using sly.parser.generator;
using sly.parser;

namespace Jxtym.Parser;
public static class Jxtym
{
    public static Parser<ExpressionToken, int> GetParser()
    {
        var parserInstance = new ExpressionParser();
        var builder = new ParserBuilder<ExpressionToken, int>();
        var parser = builder.BuildParser(parserInstance, ParserType.LL_RECURSIVE_DESCENT, "expression").Result;

        return parser;
    }
}