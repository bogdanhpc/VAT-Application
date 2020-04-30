using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            Context = new Entities();
            DbSet = Context.Set<T>();
        }

        public DbContext Context { get; set; }
        public DbSet<T> DbSet { get; set; }

        public void Add(params T[] items)
        {

            foreach (var item in items)
            {
                DbSet.Add(item);
                Context.Entry(item).State = System.Data.Entity.EntityState.Added;
            }
            SaveChanges();
        }

        public void Remove(params T[] items)
        {
            foreach (var item in items)
            {
                //DbSet.Remove(item);
                Context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            }
            SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (var item in items)
            {
                DbSet.Attach(item);
                Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> results = DbSet.AsNoTracking().Where(predicate).ToList();
            return results;
        }

        public T FindById(int id)
        {
            Expression<Func<T, bool>> lamda = Utilities.BuildLamdaForFindByKey<T>(id);
            return DbSet.AsNoTracking().FirstOrDefault(lamda);
        }
    }
}
