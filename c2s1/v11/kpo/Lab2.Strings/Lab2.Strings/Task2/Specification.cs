using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabL
{
    static class Specification
    {
        public enum TokenType
        {
            Number,
            Operation,
            Expression,
            Program,
        }

        internal static readonly Dictionary<Regex, TokenType?> RegularExpressionRules = new Dictionary<Regex, TokenType?>
        {
            // white spaces
            {new Regex(@"^\s+"), null},
            // digits
            {new Regex(@"^\d+"), TokenType.Number},
            // expressions
            {new Regex(@"^\([\s\S]*?\)+", RegexOptions.Multiline), TokenType.Expression},
            {new Regex(@"[+-/*]"), TokenType.Operation }

        };
    }
}
