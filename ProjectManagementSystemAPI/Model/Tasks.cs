using ProjectManagementSystemAPI.Constants.Enum;

namespace ProjectManagementSystemAPI.Model
{
    public class Tasks:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTask status { get; set; }
        public List<ProjectTasks> ProjectTasks { get; set; }
        public List<UserTasks> UserTasks { get; set; }

    }
}
