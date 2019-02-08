namespace PreAddTech
{
    partial class FormGist
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGist));
            this.chartGistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSwitch = new System.Windows.Forms.Button();
            this.chartIntegral = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonProperty = new System.Windows.Forms.Button();
            this.propertyGridUniverse = new System.Windows.Forms.PropertyGrid();
            this.buttonComparison = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.richTextBoxResultVerify = new System.Windows.Forms.RichTextBox();
            this.comboBoxAlfa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartGistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegral)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGistogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGistogram.ChartAreas.Add(chartArea1);
            this.chartGistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGistogram.Location = new System.Drawing.Point(0, 0);
            this.chartGistogram.Name = "chartGistogram";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartGistogram.Series.Add(series1);
            this.chartGistogram.Size = new System.Drawing.Size(784, 400);
            this.chartGistogram.TabIndex = 0;
            this.chartGistogram.Text = "chart1";
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Location = new System.Drawing.Point(-1, 0);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(250, 25);
            this.buttonSwitch.TabIndex = 1;
            this.buttonSwitch.Text = "Интегральная функция распределения";
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.ButtonSwitch_Click);
            // 
            // chartIntegral
            // 
            chartArea2.Name = "ChartArea1";
            this.chartIntegral.ChartAreas.Add(chartArea2);
            this.chartIntegral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIntegral.Location = new System.Drawing.Point(0, 0);
            this.chartIntegral.Name = "chartIntegral";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartIntegral.Series.Add(series2);
            this.chartIntegral.Size = new System.Drawing.Size(784, 400);
            this.chartIntegral.TabIndex = 2;
            this.chartIntegral.Text = "chart1";
            // 
            // buttonProperty
            // 
            this.buttonProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProperty.Location = new System.Drawing.Point(664, 0);
            this.buttonProperty.Name = "buttonProperty";
            this.buttonProperty.Size = new System.Drawing.Size(120, 25);
            this.buttonProperty.TabIndex = 8;
            this.buttonProperty.Text = "Настройки";
            this.buttonProperty.UseVisualStyleBackColor = true;
            this.buttonProperty.Click += new System.EventHandler(this.ButtonProperty_Click);
            // 
            // propertyGridUniverse
            // 
            this.propertyGridUniverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridUniverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertyGridUniverse.Location = new System.Drawing.Point(501, 25);
            this.propertyGridUniverse.Name = "propertyGridUniverse";
            this.propertyGridUniverse.SelectedObject = this.chartGistogram;
            this.propertyGridUniverse.Size = new System.Drawing.Size(283, 375);
            this.propertyGridUniverse.TabIndex = 9;
            this.propertyGridUniverse.ToolbarVisible = false;
            this.propertyGridUniverse.Visible = false;
            // 
            // buttonComparison
            // 
            this.buttonComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonComparison.Location = new System.Drawing.Point(256, 0);
            this.buttonComparison.Name = "buttonComparison";
            this.buttonComparison.Size = new System.Drawing.Size(136, 25);
            this.buttonComparison.TabIndex = 17;
            this.buttonComparison.Text = "Сравнительный анализ";
            this.buttonComparison.UseVisualStyleBackColor = true;
            this.buttonComparison.Click += new System.EventHandler(this.buttonComparison_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTest.Location = new System.Drawing.Point(399, 0);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(136, 25);
            this.buttonTest.TabIndex = 18;
            this.buttonTest.Text = "Проверка гипотезы";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // richTextBoxResultVerify
            // 
            this.richTextBoxResultVerify.Location = new System.Drawing.Point(501, 31);
            this.richTextBoxResultVerify.Name = "richTextBoxResultVerify";
            this.richTextBoxResultVerify.ReadOnly = true;
            this.richTextBoxResultVerify.Size = new System.Drawing.Size(271, 357);
            this.richTextBoxResultVerify.TabIndex = 19;
            this.richTextBoxResultVerify.Text = "";
            this.richTextBoxResultVerify.Visible = false;
            this.richTextBoxResultVerify.DoubleClick += new System.EventHandler(this.richTextBoxResultVerify_DoubleClick);
            // 
            // comboBoxAlfa
            // 
            this.comboBoxAlfa.FormattingEnabled = true;
            this.comboBoxAlfa.ItemHeight = 13;
            this.comboBoxAlfa.Items.AddRange(new object[] {
            "0,200",
            "0,150",
            "0,100",
            "0,050",
            "0,025",
            "0,010",
            "0,005",
            "0,001"});
            this.comboBoxAlfa.Location = new System.Drawing.Point(544, 2);
            this.comboBoxAlfa.MaxDropDownItems = 9;
            this.comboBoxAlfa.Name = "comboBoxAlfa";
            this.comboBoxAlfa.Size = new System.Drawing.Size(110, 21);
            this.comboBoxAlfa.TabIndex = 21;
            this.comboBoxAlfa.Text = "0,05";
            this.comboBoxAlfa.UseWaitCursor = true;
            // 
            // FormGist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 400);
            this.Controls.Add(this.richTextBoxResultVerify);
            this.Controls.Add(this.comboBoxAlfa);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonComparison);
            this.Controls.Add(this.propertyGridUniverse);
            this.Controls.Add(this.buttonProperty);
            this.Controls.Add(this.buttonSwitch);
            this.Controls.Add(this.chartGistogram);
            this.Controls.Add(this.chartIntegral);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGist";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гистограмма распределения";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.chartGistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        /// Гистограмма распределения
        /// </summary>
        public System.Windows.Forms.DataVisualization.Charting.Chart chartGistogram;
        private System.Windows.Forms.Button buttonSwitch;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartIntegral;
        private System.Windows.Forms.Button buttonProperty;
        private System.Windows.Forms.PropertyGrid propertyGridUniverse;
        private System.Windows.Forms.Button buttonComparison;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.RichTextBox richTextBoxResultVerify;
        private System.Windows.Forms.ComboBox comboBoxAlfa;
    }
}