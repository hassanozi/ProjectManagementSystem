using HotelReservationApi.Mediators.Users;
using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;

namespace ProjectManagementSystemAPI.CQRS.User.Commands
{
    public record RegisterUserCommand(UserDTO UserDTO) :IRequest<bool>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,bool>
    {
        IMediator _mediator;
        IUserMediator _userMediator;
        public RegisterUserCommandHandler(IMediator mediator , IUserMediator userMediator)
        {
            _mediator = mediator;
            _userMediator = userMediator;
        }



        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.MapOne<UserRegisterDTO>();
           ResultDTO resultDTO =await  _userMediator.RegisterAsync(user);
            return true;

        }
    }



}
