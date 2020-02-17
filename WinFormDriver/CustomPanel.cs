using System;
using System.Windows.Forms;
using PaletteNormalizer.Shared;

namespace PaletteNormalizer
{
  public class CustomPanel : Panel
  {

    public CustomPanel(int x, int y, ColorTuple tuple)
    {
      X = x;
      Y = y;
      PaletteItem = tuple;
      //BackColor = tuple.ColorValue;
      BorderStyle = BorderStyle.FixedSingle;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public bool Active { get; private set; }
    public ColorTuple PaletteItem { get; private set; }

    protected override void OnClick(EventArgs e)
    {
      Active = !Active;
      base.OnClick(e);
    }
  }
}
