using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Domain
{
    public class LoginRequestPayload
    {
        public string? EmailID { get; set; }
        public string? Password { get; set; }
    }
}
