using Dapper.Contrib.Extensions;

namespace Ecommerce.Application.Domain
{
    [Table("participants")]
    public class Participant
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; } = string.Empty;

        public string document { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string phone { get; set; } = string.Empty;

        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; } 
    }
}
