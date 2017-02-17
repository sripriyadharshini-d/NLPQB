using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QueryBuilderAPI.Models;
using System.Text;
using QueryProcessorEngine;
using QueryBuilderAPI.Models.Helper;

namespace QueryBuilderAPI.Controllers
{
    public class SearchController : BaseController
    {
        [HttpPost]
        public HttpResponseMessage Process(SearchModel searchModel)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var content = new QueryProcessor().Process(searchModel.SearchText);
            response.Content = new JsonContent(content);
            return response;
        }
    }

}
