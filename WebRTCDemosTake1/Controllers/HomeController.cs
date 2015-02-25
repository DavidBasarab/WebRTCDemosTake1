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
            ViewBag.IceServers = GetIceServers().IceServers;
            return View();
        }

        public ActionResult Callee()
        {
            ViewBag.IceServers = GetIceServers().IceServers;
            return View();
        }

        private Token GetIceServers()
        {
            TwilioRestClient client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            return client.CreateToken();
        }
    }
}