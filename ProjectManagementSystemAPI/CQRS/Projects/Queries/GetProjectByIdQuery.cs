using MediatR;
using ProjectManagementSystemAPI.DTO;
using ProjectManagementSystemAPI.DTO.Project;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetProjectByIdQuery(int id):IRequest<ResultDTO>;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ResultDTO>
    {
        IRepository<Project> _repository;
        public GetProjectByIdQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<ResultDTO> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            if(request == null || request.id > 0)
            {
                return ResultDTO.Faliure("id should by greater than zero");
            }

            
            var project = _repository.GetByID(request.id);

            return ResultDTO.Sucess(project);

            
        }
    }
}
