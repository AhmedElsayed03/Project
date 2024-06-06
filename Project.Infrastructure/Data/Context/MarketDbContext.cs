using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Context
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ClientProduct> ClientProducts => Set<ClientProduct>();

        public MarketDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region ClientProduct

            builder.Entity<ClientProduct>()
                   .HasKey(i => new { i.ClientId, i.ProductId });

            builder.Entity<ClientProduct>().Property(p => p.StartDate)
                   .IsRequired();

            builder.Entity<ClientProduct>().Property(p => p.EndDate)
                   .IsRequired(false);

            builder.Entity<ClientProduct>().Property(p => p.License)
                   .IsRequired();

            #endregion

        }
    }
}
