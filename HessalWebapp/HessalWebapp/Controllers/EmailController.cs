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
                string smtpServer = "mail5017.site4now.net";
                int smtpPort = 25;
                string smtpUsername = "info@hessal-sol.com";
                string smtpPassword = "243243Godi@";

                // Create a MailMessage object
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("info@hessal-sol.com");
                mailMessage.To.Add("info@hessal-sol.com");
                mailMessage.Subject = "New Website Message";
                mailMessage.Body = $"First Name: {emailInput.FirstName} Last Name: {emailInput.LastName}\nContact: {emailInput.Contact} \nEmail: {emailInput.Email}\n\n{emailInput.Message}";

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = false;

                // Send the email
                try
                {
                    smtpClient.Send(mailMessage);
                    ViewBag.Message = "Your email was sent successfully. We shall get back to you shortly!";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Error sending email: \n {ex.Message}";
                }
            }
            return View("~/Views/Shared/SendEmail.cshtml", emailInput);
        }
    }
}




