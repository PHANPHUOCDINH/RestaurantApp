using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Dish
    {
        public Dish()
        {
            num = 0;
        }
        public string DishId { get; set; }

        public string DishName { get; set; }

        public decimal DishPrice { get; set; }

        public string DishDescription { get; set; }

        public bool DishIsActive { get; set; }

        public int num { get; set; }

        public decimal DishFunds { get; set; }
        public string DishImage { get; set; }
    }
}
