﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialControl.Database;
using FinancialControl.Repositories;
using ServiceStack;
using ServiceStack.Web;
using Category = FinancialControl.Repositories.Category;

namespace FinancialControl.Service
{
    [Route("/categories", "POST", Summary = "Adds category")]
    public class CreateCategoryRequest : IReturnVoid
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public RgbColor Color { get; set; }
    }

    [Route("/categories", "GET", Summary = "Adds category")]
    public class AllCategoriesRequest : IReturn<List<Category>>
    {

    }
    public class RgbColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
    public class FinancialControlService : IService
    {
        private readonly IDataAccessProxy _proxy;

        public FinancialControlService(IDataAccessProxy proxy)
        {
            _proxy = proxy;
        }
        public void Post(CreateCategoryRequest request)
        {
            var c = request.Color;
            _proxy.AddCategory(new Category()
            {
                Description = request.Description,
                Title = request.Title,
                Color = System.Drawing.Color.FromArgb(c.R, c.G, c.B)
            });
        }

        public List<Category> Get(AllCategoriesRequest request)
        {
            return _proxy.GetCategories();
        }
    }
}