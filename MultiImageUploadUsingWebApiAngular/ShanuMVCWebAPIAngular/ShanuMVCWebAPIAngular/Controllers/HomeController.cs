using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShanuMVCWebAPIAngular.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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


        [HttpPost]
        public JsonResult UploadFile()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            
            if (Request.Files != null)
            {
                

                    HttpPostedFileBase file = Request.Files[0];
                    fileName = Path.GetFileName(file.FileName);
                    try
                    {

                        file.SaveAs(Path.Combine("C:\\Users\\prince\\Downloads\\ShanuMVCWebAPIAngular\\ShanuMVCWebAPIAngular\\Images", fileName));
                        Message = "File uploaded";
                        flag = true;
                    }
                    catch (Exception)
                    {
                        Message = "File upload failed! Please try again";
                    }

                
                //var file = Request.Files[0];


            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }
    }
}