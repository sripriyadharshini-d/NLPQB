using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace QueryBuilderAPI.Models.Helper
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content)
            : this(content, Encoding.UTF8)
        {
        }

        public JsonContent(string content, Encoding encoding)
            : base(content, encoding, "application/json")
        {
        }
    }
}