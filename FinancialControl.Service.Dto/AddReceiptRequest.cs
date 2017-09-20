using System;
using System.Collections.Generic;
using ServiceStack;

namespace FinancialControl.Service.Dto
{
    [Route("/receipts", "POST", Summary = "Adds receipt")]
    public class AddReceiptRequest : IReturnVoid
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<Product> Products { get; set; }
    }
}