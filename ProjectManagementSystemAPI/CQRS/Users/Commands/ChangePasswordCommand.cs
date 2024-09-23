using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Specification;
using ProjectManagementSystemAPI.ViewModels;


namespace ProjectsManagement.CQRS.Users.Commands
{
    public record ChangePasswordCommand(ChangePasswordDTO changePasswordDTO) : IRequest<ResponseViewModel>;


    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResponseViewModel>
    {
        private readonly IRepository<User> _userRepository;

        public ChangePasswordCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserSpecification(request.changePasswordDTO.Email);

            var user = await _userRepository.First(spec.Criteria);

            if (user is null)
            {
                return ResponseViewModel.Faliure("Invalid Email");
            }

            if (PasswordHelper.CheckUserPasswordAsync(request.changePasswordDTO.CurrentPassword, user.PasswordHash) is null)
            {
                return  ResponseViewModel.Faliure("Invalid Current Password");
            }

            user.PasswordHash = PasswordHelper.CreatePasswordHash(request.changePasswordDTO.NewPassword);
            //var decryptedPass = PasswordHelper.Decrypt(user.PasswordHash);
            //Console.WriteLine(decryptedPass);
             _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();

            return ResponseViewModel.Success(user, "Your Password  have been changed successfully");
        }
    }
}