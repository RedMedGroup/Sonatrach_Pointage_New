using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class Frm_AgentList : DevExpress.XtraEditors.XtraForm
    {
        public Frm_AgentList()
        {
            InitializeComponent();
            gridView1.DoubleClick += GridView1_DoubleClick;
            gridView1.OptionsBehavior.Editable = false;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);

            if (info.InRow || info.InRowCell)
            {
                // الحصول على قيمة ID
                int id = Convert.ToInt32(view.GetFocusedRowCellValue("ID"));
                OpenForm(id);
            }
        }
        public virtual void OpenForm(int id)
        {
            var frm = new Form.Frm_Fich_Agent(id);
            frm.ShowDialog();
        }

        private void Frm_AgentList_Load(object sender, EventArgs e)
        {
            RefrechData();
            gridView1.Columns["Name"].Caption = "Nom";
            gridView1.Columns["Post"].Caption = "Poste";
        }
        void RefrechData()
        {
            var db = new DAL.DataClasses1DataContext();
            var data = from ag in db.Fich_Agents
                       join post in db.Fiche_DePosts on ag.ID_Post equals post.ID
                       select new
                       {
                           ag.ID,
                           Name = ag.Name,
                           Post = post.Name,
                       };
            gridControl1.DataSource = data;
            gridView1.Columns["ID"].Visible=false;
        }

        private void btn_printe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowPrintPreview();
        }
    }
}