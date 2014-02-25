using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SwffPodcast.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            const string orignialFeedUrl = "http://www.swff.com/index.php?option=com_sermonspeaker&view=feed&format=raw";
            using (var webclient = new WebClient())
            {
                //webclient.Proxy = new WebProxy("127.0.0.1", 8888);
                webclient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1700.107 Safari/537.36");
                var rss = webclient.DownloadString(orignialFeedUrl);
                rss = rss.TrimStart();

                return Content(rss, "text/xml");
            }
        }

    }
}
