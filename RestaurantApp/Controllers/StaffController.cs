using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
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

        [HttpGet("getallstaff")]
        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await service.GetAll();
        }

        [HttpPost("addstaff")]
        public void InsertStaff([FromBody]Staff staff)
        {
            service.Insert(staff);
        }

        [HttpPost("deletestaff/{id?}")]
        public void DeleteStaff(string id)
        {
            service.DeleteStaff(id);
        }

        [HttpGet("getstaffbyid/{id?}")]
        public Staff GetById(string id)
        {
            return service.GetStaffById(id);
        }

        [HttpGet("getstaffbyusername/{username?}")]
        public Staff GetByUsername(string username)
        {
            return service.GetStaffByUsername(username);
        }

        [HttpPost("updatestaff")]
        public void UpdateStaff([FromBody] Staff staff)
        {
            service.Update(staff);
        }
    }
}
