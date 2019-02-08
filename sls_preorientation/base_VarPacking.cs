using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс варианта размещения моделей в рабочем пространстве установки
    /// </summary>
    public class Base_VarPacking
    {
        /// <summary>
        /// Размещенные модели
        /// </summary>
        public List<Base_model> Models { get; set; }

        /// <summary>
        /// Критерий оптимизации
        /// </summary>
        public PlacementCriterion Criterion { get; set; }

        /// <summary>
        /// Эквивалент критерия для его оптимизации по минимальной величине
        /// </summary>
        public float ValueCriterion { get; set; }
    }
}
