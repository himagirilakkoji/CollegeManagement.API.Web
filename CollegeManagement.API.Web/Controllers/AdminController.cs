using CollegeManagement.API.Core.Commands;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeManagement.API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator, ILogger<AdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Return LoginValidation Details
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("LoginValidation")]
        public async Task<ActionResult<LoginResponseVM>> Post([FromBody]  LoginRequestPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<LoginResponseVM>(new PostLoginValidation(request));
                
                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.adminDetails == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Return DepartmentWithCourses Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetDepartmentDetails")]
        public async Task<ActionResult<DepartmentResponseVM>> Get()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DepartmentResponseVM>(new GetDepartmentData());

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Post CreateFaculty Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("CreateFaculty")]
        public async Task<ActionResult<InsertFacultyResponseVM>> Post([FromBody] InsertFacultyPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertFacultyResponseVM>(new PostFacultyDetails(request));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Return Faculty list Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllFaculties")]
        public async Task<ActionResult<FacultyListResponseVM>> GetAllFaculties()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<FacultyListResponseVM>(new GetAllFacultyList());

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Delete FacultyUser Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteCurrentFaculty/{Id}")]
        public async Task<ActionResult<FacultyListResponseVM>> DeleteCurrentFaculty(Guid Id)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DeleteFacultyResponseVM>(new DeleteCurrentFacultyById(Id));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null || result.Response.ToLower() == "faculty does not exist")
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Update FacultyUser Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateCurrentFaculty/{Id}")]
        public async Task<ActionResult<UpdateFacultyResponseVM>> UpdateCurrentFaculty([FromRoute] Guid Id, [FromBody] UpdateFacultyPayload updateFacultyPayload)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);

                updateFacultyPayload = new UpdateFacultyPayload
                {
                    Id        = Id,
                    FirstName = updateFacultyPayload.FirstName,
                    LastName  = updateFacultyPayload.LastName,
                    UserName  = updateFacultyPayload.UserName,
                    Email = updateFacultyPayload.Email,
                    Dept      = updateFacultyPayload.Dept,
                    courseRequests = updateFacultyPayload.courseRequests,
                    subjectRequests = updateFacultyPayload.subjectRequests,
                };

                // Assuming a method to map the request to a command for the mediator
                var result = await _mediator.Send<UpdateFacultyResponseVM>(new UpdateCurrentFacultyById(updateFacultyPayload));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Return Faculty list Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllFacultiesWithPagination/{pageNumber}/{pageSize}")]
        public async Task<ActionResult<FacultyListResponseVM>> GetAllFacultiesWithPagination([FromRoute] int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<FacultyListResponseVM>(new GetAllFacultyListWithPagination(pageNumber, pageSize));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Post CreateStudent Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("CreateStudent")]
        public async Task<ActionResult<InsertFacultyResponseVM>> CreateStudent([FromBody] InsertStudentPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertStudentResponseVM>(new PostStudentDetails(request));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Return Student list Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<StudentListResponseVM>>> GetAllStudents()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<StudentListResponseVM>>(new GetAllStudentList());

                if (result == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Delete StudentUser Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteCurrentStudent/{Id}")]
        public async Task<ActionResult<DeleteStudentResponseVM>> DeleteCurrentStudent(int Id)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DeleteStudentResponseVM>(new DeleteCurrentStudentById(Id));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null || result.Response.ToLower() == "faculty does not exist")
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Save StudentExamMarks
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("SaveStudentMarks")]
        public async Task<ActionResult<InsertStudentMarksResponseVM>> SaveStudentMarks([FromBody] InsertStudentMarksPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertStudentMarksResponseVM>(new PostStudentExamMarksDetails(request));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Return CourseLevelReport Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("CourseLevelReport/{guid}")]
        public async Task<ActionResult<List<CourseLevelReportResponseVM>>> GetCourseLevelReportByFacultyId(Guid guid)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<CourseLevelReportResponseVM>>(new GetCourseLevelReportList(guid));

                if (!result.Any())
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        // <summary>
        // Return SubjectLevelReport Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("SubjectLevelReport/{guid}")]
        public async Task<ActionResult<List<SubjectLevelReportResponseVM>>> GetSubjectLevelReportByFacultyId([FromRoute] Guid guid)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<SubjectLevelReportResponseVM>>(new GetSubjectLevelReportList(guid));

                if (!result.Any())
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Update StudentUser Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateCurrentStudent/{Id}")]
        public async Task<ActionResult<UpdateStudentResponseVM>> UpdateCurrentStudent([FromRoute] int Id, [FromBody] UpdateStudentPayload updateFacultyPayload)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);

                // Assuming a method to map the request to a command for the mediator
                var result = await _mediator.Send<UpdateStudentResponseVM>(new UpdateCurrentStudentById(Id , updateFacultyPayload));

                if (result.ErrorProcedure != null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                if (result.Response == null)
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // <summary>
        // Return StudentMarksList Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("StudentMarksListById/{Id}")]
        public async Task<ActionResult<List<StudentMarksResponseVM>>> StudentMarksListById(int Id)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<StudentMarksResponseVM>>(new GetStudentMarksList(Id));

                if (!result.Any())
                {
                    _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                    return NotFound();
                }

                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Completed processing {namespace} AdminController", typeof(AdminController).Namespace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
