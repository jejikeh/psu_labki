namespace Flow
{
    internal class PlayerSnake : Snake
    {
        public PlayerSnake(int x, int y, int width, int height, Flow form) : base(x, y, width, height, form)
        {
            GameObjectColor = RandomColor.Next();
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public PlayerSnake(int x, int y, int width, int height, Flow form, Snake parentSnake, List<Tail>? tail) : base(x, y, width, height, form, parentSnake, tail)
        {
            GameObjectColor = RandomColor.Next();
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }


        public override void Update()
        {
            base.Update();
            switch (BelongForm.directions)
            {
                case "left":
                    X--;
                    break;
                case "right":
                    X++;
                    break;
                case "up":
                    Y--;
                    break;
                case "down":
                    Y++;
                    break;
            }

        }

        public override void ToDoOnEatBio()
        {
            base.ToDoOnEatBio();
            BelongForm.AddScore();
        }

        protected override void OnDie()
        {
        }
    }
}