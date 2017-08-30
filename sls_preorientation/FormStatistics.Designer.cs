namespace PreAddTech
{
    partial class FormStatistics
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
            this.toolStripStat = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxResearchParameter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStat
            // 
            this.toolStripStat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxResearchParameter});
            this.toolStripStat.Location = new System.Drawing.Point(0, 0);
            this.toolStripStat.Name = "toolStripStat";
            this.toolStripStat.Size = new System.Drawing.Size(584, 25);
            this.toolStripStat.TabIndex = 0;
            this.toolStripStat.Text = "toolStrip1";
            // 
            // toolStripComboBoxResearchParameter
            // 
            this.toolStripComboBoxResearchParameter.Name = "toolStripComboBoxResearchParameter";
            this.toolStripComboBoxResearchParameter.Size = new System.Drawing.Size(550, 25);
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.toolStripStat);
            this.Name = "FormStatistics";
            this.Text = "Результаты статистического анализа";
            this.toolStripStat.ResumeLayout(false);
            this.toolStripStat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripStat;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxResearchParameter;
    }
}