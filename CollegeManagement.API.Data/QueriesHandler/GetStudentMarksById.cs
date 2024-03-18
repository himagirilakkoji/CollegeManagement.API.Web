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
    public class GetStudentMarksById
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetStudentMarksById> _logger;

        public GetStudentMarksById(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetStudentMarksById> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<List<StudentMarksResponseVM>> ExecuteStoredProcedure(string spname, int id)
        {
            _logger.LogInformation("Started processing {namespace} GetStudentMarksById", typeof(GetStudentMarksById).Namespace);

            //Calling stored procedure

            var entity = await _collegeDbQueryContext.sPStudentMarksEntities.FromSqlInterpolated($@"exec {spname} @StudentID = {id}").ToListAsync();
            var result = _mapper.Map<List<StudentMarksResponseVM>>(entity);

            _logger.LogInformation("Completed processing {namespace} GetStudentMarksById", typeof(GetStudentMarksById).Namespace);
            return result;
        }
    }
}
