using DemoProject.Data;
using DemoProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class AdminRepo
    {

        public DemoProjectDbContext _dbContext;
        public AdminRepo(DemoProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Admin> GetEmployees()
        {
            return _dbContext.Admins;

        }
        public IEnumerable<Admin> GetAdminbyemail(string Email)
        {
            return _dbContext.Admins.Where(i => i.Email == Email);
        }

        public Admin Addemployee(Admin employee)
        {
            _dbContext.Admins.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }
        public bool Adminlogin(string email, string password)
        {
            var admin = this._dbContext.Admins.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return admin == null ? false : true;
        }

        public bool Adminsignup(string email)
        {
            var user = _dbContext.Admins.Where(u => u.Email == email).FirstOrDefault();
            return user == null ? false : true;

        }

    }
}
