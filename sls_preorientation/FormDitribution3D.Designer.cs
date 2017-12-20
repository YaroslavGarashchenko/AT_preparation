namespace PreAddTech
{
    partial class FormDitribution3D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDitribution3D));
            this.trackBarHeight = new System.Windows.Forms.TrackBar();
            this.labelСurrent = new System.Windows.Forms.Label();
            this.buttonSection = new System.Windows.Forms.Button();
            this.numericUpDownB2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownR2 = new System.Windows.Forms.NumericUpDown();
            this.labelRGB2 = new System.Windows.Forms.Label();
            this.numericUpDownB1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownR1 = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.labelRGB1 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.panelReview3D = new System.Windows.Forms.Panel();
            this.labelStat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialogSelect = new System.Windows.Forms.ColorDialog();
            this.checkBoxVoxelPartOrFree = new System.Windows.Forms.CheckBox();
            this.buttonGist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR1)).BeginInit();
            this.panelReview3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarHeight
            // 
            this.trackBarHeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarHeight.LargeChange = 2;
            this.trackBarHeight.Location = new System.Drawing.Point(21, 50);
            this.trackBarHeight.Minimum = 1;
            this.trackBarHeight.Name = "trackBarHeight";
            this.trackBarHeight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarHeight.Size = new System.Drawing.Size(45, 473);
            this.trackBarHeight.TabIndex = 0;
            this.trackBarHeight.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarHeight.Value = 1;
            this.trackBarHeight.ValueChanged += new System.EventHandler(this.trackBarHeight_ValueChanged);
            // 
            // labelСurrent
            // 
            this.labelСurrent.AutoSize = true;
            this.labelСurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelСurrent.Location = new System.Drawing.Point(22, 532);
            this.labelСurrent.Name = "labelСurrent";
            this.labelСurrent.Size = new System.Drawing.Size(45, 15);
            this.labelСurrent.TabIndex = 1;
            this.labelСurrent.Text = "Z: 1/10";
            // 
            // buttonSection
            // 
            this.buttonSection.Location = new System.Drawing.Point(12, 17);
            this.buttonSection.Name = "buttonSection";
            this.buttonSection.Size = new System.Drawing.Size(63, 23);
            this.buttonSection.TabIndex = 2;
            this.buttonSection.Text = "XY";
            this.buttonSection.UseVisualStyleBackColor = true;
            this.buttonSection.Click += new System.EventHandler(this.buttonSection_Click);
            // 
            // numericUpDownB2
            // 
            this.numericUpDownB2.Location = new System.Drawing.Point(623, 20);
            this.numericUpDownB2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB2.Name = "numericUpDownB2";
            this.numericUpDownB2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownB2.TabIndex = 40;
            this.numericUpDownB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownB2.ValueChanged += new System.EventHandler(this.numericUpDownR2_ValueChanged);
            // 
            // numericUpDownG2
            // 
            this.numericUpDownG2.Location = new System.Drawing.Point(554, 20);
            this.numericUpDownG2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG2.Name = "numericUpDownG2";
            this.numericUpDownG2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownG2.TabIndex = 39;
            this.numericUpDownG2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownG2.ValueChanged += new System.EventHandler(this.numericUpDownR2_ValueChanged);
            // 
            // numericUpDownR2
            // 
            this.numericUpDownR2.Location = new System.Drawing.Point(487, 20);
            this.numericUpDownR2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR2.Name = "numericUpDownR2";
            this.numericUpDownR2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownR2.TabIndex = 38;
            this.numericUpDownR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownR2.ValueChanged += new System.EventHandler(this.numericUpDownR2_ValueChanged);
            // 
            // labelRGB2
            // 
            this.labelRGB2.AutoSize = true;
            this.labelRGB2.BackColor = System.Drawing.Color.Black;
            this.labelRGB2.ForeColor = System.Drawing.SystemColors.Control;
            this.labelRGB2.Location = new System.Drawing.Point(393, 23);
            this.labelRGB2.Name = "labelRGB2";
            this.labelRGB2.Size = new System.Drawing.Size(79, 13);
            this.labelRGB2.TabIndex = 37;
            this.labelRGB2.Text = "Цвет (Kv=max)";
            this.labelRGB2.Click += new System.EventHandler(this.labelRGB2_Click);
            // 
            // numericUpDownB1
            // 
            this.numericUpDownB1.Location = new System.Drawing.Point(315, 20);
            this.numericUpDownB1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB1.Name = "numericUpDownB1";
            this.numericUpDownB1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownB1.TabIndex = 36;
            this.numericUpDownB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownB1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB1.ValueChanged += new System.EventHandler(this.numericUpDownR1_ValueChanged);
            // 
            // numericUpDownG1
            // 
            this.numericUpDownG1.Location = new System.Drawing.Point(247, 20);
            this.numericUpDownG1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG1.Name = "numericUpDownG1";
            this.numericUpDownG1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownG1.TabIndex = 35;
            this.numericUpDownG1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownG1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG1.ValueChanged += new System.EventHandler(this.numericUpDownR1_ValueChanged);
            // 
            // numericUpDownR1
            // 
            this.numericUpDownR1.Location = new System.Drawing.Point(180, 20);
            this.numericUpDownR1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR1.Name = "numericUpDownR1";
            this.numericUpDownR1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownR1.TabIndex = 34;
            this.numericUpDownR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownR1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR1.ValueChanged += new System.EventHandler(this.numericUpDownR1_ValueChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label53.ForeColor = System.Drawing.Color.Blue;
            this.label53.Location = new System.Drawing.Point(332, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(15, 13);
            this.label53.TabIndex = 31;
            this.label53.Text = "B";
            // 
            // labelRGB1
            // 
            this.labelRGB1.AutoSize = true;
            this.labelRGB1.BackColor = System.Drawing.Color.White;
            this.labelRGB1.Location = new System.Drawing.Point(95, 23);
            this.labelRGB1.Name = "labelRGB1";
            this.labelRGB1.Size = new System.Drawing.Size(69, 13);
            this.labelRGB1.TabIndex = 33;
            this.labelRGB1.Text = "Цвет (Kv =0)";
            this.labelRGB1.DoubleClick += new System.EventHandler(this.labelRGB1_DoubleClick);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label57.ForeColor = System.Drawing.Color.Green;
            this.label57.Location = new System.Drawing.Point(263, 3);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(16, 13);
            this.label57.TabIndex = 32;
            this.label57.Text = "G";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label58.ForeColor = System.Drawing.Color.Red;
            this.label58.Location = new System.Drawing.Point(195, 3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(16, 13);
            this.label58.TabIndex = 30;
            this.label58.Text = "R";
            // 
            // panelReview3D
            // 
            this.panelReview3D.AutoScroll = true;
            this.panelReview3D.BackColor = System.Drawing.Color.OldLace;
            this.panelReview3D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReview3D.Controls.Add(this.labelStat);
            this.panelReview3D.Location = new System.Drawing.Point(92, 50);
            this.panelReview3D.Name = "panelReview3D";
            this.panelReview3D.Size = new System.Drawing.Size(820, 500);
            this.panelReview3D.TabIndex = 41;
            this.panelReview3D.Paint += new System.Windows.Forms.PaintEventHandler(this.panelReview3D_Paint);
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.Location = new System.Drawing.Point(3, 482);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(201, 13);
            this.labelStat.TabIndex = 0;
            this.labelStat.Text = "Количество элементов декомпозиции";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(639, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(569, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(501, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "R";
            // 
            // checkBoxVoxelPartOrFree
            // 
            this.checkBoxVoxelPartOrFree.AutoSize = true;
            this.checkBoxVoxelPartOrFree.Checked = true;
            this.checkBoxVoxelPartOrFree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVoxelPartOrFree.Location = new System.Drawing.Point(692, 22);
            this.checkBoxVoxelPartOrFree.Name = "checkBoxVoxelPartOrFree";
            this.checkBoxVoxelPartOrFree.Size = new System.Drawing.Size(70, 17);
            this.checkBoxVoxelPartOrFree.TabIndex = 45;
            this.checkBoxVoxelPartOrFree.Text = "Изделие";
            this.checkBoxVoxelPartOrFree.UseVisualStyleBackColor = true;
            this.checkBoxVoxelPartOrFree.CheckStateChanged += new System.EventHandler(this.checkBoxVoxelPartOrFree_CheckStateChanged);
            // 
            // buttonGist
            // 
            this.buttonGist.Location = new System.Drawing.Point(829, 17);
            this.buttonGist.Name = "buttonGist";
            this.buttonGist.Size = new System.Drawing.Size(83, 23);
            this.buttonGist.TabIndex = 46;
            this.buttonGist.Text = "Гистограмма";
            this.buttonGist.UseVisualStyleBackColor = true;
            this.buttonGist.Click += new System.EventHandler(this.buttonGist_Click);
            // 
            // FormDitribution3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 561);
            this.Controls.Add(this.buttonGist);
            this.Controls.Add(this.checkBoxVoxelPartOrFree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelReview3D);
            this.Controls.Add(this.numericUpDownB2);
            this.Controls.Add(this.numericUpDownG2);
            this.Controls.Add(this.numericUpDownR2);
            this.Controls.Add(this.labelRGB2);
            this.Controls.Add(this.numericUpDownB1);
            this.Controls.Add(this.numericUpDownG1);
            this.Controls.Add(this.numericUpDownR1);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.labelRGB1);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.buttonSection);
            this.Controls.Add(this.labelСurrent);
            this.Controls.Add(this.trackBarHeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDitribution3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ распределения вокселей при объемной декомпозиции";
            this.Load += new System.EventHandler(this.FormDitribution3D_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR1)).EndInit();
            this.panelReview3D.ResumeLayout(false);
            this.panelReview3D.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSection;
        public System.Windows.Forms.TrackBar trackBarHeight;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Label labelСurrent;
        private System.Windows.Forms.NumericUpDown numericUpDownB2;
        private System.Windows.Forms.NumericUpDown numericUpDownG2;
        private System.Windows.Forms.NumericUpDown numericUpDownR2;
        private System.Windows.Forms.Label labelRGB2;
        private System.Windows.Forms.NumericUpDown numericUpDownB1;
        private System.Windows.Forms.NumericUpDown numericUpDownG1;
        private System.Windows.Forms.NumericUpDown numericUpDownR1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label labelRGB1;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Panel panelReview3D;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialogSelect;
        private System.Windows.Forms.CheckBox checkBoxVoxelPartOrFree;
        private System.Windows.Forms.Button buttonGist;
        private System.Windows.Forms.Label labelStat;
    }
}