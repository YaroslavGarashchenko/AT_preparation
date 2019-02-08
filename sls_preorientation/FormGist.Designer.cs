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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGist));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            resources.ApplyResources(this.chartGistogram, "chartGistogram");
            chartArea1.Name = "ChartArea1";
            this.chartGistogram.ChartAreas.Add(chartArea1);
            this.chartGistogram.Name = "chartGistogram";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartGistogram.Series.Add(series1);
            // 
            // buttonSwitch
            // 
            resources.ApplyResources(this.buttonSwitch, "buttonSwitch");
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.ButtonSwitch_Click);
            // 
            // chartIntegral
            // 
            resources.ApplyResources(this.chartIntegral, "chartIntegral");
            chartArea2.Name = "ChartArea1";
            this.chartIntegral.ChartAreas.Add(chartArea2);
            this.chartIntegral.Name = "chartIntegral";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartIntegral.Series.Add(series2);
            // 
            // buttonProperty
            // 
            resources.ApplyResources(this.buttonProperty, "buttonProperty");
            this.buttonProperty.Name = "buttonProperty";
            this.buttonProperty.UseVisualStyleBackColor = true;
            this.buttonProperty.Click += new System.EventHandler(this.ButtonProperty_Click);
            // 
            // propertyGridUniverse
            // 
            resources.ApplyResources(this.propertyGridUniverse, "propertyGridUniverse");
            this.propertyGridUniverse.Name = "propertyGridUniverse";
            this.propertyGridUniverse.SelectedObject = this.chartGistogram;
            this.propertyGridUniverse.ToolbarVisible = false;
            // 
            // buttonComparison
            // 
            resources.ApplyResources(this.buttonComparison, "buttonComparison");
            this.buttonComparison.Name = "buttonComparison";
            this.buttonComparison.UseVisualStyleBackColor = true;
            this.buttonComparison.Click += new System.EventHandler(this.ButtonComparison_Click);
            // 
            // buttonTest
            // 
            resources.ApplyResources(this.buttonTest, "buttonTest");
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // richTextBoxResultVerify
            // 
            resources.ApplyResources(this.richTextBoxResultVerify, "richTextBoxResultVerify");
            this.richTextBoxResultVerify.Name = "richTextBoxResultVerify";
            this.richTextBoxResultVerify.ReadOnly = true;
            this.richTextBoxResultVerify.DoubleClick += new System.EventHandler(this.RichTextBoxResultVerify_DoubleClick);
            // 
            // comboBoxAlfa
            // 
            resources.ApplyResources(this.comboBoxAlfa, "comboBoxAlfa");
            this.comboBoxAlfa.FormattingEnabled = true;
            this.comboBoxAlfa.Items.AddRange(new object[] {
            resources.GetString("comboBoxAlfa.Items"),
            resources.GetString("comboBoxAlfa.Items1"),
            resources.GetString("comboBoxAlfa.Items2"),
            resources.GetString("comboBoxAlfa.Items3"),
            resources.GetString("comboBoxAlfa.Items4"),
            resources.GetString("comboBoxAlfa.Items5"),
            resources.GetString("comboBoxAlfa.Items6"),
            resources.GetString("comboBoxAlfa.Items7")});
            this.comboBoxAlfa.Name = "comboBoxAlfa";
            this.comboBoxAlfa.UseWaitCursor = true;
            // 
            // FormGist
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "FormGist";
            this.ShowInTaskbar = false;
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