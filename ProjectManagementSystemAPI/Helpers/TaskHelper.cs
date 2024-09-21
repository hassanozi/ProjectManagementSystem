using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.ViewModels;

namespace ProjectManagementSystemAPI.Helpers
{
    public class TaskHelper
    {
        IRepository<Model.Tasks> _repository;
        IRepository<Project> repositoryProject;
        IRepository<User > repositoryUser;
        public TaskHelper(IRepository<Tasks> repository, IRepository<Project> repositoryProject, IRepository<User> repositoryUser)
        {
            _repository = repository;
            this.repositoryProject = repositoryProject;
            this.repositoryUser = repositoryUser;
        }

        //public async Task<ResponseViewModel> getTask()
        //{
        //    var tasks =  _repository.GetAll().ToList();
        //}
    }
}
