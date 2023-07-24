using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service 
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> _ItemsRepo;

        public ItemController(IRepository<Item> itemRepository)
        {
            _ItemsRepo = itemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> Get()
        {
            var items = (await _ItemsRepo.GetAllItems()).Select(items => items.AsDto());
            return items;
        }

        //GET http://stackoverflow.com/Items/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetById(Guid id)
        {
            // var item = items.Where(i => i.Id == id).SingleOrDefault();
            var item = await _ItemsRepo.GetItemById(id);

            if(item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
       
        [HttpPost]
        public async Task<ActionResult<ItemDto>> Post(CreateItemDto itemDto)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _ItemsRepo.CreateItem(item);
            return CreatedAtAction(nameof(GetById), new {Id = item.Id}, item);
        }
        //PUT http://stackoverflow.com/Items/:id
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateItemDto updateItem)
        {
            Item existingItem = await _ItemsRepo.GetItemById(id);
            if(existingItem == null) return NotFound();
            //should make update 

            existingItem.Name = updateItem.Name;
            existingItem.Description = updateItem.Description;
            existingItem.Price = updateItem.Price;

            await _ItemsRepo.Update(existingItem);

            return NoContent();
        }
        // DELETE http://stackoverflow.com/Items/:id
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Item item = await _ItemsRepo.GetItemById(id);
            
            if(item == null) return NotFound();

            await _ItemsRepo.Delete(item.Id);
            
            return NoContent();
        }
    }
}