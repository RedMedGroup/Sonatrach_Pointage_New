using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        public Frm_Fich_Agent(int id)
        {
            InitializeComponent();
            using (var db = new DAL.DataClasses1DataContext())
            {
                agent = db.Fich_Agents.Single(x => x.ID == id);
                GetData();
            }
            this.Text = string.Format(";;: {0}", agent.Name);
        }
        private void Frm_Fich_Agent_Load(object sender, EventArgs e)
        {
            toggleSwitch1.IsOn=false;
            using (var db = new DAL.DataClasses1DataContext())
            {
                var post = db.Fiche_DePosts.Select(x => new { x.ID, x.Name }).ToList();

                // تهيئة GridLookUpEdit بالبيانات
                lkp_post.Properties.DataSource = post;
                lkp_post.Properties.DisplayMember = "Name";
                lkp_post.Properties.ValueMember = "ID";
                lkp_post.Properties.PopulateViewColumns();
                lkp_post.Properties.View.Columns["ID"].Visible = false;
            }
            lkp_post.EditValueChanged += Lkp_post_EditValueChanged;
        }

        private void Lkp_post_EditValueChanged(object sender, EventArgs e)
        {
            int selectedPostId = (int)lkp_post.EditValue;

            using (var db = new DAL.DataClasses1DataContext())
            {
                var postDetails = db.Fiche_DePosts.FirstOrDefault(x => x.ID == selectedPostId);
                if (postDetails != null)
                {
                    txt_contra.Text = postDetails.Nembre_Contra.ToString();
                }

                int agentCount = db.Fich_Agents.Count(x => x.ID_Post == selectedPostId && x.IsActive == true);
                txt_efectif.Text = agentCount.ToString();
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
            agent.IsActive = toggleSwitch1.IsOn;
        }
        void GetData()
        {
            txt_Name.Text = agent.Name;
            lkp_post.EditValue = agent.ID_Post;
            toggleSwitch1.IsOn=agent.IsActive;
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
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(toggleSwitch1, "S'il est On, il sera suspendu.");
        }
    }
}