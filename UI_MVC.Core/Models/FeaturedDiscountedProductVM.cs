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
        // private static CultureInfo Culture;

        public string SummaryText { get; }

        // Constructor
        public FeaturedDiscountedProductVM(FeaturedDiscountedProduct product)
        {
            //to encapsulate rendering logic
            SummaryText = string.Format(new CultureInfo("fr-BE"), "{0} ({1:C})", product.Name, product.UnitPrice.Amount);
        }
    }
}
