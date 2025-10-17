namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    partial class SelectDoanhNghiep1_UC_Form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbBangDN = new System.Windows.Forms.Label();
            this.dgvUngVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            this.txtmatintuyendung = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btntimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtmadoanhnghiep = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuat = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUngVien)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBangDN
            // 
            this.lbBangDN.AutoSize = true;
            this.lbBangDN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbBangDN.Location = new System.Drawing.Point(689, 123);
            this.lbBangDN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBangDN.Name = "lbBangDN";
            this.lbBangDN.Size = new System.Drawing.Size(237, 28);
            this.lbBangDN.TabIndex = 161;
            this.lbBangDN.Text = "Bảng danh sách ứng viên";
            // 
            // dgvUngVien
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvUngVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUngVien.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUngVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUngVien.ColumnHeadersHeight = 4;
            this.dgvUngVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUngVien.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUngVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUngVien.Location = new System.Drawing.Point(694, 157);
            this.dgvUngVien.Name = "dgvUngVien";
            this.dgvUngVien.RowHeadersVisible = false;
            this.dgvUngVien.RowHeadersWidth = 51;
            this.dgvUngVien.RowTemplate.Height = 24;
            this.dgvUngVien.Size = new System.Drawing.Size(1037, 527);
            this.dgvUngVien.TabIndex = 162;
            this.dgvUngVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUngVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUngVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUngVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUngVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUngVien.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.dgvUngVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUngVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUngVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUngVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUngVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUngVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUngVien.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvUngVien.ThemeStyle.ReadOnly = false;
            this.dgvUngVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUngVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUngVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUngVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUngVien.ThemeStyle.RowsStyle.Height = 24;
            this.dgvUngVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUngVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnXem
            // 
            this.btnXem.BorderRadius = 20;
            this.btnXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnXem.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(973, 725);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(234, 48);
            this.btnXem.TabIndex = 177;
            this.btnXem.Text = "Xem danh sách";
            this.btnXem.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            this.guna2Panel2.Controls.Add(this.btnlammoi);
            this.guna2Panel2.Controls.Add(this.txtmatintuyendung);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.btntimkiem);
            this.guna2Panel2.Controls.Add(this.txtmadoanhnghiep);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(38, 175);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(591, 328);
            this.guna2Panel2.TabIndex = 179;
            // 
            // btnlammoi
            // 
            this.btnlammoi.BorderRadius = 20;
            this.btnlammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlammoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnlammoi.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnlammoi.ForeColor = System.Drawing.Color.White;
            this.btnlammoi.Location = new System.Drawing.Point(326, 220);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(180, 45);
            this.btnlammoi.TabIndex = 167;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // txtmatintuyendung
            // 
            this.txtmatintuyendung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmatintuyendung.DefaultText = "";
            this.txtmatintuyendung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtmatintuyendung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtmatintuyendung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmatintuyendung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmatintuyendung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmatintuyendung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtmatintuyendung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmatintuyendung.Location = new System.Drawing.Point(276, 128);
            this.txtmatintuyendung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmatintuyendung.Name = "txtmatintuyendung";
            this.txtmatintuyendung.PlaceholderText = "";
            this.txtmatintuyendung.SelectedText = "";
            this.txtmatintuyendung.Size = new System.Drawing.Size(261, 48);
            this.txtmatintuyendung.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 165;
            this.label2.Text = "Mã Tin Tuyển Dụng:";
            // 
            // btntimkiem
            // 
            this.btntimkiem.BorderRadius = 20;
            this.btntimkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btntimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btntimkiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btntimkiem.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btntimkiem.ForeColor = System.Drawing.Color.White;
            this.btntimkiem.Location = new System.Drawing.Point(90, 220);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(185, 45);
            this.btntimkiem.TabIndex = 164;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // txtmadoanhnghiep
            // 
            this.txtmadoanhnghiep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmadoanhnghiep.DefaultText = "";
            this.txtmadoanhnghiep.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtmadoanhnghiep.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtmadoanhnghiep.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmadoanhnghiep.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmadoanhnghiep.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmadoanhnghiep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtmadoanhnghiep.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmadoanhnghiep.Location = new System.Drawing.Point(276, 63);
            this.txtmadoanhnghiep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmadoanhnghiep.Name = "txtmadoanhnghiep";
            this.txtmadoanhnghiep.PlaceholderText = "";
            this.txtmadoanhnghiep.SelectedText = "";
            this.txtmadoanhnghiep.Size = new System.Drawing.Size(261, 48);
            this.txtmadoanhnghiep.TabIndex = 163;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 162;
            this.label1.Text = "Mã Doanh Nghiệp:";
            // 
            // btnXuat
            // 
            this.btnXuat.BorderRadius = 20;
            this.btnXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1300, 725);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(234, 48);
            this.btnXuat.TabIndex = 180;
            this.btnXuat.Text = "Xuất danh sách";
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(33, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 167;
            this.label3.Text = "Tìm kiếm";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(109)))), ((int)(((byte)(121)))));
            this.lbTitle.Location = new System.Drawing.Point(794, 21);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(329, 38);
            this.lbTitle.TabIndex = 181;
            this.lbTitle.Text = "DANH SÁCH ỨNG VIÊN";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this.guna2Panel2;
            // 
            // SelectDoanhNghiep1_UC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvUngVien);
            this.Controls.Add(this.lbBangDN);
            this.Name = "SelectDoanhNghiep1_UC_Form";
            this.Size = new System.Drawing.Size(1815, 866);
            this.Load += new System.EventHandler(this.SelectDoanhNghiep1_UC_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUngVien)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbBangDN;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUngVien;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btntimkiem;
        private Guna.UI2.WinForms.Guna2TextBox txtmadoanhnghiep;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtmatintuyendung;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnXuat;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}