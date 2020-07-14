// System
using System;
using System.Collections.Generic;
using System.Text;
// user defined
using Catalog.Domain.Entities;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;


namespace Catalog.Domain.Mappers
{
    public    interface IItemMapper
    {

        Item Map(AddItemRequest request);
        Item Map(EditItemRequest request);
        ItemResponse Map(Item item);

    }
}
