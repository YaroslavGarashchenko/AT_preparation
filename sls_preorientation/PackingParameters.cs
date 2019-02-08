using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Параметры размещения 3D-моделей изделий
    /// </summary>
    public class PackingParameters
    {
        /// <summary>
        /// Направление сортировки моделей
        /// </summary>
        public Sort SortDirect { get; set; }

        /// <summary>
        /// Сортировка моделей по геометрическим их характеристикам
        /// </summary>
        public SortModels SortCharactModels { get; set; }

        /// <summary>
        /// Режим размещения изделий в рабочем протсранстве
        /// </summary>
        public PlacementMode Mode { get; set; }

        /// <summary>
        /// Критерий оптимизации размещения изделий
        /// </summary>
        public PlacementCriterion Criterion { get; set; }

        /// <summary>
        /// Количество созадаваемых вариантов размещения для поиска рационального
        /// </summary>
        public int NumVariants { get; set; }

        /// <summary>
        /// Предельно допустимое количество попыток поиска свободного пространства
        /// </summary>
        public int NumTimesFreeSpace { get; set; }

        //Реализация генетического алгоритма
        /// <summary>
        /// Kроссинговер
        /// </summary>
        public double CrossoverRate { get; set; }
        /// <summary>
        /// Мутация
        /// </summary>
        public double MutationRate { get; set; }
        /// <summary>
        /// Размер популяции
        /// </summary>
        public int PopulationSize { get; set; }
        /// <summary>
        /// Количество популяций
        /// </summary>
        public int GenerationSize { get; set; }
        /// <summary>
        /// Размер генома
        /// </summary>
        public int GenomeSize { get; set; }
        /// <summary>
        /// Коэффициент усиления критерия оптимизации
        /// </summary>
        public float Magnitude{get; set;}
    }
}
