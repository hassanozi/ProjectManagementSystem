using MediatR;
using ProjectManagementSystemAPI.CQRS.Roles.Query;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.RoleFeatureDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.RoleFeatures.Commands
{
    public record AssignFeaturesToRoleOrchestrator(AddFeaturesToRuleDTO addFeaturesToRuleDTO) : IRequest<ResponseViewModel>;

    public class AssignFeaturesToRoleOrchestratorHandler : BaseRequestHandler<RoleFeature, AssignFeaturesToRoleOrchestrator, ResponseViewModel>
    {
        public AssignFeaturesToRoleOrchestratorHandler(RequestParameters requestParameters, IRepository<RoleFeature> repository) : base(requestParameters, repository) { }

        public override async Task<ResponseViewModel> Handle(AssignFeaturesToRoleOrchestrator request, CancellationToken cancellationToken)
        {
            if (request == null || request.addFeaturesToRuleDTO == null || !request.addFeaturesToRuleDTO.Features.Any())
            {
                return ResponseViewModel.Failure("Invalid data.");
            }

            var role = await _mediator.Send(new GetRoleByIdQuery(request.addFeaturesToRuleDTO.RoleId));
            //var role = await _repository.GetByIdAsync(request.addFeaturesToRuleDTO.RoleId);
            if (role == null)
            {
                return ResponseViewModel.Failure("Role not found.");
            }

            foreach (var feature in request.addFeaturesToRuleDTO.Features)
            {
                var existingRoleFeature = await _repository.First(
                    rf => rf.RoleID == request.addFeaturesToRuleDTO.RoleId && rf.Feature == feature
                );

                if (existingRoleFeature == null)
                {
                    var roleFeature = new RoleFeature
                    {
                        RoleID = request.addFeaturesToRuleDTO.RoleId,
                        Feature = feature
                    };

                    await _repository.AddAsync(roleFeature);
                }
            }

            await _repository.SaveChangesAsync();

            return ResponseViewModel.Success("Features assigned to role successfully.");
        }

    }
}
