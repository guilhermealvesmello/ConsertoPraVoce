using ConsertoPraVoce.Regras.Regras;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Mappings
{
	public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
	{
		public FornecedorMap()
		{
			this.ToTable("Fornecedor");
			this.HasKey(c => c.Id);
		}

	}
}
