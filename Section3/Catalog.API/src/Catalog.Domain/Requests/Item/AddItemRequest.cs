// System
using System;
using System.Collections.Generic;
using System.Text;
//file requisite
using AutoMapper;
//user defined
using Catalog.Domain.Entities;

namespace Catalog.Domain.Requests.Item
{
    public class AddItemRequest
    {

        //Attempting to add AutoMapper, not complete
        //==========================
        //private IMapper _mapper;

        //public AddItemRequest(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        public string Name { get; set; }
        public string Description { get; set; }
        public string LabelName { get; set; }
        public Price Price { get; set; }
        public string PictureUri { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Format { get; set; }
        public int AvailableStock { get; set; }
        public Guid GenreId { get; set; }
        public Guid ArtistId { get; set; }

    }
}
