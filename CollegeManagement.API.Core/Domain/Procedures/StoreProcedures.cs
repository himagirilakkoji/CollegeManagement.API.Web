using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class StoreProcedures
    {
        public string? UserLoginValidations { get; set; }
        public string? GetDepartmentdata { get; set; }
        public string? InsertFacultyDetails { get; set; }
        public string? GetAllFaculties { get; set; }
        public string? DeleteFacultyById { get; set; }
        public string? UpdateFacultyById { get; set; }
        public string? InsertStudentDetails { get; set; }
        public string? GetAllStudents { get; set; }
        public string? DeleteStudentById { get; set; }
        public string? InsertExamMarksDetails { get; set; }
        public string? CalculateCourseLevelReport { get; set; }
    }
}
