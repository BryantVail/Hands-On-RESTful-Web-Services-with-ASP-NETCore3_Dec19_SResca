// System
using System;
using System.Collections.Generic;
using System.Text;
//Microsoft
using Microsoft.EntityFrameworkCore;

// user defined
using Catalog.Infrastructure;
using Catalog.Domain.Mappers;


namespace Catalog.Fixtures
{
    public class CatalogContextFactory
    {

        public readonly TestCatalogContext ContextInstance;
        public readonly IGenreMapper GenreMapper;
        public readonly IArtistMapper ArtistMapper;
        public readonly IItemMapper ItemMapper;

        public CatalogContextFactory()
        {
            var contextOptions = new DbContextOptionsBuilder<CatalogContext>()
                // using Guid to uniquely name the db
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            EnsureCreation(contextOptions);
            ContextInstance = new TestCatalogContext(contextOptions);

            GenreMapper = new GenreMapper();
            ArtistMapper = new ArtistMapper();
            ItemMapper = new ItemMapper(ArtistMapper, GenreMapper);

        }

        private void EnsureCreation(DbContextOptions<CatalogContext> contextOptions)
        {
            using var context = new TestCatalogContext(contextOptions);
            context.Database.EnsureCreated();
        }

    }
}
