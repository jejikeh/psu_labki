namespace Jxtym.Parser
{
    public class Set<T> : Statement where T : Ast
    {
        public Identifier Id { get; set; }
        
        public T Value { get; set; }
        
        public string Comment { get; set; }

        public Set(Identifier id, T newValue)
        {
            Id = id;
            Value = newValue;
        }
        
        public string Dump(string tab)
        {
            return $"{tab}{Id.Dump(tab)} = {Value.Dump(tab)}";
        }
    }
}