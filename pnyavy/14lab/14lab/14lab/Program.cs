namespace _14lab
{

    class Program
    {
        static private void Main()
        {
            VectorArray vectorArray = new VectorArray(3);

            vectorArray.Add(1);
            vectorArray.Add(3);
            vectorArray.Add(4);

            vectorArray.AddValueToAll(10);
            vectorArray.Print();
        }
    }
}
