using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreAddTech
{
    class Stat_analysis
    {
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
                    stat[11] = (DataArray[DataArray.Length / 2] + DataArray[DataArray.Length / 2 + 1])/2; // медиана
                else
                    stat[11] = DataArray[(int)Math.Truncate((decimal)DataArray.Length / 2)];
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //
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
                    stat[10] = (gist[i].Xmin + gist[i].Xmax)/2;
                }
            }
            //
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
            //
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
            //
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
            //
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
            //
            return gist;
        }
    }
}
