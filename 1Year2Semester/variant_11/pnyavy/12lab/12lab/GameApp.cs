namespace _12lab
{
    class GameApp : Application
    {
        private string _genre;
        private int _age;
        private bool _multiplayer;

        public GameApp(string genre, int age, bool multiplayer,string developer,int version,int year) : base(developer,version,year)
        {
            _genre = genre;
            _age = age;
            _multiplayer = multiplayer;
        }

        public void PrintGenre()
        {
            Console.WriteLine(_genre);
        }
    }
}
