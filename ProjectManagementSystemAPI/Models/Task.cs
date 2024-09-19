using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.Model
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusTask Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ProjectId { get; set; }
        public List<UserTask> UserTasks { get; set; }
    }
}
