using CollegeManagement.API.Data.Entities;
using CollegeManagement.API.Data.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data
{
    public class CollegeDbContext<T> : DbContext where T : DbContext
    {
        public CollegeDbContext(DbContextOptions<T> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new AdmintblEntityMap());
            modelBuilder.ApplyConfiguration(new RolestblEntityMap());
            base.OnModelCreating(modelBuilder);
        }


        //Address tbl DbSet
        public DbSet<AdminDetailsEntity> adminDetailstblEntities { get; set; }
        //Country tbl DbSet
        public DbSet<RolesEntity> rolestblEntities { get; set; }

    }
}
