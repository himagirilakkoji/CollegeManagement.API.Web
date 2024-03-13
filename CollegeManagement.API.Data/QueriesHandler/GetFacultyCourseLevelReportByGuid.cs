using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.QueriesHandler
{
    public class GetFacultyCourseLevelReportByGuid
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetFacultyCourseLevelReportByGuid> _logger;

        public GetFacultyCourseLevelReportByGuid(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetFacultyCourseLevelReportByGuid> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<List<CourseLevelReportResponceVM>> ExecuteStoredProcedure(string spname,Guid guid)
        {
            _logger.LogInformation("Started processing {namespace} GetFacultyCourseLevelReportByGuid", typeof(GetFacultyCourseLevelReportByGuid).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbQueryContext.sPCourseLevelReportEntities.FromSqlInterpolated($@"exec {spname} @FacultyID = {guid}").ToListAsync();
            var result = _mapper.Map<List<CourseLevelReportResponceVM>>(entity);
            _logger.LogInformation("Completed processing {namespace} GetAllStudentDetails", typeof(GetAllStudentDetails).Namespace);
            return result;
        }
    }
}
