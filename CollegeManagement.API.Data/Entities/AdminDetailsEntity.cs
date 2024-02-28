using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Entities
{
    public class AdminDetailsEntity
    {
        public Guid AdminID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int AdminRoleID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public RolesEntity? rolesEntities { get;set; }
    }
}
