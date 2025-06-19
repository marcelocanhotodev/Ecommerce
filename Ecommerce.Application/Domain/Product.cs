using Dapper.Contrib.Extensions;

namespace Ecommerce.Application.Domain
{
    [Table("products")]
    public class Product
    {
        [Key]
        public long id { get; set; }

        public string ean { get; set; } = string.Empty;
        public long brandid { get; set; }
        public string name { get; set; } = string.Empty;
        public string? description { get; set; }
        public DateTime createdat { get; set; } = DateTime.UtcNow;
        public DateTime? updatedat { get; set; }
    }
}
