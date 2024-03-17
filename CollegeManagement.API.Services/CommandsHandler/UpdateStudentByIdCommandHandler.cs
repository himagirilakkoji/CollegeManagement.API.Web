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
    public class UpdateStudentByIdCommandHandler : IRequestHandler<UpdateCurrentStudentById, UpdateStudentResponseVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<UpdateStudentByIdCommandHandler> _logger;

        public UpdateStudentByIdCommandHandler(IAdminService adminService, ILogger<UpdateStudentByIdCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<UpdateStudentResponseVM> Handle(UpdateCurrentStudentById request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} UpdateStudentByIdCommandHandler", typeof(UpdateStudentByIdCommandHandler).Namespace);
            return await _adminService.UpdateStudentById(request.id, request.updateStudentPayload);
        }
    }
}
