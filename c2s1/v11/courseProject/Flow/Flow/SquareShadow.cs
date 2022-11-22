using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow
{
    internal class SquareShadow : Square
    {
        protected new Color GameObjectColor;
        private Point _shadowOffset;

        private GameObject parentGameObject;

        public SquareShadow(GameObject gameObject, Point offset) : base(gameObject)
        {
            _shadowOffset = offset;

            GameObjectColor = Color.FromArgb(50,0,0,0);
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);

            parentGameObject = gameObject;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(GameObjectSolidBrush, new Rectangle((parentGameObject.X * Width) + _shadowOffset.X , (parentGameObject.Y * Height) + _shadowOffset.Y, Width, Height));
        }
    }
}
