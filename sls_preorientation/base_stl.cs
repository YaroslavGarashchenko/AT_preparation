using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace PreAddTech
{
    /// <summary>
    /// класс описания треугольной грани для stl файла
    /// </summary>
    public class Base_stl
    {
        /// <summary>
        /// порядковый номер треугольника
        /// </summary>
        public int Nom { get; set; }

        /// <summary>
        /// Номер 1-й вершины
        /// </summary>
        public int NomV1 { get; set; }

        /// <summary>
        /// Номер 2-й вершины
        /// </summary>
        public int NomV2 { get; set; }

        /// <summary>
        /// Номер 3-й вершины
        /// </summary>
        public int NomV3 { get; set; }

        /// <summary>
        /// координата 1-й вершины по оси Х
        /// </summary>
        private float x1;
        public float X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        /// <summary>
        /// координата 1-й вершины по оси Y
        /// </summary>
        private float y1;
        public float Y1
        {
            get { return y1; }
            set { y1 = value; }
        }
        /// <summary>
        /// координата 1-й вершины по оси Z
        /// </summary>
        private float z1;
        public float Z1
        {
            get { return z1; }
            set { z1 = value; }
        }
        /// <summary>
        /// координата 2-й вершины по оси X (private)
        /// </summary>
        private float x2;
        /// <summary>
        /// координата 2-й вершины по оси X
        /// </summary>
        public float X2
        {
            get { return x2; }
            set { x2 = value; }
        }
        /// <summary>
        /// координата 2-й вершины по оси Y
        /// </summary>
        private float y2;
        public float Y2
        {
            get { return y2; }
            set { y2 = value; }
        }
        /// <summary>
        /// координата 2-й вершины по оси Z
        /// </summary>
        private float z2;
        public float Z2
        {
            get { return z2; }
            set { z2 = value; }
        }
        /// <summary>
        /// координата 3-й вершины по оси X
        /// </summary>
        private float x3;
        public float X3
        {
            get { return x3; }
            set { x3 = value; }
        }
        /// <summary>
        /// координата 3-й вершины по оси Y
        /// </summary>
        private float y3;
        public float Y3
        {
            get { return y3; }
            set { y3 = value; }
        }
        /// <summary>
        /// координата 3-й вершины по оси Z
        /// </summary>
        private float z3;
        public float Z3
        {
            get { return z3; }
            set { z3 = value; }
        }
        /// <summary>
        /// Координата нормали треугольника по оси X
        /// </summary>
        private float xN;
        public float XN
        {
            get { return xN; }
            set { xN = value; }
        }
        /// <summary>
        /// Координата нормали треугольника по оси Y
        /// </summary>
        private float yN;
        public float YN
        {
            get { return yN; }
            set { yN = value; }
        }
        /// <summary>
        /// Координата нормали треугольника по оси Z
        /// </summary>
        private float zN;
        public float ZN
        {
            get { return zN; }
            set { zN = value; }
        }
        /// <summary>
        /// Цвет грани (R компонента)
        /// </summary>
        public byte Rface { get; set; }
        /// <summary>
        /// Цвет грани (G компонента)
        /// </summary>
        public byte Gface { get; set; }
        /// <summary>
        /// Цвет грани (B компонента)
        /// </summary>
        public byte Bface { get; set; }

        /// <summary>
        /// площадь треугольника
        /// </summary>
        public float STr { get; set; }

        /// <summary>
        /// создание строки со всеми исходными параметрами (x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn)
        /// </summary>
        /// <returns></returns>
        public string Allstring()
            {
            return Nom.ToString() + "; \t" + x1 + "; " + y1 + "; " + z1 + "; " + x2 + "; " + y2 + "; " + z2 + "; " + 
                                             x3 + "; " + y3 + "; " + z3 + "; " + xN + "; " + yN + "; " + zN + "\n";
        }

        private float minx;
        /// <summary>
        /// Минимальное значение координат вершин по оси Х
        /// </summary>
        /// <returns></returns>
        public float MinX()
        {
            minx = (x1 < x2) ? x1 : x2;
            minx = (minx < x3) ? minx : x3;
            return minx;
        }
        private float miny;
        /// <summary>
        /// Минимальное значение координат вершин по оси Y
        /// </summary>
        /// <returns></returns>
        public float MinY()
        {
            miny = (y1 < y2) ? y1 : y2;
            miny = (miny < y3) ? miny : y3;
            return miny;
        }
        private float minz;
        /// <summary>
        /// Минимальное значение координат вершин по оси Z
        /// </summary>
        /// <returns></returns>
        public float MinZ()
        {
            minz = (z1 < z2) ? z1 : z2;
            minz = (minz < z3) ? minz : z3;
            return minz;
        }
        private float maxx;
        /// <summary>
        /// Максимальное значение координат вершин по оси Х
        /// </summary>
        /// <returns></returns>
        public float MaxX()
        {
            maxx = (x1 > x2) ? x1 : x2;
            maxx = (maxx > x3) ? maxx : x3;
            return maxx;
        }
        private float maxy;
        /// <summary>
        /// Максимальное значение координат вершин по оси Y
        /// </summary>
        /// <returns></returns>
        public float MaxY()
        {
            maxy = (y1 > y2) ? y1 : y2;
            maxy = (maxy > y3) ? maxy : y3;
            return maxy;
        }
        private float maxz;
        /// <summary>
        /// Максимальное значение координат вершин по оси Z
        /// </summary>
        /// <returns></returns>
        public float MaxZ()
        {
            maxz = (z1 > z2) ? z1 : z2;
            maxz = (maxz > z3) ? maxz : z3;
            return maxz;
        }
        /// <summary>
        /// Определение попадания точки с координатами X, Y в пределы треугольника
        /// </summary>
        /// <param name="tempX">координата определяемой точки по оси X</param>
        /// <param name="tempY">координата определяемой точки по оси Y</param>
        /// <returns>true - точка находится внутри треугольника, false - наружи</returns>
        public bool PeresZ(float tempX, float tempY)
        {
            if (ZN == 0)
            {
                return false;
            }

            if (MinX() <= tempX && MaxX() >= tempX && MinY() <= tempY && MaxY() >= tempY)
            {

                //Зависит от правильного обхода ребер треугольника
                
               float a = (X1 - tempX) * (Y2 - Y1) - (X2 - X1) * (Y1 - tempY);
               float b = (X2 - tempX) * (Y3 - Y2) - (X3 - X2) * (Y2 - tempY);
               float c = (X3 - tempX) * (Y1 - Y3) - (X1 - X3) * (Y3 - tempY);

               if ((a >= 0 && b >= 0 && c >= 0) || (a < 0 && b < 0 && c < 0))
               { return true; }
               else
               { return false; }
               
            }
            else
            { return false; }

        }
        /// <summary>
        /// Определение попадания точки с координатами X, Y в пределы треугольника (перегруженый метод)
        /// </summary>
        /// <param name="tempX">координата определяемой точки по оси X</param>
        /// <param name="tempY">координата определяемой точки по оси Y</param>
        /// <returns>true - точка находится внутри треугольника, false - наружи</returns>
        public bool PeresZ2(float tempX, float tempY)
        {
            if (ZN == 0)
            {
                return false;
            }
            
            if (MinX() <= tempX && MaxX() >= tempX && MinY() <= tempY && MaxY() >= tempY)
            {

            MyProcedures procedure = new MyProcedures();
            double Str123 = procedure.Str(X1, Y1, 0, X2, Y2, 0, X3, Y3, 0);
            double Str12 = procedure.Str(X1, Y1, 0, X2, Y2, 0, tempX, tempY, 0);
            double Str23 = procedure.Str(tempX, tempY, 0, X2, Y2, 0, X3, Y3, 0);
            double Str31 = procedure.Str(X1, Y1, 0, tempX, tempY, 0, X3, Y3, 0);
            return (Math.Abs((Str123) - (Str12 + Str23 + Str31)) < (Str123 / 100) );
            }
            else
            { return false; }
        }

        /// <summary>
        /// Определение попадания точки с координатами X, Y, Z в пределы треугольника
        /// </summary>
        /// <param name="tempX">координата определяемой точки по оси X</param>
        /// <param name="tempY">координата определяемой точки по оси Y</param>
        /// <param name="tempZ">координата определяемой точки по оси Z</param>
        /// <param name="tempNX">координата нормали грани по оси X</param>
        /// <param name="tempNY">координата нормали грани по оси Y</param>
        /// <returns>true - точка находится внутри треугольника, false - наружи</returns>
        public bool PeresXY(float tempX, float tempY, float tempZ, float tempNX, float tempNY)
        {
            //Для граней перпендикулярных оси Z не определяем пересечение
            if (ZN == 1 || ZN == -1)
            {
                return false;
            }
            
            //
            if (MinZ() <= tempZ && MaxZ() >= tempZ)
            {
                float A = (Y2 - Y1) * (Z3 - Z1) - (Y3 - Y1) * (Z2 - Z1);
                float B = (X2 - X1) * (Z3 - Z1) - (Z2 - Z1) * (X3 - X1);
                float C = (tempZ - Z1) * ((X2 - X1) *(Y3 - Y1) - (Y2 - Y1) * (X3 - X1));
                float tempX0 = (A * X1 + B * (tempY - tempNY * tempX / tempNX - Y1) - C) / (A - B* tempNY/ tempNX);
                float tempY0 = tempY + (tempNY / tempNX)*(tempX0 - tempX);
                //
                float a = (X1 - tempX0) * (Y2 - Y1) - (X2 - X1) * (Y1 - tempY0);
                float b = (X2 - tempX0) * (Y3 - Y2) - (X3 - X2) * (Y2 - tempY0);
                float c = (X3 - tempX0) * (Y1 - Y3) - (X1 - X3) * (Y3 - tempY0);

                if ((a >= 0 && b >= 0 && c >= 0) || (a < 0 && b < 0 && c < 0))
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }

        float koordZ;
        /// <summary>
        /// Определение координаты по оси Z точки с координатами X, Y лежащей на грани треугольника
        /// </summary>
        /// <param name="tempX">координата определяемой точки по оси X</param>
        /// <param name="tempY">координата определяемой точки по оси Y</param>
        /// <returns>Координата по оси Z</returns>
        public float KoordZ(float tempX, float tempY)
        {
            koordZ = Z1 + ((tempY - Y1)*((X3-X1)*(Z2-Z1)-(Z3-Z1)*(X2-X1))
                     + (X1 - tempX)*((Y3-Y1)*(Z2-Z1)-(Y2-Y1)*(Z3-Z1))) /
                     ((X3-X1)*(Y2-Y1)-(X2-X1)*(Y3-Y1));
            return koordZ;
        }

        float[] koordXY = new float[4];
        /// <summary>
        /// Определение координат по осям X, Y, расстояние и радиус вектор для точки лежащей на грани треугольника в плоскости Z 
        /// (пересекающая линия задана направляющими)
        /// </summary>
        /// <param name="tempX">координата определяемой точки по оси X</param>
        /// <param name="tempY">координата определяемой точки по оси Y</param>
        /// <param name="tempZ">координата определяемой точки по оси Z</param>
        /// <param name="tempNX">координата нормали грани по оси X</param>
        /// <param name="tempNY">координата нормали грани по оси Y</param>
        /// <returns>Координата по оси Z</returns>
        public float[] KoordXY(float tempX, float tempY, float tempZ, float tempNX, float tempNY)
        {
            float A = (Y2 - Y1) * (Z3 - Z1) - (Y3 - Y1) * (Z2 - Z1);
            float B = (X2 - X1) * (Z3 - Z1) - (Z2 - Z1) * (X3 - X1);
            float C = (tempZ - Z1) * ((X2 - X1) * (Y3 - Y1) - (Y2 - Y1) * (X3 - X1));
            //X
            koordXY[1] = (A * X1 + B * (tempY - tempNY * tempX / tempNX - Y1) - C) / (A - B * tempNY / tempNX);
            //Y
            koordXY[2] = tempY + (tempNY / tempNX) * (koordXY[1] - tempX);
            //Length
            koordXY[3] = (float)Math.Sqrt((tempX - koordXY[0]) * (tempX - koordXY[0]) + (tempY - koordXY[1]) * (tempY - koordXY[1]));
            //Радиус вектор точки
            koordXY[0] = (float)Math.Sqrt(koordXY[0] * koordXY[0] + koordXY[1] * koordXY[1]);
            return koordXY;
        }

        double[] calcSTr = new double[] {0,0,0,0};
        /// <summary>
        /// Определение площади треугольной грани [XY,YZ,XZ,грани]
        /// </summary>
        /// <returns>Массив площадей проекций и грани [XY,YZ,XZ,грани]</returns>
        public double[] CalcSTr()
        {
            calcSTr[0] = X2 * Y3 - X2 * Y1 - X1 * Y3 - X3 * Y2 + X1 * Y2 + X3 * Y1;
            calcSTr[1] = Y2 * Z3 - Y2 * Z1 - Y1 * Z3 - Y3 * Z2 + Y1 * Z2 + Y3 * Z1;
            calcSTr[2] = X2 * Z3 - X2 * Z1 - X1 * Z3 - X3 * Z2 + X1 * Z2 + X3 * Z1;
            calcSTr[3] = 0.5 * Math.Sqrt(calcSTr[0] * calcSTr[0] + calcSTr[1] * calcSTr[1] + calcSTr[2] * calcSTr[2]);
            return calcSTr;
        }
        float calcVol;
        /// <summary>
        /// Определение объема треугольника как тетраэдра с вершиной в начале координат (для общего объема STL файла)
        /// </summary>
        /// <returns></returns>
        public float CalcVol()
        {
             calcVol = ( X1*Y2*Z3 - X1*Y3*Z2 - X2*Y1*Z3 + X2*Y3*Z1 + X3*Y1*Z2 - X3*Y2*Z1)/6;
             return calcVol;
        }
        float[] centerOfGravity = new float[4];
        /// <summary>
        /// Цетр тяжести тетраэдра с основанием треугольника (для определения цетра тяжести модели)
        /// http://www.e-maxx-ru.1gb.ru/algo/gravity_center
        /// </summary>
        /// <returns>координаты центра тяжести X, Y, Z и объем</returns>
        public float[] CenterOfGravity()
        {
            centerOfGravity[0] = (X1 + X2 + X3 + 0) / 4;
            centerOfGravity[1] = (Y1 + Y2 + Y3 + 0) / 4;
            centerOfGravity[2] = (Z1 + Z2 + Z3 + 0) / 4;
            centerOfGravity[3] = CalcVol();
            return centerOfGravity;
        }
        /// <summary>
        /// Радиусы вписанной и описанной окружности для треуг. грани
        /// </summary>
        /// <returns>Rr[0] - радиус вписанной окружности, Rr[1] - описанной окружности</returns>
        public float[] CalcR()
        {
            float[] Rr = new float[2];
            // Длины сторон
            float L12 = (float)Math.Sqrt((double)((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2) + (Z1 - Z2) * (Z1 - Z2)));
            float L23 = (float)Math.Sqrt((double)((X2 - X3) * (X2 - X3) + (Y2 - Y3) * (Y2 - Y3) + (Z2 - Z3) * (Z2 - Z3)));
            float L31 = (float)Math.Sqrt((double)((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1) + (Z3 - Z1) * (Z3 - Z1)));
            // Полупериод
            float p = (L12 + L23 + L31)/2;
            // радиус вписанной окружности
            Rr[0] = (float)Math.Sqrt((double)((p - L12) * (p - L23) * (p - L31) / p));
            // описанной окружности
            Rr[1] = L12 * L23 * L31 / (4 * (float)Math.Sqrt((double)((p - L12) * (p - L23) * (p - L31) * p)));
            return Rr;
        }
    }
    /// <summary>
    /// класс описания вершины треугольной грани для stl файла
    /// </summary>
    public class Base_vertex
    {
        /// <summary>
        /// Номер вершины
        /// </summary>
        public int Nom { get; set; }

        /// <summary>
        /// координата вершины по оси Х
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// координата вершины по оси Y
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// координата вершины по оси Z
        /// </summary>
        public float Z { get; set; }
        /// <summary>
        /// Строковое представление координат X, Y, Z
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return X.ToString("N08") + " " + Y.ToString("N08") + " " + Z.ToString("N08");
        }
    }
    /// <summary>
    /// Координаты вершин и вектора нормали с площадью треугольника
    /// </summary>
    public struct SurfaceNormal
    {
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float X3 { get; set; }
        public float Y1 { get; set; }
        public float Y2 { get; set; }
        public float Y3 { get; set; }
        public float Z1 { get; set; }
        public float Z2 { get; set; }
        public float Z3 { get; set; }
        public float XN { get; set; }
        public float YN { get; set; }
        public float ZN { get; set; }
        public float Str{ get; set; }

    }

    /// <summary>
    /// Координаты вершин треугольника
    /// </summary>
    public struct VertexXYZ
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    /// <summary>
    /// Фрагмент поверхности попадаемый в слой
    /// </summary>
    public class SurfaceSection
    {
        /// <summary>
        /// Трансформация треугольника для ускорения определения части площади (преобразование пространственно заданной грани в подобный плоский)
        /// </summary>
        /// <param name="pointSTL">Список вершин треугольной грани</param>
        /// <param name="ZN">Нормаль треугольника по оси Z</param>
        /// <returns></returns>
        public List<TransformedTriangle> TransformTriangle(List<Point3D> pointSTL, float ZN)
        {
            List<TransformedTriangle> listTransformedTriangle = new List<TransformedTriangle>();

            MyProcedures proc = new MyProcedures();
            List<Point3D> pointSTL0 = pointSTL.OrderBy(p => p.Z).ToList<Point3D>();
            float h1, h2, zn = ZN;

            if (Math.Abs(ZN) == 1)
            {
                listTransformedTriangle.Add(new TransformedTriangle() { Z1 = pointSTL0[0].Z, H1 = 0, Z2 = pointSTL0[2].Z, H2 = 0, ZN = zn,
                    S = (float)proc.Str(pointSTL[0].X, pointSTL[0].Y, pointSTL[0].Z, 
                                        pointSTL[1].X, pointSTL[1].Y, pointSTL[1].Z, 
                                        pointSTL[2].X, pointSTL[2].Y, pointSTL[2].Z)
                });
                return listTransformedTriangle;
            }

            if (pointSTL0[0].Z == pointSTL0[1].Z)
            {
                h1 = proc.Length(pointSTL0[0], pointSTL0[1]);
                h2 = 0f;
                listTransformedTriangle.Add(new TransformedTriangle() { Z1 = pointSTL0[0].Z, H1 = h1, Z2 = pointSTL0[2].Z, H2 = h2, ZN = zn, S = 0 });
                return listTransformedTriangle;
            }

            if (pointSTL0[1].Z == pointSTL0[2].Z)
            {
                h1 = 0f;
                h2 = proc.Length(pointSTL0[1], pointSTL0[2]);
                listTransformedTriangle.Add(new TransformedTriangle() { Z1 = pointSTL0[0].Z, H1 = h1, Z2 = pointSTL0[2].Z, H2 = h2, ZN = zn, S = 0 });
                return listTransformedTriangle;
            }

                h1 = 0f;
                PointF p2 = proc.PlaneCrossLine(pointSTL0[0], pointSTL0[2], pointSTL0[1].Z);
                h2 = proc.Length(pointSTL0[1], new Point3D {X = p2.X, Y = p2.Y, Z = pointSTL0[1].Z });
            listTransformedTriangle.Add(new TransformedTriangle() { Z1 = pointSTL0[0].Z, H1 = h1, Z2 = pointSTL0[1].Z, H2 = h2, ZN = zn, S = 0 });
            listTransformedTriangle.Add(new TransformedTriangle() { Z1 = pointSTL0[1].Z, H1 = h2, Z2 = pointSTL0[2].Z, H2 = h1, ZN = zn, S = 0 });
            return listTransformedTriangle;
        }

        /// <summary>
        /// Координата сечения по оси Z
        /// </summary>
        public float CoordinateSectionZ { get; set; }

        /// <summary>
        /// Коэффициент нормали по оси Z (в градусах угла)
        /// </summary>
        public float ZN { get; set; }

        /// <summary>
        /// Площадь части треугольника попавшего в сечение
        /// </summary>
        public float Str { get; set; }

        /// <summary>
        /// Величина погрешности (для определения переменного шага построения)
        /// </summary>
        public float Error { get; set; }
    }

    /// <summary>
    /// Треугольник (координаты по оси Z и высоты H) 
    /// </summary>
    public class TransformedTriangle
    {
        //Первая точка (мин. Z)
        public float Z1;
        public float H1;
        //Вторая точка (макс. Z)
        public float Z2;
        public float H2;
        //Площадь треугольника
        public float S;
        //Нормаль треугольника
        public float ZN;
    }
}
