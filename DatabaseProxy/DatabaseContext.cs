using System.Data.Entity;

namespace DatabaseProxy
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=FCdbConnectionString") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }

    public class Color
    {
        public int Id { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
}
