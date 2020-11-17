using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            // bool isSuccess = false;
            //Staff user = context.Staff.Where(x => !(x.StaffUsername != username)).FirstOrDefault();
            //if (user!=null && BCrypt.Net.BCrypt.Verify(password, user.StaffPassword))
            //{
            //    return user;
            //}
            //else
            //    return null;
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
                return false ;
        }

        public void DeleteStaff(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id).FirstOrDefault();
            obj.StaffIsActive = true;
            context.Staff.Update(obj);
            context.SaveChanges();
        }

        public async Task<List<Staff>> GetAll()
        {
            return await context.Staff.Where(x => !x.StaffIsActive).ToListAsync();
        }

        public Staff GetStaffById(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id && !x.StaffIsActive).FirstOrDefault();
            return (Staff)obj;
        }

        public Staff GetStaffByUsername(string username)
        {
            var obj = context.Staff.Where(x => x.StaffUsername == username && !x.StaffIsActive).FirstOrDefault();
            return (Staff)obj;
        }

        public void Insert(Staff staff)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(staff.StaffPassword, 12);
            //staff.StaffPassword = passwordHash;
            staff.StaffId = Guid.NewGuid().ToString();
            staff.StaffIsActive = false;
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
