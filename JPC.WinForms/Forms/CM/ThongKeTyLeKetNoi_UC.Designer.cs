namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CM
{
    partial class ThongKeTyLeKetNoi_UC
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
            this.dgvTyLe = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phantich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongUv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdViTri = new System.Windows.Forms.RadioButton();
            this.rdNhomNghe = new System.Windows.Forms.RadioButton();
            this.rdNghe = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdQuy = new System.Windows.Forms.RadioButton();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.cbThangQuy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTaoBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiLai = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txtCoViecLam = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rdoCanCaiThien = new System.Windows.Forms.RadioButton();
            this.rdoKha = new System.Windows.Forms.RadioButton();
            this.rdoTot = new System.Windows.Forms.RadioButton();
            this.btnXuatBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.txtTyLeThanhCong = new System.Windows.Forms.TextBox();
            this.txtTongUngVien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTyLe)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTyLe
            // 
            this.dgvTyLe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.dgvTyLe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTyLe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Phantich,
            this.TongUv,
            this.TyLe});
            this.dgvTyLe.Location = new System.Drawing.Point(25, 47);
            this.dgvTyLe.Name = "dgvTyLe";
            this.dgvTyLe.RowHeadersWidth = 51;
            this.dgvTyLe.RowTemplate.Height = 24;
            this.dgvTyLe.Size = new System.Drawing.Size(1035, 388);
            this.dgvTyLe.TabIndex = 20;
            this.dgvTyLe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTyLe_CellContentClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 125;
            // 
            // Phantich
            // 
            this.Phantich.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phantich.HeaderText = "Nhóm nghề/ Nghề/ Vị trí";
            this.Phantich.MinimumWidth = 6;
            this.Phantich.Name = "Phantich";
            // 
            // TongUv
            // 
            this.TongUv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TongUv.HeaderText = "Tổng Ứng Viên";
            this.TongUv.MinimumWidth = 6;
            this.TongUv.Name = "TongUv";
            // 
            // TyLe
            // 
            this.TyLe.HeaderText = "Tỷ Lệ";
            this.TyLe.MinimumWidth = 6;
            this.TyLe.Name = "TyLe";
            this.TyLe.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTyLe);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(41, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1084, 472);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BẢNG THỐNG KÊ";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.label13.Location = new System.Drawing.Point(46, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(325, 35);
            this.label13.TabIndex = 43;
            this.label13.Text = "🔍 BỘ LỌC - THỜI GIAN  ";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderRadius = 30;
            this.guna2CustomGradientPanel2.Controls.Add(this.panel1);
            this.guna2CustomGradientPanel2.Controls.Add(this.rdNam);
            this.guna2CustomGradientPanel2.Controls.Add(this.rdQuy);
            this.guna2CustomGradientPanel2.Controls.Add(this.rdThang);
            this.guna2CustomGradientPanel2.Controls.Add(this.label4);
            this.guna2CustomGradientPanel2.Controls.Add(this.label5);
            this.guna2CustomGradientPanel2.Controls.Add(this.cbNam);
            this.guna2CustomGradientPanel2.Controls.Add(this.cbThangQuy);
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(199)))), ((int)(((byte)(211)))));
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(52, 100);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(1369, 134);
            this.guna2CustomGradientPanel2.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rdViTri);
            this.panel1.Controls.Add(this.rdNhomNghe);
            this.panel1.Controls.Add(this.rdNghe);
            this.panel1.Location = new System.Drawing.Point(165, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 47);
            this.panel1.TabIndex = 29;
            // 
            // rdViTri
            // 
            this.rdViTri.AutoSize = true;
            this.rdViTri.BackColor = System.Drawing.Color.Transparent;
            this.rdViTri.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdViTri.Location = new System.Drawing.Point(302, 17);
            this.rdViTri.Name = "rdViTri";
            this.rdViTri.Size = new System.Drawing.Size(169, 27);
            this.rdViTri.TabIndex = 18;
            this.rdViTri.TabStop = true;
            this.rdViTri.Text = "Vị trí chuyên môn";
            this.rdViTri.UseVisualStyleBackColor = false;
            // 
            // rdNhomNghe
            // 
            this.rdNhomNghe.AutoSize = true;
            this.rdNhomNghe.BackColor = System.Drawing.Color.Transparent;
            this.rdNhomNghe.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdNhomNghe.Location = new System.Drawing.Point(15, 17);
            this.rdNhomNghe.Name = "rdNhomNghe";
            this.rdNhomNghe.Size = new System.Drawing.Size(122, 27);
            this.rdNhomNghe.TabIndex = 16;
            this.rdNhomNghe.TabStop = true;
            this.rdNhomNghe.Text = "Nhóm nghề";
            this.rdNhomNghe.UseVisualStyleBackColor = false;
            // 
            // rdNghe
            // 
            this.rdNghe.AutoSize = true;
            this.rdNghe.BackColor = System.Drawing.Color.Transparent;
            this.rdNghe.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdNghe.Location = new System.Drawing.Point(173, 17);
            this.rdNghe.Name = "rdNghe";
            this.rdNghe.Size = new System.Drawing.Size(73, 27);
            this.rdNghe.TabIndex = 17;
            this.rdNghe.TabStop = true;
            this.rdNghe.Text = "Nghề";
            this.rdNghe.UseVisualStyleBackColor = false;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.BackColor = System.Drawing.Color.Transparent;
            this.rdNam.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdNam.Location = new System.Drawing.Point(470, 36);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(69, 27);
            this.rdNam.TabIndex = 25;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Năm";
            this.rdNam.UseVisualStyleBackColor = false;
            // 
            // rdQuy
            // 
            this.rdQuy.AutoSize = true;
            this.rdQuy.BackColor = System.Drawing.Color.Transparent;
            this.rdQuy.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdQuy.Location = new System.Drawing.Point(337, 36);
            this.rdQuy.Name = "rdQuy";
            this.rdQuy.Size = new System.Drawing.Size(63, 27);
            this.rdQuy.TabIndex = 24;
            this.rdQuy.TabStop = true;
            this.rdQuy.Text = "Quý";
            this.rdQuy.UseVisualStyleBackColor = false;
            // 
            // rdThang
            // 
            this.rdThang.AutoSize = true;
            this.rdThang.BackColor = System.Drawing.Color.Transparent;
            this.rdThang.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdThang.Location = new System.Drawing.Point(179, 34);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(80, 27);
            this.rdThang.TabIndex = 23;
            this.rdThang.TabStop = true;
            this.rdThang.Text = "Tháng";
            this.rdThang.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(29, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Phân tích theo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(29, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Thời gian: ";
            // 
            // cbNam
            // 
            this.cbNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(1194, 18);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(127, 28);
            this.cbNam.TabIndex = 20;
            this.cbNam.Text = "-- Chọn năm --";
            // 
            // cbThangQuy
            // 
            this.cbThangQuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbThangQuy.FormattingEnabled = true;
            this.cbThangQuy.Location = new System.Drawing.Point(978, 18);
            this.cbThangQuy.Name = "cbThangQuy";
            this.cbThangQuy.Size = new System.Drawing.Size(162, 28);
            this.cbThangQuy.TabIndex = 19;
            this.cbThangQuy.Text = "-- Chọn tháng/quý --";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(109)))), ((int)(((byte)(121)))));
            this.label3.Location = new System.Drawing.Point(592, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(604, 38);
            this.label3.TabIndex = 45;
            this.label3.Text = "THỐNG KÊ TỶ LỆ ỨNG TUYỂN THÀNH CÔNG";
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.btnTaoBaoCao.BorderRadius = 10;
            this.btnTaoBaoCao.BorderThickness = 2;
            this.btnTaoBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTaoBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(1522, 165);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(183, 45);
            this.btnTaoBaoCao.TabIndex = 47;
            this.btnTaoBaoCao.Text = "TẠO BÁO CÁO";
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.Transparent;
            this.btnTaiLai.BorderRadius = 10;
            this.btnTaiLai.BorderThickness = 2;
            this.btnTaiLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiLai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(1541, 114);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(148, 45);
            this.btnTaiLai.TabIndex = 46;
            this.btnTaiLai.Text = "TẢI LẠI";
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 30;
            this.guna2CustomGradientPanel1.Controls.Add(this.txtCoViecLam);
            this.guna2CustomGradientPanel1.Controls.Add(this.label14);
            this.guna2CustomGradientPanel1.Controls.Add(this.rdoCanCaiThien);
            this.guna2CustomGradientPanel1.Controls.Add(this.rdoKha);
            this.guna2CustomGradientPanel1.Controls.Add(this.rdoTot);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnXuatBaoCao);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtTyLeThanhCong);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtTongUngVien);
            this.guna2CustomGradientPanel1.Controls.Add(this.label8);
            this.guna2CustomGradientPanel1.Controls.Add(this.label10);
            this.guna2CustomGradientPanel1.Controls.Add(this.label11);
            this.guna2CustomGradientPanel1.Controls.Add(this.label12);
            this.guna2CustomGradientPanel1.Controls.Add(this.label9);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(199)))), ((int)(((byte)(211)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(1185, 262);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(550, 496);
            this.guna2CustomGradientPanel1.TabIndex = 48;
            // 
            // txtCoViecLam
            // 
            this.txtCoViecLam.Location = new System.Drawing.Point(257, 241);
            this.txtCoViecLam.Multiline = true;
            this.txtCoViecLam.Name = "txtCoViecLam";
            this.txtCoViecLam.Size = new System.Drawing.Size(212, 30);
            this.txtCoViecLam.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(76, 246);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 25);
            this.label14.TabIndex = 42;
            this.label14.Text = "Có việc làm:";
            // 
            // rdoCanCaiThien
            // 
            this.rdoCanCaiThien.AutoSize = true;
            this.rdoCanCaiThien.BackColor = System.Drawing.Color.Transparent;
            this.rdoCanCaiThien.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoCanCaiThien.Location = new System.Drawing.Point(360, 357);
            this.rdoCanCaiThien.Name = "rdoCanCaiThien";
            this.rdoCanCaiThien.Size = new System.Drawing.Size(144, 29);
            this.rdoCanCaiThien.TabIndex = 41;
            this.rdoCanCaiThien.TabStop = true;
            this.rdoCanCaiThien.Text = "Cần cải thiện";
            this.rdoCanCaiThien.UseVisualStyleBackColor = false;
            // 
            // rdoKha
            // 
            this.rdoKha.AutoSize = true;
            this.rdoKha.BackColor = System.Drawing.Color.Transparent;
            this.rdoKha.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoKha.Location = new System.Drawing.Point(233, 357);
            this.rdoKha.Name = "rdoKha";
            this.rdoKha.Size = new System.Drawing.Size(66, 29);
            this.rdoKha.TabIndex = 40;
            this.rdoKha.TabStop = true;
            this.rdoKha.Text = "Khá";
            this.rdoKha.UseVisualStyleBackColor = false;
            // 
            // rdoTot
            // 
            this.rdoTot.AutoSize = true;
            this.rdoTot.BackColor = System.Drawing.Color.Transparent;
            this.rdoTot.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdoTot.Location = new System.Drawing.Point(86, 357);
            this.rdoTot.Name = "rdoTot";
            this.rdoTot.Size = new System.Drawing.Size(61, 29);
            this.rdoTot.TabIndex = 39;
            this.rdoTot.TabStop = true;
            this.rdoTot.Text = "Tốt";
            this.rdoTot.UseVisualStyleBackColor = false;
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.btnXuatBaoCao.BorderRadius = 10;
            this.btnXuatBaoCao.BorderThickness = 2;
            this.btnXuatBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXuatBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(178, 414);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(199, 45);
            this.btnXuatBaoCao.TabIndex = 36;
            this.btnXuatBaoCao.Text = "XUẤT BÁO CÁO";
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // txtTyLeThanhCong
            // 
            this.txtTyLeThanhCong.Location = new System.Drawing.Point(257, 176);
            this.txtTyLeThanhCong.Multiline = true;
            this.txtTyLeThanhCong.Name = "txtTyLeThanhCong";
            this.txtTyLeThanhCong.Size = new System.Drawing.Size(212, 30);
            this.txtTyLeThanhCong.TabIndex = 35;
            // 
            // txtTongUngVien
            // 
            this.txtTongUngVien.Location = new System.Drawing.Point(257, 120);
            this.txtTongUngVien.Multiline = true;
            this.txtTongUngVien.Name = "txtTongUngVien";
            this.txtTongUngVien.Size = new System.Drawing.Size(212, 30);
            this.txtTongUngVien.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(162, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "____________________________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(76, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "Đánh giá chất lượng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(76, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 25);
            this.label11.TabIndex = 28;
            this.label11.Text = "Tỷ lệ thành công:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(76, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "Tổng số ứng viên:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.label9.Location = new System.Drawing.Point(134, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(290, 35);
            this.label9.TabIndex = 26;
            this.label9.Text = "KẾT QUẢ TỔNG QUAN";
            // 
            // ThongKeTyLeKetNoi_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.btnTaoBaoCao);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Name = "ThongKeTyLeKetNoi_UC";
            this.Size = new System.Drawing.Size(1815, 803);
            this.Load += new System.EventHandler(this.ThongKeTyLeKetNoi_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTyLe)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTyLe;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phantich;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongUv;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.ComboBox cbThangQuy;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnTaoBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnTaiLai;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.RadioButton rdoCanCaiThien;
        private System.Windows.Forms.RadioButton rdoKha;
        private System.Windows.Forms.RadioButton rdoTot;
        private Guna.UI2.WinForms.Guna2Button btnXuatBaoCao;
        private System.Windows.Forms.TextBox txtTyLeThanhCong;
        private System.Windows.Forms.TextBox txtTongUngVien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCoViecLam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdQuy;
        private System.Windows.Forms.RadioButton rdThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdViTri;
        private System.Windows.Forms.RadioButton rdNhomNghe;
        private System.Windows.Forms.RadioButton rdNghe;
    }
}

