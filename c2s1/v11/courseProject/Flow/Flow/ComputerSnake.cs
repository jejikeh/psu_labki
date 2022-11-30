namespace Flow
{
    internal class ComputerSnake : Snake
    {
        public GameObject Target { get; set; }
        
        public ComputerSnake(int x, int y, int width, int height, Flow form) : base(x, y, width, height, form)
        {
            Target = BelongForm.GetRandomTarget<GameObject>();
            GameObjectColor = RandomColor.Next();
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);

            var randomTailLength = BelongForm.FlowRandom.Next(0, 10);
            for (var i = 0; i < randomTailLength; i++)
                AddToTail();
        }

        public ComputerSnake(int x, int y, int width, int height, Flow form, Snake parentSnake, List<Tail>? tail) : base(x, y, width, height, form, parentSnake, tail)
        {
            Target = BelongForm.GetRandomTarget<GameObject>();
            GameObjectColor = RandomColor.Next();
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
            var randomTailLength = BelongForm.FlowRandom.Next(0, 10);
            for (var i = 0; i < randomTailLength; i++)
                AddToTail();
        }

        public override void Update()
        {
            base.Update();
            
            if(Target.X == X && Target.Y == Y || BelongForm.FlowRandom.Next(0,50) == 30)
                Target = BelongForm.GetRandomTarget<GameObject>();

            var randomChoice = BelongForm.FlowRandom.Next(1, 3);
            if (randomChoice == 1)
                MoveToTargetByX();
            if(randomChoice == 2)
                MoveToTargetByY();
        }

        private void MoveToTargetByX()
        {
            if (Target.X > X)
                X++;
            else
                X--;
        }

        private void MoveToTargetByY()
        {
            if (Target.Y > Y)
                Y++;
            else
                Y--;
        }
    }
}
