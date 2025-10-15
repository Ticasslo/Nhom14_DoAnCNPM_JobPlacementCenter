namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login
{
    partial class Login_Form
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
            this.grBoxRole = new Guna.UI2.WinForms.Guna2GroupBox();
            this.radioBtnSA = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnCM = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnFO = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnERS = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnCSS = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.picBoxHide = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picBoxShow = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.grBoxRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // grBoxRole
            // 
            this.grBoxRole.Controls.Add(this.radioBtnSA);
            this.grBoxRole.Controls.Add(this.radioBtnCM);
            this.grBoxRole.Controls.Add(this.radioBtnFO);
            this.grBoxRole.Controls.Add(this.radioBtnERS);
            this.grBoxRole.Controls.Add(this.radioBtnCSS);
            this.grBoxRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grBoxRole.Location = new System.Drawing.Point(15, 254);
            this.grBoxRole.Margin = new System.Windows.Forms.Padding(2);
            this.grBoxRole.Name = "grBoxRole";
            this.grBoxRole.Size = new System.Drawing.Size(427, 285);
            this.grBoxRole.TabIndex = 98;
            this.grBoxRole.Text = "Vai trò";
            // 
            // radioBtnSA
            // 
            this.radioBtnSA.AutoSize = true;
            this.radioBtnSA.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnSA.CheckedState.BorderThickness = 0;
            this.radioBtnSA.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnSA.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnSA.CheckedState.InnerOffset = -4;
            this.radioBtnSA.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnSA.Location = new System.Drawing.Point(11, 241);
            this.radioBtnSA.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnSA.Name = "radioBtnSA";
            this.radioBtnSA.Size = new System.Drawing.Size(197, 32);
            this.radioBtnSA.TabIndex = 0;
            this.radioBtnSA.Text = "Quản trị hệ thống";
            this.radioBtnSA.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnSA.UncheckedState.BorderThickness = 2;
            this.radioBtnSA.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnSA.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioBtnCM
            // 
            this.radioBtnCM.AutoSize = true;
            this.radioBtnCM.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnCM.CheckedState.BorderThickness = 0;
            this.radioBtnCM.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnCM.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnCM.CheckedState.InnerOffset = -4;
            this.radioBtnCM.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnCM.Location = new System.Drawing.Point(11, 196);
            this.radioBtnCM.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnCM.Name = "radioBtnCM";
            this.radioBtnCM.Size = new System.Drawing.Size(200, 32);
            this.radioBtnCM.TabIndex = 0;
            this.radioBtnCM.Text = "Quản lý trung tâm";
            this.radioBtnCM.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnCM.UncheckedState.BorderThickness = 2;
            this.radioBtnCM.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnCM.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioBtnFO
            // 
            this.radioBtnFO.AutoSize = true;
            this.radioBtnFO.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnFO.CheckedState.BorderThickness = 0;
            this.radioBtnFO.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnFO.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnFO.CheckedState.InnerOffset = -4;
            this.radioBtnFO.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnFO.Location = new System.Drawing.Point(11, 149);
            this.radioBtnFO.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnFO.Name = "radioBtnFO";
            this.radioBtnFO.Size = new System.Drawing.Size(210, 32);
            this.radioBtnFO.TabIndex = 0;
            this.radioBtnFO.Text = "Nhân viên tài chính";
            this.radioBtnFO.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnFO.UncheckedState.BorderThickness = 2;
            this.radioBtnFO.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnFO.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioBtnERS
            // 
            this.radioBtnERS.AutoSize = true;
            this.radioBtnERS.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnERS.CheckedState.BorderThickness = 0;
            this.radioBtnERS.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnERS.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnERS.CheckedState.InnerOffset = -4;
            this.radioBtnERS.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnERS.Location = new System.Drawing.Point(11, 103);
            this.radioBtnERS.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnERS.Name = "radioBtnERS";
            this.radioBtnERS.Size = new System.Drawing.Size(361, 32);
            this.radioBtnERS.TabIndex = 0;
            this.radioBtnERS.Text = "Chuyên viên quan hệ doanh nghiệp";
            this.radioBtnERS.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnERS.UncheckedState.BorderThickness = 2;
            this.radioBtnERS.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnERS.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioBtnCSS
            // 
            this.radioBtnCSS.AutoSize = true;
            this.radioBtnCSS.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnCSS.CheckedState.BorderThickness = 0;
            this.radioBtnCSS.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioBtnCSS.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioBtnCSS.CheckedState.InnerOffset = -4;
            this.radioBtnCSS.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnCSS.Location = new System.Drawing.Point(11, 56);
            this.radioBtnCSS.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnCSS.Name = "radioBtnCSS";
            this.radioBtnCSS.Size = new System.Drawing.Size(294, 32);
            this.radioBtnCSS.TabIndex = 0;
            this.radioBtnCSS.Text = "Chuyên viên hỗ trợ ứng viên";
            this.radioBtnCSS.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioBtnCSS.UncheckedState.BorderThickness = 2;
            this.radioBtnCSS.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioBtnCSS.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // btnLogin
            // 
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(15, 557);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(427, 59);
            this.btnLogin.TabIndex = 97;
            this.btnLogin.Text = "Đăng nhập";
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(159, 134);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(267, 29);
            this.txtUsername.TabIndex = 95;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTitle.Location = new System.Drawing.Point(121, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(209, 41);
            this.lbTitle.TabIndex = 94;
            this.lbTitle.Text = "ĐĂNG NHẬP";
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.Location = new System.Drawing.Point(85, 61);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(279, 28);
            this.lbWelcome.TabIndex = 93;
            this.lbWelcome.Text = "Trung tâm giới thiệu việc làm";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(31, 197);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(98, 25);
            this.lbPassword.TabIndex = 91;
            this.lbPassword.Text = "Mật khẩu:";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(31, 134);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(99, 25);
            this.lbUsername.TabIndex = 92;
            this.lbUsername.Text = "Tài khoản:";
            // 
            // picBoxHide
            // 
            this.picBoxHide.ImageRotate = 0F;
            this.picBoxHide.Location = new System.Drawing.Point(387, 201);
            this.picBoxHide.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxHide.Name = "picBoxHide";
            this.picBoxHide.Size = new System.Drawing.Size(35, 22);
            this.picBoxHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxHide.TabIndex = 99;
            this.picBoxHide.TabStop = false;
            // 
            // picBoxShow
            // 
            this.picBoxShow.ImageRotate = 0F;
            this.picBoxShow.Location = new System.Drawing.Point(387, 201);
            this.picBoxShow.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxShow.Name = "picBoxShow";
            this.picBoxShow.Size = new System.Drawing.Size(35, 22);
            this.picBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxShow.TabIndex = 100;
            this.picBoxShow.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(159, 197);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(267, 29);
            this.txtPassword.TabIndex = 96;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 637);
            this.Controls.Add(this.grBoxRole);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.picBoxHide);
            this.Controls.Add(this.picBoxShow);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.grBoxRole.ResumeLayout(false);
            this.grBoxRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grBoxRole;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnSA;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnCM;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnFO;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnERS;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnCSS;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUsername;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxHide;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxShow;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
    }
}