using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using RestaurantApp.Models;
using RestaurantApp.Route;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class StaffController:Controller
    {
        private readonly IStaffService service;
        public StaffController(IStaffService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(ApiRoute.GetAllStaffAsync)]
        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await service.GetAll();
        }

        [Authorize]
        [HttpPost(ApiRoute.InsertStaff)]
        public void InsertStaff([FromBody]Staff staff)
        {
            service.Insert(staff);
        }

        [Authorize]
        [HttpPost(ApiRoute.DeleteStaff)]
        public void DeleteStaff(string id)
        {
            service.DeleteStaff(id);
        }

        [Authorize]
        [HttpGet(ApiRoute.GetById)]
        public Staff GetById(string id)
        {
            return service.GetStaffById(id);
        }

        [Authorize]
        [HttpGet(ApiRoute.GetByUsername)]
        public Staff GetByUsername(string username)
        {
            return service.GetStaffByUsername(username);
        }

        [Authorize]
        [HttpPost(ApiRoute.UpdateStaff)]
        public void UpdateStaff([FromBody] Staff staff)
        {
            service.Update(staff);
        }
    }
}
