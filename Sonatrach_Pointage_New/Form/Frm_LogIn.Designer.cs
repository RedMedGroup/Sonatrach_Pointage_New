namespace Sonatrach_Pointage_New.Form
{
    partial class Frm_LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LogIn));
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserPWD = new DevExpress.XtraEditors.TextEdit();
            this.btn_log = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserPWD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(155, 57);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(137, 20);
            this.txt_UserName.TabIndex = 0;
            // 
            // txt_UserPWD
            // 
            this.txt_UserPWD.Location = new System.Drawing.Point(155, 118);
            this.txt_UserPWD.Name = "txt_UserPWD";
            this.txt_UserPWD.Properties.PasswordChar = '*';
            this.txt_UserPWD.Size = new System.Drawing.Size(137, 20);
            this.txt_UserPWD.TabIndex = 1;
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(140, 164);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(162, 23);
            this.btn_log.TabIndex = 2;
            this.btn_log.Text = "Connexion";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Nom d\'utilisateur ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(55, 121);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Mot de passe ";
            // 
            // Frm_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 241);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.txt_UserPWD);
            this.Controls.Add(this.txt_UserName);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Frm_LogIn.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.Name = "Frm_LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.Frm_LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserPWD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.TextEdit txt_UserPWD;
        private DevExpress.XtraEditors.SimpleButton btn_log;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}