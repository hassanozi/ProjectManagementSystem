using ProjectManagementSystemAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystemAPI.Models
{
    public class ProjectTask:BaseModel
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Tasks")]
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
    }
}
