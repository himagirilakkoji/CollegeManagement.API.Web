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
        private readonly InsertFacultyDetails _insertFacultyDetails;
        private readonly DeleteFacultyById _deleteFacultyById;
        private readonly UpdateFacultyById _updateFacultyById;
        private readonly InsertStudentDetails _insertStudentDetails;
        private readonly GetAllStudentDetails _getAllStudentDetails;
        private readonly DeleteStudentById _deleteStudentById;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<AdminService> _logger;

        public AdminService(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper , UserLoginValidation userLoginValidation, IOptions<StoreProcedures> storeProcedures, ILogger<AdminService> logger,
               GetDepartmentDetails getDepartmentDetails, InsertFacultyDetails insertFacultyDetails, GetAllFacultyDetails getAllFacultyDetails, DeleteFacultyById deleteFacultyById, UpdateFacultyById updateFacultyById, 
               InsertStudentDetails insertStudentDetails, GetAllStudentDetails getAllStudentDetails, DeleteStudentById deleteStudentById)
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
        }

        public async Task<LoginResponceVM> PostLoginValidationAsync(LoginRequestPayload payload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _userLoginValidation.ExecuteStoredProcedure(_storeProcedures.UserLoginValidations , payload);
        }

        public async Task<DepartmentResponceVM> GetDepartmentDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getDepartmentDetails.ExecuteStoredProcedure(_storeProcedures.GetDepartmentdata);
        }

        public async Task<FacultyListResponceVM> GetAllFacultyDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getAllFacultyDetails.ExecuteStoredProcedure(_storeProcedures.GetAllFaculties);
        }

        public async Task<InsertFacultyResponceVM> InsertFacultyAsync(InsertFacultyPayload insertFacultyPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _insertFacultyDetails.ExecuteStoredProcedure(_storeProcedures.InsertFacultyDetails, insertFacultyPayload);
        }

        public async Task<DeleteFacultyResponceVM> DeeleteFacultyById(Guid id)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _deleteFacultyById.ExecuteStoredProcedure(_storeProcedures.DeleteFacultyById, id);
        }

        public async Task<UpdateFacultyResponceVM> UpdateFacultyById(UpdateFacultyPayload updateFacultyPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _updateFacultyById.ExecuteStoredProcedure(_storeProcedures.UpdateFacultyById, updateFacultyPayload);
        }

        public async Task<InsertStudentResponceVM> InsertStudentAsync(InsertStudentPayload insertStudentPayload)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _insertStudentDetails.ExecuteStoredProcedure(_storeProcedures.InsertStudentDetails, insertStudentPayload);
        }

        public async Task<List<StudentListResponceVM>> GetAllStudentDetails()
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _getAllStudentDetails.ExecuteStoredProcedure(_storeProcedures.GetAllStudents);
        }

        public async Task<DeleteStudentResponceVM> DeleteStudentById(int id)
        {
            _logger.LogInformation("Started processing {namespace} AdminService", typeof(AdminService).Namespace);
            return await _deleteStudentById.ExecuteStoredProcedure(_storeProcedures.DeleteStudentById, id);
        }

    }
}
