namespace _13lab
{
    class Application
    {
        private string _developer;
        private int _version;
        private int _year;

        public Application(string developer, int version, int year)
        {
            _developer = developer;
            _version = version;
            _year = year;
        }

        public void PrintDeveloper()
        {
            Console.WriteLine(_developer);
        }

        virtual internal protected void PrintAll()
        {
            Console.WriteLine($"Developer {_developer}");
            Console.WriteLine($"Version {_version}");
            Console.WriteLine($"Year {_year}");
        }
    }
    static class Program
    {
        static void Main()
        {

            GameApp gameApp = new GameApp("Horror", 21, true, "1C", 23, 2004);
            gameApp.PrintDeveloper();
            gameApp.PrintGenre();

            // Sience application

            SienceApp sienceApp = new SienceApp("Math", 23, false, "Ashan", 23, 2014);
            sienceApp.PrintAll();
     
        }
    }
}