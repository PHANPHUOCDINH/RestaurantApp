using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Route
{
    public class ApiRoute
    {
        public const string GetAllTable = "getalltable";
        public const string UpdateTableStatus = "updatetablestatus";
        public const string GetAllDishAsync = "getalldish";
        public const string AddDish = "adddish";
        public const string GetDishById = "getdishbyid/{id?}";
        public const string UpdateDish = "updatedish";
        public const string DeleteDish = "deletedish/{id?}";
        public const string GetAllOrderAsync = "getallorder";
        public const string GetOrderById = "getorderbyid/{id?}";
        public const string AddOrder = "addorder";
        public const string UpdateOrder = "updateorder";
        public const string DeleteOrder = "deleteorder/{id?}";
        public const string GetAllOrderDetail = "getallorderdetail/{cookid?}";
        public const string GetAllOrderDetailByIdOrder = "getallorderdetailbyidorder/{id?}";
        public const string GetOrderDetailById = "getbyid/{id?}";
        public const string AddOrderDetail = "addorderdetail";
        public const string DeleteOrderDetail = "deleteorderdetail/{id?}";
        public const string UpdateCookRequest = "updatecookrequest/{id?}/{cook_id?}/{starttime?}/{endtime?}";
        public const string UpdateStatus = "updatecookrequest/{id?}/{status?}";
        public const string GetAllStaffAsync = "getallstaff";
        public const string InsertStaff = "addstaff";
        public const string DeleteStaff = "deletestaff/{id?}";
        public const string GetById = "getstaffbyid/{id?}";
        public const string GetByUsername = "getstaffbyusername/{username?}";
        public const string UpdateStaff = "updatestaff";
    }
}
