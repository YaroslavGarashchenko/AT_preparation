using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс описания контура сечения 3D-модели
    /// </summary>
    public class Base_curveContourSection
    {
        /// <summary>
        /// Высота слоя h
        /// </summary>
        public float H { get; set; }
        /// <summary>
        /// Координата сечения по оси Z
        /// </summary>
        public float Z { get; set; }
        /// <summary>
        /// Метка внутреннего/внешнего контура (True - внешний контур, Fаlse - внутренний контур)
        /// </summary>
        public object InsideOrOuterContour { get; set; }
        /// <summary>
        /// Список точек контура
        /// </summary>
        public List<Base_elementOfCurve> ListElement { get; set; }
    }

}
