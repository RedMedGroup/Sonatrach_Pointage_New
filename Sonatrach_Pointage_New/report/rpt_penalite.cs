using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Sonatrach_Pointage_New.report
{
    public partial class rpt_penalite : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 1;
        public rpt_penalite()
        {
            InitializeComponent();
            BindData();
            cell_n.BeforePrint += Cell_n_BeforePrint;   
        }

        private void Cell_n_BeforePrint(object sender, CancelEventArgs e)
        {
            cell_n.Text = (index++).ToString();
        }
        public void BindData()
        {
            cell_Department.DataBindings.Add("Text", this.DataSource, "Department");
            cell_TotalAbsences.DataBindings.Add("Text", this.DataSource, "TotalAbsences");
            cell_M_Penalite.DataBindings.Add("Text", this.DataSource, "M_Penalite");
            cell_TotalPenalties.DataBindings.Add("Text", this.DataSource, "TotalPenalties");

            string formattedDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("fr-FR"));
            lbl_date.Text = formattedDate;
        }
    }
}
