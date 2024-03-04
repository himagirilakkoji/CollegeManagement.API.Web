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
    }
}
