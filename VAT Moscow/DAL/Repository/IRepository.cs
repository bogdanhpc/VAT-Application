using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
        void SaveChanges();

    }
}
