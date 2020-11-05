using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Dish
    {
        public string DishId { get; set; }

        public string DishName { get; set; }

        public string DishPrice { get; set; }

        public string DishDescription { get; set; }

        public int DishIsActive { get; set; }

        public int DishIsDeleted { get; set; }
    }
}
