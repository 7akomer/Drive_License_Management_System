namespace Drive_License_System_UI
{
    partial class Us_Examinations
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
            this.lblIcon = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.piclTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlfull.SuspendLayout();
            this.pnltop.SuspendLayout();
            this.lblIcon.SuspendLayout();
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
            this.pnlfull.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel1_Paint);
            // 
            // pnlscreen
            // 
            this.pnlscreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlscreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscreen.Location = new System.Drawing.Point(0, 85);
            this.pnlscreen.Name = "pnlscreen";
            this.pnlscreen.Padding = new System.Windows.Forms.Padding(40, 20, 20, 10);
            this.pnlscreen.Size = new System.Drawing.Size(1632, 933);
            this.pnlscreen.TabIndex = 3;
            this.pnlscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlscreen_Paint);
            // 
            // pnltop
            // 
            this.pnltop.BackColor = System.Drawing.Color.Transparent;
            this.pnltop.Controls.Add(this.subtitle);
            this.pnltop.Controls.Add(this.lblIcon);
            this.pnltop.Controls.Add(this.title);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1632, 85);
            this.pnltop.TabIndex = 2;
            // 
            // subtitle
            // 
            this.subtitle.BackColor = System.Drawing.Color.Transparent;
            this.subtitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(148)))), ((int)(((byte)(178)))));
            this.subtitle.Location = new System.Drawing.Point(90, 46);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(146, 19);
            this.subtitle.TabIndex = 12;
            this.subtitle.Text = "View and conduct tests";
            // 
            // lblIcon
            // 
            this.lblIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIcon.BorderRadius = 11;
            this.lblIcon.Controls.Add(this.piclTitle);
            this.lblIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(35)))), ((int)(((byte)(140)))));
            this.lblIcon.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(65)))), ((int)(((byte)(230)))));
            this.lblIcon.Location = new System.Drawing.Point(37, 20);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(45, 45);
            this.lblIcon.TabIndex = 13;
            this.lblIcon.UseWaitCursor = true;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(89, 19);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(135, 30);
            this.title.TabIndex = 11;
            this.title.Text = "Examanations";
            // 
            // piclTitle
            // 
            this.piclTitle.BackgroundImage = global::Drive_License_System_UI.Properties.Resources.file_00000000f00471f48ddd0d70bf8bafba;
            this.piclTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.piclTitle.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.piclTitle.FillColor = System.Drawing.Color.Transparent;
            this.piclTitle.ImageRotate = 0F;
            this.piclTitle.Location = new System.Drawing.Point(0, 3);
            this.piclTitle.Name = "piclTitle";
            this.piclTitle.Size = new System.Drawing.Size(45, 40);
            this.piclTitle.TabIndex = 2;
            this.piclTitle.TabStop = false;
            this.piclTitle.UseWaitCursor = true;
            // 
            // Us_Examinations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlfull);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Us_Examinations";
            this.Size = new System.Drawing.Size(1632, 1018);
            this.Load += new System.EventHandler(this.Us_Examinations_Load);
            this.pnlfull.ResumeLayout(false);
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            this.lblIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlfull;
        private Guna.UI2.WinForms.Guna2Panel pnltop;
        private Guna.UI2.WinForms.Guna2HtmlLabel subtitle;
        private Guna.UI2.WinForms.Guna2GradientPanel lblIcon;
        private Guna.UI2.WinForms.Guna2PictureBox piclTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2Panel pnlscreen;
    }
}
