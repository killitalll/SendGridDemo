using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace SendGrid.Models.Helper_Classes
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return configSendGridasync(message);
        }

        private Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            //myMessage.From = new System.Net.Mail.MailAddress("Joe@contoso.com", "Joe S.");
            myMessage.From = new SendGrid.Helpers.Mail.EmailAddress("Joe@contoso.com", "Joe S.");
            myMessage.Subject = message.Subject;
           // myMessage.Text = message.Body;
           //myMessage.Html = message.Body;
            myMessage.AddContent("text/plain", message.Body);

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                return transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                return Task.FromResult(0);
            }
        }
    }
}