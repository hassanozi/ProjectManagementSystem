namespace ProjectManagementSystemAPI.DTO.Projects
{
    public class ProjectsDTO
    {
        public string Title { get; set; }
        public string Statues { get; set; }
        public int NumUsers { get; set; }
        public int NumTasks { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;



    }
}
