using ProjectManagementSystemAPI.Enums;

namespace ProjectManagementSystemAPI.ViewModels.ProjectViewModels
{
    public class AddProjectViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public StatusProject Status { get; set; }
    }
}
