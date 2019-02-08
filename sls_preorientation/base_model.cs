using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс модели (Списки STL, voxel и данные анализа)
    /// </summary>
    public class Base_model
    {
        /// <summary>
        /// Порядковый номер для размещения в рабочем пространстве
        /// </summary>
        public int Num { get; set; }

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
        public List<Base_vox> Voxels { get; set; }

        /// <summary>
        /// Общее количество вокселей при создании модели
        /// </summary>
        public int TotalCountVoxels { get; set; }

        /// <summary>
        /// Размер вокселя по оси X
        /// </summary>
        public float SizeXvoxel { get; set; }

        /// <summary>
        /// Размер вокселя по оси Y
        /// </summary>
        public float SizeYvoxel { get; set; }

        /// <summary>
        /// Размер вокселя по оси Z
        /// </summary>
        public float SizeZvoxel { get; set; }

        /// <summary>
        /// Список вершин
        /// </summary>
        public List<Base_vertex> Vertexs { get; set; }

        /// <summary>
        /// Исходный размер модели по оси X
        /// </summary>
        public float SizeX { get; set; }

        /// <summary>
        /// Исходный размер модели по оси Y
        /// </summary>
        public float SizeY { get; set; }

        /// <summary>
        /// Исходный размер модели по оси Z
        /// </summary>
        public float SizeZ { get; set; }

        /// <summary>
        /// Исходное расположение модели по оси X (миним.значение)
        /// </summary>
        public float CoordinateX { get; set; }

        /// <summary>
        /// Исходное расположение модели по оси Y (миним.значение)
        /// </summary>
        public float CoordinateY { get; set; }

        /// <summary>
        /// Исходное расположение модели по оси Z (миним.значение)
        /// </summary>
        public float CoordinateZ { get; set; }

        /// <summary>
        /// Объем модели
        /// </summary>
        public float Volumе { get; set; }

        /// <summary>
        /// Данные расчетов и по декомпозиции
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Потребность в структурно обратимой декомпозиции модели
        /// </summary>
        public bool Decompozition { get; set; }

        //Данные по рациональной ориентации и расположению для создания проекта загрузки
        /// <summary>
        /// Угол поворота вокруг оси X (град.)
        /// </summary>
        public float AngleX { get; set; }

        /// <summary>
        /// Угол поворота вокруг оси Y (град.)
        /// </summary>
        public float AngleY { get; set; }

        /// <summary>
        /// Перемещение по оси X
        /// </summary>
        public float TransferX { get; set; }

        /// <summary>
        /// Перемещение по оси Y
        /// </summary>
        public float TransferY { get; set; }

        /// <summary>
        /// Перемещение по оси Z
        /// </summary>
        public float TransferZ { get; set; }

        /// <summary>
        /// Поворот вокруг оси X
        /// </summary>
        public float RotationX { get; set; }

        /// <summary>
        /// Поворот вокруг оси Y
        /// </summary>
        public float RotationY { get; set; }

        /// <summary>
        /// Поворот вокруг оси Z
        /// </summary>
        public float RotationZ { get; set; }

        /// <summary>
        /// Метка размещения в рабочем пространстве
        /// </summary>
        public bool WasPlaced { get; set; }
    }
}
