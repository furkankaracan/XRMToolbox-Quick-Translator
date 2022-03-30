
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
            this.Forms = new System.Windows.Forms.TabPage();
            this.tpFormFields = new System.Windows.Forms.TabPage();
            this.tpViews = new System.Windows.Forms.TabPage();
            this.tpBooleans = new System.Windows.Forms.TabPage();
            this.tpPicklists = new System.Windows.Forms.TabPage();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.dgvForms = new System.Windows.Forms.DataGridView();
            this.attrLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFormFields = new System.Windows.Forms.DataGridView();
            this.dgvViews = new System.Windows.Forms.DataGridView();
            this.dgvBooleans = new System.Windows.Forms.DataGridView();
            this.dgvPicklists = new System.Windows.Forms.DataGridView();
            this.boolLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picklistLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewsLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formFieldsLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooleans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicklists)).BeginInit();
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
            this.tbFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyUp);
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
            this.lvEntities.SelectedIndexChanged += new System.EventHandler(this.lvEntities_SelectedIndexChanged);
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
            this.tcSelectedEntityTabs.SelectedIndexChanged += new System.EventHandler(this.tcSelectedEntityTabs_TabIndexChanged);
            this.tcSelectedEntityTabs.TabIndexChanged += new System.EventHandler(this.tcSelectedEntityTabs_TabIndexChanged);
            // 
            // tpAttributes
            // 
            this.tpAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.tpAttributes.Controls.Add(this.dgvAttributes);
            this.tpAttributes.Location = new System.Drawing.Point(4, 25);
            this.tpAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.tpAttributes.Name = "tpAttributes";
            this.tpAttributes.Padding = new System.Windows.Forms.Padding(2);
            this.tpAttributes.Size = new System.Drawing.Size(653, 524);
            this.tpAttributes.TabIndex = 0;
            this.tpAttributes.Text = "Attributes";
            // 
            // Forms
            // 
            this.Forms.BackColor = System.Drawing.SystemColors.Control;
            this.Forms.Controls.Add(this.dgvForms);
            this.Forms.Location = new System.Drawing.Point(4, 25);
            this.Forms.Margin = new System.Windows.Forms.Padding(2);
            this.Forms.Name = "Forms";
            this.Forms.Padding = new System.Windows.Forms.Padding(2);
            this.Forms.Size = new System.Drawing.Size(653, 524);
            this.Forms.TabIndex = 1;
            this.Forms.Text = "Forms";
            // 
            // tpFormFields
            // 
            this.tpFormFields.BackColor = System.Drawing.SystemColors.Control;
            this.tpFormFields.Controls.Add(this.dgvFormFields);
            this.tpFormFields.Location = new System.Drawing.Point(4, 25);
            this.tpFormFields.Margin = new System.Windows.Forms.Padding(2);
            this.tpFormFields.Name = "tpFormFields";
            this.tpFormFields.Padding = new System.Windows.Forms.Padding(2);
            this.tpFormFields.Size = new System.Drawing.Size(653, 524);
            this.tpFormFields.TabIndex = 2;
            this.tpFormFields.Text = "Form Fields";
            // 
            // tpViews
            // 
            this.tpViews.BackColor = System.Drawing.SystemColors.Control;
            this.tpViews.Controls.Add(this.dgvViews);
            this.tpViews.Location = new System.Drawing.Point(4, 25);
            this.tpViews.Margin = new System.Windows.Forms.Padding(2);
            this.tpViews.Name = "tpViews";
            this.tpViews.Padding = new System.Windows.Forms.Padding(2);
            this.tpViews.Size = new System.Drawing.Size(653, 524);
            this.tpViews.TabIndex = 3;
            this.tpViews.Text = "Views";
            // 
            // tpBooleans
            // 
            this.tpBooleans.BackColor = System.Drawing.SystemColors.Control;
            this.tpBooleans.Controls.Add(this.dgvBooleans);
            this.tpBooleans.Location = new System.Drawing.Point(4, 25);
            this.tpBooleans.Margin = new System.Windows.Forms.Padding(2);
            this.tpBooleans.Name = "tpBooleans";
            this.tpBooleans.Padding = new System.Windows.Forms.Padding(2);
            this.tpBooleans.Size = new System.Drawing.Size(653, 524);
            this.tpBooleans.TabIndex = 4;
            this.tpBooleans.Text = "Booleans";
            // 
            // tpPicklists
            // 
            this.tpPicklists.BackColor = System.Drawing.SystemColors.Control;
            this.tpPicklists.Controls.Add(this.dgvPicklists);
            this.tpPicklists.Location = new System.Drawing.Point(4, 25);
            this.tpPicklists.Margin = new System.Windows.Forms.Padding(2);
            this.tpPicklists.Name = "tpPicklists";
            this.tpPicklists.Padding = new System.Windows.Forms.Padding(2);
            this.tpPicklists.Size = new System.Drawing.Size(653, 524);
            this.tpPicklists.TabIndex = 5;
            this.tpPicklists.Text = "Picklists";
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attrLogicalName});
            this.dgvAttributes.Location = new System.Drawing.Point(5, 5);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.Size = new System.Drawing.Size(643, 514);
            this.dgvAttributes.TabIndex = 0;
            // 
            // dgvForms
            // 
            this.dgvForms.AllowUserToAddRows = false;
            this.dgvForms.AllowUserToDeleteRows = false;
            this.dgvForms.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForms.Location = new System.Drawing.Point(5, 5);
            this.dgvForms.Name = "dgvForms";
            this.dgvForms.Size = new System.Drawing.Size(643, 514);
            this.dgvForms.TabIndex = 0;
            // 
            // attrLogicalName
            // 
            this.attrLogicalName.HeaderText = "Logical Name";
            this.attrLogicalName.Name = "attrLogicalName";
            this.attrLogicalName.ReadOnly = true;
            this.attrLogicalName.Width = 150;
            // 
            // dgvFormFields
            // 
            this.dgvFormFields.AllowUserToAddRows = false;
            this.dgvFormFields.AllowUserToDeleteRows = false;
            this.dgvFormFields.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFormFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formFieldsLogicalName});
            this.dgvFormFields.Location = new System.Drawing.Point(5, 5);
            this.dgvFormFields.Name = "dgvFormFields";
            this.dgvFormFields.Size = new System.Drawing.Size(643, 514);
            this.dgvFormFields.TabIndex = 0;
            // 
            // dgvViews
            // 
            this.dgvViews.AllowUserToAddRows = false;
            this.dgvViews.AllowUserToDeleteRows = false;
            this.dgvViews.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvViews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.viewsLogicalName});
            this.dgvViews.Location = new System.Drawing.Point(5, 5);
            this.dgvViews.Name = "dgvViews";
            this.dgvViews.Size = new System.Drawing.Size(643, 514);
            this.dgvViews.TabIndex = 0;
            // 
            // dgvBooleans
            // 
            this.dgvBooleans.AllowUserToAddRows = false;
            this.dgvBooleans.AllowUserToDeleteRows = false;
            this.dgvBooleans.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBooleans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooleans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.boolLogicalName});
            this.dgvBooleans.Location = new System.Drawing.Point(5, 5);
            this.dgvBooleans.Name = "dgvBooleans";
            this.dgvBooleans.Size = new System.Drawing.Size(643, 514);
            this.dgvBooleans.TabIndex = 0;
            // 
            // dgvPicklists
            // 
            this.dgvPicklists.AllowUserToAddRows = false;
            this.dgvPicklists.AllowUserToDeleteRows = false;
            this.dgvPicklists.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPicklists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPicklists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.picklistLogicalName});
            this.dgvPicklists.Location = new System.Drawing.Point(5, 5);
            this.dgvPicklists.Name = "dgvPicklists";
            this.dgvPicklists.Size = new System.Drawing.Size(643, 514);
            this.dgvPicklists.TabIndex = 0;
            // 
            // boolLogicalName
            // 
            this.boolLogicalName.HeaderText = "Logical Name";
            this.boolLogicalName.Name = "boolLogicalName";
            this.boolLogicalName.ReadOnly = true;
            this.boolLogicalName.Width = 150;
            // 
            // picklistLogicalName
            // 
            this.picklistLogicalName.HeaderText = "Logical Name";
            this.picklistLogicalName.Name = "picklistLogicalName";
            this.picklistLogicalName.ReadOnly = true;
            this.picklistLogicalName.Width = 150;
            // 
            // viewsLogicalName
            // 
            this.viewsLogicalName.HeaderText = "Logical Name";
            this.viewsLogicalName.Name = "viewsLogicalName";
            this.viewsLogicalName.ReadOnly = true;
            this.viewsLogicalName.Width = 150;
            // 
            // formFieldsLogicalName
            // 
            this.formFieldsLogicalName.HeaderText = "Logical Name";
            this.formFieldsLogicalName.Name = "formFieldsLogicalName";
            this.formFieldsLogicalName.ReadOnly = true;
            this.formFieldsLogicalName.Width = 150;
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
            this.Load += new System.EventHandler(this.MainControl_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooleans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPicklists)).EndInit();
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
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn attrLogicalName;
        private System.Windows.Forms.DataGridView dgvForms;
        private System.Windows.Forms.DataGridView dgvFormFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn formFieldsLogicalName;
        private System.Windows.Forms.DataGridView dgvViews;
        private System.Windows.Forms.DataGridViewTextBoxColumn viewsLogicalName;
        private System.Windows.Forms.DataGridView dgvBooleans;
        private System.Windows.Forms.DataGridViewTextBoxColumn boolLogicalName;
        private System.Windows.Forms.DataGridView dgvPicklists;
        private System.Windows.Forms.DataGridViewTextBoxColumn picklistLogicalName;
    }
}
