namespace PreAddTech
{
    partial class FormAnalysisSteps
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalysisSteps));
            this.richTextBoxData = new System.Windows.Forms.RichTextBox();
            this.chartDependent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.propertyGridUniverse = new System.Windows.Forms.PropertyGrid();
            this.numericUpDownStepIntervals = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumIntervals = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.buttonProperty = new System.Windows.Forms.Button();
            this.labelShow = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelNumIntervals = new System.Windows.Forms.Label();
            this.richTextBoxQuartile = new System.Windows.Forms.RichTextBox();
            this.buttonAddInComparison = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDependent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxData
            // 
            this.richTextBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxData.AutoWordSelection = true;
            this.richTextBoxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxData.Location = new System.Drawing.Point(632, 25);
            this.richTextBoxData.Name = "richTextBoxData";
            this.richTextBoxData.ReadOnly = true;
            this.richTextBoxData.Size = new System.Drawing.Size(152, 224);
            this.richTextBoxData.TabIndex = 0;
            this.richTextBoxData.Text = "";
            this.richTextBoxData.Visible = false;
            // 
            // chartDependent
            // 
            this.chartDependent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartDependent.ChartAreas.Add(chartArea1);
            this.chartDependent.Location = new System.Drawing.Point(-1, 0);
            this.chartDependent.Name = "chartDependent";
            this.chartDependent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartDependent.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.chartDependent.Size = new System.Drawing.Size(785, 400);
            this.chartDependent.TabIndex = 1;
            this.chartDependent.Text = "chart1";
            this.chartDependent.DoubleClick += new System.EventHandler(this.ChartDependent_DoubleClick);
            // 
            // propertyGridUniverse
            // 
            this.propertyGridUniverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridUniverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertyGridUniverse.Location = new System.Drawing.Point(500, 25);
            this.propertyGridUniverse.Name = "propertyGridUniverse";
            this.propertyGridUniverse.SelectedObject = this.chartDependent;
            this.propertyGridUniverse.Size = new System.Drawing.Size(283, 375);
            this.propertyGridUniverse.TabIndex = 2;
            this.propertyGridUniverse.ToolbarVisible = false;
            this.propertyGridUniverse.Visible = false;
            // 
            // numericUpDownStepIntervals
            // 
            this.numericUpDownStepIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownStepIntervals.DecimalPlaces = 3;
            this.numericUpDownStepIntervals.Location = new System.Drawing.Point(436, 413);
            this.numericUpDownStepIntervals.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownStepIntervals.Name = "numericUpDownStepIntervals";
            this.numericUpDownStepIntervals.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownStepIntervals.TabIndex = 3;
            // 
            // numericUpDownNumIntervals
            // 
            this.numericUpDownNumIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownNumIntervals.Location = new System.Drawing.Point(659, 413);
            this.numericUpDownNumIntervals.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNumIntervals.Name = "numericUpDownNumIntervals";
            this.numericUpDownNumIntervals.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownNumIntervals.TabIndex = 4;
            this.numericUpDownNumIntervals.ValueChanged += new System.EventHandler(this.NumericUpDownNumIntervals_ValueChanged);
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownMax.DecimalPlaces = 2;
            this.numericUpDownMax.Location = new System.Drawing.Point(207, 413);
            this.numericUpDownMax.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownMax.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDownMax.Name = "numericUpDownMax";
            this.numericUpDownMax.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownMax.TabIndex = 5;
            this.numericUpDownMax.ValueChanged += new System.EventHandler(this.NumericUpDownMax_ValueChanged);
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownMin.DecimalPlaces = 2;
            this.numericUpDownMin.Location = new System.Drawing.Point(51, 413);
            this.numericUpDownMin.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownMin.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownMin.TabIndex = 6;
            this.numericUpDownMin.ValueChanged += new System.EventHandler(this.NumericUpDownMin_ValueChanged);
            // 
            // buttonProperty
            // 
            this.buttonProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProperty.Location = new System.Drawing.Point(647, 0);
            this.buttonProperty.Name = "buttonProperty";
            this.buttonProperty.Size = new System.Drawing.Size(136, 25);
            this.buttonProperty.TabIndex = 7;
            this.buttonProperty.Text = "Настройки";
            this.buttonProperty.UseVisualStyleBackColor = true;
            this.buttonProperty.Click += new System.EventHandler(this.ButtonProperty_Click);
            // 
            // labelShow
            // 
            this.labelShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShow.Location = new System.Drawing.Point(12, 0);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(614, 25);
            this.labelShow.TabIndex = 8;
            this.labelShow.Text = "График";
            this.labelShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(19, 417);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(31, 13);
            this.labelMin.TabIndex = 9;
            this.labelMin.Text = "Мин.";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(-1, 0);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(250, 25);
            this.buttonCalculate.TabIndex = 10;
            this.buttonCalculate.Text = "Плотность распределения";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculate_Click);
            // 
            // labelMax
            // 
            this.labelMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(169, 417);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(37, 13);
            this.labelMax.TabIndex = 11;
            this.labelMax.Text = "Макс.";
            // 
            // labelInterval
            // 
            this.labelInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(329, 416);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(102, 13);
            this.labelInterval.TabIndex = 12;
            this.labelInterval.Text = "Размер интервала";
            // 
            // labelNumIntervals
            // 
            this.labelNumIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumIntervals.AutoSize = true;
            this.labelNumIntervals.Location = new System.Drawing.Point(554, 417);
            this.labelNumIntervals.Name = "labelNumIntervals";
            this.labelNumIntervals.Size = new System.Drawing.Size(103, 13);
            this.labelNumIntervals.TabIndex = 13;
            this.labelNumIntervals.Text = "Кол-во интервалов";
            // 
            // richTextBoxQuartile
            // 
            this.richTextBoxQuartile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxQuartile.AutoWordSelection = true;
            this.richTextBoxQuartile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxQuartile.Location = new System.Drawing.Point(632, 255);
            this.richTextBoxQuartile.Name = "richTextBoxQuartile";
            this.richTextBoxQuartile.ReadOnly = true;
            this.richTextBoxQuartile.Size = new System.Drawing.Size(152, 145);
            this.richTextBoxQuartile.TabIndex = 14;
            this.richTextBoxQuartile.Text = "";
            this.richTextBoxQuartile.Visible = false;
            // 
            // buttonAddInComparison
            // 
            this.buttonAddInComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddInComparison.Location = new System.Drawing.Point(256, 0);
            this.buttonAddInComparison.Name = "buttonAddInComparison";
            this.buttonAddInComparison.Size = new System.Drawing.Size(136, 25);
            this.buttonAddInComparison.TabIndex = 15;
            this.buttonAddInComparison.Text = "В подсистему анализа";
            this.buttonAddInComparison.UseVisualStyleBackColor = true;
            this.buttonAddInComparison.Click += new System.EventHandler(this.ButtonComparison_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTest.Location = new System.Drawing.Point(400, 0);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(136, 25);
            this.buttonTest.TabIndex = 19;
            this.buttonTest.Text = "Проверка гипотезы";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // FormAnalysisSteps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonAddInComparison);
            this.Controls.Add(this.propertyGridUniverse);
            this.Controls.Add(this.richTextBoxQuartile);
            this.Controls.Add(this.labelNumIntervals);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelShow);
            this.Controls.Add(this.buttonProperty);
            this.Controls.Add(this.numericUpDownMin);
            this.Controls.Add(this.numericUpDownMax);
            this.Controls.Add(this.numericUpDownNumIntervals);
            this.Controls.Add(this.numericUpDownStepIntervals);
            this.Controls.Add(this.richTextBoxData);
            this.Controls.Add(this.chartDependent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnalysisSteps";
            this.Text = "Анализ данных по слоям";
            this.Load += new System.EventHandler(this.FormAnalysisSteps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDependent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBoxData;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartDependent;
        private System.Windows.Forms.PropertyGrid propertyGridUniverse;
        private System.Windows.Forms.NumericUpDown numericUpDownStepIntervals;
        private System.Windows.Forms.NumericUpDown numericUpDownMax;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.Button buttonProperty;
        private System.Windows.Forms.Label labelShow;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label labelNumIntervals;
        public System.Windows.Forms.NumericUpDown numericUpDownNumIntervals;
        public System.Windows.Forms.RichTextBox richTextBoxQuartile;
        private System.Windows.Forms.Button buttonTest;
        public System.Windows.Forms.Button buttonAddInComparison;
    }
}