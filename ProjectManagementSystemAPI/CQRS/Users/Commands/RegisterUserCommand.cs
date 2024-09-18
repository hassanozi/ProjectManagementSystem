﻿using MediatR;
using ProjectManagementSystemAPI.DTO.Auth;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Users.Commands
{
    public record RegisterUserCommand(UserRegisterDTO userRegisterDTO) : IRequest<ResponseViewModel>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseViewModel>
    {
        IRepository<User> _userRepository;
        public RegisterUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.First(u => u.Email == request.userRegisterDTO.Email);

            if (result is not null)
            {
                return ResponseViewModel.Faliure("Email is already registered!");
            }

            result = await _userRepository.First(user => user.UserName == request.userRegisterDTO.UserName);

            if (result is not null)
            {
                return ResponseViewModel.Faliure("Username is alerady registered!");
            }

            User user = request.userRegisterDTO.MapOne<User>();
            user.PasswordHash = PasswordHelper.CreatePasswordHash(request.userRegisterDTO.Password);
            user = await _userRepository.AddAsync(user);

            ResponseViewModel resultDTO =ResponseViewModel.Sucess(user);
            return ResponseViewModel.Sucess(user);
        }
    }
}
