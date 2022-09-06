using LabL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabL
{
    class Token
    {
        public Specification.TokenType TokenType { get; set; }
        public string? Value { get; set; }

        public Token(Specification.TokenType specification, string? value)
        {
            TokenType = specification;
            Value = value;
        }
    }
}
