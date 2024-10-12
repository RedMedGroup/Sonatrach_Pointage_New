using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class Frm_LogIn : DevExpress.XtraEditors.XtraForm
    {
        public static string NamUser;
        public static int IDUser;
        public Frm_LogIn()
        {
            InitializeComponent();
        }

        private void Frm_LogIn_Load(object sender, EventArgs e)
        {

        }
        void Login()
        {
            using (var db = new DAL.DataClasses1DataContext())
            {
                var userName = txt_UserName.Text;
                var passWord = txt_UserPWD.Text;

                var user = db.Users.SingleOrDefault(x => x.UserName == userName);
                if (user == null)
                {
                    XtraMessageBox.Show(
                         text: "Le nom d'utilisateur ou le mot de passe est incorrect",
                        caption: "",
                        icon: MessageBoxIcon.Error,
                        buttons: MessageBoxButtons.OK
                        );
                    return;
                }
                else
                {
                    if (user.IsActive == false)
                    {
                        XtraMessageBox.Show(
                      text: "Ce compte a été désactivé veuillez contacter l'administrateur",
                      caption: "",
                      icon: MessageBoxIcon.Error,
                      buttons: MessageBoxButtons.OK);
                        return;
                    }
                    var passWordHash = user.Password;
                    // var hasher = new Liphsoft.Crypto.Argon2.PasswordHasher();
                    // if (hasher.Verify(passWordHash, passWord))
                    if (txt_UserPWD.Text == user.Password && txt_UserName.Text == user.UserName)
                    {
                        this.Hide();
                        NamUser = user.Name;
                        IDUser = user.ID;
                     
                        Frm_Main.Instance.Show();
                        return;

                        ///////////////////////////
                    }
                    else
                        goto LogInFaild;
                }

            }

        LogInFaild:
            XtraMessageBox.Show(
                      text: "Le nom d'utilisateur ou le mot de passe est incorrect",
                      caption: "",
                      icon: MessageBoxIcon.Error,
                      buttons: MessageBoxButtons.OK
                      );
            return;
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
           // Login();
            Login(txt_UserName.Text, txt_UserPWD.Text);
        }
        public bool Login(string userName, string password)
        {
            using (var context = new DAL.DataClasses1DataContext()) 
            {
                var userFromDb = context.Users
                                        .Where(u => u.UserName == userName && u.Password == password)
                                        .FirstOrDefault();
                if (userFromDb.IsActive == false)
                {
                    XtraMessageBox.Show(
                  text: "Ce compte a été désactivé veuillez contacter l'administrateur",
                  caption: "",
                  icon: MessageBoxIcon.Error,
                  buttons: MessageBoxButtons.OK);
                    return false;
                }
                if (userFromDb != null )
                {
                    UserManager.SetUser(userFromDb);
                    this.Hide();
                    Frm_Main.Instance.Show();
                    return true;
                }
                else
                {
                    XtraMessageBox.Show(
                         text: "Le nom d'utilisateur ou le mot de passe est incorrect",
                        caption: "",
                        icon: MessageBoxIcon.Error,
                        buttons: MessageBoxButtons.OK);
                    return false;
                }               
            }
        }

    }
}