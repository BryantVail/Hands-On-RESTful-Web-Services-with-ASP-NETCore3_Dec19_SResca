﻿// System
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
// Other
using Shouldly;
using Xunit;
// User Defined
using Catalog.Infrastructure.Repositories;
using Catalog.Domain.Entities;
using Catalog.Domain.Mappers;
using Catalog.Fixtures;
using Catalog.Domain.Services;
using Catalog.Domain.Requests.Item;

namespace Catalog.Domain.Tests.Services
{
    public class ItemServiceTests : IClassFixture<CatalogContextFactory>
    {

        private readonly ItemRepository _itemRepository;
        private readonly IItemMapper _mapper;

        public ItemServiceTests(CatalogContextFactory catalogContextFactory)
        {
            _itemRepository = new ItemRepository(catalogContextFactory.ContextInstance);
            _mapper = catalogContextFactory.ItemMapper;
        }

        [Fact]
        public async Task getitems_should_return_right_data()
        {
            ItemService sut = new ItemService(_itemRepository, _mapper);

            var result = await sut.GetItemsAsync();
            result.ShouldNotBeNull();
        }

        // GetItemAsync(Guid)
        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task getitem_should_return_right_data(string guid)
        {
            ItemService sut = new ItemService(_itemRepository, _mapper);

            var result = await sut.GetItemAsync(new GetItemRequest { Id = new Guid(guid) });

            result.Id.ShouldBe(new Guid(guid));
        }

        [Fact]
        public void getitem_should_thrown_exception_with_null_id()
        {
            ItemService sut = new ItemService(_itemRepository, _mapper);

            sut.GetItemAsync(null).ShouldThrow<ArgumentNullException>();
        }

        //AddItemAsync(item)
        [Fact]
        public async Task additem_should_add_right_entity()
        {
            var testItem = new AddItemRequest
            {
                Name = "Test album",
                Description = "Description",
                LabelName = "Label name",
                Price = new Price { Amount = 13, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

            IItemService sut = new ItemService(_itemRepository, _mapper);

            var result = await sut.AddItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
            result.Price.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
        }

        //EditItemAsync(item)
        [Fact]
        public async Task edititem_should_add_right_entity()
        {
            // the request for the Item resource
            var testItem = new EditItemRequest
            {
                Id = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e"),
                Name = "Test album",
                Description = "Description",
                LabelName = "Label name",
                Price = new Price { Amount = 13, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

            ItemService sut = new ItemService(_itemRepository, _mapper);

            var result = await sut.EditItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.LabelName.ShouldBe(testItem.LabelName);
            result.Price.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
        }
    }
}