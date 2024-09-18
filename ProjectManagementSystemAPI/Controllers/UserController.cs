using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.User.Commands;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.ViewModels;

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

        public async Task<ActionResult<ResponseViewModel>> Register(UserRegisterDTO user)
        {
            var x = await _mediator.Send(new RegisterUserCommand( user));

            return Ok( x);
        }


        [HttpPost]
        public async Task<ActionResult<ResponseViewModel>> Login(UserLoginDTO user)
        {
            var x = await _mediator.Send(new LoginUserCommand(user));

            return Ok(x);
        }
    }
}
