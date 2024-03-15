using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain.Procedures
{
    public class LoginResponseVM
    {
        public string? ResponseCode { get; set; }
        public string? ErrorProcedure { get; set; }
        public AdminDetailsVM? adminDetails { get; set; }
    }
}
