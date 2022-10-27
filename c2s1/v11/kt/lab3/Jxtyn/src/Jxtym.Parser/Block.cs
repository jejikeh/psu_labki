using System.Collections.Generic;
using System.Text;

namespace Jxtym.Parser
{
    public class Block : Statement
    {
        public List<Ast> Statements { get; set; } = new List<Ast>();
        
        public string Comment { get; set; }

        public Block(List<Ast> stats)
        {
            Statements = stats;
            
            stats.ForEach(x=>Console.Write(x.Dump("")));
        }

        public string Dump(string tab)
        {
            StringBuilder builder = new StringBuilder();
            var newTab = tab + "\t";
            foreach (var statement in Statements)
            {
                builder.AppendLine(statement.Dump(newTab));
            }

            return builder.ToString();
        }
    }
}