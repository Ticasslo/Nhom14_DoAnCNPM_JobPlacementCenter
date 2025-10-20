namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    partial class QLTaiKhoanNhanVien_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.cbVaiTro = new System.Windows.Forms.ComboBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblHoten = new System.Windows.Forms.Label();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.panelChiTiet = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.checkDoiMatKhau = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnCapNhatMatKhau = new Guna.UI2.WinForms.Guna2Button();
            this.btnHienMatKhau = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiLai = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.DGVTaiKhoanNhanVien = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTaiKhoanNhanVien)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelDGV.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(829, 60);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(356, 34);
            this.txtTimKiem.TabIndex = 92;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimKiem.Location = new System.Drawing.Point(417, 65);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(391, 28);
            this.lblTimKiem.TabIndex = 90;
            this.lblTimKiem.Text = "🔍 Tìm kiếm (Họ tên, Email, Username):";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(654, 223);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(409, 36);
            this.cbTrangThai.TabIndex = 103;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(655, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(408, 34);
            this.txtPassword.TabIndex = 102;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(655, 41);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(408, 34);
            this.txtUsername.TabIndex = 101;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(132, 165);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(328, 34);
            this.txtSDT.TabIndex = 100;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(132, 103);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(328, 34);
            this.txtEmail.TabIndex = 99;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTrangThai.Location = new System.Drawing.Point(505, 226);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(107, 28);
            this.lblTrangThai.TabIndex = 98;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVaiTro.Location = new System.Drawing.Point(21, 228);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(76, 28);
            this.lblVaiTro.TabIndex = 97;
            this.lblVaiTro.Text = "Vai trò:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMatKhau.Location = new System.Drawing.Point(505, 108);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(103, 28);
            this.lblMatKhau.TabIndex = 96;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsername.Location = new System.Drawing.Point(505, 47);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(109, 28);
            this.lblUsername.TabIndex = 95;
            this.lblUsername.Text = "Username:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSDT.Location = new System.Drawing.Point(21, 167);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(53, 28);
            this.lblSDT.TabIndex = 94;
            this.lblSDT.Text = "SĐT:";
            // 
            // cbVaiTro
            // 
            this.cbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVaiTro.FormattingEnabled = true;
            this.cbVaiTro.Location = new System.Drawing.Point(132, 224);
            this.cbVaiTro.Name = "cbVaiTro";
            this.cbVaiTro.Size = new System.Drawing.Size(328, 36);
            this.cbVaiTro.TabIndex = 91;
            this.cbVaiTro.SelectedIndexChanged += new System.EventHandler(this.cbVaiTro_SelectedIndexChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(132, 42);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(328, 34);
            this.txtHoTen.TabIndex = 90;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEmail.Location = new System.Drawing.Point(21, 107);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 28);
            this.lblEmail.TabIndex = 87;
            this.lblEmail.Text = "Email:";
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoten.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHoten.Location = new System.Drawing.Point(21, 47);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(80, 28);
            this.lblHoten.TabIndex = 86;
            this.lblHoten.Text = "Họ tên:";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.lblChiTiet.Location = new System.Drawing.Point(19, 0);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(100, 35);
            this.lblChiTiet.TabIndex = 82;
            this.lblChiTiet.Text = "Chi tiết";
            // 
            // panelChiTiet
            // 
            this.panelChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.panelChiTiet.Controls.Add(this.checkDoiMatKhau);
            this.panelChiTiet.Controls.Add(this.btnCapNhatMatKhau);
            this.panelChiTiet.Controls.Add(this.btnHienMatKhau);
            this.panelChiTiet.Controls.Add(this.btnHuy);
            this.panelChiTiet.Controls.Add(this.btnLuu);
            this.panelChiTiet.Controls.Add(this.txtHoTen);
            this.panelChiTiet.Controls.Add(this.lblChiTiet);
            this.panelChiTiet.Controls.Add(this.cbTrangThai);
            this.panelChiTiet.Controls.Add(this.lblHoten);
            this.panelChiTiet.Controls.Add(this.txtPassword);
            this.panelChiTiet.Controls.Add(this.lblEmail);
            this.panelChiTiet.Controls.Add(this.txtUsername);
            this.panelChiTiet.Controls.Add(this.cbVaiTro);
            this.panelChiTiet.Controls.Add(this.txtSDT);
            this.panelChiTiet.Controls.Add(this.txtEmail);
            this.panelChiTiet.Controls.Add(this.lblSDT);
            this.panelChiTiet.Controls.Add(this.lblTrangThai);
            this.panelChiTiet.Controls.Add(this.lblUsername);
            this.panelChiTiet.Controls.Add(this.lblVaiTro);
            this.panelChiTiet.Controls.Add(this.lblMatKhau);
            this.panelChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.panelChiTiet.Location = new System.Drawing.Point(24, 454);
            this.panelChiTiet.Name = "panelChiTiet";
            this.panelChiTiet.Radius = 12;
            this.panelChiTiet.ShadowColor = System.Drawing.Color.Black;
            this.panelChiTiet.ShadowDepth = 120;
            this.panelChiTiet.ShadowShift = 10;
            this.panelChiTiet.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.panelChiTiet.Size = new System.Drawing.Size(1128, 287);
            this.panelChiTiet.TabIndex = 94;
            // 
            // checkDoiMatKhau
            // 
            this.checkDoiMatKhau.AutoSize = true;
            this.checkDoiMatKhau.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkDoiMatKhau.CheckedState.BorderRadius = 0;
            this.checkDoiMatKhau.CheckedState.BorderThickness = 0;
            this.checkDoiMatKhau.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkDoiMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDoiMatKhau.Location = new System.Drawing.Point(1069, 110);
            this.checkDoiMatKhau.Name = "checkDoiMatKhau";
            this.checkDoiMatKhau.Size = new System.Drawing.Size(123, 24);
            this.checkDoiMatKhau.TabIndex = 110;
            this.checkDoiMatKhau.Text = "Đổi mật khẩu";
            this.checkDoiMatKhau.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkDoiMatKhau.UncheckedState.BorderRadius = 0;
            this.checkDoiMatKhau.UncheckedState.BorderThickness = 0;
            this.checkDoiMatKhau.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkDoiMatKhau.CheckedChanged += new System.EventHandler(this.checkDoiMatKhau_CheckedChanged);
            // 
            // btnCapNhatMatKhau
            // 
            this.btnCapNhatMatKhau.BorderRadius = 8;
            this.btnCapNhatMatKhau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatMatKhau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhatMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapNhatMatKhau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(121)))), ((int)(((byte)(158)))));
            this.btnCapNhatMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatMatKhau.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.btnCapNhatMatKhau.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatMatKhau.Location = new System.Drawing.Point(848, 161);
            this.btnCapNhatMatKhau.Name = "btnCapNhatMatKhau";
            this.btnCapNhatMatKhau.Size = new System.Drawing.Size(215, 38);
            this.btnCapNhatMatKhau.TabIndex = 109;
            this.btnCapNhatMatKhau.Text = "🔄 Cập nhật mật khẩu";
            this.btnCapNhatMatKhau.Click += new System.EventHandler(this.btnCapNhatMatKhau_Click);
            // 
            // btnHienMatKhau
            // 
            this.btnHienMatKhau.BorderRadius = 8;
            this.btnHienMatKhau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHienMatKhau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHienMatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHienMatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHienMatKhau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(121)))), ((int)(((byte)(158)))));
            this.btnHienMatKhau.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnHienMatKhau.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnHienMatKhau.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnHienMatKhau.Location = new System.Drawing.Point(655, 161);
            this.btnHienMatKhau.Name = "btnHienMatKhau";
            this.btnHienMatKhau.Size = new System.Drawing.Size(186, 38);
            this.btnHienMatKhau.TabIndex = 108;
            this.btnHienMatKhau.Text = "👁️ Hiện mật khẩu";
            this.btnHienMatKhau.Click += new System.EventHandler(this.btnHienMatKhau_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(121)))), ((int)(((byte)(158)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.HoverState.FillColor = System.Drawing.Color.Teal;
            this.btnHuy.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(960, 210);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 48);
            this.btnHuy.TabIndex = 107;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(121)))), ((int)(((byte)(158)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.btnLuu.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(960, 134);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 48);
            this.btnLuu.TabIndex = 106;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BorderRadius = 10;
            this.btnTaiLai.BorderThickness = 2;
            this.btnTaiLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnTaiLai.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(372, 54);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(180, 48);
            this.btnTaiLai.TabIndex = 97;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 10;
            this.btnSua.BorderThickness = 2;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnSua.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(186, 54);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(180, 48);
            this.btnSua.TabIndex = 96;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 10;
            this.btnThem.BorderThickness = 2;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnThem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(0, 54);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 48);
            this.btnThem.TabIndex = 95;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // DGVTaiKhoanNhanVien
            // 
            this.DGVTaiKhoanNhanVien.AllowUserToAddRows = false;
            this.DGVTaiKhoanNhanVien.AllowUserToDeleteRows = false;
            this.DGVTaiKhoanNhanVien.AllowUserToResizeRows = false;
            this.DGVTaiKhoanNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTaiKhoanNhanVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVTaiKhoanNhanVien.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVTaiKhoanNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTaiKhoanNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVTaiKhoanNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTaiKhoanNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVTaiKhoanNhanVien.Location = new System.Drawing.Point(3, 2);
            this.DGVTaiKhoanNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVTaiKhoanNhanVien.MultiSelect = false;
            this.DGVTaiKhoanNhanVien.Name = "DGVTaiKhoanNhanVien";
            this.DGVTaiKhoanNhanVien.ReadOnly = true;
            this.DGVTaiKhoanNhanVien.RowHeadersVisible = false;
            this.DGVTaiKhoanNhanVien.RowHeadersWidth = 51;
            this.DGVTaiKhoanNhanVien.RowTemplate.Height = 24;
            this.DGVTaiKhoanNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTaiKhoanNhanVien.Size = new System.Drawing.Size(1137, 314);
            this.DGVTaiKhoanNhanVien.TabIndex = 98;
            this.DGVTaiKhoanNhanVien.SelectionChanged += new System.EventHandler(this.DGVTaiKhoanNhanVien_SelectionChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Controls.Add(this.btnThem);
            this.panelHeader.Controls.Add(this.btnTaiLai);
            this.panelHeader.Controls.Add(this.lblTimKiem);
            this.panelHeader.Controls.Add(this.btnSua);
            this.panelHeader.Controls.Add(this.txtTimKiem);
            this.panelHeader.Location = new System.Drawing.Point(24, 12);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panelHeader.Size = new System.Drawing.Size(1125, 105);
            this.panelHeader.TabIndex = 99;
            // 
            // panelDGV
            // 
            this.panelDGV.Controls.Add(this.DGVTaiKhoanNhanVien);
            this.panelDGV.Location = new System.Drawing.Point(24, 120);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelDGV.Size = new System.Drawing.Size(1128, 328);
            this.panelDGV.TabIndex = 100;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(109)))), ((int)(((byte)(121)))));
            this.lblTieuDe.Location = new System.Drawing.Point(340, -3);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(468, 38);
            this.lblTieuDe.TabIndex = 98;
            this.lblTieuDe.Text = "QUẢN LÝ TÀI KHOẢN NHÂN VIÊN";
            // 
            // QLTaiKhoanNhanVien_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelChiTiet);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLTaiKhoanNhanVien_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTaiKhoanNhanVien)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelDGV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cbVaiTro;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnTaiLai;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.DataGridView DGVTaiKhoanNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnHienMatKhau;
        private Guna.UI2.WinForms.Guna2Button btnCapNhatMatKhau;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelDGV;
        private Guna.UI2.WinForms.Guna2CheckBox checkDoiMatKhau;
        private System.Windows.Forms.Label lblTieuDe;
    }
}