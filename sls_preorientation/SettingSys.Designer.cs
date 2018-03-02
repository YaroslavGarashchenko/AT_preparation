namespace PreAddTech
{
    partial class SettingSys
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
            this.dataGridViewSYS = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDefolt = new System.Windows.Forms.Button();
            this.openFileDialogSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumPar = new System.Windows.Forms.TextBox();
            this.Par = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamePar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSYS)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSYS
            // 
            this.dataGridViewSYS.AllowUserToAddRows = false;
            this.dataGridViewSYS.AllowUserToDeleteRows = false;
            this.dataGridViewSYS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSYS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSYS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Par,
            this.NamePar,
            this.Value,
            this.Type});
            this.dataGridViewSYS.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewSYS.Name = "dataGridViewSYS";
            this.dataGridViewSYS.Size = new System.Drawing.Size(900, 511);
            this.dataGridViewSYS.TabIndex = 0;
            this.dataGridViewSYS.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSYS_CellContentDoubleClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(601, 530);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(311, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить настройки";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDefolt
            // 
            this.buttonDefolt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDefolt.Location = new System.Drawing.Point(245, 530);
            this.buttonDefolt.Name = "buttonDefolt";
            this.buttonDefolt.Size = new System.Drawing.Size(311, 23);
            this.buttonDefolt.TabIndex = 2;
            this.buttonDefolt.Text = "Значения по умолчанию (default)";
            this.buttonDefolt.UseVisualStyleBackColor = true;
            this.buttonDefolt.Click += new System.EventHandler(this.ButtonDefolt_Click);
            // 
            // openFileDialogSelectFile
            // 
            this.openFileDialogSelectFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество параметров";
            // 
            // textBoxNumPar
            // 
            this.textBoxNumPar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxNumPar.Location = new System.Drawing.Point(151, 532);
            this.textBoxNumPar.MaxLength = 3;
            this.textBoxNumPar.Name = "textBoxNumPar";
            this.textBoxNumPar.ReadOnly = true;
            this.textBoxNumPar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxNumPar.Size = new System.Drawing.Size(56, 20);
            this.textBoxNumPar.TabIndex = 4;
            // 
            // Par
            // 
            this.Par.HeaderText = "Описание параметра";
            this.Par.MaxInputLength = 100;
            this.Par.Name = "Par";
            this.Par.ReadOnly = true;
            this.Par.Width = 350;
            // 
            // NamePar
            // 
            this.NamePar.HeaderText = "Переменная";
            this.NamePar.MaxInputLength = 100;
            this.NamePar.Name = "NamePar";
            this.NamePar.ReadOnly = true;
            this.NamePar.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Значение";
            this.Value.MaxInputLength = 200;
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value.ToolTipText = "Вызов диалогового окна для выбора файла (DoubleClick)";
            this.Value.Width = 250;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип переменной";
            this.Type.MaxInputLength = 50;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 150;
            // 
            // SettingSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 561);
            this.Controls.Add(this.textBoxNumPar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDefolt);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewSYS);
            this.Name = "SettingSys";
            this.Text = "Настройки системы";
            this.Load += new System.EventHandler(this.SettingSys_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSYS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSYS;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDefolt;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumPar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Par;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamePar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}