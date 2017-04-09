using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace QueryProcessorEngine
{
    public class QueryProcessor
    {
        public string Process(string text)
        {
            var tokenList = new POSTagger().TagPartsOfSpeech(text);
            new NamedEntityRecognizer().RecoginizeNamedEntites(tokenList);
            var sqlQueryOutput = new SqlStringFormatter().FormatTokensIntoSqlQuery(tokenList, "AdventureWorks");
            var dataOutput = new SqlDAL().GetDatabaseValues(sqlQueryOutput, "AdventureWorks");
            var JSONOutput = JsonConvert.SerializeObject(dataOutput);
            return JSONOutput;
        }
    }
}
