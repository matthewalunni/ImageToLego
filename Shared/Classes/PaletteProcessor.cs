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
  public class PaletteProcessor
  {
    public Dictionary<string, Color> ColorPalette;

    public PaletteProcessor(string path)
    {
      ColorPalette = ToColorPalette(CSVTools.Process(path));
    }

    private Dictionary<string, Color> ToColorPalette(List<List<string>> csv)
    {
      //starting at 1 to ignore headers
      Dictionary<string, Color> result = new Dictionary<string, Color>();

      for (int i = 1; i < csv.Count(); i++)
      {
        string name = csv.ElementAt(i).ElementAt(0);
        int r = Convert.ToInt32(csv.ElementAt(i).ElementAt(1));
        int g = Convert.ToInt32(csv.ElementAt(i).ElementAt(2));
        int b = Convert.ToInt32(csv.ElementAt(i).ElementAt(3));

        Color clr = Color.FromArgb(r, g, b);
        result.Add(name, clr);
      }
      return result;
    }
  }
}
