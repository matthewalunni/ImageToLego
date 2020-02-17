using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaletteNormalizer.Shared
{
  public static class ColorExtensions
  {
    public static ColorTuple ClosestColor(this Color original, Dictionary<string, Color> palette)
    {
      // Middle of the color range yields significantly better results as a default.
      ColorTuple closest = new ColorTuple("Blank", Color.FromArgb(255, 128, 128, 128));

      foreach( string key in palette.Keys)
      {
        if (palette[key].ColorDiff(original) <= closest.ColorValue.ColorDiff(original))
        {
          closest.Name = key;
          closest.ColorValue = palette[key];
        }
      }

      return closest;
    }

    public static Color ClosestColor(this Color original, List<Color> colors)
    {
      Color closest = Color.Empty;

      foreach (Color color in colors)
        if (color.ColorDiff(original) <= closest.ColorDiff(original))
          closest = color;

      return closest;
    }


    // distance in RGB space
    private static int ColorDiff(this Color c1, Color c2)
    {
      double R = Math.Pow((c1.R - c2.R), 2.0);
      double G = Math.Pow((c1.G - c2.G), 2.0);
      double B = Math.Pow((c1.B - c2.B), 2.0);

      return (int)Math.Sqrt(R + G + B);
    }
  }
}
