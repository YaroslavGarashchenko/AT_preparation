using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace PreAddTech
{
    /// <summary>
    /// Класс статистического анализа
    /// </summary>
    class Stat_analysis
    {
        /// <summary>
        /// Массив статистических характеристик
        /// </summary>
        private float[] stat = new float[13];
        /// <summary>
        /// Определение статистических характеристик для массива данных
        /// </summary>
        /// <returns>0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
        /// 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки</returns>
        public float[] Stat(float[] DataArray)
        {
            stat[0] = DataArray.Min(); //минимальное значение
            stat[1] = DataArray.Max(); //максимальное значение
            stat[2] = stat[1] - stat[0]; // интервал значений
            stat[12] = DataArray.Length; // объем выборки
            //
            float sumx = 0;
            float sumx2 = 0;
            float sumx3 = 0;
            float sumx4 = 0;
            for (int i = 0; i < stat[12]; i++)
            {
                sumx += DataArray[i];
                sumx2 += DataArray[i] * DataArray[i];
                sumx3 += DataArray[i] * DataArray[i] * DataArray[i];
                sumx4 += DataArray[i] * DataArray[i] * DataArray[i] * DataArray[i];
            }
            //
            stat[5] = sumx / stat[12]; // среднеарифметическое значение (начальный момент первого порядка)
            // начальные моменты
            float nm2 = sumx2 / stat[12];
            float nm3 = sumx3 / stat[12];
            float nm4 = sumx4 / stat[12];
            // центральные моменты
            float cm3 = nm3 - 3 * stat[5] * nm2 + 2 * stat[5] * stat[5] * stat[5];
            float cm4 = nm4 - 4 * stat[5] * nm3 + 6 * stat[5] * stat[5] * nm2 - 3 * stat[5] * stat[5] * stat[5] * stat[5];
            //
            stat[3] = nm2 - stat[5] * stat[5]; //дисперсия
            stat[4] = (float)Math.Sqrt(stat[3]); // среднеквадратическое отклонение
            stat[6] = cm3 / (stat[3] * stat[4]); // коэффициент ассиметрии
            stat[7] = cm4 / (stat[3] * stat[3]) - 3; // коэффициент эксцесса
            stat[8] = stat[4] / stat[5]; // коэффициент вариации
            stat[9] = (stat[1] - stat[0]) / 2; // меана
            stat[10] = 0; // мода
            try
            {
                if ((Math.Truncate((decimal)DataArray.Length / 2) - (decimal)DataArray.Length / 2) == 0)
                    stat[11] = (DataArray[DataArray.Length / 2] + DataArray[DataArray.Length / 2 + 1]) / 2; // медиана
                else
                    stat[11] = DataArray[(int)Math.Truncate((decimal)DataArray.Length / 2)];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return stat;
        }
        /// <summary>
        /// Определение статистических характеристик для массива данных (Перегруженный) с модой
        /// </summary>
        /// <returns>0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
        /// 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (высчитывается), 11 - медиана, 12 - объем выборки</returns>
        public float[] Stat(float[] DataArray, List<elementGist> gist)
        {
            stat = Stat(DataArray);
            //
            float Maxgistmas = float.MinValue;
            stat[10] = 0; // мода
            for (int i = 0; i < gist.Count; i++)
            {
                if (Maxgistmas < gist[i].Y)
                {
                    Maxgistmas = gist[i].Y;
                    stat[10] = (gist[i].Xmin + gist[i].Xmax) / 2;
                }
            }
            return stat;
        }

        /// <summary>
        /// Данные элемента гистограммы
        /// </summary>
        public class elementGist
        {
            private float xmin;
            /// <summary>
            /// Минимальное значение интервала
            /// </summary>
            public float Xmin
            {
                get { return xmin; }
                set { xmin = value; }
            }
            private float xmax;
            /// <summary>
            /// Максимальное значение интервала
            /// </summary>
            public float Xmax
            {
                get { return xmax; }
                set { xmax = value; }
            }
            private float y;
            /// <summary>
            /// Величина плотности интервала (относительная высота столбика)
            /// </summary>
            public float Y
            {
                get { return y; }
                set { y = value; }
            }
        }

        /// <summary>
        /// Список данных гистограммы
        /// </summary>
        private List<elementGist> gist = new List<elementGist>();

        /// <summary>
        /// Формирование данных для гистограмм
        /// </summary>
        /// <returns></returns>
        public List<elementGist> Gist(float[] DataArray, int NumInt)
        {
            //Объем выборки
            int Nvib = DataArray.Length;
            //создаем список интервалов
            gist.Clear();
            //
            if (Nvib == 0)
            {
                MessageBox.Show("Нет данных для анализа", "Проблема!");
                return gist;
            }
            float Xmin = DataArray.Min();
            float Xmax = DataArray.Max();
            float Xint = Xmax - Xmin; // интервал значений

            for (int i = 0; i < NumInt; i++)
            {
                elementGist tempElementGist = new elementGist();
                tempElementGist.Xmin = Xmin + i * (Xint / NumInt);
                tempElementGist.Xmax = Xmin + (i + 1) * (Xint / NumInt);
                tempElementGist.Y = 0;
                gist.Add(tempElementGist);
            }
            if (!float.IsNaN(Xint) && !float.IsNaN(Xmin) && Xint != 0)
            {
                int k = 0; //индекс текущего интервала
                           //
                for (int j = 0; j < Nvib; j++)
                {
                    k = (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) != gist.Count ?
                        (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) : gist.Count - 1;
                    gist[k].Y += 1;
                }
            }
            return gist;
        }

        /// <summary>
        /// Формирование данных для гистограмм (перегружен с учетом весового коэффициента)
        /// </summary>
        /// <returns></returns>
        public List<elementGist> Gist(float[] DataArray, int NumInt, float[] KoefVesArray)
        {
            //Объем выборки
            int Nvib = DataArray.Length;
            if (Nvib != KoefVesArray.Length)
            {
                MessageBox.Show("Несоответствие размеров исходных массивов для статистического анализа");
            }
            //
            float Xmin = DataArray.Min();
            float Xmax = DataArray.Max();
            float Xint = Xmax - Xmin; // интервал значений
            //создаем список интервалов
            gist.Clear();
            for (int i = 0; i < NumInt; i++)
            {
                elementGist tempElementGist = new elementGist();
                tempElementGist.Xmin = Xmin + i * (Xint / NumInt);
                tempElementGist.Xmax = Xmin + (i + 1) * (Xint / NumInt);
                tempElementGist.Y = 0;
                gist.Add(tempElementGist);
            }
            if (Xint != 0 && !float.IsNaN(Xmin) && !float.IsNaN(Xint))
            {
                int k = 0; //индекс текущего интервала
                           //
                for (int j = 0; j < Nvib; j++)
                {
                    k = (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) != gist.Count ?
                        (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) : gist.Count - 1;
                    gist[k].Y += KoefVesArray[j];
                }
            }
            return gist;
        }

        /// <summary>
        /// Формирование данных для гистограмм (перегружен с учетом весового коэффициента) и заданных мин. и макс. значения
        /// </summary>
        /// <returns></returns>
        public List<elementGist> Gist(float[] DataArray, int NumInt, float[] KoefVesArray, float Xmin, float Xmax)
        {
            //Объем выборки
            int Nvib = DataArray.Length;
            if (Nvib != KoefVesArray.Length)
            {
                MessageBox.Show("Несоответствие размеров исходных массивов для статистического анализа");
            }
            //
            float Xint = Xmax - Xmin; // интервал значений
            //создаем список интервалов
            gist.Clear();
            for (int i = 0; i < NumInt; i++)
            {
                elementGist tempElementGist = new elementGist();
                tempElementGist.Xmin = Xmin + i * (Xint / NumInt);
                tempElementGist.Xmax = Xmin + (i + 1) * (Xint / NumInt);
                tempElementGist.Y = 0;
                gist.Add(tempElementGist);
            }
            if (Xint != 0 && !float.IsNaN(Xmin) && !float.IsNaN(Xint))
            {
                int k = 0; //индекс текущего интервала
                           //
                for (int j = 0; j < Nvib; j++)
                {
                    k = (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) != gist.Count ?
                        (int)Math.Floor((DataArray[j] - Xmin) / (Xint / NumInt)) : gist.Count - 1;
                    gist[k].Y += KoefVesArray[j];
                }
            }
            return gist;
        }

        /// <summary>
        /// Комплексный статистический анализ
        /// </summary>
        /// <param name="DataArray">Массив исходных данных</param>
        /// <param name="NumInt">Количество интервалов гистограммы</param>
        /// <returns> 0 - resultStatParLayer, 1 - seriesDensity, 2 - seriesIntegralFunction, 3 - resultQuartile</returns>
        public object[] ComplexAnalysis(float[] DataArray, int NumInt)
        {
            List<elementGist> gistPar = Gist(DataArray, NumInt);
            float[] resultStatParLayer = Stat(DataArray, gistPar);
            float[] resultQuartile = Quartile(DataArray);
            //Вывод данных на гистограмму распределения
            Series seriesDensity = new Series();
            Series seriesIntegralFunction = new Series();
            float SumInt = 0;
            float SumPar = 0;
            //Относительные величины
            for (int i = 0; i < gistPar.Count; i++)
                SumPar += gistPar[i].Y;

            for (int i = 0; i < gistPar.Count; i++)
            {
                seriesDensity.Points.Add(
                    new DataPoint(Math.Round((gistPar[i].Xmin + gistPar[i].Xmax) / 2, 2), gistPar[i].Y / SumPar));
                SumInt += gistPar[i].Y;
                seriesIntegralFunction.Points.Add(
                    new DataPoint(Math.Round((gistPar[i].Xmin + gistPar[i].Xmax) / 2, 2), SumInt / SumPar));
            }
            return new object[4] { resultStatParLayer, seriesDensity, seriesIntegralFunction, resultQuartile };
        }

        /// <summary>
        /// Определение квартилей для массива данных
        /// </summary>
        /// <returns>0 - мин., 1 - 1 квартиль., 2 - медиана, 3 - 3 квартиль, 4 - макс.</returns>
        public float[] Quartile(float[] DataArray)
        {
            if (DataArray == null || DataArray.Length < 5)
                return new float[5] { 0, 0, 0, 0, 0 };

            float[] result = new float[5];
            float[] dArray = DataArray.OrderBy(d => d).ToArray();
            //Array.Sort(dArray); ссылочный тип
            result[0] = dArray[0];
            result[1] = dArray[(int)Math.Floor((double)dArray.Length / 4)] +
                       (dArray[(int)Math.Floor((double)dArray.Length / 4)] -
                        dArray[(int)Math.Ceiling((double)dArray.Length / 4)]) *
                       ((float)Math.Floor((double)dArray.Length / 4) - (dArray.Length / 4));
            result[2] = (dArray[(int)Math.Ceiling((double)dArray.Length / 2)] +
                         dArray[(int)Math.Floor((double)dArray.Length / 2)]) / 2;
            result[3] = dArray[(int)Math.Floor((double)dArray.Length * 3 / 4)] +
                       (dArray[(int)Math.Floor((double)dArray.Length * 3 / 4)] -
                        dArray[(int)Math.Ceiling((double)dArray.Length * 3 / 4)]) *
                       ((float)Math.Floor((double)dArray.Length * 3 / 4) - (dArray.Length * 3 / 4));
            result[4] = dArray[dArray.Length - 1];
            return result;
        }

        /// <summary>
        /// Статистический сравнительный анализ двух выборок
        /// </summary>
        /// <param name="data1">Первый ряд данных</param>
        /// <param name="data2">Второй ряд данных</param>
        /// <returns> Массив значений критериев { [0] Kruskal–Wallis, [1] Mann–Whitney, [2] Манна — Уитни, 
        /// [3] Вальда — Вольфовица, [4] Колмогорова — Смирнова, [5] Пирсона } </returns>
        public float[] ComparisonStatData( float[] data1, float[] data2 )
        {
            //U-критерий Манна
            //Составить единый ранжированный ряд из обеих сопоставляемых выборок, 
            //расставив их элементы по степени нарастания признака и приписав меньшему 
            //значению меньший ранг. Общее количество рангов получится равным:
            int GeneralLength = data1.Length + data2.Length;
            List<PointMassive> GeneralMassive = new List<PointMassive>();
            for (int i = 0; i < GeneralLength; i++)
            {
                if (i < data1.Length)
                {
                    GeneralMassive.Add(new PointMassive()
                    {
                        Rank = 0,
                        NumGroup = 1,
                        Point = new Point3D() { X = data1[i], Y = 0, Z = 0 }
                    });
                }
                else
                {
                    GeneralMassive.Add(new PointMassive()
                    {
                        Rank = 0,
                        NumGroup = 2,
                        Point = new Point3D() { X = data2[i], Y = 0, Z = 0 }
                    });
                }
            }
            List<PointMassive> GeneralMassiveOrdered = 
                                      GeneralMassive.OrderBy(p => p.Point.X).ToList<PointMassive>();
            //Определение рангов с учетом повторов значений
            int tempRank = 0;
            for (int j = 0; j < GeneralMassiveOrdered.Count(); j++)
            {
                tempRank = j + 1;
                int tCount = GeneralMassiveOrdered.Where(p => p.Point.X == GeneralMassiveOrdered[j].Point.X).Count();
                for (int i = 0; i < tCount; i++)
                {
                    GeneralMassiveOrdered[j + i].Rank = tempRank + (tCount - 1) / 2;
                }
                j += (tCount - 1);
            }

            int Ri1 = 0, Ri2 = 0;
            for (int i = 0; i < GeneralMassiveOrdered.Count(); i++)
            {
                if (GeneralMassiveOrdered[i].NumGroup == 1)
                {
                    Ri1 += GeneralMassiveOrdered[i].Rank;
                }
                else
                {
                    Ri2 += GeneralMassiveOrdered[i].Rank;
                }
            }
            float Ri1Mean = Ri1 / data1.Length;
            float Ri2Mean = Ri2 / data2.Length;

            // Kruskal–Wallis one-way analysis of variance
            //https://en.wikipedia.org/wiki/Kruskal–Wallis_one-way_analysis_of_variance
            float KruskalWallis = (12 / (GeneralLength * (GeneralLength + 1))) *
                                  (Ri1Mean * Ri1Mean * data1.Length +
                                   Ri2Mean * Ri2Mean * data2.Length) -
                                  3 * (GeneralLength + 1);
            // Mann–Whitney U test 
            //https://en.wikipedia.org/wiki/Mann–Whitney_U_test
            float U1 = Ri1 - (data1.Length * (data1.Length + 1) / 2);
            float U2 = Ri2 - (data2.Length * (data2.Length + 1) / 2);
            float Ueng = (new float[] { U1, U2 }).Min();
            // U-критерий Манна — Уитни
            //https://ru.wikipedia.org/wiki/U-критерий_Манна_—_Уитни
            float Rix = (new float[] { Ri1, Ri2 }).Max();
            float nx = Rix == Ri1 ? data1.Length : data2.Length;
            float Urus = data1.Length * data2.Length + nx * (nx + 1) / 2 - Rix;
            // Серийный критерий Вальда — Вольфовица
            //http://meteoinfo12.ru/files/lab_rab_2_aoed.pdf
            int[] GroupCount = new int[2] {0, 0 };
            for (int i = 0; i < GeneralMassiveOrdered.Count; i++)
            {
                int rank = GeneralMassiveOrdered.Where(n => n.Rank == GeneralMassiveOrdered[i].Rank).Count();
                if (rank > 1)
                {
                    if (i == 0)
                    { ++GroupCount[GeneralMassiveOrdered[i].NumGroup - 1]; }
                    else 
                    { ++GroupCount[0]; ++GroupCount[1]; }
                    i = i + rank - 1;
                }
                else
                {
                    if (i == 0)
                    {
                        ++GroupCount[ GeneralMassiveOrdered[i].NumGroup - 1];
                    }
                    else if (GeneralMassiveOrdered[i-1].NumGroup != GeneralMassiveOrdered[i].NumGroup)
                    {
                            ++GroupCount[GeneralMassiveOrdered[i].NumGroup - 1];
                    }
                }
            }
            float RValda = GroupCount.Sum();
            // Критерий Колмогорова — Смирнова
            float[] unique = data1.Union(data2).ToArray(); //Ряд с уникальными значениями
            int ALength = unique.Length;
            float maxDifference = 0;
            for (int i = 0; i < ALength; i++)
            {
                float value1 = GeneralMassiveOrdered.Where(n => n.Value <= unique[i] && n.NumGroup == 1).
                               Sum(n => n.Value);
                float value1Rel = value1 / GeneralMassiveOrdered.Where(n => n.Value <= unique[i] && n.NumGroup == 1).
                                  Count();
                float value2 = GeneralMassiveOrdered.Where(n => n.Value <= unique[i] && n.NumGroup == 2).
                               Sum(n => n.Value);
                float value2Rel = value2 / GeneralMassiveOrdered.Where(n => n.Value <= unique[i] && n.NumGroup == 2).
                                  Count();
                maxDifference = Math.Abs(value1Rel - value2Rel) > maxDifference ? 
                                Math.Abs(value1Rel - value2Rel) : maxDifference;
            }
            float lamda = maxDifference * maxDifference * (data1.Length * data2.Length / GeneralLength);
            // Критерий Пирсона Хи квадрат
            // 20181003
            float pirson = float.NaN;
                
            return new float[6]{ KruskalWallis, Ueng, Urus, RValda, lamda, pirson };
        }

        /// <summary>
        /// Сравнение гистограмм (> 7 количество интервалов)
        /// </summary>
        /// <param name="data1">Список элементов 1-й гистограммы</param>
        /// <param name="data2">Список элементов 2-й гистограммы</param>
        /// <param name="criterion">Вычисляемый критерий</param>
        /// <param name="A">Уровень значимости</param>
        /// <returns></returns>
        public Validity ComparisonGistData(List<elementGist> data1, List<elementGist> data2, 
                                           StatisticalCriterion criterion = StatisticalCriterion.Wilcoxon,
                                           float A = 0.05F)
        {
            if (data1.Count() != data2.Count() || data1.Count() < 7 || 
                (data1.Count() > 50 && criterion == StatisticalCriterion.Wilcoxon))
                return Validity.excluded;
            //Список рангов
            List<PointMassive> listRank = new List<PointMassive>();  
            // Определение различий
            for (int i = 0; i < data1.Count(); i++)
            {
                listRank.Add(new PointMassive() {  Value = data1[i].Y - data2[i].Y });
            }
            switch (criterion)
            {
                case StatisticalCriterion.Wilcoxon:
                    listRank.RemoveAll(p => p.Value == 0);
                    if (listRank.Count() == 0)
                        return Validity.excluded;
                    List<PointMassive> listRankOrdered =
                                              listRank.OrderBy(p => Math.Abs(p.Value)).ToList<PointMassive>();
                    //Определение рангов с учетом повторов значений
                    int tempRank = 0;
                    for (int j = 0; j < listRankOrdered.Count(); j++)
                    {
                        tempRank = j + 1;
                        int tCount = listRankOrdered.Where(p => p.Value == listRankOrdered[j].Value).Count();
                        for (int i = 0; i < tCount; i++)
                        {
                            listRankOrdered[j + i].Rank = tempRank + (tCount - 1) / 2;
                        }
                        j += (tCount - 1);
                    }
                    int Ri1 = 0, Ri2 = 0;
                    for (int i = 0; i < listRankOrdered.Count(); i++)
                    {
                        if (listRankOrdered[i].Value < 0)
                        {
                            Ri1 += listRankOrdered[i].Rank;
                        }
                        else if (listRankOrdered[i].Value > 0)
                        {
                            Ri2 += listRankOrdered[i].Rank;
                        }
                    }
                    float Ri = Ri1 < Ri2 ? Ri1 : Ri2;
                    float limit = 0;
                    try
                    {
                        limit = Stat_criterion.listLimitWilcoxon.Where(c => c.N == data1.Count() && c.A == A).
                                                                       First().Value;
                    }
                    catch (Exception)
                    {
                        return Validity.excluded;
                    }
                    return Ri < limit ? Validity.no : Validity.yes;

                case StatisticalCriterion.Chesnokov:
                    int valueZero = listRank.Where(v => v.Value == 0).Count();
                    int valueLess = listRank.Where(v => v.Value < 0).Count();
                    int valueMore = listRank.Where(v => v.Value > 0).Count();
                    //Объем связи: C = K0 / (K0 + K1)
                    float C = valueZero / (valueZero + valueLess);
                    // Дефект связи: Де = 1 — K0 / (K0 + K2)
                    float De = 1 - valueZero / (valueZero + valueMore);
                    //{С  ≤ 0,5; Де ≥ 0,5}
                    return C <= 0.5F && De >= 0.5F ? Validity.no : Validity.yes;

                case StatisticalCriterion.PearsonsChiSquare:
                    if (data1[0].Xmin != data2[0].Xmin)
                    {
                        return Validity.excluded;
                    }
                    float chi = 0;
                    for (int i = 0; i < data1.Count(); i++)
                    {
                        chi += (data1[i].Y - data2[i].Y) * (data1[i].Y - data2[i].Y) / data1[i].Y;
                    }
                    chi *= data1.Count();
                    return VerifyCriterionPirson(chi, data1.Count(), A);

                default:
                    break;
            }
            return Validity.excluded;
        }

        /// <summary>
        /// Проверка справедливости нулевой гипотезы по критерию Вальда — Вольфовица
        /// </summary>
        /// <param name="R">Расчетная величина критерия</param>
        /// <param name="n1">Размер первого ряда значений</param>
        /// <param name="n2">Размер второго ряда значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionR(float R, int n1, int n2, float al)
        {
            int a = 2 * n1 * n2;
            int b = n1 + n2;
            float MR = a / b + 1; // Мат.ожидание R-критерия
            float SR = (float)Math.Sqrt(a * (a - b) / (b * b * (b - 1))); // Среднее квадр-е отклонение R-критерия
            float Rverify = (MR - R - 0.5F) / SR;
            float Rlimit = 1;
            if (al == 0.05F) Rlimit = 1.96F; 
            else if (al == 0.01F) Rlimit = 2.58F; 
            else return Validity.excluded; 

            return R <= Rlimit ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка справедливости нулевой гипотезы по критерию Колмогорова — Смирнова
        /// </summary>
        /// <param name="Lambda">Расчетная величина критерия</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionK(float Lambda, float al)
        {
            float Rlimit = 1;
            if (al == 0.05F) Rlimit = 1.84F; 
            else if (al == 0.01F) Rlimit = 2.65F;
            else return Validity.excluded; 

            return Lambda <= Rlimit ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка справедливости нулевой гипотезы по U-критерию Манна — Уитни
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="n1">Размер первого ряда значений</param>
        /// <param name="n2">Размер второго ряда значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionU(float U, int n1, int n2, float al)
        {
            float MU = n1 * n2 / 2; //Мат.ожидание U-критерия
            float DU = n1 * n2 * (n1 + n2 + 1) / 12; //Дисперсия U-критерия
            float alRel = Stat_criterion.NormFunction.Where(n => n.X <= (al / 2)).Min(n => n.Y);
            float Umin = MU - alRel * (float)Math.Sqrt(DU);
            return U > Umin ? Validity.yes : Validity.no;
        }
        /// <summary>
        /// Проверка гипотезы о принадлежности выборки равномерному закону
        /// </summary>
        /// <param name="data">Ряд данных</param>
        /// <param name="criterion">Критерий проверки</param>
        /// <returns> Величины критериев [0] Шермана, [1] Кимбала, [2] Андерсона-Дарлинга, [3] Крамера-Мизеса-Смирнова, [4-7] Ньюмана-Бартона,
        ///          [8] Дудевича, [9] Пирсона </returns>
        public float[] VerifyUniformLaw(float[] data, StatisticalCriterion criterion)
        {
            float[] result = new float[10];
            int N = data.Length; //Объем выборки
            Array.Sort(data);
            float sum = 0;
            switch (criterion)
            {
                case StatisticalCriterion.Sherman:
                    sum = Math.Abs(data[0] - 1/(N + 1));
                    for (int i = 1; i < N; i++)
                    {
                        sum += Math.Abs(data[i] - data[i-1] - 1 / (N + 1));
                    }
                    result[0] = 0.5F * sum;
                    break;
                case StatisticalCriterion.Kimball:
                    sum = (data[0] - 1 / (N + 1)) * (data[0] - 1 / (N + 1));
                    for (int i = 1; i < N; i++)
                    {
                        sum += (float)Math.Pow(data[i] - data[i - 1] - 1 / (N + 1), 2);
                    }
                    result[1] = 0.5F * sum;
                    break;
                case StatisticalCriterion.AndersonDarling:
                    sum = -N;
                    for (int i = 1; i <= N; i++)
                    {
                        sum += (2*i-1) * (float)Math.Log(data[i - 1])/(2*N) + 
                               (1 - (2*i-1)/(2*N)) * (float)Math.Log(1 - data[i - 1]) ;
                    }
                    result[2] = -2F * sum;
                    break;
                case StatisticalCriterion.KramerMisesSmirnov:
                    sum = 1/(12*N);
                    for (int i = 1; i <= N; i++)
                    {
                        sum += (float)Math.Pow(data[i - 1] - (2 * i - 1) / (2 * N), 2);
                    }
                    result[3] = sum;
                    break;
                case StatisticalCriterion.NeymanBarton1polinom:
                    for (int i = 0; i < N; i++)
                    {
                        result[4] += 3.4641F * (data[i] - 0.5F);
                    }
                    break;
                case StatisticalCriterion.NeymanBarton2polinom:
                    for (int i = 0; i < N; i++)
                    {
                        result[5] += 2.2361F * (6 * (data[i] - 0.5F) * (data[i] - 0.5F) - 0.5F);
                    }
                    break;
                case StatisticalCriterion.NeymanBarton3polinom:
                    for (int i = 0; i < N; i++)
                    {
                        result[6] += 2.6458F * (20 * (float)Math.Pow(data[i] - 0.5F, 3) - 3 * (data[i] - 0.5F));
                    }
                    break;
                case StatisticalCriterion.NeymanBarton4polinom:
                    for (int i = 0; i < N; i++)
                    {
                        result[7] += 3 * (70 * (float)Math.Pow(data[i] - 0.5F, 4)
                                       - 15 * (float)Math.Pow(data[i] - 0.5F, 2) + 0.375F);
                    }
                    break;
                case StatisticalCriterion.DudevichVanDerMuelen:
                    int M = Stat_criterion.DudevichaValueM(N);
                    for (int i = 0; i < N; i++)
                    {
                        if (data[i + M >= N ? N - 1 : i + M] - data[i - M < 0 ? 0 : i - M] != 0)
                        sum += (float)Math.Log((N/(2*M))*(
                                data[i + M >= N ? N - 1 : i + M] 
                                - 
                                data[i - M < 0 ? 0 : i - M])); 
                    }
                    result[8] = sum / (-N);
                    break;
                case StatisticalCriterion.PearsonsChiSquare:
                    int n = СhoiceNumberIntervals(N);
                    float[] distribution = new float[n]; // частоты эмпирические
                    float frequency = N / n; // частоты теоретические 
                    List<elementGist> researchGist = Gist(data, n);
                    for (int i = 0; i < n; i++)
                    {
                        distribution[i] = N * researchGist[n].Y;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        result[9] += (frequency - distribution[j]) * (frequency - distribution[j]) / distribution[j];
                    }
                    break;
                default:
                    MessageBox.Show("Неправильный выбор критерия!","Ошибка...");
                    break;
            }
            return result;
        }
        /// <summary>
        /// Нармализация массива чисел
        /// </summary>
        /// <param name="data">Исходный массив данных</param>
        /// <returns></returns>
        public float[] NormalizedData(float[] data)
        {
            float[] result = new float[data.Length];
            float min = data.Min();
            float max = data.Max();

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (data[i] - min) / (max - min);
            }
            return result;
        }

        /// <summary>
        /// Проверка гипотезы о принадлежности выборки равномерному закону (Критерий Шермана)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionSherman(float value, int N, float al)
        {
            float valueMin = float.NaN;
            if (Stat_criterion.listLimitSherman.Where(v => v.A == al && v.N == N).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitSherman.Where(v => v.A == al && v.N == N).
                                                Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return value < valueMin ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка на проверку гипотезы о принадлежности выборки равномерному закону (Критерий Кимбела)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionKimbela(float value, int N, float al)
        {
            float valueMin = float.NaN;
            if (Stat_criterion.listLimitKimbela.Where(v => v.A == al && v.N == N).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitKimbela.Where(v => v.A == al && v.N == N).
                                                Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return value < valueMin ? Validity.yes : Validity.no;
        }
        //Кобзарь Л.И. - Прикладная математическая статистика, стр. 220
        //Лучше, если использовать модифицированную форму [226]
        /// <summary>
        /// Проверка на проверку гипотезы о принадлежности выборки равномерному закону (Критерий Андерсона–Дарлинга)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionAndersonDarling(float value, int N, float al)
        {
            //Модифицированная форма
            float valueMod = (N*N*value + N + 1) / (N*N + N + 1);
            float valueMin = float.NaN;
            if (Stat_criterion.listLimitAndersonDarling.Where(v => v.A == al).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitAndersonDarling.Where(v => v.A == al).
                                                Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return valueMod < valueMin ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка на проверку гипотезы о принадлежности выборки равномерному закону (Критерий Крамера–Мизеса–Смирнова)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionKramerMisesSmirnov(float value, int N, float al)
        {
            float valueMod = N < 40 ? (value - 0.4F / N + 0.6F / (N * N)) * (1 + 1 / N) : value;

            float valueMin = float.NaN;
            if (Stat_criterion.listLimitKramerMisesSmirnov.Where(v => v.A == al).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitKramerMisesSmirnov.Where(v => v.A == al).
                                                Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return valueMod < valueMin ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка на проверку гипотезы о принадлежности выборки равномерному закону (Критерий Неймана–Бартона)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionNeymanBarton(float[] value, int N, float al)
        {
            if (value.Length < 3) return Validity.excluded;

            float valueMin2 = float.NaN, valueMin3 = float.NaN, valueMin4 = float.NaN;
            if (Stat_criterion.listLimitNeymanBarton2.Where(v => v.A >= al && v.N >= N).Count() != 0)
            {
                valueMin2 = Stat_criterion.listLimitNeymanBarton2.Where(v => v.A >= al && v.N >= N).
                                                Select(v => v.Value).First();
                valueMin3 = Stat_criterion.listLimitNeymanBarton2.Where(v => v.A >= al && v.N >= N).
                                                Select(v => v.Value).First();
                valueMin4 = Stat_criterion.listLimitNeymanBarton2.Where(v => v.A >= al && v.N >= N).
                                                Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return value[0] < valueMin2 && value[1] < valueMin3 && value[2] < valueMin4 ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка на проверку гипотезы о принадлежности выборки равномерному закону (Критерий Дудевича-ван дер Мюлена)
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="N">Размер выборки значений</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionDudevichVanDerMuelen(float value, int N, float al)
        {
            float valueMin = float.NaN;
            if (Stat_criterion.listLimitDudevichVanDerMuelen.Where( v => v.A >= al && v.N >= N ).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitDudevichVanDerMuelen.Where(v => v.A >= al && v.N >= N).
                                                Select(v => v.Value).First();
            }
            else if (Stat_criterion.listLimitDudevichVanDerMuelen.Where(v => v.A >= al).Count() == 0)
            {
                valueMin = Stat_criterion.listLimitDudevichVanDerMuelen.Where(v => v.A >= al && v.N <= N).
                                                Select(v => v.Value).Min();
            }
            else
            {
                return Validity.excluded;
            }
            return value < valueMin ? Validity.yes : Validity.no;
        }

        /// <summary>
        /// Проверка по критерию согласия хи-квадрат Пирсона
        /// </summary>
        /// <param name="U">Расчетная величина критерия</param>
        /// <param name="K">Количество интервалов гистограммы</param>
        /// <param name="al">Уровень значимости</param>
        /// <returns></returns>
        public Validity VerifyCriterionPirson(float value, int K, float al)
        {
            float valueMin = float.NaN;
            int n = 2; //число параметров теоретического закона распределения
            int r = K - 1 - n; // число степеней свободы
            if (Stat_criterion.listLimitPirson.Where(v => v.A >= al && v.K <= r).Count() != 0)
            {
                valueMin = Stat_criterion.listLimitPirson.Where(v => v.A >= al && v.K <= r).Select(v => v.Value).First();
            }
            else
            {
                return Validity.excluded;
            }
            return value < valueMin ? Validity.yes : Validity.no;
        }
        /// <summary>
        /// Выбор числа интервалов гистограммы от объема выборки (Формула Старджесса)
        /// </summary>
        /// <param name="N">Объем выборки</param>
        /// <returns></returns>
        public int СhoiceNumberIntervals(int N)
        {
            // AN006266. С.А. Бардасов. Гистограммы. Критерии оптимальности
            // Среднеарифметическое значение от трех методов расчета (Стерджесс, Скотт, информационный критерий)
            List<NumIntervalsGistogram> recomendation = new List<NumIntervalsGistogram>()
                                               { new NumIntervalsGistogram() {Min =    0, Max =   30, Num = 4 },
                                                 new NumIntervalsGistogram() {Min =   31, Max =   60, Num = 5 },
                                                 new NumIntervalsGistogram() {Min =   61, Max =  100, Num = 6 },
                                                 new NumIntervalsGistogram() {Min =  101, Max =  200, Num = 7 },
                                                 new NumIntervalsGistogram() {Min =  201, Max =  500, Num = 8 },
                                                 new NumIntervalsGistogram() {Min =  501, Max = 1000, Num = 10 },
                                                 new NumIntervalsGistogram() {Min = 1001, Max = 5000, Num = 14 },
                                                 new NumIntervalsGistogram() {Min = 5001, Max = 10000, Num = 18 },
                                                 new NumIntervalsGistogram() {Min = 10001, Max = 50000, Num = 25 },
                                                 new NumIntervalsGistogram() {Min = 50001, Max = 100000, Num = 35 },
                                                 new NumIntervalsGistogram() {Min = 100001, Max = 200000, Num = 40 },
                                                 new NumIntervalsGistogram() {Min = 200001, Max = 500000, Num = 55 },
                                                 new NumIntervalsGistogram() {Min = 500001, Max = 1000000, Num = 70 },
                                                 new NumIntervalsGistogram() {Min = 1000001, Max = 5000000, Num = 85 },
                                                 new NumIntervalsGistogram() {Min = 5000001, Max = 10000000, Num = 100 },
                                                 new NumIntervalsGistogram() {Min = 10000001, Max = 50000000, Num = 170 },
                                                 new NumIntervalsGistogram() {Min = 50000001, Max = int.MaxValue, Num = 200 }
                                               };
            return recomendation.Where(n => n.Min <= N && n.Max >= N).Select(n => n.Num).First();
        }
    }
}
