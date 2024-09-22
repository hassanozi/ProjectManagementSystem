using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetProjectCountQuery():IRequest<int>;

    public class GetProjectCountQueryHandler : BaseRequestHandler<Project, GetProjectCountQuery, int>
    {
        public GetProjectCountQueryHandler(RequestParameters requestParameters, IRepository<Project> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<int> Handle(GetProjectCountQuery request, CancellationToken cancellationToken)
        {
            var ProjectNo = _repository.GetAll().Count();

            return ProjectNo;
           
        }
    }
}
