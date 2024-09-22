using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetAllProjectQuery(ProjectDTO ProjectDTO):IRequest<ProjectAllDataDTO>;

    public class GetAllProjectQueryHandler : BaseRequestHandler<Project, GetAllProjectQuery, ProjectAllDataDTO>
    {
        public GetAllProjectQueryHandler(RequestParameters requestParameters, IRepository<Project> repository) : base(requestParameters, repository)
        {
        }

        public override Task<ProjectAllDataDTO> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = _repository.GetAllPag(p => p.Title == request.ProjectDTO.Title, 10, 0, x => x.UserProjects);
            throw new NotImplementedException();
        }
    }



}
