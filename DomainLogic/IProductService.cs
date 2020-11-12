using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public interface IProductService
    {
        // applies business logic
        public IEnumerable<FeaturedDiscountedProduct> GetFeaturedDiscountedProducts();
    }
}
