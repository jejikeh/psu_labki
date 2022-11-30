using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow
{
    internal class Tail : Square
    {
        private Snake _parentSnake;
        public Snake ParentSnake => _parentSnake;

        public Tail(GameObject gameObject, Color color) : base(gameObject)
        {
            GameObjectColor = color;
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public Tail(int x, int y, int width, int height, Flow form, Color color, Snake parentSnake) : base(x, y, width, height, form)
        {
            GameObjectColor = color;
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);

            _parentSnake = parentSnake;
        }
    }
}
