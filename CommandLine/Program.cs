using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using PaletteNormalizer.Shared;

namespace PaletteNormalizer
{
  class CommandLineDriver
  {
    //TODO : Add commandline args handling
    static void Main(string[] args)
    {
      /*
       * 1. Open the palette and create a dictionary of name, color
       * 2. Open image and iterate over all pixels, across columns, then rows
       * 3. For each pixel, resolve into nearest color from palette and add to the order sheet
       * NOTE : Transparent pixels don't enter into the count
       */

      string srcImage = "test.png";
      string srcPalette = "colours.csv";
      string outImage = "paletteAdjusted.png";

      Dictionary<string, Color> palette = PaletteProcessor.CreatePalette(srcPalette);
      Dictionary<string, int> orderSheet = new Dictionary<string, int>();

      using (Bitmap src = new Bitmap(srcImage))
      {
        using (Bitmap tar = new Bitmap(src.Width, src.Height))
        {
          for (int x = 0; x < src.Width; x++)
          {
            for (int y = 0; y < src.Height; y++)
            {
              Color color = src.GetPixel(x, y);

              // Skip transparent
              if (color.A == 0)
                tar.SetPixel(x, y, color);
              else
              {
                ColorTuple tup = color.ClosestColor(palette);

                if (!orderSheet.ContainsKey(tup.Name))
                  orderSheet.Add(tup.Name, 1);
                else
                  orderSheet[tup.Name]++;

                tar.SetPixel(x, y, tup.ColorValue);
              }
            }
          }

          //Dump the ordersheet
          StringBuilder sb = new StringBuilder();
          foreach( string name in orderSheet.Keys)
            sb.AppendFormat("{0}: {1}\r\n", name, orderSheet[name]);

          File.WriteAllText("OrderSheet.txt", sb.ToString());
          tar.Save(outImage, src.RawFormat);
        }
      }
    }
  }
}
