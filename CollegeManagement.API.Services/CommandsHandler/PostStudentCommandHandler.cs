using CollegeManagement.API.Core.Commands;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Services.CommandsHandler
{
    public class PostStudentCommandHandler : IRequestHandler<PostStudentDetails, InsertStudentResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<PostFacultyCommandHandler> _logger;
        public PostStudentCommandHandler(IAdminService adminService, ILogger<PostFacultyCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<InsertStudentResponceVM> Handle(PostStudentDetails request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} StudentCommandHandler", typeof(PostStudentCommandHandler).Namespace);
            return await _adminService.InsertStudentAsync(request.insertStudentPayload);
        }
    }
}
