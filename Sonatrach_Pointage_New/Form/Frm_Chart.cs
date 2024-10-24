using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
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
    public partial class Frm_Chart : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Chart()
        {
            InitializeComponent();
        }
        private void Frm_Chart_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime=DateTime.Now;
            dateEdit2.DateTime=DateTime.Now;
        }
            private void simpleButton1_Click(object sender, EventArgs e)
            {
            if (checkEdit1.Checked)
            {
                int selectedEmployeeId = Convert.ToInt32(gridLookUpEdit1.EditValue);
                LoadAttendanceData(selectedEmployeeId);

            }
            else if (checkEdit2.Checked)
            {
                int selectedEmployeeId = Convert.ToInt32(gridLookUpEdit1.EditValue);
                LoadAttendanceDataForDepartments(selectedEmployeeId);

            }
            else if (checkEdit3.Checked)
            {
                // عرض بيانات الحضور/الغياب لجميع الأقسام حسب الحالة المختارة
                string selectedStatus = gridLookUpEdit1.EditValue.ToString();
                LoadAttendanceDataForStatus(selectedStatus);
            }
            else if (checkEdit4.Checked)
            {
                // عرض بيانات الحضور/الغياب لجميع الأقسام حسب الحالة المختارة
               // string selectedStatus = gridLookUpEdit1.EditValue.ToString();
                LoadAttendanceDataForStatus2();
            }
        }
        private void LoadAttendanceData(int employeeId)
        {
            DateTime startDate = dateEdit1.DateTime; 
            DateTime endDate = dateEdit2.DateTime;

            DataTable attendanceTable = CreateAttendanceReport(employeeId, startDate, endDate);


            SetupChart(attendanceTable);
        }
        private DataTable CreateAttendanceReport(int employeeId, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Date", typeof(DateTime)); 
            table.Columns.Add("Status", typeof(string)); 

            using (var context = new DAL.DataClasses1DataContext())
            {
                var attendanceData = context.P_Details
                    .Join(context.P_Heders, detail => detail.ID_Heder, header => header.ID, (detail, header) => new { detail, header })
                    .Where(joined => joined.detail.ItemID == employeeId &&
                                     joined.header.Date >= startDate &&
                                     joined.header.Date <= endDate)
                    .Select(joined => new
                    {
                        Date = joined.header.Date,
                        //Status = joined.detail.Statut == "A" ? "A" : "P" // افترض أن 0 تعني غياب و 1 تعني حضور
                        Status = GetAttendanceStatus(joined.detail.Statut)

                    })
                    .ToList();

                foreach (var record in attendanceData)
                {
                    DataRow row = table.NewRow();
                    row["Date"] = record.Date;
                    row["Status"] = record.Status;
                    table.Rows.Add(row);
                }
            }

            return table;
        }
        private string GetAttendanceStatus(string statut)
        {
            if (statut == "A")
            {
                return "A"; // غياب
            }
            else if (statut == "P")
            {
                return "P"; // حضور
            }
            else if (statut == "CR")
            {
                return "CR"; // عطلة CR
            }
            else if (statut == "M")
            {
                return "M"; // مرض
            }
            else if (statut == "CE")
            {
                return "CE"; // عطلة استثنائية CE
            }
            else if (statut == "AA")
            {
                return "AA"; // غياب مسموح AA
            }
            else
            {
                return "غير محدد"; // أي حالة أخرى
            }
        }
        private void SetupChart(DataTable attendanceTable)
        {
            // تأكد من مسح أي بيانات سابقة في الرسم البياني
            chartControl1.Series.Clear();

            // إنشاء سلسلة جديدة للحضور والغياب
            var series = new DevExpress.XtraCharts.Series("Attendance", DevExpress.XtraCharts.ViewType.Bar);

            // عد الحالات حسب الأنواع المختلفة
            int totalPresent = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "P");
            int totalAbsences = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "A");
            int totalCR = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "CR");
            int totalCE = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "CE");
            int totalAA = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "AA");
            int totalM = attendanceTable.AsEnumerable().Count(row => row.Field<string>("Status") == "M");

            // إضافة النقاط إلى السلسلة
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("P", totalPresent));
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("A", totalAbsences));
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("CR", totalCR));
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("CE", totalCE));
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("AA", totalAA));
            series.Points.Add(new DevExpress.XtraCharts.SeriesPoint("M", totalM));

            // إضافة السلسلة إلى الرسم البياني
            chartControl1.Series.Add(series);

            // تخصيص إعدادات الرسم البياني
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences, absences par Agent" });
        }
        //// Poste
        private void LoadAttendanceDataForDepartments(int departmentId)
        {
            // تواريخ البداية والنهاية
            DateTime startDate = dateEdit1.DateTime; // يمكنك تعديلها لتكون اليوم
            DateTime endDate = dateEdit2.DateTime;

            // إنشاء DataTable للحضور والغياب حسب القسم
            DataTable attendanceTable = CreateDepartmentAttendanceReport(departmentId, startDate, endDate);

            SetupDepartmentChart(attendanceTable);
        }

        private DataTable CreateDepartmentAttendanceReport(int departmentId, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Status", typeof(string)); // حالة الحضور/الغياب
            table.Columns.Add("Count", typeof(int)); // العدد

            using (var context = new DAL.DataClasses1DataContext())
            {
                var attendanceData = from detail in context.P_Details
                                     join header in context.P_Heders on detail.ID_Heder equals header.ID
                                     join agent in context.Fich_Agents on detail.ItemID equals agent.ID
                                     join poste in context.Fiche_DePosts on agent.ID_Post equals poste.ID
                                     where poste.ID == departmentId && // التحقق من أن القسم يطابق departmentId
                                           header.Date >= startDate &&
                                           header.Date <= endDate
                                     select new
                                     {
                                         Statut = detail.Statut 
                                     };

                //  عدد كل حالة
                var groupedAttendance = attendanceData
                    .AsEnumerable()
                    .GroupBy(status => GetAttendanceStatus(status.Statut))
                    .Select(group => new
                    {
                        Status = group.Key,
                        Count = group.Count() 
                    });

                foreach (var group in groupedAttendance)
                {
                    DataRow row = table.NewRow();
                    row["Status"] = group.Status;
                    row["Count"] = group.Count;
                    table.Rows.Add(row);
                }
            }

            return table;
        }


        private void SetupDepartmentChart(DataTable attendanceTable)
        {
            chartControl1.Series.Clear();
            Series series = new Series("Attendance", ViewType.Bar);
            series.ArgumentDataMember = "Status";
            series.ValueDataMembers.AddRange(new string[] { "Count" });

            series.DataSource = attendanceTable;

            chartControl1.Series.Add(series);

            // إعدادات الشارت
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences et absences par Poste" });
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit2.Checked=false; checkEdit3.Checked = false; checkEdit4.Checked = false;
            gridLookUpEdit1.ReadOnly = false;
            checkEdit1.ReadOnly = checkEdit2.ReadOnly = checkEdit3.ReadOnly = false;
            using (var context = new DAL.DataClasses1DataContext())
            {
                var employees = context.Fich_Agents.Select(agent => new
                {
                    ID = agent.ID,
                    Name = agent.Name
                }).ToList();
                gridLookUpEdit1.Properties.View.Columns.Clear();
                gridLookUpEdit1.Properties.DataSource = employees;
                gridLookUpEdit1.Properties.DisplayMember = "Name";
                gridLookUpEdit1.Properties.ValueMember = "ID";
                gridLookUpEdit1.Properties.PopulateViewColumns();
                gridLookUpEdit1.Properties.View.Columns["ID"].Visible = false;
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit1.Checked = false; checkEdit3.Checked = false; checkEdit4.Checked = false;
            gridLookUpEdit1.Properties.DataSource = null;
            gridLookUpEdit1.ReadOnly = false;
            checkEdit1.ReadOnly = checkEdit2.ReadOnly = checkEdit3.ReadOnly = false;
            if (checkEdit2.Checked)
            {
                using (var context = new DAL.DataClasses1DataContext())
                {
                    var employees = context.Fiche_DePosts.Select(agent => new
                    {
                        ID = agent.ID,
                        Name = agent.Name
                    }).ToList();
                    gridLookUpEdit1.Properties.View.Columns.Clear();
                    gridLookUpEdit1.Properties.DataSource = employees;
                    gridLookUpEdit1.Properties.DisplayMember = "Name";
                    gridLookUpEdit1.Properties.ValueMember = "ID";
                    gridLookUpEdit1.Properties.PopulateViewColumns();
                    gridLookUpEdit1.Properties.View.Columns["ID"].Visible = false;
                }
            }         
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit1.Checked = false; checkEdit2.Checked = false; checkEdit4.Checked = false;
            gridLookUpEdit1.Properties.DataSource = null;
            gridLookUpEdit1.ReadOnly = false;
            checkEdit1.ReadOnly = checkEdit2.ReadOnly = checkEdit3.ReadOnly = false;
            if (checkEdit3.Checked)
            {
                var statusList = new List<string> { "P", "A", "CR", "CE", "AA", "M" };

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Statut", typeof(string));

                foreach (var status in statusList)
                {
                    dataTable.Rows.Add(status);
                }

                gridLookUpEdit1.Properties.DataSource = dataTable;
                gridLookUpEdit1.Properties.DisplayMember = "Statut";
                gridLookUpEdit1.Properties.ValueMember = "Statut";

                gridLookUpEdit1.Properties.View.Columns.Clear();
                gridLookUpEdit1.Properties.View.Columns.AddVisible("Statut");

                // تغيير عنوان العمود إلى "Statut"
                gridLookUpEdit1.Properties.View.Columns["Statut"].Caption = "Statut";
            }          
        }
        /////////////////////////////////////////////// poste
        #region
        private void SetupDepartmentCharPost(DataTable attendanceTable)
        {
            if (attendanceTable.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات لعرضها في الشارت.");
                return;
            }

            chartControl1.Series.Clear();

            // إنشاء سلسلة جديدة وإعداداتها
            Series series = new Series("Attendance", ViewType.Bar)
            {
                ArgumentDataMember = "Department" // اسم العمود المستخدم كـ argument
            };

            // تعيين مصدر البيانات للسلسلة
            series.ValueDataMembers.AddRange(new string[] { "Count" }); // استخدام AddRange بدلاً من التعيين المباشر
            series.DataSource = attendanceTable;

            // إضافة السلسلة إلى الشارت
            chartControl1.Series.Add(series);

            // إعدادات إضافية للشارت
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences et absences par Poste" });

            // تحديث الشارت بعد الإعداد
            chartControl1.RefreshData();
        }

        private void LoadAttendanceDataForStatus(string status)
        {
            // تواريخ البداية والنهاية
            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;

            // إنشاء DataTable للحضور والغياب حسب الحالة المختارة
            DataTable attendanceTable = CreateStatusAttendanceReport(status, startDate, endDate);

            SetupDepartmentCharPost(attendanceTable);
        }
        private DataTable CreateStatusAttendanceReport(string status, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Department", typeof(string)); // اسم القسم
            table.Columns.Add("Count", typeof(int)); // العدد

            using (var context = new DAL.DataClasses1DataContext())
            {
                var attendanceData = from detail in context.P_Details
                                     join header in context.P_Heders on detail.ID_Heder equals header.ID
                                     join agent in context.Fich_Agents on detail.ItemID equals agent.ID
                                     join poste in context.Fiche_DePosts on agent.ID_Post equals poste.ID
                                     where detail.Statut == status && // مطابقة الحالة المختارة
                                           header.Date >= startDate &&
                                           header.Date <= endDate
                                     group detail by poste.Name into grouped
                                     select new
                                     {
                                         Department = grouped.Key,
                                         Count = grouped.Count()
                                     };

                // إضافة النتائج إلى DataTable
                foreach (var group in attendanceData)
                {
                    DataRow row = table.NewRow();
                    row["Department"] = group.Department;
                    row["Count"] = group.Count;
                    table.Rows.Add(row);
                }
            }

            return table;
        }
        #endregion
        #region
        private void LoadAttendanceDataForStatus2()
        {
            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;

            DataTable attendanceTable = CreateStatusAttendanceReport2( startDate, endDate);

            SetupDepartmentCharPost2(attendanceTable);
        }
        private void SetupDepartmentCharPost2(DataTable attendanceTable)
        {
            if (attendanceTable.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات لعرضها في الشارت.");
                return;
            }

            chartControl1.Series.Clear();

            // إنشاء السلسلة للحضور
            Series presentSeries = new Series("Présences", ViewType.StackedBar)
            {
                ArgumentDataMember = "Department"
            };
            presentSeries.ValueDataMembers.AddRange(new string[] { "PresentCount" });
            presentSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((StackedBarSeriesView)presentSeries.View).Color = Color.Green;

            // إنشاء السلسلة للغياب
            Series absentSeries = new Series("Absences", ViewType.StackedBar)
            {
                ArgumentDataMember = "Department"
            };
            absentSeries.ValueDataMembers.AddRange(new string[] { "AbsentCount" });
            absentSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((StackedBarSeriesView)absentSeries.View).Color = Color.Red;

            // إضافة السلاسل إلى الشارت
            chartControl1.Series.Add(presentSeries);
            chartControl1.Series.Add(absentSeries);

            // تحديث البيانات
            chartControl1.DataSource = attendanceTable;
            chartControl1.RefreshData();

            // إعدادات إضافية للشارت
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences et absences par Poste" });

            // ضبط مقياس المحور العمودي
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisY.WholeRange.SetMinMaxValues(0, attendanceTable.AsEnumerable().Max(row => Convert.ToInt32(row["PresentCount"]) + Convert.ToInt32(row["AbsentCount"])));
        }

        private DataTable CreateStatusAttendanceReport2( DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Department", typeof(string)); 
            table.Columns.Add("PresentCount", typeof(int)); 
            table.Columns.Add("AbsentCount", typeof(int)); 

            using (var context = new DAL.DataClasses1DataContext())
            {
                var attendanceData = from detail in context.P_Details
                                     join header in context.P_Heders on detail.ID_Heder equals header.ID
                                     join agent in context.Fich_Agents on detail.ItemID equals agent.ID
                                     join poste in context.Fiche_DePosts on agent.ID_Post equals poste.ID
                                     where header.Date >= startDate &&
                                           header.Date <= endDate
                                     group detail by poste.Name into grouped
                                     select new
                                     {
                                         Department = grouped.Key,
                                         PresentCount = grouped.Count(d => d.Statut == "P"), 
                                         AbsentCount = grouped.Count(d => d.Statut == "A") 
                                     };

                foreach (var group in attendanceData)
                {
                    DataRow row = table.NewRow();
                    row["Department"] = group.Department;
                    row["PresentCount"] = group.PresentCount;
                    row["AbsentCount"] = group.AbsentCount;
                    table.Rows.Add(row);
                }
            }

            return table;
        }
        #endregion
        

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit4.Checked)
            {
                checkEdit1.Checked = false; checkEdit2.Checked = false; checkEdit3.Checked = false;
                gridLookUpEdit1.ReadOnly = true;
                checkEdit1.ReadOnly = checkEdit2.ReadOnly = checkEdit3.ReadOnly = true;
            }
            else
            {
                gridLookUpEdit1.ReadOnly = false;
                checkEdit1.ReadOnly = checkEdit2.ReadOnly = checkEdit3.ReadOnly = false;
            }
           
        }
        #region generaite absent poste report 
        private DataTable CreateAbsenceReport(DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("AbsentCount", typeof(int));

            using (var context = new DAL.DataClasses1DataContext())
            {
                var absenceData = from detail in context.P_Details
                                  join header in context.P_Heders on detail.ID_Heder equals header.ID
                                  join agent in context.Fich_Agents on detail.ItemID equals agent.ID
                                  join poste in context.Fiche_DePosts on agent.ID_Post equals poste.ID
                                  where header.Date >= startDate &&
                                        header.Date <= endDate
                                  group detail by poste.Name into grouped
                                  let AbsentCount = grouped.Count(d => d.Statut == "A")
                                  where AbsentCount > 0
                                  select new
                                  {
                                      Department = grouped.Key,
                                      AbsentCount
                                  };

                foreach (var group in absenceData)
                {
                    DataRow row = table.NewRow();
                    row["Department"] = group.Department;
                    row["AbsentCount"] = group.AbsentCount;
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        private void GenerateAbsenceReport()
        {
            DateTime startDate = dateEdit1.DateTime;
            DateTime endDate = dateEdit2.DateTime;

            // الحصول على بيانات الغيابات
            DataTable absenceTable = CreateAbsenceReport(startDate, endDate);

            // إنشاء التقرير
            rpt_Poste_Absence report = new rpt_Poste_Absence();

            // تعيين مصدر البيانات للتقرير
            report.DataSource = absenceTable;
            report.DataMember = absenceTable.TableName;

            // ربط الحقول cell_poste و cell_absent مع الأعمدة في DataTable
            report.cell_poste.DataBindings.Add("Text", absenceTable, "Department");
            report.cell_abs.DataBindings.Add("Text", absenceTable, "AbsentCount");

            // عرض التقرير في نافذة المعاينة
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }


        #endregion

        private void btn_praint_Click(object sender, EventArgs e)
        {
            GenerateAbsenceReport();
        }
    }
}