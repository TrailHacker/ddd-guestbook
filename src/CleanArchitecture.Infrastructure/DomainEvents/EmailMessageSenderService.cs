using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace CleanArchitecture.Infrastructure.DomainEvents
{
    public class EmailMessageSenderService : IMessageSender
    {
	    public void SendGuestbookNotificationEmail(string toAddress, string messageBody)
	    {
		    var fromAddress = "lucas@hardbarger.com";
		    var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Guestbook", fromAddress));
		    message.To.Add(new MailboxAddress(toAddress, toAddress));
		    message.Subject = "New Message on Guestbook";
		    message.Body = new TextPart("plain") {Text = messageBody};
		    using (var client = new SmtpClient())
		    {
			    client.Connect("localhost", 25);
			    client.Send(message);
			    client.Disconnect(true);
		    }
	    }
    }
}
