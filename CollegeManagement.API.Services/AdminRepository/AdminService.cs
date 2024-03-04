using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data;
using CollegeManagement.API.Data.CommandsHandler;
using CollegeManagement.API.Data.QueriesHandler;
using CollegeManagement.API.Services.AdminRepository;
using CollegeManagement.API.Services.CommandsHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.AdminRepository
{
    public class AdminService : IAdminService
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly UserLoginValidation _userLoginValidation;
        private readonly GetDepartmentDetails _getDepartmentDetails;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<AdminService> _logger;

        public AdminService(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper , UserLoginValidation userLoginValidation, IOptions<StoreProcedures> storeProcedures, ILogger<AdminService> logger,
               GetDepartmentDetails getDepartmentDetails)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _userLoginValidation = userLoginValidation;
            _getDepartmentDetails = getDepartmentDetails;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;

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

    }
}
