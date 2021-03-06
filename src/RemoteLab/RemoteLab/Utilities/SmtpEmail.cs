﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace RemoteLab.Utilities
{
    /// <summary>
    /// Utility Class for sending SMTP mail 
    /// </summary>
    public class SmtpEmail
    {
      
        public async Task SendMailAsync(String SmtpHost, String FromEmail, String ToEmailsCommaSeparated, String Subject, String Body)
        {
            using(var Msg = new MailMessage() {
                From = new MailAddress(FromEmail),
                Subject = Subject,
                Body = Body,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = false 
            })
            {
                Msg.To.Add(ToEmailsCommaSeparated);

                using(var Smtp = new SmtpClient(SmtpHost))
                {
                    await Smtp.SendMailAsync(Msg);
                }                
            }
        }

    }
}