using MediatR;
using ProjectManagementSystemAPI.CQRS.Roles.Query;
using ProjectManagementSystemAPI.CQRS.Users.Queries;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.RoleFeatureDTOs;
using ProjectManagementSystemAPI.DTOs.UserRoleDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.UserRoles.Orchestrators
{
    public record AssignRolesToUserOrchestrator(AddRolesToUserDTO addRolesToUserDTO) : IRequest<ResponseViewModel>;

    public class AssignFeaturesToRoleOrchestratorHandler : BaseRequestHandler<UserRole, AssignRolesToUserOrchestrator, ResponseViewModel>
    {
        public AssignFeaturesToRoleOrchestratorHandler(RequestParameters requestParameters, IRepository<UserRole> repository) : base(requestParameters, repository) { }

        public override async Task<ResponseViewModel> Handle(AssignRolesToUserOrchestrator request, CancellationToken cancellationToken)
        {
            if (request == null || request.addRolesToUserDTO == null || !request.addRolesToUserDTO.RoleIds.Any())
            {
                return ResponseViewModel.Failure("Invalid data.");
            }

            var user = await _mediator.Send(new GetUserByIdQuery(request.addRolesToUserDTO.UserId));
            //var role = await _repository.GetByIdAsync(request.addFeaturesToRuleDTO.RoleId);
            if (user == null)
            {
                return ResponseViewModel.Failure("User not found.");
            }

            foreach (var roleId in request.addRolesToUserDTO.RoleIds)
            {
                var existingUserRole = await _repository.First(
                    ur => ur.UserId == request.addRolesToUserDTO.UserId && ur.RoleId == roleId
                );

                if (existingUserRole == null)
                {
                    var userRole = new UserRole
                    {
                        UserId = request.addRolesToUserDTO.UserId,
                        RoleId = roleId
                    };

                    await _repository.AddAsync(userRole);
                }
            }

            await _repository.SaveChangesAsync();

            return ResponseViewModel.Success("Roles assigned to user successfully.");
        }

    }
}
