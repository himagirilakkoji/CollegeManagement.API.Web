using AutoMapper;
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

namespace CollegeManagement.API.Data.QueriesHandler
{
    public class GetAllFacultyDetailsWithPagination
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetAllFacultyDetails> _logger;

        public GetAllFacultyDetailsWithPagination(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetAllFacultyDetails> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<FacultyListResponseVM> ExecuteStoredProcedure(string spname,int pageNumber ,int pageSize)
        {
            _logger.LogInformation("Started processing {namespace} GetAllFacultyDetailsWithPagination", typeof(GetAllFacultyDetailsWithPagination).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbQueryContext.Set<SPGetAllFacultyDataEntity>().FromSqlInterpolated($@"exec {spname} @PageNumber = {pageNumber},@PageSize = {pageSize}").ToListAsync();
            var result = _mapper.Map<FacultyListResponseVM>(entity.FirstOrDefault());

            if (entity.FirstOrDefault().Response != null)
            {
                var facultyDetails = JsonConvert.DeserializeObject<List<FacultylistVM>>(entity.FirstOrDefault().Response);
                result.Response = facultyDetails;
            }

            _logger.LogInformation("Completed processing {namespace} GetAllFacultyDetailsWithPagination", typeof(GetAllFacultyDetailsWithPagination).Namespace);
            return result;
        }
    }
}
