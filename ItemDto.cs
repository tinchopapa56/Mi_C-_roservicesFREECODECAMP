
namespace Play.Catalog.Service.Dtos
{
    public record ItemDto (Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedAt);
    public record CreateItemDto (string Name, string Description, decimal Price);
    public record UpdateItemDto (string Name, string Description, decimal Price);

    // public class ItemDto {
    //     public Guid Id { get; set; }
    //     [Required]
    //     public string Name { get; set; }
    //     public string Description { get; set; }
    //     [Range(0, 1000)]
    //     public decimal Price { get; set; }
    //     public DateTime Date { get; set; }
    // }
}