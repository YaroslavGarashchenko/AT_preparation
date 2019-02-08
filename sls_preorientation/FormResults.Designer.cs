namespace PreAddTech
{
    partial class FormResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResults));
            this.richTextBoxResultAnalysis = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxResult = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxResultAnalysis
            // 
            this.richTextBoxResultAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResultAnalysis.Location = new System.Drawing.Point(0, 34);
            this.richTextBoxResultAnalysis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxResultAnalysis.Name = "richTextBoxResultAnalysis";
            this.richTextBoxResultAnalysis.Size = new System.Drawing.Size(777, 434);
            this.richTextBoxResultAnalysis.TabIndex = 1;
            this.richTextBoxResultAnalysis.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSelect,
            this.toolStripComboBoxResult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(779, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelect.Image")));
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(84, 25);
            this.toolStripButtonSelect.Text = "Просмотр";
            this.toolStripButtonSelect.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripComboBoxResult
            // 
            this.toolStripComboBoxResult.Items.AddRange(new object[] {
            "Площадь и объем триангуляционной модели",
            "Результаты анализа фрактальной размерности методом масштабов",
            "Результаты анализа фрактальной размерности клеточным методом",
            "Полные данные анализа фрактальной размерности"});
            this.toolStripComboBoxResult.Name = "toolStripComboBoxResult";
            this.toolStripComboBoxResult.Size = new System.Drawing.Size(599, 28);
            this.toolStripComboBoxResult.Text = "Выбор...";
            this.toolStripComboBoxResult.ToolTipText = "Выбор данных для просмотра";
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 469);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBoxResultAnalysis);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1061, 728);
            this.MinimumSize = new System.Drawing.Size(661, 358);
            this.Name = "FormResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты анализов исследуемых признаков";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        /// <summary>
        /// Поле просмотра результатов исследования
        /// </summary>
        public System.Windows.Forms.RichTextBox richTextBoxResultAnalysis;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBoxResult;
        public System.Windows.Forms.ToolStripButton toolStripButtonSelect;
    }
}