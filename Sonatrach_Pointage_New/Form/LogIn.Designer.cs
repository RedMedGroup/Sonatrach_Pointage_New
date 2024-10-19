namespace Sonatrach_Pointage_New.Form
{
    partial class LogIn
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
            this.label3 = new System.Windows.Forms.Label();
            this.registrationButton = new System.Windows.Forms.Button();
            this.checkboxShowPass = new System.Windows.Forms.CheckBox();
            this.txt_UserPWD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label3.Location = new System.Drawing.Point(8, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 27);
            this.label3.TabIndex = 31;
            this.label3.Text = "Système de pointage";
            // 
            // registrationButton
            // 
            this.registrationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.registrationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.registrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrationButton.FlatAppearance.BorderSize = 0;
            this.registrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrationButton.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.registrationButton.ForeColor = System.Drawing.Color.White;
            this.registrationButton.Location = new System.Drawing.Point(33, 301);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(218, 28);
            this.registrationButton.TabIndex = 28;
            this.registrationButton.Text = "Connexion";
            this.registrationButton.UseVisualStyleBackColor = false;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // checkboxShowPass
            // 
            this.checkboxShowPass.AutoSize = true;
            this.checkboxShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkboxShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkboxShowPass.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkboxShowPass.Location = new System.Drawing.Point(77, 244);
            this.checkboxShowPass.Name = "checkboxShowPass";
            this.checkboxShowPass.Size = new System.Drawing.Size(174, 21);
            this.checkboxShowPass.TabIndex = 27;
            this.checkboxShowPass.Text = "Afficher le mot de passe";
            this.checkboxShowPass.UseVisualStyleBackColor = true;
            this.checkboxShowPass.CheckedChanged += new System.EventHandler(this.checkboxShowPass_CheckedChanged);
            // 
            // txt_UserPWD
            // 
            this.txt_UserPWD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_UserPWD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_UserPWD.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserPWD.Location = new System.Drawing.Point(34, 201);
            this.txt_UserPWD.Multiline = true;
            this.txt_UserPWD.Name = "txt_UserPWD";
            this.txt_UserPWD.PasswordChar = '*';
            this.txt_UserPWD.Size = new System.Drawing.Size(217, 28);
            this.txt_UserPWD.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Mot de passe ";
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_UserName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(33, 121);
            this.txt_UserName.Multiline = true;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(218, 28);
            this.txt_UserName.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nom d\'utilisateur ";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatAppearance.BorderSize = 2;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.clearButton.Location = new System.Drawing.Point(34, 352);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(217, 28);
            this.clearButton.TabIndex = 32;
            this.clearButton.Text = "FRMER";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(78)))), ((int)(((byte)(165)))));
            this.label6.Location = new System.Drawing.Point(98, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Base donné";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // LogIn
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 487);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.checkboxShowPass);
            this.Controls.Add(this.txt_UserPWD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.CheckBox checkboxShowPass;
        private System.Windows.Forms.TextBox txt_UserPWD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label6;
    }
}