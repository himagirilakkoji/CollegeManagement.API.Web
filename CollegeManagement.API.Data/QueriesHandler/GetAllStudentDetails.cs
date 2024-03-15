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
    public class GetAllStudentDetails
    {
        private readonly CollegeDbQueryContext _collegeDbQueryContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<GetAllStudentDetails> _logger;

        public GetAllStudentDetails(CollegeDbQueryContext collegeDbQueryContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<GetAllStudentDetails> logger)
        {
            _collegeDbQueryContext = collegeDbQueryContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<List<StudentListResponseVM>> ExecuteStoredProcedure(string spname)
        {
            _logger.LogInformation("Started processing {namespace} GetAllStudentDetails", typeof(GetAllStudentDetails).Namespace);

            //Calling stored procedure 
            var entity = await _collegeDbQueryContext.sPGetAllStudentDataEntities.FromSqlInterpolated($@"exec {spname}").ToListAsync();
            var result = new List<StudentListResponseVM>();
            
            foreach (var item in entity)
            {
                var studentCourses = new List<StudentCourseVM>();
                if (item.studentCourseEntities != null)
                {
                    studentCourses = JsonConvert.DeserializeObject<List<StudentCourseVM>>(item.studentCourseEntities);
                }

                result.Add(new StudentListResponseVM()
                {
                    StudentID = item.StudentID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    FacultyID = item.FacultyID,
                    studentCourseVM = studentCourses
                });
            }
            _logger.LogInformation("Completed processing {namespace} GetAllStudentDetails", typeof(GetAllStudentDetails).Namespace);
            return result;
        }
    }
}
