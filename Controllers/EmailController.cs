using Microsoft.AspNetCore.Mvc;

namespace DotnetSmtp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailManager _emailManager;

        public EmailController(ILogger<EmailController> logger, IEmailManager emailManager)
        {
            _logger = logger;
            _emailManager = emailManager;
        }

        [HttpGet]
        public bool EmailTrigger()
        {
           return this._emailManager.EmailTrigger();
        }
    }
}
