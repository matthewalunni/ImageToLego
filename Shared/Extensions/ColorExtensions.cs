using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Extensions
{
    public static class ColorExtensions
    {
        public static bool IsSimilar(this Color original, Color toBeCompared, int threshold)
        {
            int r = (int)original.R - toBeCompared.R,
            g = (int)original.G - toBeCompared.G,
            b = (int)original.B - toBeCompared.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public static Color ClosestColor(this Color original, List<Color> colors)
        {
            Color closest = Color.Empty;

            foreach (Color a in colors)
            {
                if (a.ColorDiff(original) <= closest.ColorDiff(original))
                {
                    closest = a;
                }
            }

            return closest;
        }


        // distance in RGB space
        private static int ColorDiff(this Color color1, Color colour2)
        {
            return (int)Math.Sqrt((color1.R - colour2.R) * (color1.R - colour2.R)
                                   + (color1.G - colour2.G) * (color1.G - colour2.G)
                                   + (color1.B - colour2.B) * (color1.B - colour2.B));
        }

    }
}
