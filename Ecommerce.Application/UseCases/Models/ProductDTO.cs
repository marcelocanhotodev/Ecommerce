using System.Reflection.Metadata.Ecma335;

namespace Ecommerce.Application.UseCases.Models
{
    public class ProductCreateRequest
    {
        public string Ean { get; set; } = default!;
        public long BrandId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }

    public class ProductCreateResponse
    {
        public long Id { get; set; }
        public string Ean { get; set; } = default!;
        public long BrandId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class ProductGetAllRequest
    {
        public int Id { get; set; }
    }

    public class ProductGetAllResponse
    {
        public List<ProductCreateResponse> Products { get; set; } = new List<ProductCreateResponse>();
    }
}

