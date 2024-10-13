using DevExpress.XtraEditors;
using Sonatrach_Pointage_New.Classe;
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
    public partial class Frm_User : DevExpress.XtraEditors.XtraForm
    {
        DAL.User user;
        public Frm_User()
        {
            InitializeComponent();
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            RefrechData();
            lkp_UserType.Properties.DataSource = Master.UserTypeList;
            lkp_UserType.Properties.DisplayMember = "Name";
            lkp_UserType.Properties.ValueMember = "ID";
            treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Node.GetValue("ID").ToString(), out id))
            {
                var db = new DAL.DataClasses1DataContext();
                user = db.Users.Single(x => x.ID == id);

                GetData();
            }
        }

        public void New()
        {
            user = new DAL.User();
            user.IsActive = true;
        }
        public void GetData()
        {
            txt_Name.Text = user.Name;
            txt_UserName.Text = user.UserName;
            txt_PWD.Text = user.Password;

            lkp_UserType.EditValue = user.UserType;
            toggleSwitch1.IsOn = user.IsActive;
        }
        public void SetData()
        {
            user.Name = txt_Name.Text;
            user.Password = txt_PWD.Text;
            user.UserName = txt_UserName.Text.Trim();
            user.UserType = Convert.ToByte(lkp_UserType.EditValue);
            user.IsActive = toggleSwitch1.IsOn;
        }
        public static string ErrorTextadvance
        {
            get
            {
                return "Ce nom est déjà enregistré";
            }
        }
        public static string ErrorText
        {
            get
            {
                return "Ce champ est obligatoire";
            }
        }
        void RefrechData()
        {
            var db = new DAL.DataClasses1DataContext();

            treeList1.DataSource = db.Users;
            treeList1.ExpandAll();
        }
        public bool Valide ()
        {
            int NumberOfErrors = 0;
            using (var db = new DAL.DataClasses1DataContext())
            {
                if (db.Users.Where(x => x.UserName.Trim() == txt_UserName.Text.Trim()
                 && x.ID != user.ID).Count() > 0)
                {
                    NumberOfErrors += 1;
                    txt_UserName.ErrorText = ErrorTextadvance;
                }
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                NumberOfErrors += 1;
                txt_Name.ErrorText = ErrorText;
            }
            if (string.IsNullOrWhiteSpace(txt_UserName.Text))
            {
                NumberOfErrors += 1;
                txt_UserName.ErrorText = ErrorText;
            }
            if (string.IsNullOrWhiteSpace(txt_PWD.Text))
            {
                NumberOfErrors += 1;
                txt_PWD.ErrorText = ErrorText;
            }
            if (string.IsNullOrWhiteSpace(lkp_UserType.Text))
            {
                NumberOfErrors += 1;
                lkp_UserType.ErrorText = ErrorText;
            }

            return (NumberOfErrors == 0);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!Valide()) 
            {
                return;
            }
            using (var dbc = new DAL.DataClasses1DataContext())
            {
                if (user.ID == 0)
                {
                    dbc.Users.InsertOnSubmit(user);
                }
                else
                {
                    dbc.Users.Attach(user);
                }
                SetData();
                dbc.SubmitChanges();
                New();
                RefrechData();
            }
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            New();txt_Name.Text = "";txt_PWD.Text = "";txt_UserName.Text = "";
        }
    }
}