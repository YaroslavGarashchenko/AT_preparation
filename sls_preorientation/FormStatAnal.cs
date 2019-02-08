using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace PreAddTech
{
    /// <summary>
    /// Класс формы статистического и сравнительного анализа данных исследований
    /// </summary>
    public partial class FormStatAnal : Form
    {
        public FormStatAnal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Основная форма приложения
        /// </summary>
        ATPreparation frmMain = (ATPreparation)Application.OpenForms["ATPreparation"];

        /// <summary>
        /// Процедуры рассчета/анализа параметров
        /// </summary>
        MyProcedures proc = new MyProcedures();
        Stat_analysis stat = new Stat_analysis();

        /// <summary>
        /// Загрузка экранной формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStatAnal_Load(object sender, EventArgs e)
        {
            if (frmMain.varDatasMassive.Count() != 0)
            foreach (VarDatas data in frmMain.varDatasMassive)
            {
                dataGridViewGroupAnalise.Rows.Add(
                    data.SelectVar == true ? 1 : 0,
                    data.Number,
                    data.Group,
                    data.Name,
                    data.Path,
                    data.SelectAnalyse,
                    "Показать",
                    "Показать",
                    "Показать",
                    data.DateTimeCreation.ToLongDateString() + "; " + data.DateTimeCreation.ToLongTimeString(),
                    "Показать"
                    );
            }
        }
        /// <summary>
        /// Выполнение процедуры анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelStatAnal.Text = "Анализ...";
            toolStripStatusLabelStatAnal.ForeColor = Color.Red;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Коррекция по возможному изменению меток и удалению данных
            //Создание массива номеров данных для которых выполняется анализ
            int[] numberDataMassive = new int[dataGridViewGroupAnalise.Rows.Count];
            for (int i = 0; i < dataGridViewGroupAnalise.Rows.Count; i++)
            {
                if (dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["M0"].Index, i].Value.ToString().Trim() == "1")
                {
                    numberDataMassive[i] = int.Parse(dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["Number"].Index, i].Value.ToString());
                }
                else
                {
                    numberDataMassive[i] = 0;
                }
            }
            int numVarData = numberDataMassive.Where(num => num != 0).Count(); // Количество вариантов данных
            if (toolStripComboBoxVariantAnalize.SelectedIndex == 0)
            {
                if (numVarData <= 1)
                return;
                int numCalculate = Stat_analysis.NumVariantsComparison(numVarData); // Количество сравнений данных
            
                for (int i = 0; i < numVarData - 1; i++)
                {
                    proc.ProgressBarRefresh(toolStripProgressBarStatAnal, i, numVarData - 2);
                    int firstNum = numberDataMassive.Where(v => v != 0).ToList<int>()[i];
                    var firstData = frmMain.varDatasMassive.Where(var => var.Number == firstNum).First();
                    for (int j = i + 1; j < numberDataMassive.Where(v => v != 0).Count(); j++)
                    {
                        int secondNum = numberDataMassive.Where(v => v != 0).ToList<int>()[j];
                        var secondData = frmMain.varDatasMassive.Where(var => var.Number == secondNum).First();
                        // Массив значений критериев { [0] Kruskal–Wallis, [1] Mann–Whitney, [2] Манна — Уитни, 
                        // [3] Вальда — Вольфовица, [4] Колмогорова — Смирнова, [5] Пирсона
                        float[] criteria = Stat_analysis.ComparisonStatData(firstData.ResearchMassive, secondData.ResearchMassive);
                        //Проверка справедливости нулевой гипотезы по критерию Вальда — Вольфовица
                        Validity validityR005 = Stat_analysis.VerifyCriterionR(criteria[3], firstData.ResearchMassive.Length, 
                                                                                        secondData.ResearchMassive.Length, 0.05f);
                        Validity validityR010 = Stat_analysis.VerifyCriterionR(criteria[3], firstData.ResearchMassive.Length,
                                                                                        secondData.ResearchMassive.Length, 0.10f);
                        Validity validityU001 = Stat_analysis.VerifyCriterionU(criteria[2], firstData.ResearchMassive.Length,
                                                                                        secondData.ResearchMassive.Length, 0.01f);
                        Validity validityU005 = Stat_analysis.VerifyCriterionU(criteria[2], firstData.ResearchMassive.Length,
                                                                                        secondData.ResearchMassive.Length, 0.05f);
                        Validity validityU010 = Stat_analysis.VerifyCriterionU(criteria[2], firstData.ResearchMassive.Length,
                                                                                        secondData.ResearchMassive.Length, 0.10f);
                        Validity validityK005 = Stat_analysis.VerifyCriterionK(criteria[2], 0.05f);
                        Validity validityK010 = Stat_analysis.VerifyCriterionK(criteria[2], 0.10f);
                        string result = "\n" + 
                                    string.Format("Выполнено сравнение данных {0} <=> {1}:\n", firstNum, secondNum) +
                                    "Первый набор данных для модели: " + firstData.Path + ";\n" +
                                    "Исследуемый признак: " + firstData.Name + ";\n" +
                                    "Второй набор данных для модели: " + firstData.Path + ";\n" +
                                    "Исследуемый признак: " + firstData.Name + ";\n" +
                                    "Критерий Краскела — Уоллиса:     " + criteria[0] + ";\n" +
                                    "Критерий Манна — Уитни (1 вар.): " + criteria[1] + ";\n" +
                                    "Критерий Манна — Уитни (2 вар.): " + criteria[2] + ";\n" +
                                    "Критерий Вальда — Вольфовица:    " + criteria[3] + ";\n" +
                                    "Критерий Колмогорова — Смирнова: " + criteria[4] + ";\n" +
                                    "Критерий Пирсона               : " + criteria[5] + ".\n" +
                        "Проверка справедливости нулевой гипотезы по U-критерию Манна — Уитни.\n" +
                        (validityU001 == Validity.yes ?
                        "При уровне значимости 0.01 гипотеза сдвига не отклоняется; \n" :
                        validityU001 != Validity.excluded ?
                        "При уровне значимости 0.01 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по U-критерию Манна — Уитни!\n") +
                        (validityU005 == Validity.yes ?
                        "При уровне значимости 0.05 гипотеза сдвига не отклоняется; \n" :
                        validityU005 != Validity.excluded ?
                        "При уровне значимости 0.05 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по U-критерию Манна — Уитни!\n") +
                        (validityU010 == Validity.yes ?
                        "При уровне значимости 0.10 гипотеза сдвига не отклоняется; \n" :
                        validityU010 != Validity.excluded ?
                        "При уровне значимости 0.10 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по U-критерию Манна — Уитни!\n") +

                        "Проверка справедливости нулевой гипотезы по критерию Вальда — Вольфовица.\n" +
                        (validityR005 == Validity.yes ?
                        "При уровне значимости 0.05 гипотеза сдвига не отклоняется; \n" :
                        validityR005 != Validity.excluded ?
                        "При уровне значимости 0.05 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по критерию Вальда — Вольфовица!\n") +
                        (validityR010 == Validity.yes ?
                        "При уровне значимости 0.10 гипотеза сдвига не отклоняется; \n" :
                        validityR010 != Validity.excluded ?
                        "При уровне значимости 0.10 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по критерию Вальда — Вольфовица!\n") +

                        "Проверка справедливости нулевой гипотезы по критерию Колмогорова — Смирнова\n" +
                        (validityK005 == Validity.yes ?
                        "При уровне значимости 0.05 гипотеза сдвига не отклоняется; \n" :
                        validityK005 != Validity.excluded ?
                        "При уровне значимости 0.05 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по критерию Колмогорова — Смирнова!\n") +
                        (validityK010 == Validity.yes ?
                        "При уровне значимости 0.10 гипотеза сдвига не отклоняется; \n" :
                        validityK010 != Validity.excluded ?
                        "При уровне значимости 0.10 не подтверждена гипотеза сдвига; \n" :
                        "Исключение при проверке по критерию Колмогорова — Смирнова!\n\n");

                        frmMain.varDatasMassive.Where(var => var.Number == firstNum).First().ResultAnalyse += result;
                        frmMain.varDatasMassive.Where(var => var.Number == secondNum).First().ResultAnalyse += result;
                        frmMain.varDatasMassive.Where(var => var.Number == firstNum).First().SelectAnalyse = 
                                                                                    toolStripComboBoxVariantAnalize.Text;
                        frmMain.varDatasMassive.Where(var => var.Number == secondNum).First().SelectAnalyse =
                                                                                    toolStripComboBoxVariantAnalize.Text;
                    }
                }
            }
            else if (toolStripComboBoxVariantAnalize.SelectedIndex == 1)
            {
                for (int j = 0; j < numberDataMassive.Where(v => v != 0).Count(); j++)
                {
                    int num = numberDataMassive.Where(v => v != 0).ToList<int>()[j];
                    var data = frmMain.varDatasMassive.Where(var => var.Number == num).First();
                    float[] statistics = (float[])stat.ComplexAnalysis(data.ResearchMassive, data.SeriesDensity.Points.Count)[0];
                    string result = stat.GenerateReportTestDistribution(statistics, data.ResearchMassive);
                    frmMain.varDatasMassive.Where(var => var.Number == num).First().ResultAnalyse += result;
                    frmMain.varDatasMassive.Where(var => var.Number == num).First().SelectAnalyse =
                                                                                    toolStripComboBoxVariantAnalize.Text;
                }
            }
            else
            {
                MessageBox.Show("Процедура анализа не выполняется.", "Недоработка!");
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            toolStripStatusLabelStatAnal.Text = "Анализ выполнен. Время расчета: " + elapsedTime;
            toolStripStatusLabelStatAnal.ForeColor = Color.Black;
        }
        /// <summary>
        /// Запуск гистограмм/форм с текстом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewGroupAnalise_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //игнорирование нажатия вне кнопки
            if (e.RowIndex < 0 || e.ColumnIndex <= 1) return;

            FormResults formAnalResults = new FormResults();
            formAnalResults.Activate();
            formAnalResults.toolStripComboBoxResult.Enabled = false;
            formAnalResults.toolStripButtonSelect.Enabled = false;
            //Порядковый номер данных
            int numSearch = int.Parse(dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["Number"].Index, e.RowIndex].Value.ToString());
            if (frmMain.varDatasMassive.Where(var => var.Number == numSearch).Count() != 0)
            {
                var varData = frmMain.varDatasMassive.Where(var => var.Number == numSearch).First();
                //Результаты анализа
                if (dataGridViewGroupAnalise.Columns[e.ColumnIndex].Name == "Calculate")
                {
                    formAnalResults.richTextBoxResultAnalysis.Text = varData.ResultAnalyse;
                    formAnalResults.Show();
                }
                //Исходные данные
                if (dataGridViewGroupAnalise.Columns[e.ColumnIndex].Name == "SourceData")
                {
                    float[] massive = varData.ResearchMassive;
                    for (int i = 0; i < massive.Count(); i++)
                    {
                        formAnalResults.richTextBoxResultAnalysis.Text += string.Format("[{0}]\t = ", i) + massive[i] + ";\n";
                    }
                    formAnalResults.Text = "Исходные данные";
                    formAnalResults.Show();
                }
                //Просмотр гистограммы
                if (dataGridViewGroupAnalise.Columns[e.ColumnIndex].Name == "Histogram" && varData.SeriesDensity != null)
                {
                    try
                    {
                        FormAnalysisSteps analysisSteps = new FormAnalysisSteps(); // Форма для анализа серии данных
                        foreach (float item in varData.ResearchMassive)
                            analysisSteps.richTextBoxData.AppendText(item.ToString() + "\n");
                        //Вывод данных на гистограмму распределения
                        Stat_analysis statisticaPar = new Stat_analysis();
                        object[] resultStat = statisticaPar.ComplexAnalysis(varData.ResearchMassive, varData.SeriesDensity.Points.Count());
                        //0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм.,...
                        float[] resultStatParLayer = (float[])resultStat[0];
                        Series seriesDensity = (Series)resultStat[1];
                        Series seriesIntegralFunction = (Series)resultStat[2];
                        float[] resultQuartile = (float[])resultStat[3];
                        analysisSteps.richTextBoxQuartile.Text = "Значения квартилей: \n";
                        for (int j = 0; j < resultQuartile.Length; j++)
                        {
                            analysisSteps.richTextBoxQuartile.AppendText(j + " - " + resultQuartile[j].ToString() + "\n");
                        }
                        seriesDensity.ChartArea = "ChartArea1";
                        seriesDensity.ChartType = SeriesChartType.Column;
                        analysisSteps.chartDependent.Palette = ChartColorPalette.BrightPastel;
                        analysisSteps.chartDependent.Series.Add(seriesDensity);
                        analysisSteps.researchMassive = varData.ResearchMassive;
                        analysisSteps.researchMassiveZ = varData.ResearchMassiveZ;
                        analysisSteps.resultStatParLayer = resultStatParLayer;
                        analysisSteps.seriesDensity = seriesDensity;
                        analysisSteps.seriesIntegralFunction = seriesIntegralFunction;
                        analysisSteps.seriesData = varData.SeriesData;
                        analysisSteps.seriesFunctionZ = varData.SeriesFunctionZ;
                        analysisSteps.numericUpDownNumIntervals.Value = varData.SeriesDensity.Points.Count();
                        analysisSteps.titleForm = string.Format("Файл \"{0}\": {1}", varData.Path, varData.Name);
                        analysisSteps.buttonAddInComparison.Enabled = false;
                        analysisSteps.Activate();
                        analysisSteps.Show();
                    }
                    catch (Exception e17)
                    { MessageBox.Show(e17.Message); }
                }

                //История (Время и заданные параметры расчета)
                if (dataGridViewGroupAnalise.Columns[e.ColumnIndex].Name == "History")
                {
                    formAnalResults.richTextBoxResultAnalysis.Text = varData.History;
                    formAnalResults.Text = "История (Время и заданные параметры расчета)";
                    formAnalResults.Show();
                }
            }
        }
        /// <summary>
        /// Удалить выделенные данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewGroupAnalise.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["M0"].Index, i].Value.ToString().Trim() == "1")
                dataGridViewGroupAnalise.Rows.RemoveAt(i);
            }
        }
        /// <summary>
        /// Метка выделения/снятия выделения
        /// </summary>
        bool mSelect = true;

        /// <summary>
        /// Выделить все записи (снять выделение)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGroupAnalise.Rows.Count; i++)
            {
                if (mSelect)
                {
                    dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["M0"].Index, i].Value = 0;
                }
                else
                {
                    dataGridViewGroupAnalise[dataGridViewGroupAnalise.Columns["M0"].Index, i].Value = 1;
                }
            }
            mSelect = !mSelect;
        }
        /// <summary>
        /// Обновить данные в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonReload_Click(object sender, EventArgs e)
        {
            dataGridViewGroupAnalise.Rows.Clear();
            FormStatAnal_Load(this, EventArgs.Empty);
        }

        /// <summary>
        /// Сохранение данных анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            /*
            toolStripStatusLabelCreateVoxel.Text = "Сохранение модели...";
            Application.DoEvents();
            saveFileDialogU.FileName = "vox_" +
                           DateTime.Now.Year.ToString() + "_" +
                           DateTime.Now.Month.ToString() + "_" +
                           DateTime.Now.Day.ToString() + "_" +
                           DateTime.Now.Hour.ToString() + "_" +
                           DateTime.Now.Minute.ToString();
            if (saveFileDialogU.ShowDialog() == DialogResult.OK && ListVox.Count != 0)
            {
                var StartTime = DateTime.Now;

                try
                {
                    XmlTextWriter textWritter = new XmlTextWriter(saveFileDialogU.FileName, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    //Тело (Variants):
                    textWritter.WriteStartElement("VoxelModel");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(saveFileDialogU.FileName);
                    
                    //richTextBoxInfo
                    XmlNode element0 = xDoc.CreateElement("richTextBoxInfo");
                    element0.InnerText = @toolStripTextBoxFileName.Text;
                    xDoc.DocumentElement.AppendChild(element0);
                    //
                    //Количество вокселей
                    XmlNode elementCount = xDoc.CreateElement("CountVoxels");
                    elementCount.InnerText = ListVox.Count.ToString();
                    xDoc.DocumentElement.AppendChild(elementCount);
                    //
                    object[] massiveObjectsNumeric = new object[3] { numericUpDownVoxX, numericUpDownVoxY, numericUpDownVoxZ };
                    object[] massiveObjects = new object[23] {textBoxMinX, textBoxMinY, textBoxMinZ,
                                                              textBoxMaxX, textBoxMaxY, textBoxMaxZ,
                                                              textBoxSizeX, textBoxSizeY, textBoxSizeZ,
                                                              textBoxTotalVox,
                                                              textBoxVoxMinX, textBoxVoxMinY, textBoxVoxMinZ,
                                                              textBoxVoxMaxX, textBoxVoxMaxY, textBoxVoxMaxZ,
                                                              textBoxVoxSizeX, textBoxVoxSizeY, textBoxVoxSizeZ,
                                                              textBoxErrorX, textBoxErrorY, textBoxErrorZ,
                                                              textBoxTotalVoxRez };
                    for (int i = 0; i < massiveObjectsNumeric.Length; i++)
                    {
                        XmlNode element = xDoc.CreateElement(((NumericUpDown)massiveObjectsNumeric[i]).Name);
                        element.InnerText = ((NumericUpDown)massiveObjectsNumeric[i]).Value.ToString();
                        xDoc.DocumentElement.AppendChild(element);
                    }
                    for (int i = 0; i < massiveObjects.Length; i++)
                    {
                        XmlNode element = xDoc.CreateElement(((TextBox)massiveObjects[i]).Name);
                        element.InnerText = ((TextBox)massiveObjects[i]).Text;
                        xDoc.DocumentElement.AppendChild(element);
                    }

                    XmlNode elementVoxels = xDoc.CreateElement("Voxels");
                    xDoc.DocumentElement.AppendChild(elementVoxels);
                    int numTempvoxstr = 0;
                    foreach (var item in ListVox)
                    {
                        XmlNode elementVox = xDoc.CreateElement("Voxel");
                        // Nom; Xv; Yv; Zv; Lv; Lfull; NomModel; SizeX; SizeY; SizeZ
                        elementVox.InnerText = item.Nom.ToString() + ";" +
                                               item.Xv.ToString() + ";" +
                                               item.Yv.ToString() + ";" +
                                               item.Zv.ToString() + ";" +
                                               item.Lv.ToString() + ";" +
                                               item.Lfull.ToString() + ";" +
                                               item.NomModel.ToString() + ";" +
                                               item.SizeX.ToString() + ";" +
                                               item.SizeY.ToString() + ";" +
                                               item.SizeZ.ToString();
                        elementVoxels.AppendChild(elementVox);
                        proc.ProgressBarRefresh(toolStripProgressBarCreateVoxel, numTempvoxstr++, ListVox.Count);
                    }
                    xDoc.Save(saveFileDialogU.FileName);
                }
                catch (Exception e7)
                {
                    MessageBox.Show("Не записана БД! \n" + e7.Message, "Проблема!");
                }

                var dTime = DateTime.Now - StartTime;
                richTextBoxInfo.Text += "Записан файл: " + saveFileDialogU.FileName + ", за " + dTime.TotalSeconds.ToString("###,0") + " с. \n";
            }
            toolStripStatusLabelCreateVoxel.Text = "Модель сохранена в файл: " + saveFileDialogU.FileName;
            try
            {
                frmMain.richTextBoxHistory.Text += "Воксельная модель сохранена в файл: " + saveFileDialogU.FileName + " \n";
            }
            catch (Exception e9)
            {
                MessageBox.Show(e9.Message);
            }
             
             */
        }

        /// <summary>
        /// Загрузка данных анализа с заменой существующих
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonLoad_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Добавление данных анализа к существующим
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
