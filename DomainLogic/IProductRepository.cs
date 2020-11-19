using System.Collections.Generic;

namespace DomainLogic
{
    public interface IProductRepository
    {
        //  returning “raw” Entities from the persistence store
        public IEnumerable<FeaturedProduct> GetFeaturedProducts();
    }
}
