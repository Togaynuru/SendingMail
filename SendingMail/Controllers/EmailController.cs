using Microsoft.AspNetCore.Mvc;
using SendingMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendingMail.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email email)
        {
            try
            {
                MailMessage mail = new MailMessage();
            mail.To.Add("togaynuru94@gmail.com");
            mail.From = new MailAddress("togaynuru94@gmail.com");
            mail.Subject ="Kişisel Websitenizden Mesaj var ==>" + email.Topic;
            mail.Body = "Mail from : " + email.Name + "<br />Gonderen Mail Adres :" + email.EmailAdress+ "<br />You can find the contents of the mail below. <br /><hr />" + email.Comment;
            mail.IsBodyHtml = true;


            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("togaynuru94@gmail.com", "ngdhgkmiuvehplrx");
            //smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

                if (ModelState.IsValid == true)
                {
                    smtp.Send(mail);

                    ViewBag.Success = "Your message has been sent.You will receive feedback as soon as possible.";

                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Error = "Failed to send email. Something Wrong.!";
                    TempData["Message"] = "Failed to send email. Error reason :";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Failed to send email. Error reason :" + ex.Message;
                //TempData["Message"] = "Failed to send email. Error reason :" + ex.Message;
                return View();
            }
  
        }
    }
}
