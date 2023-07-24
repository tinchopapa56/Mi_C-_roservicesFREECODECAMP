using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
       
    }

    public class Item : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 1000)]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}