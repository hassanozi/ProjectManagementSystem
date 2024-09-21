using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.AuthDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Users.Commands
{
    public record RegisterUserCommand(UserRegisterDTO userRegisterDTO) : IRequest<ResponseViewModel>;

    public class RegisterUserCommandHandler  : BaseRequestHandler<User, RegisterUserCommand, ResponseViewModel> 
    {
        //IRepository<User> _userRepository;
        public RegisterUserCommandHandler(RequestParameters requestParameters
            , IRepository<User> userRepository
            ) : base( requestParameters
                ,  userRepository
                )
        {
          // _userRepository = userRepository;
        }

        //public async Task<ResponseViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        //{
        //    var result = await _repository.First(u => u.Email == request.userRegisterDTO.Email);

        //    if (result is not null)
        //    {
        //        return ResponseViewModel.Faliure("Email is already registered!");
        //    }

        //    result = await _repository.First(user => user.UserName == request.userRegisterDTO.UserName);

        //    if (result is not null)
        //    {
        //        return ResponseViewModel.Faliure("Username is alerady registered!");
        //    }

        //    User user = request.userRegisterDTO.MapOne<User>();
        //    user.PasswordHash = PasswordHelper.CreatePasswordHash(request.userRegisterDTO.Password);
        //    user = await _repository.AddAsync(user);

        //    ResponseViewModel resultDTO = ResponseViewModel.Success(user);
        //    return ResponseViewModel.Success(user);
        //}

        public override async Task<ResponseViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.First(u => u.Email == request.userRegisterDTO.Email);

            if (result is not null)
            {
                return ResponseViewModel.Faliure("Email is already registered!");
            }

            result = await _repository.First(user => user.UserName == request.userRegisterDTO.UserName);

            if (result is not null)
            {
                return ResponseViewModel.Faliure("Username is alerady registered!");
            }

            User user = request.userRegisterDTO.MapOne<User>();
            user.PasswordHash = PasswordHelper.CreatePasswordHash(request.userRegisterDTO.Password);
            user = await _repository.AddAsync(user);

            ResponseViewModel resultDTO = ResponseViewModel.Success(user);
            return ResponseViewModel.Success(user);

        }
    }
}
