using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// класс описания вокселя, элемента воксельной модели
    /// </summary>
    public class base_vox
    {
        /// <summary>
        /// порядковый номер вокселя
        /// </summary>
        public int Nom { get; set; }
        /// <summary>
        /// координата центра вокселя по оси Х
        /// </summary>
        private float xv;
        public float Xv
        {
            get { return xv; }
            set { xv = value; }
        }
        /// <summary>
        /// координата центра вокселя по оси Y
        /// </summary>
        private float yv;
        public float Yv
        {
            get { return yv; }
            set { yv = value; }
        }
        /// <summary>
        /// координата центра вокселя по оси Z
        /// </summary>
        private float zv;
        public float Zv
        {
            get { return zv; }
            set { zv = value; }
        }
        /// <summary>
        /// метка крайнего вокселя (значение true - крайний)
        /// </summary>
        public bool Lv { get; set; }
        //
        private bool lfull = false;
        /// <summary>
        /// метка вокселя принадлежащего модели (значение true - заполнен объемом модели)
        /// </summary>
        public bool Lfull
        {
            get { return lfull; }
            set { lfull = value; }
        }
        /// <summary>
        /// номер модели, к которой принадлежит воксель
        /// </summary>
        public int NomModel { get; set; }

        /// <summary>
        /// размер вокселя по координате X
        /// </summary>
        private float sizeX;
        public float SizeX
        {
            get {return sizeX;}
            set {sizeX = value;}
        }
        /// <summary>
        /// размер вокселя по координате Y
        /// </summary>
        private float sizeY;
        public float SizeY
        {
            get {return sizeY;}
            set {sizeY = value;}
        }
        /// <summary>
        /// размер вокселя по координате Z
        /// </summary>
        private float sizeZ;
        public float SizeZ
        {
            get {return sizeZ;}
            set {sizeZ = value;}
        }
        /// <summary>
        /// Определение объема вокселя
        /// </summary>
        /// <returns></returns>
        public float VolVox()
        {
            return SizeX * SizeY * SizeZ;
        }
        /// <summary>
        /// Строковое представление координат X, Y, Z
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Xv + " " + Yv + " " + Zv;
        }
    }
}
