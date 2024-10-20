﻿using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Sonatrach_Pointage_New.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sonatrach_Pointage_New.Form
{
    public partial class Frm_WorkDays : DevExpress.XtraEditors.XtraForm
    {
        public Frm_WorkDays()
        {
            InitializeComponent();
        }

        private void Frm_WorkDays_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = true;

            gridControl1.DataSource = CreateEmployeeReport();
            gridView1.PopulateColumns();
            gridView1.BestFitColumns();
            gridView1.RowCellStyle += GridView1_RowCellStyle;
        }

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Jours ouvrables")
            {
                // تحويل القيمة إلى double
                double cellValue;
                if (double.TryParse(e.CellValue?.ToString(), out cellValue))
                {
                    if (cellValue >= 28)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#F44336");

                    }
                    else if (cellValue <= 28)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#7CB342");
                    }
                }
            }
        }
        private DataTable CreateEmployeeReport()
        {
            DateTime selectedDate = dateEdit1.DateTime;
            DataTable table = new DataTable();


            using (var context = new DAL.DataClasses1DataContext())
            {
                // التحقق من وجود التاريخ المحدد
                bool dateExists = context.P_Heders.Any(header => header.Date == selectedDate);

                if (!dateExists)
                {
                    // إذا لم يتم العثور على التاريخ، قم بإرجاع أو إظهار رسالة
                    MessageBox.Show("La date indiquée n'existe pas", "avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return table; // العودة من الدالة
                }

            }

            // إضافة الأعمدة المطلوبة
            table.Columns.Add("Nom et Prénom", typeof(string));
            table.Columns.Add("Poste", typeof(string));
            table.Columns.Add("Date de retour des vacances", typeof(DateTime));
            table.Columns.Add("Jours ouvrables", typeof(int));
            table.Columns.Add("Statut", typeof(string)); // إضافة عمود جديد للحالة


            // ربط البيانات باستخدام LINQ
            using (var context = new DAL.DataClasses1DataContext())
            {
                var agentData = (from agent in context.Fich_Agents
                                 join post in context.Fiche_DePosts on agent.ID_Post equals post.ID
                                 select new
                                 {
                                     EmployeeName = agent.Name,
                                     DepartmentName = post.Name,
                                     AgentID = agent.ID,
                                     PostID = post.ID,
                                     IsActive = agent.IsActive
                                 }).ToList();

                foreach (var agent in agentData)
                {
                    if (agent.IsActive == false)
                    {
                        // إضافة الموظف مع النص "توقف عن العمل" إذا كان غير نشط
                        DataRow row = table.NewRow();
                        row["Nom et Prénom"] = agent.EmployeeName;
                        row["Poste"] = agent.DepartmentName;
                        row["Date de retour des vacances"] = DBNull.Value;
                        row["Jours ouvrables"] = DBNull.Value;
                        row["Statut"] = "Arrêter de travailler";
                        table.Rows.Add(row);
                    }
                    else
                    {
                        // إيجاد آخر يوم إجازة (CR) قبل التاريخ المحدد
                        var lastVacationDay = (from details in context.P_Details
                                               join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                               where details.ItemID == agent.AgentID && details.Statut == "CR" && headers.Date <= selectedDate
                                               orderby headers.Date descending
                                               select headers.Date).FirstOrDefault();

                        // إيجاد أول يوم حضور (P) بعد آخر إجازة (CR)
                        var firstPresentDayAfterVacation = (from details in context.P_Details
                                                            join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                                            where details.ItemID == agent.AgentID && details.Statut == "P" && headers.Date > lastVacationDay
                                                            orderby headers.Date
                                                            select headers.Date).FirstOrDefault();

                        // التحقق مما إذا كان التاريخ المحدد بعد آخر يوم حضور (P)
                        var lastPresentDayBeforeSelected = (from details in context.P_Details
                                                            join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                                            where details.ItemID == agent.AgentID && details.Statut == "P" && headers.Date <= selectedDate
                                                            orderby headers.Date descending
                                                            select headers.Date).FirstOrDefault();

                        // إذا كان الموظف قد عاد من الإجازة وكان التاريخ المحدد بعد عودته
                        if (firstPresentDayAfterVacation != DateTime.MinValue &&
                            firstPresentDayAfterVacation <= selectedDate &&
                            lastPresentDayBeforeSelected != DateTime.MinValue)
                        {
                            // حساب عدد أيام العمل منذ آخر يوم حضور بعد الإجازة
                            int workingDays = (selectedDate - firstPresentDayAfterVacation).Days;

                            // إضافة البيانات إلى الجدول
                            DataRow row = table.NewRow();
                            row["Nom et Prénom"] = agent.EmployeeName;
                            row["Poste"] = agent.DepartmentName;
                            row["Date de retour des vacances"] = firstPresentDayAfterVacation;
                            row["Jours ouvrables"] = workingDays;
                            row["Statut"] = "Active";
                            table.Rows.Add(row);
                        }
                    }
                }
                  
            }

            return table;
        }

        private void PrintWorkDayReport()
        {
            // إنشاء الجدول باستخدام الدالة CreateEmployeeReport
            DataTable workDaysTable = CreateEmployeeReport();

            // التحقق من وجود بيانات في الجدول
            if (workDaysTable.Rows.Count == 0)
            {
                MessageBox.Show("Il n'y a aucune donnée à afficher dans le rapport.", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string reportTitle = checkEdit1.Checked ?
        "Rapport des Employés avec plus de 28 jours de travail" :
        "Rapport des Jours de Travail";
            if (checkEdit1.Checked)
            {

                var filteredRows = workDaysTable.AsEnumerable()
                                    .Where(row => row.Field<int?>("Jours ouvrables") > 28);

                if (!filteredRows.Any())
                {
                    MessageBox.Show("Il n'y a pas de données pour les personnes de plus de 28 jours.", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                workDaysTable = filteredRows.CopyToDataTable();

            }
            rpt_WorkDay report = new rpt_WorkDay();

            report.DataSource = workDaysTable;
            report.FindControl("xrLabel1", true).Text = reportTitle;
            report.FindControl("cell_nom", true).DataBindings.Add("Text", null, "Nom et Prénom");
            report.FindControl("cell_poste", true).DataBindings.Add("Text", null, "Poste");
            report.FindControl("cell_date", true).DataBindings.Add("Text", null, "Date de retour des vacances", "{0:dd/MM/yyyy}");
            report.FindControl("cell_jour", true).DataBindings.Add("Text", null, "Jours ouvrables");

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintWorkDayReport();
        }
    }
}