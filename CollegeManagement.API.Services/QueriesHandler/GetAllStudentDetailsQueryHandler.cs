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
    public class GetAllStudentDetailsQueryHandler : IRequestHandler<GetAllStudentList, List<StudentListResponseVM>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllStudentDetailsQueryHandler> _logger;

        public GetAllStudentDetailsQueryHandler(IAdminService adminService, ILogger<GetAllStudentDetailsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }
        public async Task<List<StudentListResponseVM>> Handle(GetAllStudentList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetAllStudentDetailsQueryHandler", typeof(GetAllStudentDetailsQueryHandler).Namespace);
            return await _adminService.GetAllStudentDetails();
        }
    }
}
