using ImageToLego.Classes;
using ImageToLego.Extensions;
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
        private Dictionary<string, Color> palette;
        private string imagePath;
        private string CSVPath;
        private int threshold = 10;
        private LegoPiece[,] individualPieces;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            panel1.BackColor = Color.Black;
            tbCSVPath.Text = "C:\\Users\\matth\\Documents\\Projects\\C#\\ImageToLego\\colours.csv";
            CSVPath = tbCSVPath.Text;
        }

        #region listeners
        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (FormHelper.ControlsAreFilled(tbCSVPath, tbImagePath))
            {
                img = ImageHelper.IterateImageByPixel(imagePath);
                palette = new PaletteProcessor(CSVPath).ColorPalette;
                AdjustColors();
                DisplayGrid(img, panel1);
                PopulateDataGridView();
            }
            else
            {
                MessageBox.Show("Make sure all of the required form components are filled!");
            }
        }

        private void DynamicPanel_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            string filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
                "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            imagePath = FormHelper.FileUploadPrompt(filter);
            tbImagePath.Text = imagePath;
            

        }

        private void BtnColorPalette_Click(object sender, EventArgs e)
        {
            string filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            CSVPath = FormHelper.FileUploadPrompt(filter);
            tbCSVPath.Text = CSVPath;

        }
        #endregion

        #region helper methods
        private void AdjustColors()
        {
            for (int i = 0; i < img.GetLength(0); i++)
            {
                for (int j = 0; j < img.GetLength(1); j++)
                {
                    img[i, j] = img[i, j].ClosestColor(palette.Values.ToList());
                }
            }
        }

        public Panel[,] DisplayGrid(Color[,] clr, Panel placeholder)
        {
            int tileSizeX = placeholder.Width / clr.GetLength(0);
            int tileSizeY = placeholder.Height / clr.GetLength(1);
            Panel[,] output = new Panel[clr.GetLength(0), clr.GetLength(1)];
            individualPieces = new LegoPiece[clr.GetLength(0), clr.GetLength(1)];
            for (int x = 0; x < clr.GetLength(0); x++)
            {
                for (int y = 0; y < clr.GetLength(1); y++)
                {
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSizeX, tileSizeY),
                        Location = new Point(
                            tileSizeX * x + placeholder.Location.X,
                            tileSizeY * y + placeholder.Location.Y
                            ),
                        BackColor = clr[x, y],
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    newPanel.Click += DynamicPanel_Click;

                    Controls.Add(newPanel);
                    output[x, y] = newPanel;

                    LegoPiece lp = new LegoPiece(clr[x, y], x, y);
                    individualPieces[x, y] = lp;

                }
            }
            placeholder.Visible = false;
            return output;
        }

        private void PopulateDataGridView()
        {

            //to be tested but in theory this method goes through each row of a 
            //array of colours and calculates how many neighbors to each pixel are and then
            //adds them to a list of pieces..........
            

            //now this seems to be working...
            LinkedList<LegoPiece> pieces = new LinkedList<LegoPiece>();
            for (int i = 0; i < img.GetLength(0); i++)
            {
                LegoPiece aLegoPiece = new LegoPiece();
                int rightNeighborCount = 0;
                for (int j = 0; j < img.GetLength(1); j++)
                {
                    if (img[i, j].IsSimilar(img[i, j + 1], threshold))
                    {
                        rightNeighborCount++;
                    }
                    else
                    {
                        aLegoPiece = new LegoPiece(img[i, j], rightNeighborCount);
                        
                        break;
                    }
                }
                pieces.AddLast(aLegoPiece);
            }

            LinkedList<string> csvLegoPieces = LegoPieceListToCSVList(pieces);
            DataTable dt = TypeCoversions.ToDataTable(csvLegoPieces, ",");
            dgvOutput.DataSource = dt;
            //print list of lego pieces nicely into a datagrid view, then isolate this nightmare of
            //logic that went on above

        }

        private LinkedList<string> LegoPieceListToCSVList(LinkedList<LegoPiece> pieces)
        {
            LinkedList<string> result = new LinkedList<string>();
            foreach (var piece in pieces)
            {
                result.AddLast(piece.ToCSVLine());
            }

            return result;
        }
        

        #endregion


    }
}
