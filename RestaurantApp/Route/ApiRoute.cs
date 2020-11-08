using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Route
{
    public class ApiRoute
    {
        public static string GetAllTable = "getalltable";
        public static string GetAllTableAsyncUpdateTableStatus = "updatetablestatus";
        public static string GetAllDishAsync = "getalldish";
        public static string AddDish = "adddish";
        public static string GetDishById = "getdishbyid/{id?}";
        public static string UpdateDish = "updatedish";
        public static string DeleteDish = "deletedish/{id?}";
        public static string GetAllOrderAsync = "getallorder";
        public static string GetOrderById = "getorderbyid/{id?}";
        public static string AddOrder = "addorder";
        public static string UpdateOrder = "updateorder";
        public static string DeleteOrder = "deleteorder/{id?}";
        public static string GetAllOrderDetail = "getallorderdetail";
        public static string GetAllOrderDetailByIdOrder = "getallorderdetailbyidorder/{id?}";
        public static string GetOrderDetailById = "getbyid/{id?}";
        public static string AddOrderDetail = "addorderdetail";
        public static string DeleteOrderDetail = "deleteorderdetail/{id?}";
        public static string UpdateCookRequest = "updatecookrequest/{id?}/{cook_id?}/{starttime?}/{endtime?}";
        public static string UpdateStatus = "updatecookrequest/{id?}/{status?}";
        public static string GetAllStaffAsync = "getallstaff";
        public static string InsertStaff = "addstaff";
        public static string DeleteStaff = "deletestaff/{id?}";
        public static string GetById = "getstaffbyid/{id?}";
        public static string GetByUsername = "getstaffbyusername/{username?}";
        public static string UpdateStaff = "updatestaff";
    }
}
