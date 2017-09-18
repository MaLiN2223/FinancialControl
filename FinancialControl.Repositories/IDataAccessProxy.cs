
using System.Collections.Generic;

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
