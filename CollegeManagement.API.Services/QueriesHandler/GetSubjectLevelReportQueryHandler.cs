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
    public class GetSubjectLevelReportQueryHandler : IRequestHandler<GetSubjectLevelReportList, List<SubjectLevelReportResponseVM>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetSubjectLevelReportQueryHandler> _logger;

        public GetSubjectLevelReportQueryHandler(IAdminService adminService, ILogger<GetSubjectLevelReportQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }
        public async Task<List<SubjectLevelReportResponseVM>> Handle(GetSubjectLevelReportList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetCourseLevelReportQueryHandler", typeof(GetSubjectLevelReportQueryHandler).Namespace);
            return await _adminService.GetSubjectLevelReport(request.id);
        }
    }
}
