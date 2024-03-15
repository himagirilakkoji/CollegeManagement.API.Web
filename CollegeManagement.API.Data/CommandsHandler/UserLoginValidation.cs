using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserLoginValidation> _logger;
        public UserLoginValidation(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<UserLoginValidation> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<LoginResponseVM> ExecuteStoredProcedure(string spname, LoginRequestPayload payload)
        {
                _logger.LogInformation("Started processing {namespace} UserLoginValidation", typeof(UserLoginValidation).Namespace);
                
                //Calling stored procedure 
                var entity = await _collegeDbCommandContext.Set<SPUserLoginValidationsEntity>().FromSqlInterpolated($@"exec {spname} @EmailId = {payload.EmailID} , @Password={payload.Password} ").ToListAsync();
                var result = _mapper.Map<LoginResponseVM>(entity.FirstOrDefault());

                if (entity.FirstOrDefault().Response != null)
                {
                    var adminDetails = JsonConvert.DeserializeObject<AdminDetailsVM>(entity.FirstOrDefault().Response);
                    result.adminDetails = adminDetails;
                }

                _logger.LogInformation("Completed processing {namespace} UserLoginValidation", typeof(UserLoginValidation).Namespace);
                return result;
        }
    }
}
