using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace HessalWebapp.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmailInputModel emailInput)
        {
            if (ModelState.IsValid)
            {
                // Set your email configuration
                string smtpServer = "smtp.titan.email";
                int smtpPort = 465;
                string smtpUsername = "info@hessal-sol.com";
                string smtpPassword = "grcVmCpnPbN86Sj";

                // Create a MailMessage object
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("info@hessal-sol.com");
                mailMessage.To.Add("info@hessal-sol.com");
                mailMessage.Subject = "Someone new wants to connect";
                mailMessage.Body = $"Name: {emailInput.FirstName} {emailInput.LastName}\nContact: {emailInput.Contact}\n\n{emailInput.Message}";

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Send the email
                try
                {
                    smtpClient.Send(mailMessage);
                    ViewBag.Message = "Email sent successfully.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Error sending email: {ex.Message}";
                }
            }
            return View("~/Views/Shared/SendEmail.cshtml", emailInput);
        }
    }
}




