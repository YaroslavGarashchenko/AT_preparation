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
            resources.ApplyResources(this.trackBarHeight, "trackBarHeight");
            this.trackBarHeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarHeight.LargeChange = 2;
            this.trackBarHeight.Minimum = 1;
            this.trackBarHeight.Name = "trackBarHeight";
            this.trackBarHeight.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarHeight.Value = 1;
            this.trackBarHeight.ValueChanged += new System.EventHandler(this.TrackBarHeight_ValueChanged);
            // 
            // labelСurrent
            // 
            resources.ApplyResources(this.labelСurrent, "labelСurrent");
            this.labelСurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelСurrent.Name = "labelСurrent";
            // 
            // buttonSection
            // 
            resources.ApplyResources(this.buttonSection, "buttonSection");
            this.buttonSection.Name = "buttonSection";
            this.buttonSection.UseVisualStyleBackColor = true;
            this.buttonSection.Click += new System.EventHandler(this.buttonSection_Click);
            // 
            // numericUpDownB2
            // 
            resources.ApplyResources(this.numericUpDownB2, "numericUpDownB2");
            this.numericUpDownB2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB2.Name = "numericUpDownB2";
            this.numericUpDownB2.ValueChanged += new System.EventHandler(this.NumericUpDownR2_ValueChanged);
            // 
            // numericUpDownG2
            // 
            resources.ApplyResources(this.numericUpDownG2, "numericUpDownG2");
            this.numericUpDownG2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG2.Name = "numericUpDownG2";
            this.numericUpDownG2.ValueChanged += new System.EventHandler(this.NumericUpDownR2_ValueChanged);
            // 
            // numericUpDownR2
            // 
            resources.ApplyResources(this.numericUpDownR2, "numericUpDownR2");
            this.numericUpDownR2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR2.Name = "numericUpDownR2";
            this.numericUpDownR2.ValueChanged += new System.EventHandler(this.NumericUpDownR2_ValueChanged);
            // 
            // labelRGB2
            // 
            resources.ApplyResources(this.labelRGB2, "labelRGB2");
            this.labelRGB2.BackColor = System.Drawing.Color.Black;
            this.labelRGB2.ForeColor = System.Drawing.SystemColors.Control;
            this.labelRGB2.Name = "labelRGB2";
            this.labelRGB2.Click += new System.EventHandler(this.LabelRGB2_Click);
            // 
            // numericUpDownB1
            // 
            resources.ApplyResources(this.numericUpDownB1, "numericUpDownB1");
            this.numericUpDownB1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB1.Name = "numericUpDownB1";
            this.numericUpDownB1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB1.ValueChanged += new System.EventHandler(this.NumericUpDownR1_ValueChanged);
            // 
            // numericUpDownG1
            // 
            resources.ApplyResources(this.numericUpDownG1, "numericUpDownG1");
            this.numericUpDownG1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG1.Name = "numericUpDownG1";
            this.numericUpDownG1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG1.ValueChanged += new System.EventHandler(this.NumericUpDownR1_ValueChanged);
            // 
            // numericUpDownR1
            // 
            resources.ApplyResources(this.numericUpDownR1, "numericUpDownR1");
            this.numericUpDownR1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR1.Name = "numericUpDownR1";
            this.numericUpDownR1.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR1.ValueChanged += new System.EventHandler(this.NumericUpDownR1_ValueChanged);
            // 
            // label53
            // 
            resources.ApplyResources(this.label53, "label53");
            this.label53.ForeColor = System.Drawing.Color.Blue;
            this.label53.Name = "label53";
            // 
            // labelRGB1
            // 
            resources.ApplyResources(this.labelRGB1, "labelRGB1");
            this.labelRGB1.BackColor = System.Drawing.Color.White;
            this.labelRGB1.Name = "labelRGB1";
            this.labelRGB1.DoubleClick += new System.EventHandler(this.LabelRGB1_DoubleClick);
            // 
            // label57
            // 
            resources.ApplyResources(this.label57, "label57");
            this.label57.ForeColor = System.Drawing.Color.Green;
            this.label57.Name = "label57";
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.ForeColor = System.Drawing.Color.Red;
            this.label58.Name = "label58";
            // 
            // panelReview3D
            // 
            resources.ApplyResources(this.panelReview3D, "panelReview3D");
            this.panelReview3D.BackColor = System.Drawing.Color.OldLace;
            this.panelReview3D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReview3D.Controls.Add(this.labelStat);
            this.panelReview3D.Name = "panelReview3D";
            this.panelReview3D.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelReview3D_Paint);
            // 
            // labelStat
            // 
            resources.ApplyResources(this.labelStat, "labelStat");
            this.labelStat.Name = "labelStat";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // checkBoxVoxelPartOrFree
            // 
            resources.ApplyResources(this.checkBoxVoxelPartOrFree, "checkBoxVoxelPartOrFree");
            this.checkBoxVoxelPartOrFree.Checked = true;
            this.checkBoxVoxelPartOrFree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVoxelPartOrFree.Name = "checkBoxVoxelPartOrFree";
            this.checkBoxVoxelPartOrFree.UseVisualStyleBackColor = true;
            this.checkBoxVoxelPartOrFree.CheckStateChanged += new System.EventHandler(this.checkBoxVoxelPartOrFree_CheckStateChanged);
            // 
            // buttonGist
            // 
            resources.ApplyResources(this.buttonGist, "buttonGist");
            this.buttonGist.Name = "buttonGist";
            this.buttonGist.UseVisualStyleBackColor = true;
            this.buttonGist.Click += new System.EventHandler(this.buttonGist_Click);
            // 
            // FormDitribution3D
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDitribution3D";
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