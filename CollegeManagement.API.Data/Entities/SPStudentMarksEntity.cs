using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class SPStudentMarksEntity
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public Guid? FacultyID { get; set; }
        public string? Name { get; set; }
        public int Marks { get; set; }
        public string? classRoom { get; set; }
        public string? semester { get; set; }
    }
}
