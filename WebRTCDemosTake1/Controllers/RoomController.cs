using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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
            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore                
            };

            var stringwriter = new StringWriter();
            using (var writer = new JsonTextWriter(stringwriter))
            {
                writer.QuoteName = false;
                serializer.Serialize(writer, GetIceServers().IceServers);
            }

            ViewBag.IceServers = stringwriter.ToString();
            return View();
        }

        private Token GetIceServers()
        {
            TwilioRestClient client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);
            return client.CreateToken();
        }

    }
}