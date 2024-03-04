using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class DepartmentDataVM
    {
        public int? departmentId { get; set; }
        public string? departmentName { get; set; }
        public List<CoursesVM>? courses { get; set; }
    }
}
