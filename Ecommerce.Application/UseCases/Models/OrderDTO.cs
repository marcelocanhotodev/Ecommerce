using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Models
{
    public class OrderCreateRequest
    {
        public long ParticipantId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

    }

    public class OrderCreateResponse
    {
        public long Id { get; set; }
        public long ParticipantId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
