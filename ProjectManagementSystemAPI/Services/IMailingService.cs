using ProjectManagementSystemAPI.Settings;

namespace ProjectManagementSystemAPI.Services
{
    public interface IMailingService
    {
        Task SendEmailAsync(SendEmailParameters sendEmailParameters);
              
    }
}