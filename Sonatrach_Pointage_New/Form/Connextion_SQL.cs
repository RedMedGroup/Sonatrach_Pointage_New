using DevExpress.XtraEditors;
using Sonatrach_Pointage_New.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sonatrach_Pointage_New.Form
{
    public partial class Connextion_SQL : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlconnection;
        public Connextion_SQL()
        {
            InitializeComponent();
        }

        private void Connextion_SQL_Load(object sender, EventArgs e)
        {
            string mode = Properties.Settings.Default.Mode;
            if (mode == "SQL")
            {
                sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.SERVER_NAME + "; Database=" +
                                                    Properties.Settings.Default.DATABASE_NAME + "; Integrated Security=false; User ID=" +
                                                    Properties.Settings.Default.DB_USER_NAME + "; Password=" + Properties.Settings.Default.DB_PASSWORD + "");
            }
            else
            {
                sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.SERVER_NAME + "; Database=" + Properties.Settings.Default.DATABASE_NAME + "; Integrated Security=true");
            }
            txtServer.Text = Properties.Settings.Default.SERVER_NAME;
            cmb_Database_Name.Text = Properties.Settings.Default.DATABASE_NAME;
            txtID.Text = Properties.Settings.Default.DB_USER_NAME;
            txtPWD.Text = Properties.Settings.Default.DB_PASSWORD;
            txtCon_Setring.Text = Properties.Settings.Default.CON_STRING;
            txtID.ReadOnly = true;
            txtPWD.ReadOnly = true;
        }

        private void btn_database_fill_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "")
            {
                cmb_Database_Name.Text = "";
                GetDatabaseNames();
                cmb_Database_Name.DataSource = GetDatabaseNames();
                cmb_Database_Name.DisplayMember = "name";
            }
        }
        SqlConnection conn;
        public DataTable GetDatabaseNames()
        {
            DataTable dt = new DataTable();
            string connectionString = string.Empty;

            try
            {
                // Determine connection string based on authentication type
                if (rbSQL.Checked)
                {
                    connectionString = string.Format("Data Source={0}; Initial Catalog=master; User ID={1}; Password={2};",
                                                     txtServer.Text, txtID.Text, txtPWD.Text);
                }
                else if (rbWindows.Checked)
                {
                    connectionString = string.Format("Data Source={0}; Initial Catalog=master; Integrated Security=True;",
                                                     txtServer.Text);
                }
                else
                {
                    throw new InvalidOperationException("No authentication method selected.");
                }

                // Use the connection to fetch database names
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT [name] FROM master.dbo.sysdatabases WHERE dbid > 4";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtPWD.ReadOnly = true;
            txtCon_Setring.Text = "Data Source=" + txtServer.Text + "; Initial Catalog =" + cmb_Database_Name.Text + "; Integrated Security = True";
        }

        private void rbSQL_CheckedChanged(object sender, EventArgs e)
        {
            txtID.ReadOnly = false;
            txtPWD.ReadOnly = false;
            txtCon_Setring.Text = "Data Source=" + txtServer.Text + ";Initial Catalog=" + cmb_Database_Name.Text + "; User ID = " + txtID.Text + "; Password = " + txtPWD.Text + ";";
        }

        private void btn_test_conection_Click(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
        }
        #region
        public void CheckDatabaseConnection()
        {
            try
            {
                string connectionString = string.Empty;

                // Check if SQL Authentication is selected
                if (rbSQL.Checked)
                {
                    if (DATACONFIG())
                    {
                        connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};",
                                                         txtServer.Text, cmb_Database_Name.Text, txtID.Text, txtPWD.Text);

                        AttemptConnection(connectionString);
                    }
                    else
                    {
                        DisplayConnectionError();
                    }
                }
                // Check if Windows Authentication is selected
                else if (rbWindows.Checked)
                {
                    if (DATACONFIG())
                    {
                        connectionString = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True;",
                                                         txtServer.Text, cmb_Database_Name.Text);

                        AttemptConnection(connectionString);
                    }
                    else
                    {
                        DisplayConnectionError();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an authentication method.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lbl_con.Text = "غير متصل";
                lbl_con.Appearance.BackColor = Color.Red;
                MessageBox.Show("خطأ في الاتصال: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to attempt the connection
        private void AttemptConnection(string connectionString)
        {
            try
            {
                sqlhelper helper = new sqlhelper(connectionString);
                if (helper.IsConection)
                {
                    lbl_con.Text = "متصل";
                    lbl_con.Appearance.BackColor = Color.Green;
                    MessageBox.Show("تم الاتصال بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DisplayConnectionError();
                }
            }
            catch (Exception ex)
            {
                lbl_con.Text = "غير متصل";
                lbl_con.Appearance.BackColor = Color.Red;
                MessageBox.Show("خطأ في الاتصال: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to display connection error
        private void DisplayConnectionError()
        {
            lbl_con.Text = "خطاء في الاتصال";
            lbl_con.Appearance.BackColor = Color.Red;
            MessageBox.Show("فشل الاتصال. يرجى التحقق من إعدادات الاتصال.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion
        public Boolean DATACONFIG()
        {
            Boolean conState = false;
            string hostname = txtServer.Text;
            int timeout = 10000;
            Ping ping = new Ping();

            // Check if hostname is provided
            if (string.IsNullOrWhiteSpace(hostname))
            {
                MessageBox.Show("Veuillez saisir le nom du client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return conState;
            }

            try
            {
                PingReply pingReply = ping.Send(hostname, timeout);

                if (pingReply.Status == IPStatus.Success)
                {
                    string connectionString = string.Empty;

                    // Check if SQL Authentication is selected
                    if (rbSQL.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(txtCon_Setring.Text) && !string.IsNullOrWhiteSpace(txtServer.Text) &&
                            !string.IsNullOrWhiteSpace(txtID.Text) && !string.IsNullOrWhiteSpace(txtPWD.Text))
                        {
                            connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};",
                                                             txtServer.Text, cmb_Database_Name.Text, txtID.Text, txtPWD.Text);
                        }
                        else
                        {
                            MessageBox.Show("Veuillez vous assurer de remplir toutes les informations de contact.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return conState;
                        }
                    }
                    // Check if Windows Authentication is selected
                    else if (rbWindows.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(txtCon_Setring.Text) && !string.IsNullOrWhiteSpace(txtServer.Text))
                        {
                            // No need for username and password in Windows Authentication
                            connectionString = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True;",
                                                             txtServer.Text, cmb_Database_Name.Text);
                        }
                        else
                        {
                            MessageBox.Show("Veuillez vous assurer de remplir toutes les informations de contact.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return conState;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un type d'authentification.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return conState;
                    }

                    // Attempt to open the connection
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        conState = true;
                    }
                }
                else
                {
                    MessageBox.Show("Échec de la connexion au serveur. Vérifiez que le nom du serveur est correct.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (PingException)
            {
                MessageBox.Show("Échec de la connexion au serveur. Vérifiez si le nom du serveur ou l'état du réseau est correct.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("La connexion à la base de données a échoué : " + ex.Message, "Erreur de communication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Database_Name.DataSource = null;
                cmb_Database_Name.Text = string.Empty;
            }

            return conState;
        }

        private void cmb_Database_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbWindows.Checked == true)
                txtCon_Setring.Text = "Data Source=" + txtServer.Text + "; Initial Catalog =" + cmb_Database_Name.Text + "; Integrated Security = True";
            if (rbSQL.Checked == true)
                txtCon_Setring.Text = "Data Source=" + txtServer.Text + ";Initial Catalog=" + cmb_Database_Name.Text + "; User ID = " + txtID.Text + "; Password = " + txtPWD.Text + ";";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SERVER_NAME = txtServer.Text;
            Properties.Settings.Default.DATABASE_NAME = cmb_Database_Name.Text;
            Properties.Settings.Default.Mode = rbSQL.Checked == true ? "SQL" : "Windows";
            Properties.Settings.Default.DB_USER_NAME = txtID.Text;
            Properties.Settings.Default.DB_PASSWORD = txtPWD.Text;
            Properties.Settings.Default.CON_STRING = txtCon_Setring.Text;

            Properties.Settings.Default.Save();
            #region
            string connectionString = string.Format("Data Source={0}; Initial Catalog = {1}; User ID = {2}; Password = {3}; ", txtServer.Text, cmb_Database_Name.Text, txtID.Text, txtPWD.Text);
            try
            {
                string mode = Properties.Settings.Default.Mode;
                if (mode == "SQL")
                {
                    sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.SERVER_NAME + "; Database=" +
                                                        Properties.Settings.Default.DATABASE_NAME + "; Integrated Security=false; User ID=" +
                                                        Properties.Settings.Default.DB_USER_NAME + "; Password=" + Properties.Settings.Default.DB_PASSWORD + "");
                }
                else
                {
                    sqlconnection = new SqlConnection(@"Server=" + Properties.Settings.Default.SERVER_NAME + "; Database=" + Properties.Settings.Default.DATABASE_NAME + "; Integrated Security=true");
                }
                MessageBox.Show("Enregistré");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de communication", ex.Message);
            }
            #endregion
        }
    }
}