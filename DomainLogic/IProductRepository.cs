using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DomainLogic
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetFeaturedProducts(); 
    }
}
