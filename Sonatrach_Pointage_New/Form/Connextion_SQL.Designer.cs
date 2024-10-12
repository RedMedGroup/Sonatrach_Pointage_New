namespace Sonatrach_Pointage_New.Form
{
    partial class Connextion_SQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connextion_SQL));
            this.cmb_Database_Name = new System.Windows.Forms.ComboBox();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.btn_database_fill = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtPWD = new DevExpress.XtraEditors.TextEdit();
            this.txtCon_Setring = new System.Windows.Forms.RichTextBox();
            this.btn_test_conection = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_con = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Database_Name
            // 
            this.cmb_Database_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Database_Name.DropDownWidth = 175;
            this.cmb_Database_Name.FormattingEnabled = true;
            this.cmb_Database_Name.Location = new System.Drawing.Point(109, 87);
            this.cmb_Database_Name.Name = "cmb_Database_Name";
            this.cmb_Database_Name.Size = new System.Drawing.Size(236, 21);
            this.cmb_Database_Name.TabIndex = 33;
            this.cmb_Database_Name.SelectedIndexChanged += new System.EventHandler(this.cmb_Database_Name_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(109, 58);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(259, 20);
            this.txtServer.TabIndex = 32;
            // 
            // btn_database_fill
            // 
            this.btn_database_fill.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_database_fill.ImageOptions.SvgImage")));
            this.btn_database_fill.Location = new System.Drawing.Point(374, 76);
            this.btn_database_fill.Name = "btn_database_fill";
            this.btn_database_fill.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_database_fill.Size = new System.Drawing.Size(43, 32);
            this.btn_database_fill.TabIndex = 36;
            this.btn_database_fill.Click += new System.EventHandler(this.btn_database_fill_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "Nom du serveur";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "Base de données";
            // 
            // rbSQL
            // 
            this.rbSQL.Location = new System.Drawing.Point(132, 167);
            this.rbSQL.Name = "rbSQL";
            this.rbSQL.Size = new System.Drawing.Size(201, 25);
            this.rbSQL.TabIndex = 41;
            this.rbSQL.Text = "SQL Server Authentication";
            this.rbSQL.UseVisualStyleBackColor = true;
            this.rbSQL.CheckedChanged += new System.EventHandler(this.rbSQL_CheckedChanged);
            // 
            // rbWindows
            // 
            this.rbWindows.Checked = true;
            this.rbWindows.Location = new System.Drawing.Point(132, 138);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(201, 25);
            this.rbWindows.TabIndex = 40;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Windows Authentication";
            this.rbWindows.UseVisualStyleBackColor = true;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbWindows_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(109, 198);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(259, 20);
            this.txtID.TabIndex = 42;
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(109, 230);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(259, 20);
            this.txtPWD.TabIndex = 43;
            // 
            // txtCon_Setring
            // 
            this.txtCon_Setring.Location = new System.Drawing.Point(42, 273);
            this.txtCon_Setring.Name = "txtCon_Setring";
            this.txtCon_Setring.Size = new System.Drawing.Size(357, 103);
            this.txtCon_Setring.TabIndex = 44;
            this.txtCon_Setring.Text = "";
            // 
            // btn_test_conection
            // 
            this.btn_test_conection.Location = new System.Drawing.Point(217, 408);
            this.btn_test_conection.Name = "btn_test_conection";
            this.btn_test_conection.Size = new System.Drawing.Size(182, 22);
            this.btn_test_conection.TabIndex = 47;
            this.btn_test_conection.Text = "Vérifier";
            this.btn_test_conection.Click += new System.EventHandler(this.btn_test_conection_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(42, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 22);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save settings";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbl_con
            // 
            this.lbl_con.Location = new System.Drawing.Point(42, 382);
            this.lbl_con.Name = "lbl_con";
            this.lbl_con.Size = new System.Drawing.Size(357, 22);
            this.lbl_con.TabIndex = 45;
            this.lbl_con.Text = "....................";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 201);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(86, 13);
            this.labelControl4.TabIndex = 48;
            this.labelControl4.Text = "Nom d\'utilisateur :";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 237);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 13);
            this.labelControl5.TabIndex = 49;
            this.labelControl5.Text = "Mot de passe  :";
            // 
            // Connextion_SQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 456);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btn_test_conection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbl_con);
            this.Controls.Add(this.txtCon_Setring);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.rbSQL);
            this.Controls.Add(this.rbWindows);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_database_fill);
            this.Controls.Add(this.cmb_Database_Name);
            this.Controls.Add(this.txtServer);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Connextion_SQL.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.Name = "Connextion_SQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connextion_SQL";
            this.Load += new System.EventHandler(this.Connextion_SQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Database_Name;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.SimpleButton btn_database_fill;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RadioButton rbSQL;
        private System.Windows.Forms.RadioButton rbWindows;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtPWD;
        private System.Windows.Forms.RichTextBox txtCon_Setring;
        private DevExpress.XtraEditors.SimpleButton btn_test_conection;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton lbl_con;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}