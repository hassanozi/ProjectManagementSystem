using ProjectManagementSystemAPI.Enum;

namespace ProjectManagementSystemAPI.ViewModels.TaskViewModels
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        public StatusTask Status { get; set; }
        public int User { get; set; }
        public int Project { get; set; }
        public DateTime DateCreated { get; set; }= DateTime.Now;
    }
}
