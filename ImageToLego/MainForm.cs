using ImageToLego.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToLego
{
    public partial class MainForm : Form
    {
        #region globals
        private Color[,] img;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            SetUpForm();
        }

        #region listeners
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            string imagePath = FormHelper.FileUploadPrompt();
            tbImagePath.Text = imagePath;
            if (FormHelper.ControlsAreFilled())
            {
                img = ImageHelper.IterateImageByPixel(imagePath);
                DisplayGrid(img, panel1);
            }
        }

        #endregion

        #region helper methods


        public Panel[,] DisplayGrid(Color[,] clr, Panel placeholder)
        {
            int tileSizeX = placeholder.Width / clr.GetLength(0);
            int tileSizeY = placeholder.Height / clr.GetLength(1);
            Panel[,] output = new Panel[clr.GetLength(0), clr.GetLength(1)];
            for (int x = 0; x < clr.GetLength(0); x++)
            {
                for (int y = 0; y < clr.GetLength(1); y++)
                {
                    //Control c = panel.GetControlFromPosition(x+1, y+1);
                    // c.BackColor = clr[x, y];
                    //panel.GetControlFromPosition(x, y).Click += ImageClickHandler();
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSizeX, tileSizeY),
                        Location = new Point(
                            tileSizeX * x + placeholder.Location.X, 
                            tileSizeY * y + placeholder.Location.Y
                            ),
                        BackColor = clr[x, y]
                    };

                    Controls.Add(newPanel);
                    output[x, y] = newPanel;




                }
            }
            placeholder.Visible = false;
            return output;
        }

        private void SetUpForm()
        {
            cbImageSize.Items.Add("8 x 8");
            cbImageSize.Items.Add("32 x 32");
            cbImageSize.Items.Add("64 x 64");
            cbImageSize.Items.Add("128 x 128");
            cbImageSize.Items.Add("256 x 256");
        }

        #endregion
    }
}
