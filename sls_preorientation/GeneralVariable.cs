using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    /// <summary>
    /// Величина точки массива
    /// </summary>
    class PointMassive
    {
        /// <summary>
        /// Номер группы (массива)
        /// </summary>
        public int NumGroup { get; set; }
        
        /// <summary>
        /// Ранг
        /// </summary>
        public int Rank { get; set; }
        
        /// <summary>
        /// Точка массива
        /// </summary>
        public Point3D Point { get; set; }
        
        /// <summary>
        /// Исследуемая величина
        /// </summary>
        public float Value { get; set; }
    }
}
