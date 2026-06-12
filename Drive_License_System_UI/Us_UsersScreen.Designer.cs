namespace Drive_License_System_UI
{
    partial class test_us
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.picUserIcon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlFull.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFull
            // 
            this.pnlFull.Controls.Add(this.pnlHeader);
            this.pnlFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFull.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(8)))), ((int)(((byte)(32)))));
            this.pnlFull.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(20)))), ((int)(((byte)(63)))));
            this.pnlFull.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(16)))), ((int)(((byte)(70)))));
            this.pnlFull.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.pnlFull.Location = new System.Drawing.Point(0, 0);
            this.pnlFull.Name = "pnlFull";
            this.pnlFull.Size = new System.Drawing.Size(1224, 827);
            this.pnlFull.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.picUserIcon);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1224, 77);
            this.pnlHeader.TabIndex = 0;
            // 
            // picUserIcon
            // 
            this.picUserIcon.BackColor = System.Drawing.Color.Transparent;
            this.picUserIcon.BackgroundImage = global::Drive_License_System_UI.Properties.Resources._9;
            this.picUserIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUserIcon.FillColor = System.Drawing.Color.Transparent;
            this.picUserIcon.ImageRotate = 0F;
            this.picUserIcon.Location = new System.Drawing.Point(18, 20);
            this.picUserIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picUserIcon.Size = new System.Drawing.Size(34, 37);
            this.picUserIcon.TabIndex = 1;
            this.picUserIcon.TabStop = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(148)))), ((int)(((byte)(178)))));
            this.lblSubtitle.Location = new System.Drawing.Point(56, 36);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(272, 17);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Manage system users and their access permissions.";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(56, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 27);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Users Management";
            // 
            // test_us
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFull);
            this.Name = "test_us";
            this.Size = new System.Drawing.Size(1224, 827);
            this.pnlFull.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlFull;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picUserIcon;
    }
}
