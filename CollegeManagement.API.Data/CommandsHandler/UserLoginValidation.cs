using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.CommandsHandler
{
    public class UserLoginValidation
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        public UserLoginValidation(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
        }

        public async Task<LoginResponceVM> ExecuteStoredProcedure(string spname, LoginRequestPayload payload)
        {
            try
            {
                //Calling stored procedure 
                var entity = await _collegeDbCommandContext.Set<SPUserLoginValidationsEntity>().FromSqlInterpolated($@"exec {spname} @EmailId = {payload.EmailID} , @Password={payload.Password} ").ToListAsync();
                var result = _mapper.Map<LoginResponceVM>(entity[0]);
                if (entity[0].Response != null)
                {
                    var adminDetails = JsonConvert.DeserializeObject<AdminDetailsVM>(entity[0].Response);
                    result.adminDetails = adminDetails;
                }
                return result;
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return null;

            }

        }
    }
}
