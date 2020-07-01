using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DomainLogic;

namespace UI_MVC.Core.Models
{
    // is a POCO,which makes it amenable to unit testing
    public class FeaturedProductVM
    {
        private static CultureInfo PriceCulture = new CultureInfo("fr-BE");

        public string SummaryText { get; }

        // Constructor
        public FeaturedProductVM(DiscountedProduct discountedProduct)
        {
            SummaryText = string.Format(PriceCulture, "{0} ({1:C})", discountedProduct.Name, discountedProduct.UnitPrice); //to encapsulate rendering logic
        }
    }
}
