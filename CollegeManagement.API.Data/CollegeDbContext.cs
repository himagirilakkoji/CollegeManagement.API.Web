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
            modelBuilder.Entity<SPUserLoginValidationsEntity>().HasNoKey();
            modelBuilder.Entity<SPGetDepartmentdataEntity>().HasNoKey();
            modelBuilder.Entity<SPInsertFacultyDetailsEntity>().HasNoKey();
            modelBuilder.Entity<SPGetAllFacultyDataEntity>().HasNoKey();
            modelBuilder.Entity<SPDeleteFacultyByIdEntity>().HasNoKey();
            modelBuilder.Entity<SPUpdateFacultyByIdEntity>().HasNoKey();
            modelBuilder.Entity<SPInsertStudentDetailsEntity>().HasNoKey();
            modelBuilder.Entity<SPGetAllStudentDataEntity>().HasNoKey();
            modelBuilder.Entity<SPDeleteStudentByIdEntity>().HasNoKey();
            modelBuilder.Entity<SPInsertStudentExamMarksDetailsEntity>().HasNoKey();
            modelBuilder.Entity<SPCourseLevelReportEntity>().HasNoKey();
            modelBuilder.Entity<SPSubjectLevelReportEntity>().HasNoKey();
            modelBuilder.Entity<SPUpdateStudentByIdEntity>().HasNoKey();
            modelBuilder.Entity<SPStudentMarksEntity>().HasNoKey();
            modelBuilder.Entity<SPGetAllFacultyDataWithPaginationEntity>().HasNoKey();
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

        //Get AllFacultyDetails With Pagination DbSet
        public DbSet<SPGetAllFacultyDataWithPaginationEntity> sPGetAllFacultyDataWithPaginationEntities { get; set; }

        //Delete CurrentFacultById DbSet
        public DbSet<SPDeleteFacultyByIdEntity> sPDeleteFacultyByIdEntities { get; set; }

        //Update CurrentFacultById DbSet
        public DbSet<SPUpdateFacultyByIdEntity> sPUpdateFacultyByIdEntities { get; set; }

        //Post StudentDetails DbSet
        public DbSet<SPInsertStudentDetailsEntity> sPInsertStudentDetailsEntities { get; set; }

        //Get AllStudentDetails DbSet
        public DbSet<SPGetAllStudentDataEntity> sPGetAllStudentDataEntities { get; set; }

        //Delete CurrentStudentById DbSet
        public DbSet<SPDeleteStudentByIdEntity> sPDeleteStudentByIdEntities { get; set; }

        //Post StudentDetails DbSet
        public DbSet<SPInsertStudentExamMarksDetailsEntity> sPInsertStudentExamMarksDetailsEntities { get; set; }

        //Get CourseLevelReport DbSet
        public DbSet<SPCourseLevelReportEntity> sPCourseLevelReportEntities { get; set; }

        //Get SubjectLevelReport DbSet
        public DbSet<SPSubjectLevelReportEntity> sPSubjectLevelReportEntities { get; set; }

        //Update Student DbSet
        public DbSet<SPUpdateStudentByIdEntity> sPUpdateStudentByIdEntities { get; set; }

        //Get SubjectmarksReport DbSet
        public DbSet<SPStudentMarksEntity> sPStudentMarksEntities { get; set; }

    }
}
