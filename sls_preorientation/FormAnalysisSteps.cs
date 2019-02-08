using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    public partial class FormAnalysisSteps : Form
    {
        public FormAnalysisSteps()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Массив исследуемого признака
        /// </summary>
        public float[] researchMassive;
        /// <summary>
        /// Массив координат Z слоев
        /// </summary>
        public float[] researchMassiveZ;
        /// <summary>
        /// Стат характеристики: 0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
        /// 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
        /// </summary>
        public float[] resultStatParLayer;
        /// <summary>
        /// Ряд данных - Плотность распределения
        /// </summary>
        public Series seriesDensity;
        /// <summary>
        /// Ряд данных - Интегральная функция
        /// </summary>
        public Series seriesIntegralFunction;
        /// <summary>
        /// Ряд данных - Перечисление исследуемого признака
        /// </summary>
        public Series seriesData;
        /// <summary>
        /// Ряд данных - Функция зависимости исследуемого признака от координаты по оси Z
        /// </summary>
        public Series seriesFunctionZ;
        /// <summary>
        /// Заголовок формы
        /// </summary>
        public string titleForm;

        /// <summary>
        /// Показать настройки графика / исходных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonProperty_Click(object sender, EventArgs e)
        {
            switch (buttonProperty.Text)
            {
                case "Настройки":
                    buttonProperty.Text = "Исх.данные";
                    propertyGridUniverse.Visible = true;
                    richTextBoxData.Visible = false;
                    richTextBoxQuartile.Visible = false;
                    labelShow.Text = "Настройки графика:";
                    break;
                case "Исх.данные":
                    buttonProperty.Text = "График";
                    propertyGridUniverse.Visible = false;
                    richTextBoxData.Visible = true;
                    richTextBoxQuartile.Visible = true;
                    labelShow.Text = "Исходные данные для графика:";
                    break;
                case "График":
                default:
                    buttonProperty.Text = "Настройки";
                    propertyGridUniverse.Visible = false;
                    richTextBoxData.Visible = false;
                    richTextBoxQuartile.Visible = false;
                    labelShow.Text = "";
                    break;
            }
        }
        /// <summary>
        /// Переключение графиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            switch (buttonCalculate.Text)
            {
                case "Плотность распределения":
                    this.Text = titleForm + "Интегральная функция распределения";
                    buttonCalculate.Text = "Интегральная функция распределения";
                    chartDependent.Series.Clear();
                    try
                    {
                        chartDependent.ChartAreas[0].AxisX.Minimum =
                                    (double)(numericUpDownMin.Value = (decimal)resultStatParLayer[0]);
                        chartDependent.ChartAreas[0].AxisX.Maximum =
                                   (double)(numericUpDownMax.Value = (decimal)resultStatParLayer[1]);
                    }
                    catch (System.Exception)
                    { }
                    chartDependent.ChartAreas[0].AxisY.Minimum = 0;
                    chartDependent.ChartAreas[0].AxisY.Maximum = 1;
                    chartDependent.Series.Add(seriesIntegralFunction);
                    chartDependent.Series[0].ChartType = SeriesChartType.Column;
                    try
                    { numericUpDownStepIntervals.Value = (decimal)resultStatParLayer[2] / numericUpDownNumIntervals.Value; }
                    catch (System.Exception)
                    { }
                    break;
                case "Интегральная функция распределения":
                    this.Text = titleForm + "Список исследуемого признака";
                    buttonCalculate.Text = "Список исследуемого признака";
                    chartDependent.Series.Clear();
                    chartDependent.ChartAreas[0].AxisX.Minimum =
                               (double)(numericUpDownMin.Value = 0);
                    chartDependent.ChartAreas[0].AxisX.Maximum =
                     (double)(numericUpDownMax.Value = (decimal)researchMassive.Length);
                    chartDependent.ChartAreas[0].AxisY.Minimum = 0;
                    chartDependent.ChartAreas[0].AxisY.Maximum = researchMassive.Max();
                    chartDependent.Series.Add(seriesData);
                    chartDependent.Series[0].ChartType = SeriesChartType.Point;
                    break;
                case "Список исследуемого признака":
                    this.Text = titleForm + "Зависимость исследуемого признака от координаты Z";
                    buttonCalculate.Text = "Зависимость исследуемого признака от координаты Z";
                    chartDependent.Series.Clear();
                    chartDependent.ChartAreas[0].AxisX.Minimum =
                               (double)(numericUpDownMin.Value = (decimal)researchMassiveZ.Min());
                    chartDependent.ChartAreas[0].AxisX.Maximum =
                        (double)(numericUpDownMax.Value = (decimal)researchMassiveZ.Max());
                    chartDependent.ChartAreas[0].AxisY.Minimum = researchMassive.Min();
                    chartDependent.ChartAreas[0].AxisY.Maximum = researchMassive.Max();
                    chartDependent.Series.Add(seriesFunctionZ);
                    chartDependent.Series[0].ChartType = SeriesChartType.Point;
                    break;
                case "Зависимость исследуемого признака от координаты Z":
                default:
                    this.Text = titleForm + "Плотность распределения";
                    buttonCalculate.Text = "Плотность распределения";
                    chartDependent.Series.Clear();
                    try
                    {
                        chartDependent.ChartAreas[0].AxisX.Minimum =
                               (double)(numericUpDownMin.Value = (decimal)resultStatParLayer[0]);
                        chartDependent.ChartAreas[0].AxisX.Maximum =
                                   (double)(numericUpDownMax.Value = (decimal)resultStatParLayer[1]);
                    }
                    catch (System.Exception)
                    { }
                    chartDependent.ChartAreas[0].AxisY.Minimum = 0;
                    chartDependent.ChartAreas[0].AxisY.Maximum = 1;
                    chartDependent.Series.Add(seriesDensity);
                    chartDependent.Series[0].ChartType = SeriesChartType.Column;
                    try
                    { numericUpDownStepIntervals.Value = (decimal)resultStatParLayer[2] / numericUpDownNumIntervals.Value; }
                    catch (System.Exception)
                    { }
                    break;
            }
        }
        /// <summary>
        /// Первоначальная загрузка формы
        /// </summary>
        private void FormAnalysisSteps_Load(object sender, EventArgs e)
        {
            this.Text = titleForm + "Плотность распределения";
            try
            {
                chartDependent.ChartAreas[0].AxisX.Minimum =
                       (double)(numericUpDownMin.Value = (decimal)resultStatParLayer[0]);
                chartDependent.ChartAreas[0].AxisX.Maximum =
                       (double)(numericUpDownMax.Value = (decimal)resultStatParLayer[1]);
                numericUpDownStepIntervals.Value = (decimal)resultStatParLayer[2] / numericUpDownNumIntervals.Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Невозможно настроить автоматически интервал значений по оси X");
            }
        }
        /// <summary>
        /// Изменение минимального значения графика
        /// </summary>
        private void NumericUpDownMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMin.Value < (numericUpDownMax.Value - 1 / 10) &&
                resultStatParLayer[1] >= (float)numericUpDownMin.Value)
            {
                chartDependent.ChartAreas[0].AxisX.Minimum = (double)numericUpDownMin.Value;
                chartDependent.ChartAreas[0].AxisX.Maximum = (double)numericUpDownMax.Value;
            }
        }
        /// <summary>
        /// Изменение максимального значения графика
        /// </summary>
        private void NumericUpDownMax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownMin.Value < (numericUpDownMax.Value - 1 / 10) &&
                resultStatParLayer[0] <= (float)numericUpDownMax.Value)
            {
                chartDependent.ChartAreas[0].AxisX.Minimum = (double)numericUpDownMin.Value;
                chartDependent.ChartAreas[0].AxisX.Maximum = (double)numericUpDownMax.Value;
            }
        }
        /// <summary>
        /// Изменение количества интервалов и пересчет гистограмм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownNumIntervals_ValueChanged(object sender, EventArgs e)
        {
            Stat_analysis statisticaPar = new Stat_analysis();
            object[] resultStat = statisticaPar.ComplexAnalysis(researchMassive, (int)numericUpDownNumIntervals.Value);
            //0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм.,...
            resultStatParLayer = (float[])resultStat[0];
            seriesDensity = (Series)resultStat[1];
            seriesIntegralFunction = (Series)resultStat[2];
            numericUpDownStepIntervals.Value = (numericUpDownMax.Value - numericUpDownMin.Value) / numericUpDownNumIntervals.Value;
            //numericUpDownStepIntervals.Value = (decimal)resultStatParLayer[2] / numericUpDownNumIntervals.Value;
        }
        //Сохранение данных графика в буфер обмена
        private void ChartDependent_DoubleClick(object sender, EventArgs e)
        {
            if (((Chart)sender).Series.Count == 0)
                return;

            Clipboard.Clear();
            string clipboardTable = "";
            for (int i = 0; i < ((Chart)sender).Series[0].Points.Count; i++)
            {
                clipboardTable += ((Chart)sender).Series[0].Points[i].XValue.ToString() + "\t";
                for (int j = 0; j < ((Chart)sender).Series[0].Points[i].YValues.Length; j++)
                {
                    clipboardTable += ((Chart)sender).Series[0].Points[i].YValues[j].ToString() + "\t";
                }
                clipboardTable += "\n";
            }
            Clipboard.SetText(clipboardTable);
            MessageBox.Show("Данные графика помещены в буфер обмена. ",
                             "Отчет о выполнении действия ...");
        }

        /// <summary>
        /// Установка флажка для сравнительного анализа данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFirstData_CheckedChanged(object sender, EventArgs e)
        {

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
        /// Проверка гипотез на равномерность распределения исследуемого признака
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest_Click(object sender, EventArgs e)
        {
            FormResults formAnalResults = new FormResults();
            formAnalResults.Activate();
            formAnalResults.toolStripComboBoxResult.Enabled = false;
            formAnalResults.toolStripButtonSelect.Enabled = false;
            formAnalResults.richTextBoxResultAnalysis.Text = GenerateReportTestDistribution();
            formAnalResults.Show();
        }
        /// <summary>
        /// Генерирование отчета по проверке гипотезы о законе распределения исследуемого признака
        /// </summary>
        /// <returns></returns>
        private string GenerateReportTestDistribution()
        {
            string result;
            if (resultStatParLayer.Length <= 0)
            {
                result = "Нет результатов статистического анализа распределения исследуемого признака! \n";
            }
            else
            {
                result = "Статистические характеристики распределения исследуемого признака:" + "\n";
                result += "Минимальная величина: " + resultStatParLayer[0] + " ;\n";
                result += "Максимальная величина: " + resultStatParLayer[1] + " ;\n";
                result += "Интервал величин: " + resultStatParLayer[2] + " ;\n";
                result += "Дисперсия: " + resultStatParLayer[3] + " ;\n";
                result += "Среднеквадратическое отклонение: " + resultStatParLayer[4] + " ;\n";
                result += "Среднеарифметическое значение: " + resultStatParLayer[5] + " ;\n";
                result += "Коэффициент асимметрии: " + resultStatParLayer[6] + " ;\n";
                result += "Коэффициент эксцесса: " + resultStatParLayer[7] + " ;\n";
                result += "Коэффициент вариации: " + resultStatParLayer[8] + " ;\n";
                result += "Меана: " + resultStatParLayer[9] + " ;\n";
                result += "Мода: " + resultStatParLayer[10] + " ;\n";
                result += "Медиана: " + resultStatParLayer[11] + " ;\n";
                result += "Объем выборки: " + resultStatParLayer[12] + " ;\n\n";
            }
            //


            return result;
        }
    }
}
