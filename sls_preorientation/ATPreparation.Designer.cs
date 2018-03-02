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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varModelsBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateVoxModel
            // 
            this.buttonCreateVoxModel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCreateVoxModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateVoxModel.Location = new System.Drawing.Point(14, 13);
            this.buttonCreateVoxModel.Name = "buttonCreateVoxModel";
            this.buttonCreateVoxModel.Size = new System.Drawing.Size(210, 42);
            this.buttonCreateVoxModel.TabIndex = 0;
            this.buttonCreateVoxModel.Text = "Структурная обратимая декомпозиция";
            this.buttonCreateVoxModel.UseVisualStyleBackColor = true;
            this.buttonCreateVoxModel.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewVariants
            // 
            this.dataGridViewVariants.AllowUserToOrderColumns = true;
            this.dataGridViewVariants.AutoGenerateColumns = false;
            this.dataGridViewVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M0,
            this.variantDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn});
            this.dataGridViewVariants.DataSource = this.varModelsBindingSource;
            this.dataGridViewVariants.Location = new System.Drawing.Point(10, 12);
            this.dataGridViewVariants.Name = "dataGridViewVariants";
            this.dataGridViewVariants.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVariants.Size = new System.Drawing.Size(267, 381);
            this.dataGridViewVariants.TabIndex = 1;
            // 
            // M0
            // 
            this.M0.DataPropertyName = "Id";
            this.M0.FalseValue = "0";
            this.M0.HeaderText = "M0";
            this.M0.MinimumWidth = 15;
            this.M0.Name = "M0";
            this.M0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.M0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.M0.TrueValue = "1";
            this.M0.Width = 25;
            // 
            // variantDataGridViewTextBoxColumn
            // 
            this.variantDataGridViewTextBoxColumn.DataPropertyName = "Variant";
            this.variantDataGridViewTextBoxColumn.HeaderText = "Вариант";
            this.variantDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.variantDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.variantDataGridViewTextBoxColumn.Name = "variantDataGridViewTextBoxColumn";
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Группа";
            this.groupDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.groupDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            // 
            // varModelsBindingSource
            // 
            this.varModelsBindingSource.DataSource = typeof(PreAddTech.VarModels);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(247, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Послойный анализ модели";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ориентация изделия в рабочей области построения";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(247, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 42);
            this.button4.TabIndex = 4;
            this.button4.Text = "Рациональное расположение изделий в рабочей области построения";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonCreateTrModels
            // 
            this.buttonCreateTrModels.Location = new System.Drawing.Point(14, 12);
            this.buttonCreateTrModels.Name = "buttonCreateTrModels";
            this.buttonCreateTrModels.Size = new System.Drawing.Size(210, 42);
            this.buttonCreateTrModels.TabIndex = 5;
            this.buttonCreateTrModels.Text = "Создание триангуляционных моделей";
            this.buttonCreateTrModels.UseVisualStyleBackColor = true;
            this.buttonCreateTrModels.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(247, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(210, 42);
            this.button6.TabIndex = 6;
            this.button6.Text = "Морфологический анализ триангуляционных моделей";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(247, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(210, 66);
            this.button7.TabIndex = 7;
            this.button7.Text = "Статистическое моделирование рабочих процессов интегрированных технологий";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(14, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(210, 66);
            this.button8.TabIndex = 8;
            this.button8.Text = "Интегрированные генеративные технологии (классификация технологий, характеристики" +
    " оборудования)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInfo.Location = new System.Drawing.Point(665, 12);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(85, 30);
            this.buttonInfo.TabIndex = 11;
            this.buttonInfo.Text = "О программе";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.button11_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(407, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(110, 30);
            this.buttonSettings.TabIndex = 12;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(16, 402);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 13);
            this.label23.TabIndex = 31;
            this.label23.Text = "Примечание";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.richTextBoxMark);
            this.panel3.Location = new System.Drawing.Point(10, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 148);
            this.panel3.TabIndex = 30;
            // 
            // richTextBoxMark
            // 
            this.richTextBoxMark.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.varModelsBindingSource, "Comment", true));
            this.richTextBoxMark.Location = new System.Drawing.Point(7, 7);
            this.richTextBoxMark.MaxLength = 1000;
            this.richTextBoxMark.Name = "richTextBoxMark";
            this.richTextBoxMark.Size = new System.Drawing.Size(251, 132);
            this.richTextBoxMark.TabIndex = 0;
            this.richTextBoxMark.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.buttonCreateTrModels);
            this.panel1.Location = new System.Drawing.Point(292, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 144);
            this.panel1.TabIndex = 32;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.Location = new System.Drawing.Point(304, 403);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(201, 13);
            this.labelHelp.TabIndex = 34;
            this.labelHelp.Text = "Информация (история расчетов)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBoxHistory);
            this.panel2.Location = new System.Drawing.Point(292, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 148);
            this.panel2.TabIndex = 33;
            // 
            // richTextBoxHistory
            // 
            this.richTextBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxHistory.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxHistory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.varModelsBindingSource, "History", true));
            this.richTextBoxHistory.Location = new System.Drawing.Point(15, 7);
            this.richTextBoxHistory.MaxLength = 1000000;
            this.richTextBoxHistory.Name = "richTextBoxHistory";
            this.richTextBoxHistory.ReadOnly = true;
            this.richTextBoxHistory.Size = new System.Drawing.Size(452, 132);
            this.richTextBoxHistory.TabIndex = 0;
            this.richTextBoxHistory.Text = "";
            this.richTextBoxHistory.DoubleClick += new System.EventHandler(this.richTextBox2_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(304, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Подсистемы";
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
            this.panel4.Location = new System.Drawing.Point(292, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(476, 178);
            this.panel4.TabIndex = 35;
            // 
            // buttonEvaluation
            // 
            this.buttonEvaluation.Location = new System.Drawing.Point(15, 123);
            this.buttonEvaluation.Name = "buttonEvaluation";
            this.buttonEvaluation.Size = new System.Drawing.Size(210, 42);
            this.buttonEvaluation.TabIndex = 6;
            this.buttonEvaluation.Text = "Результаты анализа";
            this.buttonEvaluation.UseVisualStyleBackColor = true;
            this.buttonEvaluation.Click += new System.EventHandler(this.buttonEvaluation_Click_1);
            // 
            // buttonAnalysisManufacturability
            // 
            this.buttonAnalysisManufacturability.Location = new System.Drawing.Point(247, 123);
            this.buttonAnalysisManufacturability.Name = "buttonAnalysisManufacturability";
            this.buttonAnalysisManufacturability.Size = new System.Drawing.Size(210, 42);
            this.buttonAnalysisManufacturability.TabIndex = 5;
            this.buttonAnalysisManufacturability.Text = "  Визуальный анализ    технологичности изделия";
            this.buttonAnalysisManufacturability.UseVisualStyleBackColor = true;
            this.buttonAnalysisManufacturability.Click += new System.EventHandler(this.buttonAnalysisManufacturability_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(304, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Внешние системы (программы)";
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(540, 12);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(102, 30);
            this.buttonHelp.TabIndex = 39;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // ATPreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 565);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATPreparation";
            this.Text = "Технологическая подготовка материализации сложных изделий аддитивными технологиям" +
    "и";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ATPreparation_FormClosing);
            this.Load += new System.EventHandler(this.ATPreparation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varModelsBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
    }
}