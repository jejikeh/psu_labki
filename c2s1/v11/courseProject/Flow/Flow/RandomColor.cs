using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow
{
    internal class RandomColor
    {
        public static Color Next()
        {
            var random = new Random();

            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
