namespace ProjectManagementSystemAPI.Model
{
    public class ProjectTasks:BaseModel
    {
        public int ProjectId { get; set; }  
        public Project Project { get; set; }
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }
    }
}
