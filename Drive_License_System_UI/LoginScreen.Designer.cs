namespace Drive_License_System_UI
{
    partial class LoginScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.hadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.passwordtextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.usernametextbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.rememberMe_cheack = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.moretext = new System.Windows.Forms.LinkLabel();
            this.picLoginPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 70;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // hadow
            // 
            this.hadow.TargetForm = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BorderRadius = 8;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.btnLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(48)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(585, 441);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(497, 63);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // passwordtextbox
            // 
            this.passwordtextbox.BorderRadius = 10;
            this.passwordtextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordtextbox.DefaultText = "";
            this.passwordtextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordtextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordtextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordtextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordtextbox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(51)))));
            this.passwordtextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordtextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordtextbox.ForeColor = System.Drawing.Color.White;
            this.passwordtextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordtextbox.Location = new System.Drawing.Point(585, 332);
            this.passwordtextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordtextbox.Name = "passwordtextbox";
            this.passwordtextbox.PlaceholderText = "Enter your password";
            this.passwordtextbox.SelectedText = "";
            this.passwordtextbox.Size = new System.Drawing.Size(497, 50);
            this.passwordtextbox.TabIndex = 5;
            this.passwordtextbox.UseSystemPasswordChar = true;
            this.passwordtextbox.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // usernametextbox
            // 
            this.usernametextbox.BorderRadius = 10;
            this.usernametextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernametextbox.DefaultText = "";
            this.usernametextbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernametextbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernametextbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernametextbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernametextbox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(51)))));
            this.usernametextbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernametextbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.usernametextbox.ForeColor = System.Drawing.Color.White;
            this.usernametextbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernametextbox.Location = new System.Drawing.Point(585, 240);
            this.usernametextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernametextbox.Name = "usernametextbox";
            this.usernametextbox.PlaceholderText = "Enter your username";
            this.usernametextbox.SelectedText = "";
            this.usernametextbox.Size = new System.Drawing.Size(497, 50);
            this.usernametextbox.TabIndex = 6;
            this.usernametextbox.TextChanged += new System.EventHandler(this.guna2TextBox3_TextChanged);
            // 
            // rememberMe_cheack
            // 
            this.rememberMe_cheack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.rememberMe_cheack.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rememberMe_cheack.CheckedState.BorderRadius = 2;
            this.rememberMe_cheack.CheckedState.BorderThickness = 0;
            this.rememberMe_cheack.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rememberMe_cheack.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(26)))));
            this.rememberMe_cheack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rememberMe_cheack.Location = new System.Drawing.Point(585, 401);
            this.rememberMe_cheack.Margin = new System.Windows.Forms.Padding(4);
            this.rememberMe_cheack.Name = "rememberMe_cheack";
            this.rememberMe_cheack.Size = new System.Drawing.Size(20, 18);
            this.rememberMe_cheack.TabIndex = 8;
            this.rememberMe_cheack.Text = "guna2CustomCheckBox1";
            this.rememberMe_cheack.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rememberMe_cheack.UncheckedState.BorderRadius = 2;
            this.rememberMe_cheack.UncheckedState.BorderThickness = 0;
            this.rememberMe_cheack.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rememberMe_cheack.Click += new System.EventHandler(this.rememberMe_cheack_Click);
            // 
            // moretext
            // 
            this.moretext.ActiveLinkColor = System.Drawing.Color.DarkBlue;
            this.moretext.AutoSize = true;
            this.moretext.DisabledLinkColor = System.Drawing.Color.DimGray;
            this.moretext.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moretext.ForeColor = System.Drawing.Color.BlueViolet;
            this.moretext.Image = global::Drive_License_System_UI.Properties.Resources.Screenshot__379_;
            this.moretext.LinkColor = System.Drawing.Color.BlueViolet;
            this.moretext.Location = new System.Drawing.Point(919, 553);
            this.moretext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moretext.Name = "moretext";
            this.moretext.Size = new System.Drawing.Size(50, 22);
            this.moretext.TabIndex = 9;
            this.moretext.TabStop = true;
            this.moretext.Text = "more";
            this.moretext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.moretext_LinkClicked);
            // 
            // picLoginPhoto
            // 
            this.picLoginPhoto.BackColor = System.Drawing.Color.Transparent;
            this.picLoginPhoto.BorderRadius = 25;
            this.picLoginPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoginPhoto.Image = global::Drive_License_System_UI.Properties.Resources.ا;
            this.picLoginPhoto.ImageRotate = 0F;
            this.picLoginPhoto.Location = new System.Drawing.Point(0, 0);
            this.picLoginPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.picLoginPhoto.Name = "picLoginPhoto";
            this.picLoginPhoto.Size = new System.Drawing.Size(1200, 615);
            this.picLoginPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoginPhoto.TabIndex = 0;
            this.picLoginPhoto.TabStop = false;
            this.picLoginPhoto.Click += new System.EventHandler(this.guna2PictureBox1_Click_1);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(16)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1200, 615);
            this.Controls.Add(this.moretext);
            this.Controls.Add(this.rememberMe_cheack);
            this.Controls.Add(this.usernametextbox);
            this.Controls.Add(this.passwordtextbox);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.picLoginPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1200, 615);
            this.MinimumSize = new System.Drawing.Size(1200, 615);
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoginPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        public Guna.UI2.WinForms.Guna2ShadowForm hadow;
        private Guna.UI2.WinForms.Guna2PictureBox picLoginPhoto;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2CustomCheckBox rememberMe_cheack;
        private System.Windows.Forms.LinkLabel moretext;
        public Guna.UI2.WinForms.Guna2TextBox passwordtextbox;
        public Guna.UI2.WinForms.Guna2TextBox usernametextbox;
    }
}

