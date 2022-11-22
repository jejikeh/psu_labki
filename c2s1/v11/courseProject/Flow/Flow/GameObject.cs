using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow
{
    public abstract class GameObject
    {
        protected Flow BelongForm;
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool GoingToDie { get; set; }


        private SquareShadow _shadow;


        public GameObject(GameObject gameObject)
        {
            GoingToDie = false;
            X = gameObject.X;
            Y = gameObject.Y;
            Width = gameObject.Width;
            Height = gameObject.Height;
            BelongForm = gameObject.BelongForm;
            
            // _shadow = new SquareShadow(this, new Point(5, 5), Color.FromArgb(100, 0, 0, 0));
        }

        public GameObject(int x, int y, int width, int height, Flow form)
        {
            GoingToDie = false;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            BelongForm = form;

            _shadow = new SquareShadow(this, new Point(5,5));
        }

        public virtual void Draw(Graphics graphics)
        {
            _shadow.Draw(graphics);
        }

        public virtual void Update() 
        {
            _shadow?.Update();
        }

        public virtual void OnHit(GameObject gameObject)
        {
            Console.WriteLine("AAA");
        }
    }
}
