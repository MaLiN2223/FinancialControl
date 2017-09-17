using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialControl.Database
{
    public class Category
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }
}