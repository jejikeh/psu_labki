namespace Flow
{
    internal class Square : GameObject
    {
        protected Color GameObjectColor = Color.Chocolate;
        protected SolidBrush GameObjectSolidBrush;

        public Square(GameObject gameObject) : base(gameObject)
        {
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public Square(int x, int y, int width, int height, Flow form) : base(x,y,width,height, form) 
        {
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            if (X < 0)
                X = 60;
            if (X > 60)
                X = 0;
            if (Y < 3)
                Y = 34;
            if (Y > 34)
                Y = 3;

            graphics.FillRectangle(GameObjectSolidBrush, new Rectangle(X * Width, Y * Height, Width, Height));
        }
    }
}
