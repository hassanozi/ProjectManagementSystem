namespace ProjectManagementSystemAPI.Model
{
    public class Claim : BaseModel
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
