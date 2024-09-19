using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystemAPI.Model
{
    public class UserTask : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Tasks")]

        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
    }
}
