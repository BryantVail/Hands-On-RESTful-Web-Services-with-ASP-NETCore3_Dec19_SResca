using System;
using System.Collections.Generic;
using System.Text;
//user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;


namespace Catalog.Domain.Mappers
{
    public interface IArtistMapper
    {

        public ArtistResponse Map(Artist artist);

    }
}
