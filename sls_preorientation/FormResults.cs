using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreAddTech
{
    /// <summary>
    /// Форма просмотра результатов исследования 
    /// </summary>
    public partial class FormResults : Form
    {
        public FormResults()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Временно...?
        /// </summary>
        public List<Base_stl> ListStl;
        /// <summary>
        /// Сохранение результатов расчета
        /// </summary>
        public string[] revision = new string[4];

        /// <summary>
        /// Результаты фрактального анализа
        /// </summary>
        public Base_fract_anal fractAnal;

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxResult.SelectedIndex == 0)
            {
                if (revision[0] == "")
                {
                    //площадь и объем триангуляционной модели
                    double Sstl = 0;
                    float Vstl = 0;
                    //Сумма произведений объема и координат центра тяжести треугольника
                    float VXc = 0;
                    float VYc = 0;
                    float VZc = 0;
                    foreach (var tempstl in ListStl)
                    {
                        Sstl += tempstl.CalcSTr()[3];
                        var temp = tempstl.CenterOfGravity();
                        VXc += temp[0] * temp[3];
                        VYc += temp[1] * temp[3];
                        VZc += temp[2] * temp[3];
                        Vstl += temp[3];
                    }
                    richTextBoxResultAnalysis.Text = "Анализ выполнен: " + DateTime.Now.ToShortDateString() + "; " + DateTime.Now.ToShortTimeString() + "\n";
                    //richTextBoxResultAnalysis.Text += "Модель изделия: " + toolStripTextBoxFileName.Text + "\n";
                    richTextBoxResultAnalysis.Text += "Площадь триангуляционной модели: " + Sstl.ToString("N3") + " mm2 \n";
                    richTextBoxResultAnalysis.Text += "Объем триангуляционной модели: " + Vstl.ToString("N3") + " mm3 \n";
                    richTextBoxResultAnalysis.Text += "Координаты центра тяжести триангуляционной модели: \n" +
                                                      "Xc = " + (VXc / Vstl).ToString("N3") + " mm \n" +
                                                      "Yc = " + (VYc / Vstl).ToString("N3") + " mm \n" +
                                                      "Zc = " + (VZc / Vstl).ToString("N3") + " mm \n\n";

                    revision[0] = richTextBoxResultAnalysis.Text;
                }
                else
                { richTextBoxResultAnalysis.Text = revision[0]; }
            }
            else if (toolStripComboBoxResult.SelectedIndex == 1)
            {
                richTextBoxResultAnalysis.Text = revision[1];
            }
            else if (toolStripComboBoxResult.SelectedIndex == 2)
            {
                richTextBoxResultAnalysis.Text = revision[2];
            }
            else if (toolStripComboBoxResult.SelectedIndex == 3)
            {
                if (revision[2] != "" && revision[3] != null)
                { richTextBoxResultAnalysis.Text = revision[3]; }
                else
                { if (fractAnal != null) revision[3] = richTextBoxResultAnalysis.Text = fractAnal.AllToString(); }
            }
        }
    }
}
