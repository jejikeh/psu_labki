using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RedAllert
{
    public class Tile : GameObject
    {
        private SolidBrush _gameObjectSolidBrush;
        public Image Sprite = Image.FromFile("../../../resources/dirt.png");    

        public Tile(int x, int y, int width, int height, Game form,float rotation) : base(x, y, width, height, form) 
        {
            Sprite = RotateImage(Sprite, rotation);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Sprite, X * Width, Y * Height);
        }

        public override void Update() {}
    }
}
