namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.FO
{
    partial class DanhSachHoaDon_UC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxBangDanhSachHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvBangDanhSachHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpBoxBoLoc = new System.Windows.Forms.GroupBox();
            this.btnBoLoc = new Guna.UI2.WinForms.Guna2Button();
            this.cbbIdDoanhNghiep = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbIdNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhatHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnXuaHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.grpBoxBangDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDanhSachHoaDon)).BeginInit();
            this.grpBoxBoLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxBangDanhSachHoaDon
            // 
            this.grpBoxBangDanhSachHoaDon.Controls.Add(this.dgvBangDanhSachHoaDon);
            this.grpBoxBangDanhSachHoaDon.Controls.Add(this.button1);
            this.grpBoxBangDanhSachHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpBoxBangDanhSachHoaDon.Location = new System.Drawing.Point(85, 241);
            this.grpBoxBangDanhSachHoaDon.Name = "grpBoxBangDanhSachHoaDon";
            this.grpBoxBangDanhSachHoaDon.Size = new System.Drawing.Size(1650, 535);
            this.grpBoxBangDanhSachHoaDon.TabIndex = 22;
            this.grpBoxBangDanhSachHoaDon.TabStop = false;
            this.grpBoxBangDanhSachHoaDon.Text = "          BẢNG DANH SÁCH HÓA ĐƠN";
            // 
            // dgvBangDanhSachHoaDon
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBangDanhSachHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBangDanhSachHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvBangDanhSachHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.dgvBangDanhSachHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangDanhSachHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBangDanhSachHoaDon.ColumnHeadersHeight = 4;
            this.dgvBangDanhSachHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBangDanhSachHoaDon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBangDanhSachHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBangDanhSachHoaDon.Location = new System.Drawing.Point(50, 48);
            this.dgvBangDanhSachHoaDon.Name = "dgvBangDanhSachHoaDon";
            this.dgvBangDanhSachHoaDon.RowHeadersVisible = false;
            this.dgvBangDanhSachHoaDon.RowHeadersWidth = 51;
            this.dgvBangDanhSachHoaDon.RowTemplate.Height = 24;
            this.dgvBangDanhSachHoaDon.Size = new System.Drawing.Size(1554, 460);
            this.dgvBangDanhSachHoaDon.TabIndex = 1;
            this.dgvBangDanhSachHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBangDanhSachHoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBangDanhSachHoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBangDanhSachHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBangDanhSachHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBangDanhSachHoaDon.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.dgvBangDanhSachHoaDon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBangDanhSachHoaDon.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvBangDanhSachHoaDon.ThemeStyle.ReadOnly = false;
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.Height = 24;
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBangDanhSachHoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // grpBoxBoLoc
            // 
            this.grpBoxBoLoc.Controls.Add(this.btnBoLoc);
            this.grpBoxBoLoc.Controls.Add(this.cbbIdDoanhNghiep);
            this.grpBoxBoLoc.Controls.Add(this.cbbIdNhanVien);
            this.grpBoxBoLoc.Controls.Add(this.label4);
            this.grpBoxBoLoc.Controls.Add(this.label3);
            this.grpBoxBoLoc.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpBoxBoLoc.Location = new System.Drawing.Point(85, 80);
            this.grpBoxBoLoc.Name = "grpBoxBoLoc";
            this.grpBoxBoLoc.Size = new System.Drawing.Size(1171, 141);
            this.grpBoxBoLoc.TabIndex = 16;
            this.grpBoxBoLoc.TabStop = false;
            this.grpBoxBoLoc.Text = "🔍 BỘ LỌC";
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnBoLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBoLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBoLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBoLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBoLoc.FillColor = System.Drawing.Color.White;
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnBoLoc.Location = new System.Drawing.Point(888, 51);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(137, 45);
            this.btnBoLoc.TabIndex = 22;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // cbbIdDoanhNghiep
            // 
            this.cbbIdDoanhNghiep.BackColor = System.Drawing.Color.Transparent;
            this.cbbIdDoanhNghiep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbIdDoanhNghiep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIdDoanhNghiep.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbIdDoanhNghiep.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbIdDoanhNghiep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbIdDoanhNghiep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbIdDoanhNghiep.ItemHeight = 30;
            this.cbbIdDoanhNghiep.Location = new System.Drawing.Point(199, 51);
            this.cbbIdDoanhNghiep.Name = "cbbIdDoanhNghiep";
            this.cbbIdDoanhNghiep.Size = new System.Drawing.Size(212, 36);
            this.cbbIdDoanhNghiep.TabIndex = 12;
            this.cbbIdDoanhNghiep.SelectedIndexChanged += new System.EventHandler(this.cbbIdDoanhNghiep_SelectedIndexChanged);
            // 
            // cbbIdNhanVien
            // 
            this.cbbIdNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.cbbIdNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbIdNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIdNhanVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbIdNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbIdNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbIdNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbIdNhanVien.ItemHeight = 30;
            this.cbbIdNhanVien.Location = new System.Drawing.Point(579, 52);
            this.cbbIdNhanVien.Name = "cbbIdNhanVien";
            this.cbbIdNhanVien.Size = new System.Drawing.Size(220, 36);
            this.cbbIdNhanVien.TabIndex = 11;
            this.cbbIdNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbbIdNhanVien_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(432, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "ID Nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(25, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID Doanh nghiệp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(109)))), ((int)(((byte)(121)))));
            this.label1.Location = new System.Drawing.Point(763, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 38);
            this.label1.TabIndex = 71;
            this.label1.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // btnCapNhatHoaDon
            // 
            this.btnCapNhatHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnCapNhatHoaDon.BorderRadius = 10;
            this.btnCapNhatHoaDon.BorderThickness = 2;
            this.btnCapNhatHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhatHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapNhatHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnCapNhatHoaDon.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatHoaDon.Location = new System.Drawing.Point(1462, 80);
            this.btnCapNhatHoaDon.Name = "btnCapNhatHoaDon";
            this.btnCapNhatHoaDon.Size = new System.Drawing.Size(273, 45);
            this.btnCapNhatHoaDon.TabIndex = 72;
            this.btnCapNhatHoaDon.Text = "CẬP NHẬT HÓA ĐƠN";
            this.btnCapNhatHoaDon.Click += new System.EventHandler(this.btnCapNhatHoaDon_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(1440, -97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 46);
            this.button1.TabIndex = 20;
            this.button1.Text = "CẬP NHẬT HÓA ĐƠN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnXuaHoaDon
            // 
            this.btnXuaHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnXuaHoaDon.BorderRadius = 10;
            this.btnXuaHoaDon.BorderThickness = 2;
            this.btnXuaHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuaHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuaHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuaHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuaHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnXuaHoaDon.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXuaHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXuaHoaDon.Location = new System.Drawing.Point(1516, 132);
            this.btnXuaHoaDon.Name = "btnXuaHoaDon";
            this.btnXuaHoaDon.Size = new System.Drawing.Size(219, 45);
            this.btnXuaHoaDon.TabIndex = 72;
            this.btnXuaHoaDon.Text = "XUẤT HÓA ĐƠN";
            this.btnXuaHoaDon.Click += new System.EventHandler(this.btnXuaHoaDon_Click);
            // 
            // btnXoaHoaDon
            // 
            this.btnXoaHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaHoaDon.BorderRadius = 10;
            this.btnXoaHoaDon.BorderThickness = 2;
            this.btnXoaHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaHoaDon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnXoaHoaDon.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoaHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXoaHoaDon.Location = new System.Drawing.Point(1543, 183);
            this.btnXoaHoaDon.Name = "btnXoaHoaDon";
            this.btnXoaHoaDon.Size = new System.Drawing.Size(192, 45);
            this.btnXoaHoaDon.TabIndex = 73;
            this.btnXoaHoaDon.Text = "XÓA HÓA ĐƠN";
            this.btnXoaHoaDon.Click += new System.EventHandler(this.btnXoaHoaDon_Click);
            // 
            // DanhSachHoaDon_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnXoaHoaDon);
            this.Controls.Add(this.btnXuaHoaDon);
            this.Controls.Add(this.btnCapNhatHoaDon);
            this.Controls.Add(this.grpBoxBangDanhSachHoaDon);
            this.Controls.Add(this.grpBoxBoLoc);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachHoaDon_UC";
            this.Size = new System.Drawing.Size(1815, 803);
            this.grpBoxBangDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDanhSachHoaDon)).EndInit();
            this.grpBoxBoLoc.ResumeLayout(false);
            this.grpBoxBoLoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBoxBangDanhSachHoaDon;
        private System.Windows.Forms.GroupBox grpBoxBoLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBangDanhSachHoaDon;
        private Guna.UI2.WinForms.Guna2ComboBox cbbIdDoanhNghiep;
        private Guna.UI2.WinForms.Guna2ComboBox cbbIdNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnBoLoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnCapNhatHoaDon;
        private Guna.UI2.WinForms.Guna2Button btnXuaHoaDon;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2Button btnXoaHoaDon;
    }
}