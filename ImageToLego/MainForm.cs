using ImageToLego.Classes;
using ImageToLego.Extensions;
using ImageToLego.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private int threshold = 80;
        private int lastClickedRow;
        private Panel[,] output;
        private LegoPiece[,] individualPieces;
        private bool first = true;
        #endregion globals

        public MainForm()
        {
            InitializeComponent();
            panel1.BackColor = Color.Black;
            tbCSVPath.Text = "C:\\Users\\matth\\Documents\\Projects\\C#\\ImageToLego\\colours.csv";
            CSVPath = tbCSVPath.Text;
            FormHelper.AddDataGridViewHeaders(dgvOutput, "Color", "Size");
        }

        #region listeners



        private void DynamicPanel_Click(object sender, EventArgs e)
        {
            int x, y;
            CustomPanel clicked = (CustomPanel)sender;
            x = clicked.x;
            y = clicked.y;
            Color[] aRow = img.Row(y);
            if (first)
            {
                GreyOutRow(output.Row(y));
                lastClickedRow = y;
                first = false;
            }
            else
            {
                UnGreyRow(output.Row(lastClickedRow));
                GreyOutRow(output.Row(y));
                lastClickedRow = y;
            }
            
           
            int size = 1; // minumum size
            List<LegoPiece> pieces = new List<LegoPiece>();
            LegoPiece piece;
            for (int i = 0; i < aRow.Length; i++)
            {
                if (i + 1 < aRow.Length)
                {
                    if (aRow[i].ClosestColor(palette.Values.ToList()).Equals(aRow[i + 1].ClosestColor(palette.Values.ToList())))
                    {
                        size++;
                    }
                    else
                    {
                        piece = new LegoPiece(aRow[i].ClosestColor(palette.Values.ToList()), size);
                        pieces.Add(piece);
                        size = 1;
                    }
                }
                else if (size >= aRow.Length)
                {
                    piece = new LegoPiece(aRow[i].ClosestColor(palette.Values.ToList()), size);
                    pieces.Add(piece);
                }
                else
                {
                    //last piece in row
                    piece = new LegoPiece(aRow[i].ClosestColor(palette.Values.ToList()), size);
                    pieces.Add(piece);
                    break;
                }
            }

            SetUpDataGridView(pieces);
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            first = true;
            string filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
                "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            imagePath = FormHelper.FileUploadPrompt(filter);
            tbImagePath.Text = imagePath;

            if (FormHelper.ControlsAreFilled(tbCSVPath, tbImagePath))
            {
                img = ImageHelper.IterateImageByPixel(imagePath);
                palette = new PaletteProcessor(CSVPath).ColorPalette;
                AdjustColors();
                DisplayGrid(img, panel1);
            }
            else
            {
                MessageBox.Show("Make sure all of the required form components are filled!");
            }
        }

        private void BtnColorPalette_Click(object sender, EventArgs e)
        {
            string filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            CSVPath = FormHelper.FileUploadPrompt(filter);
            tbCSVPath.Text = CSVPath;
        }

        #endregion listeners

        #region helper methods
        /// <summary>
        /// this method takes a greyed out row and reverts it to its original colour
        /// </summary>
        /// <param name="row">row of panels</param>
        private void UnGreyRow(Panel[] row)
        {
            foreach (var panel in row)
            {
                panel.BackColor = Color.FromArgb(panel.BackColor.R * 2, panel.BackColor.G * 2, panel.BackColor.B * 2);
            }
        }


        /// <summary>
        /// this method greys out a row of panels
        /// </summary>
        /// <param name="row">row of panels</param>
        private void GreyOutRow(Panel[] row)
        {
            foreach (var panel in row)
            {
                panel.BackColor = Color.FromArgb(panel.BackColor.R/2, panel.BackColor.G / 2, panel.BackColor.B / 2);
                //grey out colour here
            }
        }


        /// <summary>
        /// this method sets up the datagridview and populates it
        /// </summary>
        private void SetUpDataGridView(List<LegoPiece> pieces)
        {
            dgvOutput.Rows.Clear();
            dgvOutput.Refresh();
            foreach (var legopiece in pieces)
            {
                string colorName = palette.FirstOrDefault(x => x.Value == legopiece.color).Key;
                dgvOutput.Rows.Add(colorName, legopiece.size.ToString());
            };
        }

        /// <summary>
        /// this method adjusts the image so that it is only made up of known colors
        /// </summary>
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

        /// <summary>
        /// this method displays the altered image onto the panel
        /// </summary>
        /// <param name="clr">2D array of colors (also the image)</param>
        /// <param name="placeholder">panel placeholder for the image to go on</param>
        /// <returns>an array of panels representing the image</returns>
        public Panel[,] DisplayGrid(Color[,] clr, Panel placeholder)
        {
            int tileSizeX = placeholder.Width / clr.GetLength(0);
            int tileSizeY = placeholder.Height / clr.GetLength(1);
            output = new Panel[clr.GetLength(0), clr.GetLength(1)];
            individualPieces = new LegoPiece[clr.GetLength(0), clr.GetLength(1)];
            for (int x = 0; x < clr.GetLength(0); x++)
            {
                for (int y = 0; y < clr.GetLength(1); y++)
                {
                    var newPanel = new CustomPanel(x, y)
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

        //unused
        private void PopulateDataGridView()
        {
            //to be tested but in theory this method goes through each row of a
            //array of colours and calculates how many neighbors to each pixel are and then
            //adds them to a list of pieces..........

            //now this seems to be working...
            //its buggy now but could be useful for generating totals
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

        //unused
        private LinkedList<string> LegoPieceListToCSVList(LinkedList<LegoPiece> pieces)
        {
            LinkedList<string> result = new LinkedList<string>();
            foreach (var piece in pieces)
            {
                result.AddLast(piece.ToCSVLine());
            }

            return result;
        }

        #endregion helper methods

    }
}