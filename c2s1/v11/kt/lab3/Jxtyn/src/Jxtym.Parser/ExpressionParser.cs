using sly.lexer;
using sly.parser.generator;

namespace Jxtym.Parser;

public class ExpressionParser
{
    [Production("expression: Int")]
    public int IntExpr(Token<ExpressionToken> intToken)
    {
        return intToken.IntValue;
    }

    [Production("expression: term Plus expression")]
    public int Expression(int left, Token<ExpressionToken> operatorToken, int right) {
        return left + right;
    }

    [Production("term: Int")]
    public int Expression(Token<ExpressionToken> intToken) {
        return intToken.IntValue;
    }
}