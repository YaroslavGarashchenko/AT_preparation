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
            this.chartGistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSwitch = new System.Windows.Forms.Button();
            this.chartIntegral = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.chartGistogram.Size = new System.Drawing.Size(784, 361);
            this.chartGistogram.TabIndex = 0;
            this.chartGistogram.Text = "chart1";
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Location = new System.Drawing.Point(0, 0);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(226, 26);
            this.buttonSwitch.TabIndex = 1;
            this.buttonSwitch.Text = "Интегральная функция распределения";
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.buttonSwitch_Click);
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
            this.chartIntegral.Size = new System.Drawing.Size(784, 361);
            this.chartIntegral.TabIndex = 2;
            this.chartIntegral.Text = "chart1";
            // 
            // FormGist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.buttonSwitch);
            this.Controls.Add(this.chartGistogram);
            this.Controls.Add(this.chartIntegral);
            this.Name = "FormGist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гистограмма распределения";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.chartGistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntegral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartGistogram;
        private System.Windows.Forms.Button buttonSwitch;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartIntegral;
    }
}