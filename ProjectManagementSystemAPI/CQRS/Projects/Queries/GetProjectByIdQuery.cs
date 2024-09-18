using MediatR;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.CQRS.Projects.Queries
{
    public record GetProjectByIdQuery(int id):IRequest<ResponseViewModel>;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ResponseViewModel>
    {
        private readonly IRepository<Project> _repository;
        public GetProjectByIdQueryHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<ResponseViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            if(request == null || request.id > 0)
            {
                return ResponseViewModel.Faliure("id should by greater than zero");
            }
            
            var project = _repository.GetByID(request.id);

            return ResponseViewModel.Sucess(project);
        }
    }
}
