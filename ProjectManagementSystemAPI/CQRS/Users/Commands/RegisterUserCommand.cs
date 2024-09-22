using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.AuthDTOs;
using ProjectManagementSystemAPI.Enums;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Services;
using ProjectManagementSystemAPI.Settings;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Users.Commands
{
    public record RegisterUserCommand(UserRegisterDTO userRegisterDTO) : IRequest<ResponseViewModel>;

    public class RegisterUserCommandHandler  : BaseRequestHandler<User, RegisterUserCommand, ResponseViewModel> 
    {
        private readonly IMailingService _mailingService;

        //IRepository<User> _userRepository;
        public RegisterUserCommandHandler(RequestParameters requestParameters
            , IRepository<User> userRepository,IMailingService mailingService

            ) : base( requestParameters
                ,  userRepository
                )
        {
            _mailingService = mailingService;
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

            //if (result is not null)
            //{
            //    return ResponseViewModel.Faliure("Email is already registered!");
            //}

            //result = await _repository.First(user => user.UserName == request.userRegisterDTO.UserName);

            //if (result is not null)
            //{
            //    return ResponseViewModel.Faliure("Username is alerady registered!");
            //}

            // Generate email confirmation token
            var token = new Random().Next(1,10000).ToString();
            var expiration = DateTime.UtcNow.AddHours(24);

            User user = request.userRegisterDTO.MapOne<User>();
            user.PasswordHash = PasswordHelper.CreatePasswordHash(request.userRegisterDTO.Password);

            user.EmailConfirmationToken = token;
            user.TokenExpiration = expiration;
            await _mailingService.SendEmailAsync(new SendEmailParameters
            {
                MailTo=user.Email,
                Body = $"Verification Code is : {user.EmailConfirmationToken}",
                Subject = "Verify Your Account Registration"
            });
         
            user = await _repository.AddAsync(user);


            ResponseViewModel resultDTO = ResponseViewModel.Success(user);
            return ResponseViewModel.Success(user);

        }
    }
}
