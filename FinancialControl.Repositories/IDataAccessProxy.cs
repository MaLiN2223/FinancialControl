using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace FinancialControl.Repositories
{
    public interface IDataAccessProxy
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void CreateUser(string login, string password);
        List<string> GetUsers();
    }
}
