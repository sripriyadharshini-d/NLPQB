using edu.stanford.nlp.ling;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryProcessorEngine
{
    class POSTagger
    {
        public List<Token> TagPartsOfSpeech(string text)
        {
            var appConfig = new AppSettingsReader();
            var jarRootPath = appConfig.GetValue("POSjarRootPath", typeof(string)).ToString();
            var modelsDirectory = jarRootPath + @"\models";
            var taggerPath = appConfig.GetValue("taggerDirectoryPath", typeof(string)).ToString();
            // Loading POS Tagger
            var tagger = new MaxentTagger(modelsDirectory + taggerPath);
            var tokenList = new List<Token>();
            var sentences = MaxentTagger.tokenizeText(new StringReader(text)).toArray();
            foreach (java.util.ArrayList sentence in sentences)
            {
                var taggedSentence = tagger.tagSentence(sentence);
                var taggedtokens = SentenceUtils.listToString(taggedSentence, false);
                var newTokenList = new Tokenizer().Tokenize(taggedtokens);
                var stopItems = newTokenList.Where(x => x.Value == "/").ToList();
                foreach (var stopItem in stopItems)
                {
                    var POSTag = newTokenList.Where(x => x.Column > stopItem.Column).FirstOrDefault();
                    var actualValueToken = newTokenList.Where(x => x.Column < stopItem.Column).LastOrDefault();
                    actualValueToken.POSTag = POSTag.Value;
                    newTokenList.Remove(stopItem);
                }

                var posTagItems = newTokenList.Where(x => string.IsNullOrEmpty(x.POSTag)).ToList();
                foreach (var posTagItem in posTagItems)
                {
                    newTokenList.Remove(posTagItem);
                }
                tokenList = tokenList.Concat(newTokenList).ToList();
            }
            return tokenList;
        }
    }
}
