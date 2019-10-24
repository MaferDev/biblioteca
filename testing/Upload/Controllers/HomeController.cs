using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadImage(HttpPostedFileBase fileUpload , string rutafile ,string ticket)
        {
            string path = "@";
            string nameFileSave = "";
            try
            {
                path = Server.MapPath(path+ConfigurationManager.AppSettings["DirFileImg"]+ rutafile);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                nameFileSave = "BIOPSIA_" + ticket + ConfigurationManager.AppSettings["TypeFileImg"];
                fileUpload.SaveAs(path + nameFileSave);
            }
            catch (Exception e)
            {
                return Json(new { state = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { state = true, Message = path + nameFileSave }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetValue(FormCollection data)
        {
            return Json(new { name = "Fernanda" , Value = data["id"] });
        }
    }
}