using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Queries;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.QueriesHandler
{
    public class GetAllStudentMarksDetailsQueryHandler : IRequestHandler<GetStudentMarksList, List<StudentMarksResponseVM>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllStudentMarksDetailsQueryHandler> _logger;

        public GetAllStudentMarksDetailsQueryHandler(IAdminService adminService, ILogger<GetAllStudentMarksDetailsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }
        public async Task<List<StudentMarksResponseVM>> Handle(GetStudentMarksList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetAllStudentDetailsQueryHandler", typeof(GetAllStudentDetailsQueryHandler).Namespace);
            return await _adminService.GetAllStudentMarksDetails(request.id);
        }
    }
}
