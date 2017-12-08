using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace PreAddTech
{
    /// <summary>
    /// Класс результатов анализа фрактальной размерности
    /// </summary>
    public class base_fract_anal
    {
        /// <summary>
        /// listE.Count - Количество элементов
        /// </summary>
        public int countElements { get; set; }

        /// <summary>
        /// Количество контуров
        /// </summary>
        public int countContour { get; set; }

        /// <summary>
        /// Первоначальный радиус (мера)
        /// </summary>
        public float Mstart { get; set; }

        /// <summary>
        /// Список фрактальных размерностей
        /// </summary>
        public List<float> fractalDimension { get; set; }

        /// <summary>
        /// Список мер
        /// </summary>
        public List<float> size { get; set; }

        /// <summary>
        /// Список длин контура
        /// </summary>
        public List<float> length { get; set; }

        /// <summary>
        /// Список центров радиусов формируемых при измерении длины контура
        /// </summary>
        public List<fractalMeraR> pointR { get; set; }

        /// <summary>
        /// Средняя величина фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public float mean()
        {
            return fractalDimension.Average();
        }

        string text;

        /// <summary>
        /// Вывод данных по анализу фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            text  = "Информация по текущему сечению и результатам анализа фрактальной размерности:" + "\n";
            text += "Количество элементов в слое: " + countElements + ";\n";
            text += "Количество контуров в слое: " + countContour + ";\n";
            text += "Первоначальный радиус (мера): " + Mstart + " мм;\n";
            text += "Список фрактальных размерностей: " + "\n";
            for (int i = 0; i < fractalDimension.Count; i++)
            {
                text += "\t" + fractalDimension[i] + "\n";
            }
            text += "Среднеарифметическая величина фрактальной размерности: " + mean() + " ;\n";
            text += "Список мер: " + "\n";
            for (int i = 0; i < size.Count; i++)
            {
                text += "\t" + size[i] + "\n";
            }
            text += "Список длин контура: " + "\n";
            for (int i = 0; i < length.Count; i++)
            {
                text += "\t" + length[i] + "\n";
            }
            text += "Список центров радиусов, формируемых при измерении длины контура: " + "\n";
            for (int i = 0; i < pointR.Count; i++)
            {
                text += "Номер меры: " + pointR[i].nomMeasure +   ";  " +
                        "Номер изм.: " + pointR[i].nomIteration + ";  " +
                        "Мера: " + pointR[i].R +                  ";  " +
                        "Координаты центра:  \t" + pointR[i].pointCentre.X.ToString("##0.000") + ";  \t" + 
                                                  pointR[i].pointCentre.Y.ToString("##0.000") + ". \n";
            }
            return text;
        }
    }
    /// <summary>
    /// Класс задания окружности для визуализации
    /// </summary>
    public class fractalMeraR
    {
        /// <summary>
        /// Радиус окружности
        /// </summary>
        public float R;
        
        /// <summary>
        /// Точка центра окружности
        /// </summary>
        public PointF pointCentre;

        /// <summary>
        /// Номер итерации
        /// </summary>
        public int nomIteration;

        /// <summary>
        /// Номер
        /// </summary>
        public int nomMeasure;
    }
}
