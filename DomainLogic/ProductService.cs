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
        private readonly ICurrencyConverter _converter;

        public ProductService(IProductRepository productRepository, IUserContext userContext, ICurrencyConverter converter)
        {
            if (productRepository == null)
                throw new ArgumentNullException("repository");
            if (userContext == null)
                throw new ArgumentNullException("userContext");
            if (converter == null)
                throw new ArgumentNullException("converter");

            _productRepository = productRepository;
            _userContext = userContext;
            _converter = converter;
        }

        // with
        public IEnumerable<FeaturedDiscountedProduct> GetFeaturedDiscountedProducts()
        {
            IEnumerable<FeaturedProduct> products = _productRepository.GetFeaturedProducts();

            return from product in products
                   select product
                   .ApplyOtherCurency(_userContext.PreferedCurrency, _converter)    // method injection
                   .ApplyDiscountFor(_userContext);                                 // method injection
        }

    }
}