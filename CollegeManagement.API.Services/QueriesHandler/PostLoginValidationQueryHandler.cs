using CollegeManagement.API.Core.Domain;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CollegeManagement.API.Services.QueriesHandler
{
    public class PostLoginValidationQueryHandler : IRequestHandler<PostLoginValidation, LoginResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<PostLoginValidationQueryHandler> _logger;
        public PostLoginValidationQueryHandler(IAdminService adminService, ILogger<PostLoginValidationQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<LoginResponceVM> Handle(PostLoginValidation request, CancellationToken cancellationToken)
        {
            return await _adminService.PostLoginValidationAsync(request.LoginRequest);
        }
    }
}
