using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class CoursesVM
    {
        public int courseId { get; set; }
        public string? courseName { get; set; }
        public List<SubjectsVM>? subjects{ get; set; }
    }
}
