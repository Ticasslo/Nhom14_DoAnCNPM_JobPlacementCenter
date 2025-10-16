namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ERS
{
    partial class SelectDoanhNghiep_UC_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgvDoanhNghiep = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lbBangDN = new System.Windows.Forms.Label();
            this.btnluu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtmadoanhnghiep = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnlammoi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhNghiep)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Panel1.Controls.Add(this.lbTitle);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1164, 132);
            this.guna2Panel1.TabIndex = 8;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTitle.Location = new System.Drawing.Point(255, 63);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(626, 41);
            this.lbTitle.TabIndex = 133;
            this.lbTitle.Text = "CHỌN DOANH NGHIỆP MUỐN ĐĂNG TIN";
            // 
            // dgvDoanhNghiep
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvDoanhNghiep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoanhNghiep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDoanhNghiep.ColumnHeadersHeight = 4;
            this.dgvDoanhNghiep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoanhNghiep.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDoanhNghiep.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhNghiep.Location = new System.Drawing.Point(3, 344);
            this.dgvDoanhNghiep.Name = "dgvDoanhNghiep";
            this.dgvDoanhNghiep.RowHeadersVisible = false;
            this.dgvDoanhNghiep.RowHeadersWidth = 51;
            this.dgvDoanhNghiep.RowTemplate.Height = 24;
            this.dgvDoanhNghiep.Size = new System.Drawing.Size(1158, 253);
            this.dgvDoanhNghiep.TabIndex = 9;
            this.dgvDoanhNghiep.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhNghiep.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDoanhNghiep.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDoanhNghiep.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDoanhNghiep.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDoanhNghiep.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhNghiep.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDoanhNghiep.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvDoanhNghiep.ThemeStyle.ReadOnly = false;
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDoanhNghiep.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lbBangDN
            // 
            this.lbBangDN.AutoSize = true;
            this.lbBangDN.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBangDN.Location = new System.Drawing.Point(460, 306);
            this.lbBangDN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBangDN.Name = "lbBangDN";
            this.lbBangDN.Size = new System.Drawing.Size(181, 25);
            this.lbBangDN.TabIndex = 160;
            this.lbBangDN.Text = "Bảng Doanh nghiệp";
            // 
            // btnluu
            // 
            this.btnluu.BorderRadius = 20;
            this.btnluu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnluu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnluu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnluu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnluu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnluu.ForeColor = System.Drawing.Color.White;
            this.btnluu.Location = new System.Drawing.Point(461, 630);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(180, 45);
            this.btnluu.TabIndex = 176;
            this.btnluu.Text = "Chọn";
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.Controls.Add(this.btnlammoi);
            this.guna2Panel2.Controls.Add(this.btnTimKiem);
            this.guna2Panel2.Controls.Add(this.txtmadoanhnghiep);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(3, 166);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(594, 152);
            this.guna2Panel2.TabIndex = 179;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 20;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(200, 95);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(151, 45);
            this.btnTimKiem.TabIndex = 164;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
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
            this.txtmadoanhnghiep.Location = new System.Drawing.Point(261, 31);
            this.txtmadoanhnghiep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmadoanhnghiep.Name = "txtmadoanhnghiep";
            this.txtmadoanhnghiep.PlaceholderText = "";
            this.txtmadoanhnghiep.SelectedText = "";
            this.txtmadoanhnghiep.Size = new System.Drawing.Size(229, 48);
            this.txtmadoanhnghiep.TabIndex = 163;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 162;
            this.label1.Text = "Mã Doanh Nghiệp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 165;
            this.label2.Text = "Tìm kiếm";
            // 
            // btnlammoi
            // 
            this.btnlammoi.BorderRadius = 20;
            this.btnlammoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlammoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlammoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlammoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnlammoi.ForeColor = System.Drawing.Color.White;
            this.btnlammoi.Location = new System.Drawing.Point(406, 95);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(151, 45);
            this.btnlammoi.TabIndex = 165;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // SelectDoanhNghiep_UC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.lbBangDN);
            this.Controls.Add(this.dgvDoanhNghiep);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "SelectDoanhNghiep_UC_Form";
            this.Size = new System.Drawing.Size(1164, 753);
            this.Load += new System.EventHandler(this.SelectDoanhNghiep_UC_Form_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhNghiep)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDoanhNghiep;
        private System.Windows.Forms.Label lbBangDN;
        private Guna.UI2.WinForms.Guna2Button btnluu;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtmadoanhnghiep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnlammoi;
    }
}