using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Xamarin_API.Controllers
{
    [Authorize]
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string date = DateTime.Now.ToShortDateString();
            string username = User.Identity.Name;
            string text = "Tekst wyslano z api";


            return new string[] { username, date, text };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "penis";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
