using DomainLogic.Interfaces;

using System;

namespace DomainLogic
{
    // short-lived object
    // Data Object[POCO, DTO, view model, ...] ( contain no behavior that requires mocking, Interception, decoration, or replacement. )
    // Is a POCO (car il n'a pas toujours besoin d'une dépedance !!)
    // Is an Entity (si je le nomme Product)
    public class FeaturedProduct // je pense mieux de changer le nom et mettre "Product"
    {
        public string Name { get; set; }
        public Money UnitPrice { get; set; }

        public FeaturedProduct ApplyOtherCurency(Currency otherCurrency, ICurrencyConverter currencyConverter)
        {
            if (currencyConverter == null)
                throw new ArgumentNullException("converter");

            return new FeaturedProduct
            {
                Name = Name,
                UnitPrice = currencyConverter.Exchange(UnitPrice, otherCurrency),
            };
        }


        public FeaturedDiscountedProduct ApplyDiscountFor(IUserContext user)
        {
            bool preferred = user.IsInRole(Role.PreferredCustomer);
            decimal discount = preferred ? .95m : 1.00m;

            return new FeaturedDiscountedProduct(Name, new Money(UnitPrice.Amount * discount, UnitPrice.Currency));
        }
    }
}