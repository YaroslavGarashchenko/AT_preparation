using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс варианта рассчета
    /// </summary>
    class VarModels
    {
        /// <summary>
        /// Номер варианта
        /// </summary>
        public string Variant { get; set; }
        /// <summary>
        /// Номер группы
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// История
        /// </summary>
        public string History { get; set; }
    }
}
