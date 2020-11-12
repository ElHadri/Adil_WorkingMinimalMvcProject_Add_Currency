using System;

namespace DomainLogic
{
    // Data object
    // POCO
    // Model (implements no interface)
    public class FeaturedDiscountedProduct
    {
        public string Name { get; }
        public decimal UnitPrice { get; }

        public FeaturedDiscountedProduct(string name, decimal unitPrice)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
            UnitPrice = unitPrice;
        }
    }
}

