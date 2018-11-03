using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Quartz;

namespace Invent.Models.Job
{
    public class OrderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("wd2vteam@gmail.com", "vishalsingh9407@gmail.com"))
            {
                message.Subject = "TEST";
                message.Body = "The Time is " + DateTime.Now;
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("wd2vteam@gmail.com", "9650402952")
                })
                {
                    client.Send(message);
                }
            }
        }
    }
}