using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    /// <summary>
    /// Класс набора данных для статистического анализа
    /// </summary>
    public class VarDatas
    {
        /// <summary>
        /// Метка выбора
        /// </summary>
        public bool SelectVar { get; set; }

        /// <summary>
        /// Порядковый номер данных
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Номер группы
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// Название исследуемого признака
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь к исходному STL-файлу
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Вариант анализа данных
        /// </summary>
        public string SelectAnalyse { get; set; }

        /// <summary>
        /// Результаты анализа
        /// </summary>
        public string ResultAnalyse { get; set; }

        /// <summary>
        /// Массив исследуемого признака
        /// </summary>
        public float[] ResearchMassive;

        /// <summary>
        /// Массив координат Z слоев
        /// </summary>
        public float[] ResearchMassiveZ;

        /// <summary>
        /// Стат характеристики: 0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
        /// 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
        /// </summary>
        public float[] ResultStatParLayer;

        /// <summary>
        /// Ряд данных - Плотность распределения
        /// </summary>
        public Series SeriesDensity;

        /// <summary>
        /// Ряд данных - Интегральная функция
        /// </summary>
        public Series SeriesIntegralFunction;

        /// <summary>
        /// Ряд данных - Перечисление исследуемого признака
        /// </summary>
        public Series SeriesData;

        /// <summary>
        /// Ряд данных - Функция зависимости исследуемого признака от координаты по оси Z
        /// </summary>
        public Series SeriesFunctionZ;

        /// <summary>
        /// Дата и время анализа
        /// </summary>
        public DateTime DateTimeCreation { get; set; }

        /// <summary>
        /// История
        /// </summary>
        public string History { get; set; }
    }
}
