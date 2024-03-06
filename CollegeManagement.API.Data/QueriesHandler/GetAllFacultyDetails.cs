using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CollegeManagement.API.Data.QueriesHandler
{
    public class GetAllFacultyDetails
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetAllFacultyDetails> _logger;

        public GetAllFacultyDetails(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetAllFacultyDetails> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<FacultyListResponceVM> ExecuteStoredProcedure(string spname)
        {
            _logger.LogInformation("Started processing {namespace} GetAllFacultyDetails", typeof(GetAllFacultyDetails).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbQueryContext.Set<SPGetAllFacultyDataEntity>().FromSqlInterpolated($@"exec {spname}").ToListAsync();
            var result = _mapper.Map<FacultyListResponceVM>(entity.FirstOrDefault());

            if (entity.FirstOrDefault().Response != null)
            {
                var facultyDetails = JsonConvert.DeserializeObject<List<FacultylistVM>>(entity.FirstOrDefault().Response);
                result.Response = facultyDetails;
            }

            _logger.LogInformation("Completed processing {namespace} GetDepartmentDetails", typeof(GetDepartmentDetails).Namespace);
            return result;
        }

    }
}
