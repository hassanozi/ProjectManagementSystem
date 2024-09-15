using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Constants;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.DTO.Users;

namespace ProjectManagementSystemAPI.CQRS.User.Commands
{
    public record LoginUserCommand(UserLoginDTO UserLoginDTO) : IRequest<ResultDTO>;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultDTO>
    {
        IRepository<Model.User> _userRepository;
        public LoginUserCommandHandler(IRepository<Model.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
            var user = await _userRepository.First(c=>c.Email == request.UserLoginDTO.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.UserLoginDTO.Password, user.PasswordHash))
            {
                return ResultDTO.Faliure("Email or Password is incorrect");
            }

            var userDTO = user.MapOne<UserDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

          
            return ResultDTO.Sucess(token, "User Login Successfully!");
        
        }

    }
}
