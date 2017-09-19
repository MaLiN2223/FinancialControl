using System.Collections.Generic;
using System.Linq;
using NodaTime;

namespace FinancialControl.Repositories.Dto
{
    public class Receipt
    {
        public LocalDate Date { get; set; }
        public Location Location { get; set; }
        public double OverallValue => Products.Sum(x => x.Price);
        public List<Product> Products { get; set; } = new List<Product>();
    }
}