// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// user defined
using Catalog.Domain.Mappers;
using Catalog.Domain.Repositories;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Services
{
    public class ItemService : IItemService
    {

        private readonly IItemRepository _itemRepository;
        private readonly IItemMapper _itemMapper;

        public ItemService(IItemRepository itemRepository, IItemMapper itemMapper)
        {
            _itemRepository = itemRepository;
            _itemMapper = itemMapper;
        }

        // GetItemsAsync()
        public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
        {
            var result = await _itemRepository.GetAsync();
            return result.Select(x => _itemMapper.Map(x));
        }

        //GetItemAsync(GetItemRequest request)
        public async Task<ItemResponse> GetItemAsync(GetItemRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();

            var entity = await _itemRepository.GetAsync(request.Id);

            //convert database entity into response type safe for sending
            // > Map(Item) returns: ItemResponse
            return _itemMapper.Map(entity);
        }

        public async Task<ItemResponse> AddItemAsync(AddItemRequest request)
        {
            //Map request => Item
            var item = _itemMapper.Map(request);
            // Add item to _itemRepository with new Id (& implicit properties)
            var result = _itemRepository.Add(item);

            //SAVE
            await _itemRepository.UnitOfWork.SaveChangesAsync();

            //response returned after item was successfully saved
            return _itemMapper.Map(result);
        }

        public async Task<ItemResponse> EditItemAsync(EditItemRequest request)
        {
            var existingRecord = await _itemRepository.GetAsync(request.Id);

            if(existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} Id is not present in the data set");
            }

            //return Item from request using _itemMapper.Map
            var entity = _itemMapper.Map(request);
            //return the item after update
            var result = _itemRepository.Update(entity);

            //SAVE
            await _itemRepository.UnitOfWork.SaveChangesAsync();

            //return response DTO
            return _itemMapper.Map(result);
        }

        public Task<ItemResponse> DeleteItemAsync(DeleteItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
