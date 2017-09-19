using System;
using System.Collections.Generic;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
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

        public void AddReceipt(Receipt receipt)
        {
            receipt.Location = new Location()
            {
                Name = "name"
            };
            var request = new RestRequest("receipts", Method.POST);
            request.AddParameter("Date", receipt.Date);
            request.AddParameter("Location", receipt.Location);
            request.AddJsonBody(receipt.Products);

            _restHelper.ExecutePost(request);
        }
    }
}