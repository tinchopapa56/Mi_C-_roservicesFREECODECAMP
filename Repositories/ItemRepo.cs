// using System.ComponentModel.DataAnnotations;
// using MongoDB.Driver;
// using Play.Catalog.Service.Entities;
// using Play.Catalog.Service.Interfaces;

// namespace Play.Catalog.Service.Repositories
// {
// //  public class ItemRepository : IItemRepository {
//  public class MongoRepository<T> : IRepository<T> where T : IEntity{

    
//     private const string collectionName = "items_collections";
//     private readonly IMongoCollection<Item> dbCollection;
//     private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

//     public ItemRepository(IMongoDatabase db, string collectionName)
//     {
//         dbCollection = db.GetCollection<Item>(collectionName);
        
//     }

//     public async Task<IReadOnlyCollection<Item>> GetAllItems()
//     {
//         return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
//     }
//     public async Task<Item> GetItemById(Guid id)
//     {
//         FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, id);

//         return await dbCollection.Find(filter).FirstOrDefaultAsync();
//     }
//     public async Task CreateItem(Item item)
//     {
//         if(item == null) throw new ArgumentNullException(nameof(item));
//         await dbCollection.InsertOneAsync(item);
//     }
//     public async Task Update (Item item)
//     {
//         if(item == null) throw new ArgumentNullException(nameof(item));

//         FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, item.Id);

//         await dbCollection.ReplaceOneAsync(filter, item);
//     }

//     public async Task Delete(Guid id)
//     {
//         FilterDefinition<Item> filter = filterBuilder.Eq(existing => existing.Id, id);
//         await dbCollection.DeleteOneAsync(filter);
//     }

//         public Task CreateItem(T entity)
//         {
//             throw new NotImplementedException();
//         }

//         Task<IReadOnlyCollection<T>> IRepository<T>.GetAllItems()
//         {
//             throw new NotImplementedException();
//         }

//         Task<T> IRepository<T>.GetItemById(Guid id)
//         {
//             throw new NotImplementedException();
//         }

//         public Task Update(T entity)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }