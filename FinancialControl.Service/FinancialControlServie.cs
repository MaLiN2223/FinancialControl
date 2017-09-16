using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseProxy;
using ServiceStack;
using ServiceStack.Web;

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
    public class FinancialControlServie : IService
    {
        public void Post(CreateCategoryRequest request)
        {
            using (var db = new DatabaseContext())
            {
                var c = request.Color;
                db.AddCategory(new Category()
                {
                    Description = request.Description,
                    Title = request.Title,
                    Color = new Color { R = c.R, G = c.G, B = c.B }
                });
            }
        }

        public List<Category> Get(AllCategoriesRequest request)
        {
            using (var db = new DatabaseContext())
            {
                return db.Categories.Select(x => x).ToList();
            }
        }
    }
}