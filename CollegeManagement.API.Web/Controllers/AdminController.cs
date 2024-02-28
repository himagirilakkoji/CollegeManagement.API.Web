using CollegeManagement.API.Core.Domain;
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
        /// Return Organization Details
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("AdminDetailsByEmailID/{EmailID}/{Password}")]
        public async Task<ActionResult<AdminDetailsVM>> Get(string EmailID, string Password)
        {
            LoginRequestPayload request = new LoginRequestPayload()
            {
                EmailID = EmailID,
                Password = Password
            };

            var result = await _mediator.Send<AdminDetailsVM>(new GetAdminByEmailID(request));

            return Ok(result);
        }
    }
}
