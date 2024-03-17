using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class SPGetAllStudentDataEntity
    {
        public int StudentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FacultyUserName { get; set; }
        public string? Password { get; set; }
        public Guid? FacultyID { get; set; }
        public string? studentCourseEntities { get; set; }
    }
}
