using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain
{
    public class InsertStudentMarksPayload
    {
        public string? studentName { get; set; }
        public string? branch { get; set; }
        public string? classRoom { get; set; }
        public string? semester { get; set; }
        public List<InsertStudentSubjectsVM>? subjects { get; set; }
    }
}
