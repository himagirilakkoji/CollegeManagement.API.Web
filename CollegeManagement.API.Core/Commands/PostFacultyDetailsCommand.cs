using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Commands
{
    public record PostFacultyDetails(InsertFacultyPayload InsertFacultyPayload) : IRequest<InsertFacultyResponceVM>
    {
    }
}
