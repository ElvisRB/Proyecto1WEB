using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Proyecto1WEB2.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime; 

namespace Proyecto1WEB2.Controllers
{
    public class HomeController : Controller
    {
        private RecommendationDb db = new RecommendationDb();
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Contact(string name = "", string email = "",  string password="", string message = "")
        {
            System.Net.Mail.MailMessage newEmail = new System.Net.Mail.MailMessage();
            newEmail.To.Add("elvistry@gmail.com");
            newEmail.From = new MailAddress(email, name, System.Text.Encoding.UTF8);
            newEmail.Subject = "Curriculum";
            newEmail.SubjectEncoding = System.Text.Encoding.UTF8;
            newEmail.Body = message;
            newEmail.BodyEncoding = System.Text.Encoding.UTF8;
            newEmail.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(email, password);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; 
            try
            {
                client.Send(newEmail);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            return View();
        }

        public ActionResult Recommendations()
        {
            List<Recommendation> recommendations = db.Recommendations.ToList();
            ViewBag.recommendations = recommendations;
            return View();
        }

        public ActionResult Recommend()
        {
            List<Recommendation> recommendations = db.Recommendations.ToList();
            ViewBag.recommendations = recommendations;
            return View();
        }

        [HttpPost]
        public ActionResult Recommend(string name = "", int phone = 0, string email = "", string recomendation1 = "")
        {
            Recommendation newRecommendation = new Recommendation();
            newRecommendation.Name = name;
            newRecommendation.Phone = phone;
            newRecommendation.Email = email;
            newRecommendation.Recomendation1 = recomendation1;
            if (ModelState.IsValid)
            {
                db.Recommendations.Add(newRecommendation);
                db.SaveChanges();
                return RedirectToAction("Recommendations");
            }
            return View();
        }
    }
}
