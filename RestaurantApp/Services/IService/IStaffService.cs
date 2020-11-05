using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IStaffService
    {
        void Insert(Staff staff);

        void Update(Staff staff);

        List<Staff> GetAll();

        Staff GetStaffById(string id);

        Staff GetStaffByUsername(string username);

        bool CheckLogIn(string username, string password);

        void DeleteStaff(string id);

       
    }
}
