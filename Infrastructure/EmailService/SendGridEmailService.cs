using Domain.Models.Cars;
using Domain.Models.Users;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.EmailService
{
    public class SendGridEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendEmail(User user, Car car)
        {
            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tumskruven@gmail.com");
            var to = new EmailAddress(user.Email);
            var templateId = "d-48d99dea44d446579b58edd39b2da56e";

            var result = MailHelper.CreateSingleTemplateEmail(from, to, templateId, car);

            var response = await client.SendEmailAsync(result);

            return await Task.FromResult(response);
        }

    }
}
