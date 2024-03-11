using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class StudentListResponceVM
    {
        public int StudentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? FacultyID { get; set; }
        public List<StudentCourseVM>? studentCourseVM { get; set; }
    }
}
