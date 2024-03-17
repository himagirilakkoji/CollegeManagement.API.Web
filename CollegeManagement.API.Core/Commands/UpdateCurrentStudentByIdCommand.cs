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
    public record UpdateCurrentStudentById(int id ,UpdateStudentPayload updateStudentPayload) : IRequest<UpdateStudentResponseVM>
    {
    }
}
