using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс описания элемента контура (прямого отрезка)
    /// </summary>
    public class base_elementOfCurve
    {
        /// <summary>
        /// Определение первой точки 
        /// </summary>
        public PointF point1 { get; set; }
        /// <summary>
        /// Определение второй точки
        /// </summary>
        public PointF point2 { get; set; }
        /// <summary>
        /// Метка (для процедур перебора)
        /// </summary>
        public bool mark { get; set; }
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
