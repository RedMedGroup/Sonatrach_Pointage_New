using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
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
            LoadEmployees();
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime=DateTime.Now;
            dateEdit2.DateTime=DateTime.Now;
            gridView1.OptionsBehavior.Editable = false;
        }
        private void LoadEmployees()
        {
            using (var context = new DAL.DataClasses1DataContext())
            {
                var employees = context.Fich_Agents.Select(agent => new
                {
                    ID = agent.ID,
                    Name = agent.Name 
                }).ToList();

                gridLookUpEdit1.Properties.DataSource = employees;
                gridLookUpEdit1.Properties.DisplayMember = "Name";
                gridLookUpEdit1.Properties.ValueMember = "ID";
                gridLookUpEdit1.Properties.PopulateViewColumns();
                gridLookUpEdit1.Properties.View.Columns["ID"].Visible = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int selectedEmployeeId = Convert.ToInt32(gridLookUpEdit1.EditValue);
            LoadAttendanceData(selectedEmployeeId);
        }
        private void LoadAttendanceData(int employeeId)
        {
            // تواريخ البداية والنهاية
            DateTime startDate = dateEdit1.DateTime; // يمكنك تعديلها لتكون اليوم
            DateTime endDate = dateEdit2.DateTime;

            // إنشاء DataTable للحضور والغياب
            DataTable attendanceTable = CreateAttendanceReport(employeeId, startDate, endDate);

            // إعداد GridControl كمصدر البيانات
            gridControl1.DataSource = attendanceTable;

            // إعداد ChartControl
            SetupChart(attendanceTable);
        }
        private DataTable CreateAttendanceReport(int employeeId, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Date", typeof(DateTime)); // تاريخ الحضور/الغياب
            table.Columns.Add("Status", typeof(string)); // حالة الحضور/الغياب

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
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences, absences " });
        }

    }
}