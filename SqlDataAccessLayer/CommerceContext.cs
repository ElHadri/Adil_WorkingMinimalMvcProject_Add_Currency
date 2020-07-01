using System;
using DomainLogic;
using Microsoft.EntityFrameworkCore;

namespace SqlDataAccessLayer
{
    public class CommerceContext : DbContext
    {
        private readonly string _connectionString;
        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString should not be empty.", "connectionString");
            _connectionString = connectionString;
        }
        public DbSet<ProductEntity> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }
    }
}
