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
    public class GetAllFacultyDetailsQueryHandler : IRequestHandler<GetAllFacultyList, FacultyListResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllFacultyDetailsQueryHandler> _logger;

        public GetAllFacultyDetailsQueryHandler(IAdminService adminService, ILogger<GetAllFacultyDetailsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<FacultyListResponceVM> Handle(GetAllFacultyList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetAllFacultyDetailsQueryHandler", typeof(GetAllFacultyDetailsQueryHandler).Namespace);
            return await _adminService.GetAllFacultyDetails();
        }
    }
}
