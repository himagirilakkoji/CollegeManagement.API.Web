using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class RolesEntity
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public List<AdminDetailsEntity>? adminDetailsEntity { get; set;}
    }
}
