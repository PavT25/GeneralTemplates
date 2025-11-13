using System;
using System.Web.Mvc;

namespace TestMVCWebApplication1.Controllers
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

        [HttpGet]
        public JsonResult TestAction()
        {
            return Json(new { date = DateTime.Now.ToLongDateString(),  time = DateTime.Now.ToLongTimeString(), Data = "AAAA" }, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TestAction2(string inputData)
        {
            return Json(new { date = DateTime.Now.ToLongDateString(), time = DateTime.Now.ToLongTimeString(), Data = inputData }, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }





    }
}