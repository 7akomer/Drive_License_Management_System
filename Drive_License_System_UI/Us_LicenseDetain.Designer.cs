namespace Drive_License_System_UI
{
    partial class Us_LicenseDetain
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pnltop = new Guna.UI2.WinForms.Guna2Panel();
            this.subtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.piclTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlscreen = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.pnlscreen);
            this.guna2CustomGradientPanel1.Controls.Add(this.pnltop);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(8)))), ((int)(((byte)(32)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(63)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(16)))), ((int)(((byte)(70)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1632, 1018);
            this.guna2CustomGradientPanel1.TabIndex = 1;
            // 
            // pnltop
            // 
            this.pnltop.BackColor = System.Drawing.Color.Transparent;
            this.pnltop.Controls.Add(this.piclTitle);
            this.pnltop.Controls.Add(this.subtitle);
            this.pnltop.Controls.Add(this.title);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1632, 85);
            this.pnltop.TabIndex = 3;
            // 
            // subtitle
            // 
            this.subtitle.BackColor = System.Drawing.Color.Transparent;
            this.subtitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(148)))), ((int)(((byte)(178)))));
            this.subtitle.Location = new System.Drawing.Point(90, 46);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(169, 19);
            this.subtitle.TabIndex = 12;
            this.subtitle.Text = "License seizure and release";
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(89, 19);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(141, 30);
            this.title.TabIndex = 11;
            this.title.Text = "License Detain";
            // 
            // piclTitle
            // 
            this.piclTitle.BackgroundImage = global::Drive_License_System_UI.Properties.Resources._992;
            this.piclTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.piclTitle.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.piclTitle.FillColor = System.Drawing.Color.Transparent;
            this.piclTitle.ImageRotate = 0F;
            this.piclTitle.Location = new System.Drawing.Point(36, 21);
            this.piclTitle.Name = "piclTitle";
            this.piclTitle.Size = new System.Drawing.Size(45, 40);
            this.piclTitle.TabIndex = 2;
            this.piclTitle.TabStop = false;
            this.piclTitle.UseWaitCursor = true;
            // 
            // pnlscreen
            // 
            this.pnlscreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlscreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscreen.Location = new System.Drawing.Point(0, 85);
            this.pnlscreen.Name = "pnlscreen";
            this.pnlscreen.Padding = new System.Windows.Forms.Padding(40, 20, 20, 10);
            this.pnlscreen.Size = new System.Drawing.Size(1632, 933);
            this.pnlscreen.TabIndex = 4;
            this.pnlscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlscreen_Paint);
            // 
            // Us_LicenseDetain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Us_LicenseDetain";
            this.Size = new System.Drawing.Size(1632, 1018);
            this.Load += new System.EventHandler(this.Us_LicenseDetain_Load);
            this.Click += new System.EventHandler(this.Us_LicenseDetain_Click);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel pnltop;
        private Guna.UI2.WinForms.Guna2HtmlLabel subtitle;
        private Guna.UI2.WinForms.Guna2PictureBox piclTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2Panel pnlscreen;
    }
}
