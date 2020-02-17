namespace PaletteNormalizer
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.picOriginal = new System.Windows.Forms.PictureBox();
      this.picRendered = new System.Windows.Forms.PictureBox();
      this.pnlPalette = new System.Windows.Forms.Panel();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnNewImage = new System.Windows.Forms.Button();
      this.btnNewPalette = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picRendered)).BeginInit();
      this.SuspendLayout();
      // 
      // picOriginal
      // 
      this.picOriginal.Location = new System.Drawing.Point(12, 12);
      this.picOriginal.Name = "picOriginal";
      this.picOriginal.Size = new System.Drawing.Size(400, 400);
      this.picOriginal.TabIndex = 0;
      this.picOriginal.TabStop = false;
      // 
      // picRendered
      // 
      this.picRendered.Location = new System.Drawing.Point(435, 12);
      this.picRendered.Name = "picRendered";
      this.picRendered.Size = new System.Drawing.Size(400, 400);
      this.picRendered.TabIndex = 1;
      this.picRendered.TabStop = false;
      // 
      // pnlPalette
      // 
      this.pnlPalette.BackColor = System.Drawing.SystemColors.Control;
      this.pnlPalette.Location = new System.Drawing.Point(12, 418);
      this.pnlPalette.Name = "pnlPalette";
      this.pnlPalette.Size = new System.Drawing.Size(823, 114);
      this.pnlPalette.TabIndex = 2;
      // 
      // btnUpdate
      // 
      this.btnUpdate.Location = new System.Drawing.Point(424, 545);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new System.Drawing.Size(75, 23);
      this.btnUpdate.TabIndex = 3;
      this.btnUpdate.Text = "Update";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Click += new System.EventHandler(this.Update_Click);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(505, 545);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.Save_Click);
      // 
      // btnNewImage
      // 
      this.btnNewImage.Location = new System.Drawing.Point(262, 545);
      this.btnNewImage.Name = "btnNewImage";
      this.btnNewImage.Size = new System.Drawing.Size(75, 23);
      this.btnNewImage.TabIndex = 5;
      this.btnNewImage.Text = "New Image";
      this.btnNewImage.UseVisualStyleBackColor = true;
      this.btnNewImage.Click += new System.EventHandler(this.NewImage_Click);
      // 
      // btnNewPalette
      // 
      this.btnNewPalette.Location = new System.Drawing.Point(343, 545);
      this.btnNewPalette.Name = "btnNewPalette";
      this.btnNewPalette.Size = new System.Drawing.Size(75, 23);
      this.btnNewPalette.TabIndex = 6;
      this.btnNewPalette.Text = "New Palette";
      this.btnNewPalette.UseVisualStyleBackColor = true;
      this.btnNewPalette.Click += new System.EventHandler(this.NewPalette_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(848, 581);
      this.Controls.Add(this.btnNewPalette);
      this.Controls.Add(this.btnNewImage);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnUpdate);
      this.Controls.Add(this.pnlPalette);
      this.Controls.Add(this.picRendered);
      this.Controls.Add(this.picOriginal);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picRendered)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picOriginal;
    private System.Windows.Forms.PictureBox picRendered;
    private System.Windows.Forms.Panel pnlPalette;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnNewImage;
    private System.Windows.Forms.Button btnNewPalette;
  }
}

