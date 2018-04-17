using ConsertoPraVoce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
			try
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
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
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
				ti.ValorBruto = GerarValorBrutoItem(t);
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

		private decimal GerarValorBrutoItem(Transacao t)
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
