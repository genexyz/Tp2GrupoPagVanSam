using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Util;

namespace UI.Desktop
{
    public partial class ReportePlanesViewer : Form
    {
        public ReportePlanesViewer()
        {
            InitializeComponent();
        }

        /*private void ReportePlanesViewer_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new Util.ReportePlanes();
            this.crystalReportViewerPlanes.ReportSource = rd;
            this.crystalReportViewerPlanes.Show();
        }*/

        private void crystalReportViewerPlanes_Load(object sender, EventArgs e)
        {

        }
    }
}
