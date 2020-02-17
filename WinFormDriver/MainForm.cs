using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using PaletteNormalizer.Shared;

namespace PaletteNormalizer
{
  public partial class MainForm : Form
  {
    #region Private Members
    bool hasPalette, hasImage;
    bool first = true;
    Dictionary<string, Color> palette = null;
    #endregion

    #region Constructor/Destructor
    public MainForm()
    {
      InitializeComponent();
    }

    ~MainForm()
    {
      palette = null;

      btnNewImage.Click -= NewImage_Click;
      btnNewPalette.Click -= NewPalette_Click;
      btnSave.Click -= Save_Click;
      btnUpdate.Click -= Update_Click;
    }
    #endregion

    private void NewImage_Click(object sender, EventArgs e)
    {
      string filter = ConfigurationManager.AppSettings["ImageFileSpec"];
      string path = FileUploadPrompt(filter);

      if (String.IsNullOrEmpty(path))
      {
        MessageBox.Show("A complete path might be nice");
        hasImage = false;
        return;
      }

      hasImage = true;
      picOriginal.Image = new Bitmap(path);

      if (hasPalette)
        RefreshDisplay();
      else
        if (!first)
        MessageBox.Show("Get thee a palette");
    }

    private void NewPalette_Click(object sender, EventArgs e)
    {
      string filter = ConfigurationManager.AppSettings["PaletteFileSpec"];
      string path = FileUploadPrompt(filter);

      if (String.IsNullOrEmpty(path))
      {
        MessageBox.Show("A complete path might be nice");
        hasPalette = false;
        return;
      }

      hasPalette = true;
      palette = PaletteProcessor.CreatePalette(path);

      if (hasImage)
        RefreshDisplay();
      else
        if (!first)
        MessageBox.Show("Get thee an image");
    }

    private void Update_Click(object sender, EventArgs e)
    {

    }

    private void Save_Click(object sender, EventArgs e)
    {

    }

    public static string FileUploadPrompt(string filter)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.InitialDirectory = Directory.GetCurrentDirectory();
        ofd.Filter = filter;
        ofd.Title = "Upload a File";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          try
          {
            string filePath = ofd.FileName;
            return filePath;

          }
          catch (Exception)
          {
            throw;
          }
        }
        else
        {
          return null;
        }
      }
    }

    private void RefreshDisplay()
    {
      NormalizeToPalette();
      DisplayPalette();
    }

    private void NormalizeToPalette()
    {
      using (Bitmap originalImage = new Bitmap(picOriginal.Image))
      {
        using (Bitmap renderedImage = new Bitmap(originalImage.Width, originalImage.Height))
        {
          for (int x = 0; x < originalImage.Width; x++)
          {
            for (int y = 0; y < originalImage.Height; y++)
            {
              Color color = originalImage.GetPixel(x, y);

              // Skip transparent
              if (color.A == 0)
                renderedImage.SetPixel(x, y, color);
              else
              {
                ColorTuple tup = color.ClosestColor(palette);
                renderedImage.SetPixel(x, y, tup.ColorValue);
              }
            }
          }
          picRendered.Image = renderedImage;
        }
      }
    }


    private void DisplayPalette()
    {
      int maxCols = 32;
      int rows = (palette.Keys.Count / maxCols) + 1;
      int actualCols = rows == 1 ? Math.Min(palette.Keys.Count, maxCols) : maxCols;
      int paletteOffset = 0;

      Panel[,] output = new Panel[rows, actualCols];

      int tileSizeX = pnlPalette.Width / actualCols;
      int tileSizeY = pnlPalette.Height / rows;

      for (int x = 0; x < actualCols; x++)
      {
        for (int y = 0; y < rows; y++)
        {
          if (paletteOffset < palette.Keys.Count)
          {
            int pX = tileSizeX * x + pnlPalette.Location.X;
            int pY = tileSizeY * y + pnlPalette.Location.Y;
            //Console.WriteLine("C:{0} @ ({1},{2})", palette.Values.ElementAt(paletteOffset), pX, pY);

            var newPanel = new CustomPanel(x, y, new ColorTuple(palette.Keys.ElementAt(paletteOffset), palette.Values.ElementAt(paletteOffset)))
            {
              Size = new Size(tileSizeX, tileSizeY),
              Location = new Point(pX, pY),
              BackColor = palette.Values.ElementAt(paletteOffset++)
            };

            Controls.Add(newPanel);
            newPanel.Click += NewPanel_Click;
          }
          else
          {
            break;
          }
        }

        if (paletteOffset >= palette.Keys.Count)
          break;
      }

      pnlPalette.Visible = false;
    }

    private void NewPanel_Click(object sender, EventArgs e)
    {
      CustomPanel src = (CustomPanel)sender;
    }

    private void AResizableImageOrPictureBoxMethodToBeImplemented()
    {
      /*
      Image myImg = new Image.FromFile(..//landscape.jpg);
      int getWidth = myImg.Width;
      int getHeight = myImg.Height;
      double ratio = 0;
      if (getWidth > getHeight)
      {
        ratio = getWidth / 400;
        getWidth = 400;
        getHeight = (int)(getHeight / ratio);
      }
      else
      {
        ratio = getHeight / 400;
        getHeight = 400;
        getWidth = (int)(getWidth / ratio);
      }
      pictureBox.Width = getWidth;
      pictureBox.Height = getHeight;
      */
    }
  }
}
