using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
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
using Sonatrach_Pointage_New.report;
using Sonatrach_Pointage_New.Classe;
using static Sonatrach_Pointage_New.Classe.Master;

namespace Sonatrach_Pointage_New.Form
{
    public partial class Frm_Statistique : DevExpress.XtraEditors.XtraForm
    {
        List<DAL.P_Heder> listOfDays;
        List<DAL.P_Detail> P_Details;
        List<DAL.Fich_Agent> FicheAgentList;
        public Frm_Statistique()
        {
            InitializeComponent();
        }

        private void Frm_Statistique_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = true;

            DateTime today = DateTime.Today;
            dateEdit1.DateTime = new DateTime(today.Year, today.Month, 1);

            dateEdit2.DateTime = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            //dateEdit1.DateTime = DateTime.Now;
            //dateEdit2.DateTime = dateEdit1.DateTime.AddDays(30);
            dateEdit1.EditValueChanged += DateEdit1_EditValueChanged;
            dateEdit2.EditValueChanged += DateEdit2_EditValueChanged;
            gridView1.RowCellStyle += GridView1_RowCellStyle;
            gridView1.CellMerge += GridView1_CellMerge;
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;
        
    }

        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Column.FieldName == "POSTE")
            {
                if (string.IsNullOrEmpty(e.CellValue as string))
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }

        private void GridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Column.FieldName == "POSTE" || e.Column.FieldName == "EFECTIF/CONTRAT")
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

        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "POSTE")
            {
                string cellValue = e.CellValue?.ToString();
                if (cellValue != "")
                    e.Appearance.BackColor = Color.Yellow;
            }

            if (e.Column.FieldName == "EFECTIF/CONTRAT")
            {
                string cellValue = e.CellValue?.ToString();
                if (cellValue != "")
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#FFECB3");
            }
            if (e.Column.FieldName == "Name")
            {
                string cellValue = e.CellValue?.ToString();
                if (cellValue == "P/Total" || cellValue == "A/Total")
                {
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#00897B");

                }
            }
            if (e.Column.FieldName != "POSTE" && e.Column.FieldName != "Name")
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
                else
                {
                    int cellValue1;
                    if (int.TryParse(cellValue, out cellValue1))
                    {
                        if (cellValue1 > 0)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml("#4DB6AC");
                        }
                    }
                }
            }
        }

        private void DateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateEdit2.DateTime;

            // ضبط dateEdit1 ليكون اليوم الأول من الشهر المحدد في dateEdit2
            dateEdit1.DateTime = new DateTime(selectedDate.Year, selectedDate.Month, 1);
        }
    

        private void DateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //dateEdit2.DateTime = dateEdit1.DateTime.AddDays(29);
            DateTime selectedDate = dateEdit1.DateTime;

            // حساب عدد الأيام المتبقية في الشهر
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int remainingDays = daysInMonth - selectedDate.Day;

            // تحديث dateEdit2 ليكون في آخر الشهر
            dateEdit2.DateTime = selectedDate.AddDays(remainingDays);
        }

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("POSTE", typeof(string));
            table.Columns.Add("EFECTIF/CONTRAT", typeof(int));
            table.Columns.Add("Name", typeof(string));

            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;

            // التحقق من أن التاريخ الابتدائي أصغر أو يساوي التاريخ النهائي
            if (startDate > endDate)
            {
                MessageBox.Show("La date de début doit être antérieure ou égale à la date de fin.");
                return table;
            }

            // حساب المدة الزمنية
            TimeSpan dateRange = endDate - startDate;
            int totalDays = dateRange.Days + 1;

            // إضافة أعمدة التواريخ بشكل ديناميكي
            for (int i = 0; i < totalDays; i++)
            {
                DateTime currentDay = startDate.AddDays(i);
                table.Columns.Add($"{currentDay.Day}", typeof(string)); // إضافة كل يوم كعمود
            }

            // إضافة عمود للحساب الإجمالي
            table.Columns.Add("Total", typeof(int));

            var context = new DAL.DataClasses1DataContext();
            var groups = FicheAgentList.GroupBy(agent => agent.ID_Post)
                .Select(g => new
                {
                    Specialization = context.Fiche_DePosts.FirstOrDefault(sp => sp.ID == g.Key)?.Name,
                    RequiredQuantity = context.Fiche_DePosts.FirstOrDefault(sp => sp.ID == g.Key)?.Nembre_Contra ?? 0,
                    Agents = g.ToList()
                });

            foreach (var group in groups)
            {
                // إضافة صف للتخصص
                DataRow specializationRow = table.NewRow();
                specializationRow["POSTE"] = group.Specialization;
                specializationRow["EFECTIF/CONTRAT"] = group.RequiredQuantity;
                table.Rows.Add(specializationRow);

                // مصفوفة لتخزين الحضور والغياب
                int[] presentCountPerDay = new int[totalDays];
                int[] absentCountPerDay = new int[totalDays];

                foreach (var agent in group.Agents)
                {
                    DataRow row = table.NewRow();
                    row["Name"] = agent.Name;

                    for (int i = 0; i < totalDays; i++)
                    {
                        DateTime currentDay = startDate.AddDays(i);
                        var header = listOfDays.FirstOrDefault(h => h.Date.Date == currentDay.Date);

                        if (header != null)
                        {
                            var attendance = P_Details.FirstOrDefault(d => d.ItemID == agent.ID && d.ID_Heder == header.ID);

                            if (attendance != null)
                            {
                                if (attendance.Statut == "P")
                                {
                                    row[$"{currentDay.Day}"] = "P";
                                    presentCountPerDay[i]++; // حساب عدد الحضور لليوم الحالي
                                }
                                else if (attendance.Statut == "A")
                                {
                                    row[$"{currentDay.Day}"] = "A";
                                    absentCountPerDay[i]++; // حساب عدد الغياب لليوم الحالي
                                }
                                else if (attendance.Statut == "CR")
                                {
                                    row[$"{currentDay.Day}"] = "CR";
                                }
                                else if (attendance.Statut == "CE")
                                {
                                    row[$"{currentDay.Day}"] = "CE";
                                }
                                else if (attendance.Statut == "M")
                                {
                                    row[$"{currentDay.Day}"] = "M";
                                }
                                else if (attendance.Statut == "AA")
                                {
                                    row[$"{currentDay.Day}"] = "AA";
                                }
                            }
                            else
                            {
                                row[$"{currentDay.Day}"] = "Error";
                            }
                        }
                        else
                        {
                            row[$"{currentDay.Day}"] = " ";
                        }
                    }
                    table.Rows.Add(row);
                }

                // إضافة صف لحساب الحضور "P/Total"
                DataRow presentCountRow = table.NewRow();
                presentCountRow["Name"] = "P/Total";
                int totalPresent = 0; // مجموع الحضور

                for (int i = 0; i < totalDays; i++)
                {
                    presentCountRow[$"{startDate.AddDays(i).Day}"] = presentCountPerDay[i].ToString();
                    totalPresent += presentCountPerDay[i];
                }
                presentCountRow["Total"] = totalPresent; // تخزين المجموع
                table.Rows.Add(presentCountRow);

                // إضافة صف لحساب الغياب "A/Total"
                DataRow absentCountRow = table.NewRow();
                absentCountRow["Name"] = "A/Total";
                int totalAbsent = 0; // مجموع الغياب

                for (int i = 0; i < totalDays; i++)
                {
                    absentCountRow[$"{startDate.AddDays(i).Day}"] = absentCountPerDay[i].ToString();
                    totalAbsent += absentCountPerDay[i];
                }
                absentCountRow["Total"] = totalAbsent; // تخزين المجموع
                table.Rows.Add(absentCountRow);
            }
            return table;
        }
        private void LoadData()
        {
            using (var context = new DAL.DataClasses1DataContext())
            {
                listOfDays = context.P_Heders.ToList();

                P_Details = context.P_Details.ToList();
                FicheAgentList = context.Fich_Agents.ToList();
            }
        }
        private void btn_recharch_Click(object sender, EventArgs e)
        {
            LoadData();

            gridControl1.DataSource = CreateDataTable();

            gridView1.PopulateColumns();
            gridView1.BestFitColumns();
            gridView1.OptionsView.AllowCellMerge = !gridView1.OptionsView.AllowCellMerge;

        }

        private void PrintReport()
        {

            report.rpt_pointage report = new report.rpt_pointage();

            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;
            report.AddDateColumnsToReport(report, startDate, endDate);
            DataTable table = CreateDataTable();
            report.DataSource = table;

            report.BindAttendanceDataToCells(table);

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }
        private DataTable CreateAbsenceReport(int totalDays, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("TotalAbsences", typeof(int));
            table.Columns.Add("M_Penalite", typeof(float));
            table.Columns.Add("TotalPenalties", typeof(float));


            using (var context = new DAL.DataClasses1DataContext())
            {
                // الحصول على بيانات الغيابات وتجميعها حسب ItemID مع ربطها بـ P_Heders للحصول على التاريخ
                var absenceData = context.P_Details
                    .Join(context.P_Heders, detail => detail.ID_Heder, header => header.ID,
                        (detail, header) => new { detail, header })
                    .Where(joined => joined.detail.Statut == "A"
                        && joined.header.Date >= startDate
                        && joined.header.Date <= endDate) // تصفية بالتاريخ
                    .GroupBy(joined => joined.detail.ItemID) // تجميع البيانات حسب ItemID
                    .Select(g => new
                    {
                        ItemID = g.Key, // ItemID يمثل ID الفرد
                        TotalAbsences = g.Count() // حساب عدد الغيابات
                    })
                    .ToList();

                // الحصول على الأقسام والبيانات المرتبطة بها
                var departmentData = context.Fich_Agents
                    .Select(agent => new
                    {
                        ItemID = agent.ID, // ItemID هو ID الفرد
                        PostID = agent.ID_Post, // ID_Post للدلالة على القسم
                        DepartmentName = context.Fiche_DePosts
                            .Where(dp => dp.ID == agent.ID_Post)
                            .Select(dp => dp.Name)
                            .FirstOrDefault(), // اسم القسم من Fiche_DePosts
                        M_Penalite = context.Fiche_DePosts
                            .Where(dp => dp.ID == agent.ID_Post)
                            .Select(dp => dp.M_Penalite)
                            .FirstOrDefault() // قيمة M_Penalite
                    })
                    .ToList();

                // تجميع بيانات الغيابات حسب القسم
                var departmentAbsences = new Dictionary<string, (int TotalAbsences, float M_Penalite)>();

                foreach (var group in absenceData)
                {
                    // البحث عن القسم بناءً على ItemID
                    var department = departmentData.FirstOrDefault(d => d.ItemID == group.ItemID);

                    if (department != null)
                    {
                        // تجميع الغيابات لكل قسم
                        if (!departmentAbsences.ContainsKey(department.DepartmentName))
                        {
                            departmentAbsences[department.DepartmentName] = (0, (float)department.M_Penalite);
                        }
                        departmentAbsences[department.DepartmentName] = (
                            departmentAbsences[department.DepartmentName].TotalAbsences + group.TotalAbsences,
                            (float)department.M_Penalite
                        );
                    }
                }
                // إضافة البيانات إلى الجدول
                foreach (var dept in departmentAbsences)
                {
                    DataRow row = table.NewRow();
                    row["Department"] = dept.Key;
                    row["TotalAbsences"] = dept.Value.TotalAbsences;
                    row["M_Penalite"] = dept.Value.M_Penalite;
                    row["TotalPenalties"] = dept.Value.TotalAbsences * dept.Value.M_Penalite;
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        private void GenerateReport()
        {
            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;
            int totalDays = (endDate - startDate).Days + 1; // حساب عدد الأيام


            rpt_penalite report = new rpt_penalite();
            report.DataSource = CreateAbsenceReport(totalDays, startDate, endDate);
            report.ShowPreview();
        }
        private DataTable CreateDailyReport(DateTime reportDate)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("RequiredEmployees", typeof(int));
            table.Columns.Add("WorkerName", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("PresentCount", typeof(int));

            using (var context = new DAL.DataClasses1DataContext())
            {
                var departments = context.Fiche_DePosts
                    .Select(post => new
                    {
                        ID_Post = post.ID,
                        DepartmentName = post.Name,
                        RequiredEmployees = post.Nembre_Contra
                    })
                    .ToList();

                // استرجاع عمال كل قسم
                var workers = context.Fich_Agents
                                   .Select(agent => new
                                   {
                                       WorkerName = agent.Name,
                                       DepartmentID = agent.ID_Post,
                                       Status = context.P_Details
                  .Where(p => p.ItemID == agent.ID && context.P_Heders
                 .Where(h => h.ID == p.ID_Heder && h.Date == reportDate) // ربط P_Heder مع P_Details والتحقق من التاريخ
                 .Any() && p.Statut != "CR" && p.Statut != "CE" && p.Statut != "M" && p.Statut != "AA")
                 .Select(p => p.Statut == "P" ? "P" : "A")
                 .FirstOrDefault()
                                   })
                  .Where(worker => worker.Status != null) // تجاوز العمال الذين في عطلة بالكامل
                   .ToList();


                // إضافة البيانات إلى الجدول
                foreach (var department in departments)
                {
                    var departmentWorkers = workers.Where(w => w.DepartmentID == department.ID_Post).ToList();
                    int presentCount = departmentWorkers.Count(w => w.Status == "P");

                    foreach (var worker in departmentWorkers)
                    {
                        DataRow row = table.NewRow();
                        row["Department"] = department.DepartmentName;
                        row["RequiredEmployees"] = department.RequiredEmployees;
                        row["WorkerName"] = worker.WorkerName;
                        row["Status"] = worker.Status ?? "A"; // إذا لم يتم العثور على السجل نعتبره غائباً
                        row["PresentCount"] = presentCount;

                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }
        private void GenerateDailyReport()
        {
            DateTime reportDate = dateEdit1.DateTime; // تعيين التاريخ المحدد للتقرير اليومي
            rpt_DailyReport report = new rpt_DailyReport();
            report.DataSource = CreateDailyReport(reportDate);
            report.ShowPreview();
        }

        private void btn_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintReport();          
        }

        private void btn_reportAparJour_Click(object sender, EventArgs e)
        {
            GenerateDailyReport();          
        }

        private void btn_workdays_Click(object sender, EventArgs e)
        {
            Frm_WorkDays frm = new Frm_WorkDays();
            frm.ShowDialog();
        }

        private void btn_print_pinalite_Click(object sender, EventArgs e)
        {
            if (UserManager.User != null &&(UserType)UserManager.User.UserType == UserType.Admin)
            {
                GenerateReport();
            }
            else
            {
                // رسالة تفيد بعدم امتلاك الصلاحية لفتح النموذج
                MessageBox.Show("Vous n'avez pas les autorisations d'accès.");
            }
        }

        private void btn_listeStq_Click(object sender, EventArgs e)
        {
            Frm_Statistique_List frm = new Frm_Statistique_List();
            frm.ShowDialog();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            Frm_Import_XLSX frm = new Frm_Import_XLSX();
            frm.ShowDialog();
        }

        private void btn_print2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowRibbonPrintPreview();
        }

        private void btn_chart_Click(object sender, EventArgs e)
        {
            if (UserManager.User != null &&(UserType) UserManager.User.UserType == UserType.Admin)
            {
               Frm_Main.Instance.OpenFormByName("Frm_Chart");
            }
            else
            {
                MessageBox.Show("لا تملك صلاحية لفتح هذا النموذج.");
            }
            //Frm_Chart frm = new Frm_Chart();
            //frm.ShowDialog();
        }
    }
}