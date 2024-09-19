using MediatR;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.ViewModels;
using ProjectManagementSystemAPI.Helpers;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.DTOs.AuthDTOs;

namespace ProjectManagementSystemAPI.CQRS.Users.Commands
{
    public record LoginUserCommand(UserLoginDTO userLoginDTO) : IRequest<ResponseViewModel>;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResponseViewModel>
    {
        IRepository<User> _userRepository;
        public LoginUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.First(c => c.Email == request.userLoginDTO.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.userLoginDTO.Password, user.PasswordHash))
            {
                return ResponseViewModel.Faliure("Email or Password is incorrect");
            }

            var userDTO = user.MapOne<UserDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return ResponseViewModel.Success(token, "User Login Successfully!");
        }
    }
}
