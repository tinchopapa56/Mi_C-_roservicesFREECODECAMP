using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;

namespace Play.Catalog.Service.Repositories
{
//  public class ItemRepository : IItemRepository {
 public class MongoRepository<T> : IRepository<T> where T : IEntity{
       private const string collectionName = "items_collections";
       private readonly IMongoCollection<T> dbCollection;
       private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;
       public MongoRepository(IMongoDatabase db, string collectionName)
       {
           dbCollection = db.GetCollection<T>(collectionName);
       }
       public async Task<IReadOnlyCollection<T>> GetAllItems()
       {
           return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
       }
       public async Task<T> GetItemById(Guid id)
       {
           FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
           return await dbCollection.Find(filter).FirstOrDefaultAsync();
       }
       public async Task CreateItem(T item)
       {
           if(item == null) throw new ArgumentNullException(nameof(item));
           await dbCollection.InsertOneAsync(item);
       }
       public async Task Update (T item)
       {
           if(item == null) throw new ArgumentNullException(nameof(item));
           FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, item.Id);
           await dbCollection.ReplaceOneAsync(filter, item);
       }
       public async Task Delete(Guid id)
       {
           FilterDefinition<T> filter = filterBuilder.Eq(existing => existing.Id, id);
           await dbCollection.DeleteOneAsync(filter);
       }
    }
}