using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data;
using CollegeManagement.API.Data.CommandsHandler;
using CollegeManagement.API.Data.QueriesHandler;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CollegeManagement.API.Services.AdminRepository
{
    public class AdminService : IAdminService
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly UserLoginValidation _userLoginValidation;
        private readonly GetDepartmentDetails _getDepartmentDetails;
        private readonly GetAllFacultyDetails _getAllFacultyDetails;
        private readonly GetAllFacultyDetailsWithPagination _getAllFacultyDetailsWithPagination;
        private readonly InsertFacultyDetails _insertFacultyDetails;
        private readonly DeleteFacultyById _deleteFacultyById;
        private readonly UpdateFacultyById _updateFacultyById;
        private readonly UpdateStudentById _updateStudentById;
        private readonly InsertStudentDetails _insertStudentDetails;
        private readonly GetAllStudentDetails _getAllStudentDetails;
        private readonly DeleteStudentById _deleteStudentById;
        private readonly InsertStudentExamMarksDetails _insertStudentExamMarksDetails;
        private readonly GetFacultyCourseLevelReportByGuid _getFacultyCourseLevelReportByGuid;
        private readonly GetFacultySubjectLevelReportByGuid _getFacultySubjectLevelReportByGuid;
        private readonly GetStudentMarksById _getStudentMarksById;
        private readonly GetSearchStudentNamesByText _getSearchStudentNamesByText;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<AdminService> _logger;

        public AdminService(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper , UserLoginValidation userLoginValidation, IOptions<StoreProcedures> storeProcedures, ILogger<AdminService> logger,
               GetDepartmentDetails getDepartmentDetails, InsertFacultyDetails insertFacultyDetails, GetAllFacultyDetails getAllFacultyDetails, DeleteFacultyById deleteFacultyById, UpdateFacultyById updateFacultyById, 
               InsertStudentDetails insertStudentDetails, GetAllStudentDetails getAllStudentDetails, DeleteStudentById deleteStudentById, InsertStudentExamMarksDetails insertStudentExamMarksDetails,
               GetFacultyCourseLevelReportByGuid getFacultyCourseLevelReportByGuid, GetFacultySubjectLevelReportByGuid getFacultySubjectLevelReportByGuid, GetAllFacultyDetailsWithPagination getAllFacultyDetailsWithPagination,
               UpdateStudentById updateStudentById, GetStudentMarksById getStudentMarksById, GetSearchStudentNamesByText getSearchStudentNamesByText)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _userLoginValidation = userLoginValidation;
            _getDepartmentDetails = getDepartmentDetails;
            _insertFacultyDetails = insertFacultyDetails;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
            _getAllFacultyDetails = getAllFacultyDetails;
            _deleteFacultyById = deleteFacultyById;
            _updateFacultyById = updateFacultyById;
            _insertStudentDetails = insertStudentDetails;
            _getAllStudentDetails = getAllStudentDetails;
            _deleteStudentById = deleteStudentById;
            _insertStudentExamMarksDetails = insertStudentExamMarksDetails;
            _getFacultyCourseLevelReportByGuid = getFacultyCourseLevelReportByGuid;
            _getFacultySubjectLevelReportByGuid = getFacultySubjectLevelReportByGuid;
            _getAllFacultyDetailsWithPagination = getAllFacultyDetailsWithPagination;
            _updateStudentById = updateStudentById;
            _getStudentMarksById = getStudentMarksById;
            _getSearchStudentNamesByText = getSearchStudentNamesByText;
        }

        public async Task<LoginResponseVM> PostLoginValidationAsync(LoginRequestPayload payload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _userLoginValidation.ExecuteStoredProcedure(_storeProcedures.UserLoginValidations , payload);
        }

        public async Task<DepartmentResponseVM> GetDepartmentDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getDepartmentDetails.ExecuteStoredProcedure(_storeProcedures.GetDepartmentdata);
        }

        public async Task<FacultyListResponseVM> GetAllFacultyDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getAllFacultyDetails.ExecuteStoredProcedure(_storeProcedures.GetAllFaculties);
        }

        public async Task<FacultyListResponseWithPaginationVM> GetAllFacultyDetailsWithPagination(int pageNumber ,int pageSize)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getAllFacultyDetailsWithPagination.ExecuteStoredProcedure(_storeProcedures.GetAllFacultiesByPagination,pageNumber ,pageSize);
        }

        public async Task<InsertFacultyResponseVM> InsertFacultyAsync(InsertFacultyPayload insertFacultyPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _insertFacultyDetails.ExecuteStoredProcedure(_storeProcedures.InsertFacultyDetails, insertFacultyPayload);
        }

        public async Task<DeleteFacultyResponseVM> DeeleteFacultyById(Guid id)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _deleteFacultyById.ExecuteStoredProcedure(_storeProcedures.DeleteFacultyById, id);
        }

        public async Task<UpdateFacultyResponseVM> UpdateFacultyById(UpdateFacultyPayload updateFacultyPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _updateFacultyById.ExecuteStoredProcedure(_storeProcedures.UpdateFacultyById, updateFacultyPayload);
        }

        public async Task<InsertStudentResponseVM> InsertStudentAsync(InsertStudentPayload insertStudentPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _insertStudentDetails.ExecuteStoredProcedure(_storeProcedures.InsertStudentDetails, insertStudentPayload);
        }

        public async Task<List<StudentListResponseVM>> GetAllStudentDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getAllStudentDetails.ExecuteStoredProcedure(_storeProcedures.GetAllStudents);
        }

        public async Task<DeleteStudentResponseVM> DeleteStudentById(int id)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _deleteStudentById.ExecuteStoredProcedure(_storeProcedures.DeleteStudentById, id);
        }
        public async Task<InsertStudentMarksResponseVM> InsertStudentExamMarksAsync(InsertStudentMarksPayload insertStudentMarksPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _insertStudentExamMarksDetails.ExecuteStoredProcedure(_storeProcedures.InsertExamMarksDetails, insertStudentMarksPayload);
        }

        public async Task<List<CourseLevelReportResponseVM>> GetCourseLevelReport(Guid guid)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getFacultyCourseLevelReportByGuid.ExecuteStoredProcedure(_storeProcedures.CalculateCourseLevelReport, guid);
        }

        public async Task<List<SubjectLevelReportResponseVM>> GetSubjectLevelReport(Guid guid)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getFacultySubjectLevelReportByGuid.ExecuteStoredProcedure(_storeProcedures.CalculateSubjectLevelReport, guid);
        }

        public async Task<UpdateStudentResponseVM> UpdateStudentById(int id, UpdateStudentPayload updateStudentPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _updateStudentById.ExecuteStoredProcedure(_storeProcedures.UpdateStudentById, id, updateStudentPayload);
        }
        public async Task<List<StudentMarksResponseVM>> GetAllStudentMarksDetails(int id)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getStudentMarksById.ExecuteStoredProcedure(_storeProcedures.GetStudentMarksById, id);
        }

        public async Task<List<SearchStudentResponseVM>> GetSearchStudentDetails(string? searchText)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getSearchStudentNamesByText.ExecuteStoredProcedure(_storeProcedures.SearchStudent, searchText);
        }
    }
}
