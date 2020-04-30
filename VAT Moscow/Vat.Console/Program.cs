using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT;

namespace Vat.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var myContext = new VatContext();

            var plm = myContext.VatEntities.First().Id;

            var myService = new VatService(new UnityOfWork(myContext), new VatRepository(myContext));


            var all = myService.GetAll();

            foreach (var item in all)
            {
                System.Console.WriteLine(item.ProductName + "  " + item.Price);
            }
        }
    }
}
