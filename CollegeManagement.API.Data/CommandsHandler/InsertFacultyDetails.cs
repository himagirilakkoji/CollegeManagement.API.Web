using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CollegeManagement.API.Data.CommandsHandler
{
    public class InsertFacultyDetails
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<InsertFacultyDetails> _logger;
        public InsertFacultyDetails(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<InsertFacultyDetails> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<InsertFacultyResponseVM> ExecuteStoredProcedure(string spname, InsertFacultyPayload payload)
        {
            _logger.LogInformation("Started processing {namespace} InsertFacultyDetails", typeof(InsertFacultyDetails).Namespace);

            var InputAsJson = JsonConvert.SerializeObject(payload);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPInsertFacultyDetailsEntity>().FromSqlInterpolated($@"exec {spname} @InputAsJSON = {InputAsJson}").ToListAsync();
            var result = _mapper.Map<InsertFacultyResponseVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} InsertFacultyDetails", typeof(InsertFacultyDetails).Namespace);
            return result;
        }
    }
}
