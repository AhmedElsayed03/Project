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
    public class ClientProductConfiguration : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> builder)
        {
            //builder.HasKey(i => new { i.ClientId, i.ProductId });

            //builder.Property(p => p.StartDate)
            //       .IsRequired();

            //builder.Property(p => p.EndDate)
            //       .IsRequired(false);

            //builder.Property(p => p.License)
            //       .IsRequired();
        }

    }
}
