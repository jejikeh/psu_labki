using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
            {
                X = 60;
            }
            if (X > 60)
            {
                X = 0;

            }
            if (Y < 1)
            {
                Y = 36;

            }
            if (Y > 36)
            {
                Y = 1;

            }

            graphics.FillRectangle(GameObjectSolidBrush, new Rectangle(X * Width, Y * Height, Width, Height));
        }
    }
}
