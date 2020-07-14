using System;
using System.Collections.Generic;
//class specific namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//user defined
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.SchemaDefinitions
{
    public class ItemEntitySchemaConfiguration : IEntityTypeConfiguration<Item>
    {

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .HasOne(e => e.Genre)
                .WithMany(c => c.Items)
                .HasForeignKey(k => k.GenreId);

            builder
                .HasOne(e => e.Artist)
                .WithMany(c => c.Items)
                .HasForeignKey(k => k.ArtistId);

            builder.Property(p => p.Price).HasConversion(

                p => $"{p.Amount}:{p.Currency}",
                p => new Price
                {
                    Amount = Convert.ToDecimal(
                        p.Split(':', StringSplitOptions.None)[0]),
                        Currency = p.Split(":", StringSplitOptions.None)[1]
                }
            );//end builder.Property(p => p.Price)...
        }

    }
}




