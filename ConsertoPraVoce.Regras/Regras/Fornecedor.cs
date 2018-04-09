using ConsertoPraVoce.Regras.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Regras
{
	public partial class Fornecedor : BaseEntity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Email { get; set; }
		public string Cnpj { get; set; }
		public string InscEstadual { get; set; }
		public string Telefone { get; set; }
		public string Telefone2 { get; set; }


		public class CriarFornecedorVM
		{			
			public string Nome { get; set; }
			public string Endereco { get; set; }
			public string Email { get; set; }
			public string Cnpj { get; set; }
			public string InscEstadual { get; set; }
			public string Telefone { get; set; }
			public string Telefone2 { get; set; }
		}
		public class EditarFornecedorVM : CriarFornecedorVM
		{
			public int Id { get; set; }
		}


	}
}
