
namespace Quick_Translator
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbCustomEntities = new System.Windows.Forms.CheckBox();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.gbSelectEntity = new System.Windows.Forms.GroupBox();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.cbDefaultEntities = new System.Windows.Forms.CheckBox();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.logicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.displayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSelectedEntity = new System.Windows.Forms.GroupBox();
            this.tcSelectedEntityTabs = new System.Windows.Forms.TabControl();
            this.tpAttributes = new System.Windows.Forms.TabPage();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.attrLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Forms = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.formLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpFormFields = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.formFieldLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpViews = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.viewLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpBooleans = new System.Windows.Forms.TabPage();
            this.listView5 = new System.Windows.Forms.ListView();
            this.boolLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpPicklists = new System.Windows.Forms.TabPage();
            this.listView6 = new System.Windows.Forms.ListView();
            this.picklistLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMenu.SuspendLayout();
            this.gbSelectEntity.SuspendLayout();
            this.gbSelectedEntity.SuspendLayout();
            this.tcSelectedEntityTabs.SuspendLayout();
            this.tpAttributes.SuspendLayout();
            this.Forms.SuspendLayout();
            this.tpFormFields.SuspendLayout();
            this.tpViews.SuspendLayout();
            this.tpBooleans.SuspendLayout();
            this.tpPicklists.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(960, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cbCustomEntities
            // 
            this.cbCustomEntities.AutoSize = true;
            this.cbCustomEntities.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCustomEntities.Location = new System.Drawing.Point(4, 17);
            this.cbCustomEntities.Margin = new System.Windows.Forms.Padding(2);
            this.cbCustomEntities.Name = "cbCustomEntities";
            this.cbCustomEntities.Size = new System.Drawing.Size(98, 17);
            this.cbCustomEntities.TabIndex = 5;
            this.cbCustomEntities.Text = "Custom Entities";
            this.cbCustomEntities.UseVisualStyleBackColor = true;
            // 
            // tbFind
            // 
            this.tbFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFind.Location = new System.Drawing.Point(39, 69);
            this.tbFind.Margin = new System.Windows.Forms.Padding(2);
            this.tbFind.MaxLength = 50;
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(174, 20);
            this.tbFind.TabIndex = 6;
            this.tbFind.WordWrap = false;
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.Location = new System.Drawing.Point(4, 69);
            this.lblFind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(31, 15);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find";
            // 
            // gbSelectEntity
            // 
            this.gbSelectEntity.Controls.Add(this.btnLoadEntities);
            this.gbSelectEntity.Controls.Add(this.cbDefaultEntities);
            this.gbSelectEntity.Controls.Add(this.lvEntities);
            this.gbSelectEntity.Controls.Add(this.cbCustomEntities);
            this.gbSelectEntity.Controls.Add(this.lblFind);
            this.gbSelectEntity.Controls.Add(this.tbFind);
            this.gbSelectEntity.Location = new System.Drawing.Point(2, 24);
            this.gbSelectEntity.Margin = new System.Windows.Forms.Padding(2);
            this.gbSelectEntity.Name = "gbSelectEntity";
            this.gbSelectEntity.Padding = new System.Windows.Forms.Padding(2);
            this.gbSelectEntity.Size = new System.Drawing.Size(292, 536);
            this.gbSelectEntity.TabIndex = 8;
            this.gbSelectEntity.TabStop = false;
            this.gbSelectEntity.Text = "Select Entity";
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Location = new System.Drawing.Point(4, 38);
            this.btnLoadEntities.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(209, 22);
            this.btnLoadEntities.TabIndex = 10;
            this.btnLoadEntities.Text = "Load Entities";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // cbDefaultEntities
            // 
            this.cbDefaultEntities.AutoSize = true;
            this.cbDefaultEntities.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDefaultEntities.Location = new System.Drawing.Point(116, 17);
            this.cbDefaultEntities.Margin = new System.Windows.Forms.Padding(2);
            this.cbDefaultEntities.Name = "cbDefaultEntities";
            this.cbDefaultEntities.Size = new System.Drawing.Size(97, 17);
            this.cbDefaultEntities.TabIndex = 9;
            this.cbDefaultEntities.Text = "Default Entities";
            this.cbDefaultEntities.UseVisualStyleBackColor = true;
            // 
            // lvEntities
            // 
            this.lvEntities.BackColor = System.Drawing.SystemColors.Control;
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logicalName,
            this.displayName});
            this.lvEntities.HideSelection = false;
            this.lvEntities.LabelWrap = false;
            this.lvEntities.Location = new System.Drawing.Point(4, 93);
            this.lvEntities.Margin = new System.Windows.Forms.Padding(2);
            this.lvEntities.MultiSelect = false;
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(288, 443);
            this.lvEntities.TabIndex = 8;
            this.lvEntities.TabStop = false;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            // 
            // logicalName
            // 
            this.logicalName.Text = "Logical Name";
            this.logicalName.Width = 135;
            // 
            // displayName
            // 
            this.displayName.Text = "Display Name";
            this.displayName.Width = 146;
            // 
            // gbSelectedEntity
            // 
            this.gbSelectedEntity.Controls.Add(this.tcSelectedEntityTabs);
            this.gbSelectedEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectedEntity.Location = new System.Drawing.Point(298, 32);
            this.gbSelectedEntity.Margin = new System.Windows.Forms.Padding(2);
            this.gbSelectedEntity.Name = "gbSelectedEntity";
            this.gbSelectedEntity.Padding = new System.Windows.Forms.Padding(2);
            this.gbSelectedEntity.Size = new System.Drawing.Size(675, 574);
            this.gbSelectedEntity.TabIndex = 9;
            this.gbSelectedEntity.TabStop = false;
            this.gbSelectedEntity.Text = "Selected Entity: {0}";
            // 
            // tcSelectedEntityTabs
            // 
            this.tcSelectedEntityTabs.Controls.Add(this.tpAttributes);
            this.tcSelectedEntityTabs.Controls.Add(this.Forms);
            this.tcSelectedEntityTabs.Controls.Add(this.tpFormFields);
            this.tcSelectedEntityTabs.Controls.Add(this.tpViews);
            this.tcSelectedEntityTabs.Controls.Add(this.tpBooleans);
            this.tcSelectedEntityTabs.Controls.Add(this.tpPicklists);
            this.tcSelectedEntityTabs.Location = new System.Drawing.Point(-1, 21);
            this.tcSelectedEntityTabs.Margin = new System.Windows.Forms.Padding(2);
            this.tcSelectedEntityTabs.Name = "tcSelectedEntityTabs";
            this.tcSelectedEntityTabs.SelectedIndex = 0;
            this.tcSelectedEntityTabs.Size = new System.Drawing.Size(661, 553);
            this.tcSelectedEntityTabs.TabIndex = 0;
            // 
            // tpAttributes
            // 
            this.tpAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.tpAttributes.Controls.Add(this.lvAttributes);
            this.tpAttributes.Location = new System.Drawing.Point(4, 25);
            this.tpAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.tpAttributes.Name = "tpAttributes";
            this.tpAttributes.Padding = new System.Windows.Forms.Padding(2);
            this.tpAttributes.Size = new System.Drawing.Size(653, 524);
            this.tpAttributes.TabIndex = 0;
            this.tpAttributes.Text = "Attributes";
            // 
            // lvAttributes
            // 
            this.lvAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.lvAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.attrLogicalName});
            this.lvAttributes.HideSelection = false;
            this.lvAttributes.LabelEdit = true;
            this.lvAttributes.Location = new System.Drawing.Point(4, 4);
            this.lvAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(645, 516);
            this.lvAttributes.TabIndex = 0;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            // 
            // attrLogicalName
            // 
            this.attrLogicalName.Text = "Logical Name";
            this.attrLogicalName.Width = 150;
            // 
            // Forms
            // 
            this.Forms.BackColor = System.Drawing.SystemColors.Control;
            this.Forms.Controls.Add(this.listView2);
            this.Forms.Location = new System.Drawing.Point(4, 25);
            this.Forms.Margin = new System.Windows.Forms.Padding(2);
            this.Forms.Name = "Forms";
            this.Forms.Padding = new System.Windows.Forms.Padding(2);
            this.Forms.Size = new System.Drawing.Size(653, 524);
            this.Forms.TabIndex = 1;
            this.Forms.Text = "Forms";
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.Control;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.formLogicalName});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(4, 4);
            this.listView2.Margin = new System.Windows.Forms.Padding(2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(645, 516);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // formLogicalName
            // 
            this.formLogicalName.Text = "Logical Name";
            this.formLogicalName.Width = 150;
            // 
            // tpFormFields
            // 
            this.tpFormFields.BackColor = System.Drawing.SystemColors.Control;
            this.tpFormFields.Controls.Add(this.listView3);
            this.tpFormFields.Location = new System.Drawing.Point(4, 25);
            this.tpFormFields.Margin = new System.Windows.Forms.Padding(2);
            this.tpFormFields.Name = "tpFormFields";
            this.tpFormFields.Padding = new System.Windows.Forms.Padding(2);
            this.tpFormFields.Size = new System.Drawing.Size(653, 524);
            this.tpFormFields.TabIndex = 2;
            this.tpFormFields.Text = "Form Fields";
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.SystemColors.Control;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.formFieldLogicalName});
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(4, 4);
            this.listView3.Margin = new System.Windows.Forms.Padding(2);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(645, 516);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // formFieldLogicalName
            // 
            this.formFieldLogicalName.Text = "Logical Name";
            this.formFieldLogicalName.Width = 150;
            // 
            // tpViews
            // 
            this.tpViews.BackColor = System.Drawing.SystemColors.Control;
            this.tpViews.Controls.Add(this.listView4);
            this.tpViews.Location = new System.Drawing.Point(4, 25);
            this.tpViews.Margin = new System.Windows.Forms.Padding(2);
            this.tpViews.Name = "tpViews";
            this.tpViews.Padding = new System.Windows.Forms.Padding(2);
            this.tpViews.Size = new System.Drawing.Size(653, 524);
            this.tpViews.TabIndex = 3;
            this.tpViews.Text = "Views";
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.SystemColors.Control;
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.viewLogicalName});
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(4, 4);
            this.listView4.Margin = new System.Windows.Forms.Padding(2);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(645, 516);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // viewLogicalName
            // 
            this.viewLogicalName.Text = "Logical Name";
            this.viewLogicalName.Width = 150;
            // 
            // tpBooleans
            // 
            this.tpBooleans.BackColor = System.Drawing.SystemColors.Control;
            this.tpBooleans.Controls.Add(this.listView5);
            this.tpBooleans.Location = new System.Drawing.Point(4, 25);
            this.tpBooleans.Margin = new System.Windows.Forms.Padding(2);
            this.tpBooleans.Name = "tpBooleans";
            this.tpBooleans.Padding = new System.Windows.Forms.Padding(2);
            this.tpBooleans.Size = new System.Drawing.Size(653, 524);
            this.tpBooleans.TabIndex = 4;
            this.tpBooleans.Text = "Booleans";
            // 
            // listView5
            // 
            this.listView5.BackColor = System.Drawing.SystemColors.Control;
            this.listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.boolLogicalName});
            this.listView5.HideSelection = false;
            this.listView5.Location = new System.Drawing.Point(4, 4);
            this.listView5.Margin = new System.Windows.Forms.Padding(2);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(645, 516);
            this.listView5.TabIndex = 0;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            // 
            // boolLogicalName
            // 
            this.boolLogicalName.Text = "Logical Name";
            this.boolLogicalName.Width = 150;
            // 
            // tpPicklists
            // 
            this.tpPicklists.BackColor = System.Drawing.SystemColors.Control;
            this.tpPicklists.Controls.Add(this.listView6);
            this.tpPicklists.Location = new System.Drawing.Point(4, 25);
            this.tpPicklists.Margin = new System.Windows.Forms.Padding(2);
            this.tpPicklists.Name = "tpPicklists";
            this.tpPicklists.Padding = new System.Windows.Forms.Padding(2);
            this.tpPicklists.Size = new System.Drawing.Size(653, 524);
            this.tpPicklists.TabIndex = 5;
            this.tpPicklists.Text = "Picklists";
            // 
            // listView6
            // 
            this.listView6.BackColor = System.Drawing.SystemColors.Control;
            this.listView6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.picklistLogicalName});
            this.listView6.HideSelection = false;
            this.listView6.Location = new System.Drawing.Point(4, 4);
            this.listView6.Margin = new System.Windows.Forms.Padding(2);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(645, 516);
            this.listView6.TabIndex = 0;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.View = System.Windows.Forms.View.Details;
            // 
            // picklistLogicalName
            // 
            this.picklistLogicalName.Text = "Logical Name";
            this.picklistLogicalName.Width = 150;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSelectedEntity);
            this.Controls.Add(this.gbSelectEntity);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(960, 623);
            //this.Load += new System.EventHandler(this.PluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gbSelectEntity.ResumeLayout(false);
            this.gbSelectEntity.PerformLayout();
            this.gbSelectedEntity.ResumeLayout(false);
            this.tcSelectedEntityTabs.ResumeLayout(false);
            this.tpAttributes.ResumeLayout(false);
            this.Forms.ResumeLayout(false);
            this.tpFormFields.ResumeLayout(false);
            this.tpViews.ResumeLayout(false);
            this.tpBooleans.ResumeLayout(false);
            this.tpPicklists.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.CheckBox cbCustomEntities;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.GroupBox gbSelectEntity;
        private System.Windows.Forms.CheckBox cbDefaultEntities;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader logicalName;
        private System.Windows.Forms.ColumnHeader displayName;
        private System.Windows.Forms.GroupBox gbSelectedEntity;
        private System.Windows.Forms.TabControl tcSelectedEntityTabs;
        private System.Windows.Forms.TabPage tpAttributes;
        private System.Windows.Forms.TabPage Forms;
        private System.Windows.Forms.TabPage tpFormFields;
        private System.Windows.Forms.TabPage tpViews;
        private System.Windows.Forms.TabPage tpBooleans;
        private System.Windows.Forms.TabPage tpPicklists;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.ColumnHeader attrLogicalName;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.ListView listView6;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.ColumnHeader formLogicalName;
        private System.Windows.Forms.ColumnHeader formFieldLogicalName;
        private System.Windows.Forms.ColumnHeader viewLogicalName;
        private System.Windows.Forms.ColumnHeader boolLogicalName;
        private System.Windows.Forms.ColumnHeader picklistLogicalName;
    }
}
