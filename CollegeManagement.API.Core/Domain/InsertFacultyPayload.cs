using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain
{
    public class InsertFacultyPayload
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Dept { get; set; }
        public List<CourseRequest>? courseRequests { get; set; }
        public List<SubjectRequest>? subjectRequests { get; set; }
    }
}
