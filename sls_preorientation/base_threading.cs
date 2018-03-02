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
    }
}
