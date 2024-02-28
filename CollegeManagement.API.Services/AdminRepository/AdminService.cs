using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Data;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        public AdminService(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
        }

        public async Task<AdminDetailsVM> GetAdminByEmailAsync(LoginRequestPayload payload)
        {
            var entityResult = await _collegeDbQueryContext.adminDetailstblEntities.Where(x => x.Email == payload.EmailID).FirstOrDefaultAsync();

            return _mapper.Map<AdminDetailsVM>(entityResult);
        }

        //public string GenerateSHA256Hash(String input)
        //{
        //    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
        //    System.Security.Cryptography.SHA256Managed sha256hashstring =
        //        new System.Security.Cryptography.SHA256Managed();
        //    byte[] hash = sha256hashstring.ComputeHash(bytes);
        //    return Convert.ToBase64String(hash);
        //}
    }
}
