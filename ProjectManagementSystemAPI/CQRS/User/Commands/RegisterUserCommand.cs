using ProjectManagementSystemAPI.Mediators.Users;
using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.User.Commands
{
    public record RegisterUserCommand(UserRegisterDTO UserDTO) :IRequest<bool>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,bool>
    {
        IMediator _mediator;
        IUserMediator _userMediator;
        IRepository<Model.User> _userRepository;
        public RegisterUserCommandHandler(IMediator mediator 
            , IUserMediator userMediator
            , IRepository<Model.User> userRepository
            )
        {
            _mediator = mediator;
            _userMediator = userMediator;
            _userRepository = userRepository;
        }



        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if( request == null )
            {
                return false;
            }

            var user = request.MapOne<UserRegisterDTO>();
            Model.User user1 = user.MapOne<Model.User>();
            
             ResultDTO resultDTO =await  _userMediator.RegisterAsync(user);
            return true;

        }
    }



}
