using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mapall.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string url)
        {
            //get from database the original url "Full";             
            return "https://example.com/pd";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }



    }
}
