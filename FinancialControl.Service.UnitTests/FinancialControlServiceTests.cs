using System;
using System.Collections.Generic;
using System.Linq;
using FinancialControl.Repositories;
using FinancialControl.Repositories.Dto;
using FinancialControl.Service.Dto;
using NSubstitute;
using Xunit;
using Category = FinancialControl.Repositories.Category;
using Color = FinancialControl.Service.Dto.Color;
using Product = FinancialControl.Repositories.Dto.Product;

namespace FinancialControl.Service.UnitTests
{
    public class FinancialControlServiceTests
    {
        public FinancialControlServiceTests()
        {
            _proxy = Substitute.For<IDataAccessProxy>();
            _service = new FinancialControlService(_proxy);
        }

        private readonly IDataAccessProxy _proxy;
        private readonly FinancialControlService _service;

        [Fact]
        public void Get_AllCategoriesRequest_ReturnsDataFromProxy()
        {
            var expectedCategories = new List<Category>
            {
                new Category(),
                new Category()
            };
            _proxy.GetCategories().Returns(expectedCategories);

            //ACT
            var actualCategories = _service.Get(new AllCategoriesRequest());

            //ASSERT

            Assert.Equal(expectedCategories, actualCategories);
        }

        [Fact]
        public void ThisShouldFail()
        {
            Assert.True(false);
        }

        [Fact]
        public void Post_AddReceiptRequest_CallsProxyWithPropperArguments()
        {
            var date = new DateTime();
            var products = new[]
            {
                new {Category = "category title0", Name = "name1", Price = 1.0f, Volume = 2.0f},
                new {Category = "category title0", Name = "name1", Price = 1.0f, Volume = 2.0f}
            }.ToList();

            var expectedCategories = products.Select(x => new Category
            {
                Title = x.Category
            }).ToList();
            _proxy.GetCategories().Returns(expectedCategories);
            var i = 0;

            var expectedProducts = products.Select(x => new Product
            {
                Category = expectedCategories[i++],
                Volume = x.Volume,
                Price = x.Price,
                Name = x.Name
            });
            var requestProducts = products.Select(x =>
                new Dto.Product
                {
                    CategoryTitle = x.Category,
                    Name = x.Name,
                    Price = x.Price,
                    Volume = x.Volume
                }
            ).ToList();
            var location = "location";

            //ACT
            _service.Post(new AddReceiptRequest
            {
                Date = date,
                Location = location,
                Products = requestProducts
            });

            //ASSERT
            _proxy.Received(1).AddReceipt(Arg.Is<Receipt>(x => x.Location.Name.Equals(location)));
            _proxy.Received(1).AddReceipt(Arg.Is<Receipt>(x => x.Date.ToDateTimeUnspecified().Equals(date)));
            _proxy.Received(1)
                .AddReceipt(Arg.Is<Receipt>(x =>
                    expectedProducts.SequenceEqual(x.Products, new ProductEqualityComparer())));
        }
        public class ProductEqualityComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (x == null || y == null)
                    return false;
                return
                    x.Category.Title.Equals(y.Category.Title) &
                    x.Name.Equals(y.Name) &
                    x.Price.Equals(y.Price) &
                    x.Volume.Equals(y.Volume);

            }

            public int GetHashCode(Product obj)
            {
                // Stores the result.
                unchecked // Overflow is fine, just wrap
                {
                    int hash = 17;
                    // Suitable nullity checks etc, of course :)
                    hash = hash * 23 + obj.Category.Title.GetHashCode();
                    hash = hash * 23 + obj.Name.GetHashCode();
                    hash = hash * 23 + obj.Price.GetHashCode();
                    hash = hash * 23 + obj.Volume.GetHashCode();
                    return hash;
                }

            }
        }
        [Fact]
        public void Post_CreateCategoryRequest_CalledProxyAddCategory()
        {
            _service.Post(new CreateCategoryRequest
            {
                Color = new Color()
            });
            _proxy.Received(1).AddCategory(Arg.Any<Category>());
        }

        [Fact]
        public void Post_CreateCategoryRequest_CalledProxyAddCategoryWithArgs()
        {
            var color = new { R = (byte)10, G = (byte)30, B = (byte)50 };
            var description = "description";
            var title = "title";

            _service.Post(new CreateCategoryRequest
            {
                Color = new Color { R = color.R, G = color.G, B = color.B },
                Description = description,
                Title = title
            });

            //ASSERT
            _proxy.Received(1).AddCategory(Arg.Is<Category>(x =>
                x.Description.Equals(description)
            ));
            _proxy.Received(1).AddCategory(Arg.Is<Category>(x =>
                x.Title.Equals(title)
            ));
            _proxy.Received(1).AddCategory(Arg.Is<Category>(x =>
                x.Color.R.Equals(color.R) && x.Color.G.Equals(color.G) && x.Color.B.Equals(color.B)
            ));
        }
    }
}