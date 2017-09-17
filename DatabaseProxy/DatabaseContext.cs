using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Utils;

namespace FinancialControl.Database
{ 
    

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=FCdbConnectionString")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }

        public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                context.Users.Add(new User { Login = "admin", Password = "admin".Hash() });
                base.Seed(context);
            }
        }
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public byte[] Password { get; set; }
    }
}