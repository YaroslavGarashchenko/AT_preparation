using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс описания элемента контура (прямого отрезка)
    /// </summary>
    public class Base_elementOfCurve
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int num { get; set;}

        /// <summary>
        /// Первая точка 
        /// </summary>
        public PointF point1 { get; set; }

        /// <summary>
        /// Вторая точка
        /// </summary>
        public PointF point2 { get; set; }

        /// <summary>
        /// Смежный элемент по первой точке
        /// </summary>
        public int numAdjacent1 { get; set; }

        /// <summary>
        /// Смежный элемент по второй точке
        /// </summary>
        public int numAdjacent2 { get; set; }

        /// <summary>
        /// Номер контура
        /// </summary>
        public int iContour { get; set; }

        /// <summary>
        /// Метка внутреннего/внешнего контура (True - внешний контур, Fаlse - внутренний контур)
        /// </summary>
        public bool insideOrOuterContour { get; set; }
    }
}
