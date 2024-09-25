using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Helper;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.ProjectUser.Command
{
    public record AssignUserInProjectCommand(UserProjectDTO userProjectDTO) : IRequest<ResponseViewModel>;

    public class AssignUserInProjectCommandHandler : BaseRequestHandler<UserProject, AssignUserInProjectCommand, ResponseViewModel>
    {
        public AssignUserInProjectCommandHandler(RequestParameters requestParameters, IRepository<UserProject> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<ResponseViewModel> Handle(AssignUserInProjectCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return ResponseViewModel.Failure("Don't do this again bro");
            }
           
            UserProject userProject = request.userProjectDTO.MapOne<UserProject>();
            var result = await _repository.AddAsync(userProject);
            return ResponseViewModel.Success(result);
           
        }
    }
}
