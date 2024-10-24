using DevExpress.PivotGrid.PivotTable;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Sonatrach_Pointage_New.DAL;
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
    public partial class Frm_MVM : DevExpress.XtraEditors.XtraForm
    {
        public Frm_MVM()
        {
            InitializeComponent();
        }

        private void Frm_MVM_Load(object sender, EventArgs e)
        {
            //dateEdit1.DateTime = DateTime.Now;
            InitializeLookUpEdit();
            gridView1.OptionsBehavior.Editable = false;
            dateEdit1.EditValueChanged += DateEdit1_EditValueChanged;
            gridView1.PopulateColumns();
            gridView1.BestFitColumns();
            gridView1.RowCellStyle += GridView1_RowCellStyle;
            gridView1.CellMerge += GridView1_CellMerge;
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;
        }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Column.FieldName == "Statut")
            {
                if (string.IsNullOrEmpty(e.CellValue as string))
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }

        private void GridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Column.FieldName == "Poste" )
            {
                string value1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string value2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);

                // دمج الخلايا إذا كانت القيم متساوية أو إذا كانت القيم فارغة تحت نفس الـ 
                if (value1 == value2 || string.IsNullOrEmpty(value2))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }

                e.Handled = true;
            }
            else
            {
                e.Merge = false;
            }
            e.Handled = true;
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Statut")
            {
                string cellValue = e.CellValue?.ToString();

                if (cellValue == "P")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else if (cellValue == "A")
                {
                    e.Appearance.BackColor = Color.LightCoral;
                }
                else if (cellValue == "CR")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#FFA726");
                }
                else if (cellValue == "CE")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#FFE082");
                }
                else if (cellValue == "M")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#F48FB1");
                }
                else if (cellValue == "AA")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#FF9E80");
                }
            }
            if (e.Column.FieldName == "Poste")
            {
                string cellValue = e.CellValue?.ToString();
                if (cellValue != "")
                    e.Appearance.BackColor = Color.Yellow;
            }
            if (e.Column.FieldName == "Date de retour de congée")
            {
                if (e.CellValue == null || e.CellValue == DBNull.Value)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White; 
                }
            }
            if (e.Column.FieldName == "Jour de travail")
            {
                if (e.CellValue == null || e.CellValue == DBNull.Value)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            if (e.Column.FieldName == "Date de début de congée")
            {
                if (e.CellValue == null || e.CellValue == DBNull.Value)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            if (e.Column.FieldName == "Jours de congée")
            {
                if (e.CellValue == null || e.CellValue == DBNull.Value)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void DateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            #region
            if (dateEdit1.EditValue == null)
            {
                return;
            }
            var dbc = new DAL.DataClasses1DataContext();
            DateTime todayDate = dateEdit1.DateTime;
            DateTime yesterdayDate = todayDate.AddDays(-1);
            var yesterdayRecord = dbc.P_Heders.FirstOrDefault(w => w.Date == yesterdayDate);
            if (yesterdayRecord == null)
            {
                MessageBox.Show("Date d'hier introuvable.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControl1.DataSource=null;
                dateEdit1.EditValue=null;
                return;
            }
            var existingRecord = dbc.P_Heders.FirstOrDefault(w => w.Date == dateEdit1.DateTime);
            if (existingRecord != null)
            {
                MessageBox.Show("Il existe un enregistrement daté d'aujourd'hui. Vous ne pouvez pas ajouter un nouvel enregistrement");
                gridControl1.DataSource = null;
                dateEdit1.EditValue=null;
                return;
            }
            #endregion
            gridView1.OptionsView.AllowCellMerge = !gridView1.OptionsView.AllowCellMerge;
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            CreateEmployeeReport();
            gridControl1.DataSource = CreateEmployeeReport();
           
        }

 
        private void InitializeLookUpEdit()
        {
            //lookUpEditStatut.Properties.Items.AddRange(new[] { "P", "A", "AA", "M", "CR", "CE" });
            //lookUpEditStatut.EditValue = "P"; // تعيين قيمة افتراضية
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue == null)
            {
                MessageBox.Show("La date sélectionnée est vide. Veuillez choisir une date.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable employeeTable = CreateEmployeeReport();
            if (employeeTable.Rows.Count > 0)
            {
                SaveEmployeeReport(employeeTable);
            }
        }
      
        private DataTable CreateEmployeeReport()
        {
            DateTime selectedDate = dateEdit1.DateTime;
            DataTable table = new DataTable();

            table.Columns.Add("Poste", typeof(string));
            table.Columns.Add("Nom et Prénom", typeof(string));
            table.Columns.Add("Date de retour de congée", typeof(DateTime));
            table.Columns.Add("Jour de travail", typeof(int));
            table.Columns.Add("Date de début de congée", typeof(DateTime));
            table.Columns.Add("Jours de congée", typeof(int));
            table.Columns.Add("Statut", typeof(string)); 

            using (var context = new DAL.DataClasses1DataContext())
            {
                var agentData = (from agent in context.Fich_Agents
                                 join post in context.Fiche_DePosts on agent.ID_Post equals post.ID
                                 select new
                                 {
                                     DepartmentName = post.Name,
                                     EmployeeName = agent.Name,                                 
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
                        row["Poste"] = agent.DepartmentName;
                        row["Nom et Prénom"] = agent.EmployeeName;
                        row["Date de retour des vacances"] = DBNull.Value;
                        row["Jour de travail"] = DBNull.Value;
                        row["Date de début des vacances"] = DBNull.Value;
                        row["Jours de vacances"] = DBNull.Value;
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

                        // إيجاد أول يوم حضور (P) بعد آخر يوم إجازة (CR)
                        var firstPresentDayAfterVacation = (from details in context.P_Details
                                                            join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                                            where details.ItemID == agent.AgentID && details.Statut == "P" && headers.Date > lastVacationDay
                                                            orderby headers.Date
                                                            select headers.Date).FirstOrDefault();

                        // إيجاد آخر يوم حضور (P) قبل التاريخ المحدد
                        var lastPresentDay = (from details in context.P_Details
                                              join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                              where details.ItemID == agent.AgentID && details.Statut == "P" && headers.Date <= selectedDate
                                              orderby headers.Date descending
                                              select headers.Date).FirstOrDefault();

                        // إيجاد أول يوم إجازة (CR) بعد آخر يوم حضور
                        var firstVacationDayAfterLastPresent = (from details in context.P_Details
                                                                join headers in context.P_Heders on details.ID_Heder equals headers.ID
                                                                where details.ItemID == agent.AgentID && details.Statut == "CR" && headers.Date > lastPresentDay
                                                                orderby headers.Date
                                                                select headers.Date).FirstOrDefault();

                     

                        // حساب عدد أيام العمل إذا كان الموظف قد عاد من الإجازة
                        int? workingDays = null;
                        if (firstPresentDayAfterVacation != DateTime.MinValue && firstPresentDayAfterVacation <= selectedDate)
                        {
                            workingDays = (selectedDate - firstPresentDayAfterVacation).Days + 1;
                        }

                        // حساب عدد أيام العطلة إذا كان الموظف في عطلة
                        int? vacationDays = null;
                        if (firstVacationDayAfterLastPresent != DateTime.MinValue &&
                            (firstPresentDayAfterVacation == DateTime.MinValue || firstVacationDayAfterLastPresent < firstPresentDayAfterVacation))
                        {
                            vacationDays = (selectedDate - firstVacationDayAfterLastPresent).Days + 1;
                        }
                        string status = "M";
                        if (workingDays.HasValue && workingDays.Value >28)
                        {
                            status = "CR";
                        }
                        else if (workingDays.HasValue && workingDays.Value <= 28)
                        {
                            status = "P";
                        }
                        else if (vacationDays.HasValue && vacationDays.Value <= 28)
                        {
                            status = "CR";
                        }
                        else if (vacationDays.HasValue && vacationDays.Value > 28)
                        {
                            status = "P";
                        }

                        // إضافة البيانات إلى الجدول
                        DataRow row = table.NewRow();
                        row["Poste"] = agent.DepartmentName;
                        row["Nom et Prénom"] = agent.EmployeeName;
                        row["Date de retour de congée"] = firstPresentDayAfterVacation != DateTime.MinValue ? (object)firstPresentDayAfterVacation : DBNull.Value;
                        row["Jour de travail"] = workingDays.HasValue ? (object)workingDays.Value : DBNull.Value;
                        row["Date de début de congée"] = firstVacationDayAfterLastPresent != DateTime.MinValue ? (object)firstVacationDayAfterLastPresent : DBNull.Value;
                        row["Jours de congée"] = vacationDays.HasValue ? (object)vacationDays.Value : DBNull.Value;
                        row["Statut"] = status; 

                        table.Rows.Add(row);
                    }
                }
            }

            return table;
        }

        private void SaveEmployeeReport(DataTable employeeTable)
        {
            #region
            var dbc = new DAL.DataClasses1DataContext();
            DateTime todayDate = dateEdit1.DateTime;
            DateTime yesterdayDate = todayDate.AddDays(-1);
            var yesterdayRecord = dbc.P_Heders.FirstOrDefault(w => w.Date == yesterdayDate);
            if (yesterdayRecord == null)
            {
                MessageBox.Show("Date d'hier introuvable.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var existingRecord = dbc.P_Heders.FirstOrDefault(w => w.Date == dateEdit1.DateTime);
            if (existingRecord != null)
            {
                MessageBox.Show("Il existe un enregistrement daté d'aujourd'hui. Vous ne pouvez pas ajouter un nouvel enregistrement");
                return;
            }
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("Il n'y a aucune donnée dans le tableau. Vous ne pouvez pas sauvegarder un enregistrement vide.");
                return;
            }
            #endregion


            DateTime selectedDate = dateEdit1.DateTime;

            using (var context = new DAL.DataClasses1DataContext())
            {
                // حفظ التاريخ في P_Heders إذا لم يكن موجودًا
                var header = context.P_Heders.FirstOrDefault(h => h.Date == selectedDate);
                if (header == null)
                {
                    header = new DAL.P_Heder
                    {
                        Date = selectedDate
                    };
                    context.P_Heders.InsertOnSubmit(header);
                    context.SubmitChanges();
                }

                // الآن لدينا ID_Heder لحفظ البيانات في P_Details
                int headerID = header.ID;

                // حفظ البيانات في P_Details
                foreach (DataRow row in employeeTable.Rows)
                {
                    // الحصول على ItemID (الممثل لـ agent.ID) و Statut من الجدول
                    string employeeName = row["Nom et Prénom"].ToString();
                    string status = row["Statut"].ToString();

                    // إيجاد ID الموظف باستخدام اسمه
                    var agent = context.Fich_Agents.FirstOrDefault(a => a.Name == employeeName);
                    if (agent != null)
                    {
                        int agentID = agent.ID;

                        // إضافة سجل جديد في P_Details
                        var detail = new DAL.P_Detail
                        {
                            ID_Heder = headerID,
                            ItemID = agentID,
                            Statut = status
                        };
                        context.P_Details.InsertOnSubmit(detail);
                    }
                }

                // حفظ التغييرات
                context.SubmitChanges();
            }

            // إظهار رسالة النجاح
            MessageBox.Show("تم حفظ البيانات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}