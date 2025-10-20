namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.SA
{
    partial class QLQuyenHan_Form
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
            this.lblMaTran = new System.Windows.Forms.Label();
            this.txtMoTaChucNang = new System.Windows.Forms.TextBox();
            this.txtVaiTro = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtChucNang = new System.Windows.Forms.TextBox();
            this.lblChucNang = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.DGVQuyenHan = new System.Windows.Forms.DataGridView();
            this.panelChiTiet = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuyenHan)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaTran
            // 
            this.lblMaTran.AutoSize = true;
            this.lblMaTran.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.lblMaTran.Location = new System.Drawing.Point(3, 57);
            this.lblMaTran.Name = "lblMaTran";
            this.lblMaTran.Size = new System.Drawing.Size(287, 38);
            this.lblMaTran.TabIndex = 85;
            this.lblMaTran.Text = "Ma trận phân quyền";
            // 
            // txtMoTaChucNang
            // 
            this.txtMoTaChucNang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTaChucNang.Location = new System.Drawing.Point(202, 153);
            this.txtMoTaChucNang.Name = "txtMoTaChucNang";
            this.txtMoTaChucNang.Size = new System.Drawing.Size(920, 34);
            this.txtMoTaChucNang.TabIndex = 100;
            // 
            // txtVaiTro
            // 
            this.txtVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVaiTro.Location = new System.Drawing.Point(19, 90);
            this.txtVaiTro.Name = "txtVaiTro";
            this.txtVaiTro.Size = new System.Drawing.Size(311, 34);
            this.txtVaiTro.TabIndex = 99;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTrangThai.Location = new System.Drawing.Point(885, 52);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(210, 28);
            this.lblTrangThai.TabIndex = 97;
            this.lblTrangThai.Text = "Trạng thái quyền hạn:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMoTa.Location = new System.Drawing.Point(18, 155);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(170, 28);
            this.lblMoTa.TabIndex = 94;
            this.lblMoTa.Text = "Mô tả chức năng:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(885, 88);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(237, 36);
            this.cbTrangThai.TabIndex = 91;
            // 
            // txtChucNang
            // 
            this.txtChucNang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChucNang.Location = new System.Drawing.Point(384, 90);
            this.txtChucNang.Name = "txtChucNang";
            this.txtChucNang.Size = new System.Drawing.Size(443, 34);
            this.txtChucNang.TabIndex = 90;
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = true;
            this.lblChucNang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucNang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChucNang.Location = new System.Drawing.Point(381, 53);
            this.lblChucNang.Name = "lblChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(216, 28);
            this.lblChucNang.TabIndex = 87;
            this.lblChucNang.Text = "Chức năng được chọn:";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVaiTro.Location = new System.Drawing.Point(20, 52);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(178, 28);
            this.lblVaiTro.TabIndex = 86;
            this.lblVaiTro.Text = "Vai trò được chọn:";
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Controls.Add(this.btnSua);
            this.panelHeader.Controls.Add(this.btnHuy);
            this.panelHeader.Controls.Add(this.btnLuu);
            this.panelHeader.Controls.Add(this.lblMaTran);
            this.panelHeader.Location = new System.Drawing.Point(29, 12);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelHeader.Size = new System.Drawing.Size(1116, 105);
            this.panelHeader.TabIndex = 100;
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 8;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnSua.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(603, 57);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(180, 48);
            this.btnSua.TabIndex = 95;
            this.btnSua.Text = "✏️ Chỉnh sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnHuy.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(975, 57);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 48);
            this.btnHuy.TabIndex = 97;
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
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(110)))), ((int)(((byte)(245)))));
            this.btnLuu.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(789, 57);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 48);
            this.btnLuu.TabIndex = 96;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // panelDGV
            // 
            this.panelDGV.Controls.Add(this.DGVQuyenHan);
            this.panelDGV.Location = new System.Drawing.Point(29, 123);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panelDGV.Size = new System.Drawing.Size(1116, 396);
            this.panelDGV.TabIndex = 101;
            // 
            // DGVQuyenHan
            // 
            this.DGVQuyenHan.AllowUserToAddRows = false;
            this.DGVQuyenHan.AllowUserToDeleteRows = false;
            this.DGVQuyenHan.AllowUserToResizeRows = false;
            this.DGVQuyenHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVQuyenHan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVQuyenHan.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGVQuyenHan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVQuyenHan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVQuyenHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVQuyenHan.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVQuyenHan.Location = new System.Drawing.Point(3, 2);
            this.DGVQuyenHan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVQuyenHan.MultiSelect = false;
            this.DGVQuyenHan.Name = "DGVQuyenHan";
            this.DGVQuyenHan.ReadOnly = true;
            this.DGVQuyenHan.RowHeadersVisible = false;
            this.DGVQuyenHan.RowHeadersWidth = 51;
            this.DGVQuyenHan.RowTemplate.Height = 24;
            this.DGVQuyenHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVQuyenHan.Size = new System.Drawing.Size(1151, 377);
            this.DGVQuyenHan.TabIndex = 98;
            this.DGVQuyenHan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVQuyenHan_CellClick);
            // 
            // panelChiTiet
            // 
            this.panelChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.panelChiTiet.Controls.Add(this.txtMoTaChucNang);
            this.panelChiTiet.Controls.Add(this.lblChiTiet);
            this.panelChiTiet.Controls.Add(this.txtVaiTro);
            this.panelChiTiet.Controls.Add(this.lblVaiTro);
            this.panelChiTiet.Controls.Add(this.lblTrangThai);
            this.panelChiTiet.Controls.Add(this.lblChucNang);
            this.panelChiTiet.Controls.Add(this.lblMoTa);
            this.panelChiTiet.Controls.Add(this.txtChucNang);
            this.panelChiTiet.Controls.Add(this.cbTrangThai);
            this.panelChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.panelChiTiet.Location = new System.Drawing.Point(29, 527);
            this.panelChiTiet.Name = "panelChiTiet";
            this.panelChiTiet.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelChiTiet.Radius = 12;
            this.panelChiTiet.ShadowColor = System.Drawing.Color.Black;
            this.panelChiTiet.ShadowDepth = 120;
            this.panelChiTiet.ShadowShift = 10;
            this.panelChiTiet.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.panelChiTiet.Size = new System.Drawing.Size(1116, 214);
            this.panelChiTiet.TabIndex = 102;
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.lblChiTiet.Location = new System.Drawing.Point(29, 5);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(214, 35);
            this.lblChiTiet.TabIndex = 82;
            this.lblChiTiet.Text = "Chi tiết thông tin";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(109)))), ((int)(((byte)(121)))));
            this.lblTieuDe.Location = new System.Drawing.Point(220, 5);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(630, 38);
            this.lblTieuDe.TabIndex = 101;
            this.lblTieuDe.Text = "QUẢN LÝ QUYỀN HẠN SỬ DỤNG CHỨC NĂNG";
            // 
            // QLQuyenHan_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.panelChiTiet);
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLQuyenHan_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.QLQuyenHan_Form_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuyenHan)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMaTran;
        private System.Windows.Forms.TextBox txtMoTaChucNang;
        private System.Windows.Forms.TextBox txtVaiTro;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.TextBox txtChucNang;
        private System.Windows.Forms.Label lblChucNang;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.DataGridView DGVQuyenHan;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelChiTiet;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.Label lblTieuDe;
    }
}