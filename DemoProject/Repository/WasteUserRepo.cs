using DemoProject.Data;
using DemoProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class WasteUserRepo
    {
        public DemoProjectDbContext _dbContext;
        public WasteUserRepo(DemoProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<WasteUser> GetWasteUser()
        {
            return _dbContext.WasteUsers;
        }

        public IEnumerable<WasteUser> GetWasteUserbyid(int Id)
        {
            return _dbContext.WasteUsers.Where(i => i.Id == Id);
        }

        public IEnumerable<WasteUser> GetWasteUserbyemail(string Email)
        {
            return _dbContext.WasteUsers.Where(i => i.Email == Email);
        }

        public WasteUser Addwasteuser(WasteUser wasteuser)
        {
            _dbContext.WasteUsers.Add(wasteuser);
            _dbContext.SaveChanges();
            return wasteuser;
        }

        public bool Userlogin(string email, string password)
        {
            var user = _dbContext.WasteUsers.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user == null ? false : true;
        }

        public bool Usersignup(string email)
        {
            var user = _dbContext.WasteUsers.Where(u => u.Email == email).FirstOrDefault();
            return user == null ? false : true;

        }

    }
}
