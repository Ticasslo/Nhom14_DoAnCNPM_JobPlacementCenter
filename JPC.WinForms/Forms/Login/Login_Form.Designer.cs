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
            this.components = new System.ComponentModel.Container();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.grBoxRole = new Guna.UI2.WinForms.Guna2GroupBox();
            this.radioBtnSA = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnCM = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnFO = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnERS = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioBtnCSS = new Guna.UI2.WinForms.Guna2RadioButton();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnNen1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picBoxHide = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picBoxShow = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.grBoxRole.SuspendLayout();
            this.pnNen1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShow)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.lbTitle.Location = new System.Drawing.Point(734, 58);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(237, 46);
            this.lbTitle.TabIndex = 86;
            this.lbTitle.Text = "ĐĂNG NHẬP";
            this.lbTitle.Click += new System.EventHandler(this.lbTitle_Click);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.Location = new System.Drawing.Point(716, 113);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(279, 28);
            this.lbWelcome.TabIndex = 85;
            this.lbWelcome.Text = "Trung tâm giới thiệu việc làm";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtUsername.BorderRadius = 10;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(56, 47);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Tài khoản";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(340, 66);
            this.txtUsername.TabIndex = 87;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(56, 140);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(340, 64);
            this.txtPassword.TabIndex = 87;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // grBoxRole
            // 
            this.grBoxRole.BorderRadius = 20;
            this.grBoxRole.Controls.Add(this.radioBtnSA);
            this.grBoxRole.Controls.Add(this.radioBtnCM);
            this.grBoxRole.Controls.Add(this.radioBtnFO);
            this.grBoxRole.Controls.Add(this.radioBtnERS);
            this.grBoxRole.Controls.Add(this.radioBtnCSS);
            this.grBoxRole.CustomBorderColor = System.Drawing.Color.Transparent;
            this.grBoxRole.FillColor = System.Drawing.Color.Transparent;
            this.grBoxRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxRole.ForeColor = System.Drawing.Color.White;
            this.grBoxRole.Location = new System.Drawing.Point(32, 121);
            this.grBoxRole.Margin = new System.Windows.Forms.Padding(2);
            this.grBoxRole.Name = "grBoxRole";
            this.grBoxRole.Size = new System.Drawing.Size(375, 286);
            this.grBoxRole.TabIndex = 89;
            this.grBoxRole.Text = "Vai trò";
            this.grBoxRole.Click += new System.EventHandler(this.grBoxRole_Click);
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 50;
            this.guna2Elipse1.TargetControl = this.pnNen1;
            // 
            // pnNen1
            // 
            this.pnNen1.BackColor = System.Drawing.Color.Transparent;
            this.pnNen1.BackgroundImage = global::Nhom14_DoAnCNPM_JobPlacementCenter_Code.Properties.Resources.ebc8e6b73e8681d1a157711168a76ff21;
            this.pnNen1.Controls.Add(this.guna2Panel1);
            this.pnNen1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNen1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnNen1.Location = new System.Drawing.Point(0, 0);
            this.pnNen1.Name = "pnNen1";
            this.pnNen1.Size = new System.Drawing.Size(554, 631);
            this.pnNen1.TabIndex = 91;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 35;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.grBoxRole);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Panel1.Location = new System.Drawing.Point(51, 71);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(438, 467);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(202, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "JobCenter!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(59, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "WELCOME TO";
            // 
            // picBoxHide
            // 
            this.picBoxHide.Image = global::Nhom14_DoAnCNPM_JobPlacementCenter_Code.Properties.Resources.AnPasswordIcon;
            this.picBoxHide.ImageRotate = 0F;
            this.picBoxHide.Location = new System.Drawing.Point(346, 161);
            this.picBoxHide.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxHide.Name = "picBoxHide";
            this.picBoxHide.Size = new System.Drawing.Size(35, 22);
            this.picBoxHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxHide.TabIndex = 90;
            this.picBoxHide.TabStop = false;
            this.picBoxHide.Click += new System.EventHandler(this.picBoxHide_Click);
            // 
            // picBoxShow
            // 
            this.picBoxShow.Image = global::Nhom14_DoAnCNPM_JobPlacementCenter_Code.Properties.Resources.HienPasswordIcon;
            this.picBoxShow.ImageRotate = 0F;
            this.picBoxShow.Location = new System.Drawing.Point(346, 161);
            this.picBoxShow.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxShow.Name = "picBoxShow";
            this.picBoxShow.Size = new System.Drawing.Size(35, 22);
            this.picBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxShow.TabIndex = 90;
            this.picBoxShow.TabStop = false;
            this.picBoxShow.Click += new System.EventHandler(this.picBoxShow_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 20;
            this.btnLogin.BorderThickness = 1;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            this.btnLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(231)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(727, 494);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(119)))), ((int)(((byte)(233)))));
            this.btnLogin.Size = new System.Drawing.Size(214, 54);
            this.btnLogin.TabIndex = 92;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 30;
            this.guna2CustomGradientPanel1.Controls.Add(this.txtUsername);
            this.guna2CustomGradientPanel1.Controls.Add(this.picBoxHide);
            this.guna2CustomGradientPanel1.Controls.Add(this.picBoxShow);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtPassword);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(614, 192);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(449, 250);
            this.guna2CustomGradientPanel1.TabIndex = 93;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1139, 631);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pnNen1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Form_FormClosing);
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.grBoxRole.ResumeLayout(false);
            this.grBoxRole.PerformLayout();
            this.pnNen1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShow)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbWelcome;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2GroupBox grBoxRole;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnSA;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnCM;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnFO;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnERS;
        private Guna.UI2.WinForms.Guna2RadioButton radioBtnCSS;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxShow;
        private Guna.UI2.WinForms.Guna2PictureBox picBoxHide;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnNen1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}