using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Domain;
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
    public class InsertStudentDetails
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<InsertStudentDetails> _logger;
        public InsertStudentDetails(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<InsertStudentDetails> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<InsertStudentResponseVM> ExecuteStoredProcedure(string spname, InsertStudentPayload payload)
        {
            _logger.LogInformation("Started processing {namespace} InsertStudentDetails", typeof(InsertStudentDetails).Namespace);

            var InputAsJson = JsonConvert.SerializeObject(payload);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPInsertStudentDetailsEntity>().FromSqlInterpolated($@"exec {spname} @InputAsJSON = {InputAsJson}").ToListAsync();
            var result = _mapper.Map<InsertStudentResponseVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} InsertStudentDetails", typeof(InsertStudentDetails).Namespace);
            return result;
        }
    }
}
