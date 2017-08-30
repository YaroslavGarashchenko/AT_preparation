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
    public partial class FormResults : Form
    {
        public FormResults()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Временно...
        /// </summary>
        List<base_stl> ListStl = new List<base_stl>();

        private void toolStripButton1_Click(object sender, EventArgs e)
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
            richTextBoxResultAnalysis.Text += "Анализ выполнен: " + DateTime.Now.ToShortDateString() + "; " + DateTime.Now.ToShortTimeString() + "\n";
            //richTextBoxResultAnalysis.Text += "Модель изделия: " + toolStripTextBoxFileName.Text + "\n";
            richTextBoxResultAnalysis.Text += "Площадь триангуляционной модели: " + Sstl.ToString("N3") + " mm2 \n";
            richTextBoxResultAnalysis.Text += "Объем триангуляционной модели: " + Vstl.ToString("N3") + " mm3 \n";
            richTextBoxResultAnalysis.Text += "Координаты центра тяжести триангуляционной модели: \n" +
                                              "Xc = " + (VXc / Vstl).ToString("N3") + " mm \n" +
                                              "Yc = " + (VYc / Vstl).ToString("N3") + " mm \n" +
                                              "Zc = " + (VZc / Vstl).ToString("N3") + " mm \n\n";
        }
    }
}
