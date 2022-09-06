using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabL
{
    internal class Expression
    {
        string _expression = string.Empty;
        private Token? _lookahead;
        private Tokenizer? _tokenizer;


        public Expression(string input)
        {
            _expression = input;
            _tokenizer = new Tokenizer(_expression);
        }

        public List<Token> Parse()
        {
            List<Token> tokens = new List<Token>();
            _lookahead = _tokenizer.NextToken();
            while(_lookahead != null)
            {
                tokens.Add(_lookahead);
                _lookahead = _tokenizer.NextToken();
            }

            return tokens;
        }

        public float? Intepreter(List<Token> tokens)
        {
            float? res = null;
            for(int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine($"{tokens[i].TokenType} : {tokens[i].Value}");
                if (tokens[i].TokenType == Specification.TokenType.Expression)
                {
                    Expression expression = new Expression(tokens[i].Value.Substring(1, tokens[i].Value.Length - 2));
                    var result = expression.Parse();
                    tokens[i].Value = expression.Intepreter(result).ToString();
                }
            }

            for(int i = 0; i < tokens.Count; i++)
            {
                if(tokens[i].TokenType == Specification.TokenType.Operation)
                {
                    switch (tokens[i].Value)
                    {
                        case "+":
                            res = float.Parse(tokens[i - 1].Value) + float.Parse(tokens[i + 1].Value);
                            break;
                        case "*":
                            res = float.Parse(tokens[i - 1].Value) * float.Parse(tokens[i + 1].Value);
                            break;
                        case "-":
                            res = float.Parse(tokens[i - 1].Value) - float.Parse(tokens[i + 1].Value);
                            break;
                        case "/":
                            res = float.Parse(tokens[i - 1].Value) / float.Parse(tokens[i + 1].Value);
                            break;
                    }

                    tokens[i + 1].Value = res.ToString();
                }
            }

            return res;
        }

    }
}
