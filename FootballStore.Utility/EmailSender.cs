using Microsoft.AspNetCore.Identity.UI.Services;

namespace FootballStore.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string obj)
        {
            return Task.CompletedTask;
        }
    }
}
