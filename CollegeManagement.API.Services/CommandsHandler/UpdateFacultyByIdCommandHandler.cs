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
    public class UpdateFacultyByIdCommandHandler : IRequestHandler<UpdateCurrentFacultyById, UpdateFacultyResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<UpdateFacultyByIdCommandHandler> _logger;

        public UpdateFacultyByIdCommandHandler(IAdminService adminService, ILogger<UpdateFacultyByIdCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<UpdateFacultyResponceVM> Handle(UpdateCurrentFacultyById request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} UpdateFacultyByIdCommandHandler", typeof(UpdateFacultyByIdCommandHandler).Namespace);
            return await _adminService.UpdateFacultyById(request.UpdateFacultyPayload);
        }
    }
}
