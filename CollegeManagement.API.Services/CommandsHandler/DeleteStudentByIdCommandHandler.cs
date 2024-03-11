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
    public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteCurrentStudentById, DeleteStudentResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<DeleteStudentByIdCommandHandler> _logger;

        public DeleteStudentByIdCommandHandler(IAdminService adminService, ILogger<DeleteStudentByIdCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<DeleteStudentResponceVM> Handle(DeleteCurrentStudentById request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} DeleteStudentByIdCommandHandler", typeof(DeleteStudentByIdCommandHandler).Namespace);
            return await _adminService.DeleteStudentById(request.id);
        }
    }
}
