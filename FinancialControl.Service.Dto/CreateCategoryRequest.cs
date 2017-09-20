using ServiceStack;

namespace FinancialControl.Service.Dto
{
    [Route("/categories", "POST", Summary = "Adds category")]
    public class CreateCategoryRequest : IReturnVoid
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
    }
}