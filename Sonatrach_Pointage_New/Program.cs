using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Sonatrach_Pointage_New.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sonatrach_Pointage_New
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form.LogIn());
          //  Application.Run(new SQL_Server_Config());
        }
    }
}
