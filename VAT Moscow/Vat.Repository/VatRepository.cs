using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT
{
    public class VatRepository : GenericRepository<Vat>, IVatRepository
    {
        public VatRepository(DbContext context) : base(context)
        {
        }

        //public override IEnumerable<Person> GetAll()
        //{
        //    return _entities.Set<Person>().Include(x => x.Country).AsEnumerable();
        //}

        public Vat GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
