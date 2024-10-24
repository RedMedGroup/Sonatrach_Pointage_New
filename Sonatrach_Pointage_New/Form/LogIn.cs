using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using Sonatrach_Pointage_New.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Sonatrach_Pointage_New.Form
{
    public partial class LogIn : DevExpress.XtraEditors.XtraForm
    {
        public static string NamUser;
        public static int IDUser;
        public LogIn()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
        public bool Login(string userName, string password)
        {
            using (var context = new DAL.DataClasses1DataContext())
            {
                var userFromDb = context.Users
                                        .Where(u => u.UserName == userName && u.Password == password)
                                        .FirstOrDefault();
                var UserNameP = context.Users.SingleOrDefault(w => w.UserName == userName);

                if (userFromDb == null)
                {
                    XtraMessageBox.Show(
                         text: "Le nom d'utilisateur ou le mot de passe est incorrect",
                        caption: "",
                        icon: MessageBoxIcon.Error,
                        buttons: MessageBoxButtons.OK
                        );
                    return false;
                }
                NamUser = UserNameP.Name;
                if (userFromDb.IsActive == false)
                {
                    XtraMessageBox.Show(
                  text: "Ce compte a été désactivé veuillez contacter l'administrateur",
                  caption: "",
                  icon: MessageBoxIcon.Error,
                  buttons: MessageBoxButtons.OK);
                    return false;
                }
                if (userFromDb != null)
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
        public async Task CheckForUpdates()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string apiUrl = "https://api.github.com/repos/RedMedGroup/Sonatrach_Pointage_New/releases/latest";

            string currentVersion = "V2.3.0.0"; 

            using (WebClient webClient = new WebClient())
            {
                // إعداد User-Agent مطلوب لطلب GitHub API
                webClient.Headers.Add("User-Agent", "request");

                // إرسال طلب API والحصول على البيانات بصيغة JSON
                string json = webClient.DownloadString(apiUrl);
                JObject release = JObject.Parse(json);

                // استخراج رقم الإصدار الأخير من JSON
                string latestVersion = release["tag_name"].ToString();

                if (latestVersion != currentVersion)
                {
                    if (MessageBox.Show("Voulez-vous installer la mise à jour ?", "Une nouvelle mise à jour est disponible", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // استخراج رابط تحميل التحديث من JSON
                        string downloadUrl = release["assets"][0]["browser_download_url"].ToString();

                        // تحميل التحديث وتشغيله
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Sonatrach_Pointage_New.exe");
                        webClient.DownloadFile(downloadUrl, tempPath);
                        Process.Start(tempPath);
                        System.Windows.Forms.Application.Exit();
                    }
                }
                //else
                //{
                //    MessageBox.Show("التطبيق محدث بالفعل.", "لا توجد تحديثات متاحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }



        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Login(txt_UserName.Text, txt_UserPWD.Text);
        }

        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPass.Checked)
            {
                txt_UserPWD.PasswordChar = '\0';
            }
            else
            {
                txt_UserPWD.PasswordChar = '*';

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SQL_Server_Config frm = new SQL_Server_Config();
            frm.ShowDialog();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}