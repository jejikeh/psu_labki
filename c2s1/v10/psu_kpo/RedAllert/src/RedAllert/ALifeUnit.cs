using System.Media;

namespace RedAllert
{

    public abstract class ALifeUnit : GameObject
    {
        public string Name { get; set; }
        internal int Health { get; set; }
        internal int Attack { get; set; }
        internal int Score { get; set; }

        protected List<SoundPlayer> VoiceLines = new List<SoundPlayer>();
        public ALifeUnit(int x, int y, int width, int height, Game form, int health, int attack,int score, string name) : base(x, y, width,
            height, form)
        {
            Health = health;
            Attack = attack;
            Name = name;
            Score = score;
        }

        public abstract void BattleDraw(Graphics graphics);


    }
}