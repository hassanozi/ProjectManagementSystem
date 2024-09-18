using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.Model
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTask status { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
