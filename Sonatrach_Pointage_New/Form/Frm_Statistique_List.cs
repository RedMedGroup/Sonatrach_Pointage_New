using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Frm_Statistique_List : DevExpress.XtraEditors.XtraForm
    {
        RepositoryItemButtonEdit repositoryButton = new RepositoryItemButtonEdit();
        DAL.P_Heder P_Heder;
        public Frm_Statistique_List()
        {
            InitializeComponent();
        }

        private void Frm_Statistique_List_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = true;
            RefrechData();
            gridView1.Columns.Add(new GridColumn()
            {
                Name = "clmbtn",
                FieldName = "Btn",
                Caption = "Supprimer",
                UnboundType = DevExpress.Data.UnboundColumnType.String,
                ColumnEdit = repositoryButton
            });

            gridView1.Columns["Btn"].VisibleIndex = 2;
            repositoryButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryButton.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            repositoryButton.Click += RepositoryButton_Click;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.Transparent;
            gridView1.Appearance.HideSelectionRow.BackColor = Color.Transparent;
        }

        private void RepositoryButton_Click(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();
            if (selectedRows.Length > 0)
            {
                DialogResult result = MessageBox.Show("Etes-vous sûr de vouloir supprimer ces Date ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (DAL.DataClasses1DataContext dbContext = new DAL.DataClasses1DataContext())
                    {
                        foreach (var rowHandle in selectedRows)
                        {
                            int id = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, nameof(P_Heder.ID)));

                            var detailsToDelete = dbContext.P_Details.Where(x => x.ID_Heder == id);
                            dbContext.P_Details.DeleteAllOnSubmit(detailsToDelete);

                            var hederToDelete = dbContext.P_Heders.Where(x => x.ID == id);
                            dbContext.P_Heders.DeleteAllOnSubmit(hederToDelete);
                        }
                        dbContext.SubmitChanges();
                        RefrechData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner au moins une ligne pour la suppression.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void RefrechData()
        {
            var db = new DAL.DataClasses1DataContext();
            var data = from he in db.P_Heders
                       select new
                       {
                           he.ID,
                           he.Date,
                           p_d = (from dt in db.P_Details.Where(c => c.ID_Heder == he.ID)
                                  join nm in db.Fich_Agents on dt.ItemID equals nm.ID
                                  select new
                                  {
                                      Nom = nm.Name,
                                      dt.Statut,
                                  }).ToList()
                       };
            gridControl1.DataSource = data;
            gridView1.Columns["ID"].Visible = false;
        }
    }
}