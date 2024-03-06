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
    public class DeleteFacultyById
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<DeleteFacultyById> _logger;
        public DeleteFacultyById(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<DeleteFacultyById> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<DeleteFacultyResponceVM> ExecuteStoredProcedure(string spname, Guid guid)
        {
            _logger.LogInformation("Started processing {namespace} DeleteFacultyById", typeof(DeleteFacultyById).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPDeleteFacultyByIdEntity>().FromSqlInterpolated($@"exec {spname} @FacultyId = {guid}").ToListAsync();
            var result = _mapper.Map<DeleteFacultyResponceVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} DeleteFacultyById", typeof(DeleteFacultyById).Namespace);
            return result;
        }
    }
}
