using CollegeManagement.API.Core.Domain.Procedures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Queries
{
    public record GetSubjectLevelReportList(Guid id) : IRequest<List<SubjectLevelReportResponseVM>>
    {
    }
}
