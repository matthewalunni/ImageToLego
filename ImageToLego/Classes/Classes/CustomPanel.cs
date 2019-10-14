using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToLego.Classes
{
  public class CustomPanel : Panel
  {
    public int x, y;
    public CustomPanel(int X, int Y)
    {
      x = X;
      y = Y;
    }
  }
}
