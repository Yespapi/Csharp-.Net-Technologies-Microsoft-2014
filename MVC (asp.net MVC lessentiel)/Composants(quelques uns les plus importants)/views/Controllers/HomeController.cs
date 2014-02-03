using Lesson05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson05.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["Title"] = "My First View";
            ViewBag.Message = "This is my first message";
            return View();
        }

        public ActionResult Greeting()
        {
            var model = new GreetingModel()
            {
                Title = "My Second View",
                Message = "This is my second message"
            };

            return View(model);

        }

    }
}
