using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LAPublicHealthWebscraper.Helpers
{
    public static class WebScraper
    {
        public static async System.Threading.Tasks.Task<HtmlDocument> GetHtmlAsync(string url)
        {
            var client = new HttpClient();
            var html = await client.GetStringAsync(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc;
        }
    }
}