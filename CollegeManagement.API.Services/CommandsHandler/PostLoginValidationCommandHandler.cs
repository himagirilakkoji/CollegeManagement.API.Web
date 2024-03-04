using CollegeManagement.API.Core.Commands;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Services.AdminRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CollegeManagement.API.Services.CommandsHandler
{
    public class PostLoginValidationCommandHandler : IRequestHandler<PostLoginValidation, LoginResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<PostLoginValidationCommandHandler> _logger;
        public PostLoginValidationCommandHandler(IAdminService adminService, ILogger<PostLoginValidationCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<LoginResponceVM> Handle(PostLoginValidation request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} PostLoginValidationCommandHandler", typeof(PostLoginValidationCommandHandler).Namespace);
            return await _adminService.PostLoginValidationAsync(request.LoginRequest);       
        }
    }
}
