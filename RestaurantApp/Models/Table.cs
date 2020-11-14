using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Table
    {
        public string TableId { get; set; }

        public string TableName { get; set; }

        public int TableStatus { get; set; }

        public string TableIdOrderServing { get; set; }

        public bool TableIsDeleted { get; set; }
    }
}
