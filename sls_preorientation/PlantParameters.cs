using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Параметры установки
    /// </summary>
    class PlantParameters
    {
        public string nameEquipment { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси X
        /// </summary>
        public float workXmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси X
        /// </summary>
        public float workXmax { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси Y
        /// </summary>
        public float workYmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси Y
        /// </summary>
        public float workYmax { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси Z
        /// </summary>
        public float workZmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси Z
        /// </summary>
        public float workZmax { get; set; }
        /// <summary>
        /// Ширина области построения
        /// </summary>
        public float workWidth { get; set; }
        /// <summary>
        /// Длина области построения
        /// </summary>
        public float workLength { get; set; }
        /// <summary>
        /// Высота области построения
        /// </summary>
        public float workHeight { get; set; }
        /// <summary>
        /// Безопасное расстояние до краев области построения
        /// </summary>
        public float safeDistanceBorder { get; set; }
        /// <summary>
        /// Безопасное расстояние между моделями
        /// </summary>
        public float safeDistanceBody { get; set; }
    }
}
