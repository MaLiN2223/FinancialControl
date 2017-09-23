using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialControl.Database;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
using FinancialControl.Service.Dto;
using NodaTime;
using ServiceStack;
using ServiceStack.Web;
using Category = FinancialControl.Repositories.Category;
using Location = FinancialControl.Repositories.Dto.Location;
using Product = FinancialControl.Repositories.Dto.Product;
using Receipt = FinancialControl.Repositories.Dto.Receipt;

namespace FinancialControl.Service
{
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
                Color = new Repositories.Color { R = c.R, G = c.G, B = c.B },
            });
        }

        public List<Category> Get(AllCategoriesRequest request)
        {
            return _proxy.GetCategories();
        }

        public void Post(AddReceiptRequest request)
        {
            var categories = _proxy.GetCategories();
            _proxy.AddReceipt(new Receipt()
            {
                Products = request.Products.Select(x => new Product()
                {
                    Name = x.Name,
                    Volume = x.Volume,
                    Price = x.Price,
                    Category = categories.First(y => y.Title.Equals(x.CategoryTitle))
                }).ToList(),
                Date = LocalDate.FromDateTime(request.Date),
                Location = new Location()
                {
                    Name = request.Location
                }
            });
        }
    }
}