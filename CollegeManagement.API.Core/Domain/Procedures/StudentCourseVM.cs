using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class StudentCourseVM
    {
        public int StudentCourseID { get; set; }
        public string? CourseName { get;set; }
        public string? BranchName { get; set; }
        public Guid FacultyID { get; set; }
        public List<StudentSubjectVM>? studentSubjectEntities { get; set; }
    }
}
