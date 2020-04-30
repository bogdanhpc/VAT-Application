using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT;

namespace VAT
{
    [Table("Vat")]
    public class Vat:Entity<int>
    {
        public Vat(DateTime date, string checkNo, string companyName, string tIN, string price, string productName)
        {
            Date = date;
            CheckNo = checkNo ?? "";
            CompanyName = companyName ?? "";
            TIN = tIN ?? "";
            Price = price ?? "";
            ProductName = productName ?? "";
        }

        public Vat()
        {

        }

        public DateTime Date { get; set; }
        public string CheckNo { get; set; }
        public string CompanyName { get; set; }
        public string TIN { get; set; }
        public string Price { get; set; }
        public string ProductName { get; set; }
    }
}
