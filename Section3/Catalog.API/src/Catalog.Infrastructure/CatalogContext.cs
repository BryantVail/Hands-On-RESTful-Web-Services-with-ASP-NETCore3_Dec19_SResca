using System;
using System.Collections.Generic;
using System.Text;
//user namespaces
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.SchemaDefinitions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace Catalog.Infrastructure
{
    public class CatalogContext : DbContext, IUnitOfWork
    {

        public const string DEFAULT_SCHEMA = "catalog";

        public DbSet<Item> Items { get; set; }
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        //Creates the model from the Configuration in 'Catalog.Infrastructure.SchemaDefinitions' namespace 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ItemEntitySchemaConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntitySchemaConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEntitySchemaConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }


    }
}
