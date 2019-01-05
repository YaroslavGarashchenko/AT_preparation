using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    /// <summary>
    /// Экранная форма вывода гистограммы 
    /// </summary>
    public partial class FormGist : Form
    {
        public FormGist()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ряд данных - Плотность распределения
        /// </summary>
        public Series seriesDensity;

        private Stat_analysis analysis = new Stat_analysis();

        /// <summary>
        /// Переключатель "Интегральная функция распределения/Плотность распределения"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSwitch_Click(object sender, EventArgs e)
        {
            if (buttonSwitch.Text == "Интегральная функция распределения")
            {
                buttonSwitch.Text = "Плотность распределения";
                chartIntegral.Visible = true;
                chartGistogram.Visible = false;
            }
            else
            {
                buttonSwitch.Text = "Интегральная функция распределения";
                chartIntegral.Visible = false;
                chartGistogram.Visible = true;
            }
        }
        /// <summary>
        /// Настройки графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonProperty_Click(object sender, EventArgs e)
        {
            if (propertyGridUniverse.Visible == false)
            {
                propertyGridUniverse.Visible = true;
                richTextBoxResultVerify.Visible = false;
            }
            else
            {
                propertyGridUniverse.Visible = false;
            }
            if (chartGistogram.Visible == true)
            {
                propertyGridUniverse.SelectedObject = chartGistogram;
            }
            if (chartIntegral.Visible == true)
            {
                propertyGridUniverse.SelectedObject = chartIntegral;
            }
        }
        /// <summary>
        /// Запись в БД сравнительного анализа данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComparison_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Данные гистограммы
        /// </summary>
        private float[] data;

        /// <summary>
        /// Проверка гипотез
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest_Click(object sender, EventArgs e)
        {
            SeriesToList(seriesDensity);
            float[] statistics = analysis.Stat(data);
            const int numCriterion = 10; //[0] Шермана, [1] Кимбала, [2] Андерсона-Дарлинга, 
            //[3] Крамера-Мизеса-Смирнова, [4-7] Ньюмана-Бартона, [8] Дудевича, [9] Пирсона
            float[] valueCriterion = new float[numCriterion];
            StatisticalCriterion[] criterion = new StatisticalCriterion[numCriterion] 
                                                 { StatisticalCriterion.Sherman,
                                                   StatisticalCriterion.Kimball,
                                                   StatisticalCriterion.AndersonDarling,
                                                   StatisticalCriterion.KramerMisesSmirnov,
                                                   StatisticalCriterion.NeymanBarton1polinom,
                                                   StatisticalCriterion.NeymanBarton2polinom,
                                                   StatisticalCriterion.NeymanBarton3polinom,
                                                   StatisticalCriterion.NeymanBarton4polinom,
                                                   StatisticalCriterion.DudevichVanDerMuelen,
                                                   StatisticalCriterion.PearsonsChiSquare
                                                 };
            float A = float.Parse(comboBoxAlfa.Text);
            for (int i = 0; i < numCriterion; i++)
            {
                valueCriterion[i] = analysis.VerifyUniformLaw(data, criterion[i])[i];
            }
            richTextBoxResultVerify.Text += "Проверка статистических гипотез: \n";
            int Volume = seriesDensity.Points.Count();
            //
            richTextBoxResultVerify.Text += "Критерий Шермана: " + valueCriterion[0] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionSherman(valueCriterion[0], Volume, A), 
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Кимбала: " + valueCriterion[1] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionKimbela(valueCriterion[1], Volume, A), 
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Андерсона-Дарлинга: " + valueCriterion[2] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionAndersonDarling(valueCriterion[2], Volume, A), 
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Крамера-Мизеса-Смирнова: " + valueCriterion[3] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionKramerMisesSmirnov(valueCriterion[3], Volume, A), 
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Ньюмана-Бартона (1-4 полиномы): " + valueCriterion[4] + "; " +
                                            valueCriterion[5] + "; " + valueCriterion[6] + "; " + 
                                            valueCriterion[7] + "\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionNeymanBarton(new float[4] 
                          { valueCriterion[4], valueCriterion[5], valueCriterion[6], valueCriterion[7] }, Volume, A),
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Дудевича: " + valueCriterion[8] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionDudevichVanDerMuelen(valueCriterion[8], Volume, A),
                                 richTextBoxResultVerify);
            richTextBoxResultVerify.Text += "Критерий Пирсона: " + valueCriterion[9] + " ,\n";
            VerifyWriteToTextBox(analysis.VerifyCriterionPirson(valueCriterion[9], analysis.СhoiceNumberIntervals(Volume), A),
                                 richTextBoxResultVerify);

            richTextBoxResultVerify.Visible = true;
            propertyGridUniverse.Visible = false;
        }
        /// <summary>
        /// Запись в RichTextBox данных по результатам проверки закона распределения
        /// </summary>
        /// <param name="resultValidity">Результаты проверки</param>
        /// <param name="textBox">RichTextBox</param>
        private void VerifyWriteToTextBox(Validity resultValidity, RichTextBox textBox)
        {
            if (resultValidity == Validity.yes)
            { richTextBoxResultVerify.Text += "Данные выборки имеют равномерный закон!\n"; }
            else if (resultValidity == Validity.no)
            { richTextBoxResultVerify.Text += "Есть основания для отвергания гипотезы!\n"; }
            else
            { richTextBoxResultVerify.Text += "Не определены данные для расчета критерия!\n"; }
        }

        /// <summary>
        /// Перевод данных гистограммы в массив float[]
        /// </summary>
        /// <param name="set">Данные гистограммы</param>
        private void SeriesToList(Series set)
        {
            data = new float[set.Points.Count()];
            DataPoint[] tempPoint = set.Points.ToArray<DataPoint>();
            for (int i = 0; i < set.Points.Count(); i++)
            {
                data[i] = (float)tempPoint[i].YValues.First();
            }
        }
        /// <summary>
        /// Разворачивание/сворачивание текстового поля с характеристиками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxResultVerify_DoubleClick(object sender, EventArgs e)
        {
            if(((RichTextBox)sender).Dock == DockStyle.Fill)
            {
                ((RichTextBox)sender).Dock = DockStyle.None;
            }
            else
            {
                ((RichTextBox)sender).Dock = DockStyle.Fill;
            }
        }
    }
}
