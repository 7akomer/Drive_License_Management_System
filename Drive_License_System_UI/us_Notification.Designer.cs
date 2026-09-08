namespace Drive_License_System_UI
{
    partial class us_Notification
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
            this.DevloperInfoText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picQr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // DevloperInfoText
            // 
            this.DevloperInfoText.BackColor = System.Drawing.Color.Transparent;
            this.DevloperInfoText.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevloperInfoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(185)))), ((int)(((byte)(210)))));
            this.DevloperInfoText.Location = new System.Drawing.Point(458, 390);
            this.DevloperInfoText.Name = "DevloperInfoText";
            this.DevloperInfoText.Size = new System.Drawing.Size(343, 29);
            this.DevloperInfoText.TabIndex = 14;
            this.DevloperInfoText.Text = "Sorry, this option is currently unavailable.";
            // 
            // picQr
            // 
            this.picQr.BackgroundImage = global::Drive_License_System_UI.Properties.Resources.n1;
            this.picQr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picQr.Location = new System.Drawing.Point(574, 307);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(90, 60);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQr.TabIndex = 25;
            this.picQr.TabStop = false;
            // 
            // us_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picQr);
            this.Controls.Add(this.DevloperInfoText);
            this.Name = "us_Notification";
            this.Size = new System.Drawing.Size(1243, 796);
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel DevloperInfoText;
        private System.Windows.Forms.PictureBox picQr;
    }
}
