using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FinancialControl.Database.Tables;
using Utils;

namespace FinancialControl.Database
{


    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=FCdbConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Product> Products { get; set; }

        public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                context.Users.Add(new User { Login = "admin", Password = "admin".Hash() });
                context.Categories.Add(new Category()
                {
                    Color = new Color() { R = 255, G = 255, B = 25 },
                    Title = "Other",
                    Description = "Other"
                });
                base.Seed(context);
            }
        }
    }
}