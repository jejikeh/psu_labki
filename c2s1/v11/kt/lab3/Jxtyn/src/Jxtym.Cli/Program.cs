
namespace Jxtym.Cli;
public static class Program
{
    private static void Main()
    {
        var expression = "2 + 2";
        
        var parser = Parser.Jxtym.GetParser();
        var r = parser.Parse(expression);
        
        if (!r.IsError) 
        {
            Console.WriteLine($"result of <{expression}>  is {(int)r.Result}");
            // outputs : result of <42 + 42>  is 84"
        }
        else
        {
            if (r.Errors !=null && r.Errors.Any())
            {
                // display errors
                r.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
            }
        }
    }
}