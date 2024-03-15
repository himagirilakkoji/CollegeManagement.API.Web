using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Data.CommandsHandler;
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
    public class GetDepartmentDetails
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetDepartmentDetails> _logger;
        public GetDepartmentDetails(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetDepartmentDetails> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<DepartmentResponseVM> ExecuteStoredProcedure(string spname)
        {
            _logger.LogInformation("Started processing {namespace} GetDepartmentDetails", typeof(GetDepartmentDetails).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPGetDepartmentdataEntity>().FromSqlInterpolated($@"exec {spname}").ToListAsync();
            var result = _mapper.Map<DepartmentResponseVM>(entity.FirstOrDefault());

            if (entity.FirstOrDefault().Response != null)
            {
                var departmentDetails = JsonConvert.DeserializeObject<List<DepartmentDataVM>>(entity.FirstOrDefault().Response);
                result.Response = departmentDetails;
            }

            _logger.LogInformation("Completed processing {namespace} GetDepartmentDetails", typeof(GetDepartmentDetails).Namespace);
            return result;
        }
    }
}
