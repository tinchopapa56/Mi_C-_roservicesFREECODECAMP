using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Interfaces
{
    public interface IItemRepository {
        // public IEnumerable<Item> GetAllItems();
        // public Item GetItemById(Guid id);
        // public Item CreateItem(Item item);
        // public void DeleteById(Guid id);
        // public void updateItem(Guid id, Item item);
        Task CreateItem(Item entity);
        Task <IReadOnlyCollection<Item>> GetAllItems();
        Task<Item> GetItemById(Guid id);
        Task Delete(Guid id);
        Task Update(Item entity);
        
    }
    
}