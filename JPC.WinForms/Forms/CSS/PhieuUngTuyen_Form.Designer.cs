namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS
{
    partial class PhieuUngTuyen_Form
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
            this.phieuUngTuyenReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // phieuUngTuyenReport
            // 
            this.phieuUngTuyenReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phieuUngTuyenReport.Location = new System.Drawing.Point(0, 0);
            this.phieuUngTuyenReport.Name = "phieuUngTuyenReport";
            this.phieuUngTuyenReport.ServerReport.BearerToken = null;
            this.phieuUngTuyenReport.Size = new System.Drawing.Size(2875, 1756);
            this.phieuUngTuyenReport.TabIndex = 0;
            // 
            // PhieuUngTuyen_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2875, 1756);
            this.Controls.Add(this.phieuUngTuyenReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PhieuUngTuyen_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhieuUngTuyen_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhieuUngTuyen_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer phieuUngTuyenReport;
    }
}