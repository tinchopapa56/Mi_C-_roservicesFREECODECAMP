using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Interfaces;

namespace Play.Catalog.Service.Repositories
{
 public interface IRepository<T> where T : IEntity
 {
        Task CreateItem(T entity);
        Task <IReadOnlyCollection<T>> GetAllItems();
        Task<T> GetItemById(Guid id);
        Task Delete(Guid id);
        Task Update(T entity);
 }
}

