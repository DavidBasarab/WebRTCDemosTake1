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
        public ActionResult Bob()
        {
            return View();
        }

        public ActionResult Alice()
        {            
            return View();
        }
    }
}