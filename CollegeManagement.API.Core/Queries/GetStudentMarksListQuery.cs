using CollegeManagement.API.Core.Domain.Procedures;
using MediatR;

namespace CollegeManagement.API.Core.Queries
{
    public record GetStudentMarksList(int id) : IRequest<List<StudentMarksResponseVM>>
    {
    }
}
