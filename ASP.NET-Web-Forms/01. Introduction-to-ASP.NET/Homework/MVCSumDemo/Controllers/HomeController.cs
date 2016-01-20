using MVCSumDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSumDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new SumResponceModel();
            model.X = 0;
            model.Y = 0;
            model.Result = "0";

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SumRequestModel message)
        {
            var model = new SumResponceModel();
            model.X = 0;
            model.Y = 0;
            model.Result = "0";

            double x;
            double y;

            if(!double.TryParse(message.xNumber, out x))
            {
                model.Result = "invalid x";

                return View(model);
            }

            if (!double.TryParse(message.yNumber, out y))
            {
                model.Result = "invalid y";

                return View(model);
            }

            model.X = x;
            model.Y = y;
            model.Result = (x + y).ToString();

            return View(model);
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