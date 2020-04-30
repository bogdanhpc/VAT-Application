using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Utilities
    {
        internal static Expression<Func<T, bool>> BuildLamdaForFindByKey<T>(int id)
        {
            var item = Expression.Parameter(typeof(T), "entity");
            var prop = Expression.Property(item, "Id");
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lamda = Expression.Lambda<Func<T, bool>>(equal, item);
            return lamda;
        }
    }
}
