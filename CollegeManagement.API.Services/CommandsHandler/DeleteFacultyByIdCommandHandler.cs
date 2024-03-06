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
    public class DeleteFacultyByIdCommandHandler : IRequestHandler<DeleteCurrentFacultyById, DeleteFacultyResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<DeleteFacultyByIdCommandHandler> _logger;

        public DeleteFacultyByIdCommandHandler(IAdminService adminService, ILogger<DeleteFacultyByIdCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<DeleteFacultyResponceVM> Handle(DeleteCurrentFacultyById request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} DeleteFacultyByIdCommandHandler", typeof(DeleteFacultyByIdCommandHandler).Namespace);
            return await _adminService.DeeleteFacultyById(request.id);
        }
    }
}
