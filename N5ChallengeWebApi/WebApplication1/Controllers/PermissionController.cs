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
        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var query = new GetAllPermissionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> RequestPermission(RequestPermission permission)
        {
            var command = new RequestPermissionCommand { Permission = permission };
            var result = await _mediator.Send(command);
            return StatusCode((int) HttpStatusCode.Created, result);
        }
        [HttpPut]
        public async Task<IActionResult> ModifyPermission(ModifyPermission permission)
        {
            var command = new ModifyPermissionCommand { ModifyPermission = permission };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
