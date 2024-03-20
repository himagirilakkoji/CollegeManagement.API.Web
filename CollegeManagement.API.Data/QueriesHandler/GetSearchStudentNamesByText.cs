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
    public class GetSearchStudentNamesByText
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetSearchStudentNamesByText> _logger;

        public GetSearchStudentNamesByText(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetSearchStudentNamesByText> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<List<SearchStudentResponseVM>> ExecuteStoredProcedure(string spname ,string searchText)
        {
            _logger.LogInformation("Started processing {namespace} GetSearchStudentNamesByText", typeof(GetSearchStudentNamesByText).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbQueryContext.sPSearchStudentResponseEntities.FromSqlInterpolated($@"exec {spname} @SearchText = {searchText}").ToListAsync();
            var result = _mapper.Map<List<SearchStudentResponseVM>>(entity);
            _logger.LogInformation("Completed processing {namespace} GetSearchStudentNamesByText", typeof(GetSearchStudentNamesByText).Namespace);
            return result;
        }
    }
}
