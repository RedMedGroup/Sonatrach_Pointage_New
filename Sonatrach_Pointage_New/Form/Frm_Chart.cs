using DevExpress.XtraCharts;
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
          //  LoadEmployees();
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime=DateTime.Now;
            dateEdit2.DateTime=DateTime.Now;
        }
        //private void LoadEmployees()
        //{

        //    using (var context = new DAL.DataClasses1DataContext())
        //    {
        //        var employees = context.Fich_Agents.Select(agent => new
        //        {
        //            ID = agent.ID,
        //            Name = agent.Name 
        //        }).ToList();

        //        gridLookUpEdit1.Properties.DataSource = employees;
        //        gridLookUpEdit1.Properties.DisplayMember = "Name";
        //        gridLookUpEdit1.Properties.ValueMember = "ID";
        //        gridLookUpEdit1.Properties.PopulateViewColumns();
        //        gridLookUpEdit1.Properties.View.Columns["ID"].Visible = false;
        //    }
        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int selectedEmployeeId = Convert.ToInt32(gridLookUpEdit1.EditValue);
            if (checkEdit1.Checked)
            {
                LoadAttendanceData(selectedEmployeeId);

            }
            if (checkEdit2.Checked)
            {
                LoadAttendanceDataForDepartments(selectedEmployeeId);

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

            // إعداد ChartControl
            SetupDepartmentChart(attendanceTable);
        }

        private DataTable CreateDepartmentAttendanceReport(int departmentId, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Status", typeof(string)); // حالة الحضور/الغياب
            table.Columns.Add("Count", typeof(int)); // العدد

            using (var context = new DAL.DataClasses1DataContext())
            {
                // استعلام للحصول على بيانات الحضور والغياب من قاعدة البيانات
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

                // احسب عدد كل حالة
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

            // إضافة السلسلة إلى الشارت وربطها بـ DataTable
            series.DataSource = attendanceTable;

            // إضافة السلسلة إلى الشارت
            chartControl1.Series.Add(series);

            // إعدادات الشارت
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new DevExpress.XtraCharts.ChartTitle { Text = "Détails des présences et absences par Poste" });
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit2.Checked=false;
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

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            checkEdit1.Checked = false;
            using (var context = new DAL.DataClasses1DataContext())
            {
                var employees = context.Fiche_DePosts.Select(agent => new
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
       
    }
}