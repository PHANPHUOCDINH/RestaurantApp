using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Models;
using RestaurantApp.Route;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService service;
        public TableController(ITableService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(ApiRoute.GetAllTable)]
        public async Task<List<Table>> GetAllTableAsync()
        {
            return await service.GetAllTableAsync();
        }

        //[HttpGet("test")]
        //public async Task<IActionResult> GetTests()
        //{

        //    ITestService _service;
        //    var service = (ITestService)ServiceProvider.GetService(typeof(ITestService));
        //    return Ok(await _service.GetAllTestAsync());
        //} 
        [Authorize]
        [HttpPost(ApiRoute.UpdateTableStatus)]
        public void UpdateTableStatus([FromBody] Table table)
        {
      //      service.UpdateTableStatus(table);
        }
    }
}
