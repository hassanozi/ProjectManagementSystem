using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ProjectManagementSystemAPI.Model;
using ProjectManagementSystemAPI.Repositories;
using ProjectManagementSystemAPI.Settings;


namespace ProjectManagementSystemAPI.Services
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;
        private readonly IRepository<User> _userRepository;

        public MailingService(IOptions<MailSettings> mailSettings,IRepository<User> repository)
        {
            _mailSettings = mailSettings.Value;
            _userRepository = repository;
        }



        public async Task SendEmailAsync(SendEmailParameters sendEmailParameters)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = sendEmailParameters.Subject,
            };

            email.To.Add(MailboxAddress.Parse(sendEmailParameters.MailTo));

            var builder = new BodyBuilder();

            if (sendEmailParameters.attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in sendEmailParameters.attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();

                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = sendEmailParameters.Body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
    }
}