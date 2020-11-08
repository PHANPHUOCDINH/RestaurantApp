using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IAuthenticationService
    {
        public Staff Authenticate(string username, string password);
    }
}
