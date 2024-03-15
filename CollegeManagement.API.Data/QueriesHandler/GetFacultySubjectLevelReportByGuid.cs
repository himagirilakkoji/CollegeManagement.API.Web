using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.QueriesHandler
{
    public class GetFacultySubjectLevelReportByGuid
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetFacultySubjectLevelReportByGuid> _logger;

        public GetFacultySubjectLevelReportByGuid(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetFacultySubjectLevelReportByGuid> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<List<SubjectLevelReportResponseVM>> ExecuteStoredProcedure(string spname, Guid guid)
        {
            _logger.LogInformation("Started processing {namespace} GetFacultySubjectLevelReportByGuid", typeof(GetFacultySubjectLevelReportByGuid).Namespace);

            //Calling stored procedure

            var entity = await _collegeDbQueryContext.sPSubjectLevelReportEntities.FromSqlInterpolated($@"exec {spname} @FacultyID = {guid}").ToListAsync();
            var result = _mapper.Map<List<SubjectLevelReportResponseVM>>(entity);

            _logger.LogInformation("Completed processing {namespace} GetFacultySubjectLevelReportByGuid", typeof(GetFacultySubjectLevelReportByGuid).Namespace);
            return result;
        }
    }
}
