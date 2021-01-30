
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer.Models;

namespace TAMWEELY.DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }
        public DbSet<TbEmployee> TbEmployees { get; set; }
        public DbSet<TbDepartment> TbDepartments { get; set; }
        public DbSet<TbJob> TbJobs { get; set; }
        public DbSet<TbUser> TbUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=HASSAN-MOFTAH-P;Initial Catalog=TAMWEELYDb;integrated security=true;Connect Timeout=50");
            }
        }
       

    }
}
