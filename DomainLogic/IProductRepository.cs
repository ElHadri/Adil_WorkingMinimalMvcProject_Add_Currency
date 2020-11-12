using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DomainLogic
{
    public interface IProductRepository
    {
        //  returning “raw” Entities from the persistence store
        public IEnumerable<FeaturedProduct> GetFeaturedProducts(); 
    }
}
