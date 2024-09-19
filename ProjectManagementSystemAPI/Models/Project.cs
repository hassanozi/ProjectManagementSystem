using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.Model
{
    public class Project : BaseModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public StatusProject Status { get; set; }
        public List<Task> Tasks { get; set; }
        public List<UserProject> UserProjects { get; set; }
    }
}
