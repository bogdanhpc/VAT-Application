using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace VAT
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        //private DbContext _entities;
        //private readonly IDbSet<T> _dbSet;

        protected DbContext Entities { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public GenericRepository(DbContext context)
        {
            Entities = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = DbSet.Where(predicate).AsEnumerable();
            return query;
        }
        public virtual T Add(T entity)
        {
            return DbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            Entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual T Remove(T entity)
        {
            return DbSet.Remove(entity);
        }
        public void SaveChanges()
        {
            Entities.SaveChanges();
        }
    }
}
