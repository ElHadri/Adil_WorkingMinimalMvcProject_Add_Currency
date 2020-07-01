using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public interface IProductService
    {
        public IEnumerable<DiscountedProduct> GetDiscountedProducts();
    }
}
