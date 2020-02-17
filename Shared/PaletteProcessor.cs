using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PaletteNormalizer.Shared
{
  public class PaletteProcessor
  {
    public static Dictionary<string, Color> CreatePalette( string path )
    {
      Dictionary<string, Color> d = new Dictionary<string, Color>();

      using (var reader = new StreamReader(@path))
      {
        List<ColorTuple> rawList = new List<ColorTuple>();

        string line = reader.ReadLine();
        while( !String.IsNullOrEmpty(line) )
        {
          var bits = line.Split(',');

          string name = bits[0];
          int r = Convert.ToInt32(bits[1]);
          int g = Convert.ToInt32(bits[2]);
          int b = Convert.ToInt32(bits[3]);

          d.Add(name, Color.FromArgb(r, g, b) );
          line = reader.ReadLine();
        }
      }
      return d;
    }

    //TODO : Needs some work, like R,G,B weighting as opposed to a stright-up-the-middle, first stab  
    public static Dictionary<string, Color> PaletteReducer( Dictionary<string, Color> original, int paletteCount )
    {
      if (original.Keys.Count < paletteCount)
        return original;

      Dictionary<string, Color> reducedPalette = new Dictionary<string, Color>();

      // Divide the RBG space into paletteCount as a line through the middle of the space and find nearest neighbour to the that line.
      // When the nearest color is found, it must be removed from the list of eligible colors.
      int units = 255 / paletteCount;
      for( int i =0; i < paletteCount; i++ )
      {
        // Straight up the middle of the 3D color space
        Color testColor = Color.FromArgb(255, units * i, units * 1, units * i);
        ColorTuple t = testColor.ClosestColor(original);

        reducedPalette.Add(t.Name, t.ColorValue);
        original.Remove(t.Name);
      }

      return reducedPalette;
    }
  }
}
