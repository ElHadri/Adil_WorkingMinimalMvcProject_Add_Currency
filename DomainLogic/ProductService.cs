using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserContext _userContext;

        public ProductService(IProductRepository productRepository , IUserContext userContext)
        {
            _productRepository = productRepository;
            _userContext = userContext;
        }

        public IEnumerable<FeaturedDiscountedProduct> GetFeaturedDiscountedProducts()
        {
            IEnumerable<FeaturedProduct> products = _productRepository.GetFeaturedProducts();
            return from product in products
                   select product.ApplyDiscountFor(_userContext);
        }
    }
}