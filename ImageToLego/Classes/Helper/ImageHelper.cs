using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Helper
{
  class ImageHelper
  {
    /// <summary>
    /// this method iterates through the pixels of an image and returns a 2D array of 
    /// colours
    /// </summary>
    /// <param name="path">the path of the image</param>
    /// <returns>a 2D array of colours</returns>
    public static Color[,] IterateImageByPixel(string path)
    {
      Bitmap bmp = new Bitmap( Image.FromFile(path) );

      Color[,] result = new Color[bmp.Width, bmp.Height];

      for (int x = 0; x < bmp.Width; x++)
        for (int y = 0; y < bmp.Height; y++)
          result[x, y] = bmp.GetPixel(x, y);

      return result;
    }
  }
}
