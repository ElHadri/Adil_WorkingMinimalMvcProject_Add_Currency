using System.Collections.Generic;

namespace DomainLogic.Interfaces
{
    public interface IProductService
    {
        // applies business logic
        public IEnumerable<FeaturedDiscountedProduct> GetFeaturedDiscountedProducts();
    }
}
