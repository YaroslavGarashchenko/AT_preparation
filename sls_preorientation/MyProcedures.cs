using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Drawing;
using MSExel = Microsoft.Office.Interop.Excel;

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
            if(count != 0)
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
            //return Math.Abs((P1.X + P2.X) * (P1.Y - P2.Y) / 2);
            return (P1.X + P2.X) * (P1.Y - P2.Y) / 2;
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
                //Asquare += Math.Abs((item.point1.X * item.point2.Y - item.point2.X * item.point1.Y) /2);
                Asquare += (item.point1.X * item.point2.Y - item.point2.X * item.point1.Y) / 2;
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
        public float[] limitModelOld(List<base_stl> ListStl)
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

        /// <summary>
        /// Процедура определения предельных координат модели по осям X, Y, Z
        /// </summary>
        /// <param name="ListStl"></param>
        /// <returns>Массив: 0-minZ, 1-maxZ, 2-minX, 3-maxX, 4-minY, 5-maxY</returns>
        public float[] limitModel(List<base_stl> ListStl)
        {
            float[] tempZ = new float[3*ListStl.Count];
            float[] tempX = new float[3*ListStl.Count];
            float[] tempY = new float[3*ListStl.Count];
            //
            for (int i = 0; i < ListStl.Count; i++)
            {
                tempZ[3 * i] = ListStl[i].Z1;
                tempZ[3 * i + 1] = ListStl[i].Z2;
                tempZ[3 * i + 2] = ListStl[i].Z3;

                tempX[3 * i] = ListStl[i].X1;
                tempX[3 * i + 1] = ListStl[i].X2;
                tempX[3 * i + 2] = ListStl[i].X3;

                tempY[3 * i] = ListStl[i].Y1;
                tempY[3 * i + 1] = ListStl[i].Y2;
                tempY[3 * i + 2] = ListStl[i].Y3;
            }
            return new float[6] { tempZ.Min(), tempZ.Max(), tempX.Min(), tempX.Max(), tempY.Min(), tempY.Max() };
        }

        /// <summary>
        /// Процедура выявления замкнутых контуров с определением его вида: внешний и внутренний
        /// </summary>
        /// <param name="listE">Список элементов контура</param>
        /// <param name="roundCoord">Точность сравнения координат вершин</param>
        /// <returns>listE</returns>
        public List<base_elementOfCurve> listCloseContour(List<base_elementOfCurve> listE, float roundCoord)
        {
            if (listE.Count == 0)
            {
                return new List<base_elementOfCurve>();
            }

            //Приведение в исходное положение
            for (int k = 0; k < listE.Count(); k++)
            {
                listE[k].iContour = 0;
                listE[k].insideOrOuterContour = true;
                listE[k].numAdjacent1 = 0;
                listE[k].numAdjacent2 = 0;
            }

            //Количество совпадений
            //int numCoincidence = 0;

            //Простановка порядковых номеров смежных элементов
            for (int i = 0; i < listE.Count(); i++)
            {
                if (listE[i].numAdjacent1 == 0)
                {
                    //поиск совпадения вершин (приближенного)
                    for (int j = 0; j < listE.Count; j++)
                    {
                        if (Math.Abs(listE[i].point1.X - listE[j].point2.X) < roundCoord &&
                            Math.Abs(listE[i].point1.Y - listE[j].point2.Y) < roundCoord)
                        {
                            listE[i].numAdjacent1 = listE[j].num;
                            listE[j].numAdjacent2 = listE[i].num;
                            //2017/12/14
                            break;
                            //numCoincidence++;
                        }
                        //
                        //if (numCoincidence == 2)
                        //    goto Finish;
                    }
                }
                if (listE[i].numAdjacent2 == 0)
                {
                    for (int j = 0; j < listE.Count; j++)
                    {
                        if (Math.Abs(listE[i].point2.X - listE[j].point1.X) < roundCoord &&
                            Math.Abs(listE[i].point2.Y - listE[j].point1.Y) < roundCoord)
                        {
                            listE[i].numAdjacent2 = listE[j].num;
                            listE[j].numAdjacent1 = listE[i].num;
                            //2017/12/14
                            break;
                            //numCoincidence++;
                        }
                        //
                        //if (numCoincidence == 2)
                        //    goto Finish;
                    }
                }
            //Finish: numCoincidence = 0;
            }

            //Номер контура
            int numContour = 0;

            //Простановка номера контура
            for (int m = 0; m < listE.Count(); m++)
            {
                if (listE[m].iContour == 0 && listE[m].numAdjacent2 > 0 && listE[m].numAdjacent1 > 0)
                {
                    int searchNum = listE[m].numAdjacent2 - 1;
                    int finishNum = listE[m].numAdjacent1 - 1;
                    listE[m].iContour = ++numContour;
                    int i = 0;
                    //Поиск номера
                    while (searchNum != finishNum && i++ < listE.Count())
                    {
                        if ( searchNum == -1) break;
                        /*
                        if (listE[searchNum].numAdjacent1 == current + 1)
                        {
                        */
                            listE[searchNum].iContour = numContour;
                            searchNum = listE[searchNum].numAdjacent2 - 1;
                        /*
                    }*/
                        /*
                        if (listE[searchNum].numAdjacent2 == current + 1)
                        {
                            current = searchNum;
                            listE[searchNum].iContour = numContour;
                            searchNum = listE[searchNum].numAdjacent1 - 1;
                        }
                        */
                        if (searchNum == 0 ) break;
                    }
                    listE[finishNum].iContour = numContour;
                }
            }

            //Определение внешнего/внутреннего контура (true/false)
            if (numContour > 1)
            {
                List<base_elementOfCurve>[] subList = new List<base_elementOfCurve>[numContour];
                for (int i = 0; i < subList.Length; i++)
                {
                    subList[i] = new List<base_elementOfCurve>();
                }
                foreach (var item in listE)
                {
                    if (item != null && item.iContour != 0)
                    {
                        subList[item.iContour - 1].Add(item);
                    }
                }
                //проверка на наличие псевдоконтуров
                int numBug = 0;
                for (int i = 0; i < numContour; i++)
                {
                    if (subList[i].Count() <= 2)
                        numBug++;
                }
                if (numContour-numBug <= 1)
                {
                    return listE;
                }

                //Площадь отдельных контуров
                float[] sumContour = new float[numContour];
                //метка внешнего контура
                bool[] outContour = new bool[numContour];   
                //
                for (int i = 0; i < numContour; i++)
                {
                    for (int j = 0; j < subList[i].Count(); j++)
                    {
                        sumContour[i] += squareSection(subList[i][j].point1, subList[i][j].point2);
                    }
                    if (sumContour[i] < 0)
                    {
                        for (int j = 0; j < listE.Count(); j++)
                        {
                            if (listE[j].iContour == i)
                            listE[j].insideOrOuterContour = false;
                        }
                    }
                }
            }
            return listE;
        }

        /// <summary>
        /// Определение массива смежных углов для ребер многостороннего контура
        /// </summary>
        /// <param name="listE"></param>
        /// <returns></returns>
        public List<float> massiveAngleAdjacent(List<base_elementOfCurve> listE)
        {
            List<float> result = new List<float>();

            float Xa, Xb, Xc, Ya, Yb, Yc;

            for (int i = 0; i < listE.Count(); i++)
            {
                if (listE[i].numAdjacent2 != 0)
                {
                    Xb = listE[i].point1.X; Yb = listE[i].point1.Y;
                    Xa = listE[i].point2.X; Ya = listE[i].point2.Y;

                    Xc = listE[listE[i].numAdjacent2 - 1].point2.X;
                    Yc = listE[listE[i].numAdjacent2 - 1].point2.Y;

                    result.Add((float)(Math.Acos(((Xb - Xa) * (Xc - Xa) + (Yb - Ya) * (Yc - Ya)) /
                                Math.Sqrt(((Xb - Xa) * (Xb - Xa) + (Yb - Ya) * (Yb - Ya)) * ((Xc - Xa) * (Xc - Xa) + (Yc - Ya) * (Yc - Ya))))
                                * 180 / Math.PI));
                }
            }

            return result;
        }

        /// <summary>
        /// Сохранение данных DataGridView в XLS файл
        /// </summary>
        /// <param name="dataGridView"></param>
        public void SaveDataGridInXlc(DataGridView dataGridView)
        {
            try
            {
                MSExel.Application ExcelApp = new MSExel.Application();
                MSExel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add();
                MSExel.Sheets Sheets = ExcelWorkBook.Worksheets;
                MSExel.Worksheet ExcelWorkSheet = (MSExel.Worksheet)Sheets.get_Item(1);

                for (int j = 0; j < dataGridView.ColumnCount; j++)
                    ExcelApp.Cells[1, j + 1] = dataGridView.Columns[j].HeaderText;
                //
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value;
                    }
                }
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch (Exception err)
            {
                Clipboard.Clear();
                string clipboardTable = "";
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    clipboardTable += dataGridView.Columns[j].HeaderText;
                    clipboardTable += "\t";
                }
                clipboardTable += "\n";
                //
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value.ToString() != null &&
                            dataGridView.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            clipboardTable += dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            clipboardTable += "---";
                        }
                        clipboardTable += "\t";
                    }
                    clipboardTable += "\n";
                }
                Clipboard.SetText(clipboardTable);
                MessageBox.Show("Проблемы с приложением MS Excel \n" +
                                "Данные таблицы помещены в буфер обмена. \n\n" + err.Message);
            }
        }
        /// <summary>
        /// Определение координат точек пересечения плоскостью треугольной грани
        /// </summary>
        /// <param name="P1">Первая вершина</param>
        /// <param name="P2">Вторая вершина</param>
        /// <param name="P3">Третяя вершина</param>
        /// <param name="Z">Координата расположения плоскости по оси Z</param>
        /// <returns></returns>
        public PointF[] elementOfCurveOld (Point3D P1, Point3D P2, Point3D P3, float Z)
        {
            /*
             base_elementOfCurve tempElement = new base_elementOfCurve();

                        if (coordinateSectionZ[i] == pointSTL[0].Z && coordinateSectionZ[i] == pointSTL[1].Z)
                        {
                            tempElement.point1 = new PointF() { X = pointSTL[0].X, Y = pointSTL[0].Y };
                            tempElement.point2 = new PointF() { X = pointSTL[1].X, Y = pointSTL[1].Y };
                        }
                        else if (coordinateSectionZ[i] == pointSTL[1].Z && coordinateSectionZ[i] == pointSTL[2].Z)
                        {
                            tempElement.point1 = new PointF() { X = pointSTL[1].X, Y = pointSTL[1].Y };
                            tempElement.point2 = new PointF() { X = pointSTL[2].X, Y = pointSTL[2].Y };
                        }
                        else 
                        {
                            if (pointSTL[1].Z > coordinateSectionZ[i] && pointSTL[0].Z < coordinateSectionZ[i])
                            {
                                tempElement.point1 = proc.PlaneCrossLine(pointSTL[0].X, pointSTL[0].Y, pointSTL[0].Z,
                                                     pointSTL[1].X, pointSTL[1].Y, pointSTL[1].Z,
                                                     coordinateSectionZ[i]);

                                tempElement.point2 = proc.PlaneCrossLine(pointSTL[0].X, pointSTL[0].Y, pointSTL[0].Z,
                                                     pointSTL[2].X, pointSTL[2].Y, pointSTL[2].Z,
                                                     coordinateSectionZ[i]);
                            }
                            if (pointSTL[2].Z > coordinateSectionZ[i] && pointSTL[1].Z < coordinateSectionZ[i])
                            {
                                tempElement.point1 = proc.PlaneCrossLine(pointSTL[0].X, pointSTL[0].Y, pointSTL[0].Z,
                                                     pointSTL[2].X, pointSTL[2].Y, pointSTL[2].Z,
                                                     coordinateSectionZ[i]);

                                tempElement.point2 = proc.PlaneCrossLine(pointSTL[1].X, pointSTL[1].Y, pointSTL[1].Z,
                                                     pointSTL[2].X, pointSTL[2].Y, pointSTL[2].Z,
                                                     coordinateSectionZ[i]);
                            }
                        } 
            */

            PointF[] pointsCurve = new PointF[2];

            if (Z == P1.Z && Z == P2.Z)
            {
                pointsCurve[0] = new PointF() { X = P1.X, Y = P1.Y };
                pointsCurve[1] = new PointF() { X = P2.X, Y = P2.Y };
            }
            else if (Z == P2.Z && Z == P3.Z)
            {
                pointsCurve[0] = new PointF() { X = P2.X, Y = P2.Y };
                pointsCurve[1] = new PointF() { X = P3.X, Y = P3.Y };
            }
            else
            {
                if (P2.Z > Z && P1.Z < Z)
                {
                    pointsCurve[0] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P2.X, P2.Y, P2.Z, Z);

                    pointsCurve[1] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P3.X, P3.Y, P3.Z, Z);
                }
                if (P3.Z > Z && P2.Z < Z)
                {
                    pointsCurve[0] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P3.X, P3.Y, P3.Z, Z);

                    pointsCurve[1] = PlaneCrossLine(P2.X, P2.Y, P2.Z, P3.X, P3.Y, P3.Z, Z);
                }
            }

            return pointsCurve;
        }

        /// <summary>
        /// Определение координат точек пересечения плоскостью треугольной грани
        /// </summary>
        /// <param name="P1">Первая вершина</param>
        /// <param name="P2">Вторая вершина</param>
        /// <param name="P3">Третяя вершина</param>
        /// <param name="Z">Координата расположения плоскости по оси Z</param>
        /// <returns></returns>
        public PointF[] elementOfCurve(Point3D P1, Point3D P2, Point3D P3, float Z)
        {
            PointF[] pointsCurve = new PointF[2];

            if (Z == P1.Z && Z == P2.Z)
            {
                pointsCurve[1] = new PointF() { X = P1.X, Y = P1.Y };
                pointsCurve[0] = new PointF() { X = P2.X, Y = P2.Y };
            }
            else if (Z == P2.Z && Z == P3.Z)
            {
                pointsCurve[1] = new PointF() { X = P2.X, Y = P2.Y };
                pointsCurve[0] = new PointF() { X = P3.X, Y = P3.Y };
            }
            else if (Z == P3.Z && Z == P1.Z)
            {
                pointsCurve[1] = new PointF() { X = P3.X, Y = P3.Y };
                pointsCurve[0] = new PointF() { X = P1.X, Y = P1.Y };
            }
            else if (P1.Z >= Z && P2.Z <= Z && P3.Z <= Z)
            {
                pointsCurve[1] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P2.X, P2.Y, P2.Z, Z);
                pointsCurve[0] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P1.X, P1.Y, P1.Z, Z);
            }
            else if (P2.Z >= Z && P1.Z <= Z && P3.Z <= Z)
            {
                pointsCurve[0] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P2.X, P2.Y, P2.Z, Z);
                pointsCurve[1] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P2.X, P2.Y, P2.Z, Z);
            }
            else if (P3.Z >= Z && P1.Z <= Z && P2.Z <= Z)
            {
                pointsCurve[0] = PlaneCrossLine(P2.X, P2.Y, P2.Z, P3.X, P3.Y, P3.Z, Z);
                pointsCurve[1] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P1.X, P1.Y, P1.Z, Z);
            }
            else if (P1.Z <= Z && P2.Z >= Z && P3.Z >= Z)
            {
                pointsCurve[0] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P2.X, P2.Y, P2.Z, Z);
                pointsCurve[1] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P1.X, P1.Y, P1.Z, Z);
            }
            else if (P2.Z <= Z && P1.Z >= Z && P3.Z >= Z)
            {
                pointsCurve[1] = PlaneCrossLine(P1.X, P1.Y, P1.Z, P2.X, P2.Y, P2.Z, Z);
                pointsCurve[0] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P2.X, P2.Y, P2.Z, Z);
            }
            else if (P3.Z <= Z && P1.Z >= Z && P2.Z >= Z)
            {
                pointsCurve[1] = PlaneCrossLine(P2.X, P2.Y, P2.Z, P3.X, P3.Y, P3.Z, Z);
                pointsCurve[0] = PlaneCrossLine(P3.X, P3.Y, P3.Z, P1.X, P1.Y, P1.Z, Z);
            }
            return pointsCurve;
        }

        /// <summary>
        /// Определение фрактальной размерности контура (контуров)
        /// </summary>
        /// <param name="listE">Список элементов контура</param>
        /// <returns></returns>
        public base_fract_anal fractalDimension(List<base_elementOfCurve> listE, int CountFractalAnalysis, int ratioRtoL, bool absOrRelR)
        {
            base_fract_anal ResultFractalAnalysis = new base_fract_anal();
            if (listE.Count == 0) { return ResultFractalAnalysis; }

            //List<float> listFractalDimension = new List<float>();
            //Результаты анализа фрактальной размерности 
            
            ResultFractalAnalysis.fractalDimension = new List<float>();
            ResultFractalAnalysis.length = new List<float>();
            ResultFractalAnalysis.size = new List<float>();
            ResultFractalAnalysis.pointR = new List<fractalMeraR>();
            ResultFractalAnalysis.countElements = listE.Count();
            List<PointF> listPointF = new List<PointF>();
            int countContour = 0;
            //Определение количества контуров
            foreach (var item in listE)
            { countContour = item.iContour < countContour ? countContour : item.iContour; }
            ResultFractalAnalysis.countContour = countContour;
            int[] startContour = new int[countContour]; // начало контура
            int[] endContour = new int[countContour]; // конец контура
            float[] lengthContour = new float[countContour]; // длина контура
            for (int j = 0; j < countContour; j++)
            {
                var listECurrent = from E in listE
                                   where E.iContour == j + 1
                                   select E;                
                //Первая и последняя точки контура
                bool first = true;
                foreach (var item in listECurrent)
                {
                    if ( first )
                    {
                        startContour[j] = item.num - 1; //Номер элемента начала
                        first = false;
                    }
                        lengthContour[j] += length(item.point1, item.point2);
                }
                float mera;
                // Первоначальный радиус окружности  
                if (absOrRelR)
                {
                    mera = ratioRtoL; //абсолютный размер
                }
                else
                {
                    mera = lengthContour[j] / ratioRtoL; //радиус относительно длины контура
                }
                ResultFractalAnalysis.Mstart = mera;
                int[] L = new int[CountFractalAnalysis]; // Размерность
                float[] M = new float[CountFractalAnalysis]; // Мера
                
                //Изменение меры
                for (int varMera = 0; varMera < CountFractalAnalysis; varMera++)
                {
                    int i = 0;
                    //прохождение контура
                    mera = mera / 2; // Мера - радиус окружности
                    float x0 = listE[startContour[j]].point1.X; //Координаты центра окружности
                    float y0 = listE[startContour[j]].point1.Y;
                    float lengthOld = 0f;
                    PointF pointSearch = new PointF(); //Для поиска точки пересечения
                    int limit = (int)Math.Ceiling(lengthContour[j] / mera) + 1;
                    while (lengthOld < lengthContour[j] && i < limit)
                    {
                        float A = mera * mera - x0 * x0 - y0 * y0;
                        float lengthSearch = float.MaxValue; //Для поиска минимального значения

                        foreach (var item in listECurrent)
                        {
                            float x1 = item.point1.X; float y1 = item.point1.Y;//1-я точка линии
                            float x2 = item.point2.X; float y2 = item.point2.Y;//2-я точка линии
                            PointF pointTemp1 = new PointF(); PointF pointTemp2 = new PointF();
                            bool add = false;
                            //два варианта расчета точек пересечения
                            if (x1 == x2)
                            {
                                //Проверка пересечения окружности с линией контура
                                if (Math.Abs(x0 - x1) <= mera)
                                {
                                    pointTemp1.X = x1;
                                    pointTemp1.Y = y0 + (float)Math.Sqrt(2 * x0 * x1 - x1 * x1 + y0 * y0 + A);
                                    pointTemp2.X = x1;
                                    pointTemp2.Y = y0 - (float)Math.Sqrt(2 * x0 * x1 - x1 * x1 + y0 * y0 + A);
                                    add = true;
                                }
                            }
                            else
                            {
                                float k = (y2 - y1) / (x2 - x1);
                                float B = 2 * k * k * x0 * x1 - k * k * x1 * x1 + k * k * y0 * y0 + A * k * k + 2 * k * x0 * y0 - 2 * k * x0 * y1 -
                                          2 * k * x1 * y0 + 2 * k * x1 * y1 + x0 * x0 + 2 * y0 * y1 - y1 * y1 + A;
                                //Проверка пересечения окружности с линией контура
                                if (B >= 0)
                                {
                                    float C = k * (k * x1 + y0 - y1) + x0;
                                    pointTemp1.X = (float)(C + Math.Sqrt(B)) / (k * k + 1);
                                    pointTemp1.Y = (float)(k * (C + Math.Sqrt(B)) / (k * k + 1) - k * x1 + y1);
                                    pointTemp2.X = (float)(C - Math.Sqrt(B)) / (k * k + 1);
                                    pointTemp2.Y = (float)(k * (C - Math.Sqrt(B)) / (k * k + 1) - k * x1 + y1);
                                    add = true;
                                }
                            }
                            if (add)
                            {
                                float length1 = float.MaxValue, length2 = float.MaxValue;
                                //Проверка попадания точки на линию (между точками listE[i].point1 и listE[i].point2)
                                if (locatePointInLine(item.point1, item.point2, pointTemp1))
                                    length1 = lengthContourFromStartToPoint(listE, startContour[j], item.num - 1, pointTemp1);

                                if (locatePointInLine(item.point1, item.point2, pointTemp2))
                                    length2 = lengthContourFromStartToPoint(listE, startContour[j], item.num - 1, pointTemp2);

                                //Проверка сравнением с расстоянием до центра окружности
                                length1 = length1 < lengthOld ? float.MaxValue : length1;
                                length2 = length2 < lengthOld ? float.MaxValue : length2;

                                if (length1 < length2 && length1 < lengthSearch)
                                { lengthSearch = length1; pointSearch = pointTemp1; }
                                else if (length1 > length2 && length2 < lengthSearch)
                                { lengthSearch = length2; pointSearch = pointTemp2; }
                            }
                        }
                        lengthOld = lengthSearch;
                        x0 = pointSearch.X; y0 = pointSearch.Y;
                        listPointF.Add(pointSearch);
                        fractalMeraR tempR = new fractalMeraR() {nomIteration = i++, nomMeasure = varMera,
                                             pointCentre = pointSearch, R = mera};
                        ResultFractalAnalysis.pointR.Add(tempR);
                        L[varMera]++;
                    }
                    M[varMera] = mera;
                    if (varMera > 0)
                    {   
                        ResultFractalAnalysis.fractalDimension.Add((float)((Math.Log(L[varMera - 1] + 1) - Math.Log(L[varMera] + 1)) /
                                                 (Math.Log(M[varMera]) - Math.Log(M[varMera - 1]))));
                    }
                        ResultFractalAnalysis.size.Add(M[varMera]);
                        ResultFractalAnalysis.length.Add(L[varMera]);
                }
            }
            return ResultFractalAnalysis;
        }
        
        /// <summary>
        /// Определение длины отрезка контура
        /// </summary>
        /// <param name="listE">Список элементов контура</param>
        /// <param name="numElement1">Номер элемента начала отрезка</param>
        /// <param name="numElement2">Номер элемента конца отрезка</param>
        /// <param name="EndPoint">Точка конца отрезка</param>
        /// <returns></returns>
        float lengthContourFromStartToPoint(List<base_elementOfCurve> listE, int numElement1, int numElement2, PointF EndPoint)
        {
            if (listE.Count == 0) return 0f;

            float lengthContour = 0;
            int numElement = numElement1;

            while (numElement2 != numElement)
            {
                lengthContour += length(listE[numElement].point1, listE[numElement].point2);
                numElement = listE[numElement].numAdjacent2 - 1;
            }
            lengthContour += length(listE[numElement2].point1, EndPoint);
            return lengthContour;
        }

        /// <summary>
        /// Определение размещения точки в пределах отрезка заданного двумя точками
        /// </summary>
        /// <param name="linePoint1">Первая точка линии</param>
        /// <param name="linePoint2">Вторая точка линии</param>
        /// <param name="Point3">Заданная точка</param>
        /// <returns>true - точка внутри отрезка</returns>
        bool locatePointInLine(PointF linePoint1, PointF linePoint2, PointF Point3)
        {
            float length13 = (float)Math.Sqrt((linePoint1.X - Point3.X) * (linePoint1.X - Point3.X) + 
                                              (linePoint1.Y - Point3.Y) * (linePoint1.Y - Point3.Y));
            float length12 = (float)Math.Sqrt((linePoint1.X - linePoint2.X) * (linePoint1.X - linePoint2.X) +
                                              (linePoint1.Y - linePoint2.Y) * (linePoint1.Y - linePoint2.Y));
            float length23 = (float)Math.Sqrt((linePoint2.X - Point3.X) * (linePoint2.X - Point3.X) +
                                              (linePoint2.Y - Point3.Y) * (linePoint2.Y - Point3.Y));
            return (length12 >= length13 && length12 >= length23);
        }
    }
}
