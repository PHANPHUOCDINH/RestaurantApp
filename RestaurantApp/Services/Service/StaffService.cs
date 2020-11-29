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
        public bool CheckLogIn(string username, string password)
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
                return false;
        }

        public void DeleteStaff(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id).FirstOrDefault();
            obj.StaffIsActive = false;
            context.Staff.Update(obj);
            context.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetAll(bool isactive)
        {
            if(isactive)
                return await context.Staff.Where(x => x.StaffIsActive).ToListAsync();
            else
                return await context.Staff.ToListAsync();
        }

        public Staff GetStaffById(string id)
        {
            var obj = context.Staff.Where(x => x.StaffId == id).FirstOrDefault();
            return (Staff)obj;
        }

        public Staff GetStaffByUsername(string username)
        {
            var obj = context.Staff.Where(x => x.StaffUsername == username && x.StaffIsActive).FirstOrDefault();
            return (Staff)obj;
        }

        public async Task<string> Insert(Staff staff)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(staff.StaffPassword, 12);
            //staff.StaffPassword = passwordHash;
            staff.StaffId = Guid.NewGuid().ToString();
            staff.StaffIsActive = true;
            context.Staff.Add(staff);
            int i=-1;
            try { i=await context.SaveChangesAsync(); }
            catch
            {

            }
            if (i > 0)
                return staff.StaffId;
            else return null;
        }

        public async Task<string> Update(Staff staff)
        {
            var obj = context.Staff.Where(x => x.StaffId == staff.StaffId).FirstOrDefault();
            obj.StaffName = staff.StaffName;
            obj.RoleId = staff.RoleId;
            obj.StaffVisa = staff.StaffVisa;
            obj.StaffUsername = staff.StaffUsername;
            obj.StaffPassword = staff.StaffPassword;
            obj.StaffBirthdate = staff.StaffBirthdate;
            obj.StaffSalary = staff.StaffSalary;
            obj.StaffIsActive = staff.StaffIsActive;
            obj.ExternalId = staff.ExternalId;
            context.Staff.Update(obj);
            int i = -1;
            try { i = await context.SaveChangesAsync(); }
            catch
            {

            }
            if (i > 0)
                return staff.StaffId;
            else return null;
        }

    }
}
