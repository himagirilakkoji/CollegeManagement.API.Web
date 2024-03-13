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
    public class InsertStudentExamMarksDetails
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<InsertStudentExamMarksDetails> _logger;
        public InsertStudentExamMarksDetails(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<InsertStudentExamMarksDetails> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<InsertStudentMarksResponceVM> ExecuteStoredProcedure(string spname, InsertStudentMarksPayload payload)
        {
            _logger.LogInformation("Started processing {namespace} InsertStudentExamMarksDetails", typeof(InsertStudentExamMarksDetails).Namespace);

            var InputAsJson = JsonConvert.SerializeObject(payload);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPInsertStudentExamMarksDetailsEntity>().FromSqlInterpolated($@"exec {spname} @InputAsJSON = {InputAsJson}").ToListAsync();
            var result = _mapper.Map<InsertStudentMarksResponceVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} InsertStudentExamMarksDetails", typeof(InsertStudentExamMarksDetails).Namespace);
            return result;
        }

    }
}
