// System
using System;
using System.Collections.Generic;
using System.Text;
// user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;
// requisite
using AutoMapper;


namespace Catalog.Domain.Mappers
{
    public class CatalogProfile : Profile
    {

        public CatalogProfile()
        {
        CreateMap<ItemResponse, Item>().ReverseMap();
        CreateMap<GenreResponse, Genre>().ReverseMap();
        CreateMap<ArtistResponse, Artist>().ReverseMap();
        CreateMap<Price, PriceResponse>().ReverseMap();
        CreateMap<AddItemRequest, Item>().ReverseMap();
        CreateMap<EditItemRequest, Item>().ReverseMap();
        }

    }
}
