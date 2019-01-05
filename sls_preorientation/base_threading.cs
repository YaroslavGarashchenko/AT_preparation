using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAddTech
{
    class Base_threading
    {
        /// <summary>
        /// Определение количества ядер процессора
        /// </summary>
        /// <returns></returns>
        public int CoreProsessor()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// Определение многоядерности процессора
        /// </summary>
        /// <returns>true - многоядерный, false - одноядерный</returns>
        public bool MultiCore()
        {
            return CoreProsessor() != 1;
        }
        
        /// <summary>
        /// Неработающий метод 
        /// </summary>
        /// <param name="masiveObj"></param>
        /// <param name="delProcessing"></param>
        /// <returns></returns>
        static object[] MultiProcessing(object[] masiveObj, Delegate delProcessing)
        {
            

            return new object[10];
        }
    }

}
