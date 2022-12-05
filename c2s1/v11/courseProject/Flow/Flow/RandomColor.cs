namespace Flow
{
    internal class RandomColor
    {
        public static Color Next()
        {
            var random = new Random();
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public static Color NextAlpha(int transparent)
        {
            var random = new Random();
            return Color.FromArgb(transparent,random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
