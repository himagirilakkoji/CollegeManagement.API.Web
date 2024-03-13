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
    public class GetCourseLevelReportQueryHandler : IRequestHandler<GetCourseLevelReportList, List<CourseLevelReportResponceVM>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetCourseLevelReportQueryHandler> _logger;

        public GetCourseLevelReportQueryHandler(IAdminService adminService, ILogger<GetCourseLevelReportQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }
        public async Task<List<CourseLevelReportResponceVM>> Handle(GetCourseLevelReportList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetCourseLevelReportQueryHandler", typeof(GetCourseLevelReportQueryHandler).Namespace);
            return await _adminService.GetCourseLevelReport(request.id);
        }
    }
}
