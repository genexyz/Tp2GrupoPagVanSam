namespace UI.Desktop
{
    partial class ReportePlanesViewer
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
            this.crystalReportViewerPlanes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerPlanes
            // 
            this.crystalReportViewerPlanes.ActiveViewIndex = 0;
            this.crystalReportViewerPlanes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerPlanes.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerPlanes.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerPlanes.Name = "crystalReportViewerPlanes";
            this.crystalReportViewerPlanes.ReportSource = "C:\\Users\\Gianluca\\source\\repos\\genexyz\\Tp2GrupoPagVanSam\\Util\\ReportePlanes.rpt";
            this.crystalReportViewerPlanes.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewerPlanes.TabIndex = 0;
            this.crystalReportViewerPlanes.Load += new System.EventHandler(this.crystalReportViewerPlanes_Load);
            // 
            // ReportePlanesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewerPlanes);
            this.Name = "ReportePlanesViewer";
            this.Text = "Reporte Planes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerPlanes;
    }
}