using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; }

        public string OrderId { get; set; }

        public string DishId { get; set; }

        public string CookId { get; set; }

        public string OrderDetailStatus { get; set; }

        public DateTime? OrderDetailStarttime { get; set; }

        public DateTime? OrderDetailEndtime { get; set; }

        public bool OrderDetailIsDeleted { get; set; }
    }
}
