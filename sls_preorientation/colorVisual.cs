using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс для цветовой визуализации
    /// </summary>
    public class colorVisual
    {
        /// <summary>
        /// Номер интервала
        /// </summary>
        public int Nom { get; set; }
        /// <summary>
        /// Начало интервала
        /// </summary>
        public float Begin { get; set; }
        /// <summary>
        /// R компонента цвета
        /// </summary>
        public byte R { get; set; }
        /// <summary>
        /// G компонента цвета
        /// </summary>
        public byte G { get; set; }
        /// <summary>
        /// B компонента цвета
        /// </summary>
        public byte B { get; set; }

    }
}
