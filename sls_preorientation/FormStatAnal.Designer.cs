namespace PreAddTech
{
    partial class FormStatAnal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatAnal));
            this.dataGridViewGroupAnalise = new System.Windows.Forms.DataGridView();
            this.varDatasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripStatAnal = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCalculate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxVariantAnalize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFiltration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSorting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStripStatAnal = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarStatAnal = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelStatAnal = new System.Windows.Forms.ToolStripStatusLabel();
            this.M0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudyPar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyseSelect = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Calculate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SourceData = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Histogram = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DataTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.History = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupAnalise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDatasBindingSource)).BeginInit();
            this.toolStripStatAnal.SuspendLayout();
            this.statusStripStatAnal.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGroupAnalise
            // 
            this.dataGridViewGroupAnalise.AllowUserToOrderColumns = true;
            this.dataGridViewGroupAnalise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupAnalise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.M0,
            this.Number,
            this.Group,
            this.StudyPar,
            this.ModelPath,
            this.AnalyseSelect,
            this.Calculate,
            this.SourceData,
            this.Histogram,
            this.DataTime,
            this.Comment,
            this.History});
            this.dataGridViewGroupAnalise.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewGroupAnalise.Name = "dataGridViewGroupAnalise";
            this.dataGridViewGroupAnalise.Size = new System.Drawing.Size(924, 508);
            this.dataGridViewGroupAnalise.TabIndex = 0;
            // 
            // toolStripStatAnal
            // 
            this.toolStripStatAnal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCalculate,
            this.toolStripSeparator7,
            this.toolStripComboBoxVariantAnalize,
            this.toolStripSeparator4,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.toolStripButtonLoad,
            this.toolStripSeparator1,
            this.toolStripSeparator10,
            this.toolStripButtonDelete,
            this.toolStripSeparator6,
            this.toolStripSeparator8,
            this.toolStripButtonFiltration,
            this.toolStripSeparator5,
            this.toolStripButtonSorting,
            this.toolStripSeparator9});
            this.toolStripStatAnal.Location = new System.Drawing.Point(0, 0);
            this.toolStripStatAnal.Name = "toolStripStatAnal";
            this.toolStripStatAnal.Size = new System.Drawing.Size(924, 25);
            this.toolStripStatAnal.TabIndex = 1;
            this.toolStripStatAnal.Text = "toolStrip1";
            // 
            // toolStripButtonCalculate
            // 
            this.toolStripButtonCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCalculate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCalculate.Image")));
            this.toolStripButtonCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCalculate.Name = "toolStripButtonCalculate";
            this.toolStripButtonCalculate.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonCalculate.Text = "Анализ";
            this.toolStripButtonCalculate.ToolTipText = "Анализ выбранных данных";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxVariantAnalize
            // 
            this.toolStripComboBoxVariantAnalize.Items.AddRange(new object[] {
            "1. Все данные (сравнительный анализ)",
            "2. Все данные (статистический анализ)",
            "2. Все данные по выбранным видам анализа ",
            "3. Выделенные данные"});
            this.toolStripComboBoxVariantAnalize.Name = "toolStripComboBoxVariantAnalize";
            this.toolStripComboBoxVariantAnalize.Size = new System.Drawing.Size(300, 25);
            this.toolStripComboBoxVariantAnalize.Text = "1. Все данные (сравнительный анализ)";
            this.toolStripComboBoxVariantAnalize.ToolTipText = "Выбор данных";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(69, 22);
            this.toolStripButtonSave.Text = "Сохранить";
            this.toolStripButtonSave.ToolTipText = "Сохранить данные";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonLoad.Text = "Загрузить";
            this.toolStripButtonLoad.ToolTipText = "Загрузить данные";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(63, 22);
            this.toolStripButtonDelete.Text = "Удаление";
            this.toolStripButtonDelete.ToolTipText = "Удаление выбранных записей";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFiltration
            // 
            this.toolStripButtonFiltration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFiltration.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFiltration.Image")));
            this.toolStripButtonFiltration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFiltration.Name = "toolStripButtonFiltration";
            this.toolStripButtonFiltration.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonFiltration.Text = "Фильтр";
            this.toolStripButtonFiltration.ToolTipText = "Фильтр по выбранному образцу";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSorting
            // 
            this.toolStripButtonSorting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSorting.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSorting.Image")));
            this.toolStripButtonSorting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSorting.Name = "toolStripButtonSorting";
            this.toolStripButtonSorting.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonSorting.Text = "Сортировка";
            this.toolStripButtonSorting.ToolTipText = "Сортировка по выбранному столбцу";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStripStatAnal
            // 
            this.statusStripStatAnal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarStatAnal,
            this.toolStripStatusLabelStatAnal});
            this.statusStripStatAnal.Location = new System.Drawing.Point(0, 536);
            this.statusStripStatAnal.Name = "statusStripStatAnal";
            this.statusStripStatAnal.Size = new System.Drawing.Size(924, 25);
            this.statusStripStatAnal.TabIndex = 2;
            this.statusStripStatAnal.Text = "statusStrip1";
            // 
            // toolStripProgressBarStatAnal
            // 
            this.toolStripProgressBarStatAnal.Name = "toolStripProgressBarStatAnal";
            this.toolStripProgressBarStatAnal.Size = new System.Drawing.Size(400, 19);
            this.toolStripProgressBarStatAnal.Step = 5;
            this.toolStripProgressBarStatAnal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabelStatAnal
            // 
            this.toolStripStatusLabelStatAnal.Name = "toolStripStatusLabelStatAnal";
            this.toolStripStatusLabelStatAnal.Size = new System.Drawing.Size(70, 20);
            this.toolStripStatusLabelStatAnal.Text = "Нет данных";
            // 
            // M0
            // 
            this.M0.DataPropertyName = "SelectVar";
            this.M0.Frozen = true;
            this.M0.HeaderText = "Выбор";
            this.M0.MinimumWidth = 30;
            this.M0.Name = "M0";
            this.M0.ToolTipText = "Метка выбора";
            this.M0.Width = 55;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "№";
            this.Number.MaxInputLength = 20;
            this.Number.MinimumWidth = 50;
            this.Number.Name = "Number";
            this.Number.ToolTipText = "Порядковый номер набора данных";
            this.Number.Width = 50;
            // 
            // Group
            // 
            this.Group.DataPropertyName = "Group";
            this.Group.HeaderText = "Группа";
            this.Group.MaxInputLength = 20;
            this.Group.MinimumWidth = 50;
            this.Group.Name = "Group";
            this.Group.ToolTipText = "Группа данных по общей задаче";
            this.Group.Width = 50;
            // 
            // StudyPar
            // 
            this.StudyPar.DataPropertyName = "Name";
            this.StudyPar.HeaderText = "Исследуемый признак";
            this.StudyPar.MaxInputLength = 300;
            this.StudyPar.MinimumWidth = 150;
            this.StudyPar.Name = "StudyPar";
            this.StudyPar.ReadOnly = true;
            this.StudyPar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StudyPar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StudyPar.Width = 200;
            // 
            // ModelPath
            // 
            this.ModelPath.DataPropertyName = "Path";
            this.ModelPath.HeaderText = "Путь к STL-файлу";
            this.ModelPath.MaxInputLength = 500;
            this.ModelPath.MinimumWidth = 100;
            this.ModelPath.Name = "ModelPath";
            this.ModelPath.Width = 200;
            // 
            // AnalyseSelect
            // 
            this.AnalyseSelect.DataPropertyName = "SelectAnalyse";
            this.AnalyseSelect.DropDownWidth = 5;
            this.AnalyseSelect.HeaderText = "Выбор вида анализа";
            this.AnalyseSelect.Items.AddRange(new object[] {
            "1. Стат. анализ (моментные характеристики)",
            "2. Стат. анализ (квантили распределения)",
            "3. Проверка стат. гипотезы (равномерный з-н)",
            "4. Сравнительный анализ данных"});
            this.AnalyseSelect.MinimumWidth = 200;
            this.AnalyseSelect.Name = "AnalyseSelect";
            this.AnalyseSelect.Width = 200;
            // 
            // Calculate
            // 
            this.Calculate.HeaderText = "Результаты анализа";
            this.Calculate.MinimumWidth = 80;
            this.Calculate.Name = "Calculate";
            this.Calculate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Calculate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Calculate.Text = "";
            this.Calculate.UseColumnTextForButtonValue = true;
            // 
            // SourceData
            // 
            this.SourceData.HeaderText = "Исходные данные";
            this.SourceData.Name = "SourceData";
            this.SourceData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Histogram
            // 
            this.Histogram.HeaderText = "Гистограмма";
            this.Histogram.MinimumWidth = 75;
            this.Histogram.Name = "Histogram";
            this.Histogram.Text = "Показать";
            this.Histogram.UseColumnTextForButtonValue = true;
            // 
            // DataTime
            // 
            this.DataTime.DataPropertyName = "DateTime";
            this.DataTime.HeaderText = "Дата: время";
            this.DataTime.MaxInputLength = 80;
            this.DataTime.Name = "DataTime";
            this.DataTime.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Комментарий";
            this.Comment.MinimumWidth = 80;
            this.Comment.Name = "Comment";
            this.Comment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Comment.Text = "Нет комментария";
            // 
            // History
            // 
            this.History.HeaderText = "История";
            this.History.Name = "History";
            // 
            // FormStatAnal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 561);
            this.Controls.Add(this.statusStripStatAnal);
            this.Controls.Add(this.toolStripStatAnal);
            this.Controls.Add(this.dataGridViewGroupAnalise);
            this.Name = "FormStatAnal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистический анализ исследуемых признаков";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupAnalise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varDatasBindingSource)).EndInit();
            this.toolStripStatAnal.ResumeLayout(false);
            this.toolStripStatAnal.PerformLayout();
            this.statusStripStatAnal.ResumeLayout(false);
            this.statusStripStatAnal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGroupAnalise;
        private System.Windows.Forms.ToolStrip toolStripStatAnal;
        private System.Windows.Forms.StatusStrip statusStripStatAnal;
        private System.Windows.Forms.ToolStripButton toolStripButtonCalculate;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarStatAnal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatAnal;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxVariantAnalize;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonFiltration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonSorting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.BindingSource varDatasBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectVarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectAnalyseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultAnalyseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn M0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyPar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelPath;
        private System.Windows.Forms.DataGridViewComboBoxColumn AnalyseSelect;
        private System.Windows.Forms.DataGridViewButtonColumn Calculate;
        private System.Windows.Forms.DataGridViewButtonColumn SourceData;
        private System.Windows.Forms.DataGridViewButtonColumn Histogram;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataTime;
        private System.Windows.Forms.DataGridViewButtonColumn Comment;
        private System.Windows.Forms.DataGridViewButtonColumn History;
    }
}