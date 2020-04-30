using System;

namespace VAT
{
    public interface IModel
    {
        string ProductName { get; set; }
        DateTime Date { get; set; }
        string CheckNo { get; set; }
        string CompanyName { get; set; }
        string Price { get; set; }
    }
}