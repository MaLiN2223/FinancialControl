using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Utils;

namespace DatabaseProxy
{
    public class DatabaseContext : DbContext
    {
        public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                context.Users.Add(new User() { Login = "admin", Password = "admin".Hash() });
                base.Seed(context);
            }
        }
        public DatabaseContext() : base("name=FCdbConnectionString")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());

        }
        public List<Category> GetCategories()
        {
            return Categories.Select(x => x).ToList();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<int> CreateUser(string login, string password)
        {
            Users.Add(new User() { Login = login, Password = password.Hash() });
            return this.SaveChangesAsync();
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
            SaveChanges();
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
