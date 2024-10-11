using DevExpress.Pdf.Native.BouncyCastle.Utilities.Encoders;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sonatrach_Pointage_New.Form
{
    public partial class Frm_Import_XLSX : DevExpress.XtraEditors.XtraForm
    {
        DAL.P_Heder hed;

        public Frm_Import_XLSX()
        {
            InitializeComponent();
            New();
        }

        private void Frm_Import_XLSX_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                #region finale
                if (openFileDialog.ShowDialog() == DialogResult.OK)////////////////////////////////////////////////////////////////////////////////
                {
                    // فتح ملف Excel باستخدام ExcelDataReader
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            // تخطي الصفوف الفارغة حتى نجد صف يحتوي على بيانات
                            bool validRowFound = false;
                            while (!validRowFound && reader.Read())
                            {
                                // التحقق من وجود قيمة غير فارغة في أي عمود من السطر
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.GetValue(i) != null && !string.IsNullOrWhiteSpace(reader.GetValue(i).ToString()))
                                    {
                                        validRowFound = true;
                                        break;
                                    }
                                }
                            }

                            // إذا لم يتم العثور على أي صف صالح
                            if (!validRowFound)
                            {
                                MessageBox.Show("الملف يحتوي على صفوف فارغة فقط.");
                                return;
                            }

                            // إنشاء DataTable لإضافة البيانات
                            DataTable dataTable = new DataTable();
                            var columnNames = new List<string>();
                            // Set the data source for lkp_article_Excel
                            lkp_Name.Properties.DataSource = columnNames;
                            //lkp_post.Properties.DataSource = columnNames;
                            lkp_statu.Properties.DataSource = columnNames;
                            // قراءة أول صف وتعيين أسماء الأعمدة
                            if (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    columnNames.Add(reader.GetValue(i)?.ToString() ?? $"Column{i + 1}");
                                    dataTable.Columns.Add(columnNames[i]);
                                }
                            }

                            // قراءة بقية البيانات وإضافتها كصفوف إلى DataTable
                            while (reader.Read())
                            {
                                DataRow dataRow = dataTable.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    object value = reader.GetValue(i);
                                    dataRow[i] = value != null ? value.ToString() : ""; // تعيين القيمة الفارغة كـ ""
                                }
                                dataTable.Rows.Add(dataRow);
                            }

                            // ربط DataTable بالـ gridControl1 لعرض البيانات
                            gridControl1.DataSource = dataTable;

                            // إعداد خاصية دمج الخلايا للـ GridView
                            gridView1.OptionsView.AllowCellMerge = true;

                            // تحديد الأعمدة التي يجب دمجها بناءً على أسماء الأعمدة
                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                // دمج الأعمدة المتشابهة
                                if (i < dataTable.Columns.Count)
                                {
                                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                                }
                            }

                            // ضبط تنسيق الأعمدة
                            gridView1.BestFitColumns(); // لضبط حجم الأعمدة تلقائيًا
                        }
                    }
                }

                #endregion
            }
        }
        void New()
        {
            hed = new DAL.P_Heder();
        }
        void SetData()
        {
            hed.Date = dateEdit1.DateTime;
        }
        public static string ErrorText
        {
            get
            {
                return "Ce champ est obligatoire";
            }
        }
        bool IsValidit()
        {
            if (lkp_Name.Text.Trim() == string.Empty)
            {
                lkp_Name.ErrorText = ErrorText;
                return false;
            }
            if (lkp_statu.Text.Trim() == string.Empty)
            {
                lkp_statu.ErrorText = ErrorText;
                return false;
            }
            return true;
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            if (IsValidit() == false)
                return;
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
            //var date=dateEdit1.DateTime;
            //dbc.P_Heders.DeleteAllOnSubmit(dbc.P_Heders.Where(w=>w.Date==date));
            //dbc.SubmitChanges();
            if (hed.ID == 0)
            {
                dbc.P_Heders.InsertOnSubmit(hed);

            }
            else
            {
                dbc.P_Heders.Attach(hed);
            }

            SetData();
            dbc.SubmitChanges();
            DataTable table = (DataTable)gridControl1.DataSource;
            var up = hed.ID;
            using (var db = new DAL.DataClasses1DataContext())
            {
                foreach (DataRow row in table.Rows)
                {
                    string NameP = row[lkp_Name.Text]?.ToString();

                    var nom = db.Fich_Agents.FirstOrDefault(d => d.Name == NameP);
                    if (nom == null)
                    {

                        continue;
                    }
                    #region
                    string NameFirst = row[lkp_Name.Text]?.ToString();
                    #endregion
                    var agent = db.P_Details.FirstOrDefault() ?? new DAL.P_Detail();
                    string selectedColumn = lkp_statu.EditValue?.ToString();
                    //db.P_Details.DeleteAllOnSubmit(db.P_Details.Where(x => x.ID_Heder == hed.ID));
                    //db.SubmitChanges();
                    if (!string.IsNullOrEmpty(selectedColumn))
                    {
                        // هنا نستخدم الصف الحالي `row` بدلاً من DataRowView
                        if (row[selectedColumn] != null)
                        {
                            // الحصول على القيمة العددية من العمود الذي تم تحديده
                            string statutValue = row[selectedColumn]?.ToString();
                            //int statutValue = Convert.ToInt32(row[selectedColumn]);
                            if (agent != null)
                            {
                                agent = new DAL.P_Detail
                                {
                                    ItemID = nom.ID,
                                    Statut = statutValue,
                                    ID_Heder = hed.ID,
                                };
                            }


                            db.P_Details.InsertOnSubmit(agent);
                        }
                        else
                        {
                            MessageBox.Show("Could not retrieve a valid value from the selected row.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid column.");
                    }
                    db.P_Details.InsertOnSubmit(agent);
                }


                db.SubmitChanges();
            }

            Application.DoEvents();
            XtraMessageBox.Show("Enregistrer succés");
            gridView1.Columns.Clear();
            gridControl1.DataSource = null;
            New();
        }
    }
}