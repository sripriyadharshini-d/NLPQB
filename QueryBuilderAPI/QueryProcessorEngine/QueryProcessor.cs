using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace QueryProcessorEngine
{
    public class QueryProcessor
    {
        public string Process(string text)
        {
            //var tokenList = new Tokenizer().Tokenize(text);
            //tokenList = new NamedEntityRecognizer().RecoginizeNamedEntites(tokenList);
            //return Newtonsoft.Json.JsonConvert.SerializeObject(new { Result = text });
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=EFTrial;Integrated Security=SSPI"))
                {
                    using (SqlCommand cmd = new SqlCommand(text, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                        Dictionary<string, object> row;
                        foreach (DataRow dr in dt.Rows)
                        {
                            row = new Dictionary<string, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, dr[col]);
                            }
                            rows.Add(row);
                        }
                        return serializer.Serialize(rows);
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
