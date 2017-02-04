using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QueryBuilderAPI.Models;

namespace QueryBuilderAPI.Controllers
{
    public class NLPQuerySearchController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Search(NLPQuerySearch searchIns)
        {
            //TODO: To allow users to save the query like JIRA query.
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
        }
    }
}
