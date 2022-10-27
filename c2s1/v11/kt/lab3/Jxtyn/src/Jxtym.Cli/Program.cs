using Jxtym.Parser;
using sly.lexer;
using sly.parser.generator;
using sly.parser.generator.visitor;

namespace Jxtym.Cli 
{
    internal static class Program
    {
        private static void TestIndentedLang()
        {
            const string source = @"
a := _25a_
b := _34_
if a == _2_ then
    a := _13_
    if b == _3b_ then 
        a := _a_
    else 
        c := _22_ 
else
    a := _34_

c := _2_
";
            Console.WriteLine("********************");
            Console.WriteLine(source);
            Console.WriteLine("********************");

            IndentedTest1(source);
        }

        private static void IndentedTest1(string source)
        {
            var lexRes = LexerBuilder.BuildLexer<IndentedLangLexer>();
            if (lexRes.IsOk)
            {
                var x = lexRes.Result.Tokenize(source);
                if (x.IsError)
                {
                    Console.WriteLine(x.Error.ErrorMessage);
                }
            }
            else
            {
                lexRes.Errors.ForEach(x => Console.WriteLine(x.Message));
            }

            ParserBuilder<IndentedLangLexer, Ast> builder = new ParserBuilder<IndentedLangLexer, Ast>();
            var instance = new IndentedParser();
            var parserRes = builder.BuildParser(instance, ParserType.EBNF_LL_RECURSIVE_DESCENT, "root");

            if (parserRes.IsOk)
            {
                var res = parserRes.Result.Parse(source);
                var tree = res.SyntaxTree;
                var graphviz = new GraphVizEBNFSyntaxTreeVisitor<IndentedLangLexer>();
                var root = graphviz.VisitTree(tree);
                var graph = graphviz.Graph.Compile();
                File.Delete("tree.dot");
                File.AppendAllText("tree.dot", graph);

                if (!res.IsOk)
                {
                    res.Errors.ForEach(x => Console.WriteLine(x.ErrorMessage));
                }
            }
            else
            {
                parserRes.Errors.ForEach(x => Console.WriteLine(x.Message));
            }
        }

        private static void Main()
        {
            TestIndentedLang();
        }
    }
}