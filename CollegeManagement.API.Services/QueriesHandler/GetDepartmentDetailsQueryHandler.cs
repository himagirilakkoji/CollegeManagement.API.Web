using CollegeManagement.API.Core.Commands;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Queries;
using CollegeManagement.API.Services.AdminRepository;
using CollegeManagement.API.Services.CommandsHandler;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.QueriesHandler
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentData, DepartmentResponseVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetDepartmentDetailsQueryHandler> _logger;
        public GetDepartmentDetailsQueryHandler(IAdminService adminService, ILogger<GetDepartmentDetailsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<DepartmentResponseVM> Handle(GetDepartmentData request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetDepartmentDetailsQueryHandler", typeof(GetDepartmentDetailsQueryHandler).Namespace);
            return await _adminService.GetDepartmentDetails();
        }
    }
}
