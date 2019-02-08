using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс набора данных для статистического анализа
    /// </summary>
    class VarDatas
    {
        /// <summary>
        /// Метка выбора
        /// </summary>
        public bool SelectVar { get; set; }

        /// <summary>
        /// Порядковый номер данных
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Номер группы
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Название исследуемого признака
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Путь к исходному STL-файлу
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Вариант анализа данных
        /// </summary>
        public string SelectAnalyse { get; set; }

        /// <summary>
        /// Путь к файлу с результатами анализа
        /// </summary>
        public string ResultAnalyse { get; set; }

        /// <summary>
        /// Путь к файлу с исходными данными
        /// </summary>
        public string DataAnalyse { get; set; }

        /// <summary>
        /// Дата и время анализа
        /// </summary>
        public string DateTime { get; set; }

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
