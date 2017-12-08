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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxResult = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxResultAnalysis
            // 
            this.richTextBoxResultAnalysis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxResultAnalysis.Location = new System.Drawing.Point(0, 28);
            this.richTextBoxResultAnalysis.Name = "richTextBoxResultAnalysis";
            this.richTextBoxResultAnalysis.Size = new System.Drawing.Size(584, 353);
            this.richTextBoxResultAnalysis.TabIndex = 1;
            this.richTextBoxResultAnalysis.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripComboBoxResult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton1.Text = "Просмотр";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripComboBoxResult
            // 
            this.toolStripComboBoxResult.Items.AddRange(new object[] {
            "Площадь и объем триангуляционной модели",
            "Результаты анализа фрактальной размерности"});
            this.toolStripComboBoxResult.Name = "toolStripComboBoxResult";
            this.toolStripComboBoxResult.Size = new System.Drawing.Size(350, 25);
            this.toolStripComboBoxResult.Text = "Выбор...";
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBoxResultAnalysis);
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.RichTextBox richTextBoxResultAnalysis;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBoxResult;
    }
}