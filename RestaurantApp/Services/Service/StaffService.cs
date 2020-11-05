﻿using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantApp.Services.Service
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext context;

        public StaffService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool CheckLogIn(string username,string password)
        {
            return true;
        }

        public void DeleteStaff(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id).FirstOrDefault();
            obj.StaffIsDeleted = 1;
            context.Staff.Update(obj);
            context.SaveChanges();
        }

        public List<Staff> GetAll()
        {
             return context.Staff.Where(x=>x.StaffIsDeleted==0).ToList(); 
        }

        public Staff GetStaffById(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id).FirstOrDefault();
            return (Staff)obj;
        }

        public Staff GetStaffByUsername(string username)
        {
            var obj = context.Staff.Where(x => x.StaffUsername == username).FirstOrDefault();
            return (Staff)obj;
        }

        public void Insert(Staff staff)
        {
            staff.StaffId = Guid.NewGuid().ToString();
            staff.StaffIsDeleted = 0;
            context.Staff.Add(staff);
            context.SaveChanges();
        }

        public void Update(Staff staff)
        {
            var obj = context.Staff.Where(x => x.StaffId == staff.StaffId).FirstOrDefault();
            obj.StaffName = staff.StaffName;
            obj.RoleId = staff.RoleId;
            obj.StaffVisa = staff.StaffVisa;
            obj.StaffUsername = staff.StaffUsername;
            obj.StaffPassword = staff.StaffPassword;
            obj.StaffBirthdate = staff.StaffBirthdate;
            obj.StaffSalary = staff.StaffSalary;
            context.Staff.Update(obj);
            context.SaveChanges();

        }
    }
}
