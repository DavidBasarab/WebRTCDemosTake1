using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace WebRTCDemosTake1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Caller()
        {
            return View();
        }

        public ActionResult Callee()
        {            
            return View();
        }
    }
}