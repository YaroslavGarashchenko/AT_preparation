using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    /// <summary>
    /// Форма для анализа распределения вокселей в пространстве
    /// </summary>
    public partial class FormDitribution3D : Form
    {
        public FormDitribution3D()
        {
            InitializeComponent();
        }
        //Массивы для анализа объемного распределения
        public float[,,] distributionXYZ;
        public float[,,] distributionXYZEmpty;
        //Количество интервалов разбиения рабочего объема построения по каждой из осей X, Y, Z
        public int intervalsX;
        public int intervalsY;
        public int intervalsZ;
        //Текущая координата по высоте
        enum coordinateH { X, Y, Z };
        coordinateH currentH = coordinateH.Z;

        //Процедуры цвета
        ColorProcedures cproc = new ColorProcedures();

        /// <summary>
        /// Переключение плоскостей для просмотра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSection_Click(object sender, EventArgs e)
        {
            if (currentH == coordinateH.Z)
            {
                buttonSection.Text = "YZ";
                trackBarHeight.Maximum = intervalsX;
                currentH = coordinateH.X;

            }
            else if (currentH == coordinateH.X)
            {
                buttonSection.Text = "XZ";
                trackBarHeight.Maximum = intervalsY;
                currentH = coordinateH.Y;
            }
            else if (currentH == coordinateH.Y)
            {
                buttonSection.Text = "XY";
                trackBarHeight.Maximum = intervalsZ;
                currentH = coordinateH.Z;
            }
            trackBarHeight_ValueChanged(sender, e);
            panelReview3D.Refresh();
        }

        private void panelReview3D_Paint(object sender, PaintEventArgs e)
        {
            try
            {

            if (distributionXYZ.Length == 0) return;
            int Hp = 0, Wp = 0;
            //Размеры прямоугольника
            if (currentH == coordinateH.X)
            {
                Hp = (int)Math.Floor((decimal)panelReview3D.Height / intervalsZ);
                Wp = (int)Math.Floor((decimal)panelReview3D.Width / intervalsY);
            }
            else if (currentH == coordinateH.Y)
            {
                Hp = (int)Math.Floor((decimal)panelReview3D.Height / intervalsZ);
                Wp = (int)Math.Floor((decimal)panelReview3D.Width / intervalsX);
            }
            else if (currentH == coordinateH.Z)
            {
                Hp = (int)Math.Floor((decimal)panelReview3D.Height / intervalsY);
                Wp = (int)Math.Floor((decimal)panelReview3D.Width / intervalsX);
            }

            Graphics contourGraphics = panelReview3D.CreateGraphics();

            Color myColor = new Color();
            SolidBrush sBrush = new SolidBrush(myColor);
            
            if (currentH == coordinateH.X)
            {
                int i = trackBarHeight.Value - 1;
                for (int j = 0; j < intervalsY; j++)
                {
                    for (int k = 0; k < intervalsZ; k++)
                    {
                        float Km;
                        if (checkBoxVoxelPartOrFree.CheckState == CheckState.Checked)
                            {
                                Km = distributionXYZ[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                        else
                            {
                                Km = distributionXYZEmpty[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                        myColor = Color.FromArgb((int)(numericUpDownR1.Value + 
                                      Math.Floor((decimal)Km*(numericUpDownR2.Value - numericUpDownR1.Value))),
                                                     (int)(numericUpDownG1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownG2.Value - numericUpDownG1.Value))),
                                                     (int)(numericUpDownB1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownB2.Value - numericUpDownB1.Value))));

                        sBrush = new SolidBrush(myColor);
                        
                        contourGraphics.FillRectangle(sBrush, j*Wp, k*Hp, Wp, Hp);
                    }
                }
            }
            else if (currentH == coordinateH.Y)
            {
                int j = trackBarHeight.Value - 1;
                for (int i = 0; i < intervalsX; i++)
                {
                    for (int k = 0; k < intervalsZ; k++)
                    {
                            float Km;
                            if (checkBoxVoxelPartOrFree.CheckState == CheckState.Checked)
                            {
                                Km = distributionXYZ[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                            else
                            {
                                Km = distributionXYZEmpty[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                            myColor = Color.FromArgb((int)(numericUpDownR1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownR2.Value - numericUpDownR1.Value))),
                                                     (int)(numericUpDownG1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownG2.Value - numericUpDownG1.Value))),
                                                     (int)(numericUpDownB1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownB2.Value - numericUpDownB1.Value))));

                        sBrush = new SolidBrush(myColor);

                        contourGraphics.FillRectangle(sBrush, i * Wp, k * Hp, Wp, Hp);
                    }
                }
            }
            else if (currentH == coordinateH.Z)
            {
                int k = trackBarHeight.Value - 1;
                for (int i = 0; i < intervalsX; i++)
                {
                    for (int j = 0; j < intervalsY; j++)
                    {
                            float Km;
                            if (checkBoxVoxelPartOrFree.CheckState == CheckState.Checked)
                            {
                                Km = distributionXYZ[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                            else
                            {
                                Km = distributionXYZEmpty[i, j, k] /
                                    (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]);
                            }
                            myColor = Color.FromArgb((int)(numericUpDownR1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownR2.Value - numericUpDownR1.Value))),
                                                     (int)(numericUpDownG1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownG2.Value - numericUpDownG1.Value))),
                                                     (int)(numericUpDownB1.Value +
                                      Math.Floor((decimal)Km * (numericUpDownB2.Value - numericUpDownB1.Value))));

                        sBrush = new SolidBrush(myColor);

                        contourGraphics.FillRectangle(sBrush, i * Wp, j * Hp, Wp, Hp);
                    }
                }
            }
            sBrush.Dispose();
            contourGraphics.Dispose();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Проверьте исходные данные! \n" + e1.Message, "Проблема");

            }
        }

        private void numericUpDownR1_ValueChanged(object sender, EventArgs e)
        {
            cproc.changeColorLabel(labelRGB1, (int)numericUpDownR1.Value,
                                              (int)numericUpDownG1.Value,
                                              (int)numericUpDownB1.Value);
        }

        private void numericUpDownR2_ValueChanged(object sender, EventArgs e)
        {
            cproc.changeColorLabel(labelRGB2, (int)numericUpDownR2.Value,
                                              (int)numericUpDownG2.Value,
                                              (int)numericUpDownB2.Value);
        }

        private void labelRGB1_DoubleClick(object sender, EventArgs e)
        {
            cproc.doubleClickColorLabel(sender, colorDialogSelect, numericUpDownR1,
                                          numericUpDownG1, numericUpDownB1);
        }

        private void labelRGB2_Click(object sender, EventArgs e)
        {
            cproc.doubleClickColorLabel(sender, colorDialogSelect, numericUpDownR2,
                              numericUpDownG2, numericUpDownB2);
        }
        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDitribution3D_Load(object sender, EventArgs e)
        {
            labelСurrent.Text = "Z: 1/" + intervalsZ;
            trackBarHeight.Maximum = intervalsZ;
            labelStat.Text = "Количество элементов декомпозиции: " +
                             (intervalsX * intervalsY * intervalsZ).ToString();
        }

        private void trackBarHeight_ValueChanged(object sender, EventArgs e)
        {
            panelReview3D.Refresh();
            if(currentH == coordinateH.X)
            labelСurrent.Text = "X: " + trackBarHeight.Value + "/" + trackBarHeight.Maximum;
            if (currentH == coordinateH.Y)
                labelСurrent.Text = "Y: " + trackBarHeight.Value + "/" + trackBarHeight.Maximum;
            if (currentH == coordinateH.Z)
                labelСurrent.Text = "Z: " + trackBarHeight.Value + "/" + trackBarHeight.Maximum;
        }
        /// <summary>
        /// Выбор анализа распределения вокселей изделия или свободного пространства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxVoxelPartOrFree_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxVoxelPartOrFree.CheckState == CheckState.Unchecked)
            { checkBoxVoxelPartOrFree.Text = "Свободного прост-ва"; }
            else
            { checkBoxVoxelPartOrFree.Text = "Изделия"; }
            panelReview3D.Refresh();
        }
        /// <summary>
        /// Список для построения гистограммы
        /// </summary>
        List<float> tempMassiveVoxel3D = new List<float>();
        List<float> tempMassiveVoxel3DEmpty = new List<float>();

        /// <summary>
        /// Вывод гистограммы распределения вокселей при декомпозиции изделия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGist_Click(object sender, EventArgs e)
        {
            List<Stat_analysis.elementGist> gist3D = new List<Stat_analysis.elementGist>();
            Stat_analysis statistica3D = new Stat_analysis();
            //Статистика
            int emptyElement = 0;
            int fullElement = 0;
            int limitElement = 0;

            for (int i = 0; i < intervalsX; i++)
            {
                for (int j = 0; j < intervalsY; j++)
                {
                    for (int k = 0; k < intervalsZ; k++)
                    {
                        tempMassiveVoxel3D.Add(distributionXYZ[i, j, k] /
                                              (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]));
                        tempMassiveVoxel3DEmpty.Add(distributionXYZEmpty[i, j, k] /
                                              (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]));
                        if (distributionXYZ[i, j, k] == 0)
                            { emptyElement++; }
                        if (distributionXYZEmpty[i, j, k] == 0)
                            { fullElement++;}
                        if (0.5f <= distributionXYZ[i, j, k] / (distributionXYZ[i, j, k] + distributionXYZEmpty[i, j, k]))
                        { limitElement++; }
                    }
                }
            }
            labelStat.Text = "Количество элементов декомпозиции: " +
                             (intervalsX * intervalsY * intervalsZ).ToString() + 
                             "; пустых: " + emptyElement + "; полных: " + fullElement + 
                             "; заполненных на 50...100%: " + limitElement + ".";
            try
            {
                FormGist formGistogram = new FormGist();
                if (checkBoxVoxelPartOrFree.CheckState == CheckState.Checked)
                {
                    gist3D = statistica3D.Gist(tempMassiveVoxel3D.ToArray(), 10);
                    formGistogram.Text = "Гистограмма распределения относительного объема " +
                                         "заполнения элементов декомпозиции";
                }
                else
                {
                    gist3D = statistica3D.Gist(tempMassiveVoxel3DEmpty.ToArray(), 10);
                    formGistogram.Text = "Гистограмма распределения относительного объема " +
                     "свободного пространства для элементов декомпозиции";
                }
                
                formGistogram.Activate();
                formGistogram.Show();

                //Вывод данных на гистограмму распределения
                Series seriesStatisticalPar = new Series();
                Series seriesStatisticalPar2 = new Series();

                float SumInt = 0;
                float SumPar = 0;
                //Относительные величины
                for (int i = 0; i < gist3D.Count; i++)
                {
                    SumPar += gist3D[i].Y;
                }
                //
                for (int i = 0; i < gist3D.Count; i++)
                {
                    seriesStatisticalPar.Points.Add(
                        new DataPoint(Math.Round((gist3D[i].Xmin + gist3D[i].Xmax) / 2, 2), gist3D[i].Y / SumPar));
                    SumInt += gist3D[i].Y;
                    seriesStatisticalPar2.Points.Add(
                        new DataPoint(Math.Round((gist3D[i].Xmin + gist3D[i].Xmax) / 2, 2), SumInt / SumPar));
                }
                seriesStatisticalPar2.ChartArea =
                seriesStatisticalPar.ChartArea = "ChartArea1";
                seriesStatisticalPar2.ChartType =
                seriesStatisticalPar.ChartType = SeriesChartType.Column;

                formGistogram.chartGistogram.ChartAreas[0].AxisX.Minimum = 0;
                formGistogram.chartGistogram.ChartAreas[0].AxisX.Maximum = 1;

                formGistogram.chartIntegral.ChartAreas[0].AxisX.Minimum = 0;
                formGistogram.chartIntegral.ChartAreas[0].AxisX.Maximum = 1;

                formGistogram.chartIntegral.Palette =
                formGistogram.chartGistogram.Palette = ChartColorPalette.BrightPastel;

                formGistogram.chartGistogram.Series.Add(seriesStatisticalPar);
                formGistogram.chartIntegral.Series.Add(seriesStatisticalPar2);
            }
            catch (Exception e17)
            {
                MessageBox.Show(e17.Message);
            }
        }
    }
}
