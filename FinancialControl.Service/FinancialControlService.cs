using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialControl.Database;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
using NodaTime;
using ServiceStack;
using ServiceStack.Web;
using Category = FinancialControl.Repositories.Category;
using Location = FinancialControl.Repositories.Location;
using Product = FinancialControl.Repositories.Dto.Product;
using Receipt = FinancialControl.Repositories.Dto.Receipt;

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
    [Route("/receipts", "POST", Summary = "Adds receipt")]
    public class AddReceiptRequest : IReturnVoid
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<Product> Products { get; set; }
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
                Color = new FinancialControl.Repositories.Color { R = c.R, G = c.G, B = c.B },
            });
        }

        public List<Category> Get(AllCategoriesRequest request)
        {
            return _proxy.GetCategories();
        }

        public void Post(AddReceiptRequest request)
        {
            _proxy.AddReceipt(new Receipt()
            {
                Products = request.Products,
                Date = LocalDate.FromDateTime(request.Date),
                Location = new Location()
                {
                    Name = request.Location
                }
            });
        }
    }
}