using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Core.Commands
{
    public record PostLoginValidation(LoginRequestPayload LoginRequest) : IRequest<LoginResponceVM>
    {

    }
}
