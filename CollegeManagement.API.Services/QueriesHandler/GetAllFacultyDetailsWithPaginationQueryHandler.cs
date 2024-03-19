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
    public class GetAllFacultyDetailsWithPaginationQueryHandler : IRequestHandler<GetAllFacultyListWithPagination, FacultyListResponseWithPaginationVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllFacultyDetailsWithPaginationQueryHandler> _logger;

        public GetAllFacultyDetailsWithPaginationQueryHandler(IAdminService adminService, ILogger<GetAllFacultyDetailsWithPaginationQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<FacultyListResponseWithPaginationVM> Handle(GetAllFacultyListWithPagination request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} GetAllFacultyDetailsWithPaginationQueryHandler", typeof(GetAllFacultyDetailsWithPaginationQueryHandler).Namespace);
            return await _adminService.GetAllFacultyDetailsWithPagination(request.pageNumber , request.pageSize);
        }
    }
}
