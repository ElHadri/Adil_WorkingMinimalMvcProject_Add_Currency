using System;
using System.Collections.Generic;
using DomainLogic;
using System.Linq;

namespace SqlDataAccessLayer
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly CommerceContext _context;
        public SqlProductRepository(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }
        public IEnumerable<Product> GetFeaturedProducts()
        {
            return from product in _context.Products
                   where product.IsFeatured
                   select new Product { Name = product.Name, UnitPrice = product.UnitPrice, IsFeatured = product.IsFeatured };
        }
    }
}
