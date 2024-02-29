using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data;
using CollegeManagement.API.Data.CommandsHandler;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly StoreProcedures _storeProcedures;

        public AdminService(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper , UserLoginValidation userLoginValidation, IOptions<StoreProcedures> storeProcedures)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _userLoginValidation = userLoginValidation;
            _storeProcedures = storeProcedures.Value;

        }

        public async Task<LoginResponceVM> PostLoginValidationAsync(LoginRequestPayload payload)
        {
            return await _userLoginValidation.ExecuteStoredProcedure(_storeProcedures.UserLoginValidations , payload);
        }

    }
}
