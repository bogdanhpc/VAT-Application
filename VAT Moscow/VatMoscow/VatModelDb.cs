using System;

namespace VAT
{
    public class VatModelDb : IModel
    {
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public string CheckNo { get; set; }
        public string CompanyName { get; set; }
        public string TIN { get; set; }
        public string Price { get; set; }

        public VatModelDb(string productName, DateTime date, string checkNo, string companyName, string tIN, string price)
        {
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            Date = date;
            CheckNo = checkNo ?? throw new ArgumentNullException(nameof(checkNo));
            CompanyName = companyName ?? throw new ArgumentNullException(nameof(companyName));
            TIN = tIN ?? throw new ArgumentNullException(nameof(tIN));
            Price = price ?? throw new ArgumentNullException(nameof(price));
        }
    }
}
