using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.CommandsHandler
{
    public class DeleteStudentById
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<DeleteStudentById> _logger;

        public DeleteStudentById(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<DeleteStudentById> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<DeleteStudentResponceVM> ExecuteStoredProcedure(string spname, int id)
        {
            _logger.LogInformation("Started processing {namespace} DeleteStudentById", typeof(DeleteStudentById).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbCommandContext.Set<SPDeleteStudentByIdEntity>().FromSqlInterpolated($@"exec {spname} @StudentId = {id}").ToListAsync();
            var result = _mapper.Map<DeleteStudentResponceVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} DeleteStudentById", typeof(DeleteStudentById).Namespace);
            return result;
        }

    }
}
