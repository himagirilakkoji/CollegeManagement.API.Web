using CollegeManagement.API.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.AdminRepository
{
    public interface IAdminService
    {
        public Task<AdminDetailsVM> GetAdminByEmailAsync(LoginRequestPayload payload);
    }
}
