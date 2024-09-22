using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.ProjectDTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Specification;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetAllProjectQuery(ProjectDTO ProjectDTO):IRequest<List<ProjectAllDataDTO>>;

    public class GetAllProjectQueryHandler : BaseRequestHandler<Project, GetAllProjectQuery, List<ProjectAllDataDTO>>
    {
        public GetAllProjectQueryHandler(RequestParameters requestParameters, IRepository<Project> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<List<ProjectAllDataDTO>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            BaseSpecification<Project> baseSpecification = new BaseSpecification<Project>();
            baseSpecification.AddInclude(t => t.Include(p => p.UserProjects));
            baseSpecification.AddInclude(t => t.Include(u => u.Tasks));
            baseSpecification.AddCriteria(c=>c.Title == request.ProjectDTO.Title
            && c.Status == request.ProjectDTO.Status);
            var projects = _repository
                .GetAll(baseSpecification)
                .Result.Select(p=> new ProjectAllDataDTO
            {
                Title = p.Title,
                Description = p.Description,
                Status = p.Status,
                CreatedOn = p.CreatedOn,
                TasksNumber = p.Tasks.Count(),
                UsersNumber = p.UserProjects
                .Select(u=>u.User).Count(),
            }).ToList();
           
            return projects;
        }
    }



}
