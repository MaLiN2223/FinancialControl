using FinancialControl.Repositories;
using FinancialControl.Service.Dto;
using NSubstitute;
using Xunit;
using Category = FinancialControl.Repositories.Category;

namespace FinancialControl.Service.UnitTests
{
    public class FinancialControlServiceTests
    {
        private IDataAccessProxy _proxy;
        private FinancialControlService _service;

        public FinancialControlServiceTests()
        {
            _proxy = Substitute.For<IDataAccessProxy>();
            _service = new FinancialControlService(_proxy);
        }
        [Fact]
        public void Post_CreateCategoryRequest_CalledProxyAddCategory()
        {
            _service.Post(new CreateCategoryRequest()
            {
                Color = new Dto.Color()
            });
            _proxy.Received(1).AddCategory(Arg.Any<Category>());
        }

        [Fact]
        public void Post_CreateCategoryRequest_CalledProxyAddCategoryWithArgs()
        {
            var color = new { R = (byte)10, G = (byte)30, B = (byte)50 };
            string description = "description";
            string title = "title";

            _service.Post(new CreateCategoryRequest()
            {
                Color = new Dto.Color() { R = color.R, G = color.G, B = color.B },
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
