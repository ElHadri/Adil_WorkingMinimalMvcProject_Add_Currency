using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    // POCO
    public class DiscountedProduct
    {
        public string Name { get; }
        public decimal UnitPrice { get; }

        public DiscountedProduct(string name, decimal unitPrice)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
            UnitPrice = unitPrice;
        }
    }
}

