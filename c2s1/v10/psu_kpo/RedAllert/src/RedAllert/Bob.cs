using System.Media;

namespace RedAllert
{
    public class Bob : ALifeUnit
    {
        public Image Sprite = Image.FromFile("../../../resources/characters.png");
        private World _world;

        public Bob(int x, int y, int width, int height, Game form, World world, int health, int attack,int score, string name = "Bob") :
            base(x, y, width, height, form, health, attack,score, name)
        {
            _world = world;
            world.SetToTile(this);
            var p = Directory.GetCurrentDirectory();

        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Sprite, new Point(X * Width, Y * Height)); 
        }

        public override void BattleDraw(Graphics graphics)
        {
            graphics.DrawImage(Sprite, X * Width, Y * Height);
        }

        public override void Update()
        {
            _world.MoveToNextTile(this);
            var random = new Random();
            var cube = random.Next(1, 10);
            switch (cube)
            {
                case 1:
                    if (Attack > 0)
                    {
                        Attack -= 1;
                        new DebufWindow("О нет... Вы утомились. Ваша атака понижается на 1 ед.");
                    }
                    break;
                case 2:
                    Attack += 1;
                    new DebufWindow("Вы нашли странное зелье. Ваша атака повышается на 1 ед.");
                    break;
                case 3:
                    Health += 1;
                    new DebufWindow("Вы нашли исцеляющий свиток. Ваше здоровье повышается на 1 ед.");
                    break;
                case 4:
                    if (Health > 1)
                    {
                        Health -= 1;
                        new DebufWindow("О нет... Сзади на вас напала мышь. Ваше здоровье падает на 1 ед.");
                    }
                    break;
                case 5:
                    if ((Health == 1 && this.Attack < 2) || (this.Health < 4 && this.Attack == 0))
                    {
                        Health = 1;
                        Attack = 10;
                        new DebufWindow("Вы выпили бутылочку воды.");
                    }
                    break;
                case 6:
                    new DebufWindow("Rat wants to kill you");
                    var battleWindow = new BattleWindow();
                    battleWindow.AddUnits(this, new Rat(0, 0, 0, 0, Form, 0, 0, 0, "Nafanya"));
                    break;
            }

            if (Health <= 0)
            {
                new DebufWindow("You died");
                Application.Exit();
            }    
        }
    }
}
