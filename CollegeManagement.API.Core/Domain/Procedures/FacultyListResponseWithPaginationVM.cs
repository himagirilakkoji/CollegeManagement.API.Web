using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class FacultyListResponseWithPaginationVM
    {
        public string? ErrorProcedure { get; set; }
        public int TotalRecords { get; set; }
        public List<FacultylistVM>? Response { get; set; }
    }
}
