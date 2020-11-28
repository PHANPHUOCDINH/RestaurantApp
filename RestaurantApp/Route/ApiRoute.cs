using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Route
{
    public class ApiRoute
    {
        public const string GetAllTable = "table/getall";
        public const string UpdateTableStatus = "table/updatestatus";
        public const string GetAllDishAsync = "dish/getall";
        public const string AddDish = "dish/add";
        public const string GetDishById = "dish/{id}";
        public const string UpdateDish = "dish/update";
        public const string DeleteDish = "dish/{id}";
        public const string GetAllOrderAsync = "order/getall";
        public const string GetOrderById = "order/{id}";
        public const string AddOrder = "order/add";
        public const string UpdateOrder = "order/update";
        public const string DeleteOrder = "order/{id?}";
        public const string GetAllOrderDetail = "orderdetail/{cookid}";
        public const string GetAllOrderDetailByIdOrder = "orderdetail/byorder/{orderid}";
        public const string GetOrderDetailById = "orderdetail/byid/{id}";
        public const string AddOrderDetail = "orderdetail/add";
        public const string DeleteOrderDetail = "orderdetail/{id}";
        public const string UpdateCookRequest = "orderdetail/updatecookrequest";
        public const string UpdateStatus = "orderdetail/updatestatus";
        public const string GetAllStaffAsync = "staff/getall";
        public const string InsertStaff = "staff/add";
        public const string DeleteStaff = "staff/{id}";
        public const string GetById = "staff/{id}";
        public const string GetByUsername = "staff/byusername/{username}";
        public const string UpdateStaff = "staff/update";
        public const string Top10BestSeller = "report/topseller/{month}/{year}";
        public const string FoodFunds = "dish/allfunds";
        public const string TotalOrder = "order/total/{month}";
        public const string TotalIncome = "report/income/{month}";
        public const string GetAllRoleAsync = "role/getall";
        public const string GetRoleById = "role/{id}";
    }
}
