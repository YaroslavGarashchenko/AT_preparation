using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace PreAddTech
{
    /// <summary>
    /// Класс результатов анализа фрактальной размерности
    /// </summary>
    public class Base_fract_anal
    {
        /// <summary>
        /// Метод определения фрактальной размерности
        /// </summary>
        public FractalMethod FractalMethod { get; set; }

        /// <summary>
        /// listE.Count - Количество элементов контура
        /// </summary>
        public int CountElements { get; set; }

        /// <summary>
        /// Количество контуров
        /// </summary>
        public int CountContour { get; set; }

        /// <summary>
        /// Первоначальный радиус (размер клетки)
        /// </summary>
        public float Mstart { get; set; }

        /// <summary>
        /// Список фрактальных размерностей для метода масштабов
        /// </summary>
        public List<float> FractalDimension { get; set; }

        /// <summary>
        /// Список фрактальных размерностей для клеточного метода
        /// </summary>
        public List<float> FractalDimensionSquare { get; set; }

        /// <summary>
        /// Список мер
        /// </summary>
        public List<float> Size { get; set; }

        /// <summary>
        /// Список мер для клеточного метода
        /// </summary>
        public List<float> SizeSquare { get; set; }

        /// <summary>
        /// Список длин контура
        /// </summary>
        public List<float> Length { get; set; }

        /// <summary>
        /// Список количества клеток покрывающих контур
        /// </summary>
        public List<int> CountSquare { get; set; }

        /// <summary>
        /// Список центров радиусов формируемых при измерении длины контура
        /// </summary>
        public List<FractalMeraR> PointR { get; set; }

        /// <summary>
        /// Список координат клеток
        /// </summary>
        public List<FractalMeraS> PointS { get; set; }

        /// <summary>
        /// Количество удаленных записей при определнии среднего значения
        /// </summary>
        int intDelete;

        /// <summary>
        /// Средняя величина фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public float Mean()
        {
            List<float> fractalDimensionCopy = new List<float>();
            try
            {
                if (FractalDimension == null || FractalDimension.Count == 0)
                { return float.NaN; }
                
                fractalDimensionCopy.AddRange(FractalDimension);
                intDelete = fractalDimensionCopy.RemoveAll(IfLessThenOne);
            }
            catch (Exception e)
            { MessageBox.Show(e.Message);}

            if (fractalDimensionCopy.Count != 0)
            { return fractalDimensionCopy.Average(); }
            else
            { return float.NaN; }
        }

        /// <summary>
        /// Средняя величина фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public float Mean(List<float> FDimension)
        {
            if (FDimension == null || FDimension.Count == 0)
            { return float.NaN; }

            return FDimension.Average();
        }

        /// <summary>
        /// Фрактальная размерность для всей области скейлинга
        /// </summary>
        /// <returns></returns>
        public float FractalSizeGeneral()
        {
            if (Size == null || Size.Count == 0 || Length == null || Length.Count == 0)
            {
                return float.NaN;
            }
                return (float)((Math.Log(Length[0]) - Math.Log(Length[Length.Count - 1])) /
                               (Math.Log(Size[Size.Count - 1] / Size[0])));
        }

        /// <summary>
        /// Условие меньше единицы (делегат для удаления из списка)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IfLessThenOne (float value)
        {
            return value < 1F;
        }

        string text;

        /// <summary>
        /// Вывод данных по анализу фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (FractalDimension == null || FractalDimension.Count == 0)
            {
                return "Нет данных!";
            }
            text  = "Информация по текущему сечению и результатам анализа фрактальной размерности:" + "\n";
            text += "Количество элементов в слое: " + CountElements + ";\n";
            text += "Количество контуров в слое: " + CountContour + ";\n";
            text += "Первоначальный радиус (мера): " + Mstart + " мм;\n";
            text += "Список фрактальных размерностей: " + "\n";
            for (int i = 0; i < FractalDimension.Count; i++)
            {
                text += "\t" + FractalDimension[i] + "\n";
            }
            text += "Среднеарифметическая величина фрактальной размерности: " + Mean() + " ;\n";
            text += "Фрактальная размерность по всей области скейлинга (по предельным значениям): " + FractalSizeGeneral() + " ;\n";
            text += "Минимальная величина фрактальной размерности: " + FractalDimension.Min() + " ;\n";
            text += "Максимальная величина фрактальной размерности: " + FractalDimension.Max() + " ;\n";
            text += "Список мер: " + "\n";
            for (int i = 0; i < Size.Count; i++)
            {
                text += "\t" + Size[i] + "\n";
            }
            text += "Список длин контура: " + "\n";
            for (int i = 0; i < Length.Count; i++)
            {
                text += "\t" + Length[i] + "\n";
            }

            return text;
        }

        /// <summary>
        /// Вывод данных по анализу фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public string ToString(List<float> FDimension)
        {
            if (FDimension == null || FDimension.Count == 0)
            {
                return "Нет данных!";
            }
            text = "Информация по текущему сечению и результатам анализа фрактальной размерности:" + "\n";
            text += "Количество элементов в слое: " + CountElements + ";\n";
            text += "Количество контуров в слое: " + CountContour + ";\n";
            text += "Первоначальный радиус (мера): " + Mstart + " мм;\n";
            text += "Список фрактальных размерностей: " + "\n";
            for (int i = 0; i < FDimension.Count; i++)
            {
                text += "\t" + FDimension[i] + "\n";
            }
            text += "Среднеарифметическая величина фрактальной размерности: " + Mean(FDimension) + " ;\n";
            text += "Минимальная величина фрактальной размерности: " + FDimension.Min() + " ;\n";
            text += "Максимальная величина фрактальной размерности: " + FDimension.Max() + " ;\n";
            text += "Список мер: " + "\n";
            for (int i = 0; i < SizeSquare.Count; i++)
            {
                text += "\t" + SizeSquare[i] + "\n";
            }
            text += "Список количества клеток покрывающих контур: " + "\n";
            for (int i = 0; i < CountSquare.Count; i++)
            {
                text += "\t" + CountSquare[i] + "\n";
            }

            return text;
        }

        /// <summary>
        /// Полный вывод данных по анализу фрактальной размерности
        /// </summary>
        /// <returns></returns>
        public string AllToString()
        {
            if (FractalDimension == null || FractalDimension.Count == 0)
            {
                return "Нет данных!";
            }
            text = "Информация по текущему сечению и результатам анализа фрактальной размерности:" + "\n";
            text += "Количество элементов в слое: " + CountElements + ";\n";
            text += "Количество контуров в слое: " + CountContour + ";\n";
            text += "Первоначальный радиус (мера): " + Mstart + " мм;\n";
            text += "Список фрактальных размерностей: " + "\n";
            for (int i = 0; i < FractalDimension.Count; i++)
            {
                text += "\t" + FractalDimension[i] + "\n";
            }
            text += "Среднеарифметическая величина фрактальной размерности: " + Mean() + " ;\n";
            text += "Фрактальная размерность по всей области скейлинга (по предельным значениям): " + FractalSizeGeneral() + " ;\n";
            text += "Минимальная величина фрактальной размерности: " + FractalDimension.Min() + " ;\n";
            text += "Максимальная величина фрактальной размерности: " + FractalDimension.Max() + " ;\n";
            text += "Количество удаленных записей при определении среднего значения: " + intDelete + ";\n";
            text += "Список мер: " + "\n";
            for (int i = 0; i < Size.Count; i++)
            {
                text += "\t" + Size[i] + "\n";
            }
            text += "Список замеров длины контура: " + "\n";
            for (int i = 0; i < Length.Count; i++)
            {
                text += "\t" + Length[i] + "\n";
            }
            text += "Список центров радиусов, формируемых при измерении длины контура: " + "\n";
            for (int i = 0; i < PointR.Count; i++)
            {
                text += "Номер меры: " + PointR[i].nomMeasure + ";  " +
                        "Номер изм.: " + PointR[i].nomIteration + ";  " +
                        "Мера: " + PointR[i].R + ";  " +
                        "Координаты центра:  \t" + PointR[i].pointCentre.X.ToString("##0.000") + ";  \t" +
                                                  PointR[i].pointCentre.Y.ToString("##0.000") + ". \n";
            }
            text += "\n\n\n";

            text += "Список фрактальных размерностей (клеточный метод): " + "\n";
            for (int i = 0; i < FractalDimensionSquare.Count; i++)
            {
                text += "\t" + FractalDimensionSquare[i] + "\n";
            }
            text += "Среднеарифметическая величина фрактальной размерности: " + Mean(FractalDimensionSquare) + " ;\n";
            text += "Минимальная величина фрактальной размерности: " + FractalDimensionSquare.Min() + " ;\n";
            text += "Максимальная величина фрактальной размерности: " + FractalDimensionSquare.Max() + " ;\n";
            text += "Список мер (клеточный метод): " + "\n";
            for (int i = 0; i < SizeSquare.Count; i++)
            {
                text += "\t" + SizeSquare[i] + "\n";
            }
            text += "Список замеров длины контура: " + "\n";
            for (int i = 0; i < CountSquare.Count; i++)
            {
                text += "\t" + CountSquare[i] + "\n";
            }
            text += "Список центров радиусов, формируемых при измерении длины контура: " + "\n";
            for (int i = 0; i < PointS.Count; i++)
            {
                text += "Номер меры: " + PointS[i].nomMeasure + ";  " +
                        "Номер изм.: " + PointS[i].nomIteration + ";  " +
                        "Мера: " + PointS[i].R + ";  " +
                        "Координаты двух точек клетки:  \t" + PointS[i].S[0].X.ToString("##0.000") + ";  \t" +
                                                              PointS[i].S[0].Y.ToString("##0.000") + ";  \t" +
                                                              PointS[i].S[1].X.ToString("##0.000") + ";  \t" +
                                                              PointS[i].S[1].Y.ToString("##0.000") + ". \n";
            }

            return text;
        }

    }
    
    /// <summary>
    /// Класс задания окружности для визуализации
    /// </summary>
    public class FractalMeraR
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

    /// <summary>
    /// Класс задания окружности для визуализации
    /// </summary>
    public class FractalMeraS
    {
        /// <summary>
        /// Размер клетки
        /// </summary>
        public float R;

        /// <summary>
        /// Радиус окружности
        /// </summary>
        public PointF[] S;

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
