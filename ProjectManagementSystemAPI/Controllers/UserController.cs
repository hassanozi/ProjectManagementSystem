using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.CQRS.User.Commands;
using ProjectManagementSystemAPI.CQRS.User.Queries;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Paging;
using ProjectManagementSystemAPI.ViewModels.UserViewModels;

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
        [HttpGet]
        public async Task<UserReturnViewModel> GetUserByID(int id)
        {
            var result =  _mediator.Send(new GetUserByIdQuery(id)).MapOne<UserReturnViewModel>();
            return result ;
        }
        [HttpGet]
        public async Task<IEnumerable<UserReturnViewModel>> GetAllUsers(PagingParameters pagingParameters)
        {
            var result = _mediator.Send(new GetAllUsersQuery(pagingParameters)).MapOne<IEnumerable<UserReturnViewModel>>();
            return result;
        }
        [HttpPost]

        public async Task<ActionResult<ResultDTO>> Register(UserRegisterDTO user)
        {
            var x = await _mediator.Send(new RegisterUserCommand( user));

            return Ok( x);
        }


        [HttpPost]
        public async Task<ActionResult<ResultDTO>> Login(UserLoginDTO user)
        {
            var x = await _mediator.Send(new LoginUserCommand(user));

            return Ok(x);
        }
    }
}
