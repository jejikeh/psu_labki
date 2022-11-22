using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow
{
    internal class Bio : Square
    {
        public Bio(GameObject gameObject) : base(gameObject)
        {
            GameObjectColor = Color.GreenYellow;
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public Bio(int x, int y, int width, int height, Flow form) : base(x, y, width, height, form)
        {
            GameObjectColor = Color.GreenYellow;
            GameObjectSolidBrush = new SolidBrush(GameObjectColor);
        }

        public override void Update()
        {
            base.Update();
            if(BelongForm.FlowRandom.Next(0,20) == 9)
            {
                X += BelongForm.FlowRandom.Next(-1, 1);
                Y += BelongForm.FlowRandom.Next(-1, 1);
            }

            if (GoingToDie)
            {
                GameObjectColor = Color.Red;
                GameObjectSolidBrush = new SolidBrush(GameObjectColor);
            }
        }

        public override void OnHit(GameObject gameObject)
        {
            if (gameObject is Snake)
            {
                GoingToDie = true;
            }
        }
    }
}
