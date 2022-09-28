using DemoProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data
{
    public class DemoProjectDbContext:DbContext
    {
        public DemoProjectDbContext(DbContextOptions<DemoProjectDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<WasteUser> WasteUsers { get; set; }

        

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Waste> Wastes { get; set; }


    }
}
