using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FinancialControl.Database.Tables
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Location Location { get; set; }
        public double OverallValue => Products.Sum(x => x.Price);
        public virtual List<Product> Products { get; set; }
    }

    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Name { get; set; }
    }
}
