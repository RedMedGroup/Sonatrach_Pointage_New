namespace Sonatrach_Pointage_New.Form
{
    partial class Frm_Fich_Agent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Fich_Agent));
            this.btn_valid = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkp_post = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txt_contra = new DevExpress.XtraEditors.TextEdit();
            this.txt_efectif = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_post.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_contra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_efectif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_valid
            // 
            this.btn_valid.Location = new System.Drawing.Point(137, 161);
            this.btn_valid.Margin = new System.Windows.Forms.Padding(2);
            this.btn_valid.Name = "btn_valid";
            this.btn_valid.Size = new System.Drawing.Size(134, 21);
            this.btn_valid.TabIndex = 9;
            this.btn_valid.Text = "Valider";
            this.btn_valid.UseVisualStyleBackColor = true;
            this.btn_valid.Click += new System.EventHandler(this.btn_valid_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 34);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Post :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 114);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Nom et Prénom :";
            // 
            // lkp_post
            // 
            this.lkp_post.Location = new System.Drawing.Point(126, 32);
            this.lkp_post.Margin = new System.Windows.Forms.Padding(2);
            this.lkp_post.Name = "lkp_post";
            this.lkp_post.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkp_post.Properties.NullText = "";
            this.lkp_post.Properties.PopupView = this.gridLookUpEdit1View;
            this.lkp_post.Size = new System.Drawing.Size(247, 20);
            this.lkp_post.TabIndex = 6;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.DetailHeight = 239;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(126, 111);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(203, 20);
            this.txt_Name.TabIndex = 5;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(320, 136);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(95, 24);
            this.toggleSwitch1.TabIndex = 10;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // txt_contra
            // 
            this.txt_contra.Location = new System.Drawing.Point(126, 72);
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.Properties.ReadOnly = true;
            this.txt_contra.Size = new System.Drawing.Size(79, 20);
            this.txt_contra.TabIndex = 11;
            // 
            // txt_efectif
            // 
            this.txt_efectif.Location = new System.Drawing.Point(279, 72);
            this.txt_efectif.Name = "txt_efectif";
            this.txt_efectif.Properties.ReadOnly = true;
            this.txt_efectif.Size = new System.Drawing.Size(76, 20);
            this.txt_efectif.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "EFECTIF CONTRAT";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(230, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "N°actual";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(315, 166);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 15;
            // 
            // Frm_Fich_Agent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 223);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_efectif);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.btn_valid);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkp_post);
            this.Controls.Add(this.txt_Name);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Frm_Fich_Agent.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.Name = "Frm_Fich_Agent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fich_Agent";
            this.Load += new System.EventHandler(this.Frm_Fich_Agent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkp_post.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_contra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_efectif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_valid;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit lkp_post;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.TextEdit txt_contra;
        private DevExpress.XtraEditors.TextEdit txt_efectif;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
    }
}