using ConsertoPraVoce.Regras.Connections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Interfaces
{
	public interface IDbContext
	{
		IDbSet<TEntity> SetEntityEf<TEntity>() where TEntity : BaseEntity;

		int SaveChanges();
	}
}
