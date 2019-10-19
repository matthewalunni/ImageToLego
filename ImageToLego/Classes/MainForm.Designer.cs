namespace ImageToLego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbImagePath = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColorPalette = new System.Windows.Forms.Button();
            this.tbCSVPath = new System.Windows.Forms.TextBox();
            this.BtnPrintReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // tbImagePath
            // 
            this.tbImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImagePath.Location = new System.Drawing.Point(364, 37);
            this.tbImagePath.Name = "tbImagePath";
            this.tbImagePath.Size = new System.Drawing.Size(258, 20);
            this.tbImagePath.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Location = new System.Drawing.Point(628, 35);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Image:";
            // 
            // dgvOutput
            // 
            this.dgvOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(364, 123);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.Size = new System.Drawing.Size(339, 226);
            this.dgvOutput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output:";
            // 
            // panel1
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.Location = new System.Drawing.Point(12, 12);
            this.imagePanel.Name = "panel1";
            this.imagePanel.Size = new System.Drawing.Size(340, 337);
            this.imagePanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Color Palette As CSV (Optional):";
            // 
            // btnColorPalette
            // 
            this.btnColorPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColorPalette.Location = new System.Drawing.Point(628, 82);
            this.btnColorPalette.Name = "btnColorPalette";
            this.btnColorPalette.Size = new System.Drawing.Size(75, 23);
            this.btnColorPalette.TabIndex = 10;
            this.btnColorPalette.Text = "...";
            this.btnColorPalette.UseVisualStyleBackColor = true;
            this.btnColorPalette.Click += new System.EventHandler(this.BtnColorPalette_Click);
            // 
            // tbCSVPath
            // 
            this.tbCSVPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCSVPath.Location = new System.Drawing.Point(364, 84);
            this.tbCSVPath.Name = "tbCSVPath";
            this.tbCSVPath.Size = new System.Drawing.Size(258, 20);
            this.tbCSVPath.TabIndex = 9;
            // 
            // BtnPrintReport
            // 
            this.BtnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrintReport.Location = new System.Drawing.Point(315, 355);
            this.BtnPrintReport.Name = "btnPrintReport";
            this.BtnPrintReport.Size = new System.Drawing.Size(81, 23);
            this.BtnPrintReport.TabIndex = 12;
            this.BtnPrintReport.Text = "Print Report";
            this.BtnPrintReport.UseVisualStyleBackColor = true;
            this.BtnPrintReport.Click += new System.EventHandler(this.BtnPrintReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 383);
            this.Controls.Add(this.BtnPrintReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnColorPalette);
            this.Controls.Add(this.tbCSVPath);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.tbImagePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Image to LEGO";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbImagePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColorPalette;
        private System.Windows.Forms.TextBox tbCSVPath;
        private System.Windows.Forms.Button BtnPrintReport;
    }
}

