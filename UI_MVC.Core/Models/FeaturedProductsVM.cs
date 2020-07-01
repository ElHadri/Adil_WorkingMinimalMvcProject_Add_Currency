using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_MVC.Core.Models
{
    //  is a POCO,which makes it amenable to unit testing
    public class FeaturedProductsVM
    {
        // Property
        public IEnumerable<FeaturedProductVM> Products { get; }

        // Constructor
        public FeaturedProductsVM(IEnumerable<FeaturedProductVM> products)
        {
            Products = products;
        }
    }
}
