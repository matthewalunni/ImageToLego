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
    public static bool IsSimilar(this Color c1, Color c2, int threshold)
    {
      int r = c1.R - c2.R;
      int g = c1.G - c2.G;
      int b = c1.B - c2.B;

      return ( r*r + g*g + b*b ) <= threshold * threshold;
    }

    public static string PaletteName( this Color original, Dictionary<string, Color> d)
    {
      foreach( string name in d.Keys)
        if (d[name] == original)
          return name;

      return "NotFound";
    }

    public static Color ClosestColor(this Color c1, IEnumerable<Color> colors)
    {
      Color match = Color.Empty;

      foreach (Color color in colors)
        if (color.ColorDiff(c1) <= match.ColorDiff(c1))
          match = color;

      return match;
    }


    private static int ColorDiff(this Color c1, Color c2)
    {
      // Same as distance between two points in 3D space
      int r = c1.R - c2.R;
      int g = c1.G - c2.G;
      int b = c1.B - c2.B;

      return (int)Math.Sqrt(r*r + g*g + b*b);
    }
  }
}
