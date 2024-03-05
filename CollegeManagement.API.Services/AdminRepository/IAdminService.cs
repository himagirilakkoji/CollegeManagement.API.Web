using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.AdminRepository
{
    public interface IAdminService
    {
        Task<LoginResponceVM> PostLoginValidationAsync(LoginRequestPayload loginRequest);
        Task<InsertFacultyResponceVM> InsertFacultyAsync(InsertFacultyPayload insertFacultyPayload);
        Task<DepartmentResponceVM> GetDepartmentDetails();
    }
}
