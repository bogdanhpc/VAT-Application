using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT
{
    public interface IVatRepository:IGenericRepository<Vat>
    {
        Vat GetById(int id);
    }
}
