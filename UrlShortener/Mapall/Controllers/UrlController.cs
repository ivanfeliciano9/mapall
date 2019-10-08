using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mapall.Models;

namespace Mapall.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        //// GET api/url
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/url/5
        public string Get(string url)
        {
            MapallDBContext db = new MapallDBContext();
            string urlReturn = "";
            UrlModel urlshortener = new UrlModel();

            try
            {
                urlshortener = db.Urls.Where(x => x.Urlshortener == url).FirstOrDefault();

                if (urlshortener.Urlshortener == "")
                    throw new Exception("404 - URL Not found");
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                urlReturn = ex.Message;
            }

            if (urlshortener.Urlshortener != "")
                urlReturn = urlshortener.Urlshortener;

            return urlReturn;
        }

        // POST api/url
        public void Post([FromBody]string value)
        {
            string urlReal = "http://www.teste.com/23/234";
            string urlShort = "pd";

            MapallDBContext db = new MapallDBContext();
            UrlModel urlshortener = new UrlModel();

            urlshortener = db.Urls.Where(x => x.Urlshortener == urlReal).FirstOrDefault();

            try
            {
                if (urlshortener.Urlshortener == "")
                {
                    urlshortener.Url = urlReal;
                    urlshortener.CreateShortenerURL(urlShort);

                    db.Urls.Add(urlshortener);
                    db.SaveChanges();
                }
                else
                    throw new Exception("304 - URL já existe");

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}