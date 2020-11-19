using System.Collections.Generic;

namespace DomainLogic
{
    public interface IProductService
    {
        // applies business logic
        public IEnumerable<FeaturedDiscountedProduct> GetFeaturedDiscountedProducts();
    }
}
