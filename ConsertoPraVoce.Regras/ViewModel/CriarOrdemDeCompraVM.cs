using ConsertoPraVoce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.ViewModel
{
	public class CriarOrdemDeCompraVM
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public string DescricaoLonga { get; set; }
		public string DataCriacao { get; set; }
		public string DataEdicao { get; set; }
		public int IdFornecedor{ get; set; }
		public int? IdTransacao { get; set; }
		public int IdMetodoPagamento { get; set; }
		public List<ItemOrdemDeCompra> Produtos { get; set; }

		public class ItemOrdemDeCompra
		{
			public string Marca { get; set; }
			public string Modelo { get; set; }
			public string Tipo { get; set; }
			public string Cor { get; set; }
			public string Quantidade { get; set; }
			public string ValorUnitario { get; set; }
			public string ValorTotal { get; set; }
		}

	}



}
