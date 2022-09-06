using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabL
{
    class Tokenizer
    {
        private int _cursor;
        private readonly string _text;

        public Tokenizer(string text)
        {
            _text = text;
            _cursor = 0;
        }

        public Token? NextToken()
        {
            try
            {
                if (_cursor >= _text.Length) return null;

                string slice = _text.Substring(_cursor);
                foreach (var rule in Specification.RegularExpressionRules)
                {
                    var matched = rule.Key.Match(slice);
                    if (matched.Success)
                    {
                        _cursor += matched.Value.Length;

                        if (rule.Value == null) return NextToken();

                        return new Token((Specification.TokenType)rule.Value, matched.Value);
                    }
                }
                throw new ArgumentException($"Unexpected token \"{slice[0]}\"");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            throw new ArgumentException($"Unexpected token");
        }
    }
}
