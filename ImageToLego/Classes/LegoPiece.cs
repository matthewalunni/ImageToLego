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
        private Color rgbValues;
        private int size; //assuming we can only get pieces of height 1
        private int x;
        private int y;

        public LegoPiece(Color color, int size)
        {
            this.size = size;
            this.rgbValues = color;
        }

        public LegoPiece(Color color, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.rgbValues = color;
        }


        public LegoPiece()
        {
        }

        public string ToCSVLine()
        {
            return rgbValues.ToString() + ", " + size.ToString();
        }


    }
}
