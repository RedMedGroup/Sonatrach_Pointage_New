namespace Sonatrach_Pointage_New.Form
{
    partial class Frm_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_User));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lkp_UserType = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_PWD = new DevExpress.XtraEditors.TextEdit();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_UserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Controls.Add(this.btn_new);
            this.layoutControl1.Controls.Add(this.btn_save);
            this.layoutControl1.Controls.Add(this.txt_Name);
            this.layoutControl1.Controls.Add(this.txt_UserName);
            this.layoutControl1.Controls.Add(this.txt_PWD);
            this.layoutControl1.Controls.Add(this.lkp_UserType);
            this.layoutControl1.Controls.Add(this.toggleSwitch1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(429, 353);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(429, 353);
            this.Root.TextVisible = false;
            // 
            // lkp_UserType
            // 
            this.lkp_UserType.Location = new System.Drawing.Point(116, 124);
            this.lkp_UserType.Name = "lkp_UserType";
            this.lkp_UserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkp_UserType.Properties.NullText = "";
            this.lkp_UserType.Size = new System.Drawing.Size(289, 20);
            this.lkp_UserType.StyleController = this.layoutControl1;
            this.lkp_UserType.TabIndex = 8;
            // 
            // txt_PWD
            // 
            this.txt_PWD.Location = new System.Drawing.Point(116, 100);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.Properties.UseSystemPasswordChar = true;
            this.txt_PWD.Size = new System.Drawing.Size(289, 20);
            this.txt_PWD.StyleController = this.layoutControl1;
            this.txt_PWD.TabIndex = 6;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(116, 48);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(116, 20);
            this.txt_Name.StyleController = this.layoutControl1;
            this.txt_Name.TabIndex = 4;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(116, 76);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(289, 20);
            this.txt_UserName.StyleController = this.layoutControl1;
            this.txt_UserName.TabIndex = 5;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.EditValue = true;
            this.toggleSwitch1.Location = new System.Drawing.Point(236, 48);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "In active";
            this.toggleSwitch1.Properties.OnText = "Active";
            this.toggleSwitch1.Size = new System.Drawing.Size(169, 24);
            this.toggleSwitch1.StyleController = this.layoutControl1;
            this.toggleSwitch1.TabIndex = 11;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "معلومات المستخدم";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 3;
            this.layoutControlGroup2.Size = new System.Drawing.Size(409, 333);
            this.layoutControlGroup2.Text = "Info utilisateur";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_Name;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem1.CustomizationFormText = "الاسم";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem1.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem1.Size = new System.Drawing.Size(212, 28);
            this.layoutControlItem1.Text = "Nome";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_UserName;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem2.CustomizationFormText = "اسم الدخول";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem2.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem2.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem2.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem2.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem2.Text = "Nom de connexion";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_PWD;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem3.CustomizationFormText = "الرقم السري";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem3.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem3.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem3.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem3.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem3.Text = "Mot de passe";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkp_UserType;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem5.CustomizationFormText = "نوع الدخول";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem5.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem5.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem5.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem5.Size = new System.Drawing.Size(385, 24);
            this.layoutControlItem5.Text = "Type d\'entrée";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.toggleSwitch1;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(212, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(173, 28);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // btn_save
            // 
            this.btn_save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_save.ImageOptions.SvgImage")));
            this.btn_save.Location = new System.Drawing.Point(321, 148);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(40, 38);
            this.btn_save.StyleController = this.layoutControl1;
            this.btn_save.TabIndex = 12;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_save;
            this.layoutControlItem6.Location = new System.Drawing.Point(297, 100);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(44, 42);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // btn_new
            // 
            this.btn_new.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_new.ImageOptions.SvgImage")));
            this.btn_new.Location = new System.Drawing.Point(365, 148);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(40, 38);
            this.btn_new.StyleController = this.layoutControl1;
            this.btn_new.TabIndex = 13;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_new;
            this.layoutControlItem7.Location = new System.Drawing.Point(341, 100);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(44, 42);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // treeList1
            // 
            this.treeList1.Location = new System.Drawing.Point(24, 190);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(381, 139);
            this.treeList1.TabIndex = 14;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.treeList1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 142);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(385, 143);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 100);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(297, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 353);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Frm_User.IconOptions.SvgImage")));
            this.Name = "Frm_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.Frm_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_UserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.TextEdit txt_PWD;
        private DevExpress.XtraEditors.LookUpEdit lkp_UserType;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btn_new;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}