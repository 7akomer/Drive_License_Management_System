namespace Drive_License_System_UI
{
    partial class Us_Licenses
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
            this.pnlFull = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pnlscreen = new Guna.UI2.WinForms.Guna2Panel();
            this.pnltop = new Guna.UI2.WinForms.Guna2Panel();
            this.subtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIconLicenses = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.piclTitleLicenses = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlFull.SuspendLayout();
            this.pnltop.SuspendLayout();
            this.lblIconLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclTitleLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFull
            // 
            this.pnlFull.BackColor = System.Drawing.Color.Transparent;
            this.pnlFull.Controls.Add(this.pnlscreen);
            this.pnlFull.Controls.Add(this.pnltop);
            this.pnlFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFull.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(8)))), ((int)(((byte)(32)))));
            this.pnlFull.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(63)))));
            this.pnlFull.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(16)))), ((int)(((byte)(70)))));
            this.pnlFull.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.pnlFull.Location = new System.Drawing.Point(0, 0);
            this.pnlFull.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFull.Name = "pnlFull";
            this.pnlFull.Size = new System.Drawing.Size(1561, 885);
            this.pnlFull.TabIndex = 1;
            // 
            // pnlscreen
            // 
            this.pnlscreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlscreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscreen.Location = new System.Drawing.Point(0, 85);
            this.pnlscreen.Name = "pnlscreen";
            this.pnlscreen.Padding = new System.Windows.Forms.Padding(30, 20, 20, 10);
            this.pnlscreen.Size = new System.Drawing.Size(1561, 800);
            this.pnlscreen.TabIndex = 1;
            this.pnlscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlscreen_Paint);
            // 
            // pnltop
            // 
            this.pnltop.BackColor = System.Drawing.Color.Transparent;
            this.pnltop.Controls.Add(this.subtitle);
            this.pnltop.Controls.Add(this.lblIconLicenses);
            this.pnltop.Controls.Add(this.title);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1561, 85);
            this.pnltop.TabIndex = 0;
            // 
            // subtitle
            // 
            this.subtitle.BackColor = System.Drawing.Color.Transparent;
            this.subtitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(148)))), ((int)(((byte)(178)))));
            this.subtitle.Location = new System.Drawing.Point(90, 46);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(331, 19);
            this.subtitle.TabIndex = 12;
            this.subtitle.Text = "Here you can view all local and international licenses";
            // 
            // lblIconLicenses
            // 
            this.lblIconLicenses.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIconLicenses.BorderRadius = 11;
            this.lblIconLicenses.Controls.Add(this.piclTitleLicenses);
            this.lblIconLicenses.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(35)))), ((int)(((byte)(140)))));
            this.lblIconLicenses.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(65)))), ((int)(((byte)(230)))));
            this.lblIconLicenses.Location = new System.Drawing.Point(37, 20);
            this.lblIconLicenses.Name = "lblIconLicenses";
            this.lblIconLicenses.Size = new System.Drawing.Size(45, 45);
            this.lblIconLicenses.TabIndex = 13;
            this.lblIconLicenses.UseWaitCursor = true;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(89, 19);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(184, 30);
            this.title.TabIndex = 11;
            this.title.Text = "Licenses Over View";
            // 
            // piclTitleLicenses
            // 
            this.piclTitleLicenses.BackgroundImage = global::Drive_License_System_UI.Properties.Resources._31;
            this.piclTitleLicenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.piclTitleLicenses.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.piclTitleLicenses.FillColor = System.Drawing.Color.Transparent;
            this.piclTitleLicenses.ImageRotate = 0F;
            this.piclTitleLicenses.Location = new System.Drawing.Point(1, 3);
            this.piclTitleLicenses.Name = "piclTitleLicenses";
            this.piclTitleLicenses.Size = new System.Drawing.Size(45, 40);
            this.piclTitleLicenses.TabIndex = 2;
            this.piclTitleLicenses.TabStop = false;
            this.piclTitleLicenses.UseWaitCursor = true;
            // 
            // Us_Licenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFull);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Us_Licenses";
            this.Size = new System.Drawing.Size(1561, 885);
            this.Load += new System.EventHandler(this.Us_Licenses_Load);
            this.pnlFull.ResumeLayout(false);
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            this.lblIconLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclTitleLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlFull;
        private Guna.UI2.WinForms.Guna2Panel pnltop;
        private Guna.UI2.WinForms.Guna2HtmlLabel subtitle;
        private Guna.UI2.WinForms.Guna2GradientPanel lblIconLicenses;
        private Guna.UI2.WinForms.Guna2PictureBox piclTitleLicenses;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2Panel pnlscreen;
    }
}
