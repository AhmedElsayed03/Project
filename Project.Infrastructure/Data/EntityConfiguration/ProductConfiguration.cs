using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.IsActive)
                   .IsRequired();

            builder.HasMany(i => i.ClientProduct)
                   .WithOne(i => i.Product)
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
