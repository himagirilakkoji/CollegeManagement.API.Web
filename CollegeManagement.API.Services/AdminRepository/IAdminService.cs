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
        Task<LoginResponseVM> PostLoginValidationAsync(LoginRequestPayload loginRequest);
        Task<InsertFacultyResponseVM> InsertFacultyAsync(InsertFacultyPayload insertFacultyPayload);
        Task<DepartmentResponseVM> GetDepartmentDetails();
        Task<FacultyListResponseVM> GetAllFacultyDetails();
        Task<DeleteFacultyResponseVM> DeeleteFacultyById(Guid id);
        Task<UpdateFacultyResponseVM> UpdateFacultyById(UpdateFacultyPayload updateFacultyPayload);
        Task<InsertStudentResponseVM> InsertStudentAsync(InsertStudentPayload insertStudentPayload);
        Task<List<StudentListResponseVM>> GetAllStudentDetails();
        Task<DeleteStudentResponseVM> DeleteStudentById(int id);
        Task<InsertStudentMarksResponseVM> InsertStudentExamMarksAsync(InsertStudentMarksPayload insertStudentMarksPayload);
        Task<List<CourseLevelReportResponseVM>> GetCourseLevelReport(Guid id);
        Task<List<SubjectLevelReportResponseVM>> GetSubjectLevelReport(Guid id);
    }
}
