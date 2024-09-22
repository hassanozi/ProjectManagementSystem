using MediatR;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Query
{
    public record GetTasksCountQuery():IRequest<int>;

    public class GetTasksCountQueryHandler : BaseRequestHandler<Model.Tasks, GetTasksCountQuery, int>
    {
        public GetTasksCountQueryHandler(RequestParameters requestParameters, IRepository<Model.Tasks> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<int> Handle(GetTasksCountQuery request, CancellationToken cancellationToken)
        {
            var TasksNo =  _repository.GetAll().Count();
            return TasksNo;
            
        }
    }
}
