using CollegeManagement.API.Core.Domain;
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
    public class GetAdminDetailsByEmailQueryHandler : IRequestHandler<GetAdminByEmailID, AdminDetailsVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAdminDetailsByEmailQueryHandler> _logger;
        public GetAdminDetailsByEmailQueryHandler(IAdminService adminService, ILogger<GetAdminDetailsByEmailQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<AdminDetailsVM> Handle(GetAdminByEmailID request, CancellationToken cancellationToken)
        {
            return await _adminService.GetAdminByEmailAsync(request.LoginRequest);
        }
    }
}
