namespace PreAddTech
{
    /// <summary>
    /// Основной класс
    /// </summary>
    partial class ATPreparation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATPreparation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCreateVoxModel = new System.Windows.Forms.Button();
            this.dataGridViewVariants = new System.Windows.Forms.DataGridView();
            this.M0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.variantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonCreateTrModels = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBoxMark = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxHistory = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEvaluation = new System.Windows.Forms.Button();
            this.buttonAnalysisManufacturability = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonLanguage = new System.Windows.Forms.Button();
            this.varDatasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varModelsBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.varDatasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateVoxModel
            // 
            resources.ApplyResources(this.buttonCreateVoxModel, "buttonCreateVoxModel");
            this.buttonCreateVoxModel.Name = "buttonCreateVoxModel";
            this.buttonCreateVoxModel.UseVisualStyleBackColor = true;
            this.buttonCreateVoxModel.Click += new System.EventHandler(this.ButtonCreateVoxModel_Click);
            // 
            // dataGridViewVariants
            // 
            this.dataGridViewVariants.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewVariants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVariants.AutoGenerateColumns = false;
            this.dataGridViewVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M0,
            this.variantDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn});
            this.dataGridViewVariants.DataSource = this.varModelsBindingSource;
            resources.ApplyResources(this.dataGridViewVariants, "dataGridViewVariants");
            this.dataGridViewVariants.Name = "dataGridViewVariants";
            // 
            // M0
            // 
            this.M0.DataPropertyName = "Id";
            this.M0.FalseValue = "0";
            resources.ApplyResources(this.M0, "M0");
            this.M0.Name = "M0";
            this.M0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.M0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.M0.TrueValue = "1";
            // 
            // variantDataGridViewTextBoxColumn
            // 
            this.variantDataGridViewTextBoxColumn.DataPropertyName = "Variant";
            resources.ApplyResources(this.variantDataGridViewTextBoxColumn, "variantDataGridViewTextBoxColumn");
            this.variantDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.variantDataGridViewTextBoxColumn.Name = "variantDataGridViewTextBoxColumn";
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            resources.ApplyResources(this.groupDataGridViewTextBoxColumn, "groupDataGridViewTextBoxColumn");
            this.groupDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            // 
            // varModelsBindingSource
            // 
            this.varModelsBindingSource.DataSource = typeof(PreAddTech.VarModels);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonAnalisysLayer_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonAnalisysOrientation_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonAnalPacking_Click);
            // 
            // buttonCreateTrModels
            // 
            resources.ApplyResources(this.buttonCreateTrModels, "buttonCreateTrModels");
            this.buttonCreateTrModels.Name = "buttonCreateTrModels";
            this.buttonCreateTrModels.UseVisualStyleBackColor = true;
            this.buttonCreateTrModels.Click += new System.EventHandler(this.ButtonFox_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonAnalMorfo_Click);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonStat_Mod_Click);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonIGT_Click);
            // 
            // buttonInfo
            // 
            resources.ApplyResources(this.buttonInfo, "buttonInfo");
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.ButtonAboutProgram_Click);
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.richTextBoxMark);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // richTextBoxMark
            // 
            this.richTextBoxMark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.varModelsBindingSource, "Comment", true));
            resources.ApplyResources(this.richTextBoxMark, "richTextBoxMark");
            this.richTextBoxMark.Name = "richTextBoxMark";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.buttonCreateTrModels);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // labelHelp
            // 
            resources.ApplyResources(this.labelHelp, "labelHelp");
            this.labelHelp.Name = "labelHelp";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBoxHistory);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // richTextBoxHistory
            // 
            resources.ApplyResources(this.richTextBoxHistory, "richTextBoxHistory");
            this.richTextBoxHistory.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxHistory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.varModelsBindingSource, "History", true));
            this.richTextBoxHistory.Name = "richTextBoxHistory";
            this.richTextBoxHistory.ReadOnly = true;
            this.richTextBoxHistory.DoubleClick += new System.EventHandler(this.RichTextBoxHistory_DoubleClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonEvaluation);
            this.panel4.Controls.Add(this.buttonAnalysisManufacturability);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.buttonCreateVoxModel);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // buttonEvaluation
            // 
            resources.ApplyResources(this.buttonEvaluation, "buttonEvaluation");
            this.buttonEvaluation.Name = "buttonEvaluation";
            this.buttonEvaluation.UseVisualStyleBackColor = true;
            this.buttonEvaluation.Click += new System.EventHandler(this.ButtonEvaluation_Click_1);
            // 
            // buttonAnalysisManufacturability
            // 
            resources.ApplyResources(this.buttonAnalysisManufacturability, "buttonAnalysisManufacturability");
            this.buttonAnalysisManufacturability.Name = "buttonAnalysisManufacturability";
            this.buttonAnalysisManufacturability.UseVisualStyleBackColor = true;
            this.buttonAnalysisManufacturability.Click += new System.EventHandler(this.ButtonAnalysisManufacturability_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonHelp
            // 
            resources.ApplyResources(this.buttonHelp, "buttonHelp");
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // buttonLanguage
            // 
            resources.ApplyResources(this.buttonLanguage, "buttonLanguage");
            this.buttonLanguage.Name = "buttonLanguage";
            this.buttonLanguage.UseVisualStyleBackColor = true;
            this.buttonLanguage.Click += new System.EventHandler(this.ButtonLanguage_Click);
            // 
            // varDatasBindingSource
            // 
            this.varDatasBindingSource.DataSource = typeof(PreAddTech.VarDatas);
            // 
            // ATPreparation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.dataGridViewVariants);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ATPreparation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ATPreparation_FormClosing);
            this.Load += new System.EventHandler(this.ATPreparation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varModelsBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.varDatasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateVoxModel;
        private System.Windows.Forms.DataGridView dataGridViewVariants;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonCreateTrModels;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBoxMark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// Запись истории действий пользователя
        /// </summary>
        public System.Windows.Forms.RichTextBox richTextBoxHistory;
        /// <summary>
        /// Варианты расчетов
        /// </summary>
        public System.Windows.Forms.BindingSource varModelsBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn M0;
        private System.Windows.Forms.DataGridViewTextBoxColumn variantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonEvaluation;
        private System.Windows.Forms.Button buttonAnalysisManufacturability;
        private System.Windows.Forms.Button buttonHelp;
        public System.Windows.Forms.BindingSource varDatasBindingSource;
        private System.Windows.Forms.Button buttonLanguage;
    }
}