using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LAPublicHealthWebscraper.Helpers;

namespace LAPublicHealthWebscraper.Controllers
{
    public class HomeController : Controller
    {
        private const string _url = "http://publichealth.lacounty.gov/phcommon/public/media/mediapubhpdetail.cfm?prid=2300";

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //var client = new HttpClient();
            //var html = await client.GetStringAsync(_url);
            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);

            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(_url);

            var htmlDoc = await WebScraper.GetHtmlAsync(_url);

            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
            var cityParaList = htmlBody.Descendants("p").Where( p => p.InnerText.ToLower().Contains("city / community"));
            
            htmlBody.SelectSingleNode(cityParaList.ToString());

                //.Where( p => p.Element("b").InnerHtml.ToLower().Contains("city"));

            ViewBag.testHtml = htmlDoc.DocumentNode.InnerHtml;
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
    }
}