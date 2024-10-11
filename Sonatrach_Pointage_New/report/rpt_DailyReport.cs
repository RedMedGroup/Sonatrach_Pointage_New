using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Sonatrach_Pointage_New.report
{
    public partial class rpt_DailyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_DailyReport()
        {
            InitializeComponent();
            BindData();
            cell_Department.BeforePrint += Cell_Department_BeforePrint;
            cell_ncontra.BeforePrint += Cell_ncontra_BeforePrint;
            cell_n.BeforePrint += Cell_n_BeforePrint;
            Cell_PresentCount.BeforePrint += Cell_PresentCount_BeforePrint;
        }
        private string lastPresent = null;
        private string lastSection = null;
        private int rowNumber = 0;
        private int presentCount = 0;
        private void Cell_PresentCount_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = (XRTableCell)sender;
            string currentSection = cell.Report.GetCurrentColumnValue("Department").ToString();
            int currentPresentCount = Convert.ToInt32(cell.Report.GetCurrentColumnValue("PresentCount"));
            if (currentSection != lastSection)
            {
                rowNumber = 0;
                presentCount = currentPresentCount;
            }

            rowNumber++;

            if (rowNumber == 1)
            {
                cell.Text = presentCount.ToString();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.RowSpan = cell.Report.GetCurrentColumnValue("SectionRowCount") != null ? Convert.ToInt32(cell.Report.GetCurrentColumnValue("SectionRowCount")) : 1;
                //cell.Borders = DevExpress.XtraPrinting.BorderSide.None;
            }
            else
            {
                cell.Text = string.Empty;
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            }

            lastSection = currentSection;
        }

        int index = 1;
        private void Cell_n_BeforePrint(object sender, CancelEventArgs e)
        {
            cell_n.Text = (index++).ToString();
        }
        private string lastDepartment = null;
        private int mergeCount = 0; // عدد الصفوف المدمجة
        private void Cell_ncontra_BeforePrint(object sender, CancelEventArgs e)
        {

            XRTableCell cell = (XRTableCell)sender;
            string currentDepartment = cell.Report.GetCurrentColumnValue("Department")?.ToString();

            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            if (currentDepartment == lastDepartment)
            {
                cell.Text = string.Empty;
            }
            else
            {
                cell.Text = cell.Text;
            }

            lastDepartment = currentDepartment;
        }

        private void Cell_Department_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = (XRTableCell)sender;

            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            cell.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
            cell.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Value;

            cell.Text = cell.Text;
        }
        public void BindData()
        {
            cell_Department.DataBindings.Add("Text", this.DataSource, "Department");
            cell_ncontra.DataBindings.Add("Text", this.DataSource, "RequiredEmployees");
            cell_M_Penalite.DataBindings.Add("Text", this.DataSource, "WorkerName");
            cell_TotalPenalties.DataBindings.Add("Text", this.DataSource, "Status");

            string formattedDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("fr-FR"));
            lbl_date.Text = formattedDate;
        }
    }
}
