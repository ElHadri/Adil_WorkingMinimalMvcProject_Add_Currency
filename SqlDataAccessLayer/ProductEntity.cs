using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDataAccessLayer
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsFeatured { get; set; }
    }
}
