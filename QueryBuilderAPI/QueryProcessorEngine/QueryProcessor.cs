using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryProcessorEngine
{
    public class QueryProcessor
    {
        public string Process(string text)
        {
            new Tokenizer().Tokenize(text);
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { Result = text });
        }
    }
}
