using System;
using System.Collections.Generic;
using System.Text;
// file requisite namespaces
using Microsoft.EntityFrameworkCore;
// user defined
using Catalog.Fixtures.Extensions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;

namespace Catalog.Fixtures
{
    public class TestCatalogContext : CatalogContext
    {

        public TestCatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        // overrides the method from Catalog.Infrastructure.CatalogContext.cs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed<Artist>("Data/artist.json");
            modelBuilder.Seed<Genre>("Data/genre.json");
            modelBuilder.Seed<Item>("Data/item.json");
        }

    }
}
