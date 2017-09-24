using System.Collections.Generic;
using Product = FinancialControl.Repositories.Dto.Product;

namespace FinancialControl.Service.UnitTests
{
    public partial class FinancialControlServiceTests
    {
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
    }
}