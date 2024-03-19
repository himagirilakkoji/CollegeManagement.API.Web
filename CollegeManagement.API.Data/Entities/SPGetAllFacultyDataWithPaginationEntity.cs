using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class SPGetAllFacultyDataWithPaginationEntity
    {
        public string? ErrorProcedure { get; set; }
        public int TotalRecords { get; set; }
        public string? Response { get; set; }
    }
}
