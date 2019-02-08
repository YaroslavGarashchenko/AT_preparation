using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Параметры установки
    /// </summary>
    public class PlantParameters
    {
        public string NameEquipment { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси X
        /// </summary>
        public float WorkXmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси X
        /// </summary>
        public float WorkXmax { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси Y
        /// </summary>
        public float WorkYmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси Y
        /// </summary>
        public float WorkYmax { get; set; }
        /// <summary>
        /// Минимальная координата рабочей области построения по оси Z
        /// </summary>
        public float WorkZmin { get; set; }
        /// <summary>
        /// Максимальная координата рабочей области построения по оси Z
        /// </summary>
        public float WorkZmax { get; set; }
        /// <summary>
        /// Ширина области построения
        /// </summary>
        public float WorkWidth { get; set; }
        /// <summary>
        /// Длина области построения
        /// </summary>
        public float WorkLength { get; set; }
        /// <summary>
        /// Высота области построения
        /// </summary>
        public float WorkHeight { get; set; }
        /// <summary>
        /// Безопасное расстояние до краев области построения
        /// </summary>
        public float SafeDistanceBorder { get; set; }
        /// <summary>
        /// Безопасное расстояние между моделями
        /// </summary>
        public float SafeDistanceBody { get; set; }
    }
}
