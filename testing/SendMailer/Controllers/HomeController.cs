using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendMailer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Result = "";
            System.Net.Mail.MailMessage objMensaje = new System.Net.Mail.MailMessage();
            objMensaje.Subject = "Hola";
            objMensaje.To.Clear();
            ViewBag.Title=Result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}