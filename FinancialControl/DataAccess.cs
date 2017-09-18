using System;
using System.Collections.Generic;
using FinancialControl.Repositories;
using RestSharp;

namespace FinancialControl
{
    public class DataAccess : IDataAccessProxy
    {
        private readonly IRestHelper _restHelper;

        public DataAccess(IRestHelper restHelper)
        {
            _restHelper = restHelper;
        }

        public List<Category> GetCategories()
        {
            var request = new RestRequest("categories", Method.GET);
            return _restHelper.ExecuteGet<List<Category>>(request);
        }

        public void AddCategory(Category category)
        {
            var request = new RestRequest("categories", Method.POST);
            request.AddParameter("Title", category.Title);
            request.AddParameter("Description", category.Description);
            request.AddParameter("Color", category.Color);
            _restHelper.ExecutePost(request);
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
}