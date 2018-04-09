using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Model.ViewModel
{
	public class OrdemCompraVM
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public string DescricaoLonga { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime? DataEdicao { get; set; }
		public Fornecedor Fornecedor { get; set; }
		public Transacao Transacao { get; set; }
		public List<Tuple<Produto, int>> ItemEstoqueProduto { get; set; }
	}
}
