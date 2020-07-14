// System
using System;
using System.Collections.Generic;
using System.Text;
// user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Mappers
{
    public interface IGenreMapper
    {

        GenreResponse Map(Genre genre);

    }
}
