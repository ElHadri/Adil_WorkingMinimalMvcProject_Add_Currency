using System.Collections.Generic;

namespace UI_MVC.Core.Models
{
    //  is a POCO,which makes it amenable to unit testing
    public class FeaturedDiscountedProductsVM
    {
        // Property
        public IEnumerable<FeaturedDiscountedProductVM> Products { get; }

        // Constructor
        public FeaturedDiscountedProductsVM(IEnumerable<FeaturedDiscountedProductVM> products)
        {
            Products = products;
        }
    }
}
