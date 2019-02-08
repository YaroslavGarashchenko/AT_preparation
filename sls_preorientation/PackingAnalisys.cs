using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    public class PackingAnalisys
    {
        /// <summary>
        /// Минимальная заполненность подпространства для принимания его как близкого к полностью заполненному
        /// </summary>
        public float LimitFullSubSpace { get; set; }

        /// <summary>
        /// Максимальная заполненность подпространства для принимания его как близкого к пустому
        /// </summary>
        public float LimitEmptySubSpace { get; set; }

        /// <summary>
        /// Количество подпространств по оси X
        /// </summary>
        public int NumXSubSpace { get; set; }

        /// <summary>
        /// Количество подпространств по оси Y
        /// </summary>
        public int NumYSubSpace { get; set; }

        /// <summary>
        /// Количество подпространств по оси Z
        /// </summary>
        public int NumZSubSpace { get; set; }

        /// <summary>
        /// Вид рассечения (Варианты)
        /// </summary>
        public TypeLayering[] Layering { get; set; }
        
        /// <summary>
        /// Минимальный шаг построения
        /// </summary>
        public float StepMin { get; set; }

        /// <summary>
        /// Максимальный шаг построения
        /// </summary>
        public float StepMax { get; set; }

        /// <summary>
        /// Допустимая (погрешность) величина отклонения от правильной формы
        /// </summary>
        public float ErrorMax { get; set; }

        /// <summary>
        /// Величина относительного усечения гистограммы распределения угла наклона нормали поверхности  
        /// </summary>
        public float ValueTruncatedDistribution { get; set; }
    }
}
