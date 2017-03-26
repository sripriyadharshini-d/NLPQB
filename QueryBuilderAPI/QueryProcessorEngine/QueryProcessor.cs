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
            //var tokenList = new Tokenizer().Tokenize(text);
            var tokenList = new POSTagger().TagPartsOfSpeech(text);
            tokenList = new NamedEntityRecognizer().RecoginizeNamedEntites(tokenList);
            return Newtonsoft.Json.JsonConvert.SerializeObject(new { Result = text });
        }
    }
}
