using System;
using System.Collections.Generic;
using System.Text;
// user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public static class MappingExtensions
    {

        public static ArtistResponse MapToResponse(this Artist artist)
        {
            return new ArtistResponse
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.ArtistName
            };
        }

    }
}
