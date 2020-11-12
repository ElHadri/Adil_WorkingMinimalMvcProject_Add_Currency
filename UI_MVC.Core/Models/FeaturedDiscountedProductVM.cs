using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DomainLogic;

namespace UI_MVC.Core.Models
{
    // is a POCO,which makes it amenable to unit testing
    public class FeaturedDiscountedProductVM
    {
        private static CultureInfo PriceCulture = new CultureInfo("fr-BE");

        public string SummaryText { get; }

        // Constructor
        public FeaturedDiscountedProductVM(FeaturedDiscountedProduct product)
        {
            //to encapsulate rendering logic
            SummaryText = string.Format(PriceCulture, "{0} ({1:C})", product.Name, product.UnitPrice);
        }
    }
}
