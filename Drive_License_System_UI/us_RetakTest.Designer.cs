namespace Drive_License_System_UI
{
    partial class us_RetakTest
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
            this.btnGoBack = new Guna.UI2.WinForms.Guna2Button();
            this.title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlfull.SuspendLayout();
            this.pnltop.SuspendLayout();
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
            this.pnlfull.TabIndex = 3;
            // 
            // pnlscreen
            // 
            this.pnlscreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlscreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlscreen.Location = new System.Drawing.Point(0, 85);
            this.pnlscreen.Name = "pnlscreen";
            this.pnlscreen.Padding = new System.Windows.Forms.Padding(40, 20, 20, 10);
            this.pnlscreen.Size = new System.Drawing.Size(1632, 933);
            this.pnlscreen.TabIndex = 5;
            // 
            // pnltop
            // 
            this.pnltop.BackColor = System.Drawing.Color.Transparent;
            this.pnltop.Controls.Add(this.btnGoBack);
            this.pnltop.Controls.Add(this.title);
            this.pnltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop.Location = new System.Drawing.Point(0, 0);
            this.pnltop.Name = "pnltop";
            this.pnltop.Size = new System.Drawing.Size(1632, 85);
            this.pnltop.TabIndex = 4;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoBack.FillColor = System.Drawing.Color.Transparent;
            this.btnGoBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.Image = global::Drive_License_System_UI.Properties.Resources._124;
            this.btnGoBack.ImageSize = new System.Drawing.Size(25, 25);
            this.btnGoBack.Location = new System.Drawing.Point(3, 17);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(56, 45);
            this.btnGoBack.TabIndex = 7;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(76, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(188, 30);
            this.title.TabIndex = 11;
            this.title.Text = "Rescheduling a test";
            // 
            // us_RetakTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlfull);
            this.Name = "us_RetakTest";
            this.Size = new System.Drawing.Size(1632, 1018);
            this.Load += new System.EventHandler(this.us_RetakTest_Load);
            this.pnlfull.ResumeLayout(false);
            this.pnltop.ResumeLayout(false);
            this.pnltop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlfull;
        private Guna.UI2.WinForms.Guna2Panel pnlscreen;
        private Guna.UI2.WinForms.Guna2Panel pnltop;
        private Guna.UI2.WinForms.Guna2Button btnGoBack;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
    }
}
