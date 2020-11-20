using System.Collections.Generic;

namespace DomainLogic.Interfaces
{
    public interface IProductRepository
    {
        //  returning “raw” Entities from the persistence store
        public IEnumerable<FeaturedProduct> GetFeaturedProducts();
    }
}
