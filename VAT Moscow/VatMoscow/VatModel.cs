using System;
using VAT;

namespace VAT
{
    public class VatModel:IModel
    {
        //public string ProductName = "Продукты";
        public DateTime Date { get; set; }
        public string CheckNo { get; set; }

        public string CompanyName { get; set; }
        public string Price { get; set; }
        public string ProductName { get; set; }

        public VatModel(DateTime date, string checkNo, string companyName, string price)
        {
            Date = date;
            CheckNo = checkNo;
            CompanyName = companyName;
            Price = price;
            ProductName = "Продукты";
        }

    }
}
