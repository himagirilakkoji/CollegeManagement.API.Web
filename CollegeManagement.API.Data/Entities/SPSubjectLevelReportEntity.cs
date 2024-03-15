using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class SPSubjectLevelReportEntity
    {
        public int SubjectID { get; set; }
        public string? Name { get; set; }
        public decimal? AverageMarks { get; set; }
    }
}
