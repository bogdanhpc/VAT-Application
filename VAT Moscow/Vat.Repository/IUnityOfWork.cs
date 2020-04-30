using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT
{
    public interface IUnityOfWork:IDisposable
    {
        int Commit();
    }
}
