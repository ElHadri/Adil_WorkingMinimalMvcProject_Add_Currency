using System;
using DomainLogic;
using Microsoft.EntityFrameworkCore;

namespace SqlDataAccessLayer
{
    // exposes products
    public class CommerceContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }

        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString should not be empty.", "connectionString");
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }
    }
}
