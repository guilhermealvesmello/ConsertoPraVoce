using ConsertoPraVoce.Regras.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsertoPraVoce.Regras.Connections
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly IDbContext _context;
		private IDbSet<T> _entities;

		public GenericRepository(IDbContext context)
		{
			this._context = context;
		}

		protected virtual IDbSet<T> Entities
		{
			get
			{
				if (_entities == null)
					_entities = _context.SetEntityEf<T>();
				return _entities;
			}
		}

		public virtual IQueryable<T> Table
		{
			get
			{
				return this.Entities;
			}
		}

		public virtual void Insert(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this.Entities.Add(entity);
			this._context.SaveChanges();
		}

		public virtual void Update(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this._context.SaveChanges();
		}

		public virtual void Delete(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			this.Entities.Add(entity);
			this._context.SaveChanges();
		}
	}
}
