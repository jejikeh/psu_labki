using sly.lexer;

namespace Jxtym.Parser;

public enum ExpressionToken
{
    [Lexeme("[0-9]+")]
    Int,
    [Lexeme("\\+")]
    Plus,
    [Lexeme("[ \\t]+", isSkippable: true)]
    Whitespace
}