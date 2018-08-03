using ConsertoPraVoce.Model;
using ConsertoPraVoce.Regras.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Regras
{
	public class OrdemCompraRegras
	{
		CPVCEntities db = new CPVCEntities();

		public OrdemCompraRegras(CriarOrdemDeCompraVM vm)
		{
			Id = vm.Id;
			Descricao = vm.Descricao;
			DescricaoLonga = vm.DescricaoLonga;
			DataCriacao = DateTime.Parse(vm.DataCriacao);
			DateTime dtEdicao;
			if (DateTime.TryParse(vm.DataEdicao, out dtEdicao))
				DataEdicao = dtEdicao;
			IdFornecedor = vm.IdFornecedor;
			IdTransacao = vm.IdTransacao;
			IdMetodoPagamento = vm.IdMetodoPagamento;

			this.Produtos = new List<ItemOrdemDeCompra>();
			foreach (var item in vm.Produtos)
			{
				this.Produtos.Add(new ItemOrdemDeCompra(item));
			}
		}

		public int Id { get; set; }
		public string Descricao { get; set; }
		public string DescricaoLonga { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime? DataEdicao { get; set; }
		public int IdFornecedor { get; set; }
		public int? IdTransacao { get; set; }
		public int IdMetodoPagamento { get; set; }
		public List<ItemOrdemDeCompra> Produtos { get; set; }

		public class ItemOrdemDeCompra
		{
			public ItemOrdemDeCompra(CriarOrdemDeCompraVM.ItemOrdemDeCompra itm)
			{
				this.IdMarca = int.Parse(itm.Marca);
				this.IdModelo = int.Parse(itm.Modelo);
				this.IdTipo = int.Parse(itm.Tipo);
				int cor;
				if (int.TryParse(itm.Cor, out cor))
					this.IdCor = int.Parse(itm.Cor);
				this.Quantidade = int.Parse(string.IsNullOrEmpty(itm.Quantidade) ? "1" : itm.Quantidade);
				this.ValorUnitario = decimal.Parse(itm.ValorUnitario);
				this.ValorTotal = decimal.Parse(itm.ValorTotal);
			}

			public int? IdProduto { get; set; }
			public int IdMarca { get; set; }
			public int IdModelo { get; set; }
			public int IdTipo { get; set; }
			public int? IdCor { get; set; }
			public int Quantidade { get; set; }
			public decimal ValorUnitario { get; set; }
			public decimal ValorTotal { get; set; }
		}

		public int SalvarOrdemDeCompra()
		{
			GravarOrdemCompra();
			BuscarIdsDeProdutos();
			SalvarEstoqueProduto();
			GerarTransacao();
			return 0;
		}

		private void GravarOrdemCompra()
		{
			var oc = new OrdemCompra();
			oc.DataCriacao = this.DataCriacao;
			oc.DataEdicao = this.DataEdicao;
			oc.DescricaoCurta = this.Descricao;
			oc.DescricaoLonga = this.DescricaoLonga;
			oc.IdFornecedor = this.IdFornecedor;

			db.OrdemCompra.Add(oc);
			db.SaveChanges();
			this.Id = oc.Id;
		}

		private void GerarTransacao()
		{
			var t = new Transacao();
			t.DataTransacao = this.DataCriacao;
			t.Descricao = string.Concat("Ordem de Compra - ", this.Descricao);
			t.ValorBruto = this.Produtos.Sum(c => c.Quantidade * c.ValorUnitario);
			t.IdCategoriaTransacao = 3; //Despesas Variáveis
			t.IdSubCategoriaTransacao = 16; //Peças para Reparo
			t.IdConta = 4;//Dinheiro
			t.IdOrdemCompra = this.Id;
			t.Parcelas = BuscarParcelasMetodoPagamento();
			t.DataModificacao = DateTime.Now;
			t.PagamentoRecorrente = false;

			TransacaoRegras tr = new TransacaoRegras();
			tr.GravarTransacao(t);

		}

		private int BuscarParcelasMetodoPagamento()
		{
			return db.MetodoPagamento.FirstOrDefault(c => c.Id == this.IdMetodoPagamento).Parcelas;
		}

		private void BuscarIdsDeProdutos()
		{
			foreach (var item in this.Produtos)
			{
				BuscarIdProduto(item);
			}
		}

		private void BuscarIdProduto(ItemOrdemDeCompra item)
		{
			ProdutoRegras pr = new ProdutoRegras();
			var id = pr.GetProductIdOrCreateOne(item.IdModelo, item.IdTipo, item.IdCor);

			item.IdProduto = id;
		}

		private void SalvarEstoqueProduto()
		{
			foreach (var item in this.Produtos)
			{
				for (int i = 0; i < item.Quantidade; i++)
				{
					GravarEstoqueProduto(item);
				}
			}
		}

		private void GravarEstoqueProduto(ItemOrdemDeCompra item)
		{
			var ep = new EstoqueProduto();
			ep.IdProduto = item.IdProduto.Value;
			ep.IdOrdemCompra = this.Id;
			ep.DataMovimentacao = DateTime.Now;
			ep.IdHistorico = 3; //Ordem de Compra
			ep.ValorUnitario = item.ValorUnitario;

			db.EstoqueProduto.Add(ep);
			db.SaveChanges();
		}

	}
}
