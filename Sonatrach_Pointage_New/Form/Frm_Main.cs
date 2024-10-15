using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Sonatrach_Pointage_New.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sonatrach_Pointage_New.Classe.Master;

namespace Sonatrach_Pointage_New.Form
{
    public partial class Frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Frm_Main _instance;
        public static Frm_Main Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_Main();
                return _instance;
            }
        }

        public Frm_Main()
        {
            InitializeComponent();
            ribbon.ItemClick += Ribbon_ItemClick;
            barButtonItem7.Caption = Frm_LogIn.NamUser;
        }

        private void Ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = e.Item.Tag as string;
            if (!string.IsNullOrEmpty(tag))
            {
                if (UserManager.User != null)
                {
                    OpenFormBasedOnUserType(UserManager.User, tag);
                }
                else
                {
                    MessageBox.Show("Non connecté. Veuillez d'abord vous connecterاً.");
                }
            }
        }
        public void OpenFormBasedOnUserType(DAL.User currentUser, string formName)
        {
            if ((UserType)currentUser.UserType == UserType.Admin)
            {
                OpenFormByName(formName);
            }
            else if ((UserType)currentUser.UserType == UserType.User)
            {
                if (formName == "Frm_Statistique")
                {
                    OpenFormByName(formName);
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les autorisations d'accès.");
                }
            }
            else
            {
                MessageBox.Show("نوع مستخدم غير معروف.");
            }
        }

        public void OpenFormByName(string formName)
        {
            XtraForm formToOpen = null;

            switch (formName)
            {
                case "Frm_Fich_Agent":
                    formToOpen = new Frm_Fich_Agent();
                    break;
                case "Frm_Statistique":
                    formToOpen = new Frm_Statistique();
                    break;
                case "Frm_AgentList":
                    formToOpen = new Frm_AgentList(); 
                    break;
                case "Frm_FichePost":
                    formToOpen = new Frm_FichePost(); 
                    break;
                case "Frm_Chart":
                    formToOpen = new Frm_Chart();
                    break;
                case "Frm_Statistique_List":
                    formToOpen = new Frm_Statistique_List();
                    break;
                default:
                    return;
            }

            formToOpen.Show();
        } 

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Frm_Fich_Agent frm = new Frm_Fich_Agent();
            //frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Frm_AgentList frm = new Frm_AgentList();
            //frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Frm_FichePost frm = new Frm_FichePost();
            //frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
           // OpenFormByTag("Form2");
            //Frm_Statistique frm = new Frm_Statistique();
            //frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            string enteredPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "☠☠☠☠☠☠☠☠☠☠☠☠☠☠☠☠:",
                "🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻",
                "",
                -1,
                -1
            );

            if (IsValidPassword(enteredPassword))
            {
                Connextion_SQL form2 = new Connextion_SQL();
                form2.Show();
                MessageBox.Show("🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬");
            }
            else
            {
                MessageBox.Show("💀💀💀💀💀💀💀💀💀💥💀💀💀💀💀💀💀💀💀💥.");
            }
        }
        private bool IsValidPassword(string password)
        {
            return password == "123";
        }

        private void btn_admin_ItemClick(object sender, ItemClickEventArgs e)
        {
            string enteredPassword = Microsoft.VisualBasic.Interaction.InputBox(
               "☠☠☠☠☠☠☠☠☠☠☠☠☠☠☠☠:",
               "🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻🩻",
               "",
               -1,
               -1
           );

            if (IsValidPassword(enteredPassword))
            {
                Frm_User form2 = new Frm_User();
                form2.Show();
                MessageBox.Show("🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬🤬");
            }
            else
            {
                MessageBox.Show("💀💀💀💀💀💀💀💀💀💥💀💀💀💀💀💀💀💀💀💥.");
            }
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}