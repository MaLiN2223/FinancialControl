using System.ComponentModel.DataAnnotations;

namespace FinancialControl.Database.Tables
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
    }
}
