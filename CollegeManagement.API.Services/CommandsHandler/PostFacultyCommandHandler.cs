
using CollegeManagement.API.Core.Commands;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CollegeManagement.API.Services.CommandsHandler
{
    public class PostFacultyCommandHandler : IRequestHandler<PostFacultyDetails, InsertFacultyResponseVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<PostFacultyCommandHandler> _logger;
        public PostFacultyCommandHandler(IAdminService adminService, ILogger<PostFacultyCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<InsertFacultyResponseVM> Handle(PostFacultyDetails request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} PostFacultyCommandHandler", typeof(PostFacultyCommandHandler).Namespace);
            return await _adminService.InsertFacultyAsync(request.InsertFacultyPayload);
        }
    }
}
