using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс модели (Списки STL, voxel и данные анализа)
    /// </summary>
    class base_model
    {
        /// <summary>
        /// Имя STL-файла модели
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список граней
        /// </summary>
        public List<Base_stl> Stl { get; set; }
        /// <summary>
        /// Список вокселей
        /// </summary>
        public List<base_vox> Voxels { get; set; }
        /// <summary>
        /// Общее количество вокселей при создании модели
        /// </summary>
        public int totalCountVoxels { get; set; }
        /// <summary>
        /// Размер вокселя по оси X
        /// </summary>
        public float sizeXvoxel { get; set; }
        /// <summary>
        /// Размер вокселя по оси Y
        /// </summary>
        public float sizeYvoxel { get; set; }
        /// <summary>
        /// Размер вокселя по оси Z
        /// </summary>
        public float sizeZvoxel { get; set; }
        /// <summary>
        /// Список вершин
        /// </summary>
        public List<Base_vertex> Vertexs { get; set; }
        /// <summary>
        /// Исходный размер модели по оси X
        /// </summary>
        public float sizeX { get; set; }
        /// <summary>
        /// Исходный размер модели по оси Y
        /// </summary>
        public float sizeY { get; set; }
        /// <summary>
        /// Исходный размер модели по оси Z
        /// </summary>
        public float sizeZ { get; set; }
        /// <summary>
        /// Исходное расположение модели по оси X (миним.значение)
        /// </summary>
        public float coordinateX { get; set; }
        /// <summary>
        /// Исходное расположение модели по оси Y (миним.значение)
        /// </summary>
        public float coordinateY { get; set; }
        /// <summary>
        /// Исходное расположение модели по оси Z (миним.значение)
        /// </summary>
        public float coordinateZ { get; set; }
        /// <summary>
        /// Объем модели
        /// </summary>
        public float Volumе { get; set; }
        /// <summary>
        /// Данные расчетов
        /// </summary>
        public string information { get; set; }
        //Данные по рациональной ориентации
        //
        //Данные по рационалной декомпозиции
        //
        //Данные по рациональной ориентации и расположению для создания проекта загрузки
        /// <summary>
        /// Угол поврота вокруг оси X (град.)
        /// </summary>
        public float angleX { get; set; }
        /// <summary>
        /// Угол поврота вокруг оси Y (град.)
        /// </summary>
        public float angleY { get; set; }
        /// <summary>
        /// Перемещение по оси X
        /// </summary>
        public float transferX { get; set; }
        /// <summary>
        /// Перемещение по оси Y
        /// </summary>
        public float transferY { get; set; }
        /// <summary>
        /// Перемещение по оси Z
        /// </summary>
        public float transferZ { get; set; }
    }
}
