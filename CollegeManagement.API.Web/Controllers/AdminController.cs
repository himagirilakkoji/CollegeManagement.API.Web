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
        public async Task<ActionResult<LoginResponceVM>> Post([FromBody]  LoginRequestPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<LoginResponceVM>(new PostLoginValidation(request));
                
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
        public async Task<ActionResult<DepartmentResponceVM>> Get()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DepartmentResponceVM>(new GetDepartmentData());

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
        public async Task<ActionResult<InsertFacultyResponceVM>> Post([FromBody] InsertFacultyPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertFacultyResponceVM>(new PostFacultyDetails(request));

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
        // Return Facultylist Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllFaculties")]
        public async Task<ActionResult<FacultyListResponceVM>> GetAllFaculties()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<FacultyListResponceVM>(new GetAllFacultyList());

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
        public async Task<ActionResult<FacultyListResponceVM>> DeleteCurrentFaculty(Guid Id)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DeleteFacultyResponceVM>(new DeleteCurrentFacultyById(Id));

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
        public async Task<ActionResult<UpdateFacultyResponceVM>> UpdateCurrentFaculty([FromRoute] Guid Id, [FromBody] UpdateFacultyPayload updateFacultyPayload)
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
                var result = await _mediator.Send<UpdateFacultyResponceVM>(new UpdateCurrentFacultyById(updateFacultyPayload));

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
        public async Task<ActionResult<InsertFacultyResponceVM>> CreateStudent([FromBody] InsertStudentPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertStudentResponceVM>(new PostStudentDetails(request));

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
        // Return Studentlist Details
        // </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<StudentListResponceVM>>> GetAllStudents()
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<StudentListResponceVM>>(new GetAllStudentList());

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
        public async Task<ActionResult<DeleteStudentResponceVM>> DeleteCurrentStudent(int Id)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<DeleteStudentResponceVM>(new DeleteCurrentStudentById(Id));

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
        public async Task<ActionResult<InsertStudentMarksResponceVM>> SaveStudentMarks([FromBody] InsertStudentMarksPayload request)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<InsertStudentMarksResponceVM>(new PostStudentExamMarksDetails(request));

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
        public async Task<ActionResult<List<CourseLevelReportResponceVM>>> GetCourseLevelReportByFacultyId(Guid guid)
        {
            try
            {
                _logger.LogInformation("Started processing {namespace} AdminController", typeof(AdminController).Namespace);
                var result = await _mediator.Send<List<CourseLevelReportResponceVM>>(new GetCourseLevelReportList(guid));

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
