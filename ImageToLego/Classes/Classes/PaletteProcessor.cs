using ImageToLego.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Classes
{
  class PaletteProcessor
  {
    public static Dictionary<string, Color> CreatePalette(string paletteFile)
    {
      Dictionary<string, Color> palette = new Dictionary<string, Color>();

      using (var reader = new StreamReader(paletteFile))
      {
        //Skip the first/header line
        reader.ReadLine();

        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          string[] vals = line.Split(',');

          string name = vals[0];
          int r = Convert.ToInt32(vals[1]);
          int g = Convert.ToInt32(vals[2]);
          int b = Convert.ToInt32(vals[3]);

          Color clr = Color.FromArgb(r, g, b);
          palette.Add(name, clr);
        }
      }

      return palette;
    }
  }
}
