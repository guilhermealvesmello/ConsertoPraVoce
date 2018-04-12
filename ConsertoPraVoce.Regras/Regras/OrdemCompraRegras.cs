using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Regras
{
	public class OrdemCompraRegras
	{
		public class CriarOrdemCompraVM
		{
			public string DescricaoCurta { get; set; }
			public string DescricaoLonga { get; set; }
			public DateTime DataCriacao { get; set; }
			public DateTime DataEdicao { get; set; }
			public int IdFornecedor { get; set; }

			public List<object> Produtos { get; set; }

			public int IdTransacao { get; set; }
		}

		public class EditarOrdemCompraVM : CriarOrdemCompraVM
		{
			public int Id { get; set; }
		}

		public class ListarOrdemCompraVM : CriarOrdemCompraVM
		{
			
		}




	}
}
