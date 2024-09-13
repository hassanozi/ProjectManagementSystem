using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.User.Commands;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Users;

namespace ProjectManagementSystemAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResultDTO>> Register(UserDTO user)
        {
            var x = await _mediator.Send(new RegisterUserCommand( user));

            return Ok( x);
        }
    }
}
