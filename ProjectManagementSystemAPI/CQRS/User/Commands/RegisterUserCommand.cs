//using ProjectManagementSystemAPI.Mediators.Users;
using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.DTO.Users;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.User.Commands
{
    public record RegisterUserCommand(UserRegisterDTO UserRegisterDTO) :IRequest<ResultDTO>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,ResultDTO>
    {

       
        IRepository<Model.User> _userRepository;
        public RegisterUserCommandHandler(
            
             IRepository<Model.User> userRepository
            )
        {
            
           
            _userRepository = userRepository;
        }



        public async Task<ResultDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.First(u => u.Email == request.UserRegisterDTO.Email);

            if (result is not null)
            {
                return ResultDTO.Faliure("Email is already registered!");
            }

            result = await _userRepository.First(user => user.UserName == request.UserRegisterDTO.UserName);

            if (result is not null)
            {
                return ResultDTO.Faliure("Username is alerady registered!");
            }
            

           

            Model.User user = request.UserRegisterDTO.MapOne<Model.User>();
            user.PasswordHash = PasswordHelper.CreatePasswordHash( request.UserRegisterDTO.Password);
            user = await _userRepository.AddAsync(user);

            ResultDTO resultDTO =ResultDTO.Sucess(user);
            return ResultDTO.Sucess(user);

        }
    }



}
