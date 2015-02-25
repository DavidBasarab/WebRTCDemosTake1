using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;

namespace WebRTCDemosTake1.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {

            string json =  JsonConvert.SerializeObject(
                GetIceServers().IceServers,
                Formatting.None,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );
            
            ViewBag.IceServers = json;
            return View();
        }

        private Token GetIceServers()
        {
            TwilioRestClient client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            return client.CreateToken();
        }

    }
}