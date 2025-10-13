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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.DGVQuyenHan = new System.Windows.Forms.DataGridView();
            this.panelChiTiet = new System.Windows.Forms.Panel();
            this.txtMoTaChucNang = new System.Windows.Forms.TextBox();
            this.txtVaiTro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.txtChucNang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuyenHan)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(248, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(690, 41);
            this.label4.TabIndex = 81;
            this.label4.Text = "QUẢN LÝ QUYỀN HẠN SỬ DỤNG CHỨC NĂNG";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(305, 63);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(181, 48);
            this.btnSua.TabIndex = 84;
            this.btnSua.Text = "✏️ Chỉnh sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(287, 38);
            this.label7.TabIndex = 85;
            this.label7.Text = "Ma trận phân quyền";
            // 
            // DGVQuyenHan
            // 
            this.DGVQuyenHan.AllowUserToAddRows = false;
            this.DGVQuyenHan.AllowUserToDeleteRows = false;
            this.DGVQuyenHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVQuyenHan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVQuyenHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVQuyenHan.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVQuyenHan.Location = new System.Drawing.Point(10, 116);
            this.DGVQuyenHan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVQuyenHan.MultiSelect = false;
            this.DGVQuyenHan.Name = "DGVQuyenHan";
            this.DGVQuyenHan.ReadOnly = true;
            this.DGVQuyenHan.RowHeadersVisible = false;
            this.DGVQuyenHan.RowHeadersWidth = 51;
            this.DGVQuyenHan.RowTemplate.Height = 24;
            this.DGVQuyenHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVQuyenHan.Size = new System.Drawing.Size(1160, 419);
            this.DGVQuyenHan.TabIndex = 91;
            // 
            // panelChiTiet
            // 
            this.panelChiTiet.Controls.Add(this.txtMoTaChucNang);
            this.panelChiTiet.Controls.Add(this.txtVaiTro);
            this.panelChiTiet.Controls.Add(this.label9);
            this.panelChiTiet.Controls.Add(this.label2);
            this.panelChiTiet.Controls.Add(this.cbTrangThai);
            this.panelChiTiet.Controls.Add(this.txtChucNang);
            this.panelChiTiet.Controls.Add(this.label6);
            this.panelChiTiet.Controls.Add(this.label5);
            this.panelChiTiet.Controls.Add(this.label3);
            this.panelChiTiet.Location = new System.Drawing.Point(10, 540);
            this.panelChiTiet.Name = "panelChiTiet";
            this.panelChiTiet.Size = new System.Drawing.Size(1160, 201);
            this.panelChiTiet.TabIndex = 94;
            // 
            // txtMoTaChucNang
            // 
            this.txtMoTaChucNang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTaChucNang.Location = new System.Drawing.Point(196, 155);
            this.txtMoTaChucNang.Name = "txtMoTaChucNang";
            this.txtMoTaChucNang.Size = new System.Drawing.Size(961, 34);
            this.txtMoTaChucNang.TabIndex = 100;
            // 
            // txtVaiTro
            // 
            this.txtVaiTro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVaiTro.Location = new System.Drawing.Point(3, 92);
            this.txtVaiTro.Name = "txtVaiTro";
            this.txtVaiTro.Size = new System.Drawing.Size(322, 34);
            this.txtVaiTro.TabIndex = 99;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(874, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 28);
            this.label9.TabIndex = 97;
            this.label9.Text = "Trạng thái quyền hạn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 28);
            this.label2.TabIndex = 94;
            this.label2.Text = "Mô tả chức năng:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(879, 90);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(278, 36);
            this.cbTrangThai.TabIndex = 91;
            // 
            // txtChucNang
            // 
            this.txtChucNang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChucNang.Location = new System.Drawing.Point(377, 92);
            this.txtChucNang.Name = "txtChucNang";
            this.txtChucNang.Size = new System.Drawing.Size(443, 34);
            this.txtChucNang.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(372, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 28);
            this.label6.TabIndex = 87;
            this.label6.Text = "Chức năng được chọn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(2, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 28);
            this.label5.TabIndex = 86;
            this.label5.Text = "Vai trò được chọn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 38);
            this.label3.TabIndex = 82;
            this.label3.Text = "Chi tiết thông tin";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(492, 64);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(159, 48);
            this.btnLuu.TabIndex = 95;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(657, 63);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(159, 48);
            this.btnHuy.TabIndex = 96;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // QLQuyenHan_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.panelChiTiet);
            this.Controls.Add(this.DGVQuyenHan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLQuyenHan_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.QLQuyenHan_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVQuyenHan)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView DGVQuyenHan;
        private System.Windows.Forms.Panel panelChiTiet;
        private System.Windows.Forms.TextBox txtMoTaChucNang;
        private System.Windows.Forms.TextBox txtVaiTro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.TextBox txtChucNang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}