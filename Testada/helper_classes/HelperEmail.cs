using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Testada
{
    class HelperEmail
    {
        public static bool send(string to, string subject, string msg, List<string> attachmentFilePaths = default(List<string>))
        {
            try
            {
                // setup mail message
                MailMessage message = new MailMessage();
                //message.IsBodyHtml = true;
                message.From = new MailAddress(HelperSettings.get("smtpFrom"));
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = msg;

                // setup mail client
                SmtpClient mailClient = new SmtpClient(HelperSettings.get("smtpServer"));

                //if authentication is turned on
                if (HelperSettings.get("smtpAuthenticate"))
                {
                    mailClient.Credentials = new NetworkCredential(HelperSettings.get("smtpUsername"), HelperSettings.get("smtpPassword"));
                }

                //attach files if requested
                if (attachmentFilePaths.Count > 0)
                {
                    foreach (string attachmentFilePath in attachmentFilePaths)
                    {
                        message.Attachments.Add(new Attachment(attachmentFilePath));
                    }
                }

                // send message
                mailClient.Send(message);

                //return true to indicate success of sending message
                return true;
            }
            catch (Exception)
            {
                //return false to indicate error
                return false;
            }
        }
    }
}
