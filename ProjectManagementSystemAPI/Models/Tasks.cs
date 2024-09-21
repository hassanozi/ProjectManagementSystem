using ProjectManagementSystemAPI.Enum;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.Model
{
    public class Tasks : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTask Status { get; set; } = StatusTask.ToDo;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectId { get; set; }
      
        public Project Project{ get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
