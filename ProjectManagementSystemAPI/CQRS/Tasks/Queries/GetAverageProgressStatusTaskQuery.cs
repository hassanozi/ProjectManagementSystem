using MediatR;
using ProjectManagementSystemAPI.CQRS.Projects.Queries;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Repositories;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Query
{
    public record GetAverageProgressStatusTaskQuery():IRequest<int>;

    public class GetAverageProgressStatusTaskQueryHandler : BaseRequestHandler<Model.Tasks, GetAverageProgressStatusTaskQuery, int>
    {
        public GetAverageProgressStatusTaskQueryHandler(RequestParameters requestParameters, IRepository<Model.Tasks> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<int> Handle(GetAverageProgressStatusTaskQuery request, CancellationToken cancellationToken)
        {
            int ProgressStatusTaskNo =  _repository.GetAll(t=>t.Status == Enum.StatusTask.InProgress).Count();
           
            int ProjectNo = await _mediator.Send(new GetProjectCountQuery());


            return ProgressStatusTaskNo / ProjectNo;
        }
    }
}
