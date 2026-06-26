namespace Drive_License_System_UI
{
    partial class Us_History
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
            this.pnlfull = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pnlscreen = new Guna.UI2.WinForms.Guna2Panel();
            this.pnltop = new Guna.UI2.WinForms.Guna2Panel();
            this.subtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.piclTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlfull.SuspendLayout();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlfull
            // 
            this.pnlfull.Controls.Add(this.pnlscreen);
            this.pnlfull.Controls.Add(this.pnltop);
            this.pnlfull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlfull.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(8)))), ((int)(((byte)(32)))));
            this.pnlfull.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(63)))));
            this.pnlfull.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(16)))), ((int)(((byte)(70)))));
            this.pnlfull.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.pnlfull.Location = new System.Drawing.Point(0, 0);
            this.pnlfull.Margin = new System.Windows.Forms.Padding(4);
            this.pnlfull.Name = "pnlfull";
            this.pnlfull.Size = new System.Drawing.Size(1632, 1018);
            this.pnlfull.TabIndex = 1;
            // 
            // pnlscreen
            // 
            this.pnlscreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlscreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscreen.Location = new System.Drawing.Point(0, 85);
            this.pnlscreen.Name = "pnlscreen";
            this.pnlscreen.Padding = new System.Windows.Forms.Padding(30, 20, 20, 10);
            this.pnlscreen.Size = new System.Drawing.Size(1632, 933);
            this.pnlscreen.TabIndex = 5;
            this.pnlscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlscreen_Paint);
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
            this.pnltop.TabIndex = 4;
            // 
            // subtitle
            // 
            this.subtitle.BackColor = System.Drawing.Color.Transparent;
            this.subtitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(148)))), ((int)(((byte)(178)))));
            this.subtitle.Location = new System.Drawing.Point(90, 48);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(388, 19);
            this.subtitle.TabIndex = 12;
            this.subtitle.Text = "Here is the center for reviewing the history of all applications.";
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(89, 19);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(72, 30);
            this.title.TabIndex = 11;
            this.title.Text = "History";
            // 
            // piclTitle
            // 
            this.piclTitle.BackgroundImage = global::Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6193;
            this.piclTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.piclTitle.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.piclTitle.FillColor = System.Drawing.Color.Transparent;
            this.piclTitle.ImageRotate = 0F;
            this.piclTitle.Location = new System.Drawing.Point(38, 28);
            this.piclTitle.Name = "piclTitle";
            this.piclTitle.Size = new System.Drawing.Size(45, 40);
            this.piclTitle.TabIndex = 2;
            this.piclTitle.TabStop = false;
            this.piclTitle.UseWaitCursor = true;
            // 
            // Us_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlfull);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Us_History";
            this.Size = new System.Drawing.Size(1632, 1018);
            this.Load += new System.EventHandler(this.Us_History_Load);
            this.pnlfull.ResumeLayout(false);
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlfull;
        private Guna.UI2.WinForms.Guna2Panel pnltop;
        private Guna.UI2.WinForms.Guna2PictureBox piclTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel subtitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2Panel pnlscreen;
    }
}
