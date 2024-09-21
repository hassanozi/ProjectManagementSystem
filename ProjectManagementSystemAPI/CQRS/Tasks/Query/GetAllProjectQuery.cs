using MediatR;
using ProjectManagementSystemAPI.Constants;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.DTOs.TaskDTOs;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Specification;
using ProjectManagementSystemAPI.ViewModels;
using System.Linq;

namespace ProjectManagementSystemAPI.CQRS.Tasks.Query
{
    public record GetAllProjectQuery(TaskDTO TaskDTO) :IRequest<ResponseViewModel>;

    public class GetAllProjectQueryHandler : BaseRequestHandler<Model.Tasks, GetAllProjectQuery, ResponseViewModel>
    {
        public GetAllProjectQueryHandler(RequestParameters requestParameters, IRepository<Model.Tasks> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<ResponseViewModel> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            BaseSpecification<Model.Tasks> baseSpecification = new BaseSpecification<Model.Tasks>();
            string ProjectTasks = Entity.ProjectTasks.ToString();
            string UserTasks = Entity.UserTasks.ToString();

            var task = _repository.GetAllPag(x=>x.Title == "").Result.Select(x=> new TaskAllDataDTO
            {
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                ProjectName = x.Project.Title,
                // Get the latest User based on a date field, e.g., JoinDate or StartDate
                UserName = x.UserTasks.OrderByDescending(ut=>ut.User.CreateDate)
                           .Select(ut => ut.User.UserName)
                           .SingleOrDefault()
                           ,
                EndDate = x.EndDate,
            });

           var result = task.ToList();
            return ResponseViewModel.Success(result);
        }
    }


}
