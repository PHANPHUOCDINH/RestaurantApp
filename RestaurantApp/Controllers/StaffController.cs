﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class StaffController : Controller
    {
        private readonly IStaffService service;
        public StaffController(IStaffService service)
        {
            this.service = service;
        }

        [HttpGet(ApiRoute.GetAllStaffAsync)]
        public async Task<List<Staff>> GetAllStaffAsync(bool isactive)
        {
            return await service.GetAll(isactive);
        }

        [HttpPost(ApiRoute.InsertStaff)]
        public IActionResult InsertStaff([FromBody] Staff staff)
        {
            return Ok(service.Insert(staff));
        }

        [HttpPost(ApiRoute.DeleteStaff)]
        public void DeleteStaff(string id)
        {
            service.DeleteStaff(id);
        }

        [HttpGet(ApiRoute.GetById)]
        public Staff GetById(string id)
        {
            return service.GetStaffById(id);
        }

        [HttpGet(ApiRoute.GetByUsername)]
        public Staff GetByUsername(string username)
        {
            return service.GetStaffByUsername(username);
        }

        [HttpPost(ApiRoute.UpdateStaff)]
        public void UpdateStaff([FromBody] Staff staff)
        {
            service.Update(staff);
        }
    }
}
