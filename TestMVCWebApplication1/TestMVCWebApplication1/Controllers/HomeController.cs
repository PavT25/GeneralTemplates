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
            var result = new
            {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToLongTimeString(),
                Data = "AAAA"
            };

            return Json(result, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TestAction2(string inputData)
        {
            var result = new
            {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToLongTimeString(),
                Data = inputData
            };

            return Json(result, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TestAction3(string strData, int intData)
        {
            var result = new
            {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToLongTimeString(),
                Input = new { StringData = strData, IntData = intData },
                Active = true
            };

            return Json(result, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }





    }
}