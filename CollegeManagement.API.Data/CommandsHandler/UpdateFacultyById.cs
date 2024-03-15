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
    public class UpdateFacultyById
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<UpdateFacultyById> _logger;
        public UpdateFacultyById(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<UpdateFacultyById> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<UpdateFacultyResponseVM> ExecuteStoredProcedure(string spname,UpdateFacultyPayload updateFaculty)
        {
            _logger.LogInformation("Started processing {namespace} UpdateFacultyById", typeof(UpdateFacultyById).Namespace);
            
            var updateFacultyPayload = JsonConvert.SerializeObject(updateFaculty);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPUpdateFacultyByIdEntity>().FromSqlInterpolated($@"exec {spname} @FacultyGuid = {updateFaculty.Id},@UpdateInputAsJSON = {updateFacultyPayload}").ToListAsync();
            var result = _mapper.Map<UpdateFacultyResponseVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} UpdateFacultyById", typeof(UpdateFacultyById).Namespace);
            return result;
        }

    }
}
