using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.Services;
using ProjectManagementSystemAPI.Settings;
namespace ProjectManagementSystemAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;

        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] SendEmailParameters dto)
        {
            await _mailingService.SendEmailAsync(dto);
            return Ok();
        }

            }
}