using System.ComponentModel;

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
        public int PageSize { get; set; }
        public int Page { get; set; }
    }

    public class ProductGetAllResponse
    {
        public List<ProductCreateResponse> Products { get; set; } = new List<ProductCreateResponse>();
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}

