using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        public string TableId { get; set; }

        public string WaiterId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? OrderStarttime { get; set; }

        public DateTime? OrderEndtime { get; set; }

        public string OrderTotal { get; set; }

        public string OrderStatus { get; set; }

        public int OrderIsDeleted { get; set; }
    }
}
