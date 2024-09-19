namespace ProjectManagementSystemAPI.ViewModels.Projects
{
    public class ProjectViewModel
    {
        public string Title { get; set; }
        public string Statues { get; set; }
        public int NumUsers { get; set; }
        public int NumTasks { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
