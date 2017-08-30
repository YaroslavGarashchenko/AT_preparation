using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Drawing;

namespace PreAddTech
{
    public class MyProcedures
    {
        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <param name="double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3"></param>
        /// <param name="Площадь треугольника, мм2"></param>
        public double Str(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            double l21, l32, l13, p123; //длины и полупериметр треугольника
            l21 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            l32 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2) + (z3 - z2) * (z3 - z2));
            l13 = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3) + (z1 - z3) * (z1 - z3));
            p123 = (l13 + l21 + l32) / 2;
            return Math.Sqrt(p123 * (p123 - l13) * (p123 - l21) * (p123 - l32));
        }
        /// <summary>
        /// Расчет площади проекции треугольника на плоскость YZ
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <returns></returns>
        public double StrX(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            double l21, l32, l13, p123; //длины и полупериметр треугольника
            l21 = Math.Sqrt((y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            l32 = Math.Sqrt((y3 - y2) * (y3 - y2) + (z3 - z2) * (z3 - z2));
            l13 = Math.Sqrt((y1 - y3) * (y1 - y3) + (z1 - z3) * (z1 - z3));
            p123 = (l13 + l21 + l32) / 2;
            return Math.Sqrt(p123 * (p123 - l13) * (p123 - l21) * (p123 - l32));
        }
        /// <summary>
        /// Расчет площади проекции треугольника на плоскость XZ
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <returns></returns>
        public double StrY(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            double l21, l32, l13, p123; //длины и полупериметр треугольника
            l21 = Math.Sqrt((x2 - x1) * (x2 - x1) + (z2 - z1) * (z2 - z1));
            l32 = Math.Sqrt((x3 - x2) * (x3 - x2) + (z3 - z2) * (z3 - z2));
            l13 = Math.Sqrt((x1 - x3) * (x1 - x3) + (z1 - z3) * (z1 - z3));
            p123 = (l13 + l21 + l32) / 2;
            return Math.Sqrt(p123 * (p123 - l13) * (p123 - l21) * (p123 - l32));
        }
        /// <summary>
        /// Расчет площади проекции треугольника на плоскость XY
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <returns></returns>
        public double StrZ(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            double l21, l32, l13, p123; //длины и полупериметр треугольника
            l21 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            l32 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            l13 = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
            p123 = (l13 + l21 + l32) / 2;
            return Math.Sqrt(p123 * (p123 - l13) * (p123 - l21) * (p123 - l32));
        }
        /// <summary>
        /// Процедура удаления мантиссы из числа
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="z3"></param>
        /// <param name="xn"></param>
        /// <param name="yn"></param>
        /// <param name="zn"></param>
        /// <returns></returns>
        public string[] DeleteFraction(string x1, string y1, string z1, string x2, string y2, string z2,
                                        string x3, string y3, string z3, string xn, string yn, string zn)
        {
            string[] koord = new string[12] { x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn };
            if ((x1.IndexOf("e") != -1) || (x1.IndexOf("E") != -1))
            {
                int i = 0;
                string[] p1;
                foreach (string temp in koord)
                {
                    p1 = temp.Split(new Char[] { 'e', 'E' });
                    koord[i] = (double.Parse(p1[0]) * Math.Pow(10, int.Parse(p1[1]))).ToString();
                    ++i;
                }
            }
            return koord;
        }
        /// <summary>
        /// угол между нормалями смежных треугольников (cos fi)
        /// </summary>
        /// <param name="Item1"></param>
        /// <param name="Item2"></param>
        /// <returns></returns>
        public double AngleBetweenNormals(base_stl Item1, base_stl Item2)
        {
            double A1, B1, C1, A2, B2, C2;
            A1 = NormABC(Item1)[0];
            B1 = NormABC(Item1)[1];
            C1 = NormABC(Item1)[2];
            A2 = NormABC(Item2)[0];
            B2 = NormABC(Item2)[1];
            C2 = NormABC(Item2)[2];
            //cos fi
            double fi = (A1*A2 + B1*B2 + C1*C2)/(Math.Sqrt((A1 * A1 + B1 * B1 + C1 * C1) * (A2 * A2 + B2 * B2 + C2 * C2)));
            return fi;
        }
        /// <summary>
        /// Нормаль треугольника
        /// </summary>
        /// <param name="Item1"></param>
        /// <returns></returns>
        double[] NormABC(base_stl Item1)
        {
            double[] normABC = new double[3];
            normABC[0] = (Item1.Y2 - Item1.Y1)*(Item1.Z3 - Item1.Z1) - (Item1.Y3 - Item1.Y1) * (Item1.Z2 - Item1.Z1);
            normABC[1] = -1 * (Item1.X2 - Item1.X1) * (Item1.Z3 - Item1.Z1) - (Item1.X3 - Item1.X1) * (Item1.Z2 - Item1.Z1);
            normABC[2] = (Item1.X2 - Item1.X1) * (Item1.Y3 - Item1.Y1) - (Item1.X3 - Item1.X1) * (Item1.Y2 - Item1.Y1);
            return normABC;
        }
        /// <summary>
        /// Проверка смежности треугольных граней
        /// </summary>
        public bool contiguity(base_stl Item1, base_stl Item2)
        {
            //Количество совпадающих вершин
            int vertexGeneral = 0;
            if ((Item1.X1 == Item2.X1 && Item1.Y1 == Item2.Y1 && Item1.Z1 == Item2.Z1) ||
                (Item1.X1 == Item2.X2 && Item1.Y1 == Item2.Y2 && Item1.Z1 == Item2.Z2) ||
                (Item1.X1 == Item2.X3 && Item1.Y1 == Item2.Y3 && Item1.Z1 == Item2.Z3))
            { vertexGeneral++; }
            if ((Item1.X2 == Item2.X1 && Item1.Y2 == Item2.Y1 && Item1.Z2 == Item2.Z1) ||
                (Item1.X2 == Item2.X2 && Item1.Y2 == Item2.Y2 && Item1.Z2 == Item2.Z2) ||
                (Item1.X2 == Item2.X3 && Item1.Y2 == Item2.Y3 && Item1.Z2 == Item2.Z3))
            { vertexGeneral++; }
            if ((Item1.X3 == Item2.X1 && Item1.Y3 == Item2.Y1 && Item1.Z3 == Item2.Z1) ||
                (Item1.X3 == Item2.X2 && Item1.Y3 == Item2.Y2 && Item1.Z3 == Item2.Z2) ||
                (Item1.X3 == Item2.X3 && Item1.Y3 == Item2.Y3 && Item1.Z3 == Item2.Z3))
            { vertexGeneral++; }

            return vertexGeneral == 2 ? true:false ;
        }
        /// <summary>
        /// Количество смежных треугольных граней по вершинам (проверка рациональности модели)
        /// </summary>
        public int contiguityVertex(base_stl Item1, base_stl Item2)
        {
            //Количество совпадающих вершин
            int vertexGeneral = 0;
            if ((Item1.X1 == Item2.X1 && Item1.Y1 == Item2.Y1 && Item1.Z1 == Item2.Z1) ||
                (Item1.X1 == Item2.X2 && Item1.Y1 == Item2.Y2 && Item1.Z1 == Item2.Z2) ||
                (Item1.X1 == Item2.X3 && Item1.Y1 == Item2.Y3 && Item1.Z1 == Item2.Z3))
            { vertexGeneral++; }
            if ((Item1.X2 == Item2.X1 && Item1.Y2 == Item2.Y1 && Item1.Z2 == Item2.Z1) ||
                (Item1.X2 == Item2.X2 && Item1.Y2 == Item2.Y2 && Item1.Z2 == Item2.Z2) ||
                (Item1.X2 == Item2.X3 && Item1.Y2 == Item2.Y3 && Item1.Z2 == Item2.Z3))
            { vertexGeneral++; }
            if ((Item1.X3 == Item2.X1 && Item1.Y3 == Item2.Y1 && Item1.Z3 == Item2.Z1) ||
                (Item1.X3 == Item2.X2 && Item1.Y3 == Item2.Y2 && Item1.Z3 == Item2.Z2) ||
                (Item1.X3 == Item2.X3 && Item1.Y3 == Item2.Y3 && Item1.Z3 == Item2.Z3))
            { vertexGeneral++; }

            return vertexGeneral;
        }

        /// <summary>
        /// Процедура перехода между аддитивными цветовыми моделями (RGB->HSV)
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public float[] convertRGBHSV (byte R, byte G, byte B)
        {
            float[] HSV = new float[3];
            return HSV;
        }
        /// <summary>
        /// Процедура перевода данных из STL файла в список List<base_stl>
        /// </summary>
        /// <param name="puthFileSTL">Путь к STL файлу</param>
        /// <returns></returns>
        public List<base_stl> translationSTLtoList(string puthFileSTL)
        {
            List<base_stl> ListStl = new List<base_stl>();
            //
            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(puthFileSTL, FileMode.Open)))
                {
                    ushort AddAttr;
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        byte[] header = br.ReadBytes(80);
                        uint numTr = br.ReadUInt32();
                        for (uint ui = 0; ui < numTr; ui++)
                        {
                            Application.DoEvents();
                            base_stl TrStl = new base_stl();
                            // нормальный вектор
                            TrStl.XN = br.ReadSingle(); TrStl.YN = br.ReadSingle(); TrStl.ZN = br.ReadSingle();
                            // 1 вершина
                            TrStl.X1 = br.ReadSingle(); TrStl.Y1 = br.ReadSingle(); TrStl.Z1 = br.ReadSingle();
                            // 2 вершина
                            TrStl.X2 = br.ReadSingle(); TrStl.Y2 = br.ReadSingle(); TrStl.Z2 = br.ReadSingle();
                            // 3 вершина
                            TrStl.X3 = br.ReadSingle(); TrStl.Y3 = br.ReadSingle(); TrStl.Z3 = br.ReadSingle();
                            //
                            AddAttr = br.ReadUInt16();
                            // запись в ListStl
                            ListStl.Add(TrStl);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + "\n Выбран не верный тип файла");
            }
            //
            return ListStl;
        }
        /// <summary>
        /// Погрешность создания триангуляционного файла
        /// </summary>
        //float error = 1 / 10000;
        /// <summary>
        /// Список вершин
        /// </summary>
        List<base_vertex> listVertex = new List<base_vertex>();

        /// <summary>
        /// Процедура перевода данных из List<base_stl> в List<base_vertex>
        /// </summary>
        /// <param name="ListStl"></param>
        /// <returns></returns>
        public List<object> translationSTLtoListVertex(List<base_stl> ListStl, ToolStripProgressBar ProgressBar)
        {
            List<object> listResult = new List<object>();
            //Номер вершины
            int nomVertex = 0;

            listVertex.Clear();
            for (int k = 0; k < ListStl.Count; k++)
            {
                base_vertex tempVertex1 = new base_vertex() { X = ListStl[k].X1, Y = ListStl[k].Y1, Z = ListStl[k].Z1 };
                base_vertex tempVertex2 = new base_vertex() { X = ListStl[k].X2, Y = ListStl[k].Y2, Z = ListStl[k].Z2 };
                base_vertex tempVertex3 = new base_vertex() { X = ListStl[k].X3, Y = ListStl[k].Y3, Z = ListStl[k].Z3 };
                //Метка совпадения вершин
                bool bVertex1 = false;
                bool bVertex2 = false;
                bool bVertex3 = false;
                //Предположение - треугольник не вырожденный (вершины не совпадают для одной грани)
                if (listVertex.Count != 0)
                {
                    foreach (var item in listVertex)
                    {
                        if (item.X == tempVertex1.X && item.Y == tempVertex1.Y && item.Z == tempVertex1.Z)
                        {
                            bVertex1 = true;
                            ListStl[k].NomV1 = item.Nom;
                        }
                        if (item.X == tempVertex2.X && item.Y == tempVertex2.Y && item.Z == tempVertex2.Z)
                        {
                            bVertex2 = true;
                            ListStl[k].NomV2 = item.Nom;
                        }
                        if (item.X == tempVertex3.X && item.Y == tempVertex3.Y && item.Z == tempVertex3.Z)
                        {
                            bVertex3 = true;
                            ListStl[k].NomV3 = item.Nom;
                        }
                    }
                    if (!bVertex1)
                    {
                        ListStl[k].NomV1 = tempVertex1.Nom = ++nomVertex;
                        listVertex.Add(tempVertex1);
                    }
                    if (!bVertex2)
                    {
                        ListStl[k].NomV2 = tempVertex2.Nom = ++nomVertex;
                        listVertex.Add(tempVertex2);
                    }
                    if (!bVertex3)
                    {
                        ListStl[k].NomV3 = tempVertex3.Nom = ++nomVertex;
                        listVertex.Add(tempVertex3);
                    }
                }
                else
                {
                    ListStl[k].NomV1 = tempVertex1.Nom = nomVertex;
                    listVertex.Add(tempVertex1);
                    ListStl[k].NomV2 = tempVertex2.Nom = ++nomVertex;
                    listVertex.Add(tempVertex2);
                    ListStl[k].NomV3 = tempVertex3.Nom = ++nomVertex;
                    listVertex.Add(tempVertex3);
                }
                ProgressBarRefresh(ProgressBar, k, ListStl.Count);
            }
            listResult.Add(listVertex);
            listResult.Add(ListStl);

            return listResult;
        }
        /// <summary>
        /// Список вершин
        /// </summary>
        List<base_vertex> listVertex2 = new List<base_vertex>();
        /// <summary>
        /// Процедура (второй вариант) перевода данных из List<base_stl> в List<base_vertex>
        /// </summary>
        /// <param name="ListStl"></param>
        /// <returns></returns>
        public List<object> translationSTLtoListVertex2(List<base_stl> ListStl, ToolStripProgressBar ProgressBar)
        {
            List<object> listResult = new List<object>();
            //Номер вершины
            int nomVertex = 0;
            listVertex.Clear();
            listVertex2.Clear();

            for (int k = 0; k < ListStl.Count; k++)
            {
            base_vertex tempVertex1 = new base_vertex();
                tempVertex1.X = ListStl[k].X1;
                tempVertex1.Y = ListStl[k].Y1;
                tempVertex1.Z = ListStl[k].Z1;
                listVertex.Add(tempVertex1);
                tempVertex1.X = ListStl[k].X2;
                tempVertex1.Y = ListStl[k].Y2;
                tempVertex1.Z = ListStl[k].Z2;
                listVertex.Add(tempVertex1);
                tempVertex1.X = ListStl[k].X3;
                tempVertex1.Y = ListStl[k].Y3;
                tempVertex1.Z = ListStl[k].Z3;
                listVertex.Add(tempVertex1);
            }
            //Запрос LINQ, группирование по уникальным координатам XYZ
            var uniqueVox = from XYZ in listVertex
                            group XYZ by XYZ.X.ToString() + ";" + XYZ.Y.ToString() + ";" + XYZ.Z.ToString();
            int uniqueVoxCount = uniqueVox.Count();
            foreach (var item in uniqueVox)
            {
                base_vertex tempVertex = new base_vertex();
                tempVertex.X = item.ToArray()[0].X;
                tempVertex.Y = item.ToArray()[0].Y;
                tempVertex.Z = item.ToArray()[0].Z;
                tempVertex.Nom = nomVertex++;
                listVertex2.Add(tempVertex);
            for (int i = 0; i < ListStl.Count; i++)
            {
                    if (tempVertex.X == ListStl[i].X1 && tempVertex.Y == ListStl[i].Y1 && tempVertex.Z == ListStl[i].Z1)
                    {
                        ListStl[i].NomV1 = tempVertex.Nom;
                    }
                    if (tempVertex.X == ListStl[i].X2 && tempVertex.Y == ListStl[i].Y2 && tempVertex.Z == ListStl[i].Z2)
                    {
                        ListStl[i].NomV2 = tempVertex.Nom;
                    }
                    if (tempVertex.X == ListStl[i].X3 && tempVertex.Y == ListStl[i].Y3 && tempVertex.Z == ListStl[i].Z3)
                    {
                        ListStl[i].NomV3 = tempVertex.Nom;
                    }
            }
                ProgressBarRefresh(ProgressBar, nomVertex, uniqueVoxCount);
            }            
            listResult.Add(listVertex2);
            listResult.Add(ListStl);

            return listResult;
        }

        /// <summary>
        /// Обновление ProgressBar
        /// </summary>
        /// <param name="ProgressBar">Объект класса ToolStripProgressBar</param>
        /// <param name="i">Текущее значение</param>
        /// <param name="count">Общее количество объема данных</param>
        public void ProgressBarRefresh(ToolStripProgressBar ProgressBar, int i, int count)
        {
            ProgressBar.Value = (int)(ProgressBar.Minimum + (ProgressBar.Maximum - ProgressBar.Minimum) * i / count);
            Application.DoEvents();
        }
        //Углы поворота модели вокруг осей X и Y
        double angleXrad;
        double angleYrad;
        /// <summary>
        /// Поворот системы координат вокруг осей X и Y
        /// </summary>
        /// <param name="X">координата точки по оси X</param>
        /// <param name="Y">координата точки по оси Y</param>
        /// <param name="Z">координата точки по оси Z</param>
        /// <returns>Массив XYZ точки в новой системе координат</returns>
        public float[] turnXY(float X, float Y, float Z, float angleX, float angleY)
        {
            //угол в радианах
            angleXrad = Math.PI * angleX / 180;
            angleYrad = Math.PI * angleY / 180;

            return new float[]{ (float)(X * Math.Cos(angleYrad) + Z * Math.Sin(angleYrad)),
                                (float)((X * Math.Sin(angleYrad) - Z * Math.Cos(angleYrad)) * Math.Sin(angleXrad) +
                                Y * Math.Cos(angleXrad)),
                                (float)((-1*X * Math.Sin(angleYrad) + Z * Math.Cos(angleYrad)) * Math.Cos(angleXrad) + 
                                Y * Math.Sin(angleXrad))};
        }

        /// <summary>
        /// Перемещение воксельной модели
        /// </summary>
        /// <param name="voxModel">воксельная модель</param>
        /// <param name="newXmin">новая координата по оси X</param>
        /// <param name="newYmin">новая координата по оси Y</param>
        /// <param name="newZmin">новая координата по оси Z</param>
        /// <param name="oldXmin">старая координата по оси X</param>
        /// <param name="oldYmin">старая координата по оси Y</param>
        /// <param name="oldZmin">старая координата по оси Z</param>
        public List<base_vox> moveVoxels(List<base_vox> voxModel, float newXmin, float newYmin, float newZmin, 
                               float oldXmin, float oldYmin, float oldZmin,
                                   ToolStripProgressBar tempProgressBar)
        {
            List<base_vox> tempList = new List<base_vox>();

            for (int i = 0; i < voxModel.Count; i++)
            {
                ProgressBarRefresh(tempProgressBar, i, voxModel.Count);
                base_vox tempVox = new base_vox();
                tempVox.Xv = voxModel[i].Xv + (newXmin - oldXmin);
                tempVox.Yv = voxModel[i].Yv + (newYmin - oldYmin);
                tempVox.Zv = voxModel[i].Zv + (newZmin - oldZmin);
                tempList.Add(tempVox);
            }
            return tempList;
        }

        /// <summary>
        /// Распределение объемов воксельной модели
        /// </summary>
        /// <param name="voxModel">воксельная модель</param>
        /// <param name="numX">количество интервалов по оси X</param>
        /// <param name="numY">количество интервалов по оси Y</param>
        /// <param name="numZ">количество интервалов по оси Z</param>
        /// <returns>массив распределения объемов по номерам интервалов</returns>
        public int[,,] distribution(List<base_vox> voxModel, int numX, int numY, int numZ,
                                   float Xmin, float Ymin, float Zmin, float step,
                                   ToolStripProgressBar tempProgressBar)
        {
            int[,,] dist = new int[numX, numY, numZ];
            float intXmin, intXmax, intYmin, intYmax, intZmin, intZmax;
            int num = 0;
            foreach (var item in voxModel)
            {
                ProgressBarRefresh(tempProgressBar, num++, voxModel.Count);
                for (int i = 0; i < numX; i++)
                {
                    intXmin = Xmin + i * step;
                    intXmax = Xmin + (i + 1) * step;
                    if (item.Xv >= intXmin && item.Xv < intXmax)
                    {
                        for (int j = 0; j < numY; j++)
                        {
                            intYmin = Ymin + j * step;
                            intYmax = Ymin + (j + 1) * step;
                            if (item.Yv >= intYmin && item.Yv < intYmax)
                            {
                                for (int k = 0; k < numZ; k++)
                                {
                                    intZmin = Zmin + k * step;
                                    intZmax = Zmin + (k + 1) * step;

                                    if (item.Zv >= intZmin && item.Zv < intZmax)
                                    {
                                        dist[i, j, k] += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return dist;
        }
        /// <summary>
        /// Окраска элементов по линейной зависимости
        /// </summary>
        /// <param name="X">величина</param>
        /// <param name="Xmin">минимальное значение интервала</param>
        /// <param name="Xmax">максимальное значение интервала</param>
        /// <param name="R1">компонента R для мин.значения</param>
        /// <param name="G1">компонента G для мин.значения</param>
        /// <param name="B1">компонента B для мин.значения</param>
        /// <param name="R2">компонента R для макс.значения</param>
        /// <param name="G2">компонента G для макс.значения</param>
        /// <param name="B2">компонента B для макс.значения</param>
        /// <returns></returns>
        public int[] colorElementLine(int X, int Xmin, int Xmax, 
                                  int R1, int G1, int B1,
                                  int R2, int G2, int B2)
        {
            int[] RGB = new int[3];
            //R
            RGB[0] = (int)(R1 + (R2 - R1) * (X - Xmin) / (Xmax - Xmin));
            //G
            RGB[1] = (int)(G1 + (G2 - G1) * (X - Xmin) / (Xmax - Xmin));
            //B
            RGB[2] = (int)(B1 + (B2 - B1) * (X - Xmin) / (Xmax - Xmin));
            //Исключения
            if (RGB[0] > 255) { RGB[0] = 255; }
            if (RGB[1] > 255) { RGB[1] = 255; }
            if (RGB[2] > 255) { RGB[2] = 255; }
            return RGB;
        }
        /// <summary>
        /// Окраска элементов по гармонической зависимости
        /// </summary>
        /// <param name="X">величина</param>
        /// <param name="Xmin">минимальное значение интервала</param>
        /// <param name="Xmax">максимальное значение интервала</param>
        /// <param name="R1">компонента R для мин.значения</param>
        /// <param name="G1">компонента G для мин.значения</param>
        /// <param name="B1">компонента B для мин.значения</param>
        /// <param name="R2">компонента R для макс.значения</param>
        /// <param name="G2">компонента G для макс.значения</param>
        /// <param name="B2">компонента B для макс.значения</param>
        /// <returns></returns>
        public int[] colorElementLineGarmonic(int X, int Xmin, int Xmax,
                                  int R1, int G1, int B1,
                                  int R2, int G2, int B2)
        {
            int[] RGB = new int[3];
            //R
            RGB[0] = ((R2 + R1) / 2 + (int)Math.Floor((decimal)((R2 - R1) / 2)
                        * ((decimal)Math.Cos(2 * Math.PI * (X - Xmin) / (Xmax - Xmin)))));
            //G
            RGB[1] = ((G2 + G1) / 2 + (int)Math.Floor((decimal)((G2 - G1) / 2)
                        * ((decimal)Math.Cos(2 * Math.PI / 3 + 2 * Math.PI * (X - Xmin) / (Xmax - Xmin)))));
            //B
            RGB[2] = ((B2 + B1) / 2 + (int)Math.Floor((decimal)((B2 - B1) / 2)
                * ((decimal)Math.Cos(4 * Math.PI / 3 + 2 * Math.PI * (X - Xmin) / (Xmax - Xmin)))));

            //Исключения
            if (RGB[0] > 255) { RGB[0] = 255; }
            if (RGB[1] > 255) { RGB[1] = 255; }
            if (RGB[2] > 255) { RGB[2] = 255; }
            return RGB;
        }
        /// <summary>
        /// Точка пересечения плоскости с линией заданной двумя точками
        /// </summary>
        /// <param name="X1">координата первой точки по оси X</param>
        /// <param name="Y1">координата первой точки по оси Y</param>
        /// <param name="Z1">координата первой точки по оси Z</param>
        /// <param name="X2">координата второй точки по оси X</param>
        /// <param name="Y2">координата второй точки по оси Y</param>
        /// <param name="Z2">координата второй точки по оси Z</param>
        /// <param name="Z0">координита плоскости по оси Z</param>
        /// <returns></returns>
        public PointF PlaneCrossLine(float X1, float Y1, float Z1, float X2, float Y2, float Z2, float Z0)
        {
            float t = (Z0 - Z1) / (Z2 - Z1);
            PointF tempPoint = new PointF() { X = X1 + (X2 - X1) * t,
                                              Y = Y1 + (Y2 - Y1) * t };

            return tempPoint;
        }
        /// <summary>
        /// Расстояние между двумя точками
        /// </summary>
        /// <param name="P1">Первая точка</param>
        /// <param name="P2">Вторая точка</param>
        /// <returns></returns>
        public float length(PointF P1, PointF P2)
        {
            return (float)Math.Sqrt((P1.X - P2.X) * (P1.X - P2.X) + (P1.Y - P2.Y) * (P1.Y - P2.Y));
        }
        /// <summary>
        /// Площадь многоугольника (сумма площадей по двум вершинам ребер)
        /// </summary>
        /// <param name="P1">Первая вершина</param>
        /// <param name="P2">Вторая вершина</param>
        /// <returns></returns>
        public float squareSection(PointF P1, PointF P2)
        {
            return Math.Abs((P1.X + P2.X) * (P1.Y - P2.Y) / 2);
        }
        
        /// <summary>
        /// Барицентр (центр тяжести) многоугольника по списку координат вершин ребер
        /// </summary>
        /// <param name="listElements">Список ребер</param>
        /// <returns>Возвращает координаты барицентра в виде PointF</returns>
        public PointF barycenterSection(List<base_elementOfCurve> listElements)
        {
            float Asquare = 0, Xb = 0, Yb = 0;
            foreach (var item in listElements)
            {
                Asquare += Math.Abs((item.point1.X * item.point2.Y - item.point2.X * item.point1.Y) /2);
                Xb += (item.point1.X + item.point2.X) * Math.Abs(item.point1.X * item.point2.Y - item.point2.X * item.point1.Y);
                Yb += (item.point1.Y + item.point2.Y) * Math.Abs(item.point1.X * item.point2.Y - item.point2.X * item.point1.Y);
            }

            return new PointF() { X = (float)Math.Round(Xb / (6 * Asquare), 1), Y = (float)Math.Round(Yb / (6 * Asquare), 1) };
        }

        /// <summary>
        /// Процедура определения предельных координат модели по осям X, Y, Z
        /// </summary>
        /// <param name="ListStl"></param>
        /// <returns>Массив: 0-minZ, 1-maxZ, 2-minX, 3-maxX, 4-minY, 5-maxY</returns>
        public float[] limitModel(List<base_stl> ListStl)
        {
            float[] limits = new float[6] { float.MaxValue, float.MinValue,
                                            float.MaxValue, float.MinValue,
                                            float.MaxValue, float.MinValue };

            float[] tempZ = new float[3];
            float[] tempX = new float[3];
            float[] tempY = new float[3];
            //
            foreach (var item in ListStl)
            {
                tempZ[0] = item.Z1;
                tempZ[1] = item.Z2;
                tempZ[2] = item.Z3;
                limits[0] = limits[0] < tempZ.Min() ? limits[0] : tempZ.Min();
                limits[1] = limits[1] > tempZ.Max() ? limits[1] : tempZ.Max();

                tempX[0] = item.X1;
                tempX[1] = item.X2;
                tempX[2] = item.X3;
                limits[2] = limits[2] < tempX.Min() ? limits[2] : tempX.Min();
                limits[3] = limits[3] > tempX.Max() ? limits[3] : tempX.Max();

                tempY[0] = item.Y1;
                tempY[1] = item.Y2;
                tempY[2] = item.Y3;
                limits[4] = limits[4] < tempY.Min() ? limits[4] : tempY.Min();
                limits[5] = limits[5] > tempY.Max() ? limits[5] : tempY.Max();
            }

            return limits;
        }

        public List<float> MassiveAngleAdjacent(List<base_elementOfCurve> listE)
        {
            List<base_elementOfCurve> templistE = new List<base_elementOfCurve>();
            //Номер контура
            int nContour = 1;

            for (int i = 0; i < listE.Count(); i++)
            {
                if (i > 0)
                {
                    //поиск совпадения вершин (приближенного)
                    for (int j = i; j < listE.Count; j++)
                    {
                        if (((listE[i - 1].point2.X - listE[j].point1.X) < 0.0001f) &&
                            ((listE[i - 1].point2.Y - listE[j].point1.Y) < 0.0001f))
                        {

                        }
                        if (((listE[i - 1].point2.X - listE[j].point2.X) < 0.0001f) &&
                            ((listE[i - 1].point2.Y - listE[j].point2.Y) < 0.0001f))
                        {

                        }
                    }
                }
                else
                {
                    templistE.Add(listE[i]);
                    listE[i].mark = false;
                    listE[i].iContour = nContour;
                }
            }

            return new List<float>();
        }
    }
}
