namespace PreAddTech
{
    partial class PackingSettings
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
            this.comboBoxEquipment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPackingSettings = new System.Windows.Forms.DataGridView();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plantParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackingSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plantParametersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEquipment
            // 
            this.comboBoxEquipment.FormattingEnabled = true;
            this.comboBoxEquipment.Location = new System.Drawing.Point(255, 11);
            this.comboBoxEquipment.Name = "comboBoxEquipment";
            this.comboBoxEquipment.Size = new System.Drawing.Size(191, 21);
            this.comboBoxEquipment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Установка";
            // 
            // dataGridViewPackingSettings
            // 
            this.dataGridViewPackingSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackingSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Volum});
            this.dataGridViewPackingSettings.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewPackingSettings.Name = "dataGridViewPackingSettings";
            this.dataGridViewPackingSettings.Size = new System.Drawing.Size(434, 170);
            this.dataGridViewPackingSettings.TabIndex = 2;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(340, 228);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(106, 23);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "Сохранение";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            // 
            // Parameter
            // 
            this.Parameter.HeaderText = "Характеристика";
            this.Parameter.MaxInputLength = 250;
            this.Parameter.MinimumWidth = 150;
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Width = 280;
            // 
            // Volum
            // 
            this.Volum.HeaderText = "Величина";
            this.Volum.MaxInputLength = 20;
            this.Volum.MinimumWidth = 50;
            this.Volum.Name = "Volum";
            this.Volum.Width = 110;
            // 
            // plantParametersBindingSource
            // 
            this.plantParametersBindingSource.DataSource = typeof(PreAddTech.PlantParameters);
            // 
            // PackingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 261);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.dataGridViewPackingSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEquipment);
            this.Name = "PackingSettings";
            this.Text = "Характеристики установки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackingSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plantParametersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEquipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewPackingSettings;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volum;
        public System.Windows.Forms.BindingSource plantParametersBindingSource;
    }
}