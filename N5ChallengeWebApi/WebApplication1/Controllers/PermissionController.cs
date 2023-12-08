using Microsoft.AspNetCore.Mvc;
using N5ChallengeWebApiApplication.DTOs;
using MediatR;
using N5ChallengeWebApiApplication.Features.Commands;
using System.Net;
using N5ChallengeWebApiApplication.Features.Queries;
namespace N5ChallengeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PermissionController> _logger;
        public PermissionController(IMediator mediator, ILogger<PermissionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            _logger.LogInformation("Executing method: " + nameof(GetAllPermissions) + " at " + DateTime.Now);
            var query = new GetAllPermissionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> RequestPermission(RequestPermission permission)
        {
            _logger.LogInformation("Executing method: " + nameof(RequestPermission) + " at " + DateTime.Now);
            var command = new RequestPermissionCommand { Permission = permission };
            var result = await _mediator.Send(command);
            return StatusCode((int) HttpStatusCode.Created, result);
        }
        [HttpPut]
        public async Task<IActionResult> ModifyPermission(ModifyPermission permission)
        {
            _logger.LogInformation("Executing method: " + nameof(ModifyPermission) + " at " + DateTime.Now);
            var command = new ModifyPermissionCommand { ModifyPermission = permission };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
