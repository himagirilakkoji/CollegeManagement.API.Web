using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class FacultylistVM
    {
        public string? FacultyID { get; set; }
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Dept { get; set; }
        public List<CoursesVM>? courses { get; set; }
    }
}
