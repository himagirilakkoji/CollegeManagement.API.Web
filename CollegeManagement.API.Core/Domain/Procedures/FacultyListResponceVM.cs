using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class FacultyListResponceVM
    {
        public string? ErrorProcedure { get; set; }
        public List<FacultylistVM>? Response { get; set; }
    }
}
