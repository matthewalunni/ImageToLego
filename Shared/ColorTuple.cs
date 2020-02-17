using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaletteNormalizer.Shared
{
  public class ColorTuple
  {
    public ColorTuple( string name, Color color )
    {
      Name = name;
      ColorValue = color;
    }

    public string Name { get; set; }
    public Color ColorValue { get; set; }
  }
}
