using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace SendGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = "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";//Needs to be abstracted
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("emailsubsystemtest@gmail.com", "Console App");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("grvis1@student.monash.edu", "Alex");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
