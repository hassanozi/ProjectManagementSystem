using ProjectManagementSystemAPI.Enum;
using ProjectManagementSystemAPI.Models;

namespace ProjectManagementSystemAPI.Model
{
    public class Tasks : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTask Status { get; set; } = StatusTask.ToDo;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<ProjectTask> ProjectTasks { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
