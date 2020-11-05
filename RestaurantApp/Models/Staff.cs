using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Staff
    {
        public string StaffId { get; set; }

        public string RoleId { get; set; }

        public string StaffVisa { get; set; }

        public string StaffName { get; set; }

        public string StaffUsername { get; set; }

        public string StaffPassword { get; set; }

        public DateTime? StaffBirthdate { get; set; }

        public string StaffSalary { get; set; }

        public int StaffIsDeleted { get; set; }
    }
}
