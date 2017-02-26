using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using edu.stanford.nlp.ie.crf;
using System.Xml.Linq;
using System.Xml;

namespace QueryProcessorEngine
{
    class NamedEntityRecognizer
    {
        public List<Token> RecoginizeNamedEntites(List<Token> tokenList)
        {
            var appConfig = new AppSettingsReader();
            var jarRootPath = appConfig.GetValue("NERjarRootPath", typeof(string)).ToString();
            var classifiersDirectory = jarRootPath + @"\classifiers";
            var engClassifierPath = appConfig.GetValue("classifierDirectoryPath", typeof(string)).ToString();
            var classifier = CRFClassifier.getClassifierNoExceptions(classifiersDirectory + engClassifierPath);
            foreach(var token in tokenList.Where(x => x.Kind == "Word"))
            {
                var recognizedOutput = classifier.classifyWithInlineXML(token.Value);
                try
                {
                    var xmlOutput = XDocument.Parse(recognizedOutput);
                    var typeName = (from x in xmlOutput.Descendants()
                                  select x.Name).First().LocalName;
                    token.Kind = typeName;
                }
                catch(XmlException ex)
                {
                    //do nothing. This is to filter normal word kind of tokens which are not named entities
                }
            }
            return tokenList;
        }
    }
}
