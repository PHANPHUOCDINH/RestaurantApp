using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Notification
    {
        public string NotiId { get; set; }

        public string CookId { get; set; }

        public string WaiterId { get; set; }

        public string NotiContent { get; set; }

        public string NotiTitle { get; set; }

        public DateTime? NotiDate { get; set; }

        public bool NotiIsDeleted { get; set; }
    }
}
