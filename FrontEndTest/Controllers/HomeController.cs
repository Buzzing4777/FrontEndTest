using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FrontEndTest.Models;

namespace FrontEndTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactFormModel());
        }

       
        [HttpPost]
        public async Task<ActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>From: {0}</p> <p>Email: <a href=\"mailto:{1}\">{1}</a></p> <p>Phone#: {2}</p>";
                var subject = "AllCloud - new contact {0}";
                var message = new MailMessage();
                message.To.Add(new MailAddress("uxteam@taxslayer.com")); 
                message.Body = string.Format(body, model.Name, model.Email, model.Phone);
                message.Subject = string.Format(subject, model.Name);

                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}