using System.Collections.Generic;
using ServiceStack;

namespace FinancialControl.Service.Dto
{
    [Route("/categories", "GET", Summary = "Adds category")]
    public class AllCategoriesRequest : IReturn<List<Category>>
    {

    }
}