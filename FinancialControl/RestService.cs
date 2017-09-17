using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialControl.Repositories;

namespace FinancialControl
{
    public class DataAccess : IDataAccessProxy
    {
        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
    public class RestService
    {
    }
}
