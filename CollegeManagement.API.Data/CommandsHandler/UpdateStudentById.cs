using AutoMapper;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Domain;
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
using System.Data;
using Microsoft.Data.SqlClient;

namespace CollegeManagement.API.Data.CommandsHandler
{
    public class UpdateStudentById
    {
        private readonly CollegeDbCommandContext _collegeDbCommandContext;
        private readonly IMapper _mapper;
        private readonly StoreProcedures _storeProcedures;
        private readonly ILogger<UpdateStudentById> _logger;
        public UpdateStudentById(CollegeDbCommandContext collegeDbCommandContext, IMapper mapper, IOptions<StoreProcedures> storeProcedures, ILogger<UpdateStudentById> logger)
        {
            _collegeDbCommandContext = collegeDbCommandContext;
            _mapper = mapper;
            _storeProcedures = storeProcedures.Value;
            _logger = logger;
        }

        public async Task<UpdateStudentResponseVM> ExecuteStoredProcedure(string spname,int studentId, UpdateStudentPayload updateStudent)
        {
            _logger.LogInformation("Started processing {namespace} UpdateStudentById", typeof(UpdateStudentById).Namespace);

            var students = new List<UpdateStudentPayload>();
            students.Add(updateStudent);

            var student = ToDataTable(students);

            var studentIdParam = new SqlParameter("@StudentId", studentId);
            var studentParam = new SqlParameter("@Student", SqlDbType.Structured)
            {
                TypeName = "dbo.UpdateStudentPayloadType",
                Value = student
            };

            //Calling stored procedure 
            var entity =await _collegeDbCommandContext.Set<SPUpdateStudentByIdEntity>().FromSqlRaw("EXEC [dbo].[UpdateStudentById] @StudentId, @Student", studentIdParam, studentParam).ToListAsync();

            var result = _mapper.Map<UpdateStudentResponseVM>(entity.FirstOrDefault());

            _logger.LogInformation("Completed processing {namespace} UpdateStudentById", typeof(UpdateStudentById).Namespace);
            return result;
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            foreach (var prop in typeof(T).GetProperties())
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
