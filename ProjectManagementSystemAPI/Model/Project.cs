namespace ProjectManagementSystemAPI.Model
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
