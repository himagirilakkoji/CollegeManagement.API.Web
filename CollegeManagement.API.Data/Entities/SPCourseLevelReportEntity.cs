using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class SPCourseLevelReportEntity
    {
        public int CourseID { get; set; }
        public string? Name { get; set; }
        public decimal? AverageMarks { get; set; }
    }
}
