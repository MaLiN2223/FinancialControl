using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
using FinancialControl.Service.Dto; 
using ServiceStack;
using Category = FinancialControl.Repositories.Category;
using Color = FinancialControl.Repositories.Color;

namespace FinancialControl
{
    public class DataAccess : IDataAccessProxy
    {
        private readonly IServiceClient _client;

        public DataAccess(IServiceClient client)
        {
            this._client = client;
        }

        public List<Category> GetCategories()
        {
            return _client.Get(new AllCategoriesRequest())
                .Select(Mapper.Map<Service.Dto.Category, Category>).ToList();
        }

        public void AddCategory(Category category)
        {
            _client.Post(new CreateCategoryRequest()
            {
                Color = Mapper.Map<Color, Service.Dto.Color>(category.Color),
                Title = category.Title,
                Description = category.Description

            });
        }

        public void CreateUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsers()
        {
            throw new NotImplementedException();
        }

        public class Product
        {
            public Product(Repositories.Dto.Product product)
            {
                Name = product.Name;
                Volume = product.Volume;
                Price = product.Price;
                CategoryName = product.Category.Title;
            }
            public string Name { get; set; }
            public float Volume { get; set; }
            public float Price { get; set; }
            public string CategoryName { get; set; }
        }

        public void AddReceipt(Receipt receipt)
        {
            _client.Post(new AddReceiptRequest()
            {
                Products = receipt.Products.Select(x => new Service.Dto.Product()
                {
                    CategoryTitle = x.Category.Title,
                    Name = x.Name,
                    Volume = x.Volume,
                    Price = x.Price
                }).ToList(),
                Location = receipt.Location.Name,
                Date = receipt.Date.ToDateTimeUnspecified()
            });
        }
    }
}