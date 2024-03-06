﻿using CollegeManagement.API.Data.Entities;
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
            modelBuilder.Entity<SPUserLoginValidationsEntity>().HasNoKey();
            modelBuilder.Entity<SPGetDepartmentdataEntity>().HasNoKey();
            modelBuilder.Entity<SPInsertFacultyDetailsEntity>().HasNoKey();
            modelBuilder.Entity<SPGetAllFacultyDataEntity>().HasNoKey();
            modelBuilder.Entity<SPDeleteFacultyByIdEntity>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }


        //Address tbl DbSet
        public DbSet<AdminDetailsEntity> adminDetailstblEntities { get; set; }

        //Country tbl DbSet
        public DbSet<RolesEntity> rolestblEntities { get; set; }

        //Post LoginValidation DbSet
        public DbSet<SPUserLoginValidationsEntity> sPUserLoginValidationsEntities { get; set; }

        //Get DepatmentDetails DbSet
        public DbSet<SPGetDepartmentdataEntity> sPGetDepartmentdataEntities { get; set; }

        //Post FacultyDetails DbSet
        public DbSet<SPInsertFacultyDetailsEntity> sPInsertFacultyDetailsEntities { get; set; }

        //Get AllFacultyDetails DbSet
        public DbSet<SPGetAllFacultyDataEntity> sPGetAllFacultyDatas { get; set; }

        //Delete CurrentFacultById DbSet
        public DbSet<SPDeleteFacultyByIdEntity> sPDeleteFacultyByIdEntities { get; set; }

    }
}
