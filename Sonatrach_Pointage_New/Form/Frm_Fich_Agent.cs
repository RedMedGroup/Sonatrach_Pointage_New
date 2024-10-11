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
    public partial class Frm_Fich_Agent : DevExpress.XtraEditors.XtraForm
    {
        DAL.Fich_Agent agent;
        public Frm_Fich_Agent()
        {
            InitializeComponent();
            New();
        }

        private void Frm_Fich_Agent_Load(object sender, EventArgs e)
        {
            using (var db = new DAL.DataClasses1DataContext())
            {
                var post = db.Fiche_DePosts.Select(x => new { x.ID, x.Name }).ToList();

                // تهيئة GridLookUpEdit بالبيانات
                lkp_post.Properties.DataSource = post;
                lkp_post.Properties.DisplayMember = "Name";
                lkp_post.Properties.ValueMember = "ID";
            }
        }

        private void btn_valid_Click(object sender, EventArgs e)
        {
            Save();
        }
        void SetData()
        {
            agent.Name = txt_Name.Text;
            agent.ID_Post = Convert.ToInt32(lkp_post.EditValue);
        }
        void GetData()
        {
            txt_Name.Text = agent.Name;
            lkp_post.EditValue = agent.ID_Post;
        }
        void New()
        {
            agent = new DAL.Fich_Agent();
        }
        bool IsValidit()
        {
            if (txt_Name.Text.Trim() == string.Empty)
            {
                txt_Name.Text = ErrorText;
                return false;
            }
            if (lkp_post.Text.Trim() == string.Empty)
            {
                lkp_post.Text = ErrorText;
                return false;
            }
            return true;
        }
        void Save()
        {
            if (IsValidit() == false)
                return;
            var db = new DAL.DataClasses1DataContext();
            if (agent.ID == 0)
            {
                db.Fich_Agents.InsertOnSubmit(agent);
            }
            else
            {
                db.Fich_Agents.Attach(agent);
            }
            SetData();
            db.SubmitChanges();
            New();
            XtraMessageBox.Show("Enregistrer succés");
        }
        public static string ErrorText
        {
            get
            {
                return "Ce champ est obligatoire";
            }
        }
    }
}