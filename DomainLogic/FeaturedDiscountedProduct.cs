using System;

namespace DomainLogic
{
    // Data object
    // POCO
    // Model (implements no interface)
    public class FeaturedDiscountedProduct
    {
        public string Name { get; }
        public Money UnitPrice { get; }

        public FeaturedDiscountedProduct(string name, Money unitPrice)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
            UnitPrice = unitPrice;
        }
    }
}

