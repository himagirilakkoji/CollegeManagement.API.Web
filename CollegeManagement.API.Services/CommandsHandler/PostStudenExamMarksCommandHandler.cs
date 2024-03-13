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
    public class PostStudenExamMarksCommandHandler : IRequestHandler<PostStudentExamMarksDetails, InsertStudentMarksResponceVM>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<PostStudenExamMarksCommandHandler> _logger;

        public PostStudenExamMarksCommandHandler(IAdminService adminService, ILogger<PostStudenExamMarksCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<InsertStudentMarksResponceVM> Handle(PostStudentExamMarksDetails request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started processing {namespace} PostStudenExamMarksCommandHandler", typeof(PostStudenExamMarksCommandHandler).Namespace);
            return await _adminService.InsertStudentExamMarksAsync(request.insertStudentMarksPayload);
        }
    }
}
