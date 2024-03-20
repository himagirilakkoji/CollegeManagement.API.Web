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
    public class GetSearchStudentDetailsQueryHandler : IRequestHandler<GetSearchStudentNamesList, List<SearchStudentResponseVM>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetSearchStudentDetailsQueryHandler> _logger;
        public GetSearchStudentDetailsQueryHandler(IAdminService adminService, ILogger<GetSearchStudentDetailsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<List<SearchStudentResponseVM>> Handle(GetSearchStudentNamesList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetSearchStudentDetailsQueryHandler", typeof(GetSearchStudentDetailsQueryHandler).Namespace);
            return await _adminService.GetSearchStudentDetails(request.searchtext);
        }
    }
}
