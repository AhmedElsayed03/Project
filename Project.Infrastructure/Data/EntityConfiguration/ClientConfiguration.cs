using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.EntityConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(i => i.Code);

            builder.Property(i => i.Code)
                   .IsRequired()
                   .HasMaxLength(9);

            builder.HasIndex(i => i.Code)
                   .IsUnique();


            builder.HasAlternateKey(i => i.Code); //For Adding Unique Contraint



            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(i => i.ClientProduct)
                   .WithOne(i => i.Client)
                   .HasForeignKey(i => i.ClientId);
        }
    }
}
