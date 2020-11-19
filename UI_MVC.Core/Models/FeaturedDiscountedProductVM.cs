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
        private static CultureInfo Culture;

        public string SummaryText { get; }

        // Constructor
        public FeaturedDiscountedProductVM(FeaturedDiscountedProduct product)
        {
            //to encapsulate rendering logic
            Culture = product.UnitPrice.Currency switch
            {
                Currency.EUR => new CultureInfo("fr-BE"),
                Currency.USD => new CultureInfo("en-US"),
                Currency.MAD => new CultureInfo("ar-MA"),
                _ => new CultureInfo("fr-BE")
            };

            SummaryText = string.Format(Culture, "{0} ({1:C})", product.Name, product.UnitPrice.Amount);
        }
    }
}
