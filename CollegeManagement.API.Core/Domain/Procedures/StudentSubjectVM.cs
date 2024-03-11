using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class StudentSubjectVM
    {
        public int StudentSubjectID { get; set; }
        public string? SubjectName { get; set; }
        public Guid FacultyID { get; set; }
    }
}
