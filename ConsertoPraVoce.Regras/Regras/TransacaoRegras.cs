using ConsertoPraVoce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Regras
{
	public class TransacaoRegras
	{
		CPVCEntities db = new CPVCEntities();
		public void GravarTransacao(Transacao t)
		{			
			db.Transacao.Add(t);
			db.SaveChanges();


			//if (t.PagamentoRecorrente.HasValue && t.PagamentoRecorrente.Value)
			//{
				var itensTransacao = GerarItensTransacao(t);
				foreach (var item in itensTransacao)
				{
					GravarTransacaoItem(item);
				}
			//}
		}

		private List<TransacaoItem> GerarItensTransacao(Transacao t)
		{
			var lista = new List<TransacaoItem>();
			for (int i = 0; i < t.Parcelas; i++)
			{
				var ti = new TransacaoItem();
				ti.IdTransacao = t.Id;
				ti.DataTransacao = t.DataTransacao;
				ti.DataPrevistaCredito = BuscarDataPrevistaCredito(t, i);
				ti.ValorBruto = GerarValorBruto(t);
				ti.ValorLiquido = -1;
				ti.QuantidadeParcelas = t.Parcelas;
				ti.NumeroParcela = i + 1;
				ti.PagamentoEfetuado = false;
				ti.DataAlteracao = DateTime.Now;

				lista.Add(ti);
			}
			return lista;
		}

		private DateTime BuscarDataPrevistaCredito(Transacao t, int parcela)
		{
			return t.DataTransacao.AddDays((30 * (parcela + 1)));
		}

		private decimal GerarValorBruto(Transacao t)
		{
			return t.ValorBruto / t.Parcelas;
		}

		private void GravarTransacaoItem(TransacaoItem ti)
		{
			db.TransacaoItem.Add(ti);
			db.SaveChanges();
		}


	}
}
