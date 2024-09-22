namespace ProjectManagementSystemAPI.Settings
{
    public class SendEmailParameters
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<IFormFile> attachments { get; set; } = null;
    }
}
