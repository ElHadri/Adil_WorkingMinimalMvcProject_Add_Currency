﻿using System;
using System.Collections.Generic;
using DomainLogic;
using System.Linq;
using DomainLogic.Interfaces;

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
        public IEnumerable<FeaturedProduct> GetFeaturedProducts()
        {
            return from product in _context.Products
                   where product.IsFeatured
                   select new FeaturedProduct
                   {
                       Name = product.Name,
                       UnitPrice = new Money(product.UnitPrice, Currency.EUR) // supposons que la DB enregistre l'euro
                   };
        }
    }
}
