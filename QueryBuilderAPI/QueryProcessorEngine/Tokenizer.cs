using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryProcessorEngine
{
    class Tokenizer
    {
        internal List<Token> Tokenize(string text)
        {
            StringTokenizer stokenizer = new StringTokenizer(text);
            var tokenList = new List<Token>();
            do
            {
                tokenList.Add(stokenizer.Next());
            } while (tokenList.Last().Kind != "EOF");
            return tokenList;
        }
    }
}
