using ConsertoPraVoce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Regras
{
	public class ProdutoRegras
	{
		CPVCEntities db = new CPVCEntities();


		public int GetProductIdOrCreateOne(int idModelo, int idTipo, int? idCor)
		{
			var prod = db.Produto.Where(p =>
						p.IdModeloAparelho == idModelo &&
						p.IdTipoProduto == idTipo &&
						p.IdCor == idCor).FirstOrDefault();
			if (prod == null)
			{
				Produto prd = new Produto();
				prd.IdModeloAparelho = idModelo;
				prd.IdTipoProduto = idTipo;
				prd.IdCor = idCor;

				db.Produto.Add(prd);
				db.SaveChanges();
				return prd.Id;
			}
			return prod.Id;
		}
	}
}
