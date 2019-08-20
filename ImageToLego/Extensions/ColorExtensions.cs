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
        public static bool isSimilar(this Color original, Color toBeCompared, int threshold)
        {
            int r = (int)original.R - toBeCompared.R,
            g = (int)original.G - toBeCompared.G,
            b = (int)original.B - toBeCompared.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

    }
}
