using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Domain
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public long id { get; set; }
        public long participantid { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
    }

    [Table("order_items")] 
    public class OrderItem
    {
        [Key]
        public long id { get; set; }
        public long orderid { get; set; }
        public long productid { get; set; }
        public int quantity { get; set; }
        public decimal unitprice { get; set; }
        public decimal totalitem { get; set; }
    }
}
