using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Classes
{
    class LegoPiece
    {
        private string colourName;
        public Color color;
        public int size; //assuming we can only get pieces of height 1
        private int x;
        private int y;

        public LegoPiece(Color color, int size)
        {
            this.size = size;
            this.color = color;
        }

        public LegoPiece(Color color, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }


        public LegoPiece()
        {
        }

        public string ToCSVLine()
        {
            return color.ToString() + ", " + size.ToString();
        }


    }
}
