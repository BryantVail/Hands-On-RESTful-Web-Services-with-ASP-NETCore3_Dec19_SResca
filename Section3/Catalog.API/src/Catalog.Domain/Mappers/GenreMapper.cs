// System
using System;
using System.Collections.Generic;
using System.Text;
// user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    //Map a Concrete type to a response type
    public class GenreMapper : IGenreMapper
    {

        public GenreResponse Map(Genre genre)
        {
            if (genre == null) return null;

            return new GenreResponse
            {
                GenreId = genre.GenreId,
                GenreDescription = genre.GenreDescription
            };
        }

    }
}
