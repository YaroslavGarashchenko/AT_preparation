using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using btl.generic;
using System.Threading;
using System.Drawing;

namespace PreAddTech
{
    /// <summary>
    /// Класс процедур размещения изделий в рабочем пространстве установки
    /// </summary>
    class PackProcedures
    {
        /// <summary>
        /// Первичная проверка модели на возможность размещения в рабочем пространстве установки
        /// </summary>
        public bool FirstVerify(Base_model currentModel, PlantParameters PlantSettings)
        {
            float maxSizesPlant = (new float[3]
            { PlantSettings.WorkHeight, PlantSettings.WorkLength, PlantSettings.WorkWidth}).Max();
            //Условия размещения модели в рабочем пространстве установки
            if (currentModel.SizeX > maxSizesPlant || currentModel.SizeY > maxSizesPlant || currentModel.SizeZ > maxSizesPlant)
            {
                MessageBox.Show("Необходимо применить стуктурную обратимую декомпозицию для модели: \n" +
                                currentModel.Name);
                return false;
            }
            else if (currentModel.SizeX > PlantSettings.WorkLength ||
                     currentModel.SizeY > PlantSettings.WorkWidth ||
                     currentModel.SizeZ > PlantSettings.WorkHeight)
            {
                MessageBox.Show("Необходимо поменять ориентацию \n" +
                                "или применить стуктурную обратимую декомпозицию для модели: \n" +
                                currentModel.Name);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Сортировка моделей по заданному критерию
        /// </summary>
        /// <param name="massiveListModels"></param>
        /// <param name="PackingSettings"></param>
        public List<Base_model> SortModels(List<Base_model> massiveListModels, PackingParameters PackingSettings)
        {
            if (PackingSettings.SortDirect == Sort.no)
            {
                return massiveListModels;
            }
            List<Base_model> tempModels = new List<Base_model>();

            switch (PackingSettings.SortCharactModels)
            {
                case PreAddTech.SortModels.volume:
                    if (PackingSettings.SortDirect == Sort.ascending)
                        tempModels = massiveListModels.OrderBy(m => m.Volumе).ToList();
                    else if (PackingSettings.SortDirect == Sort.descending)
                        tempModels = massiveListModels.OrderByDescending(m => m.Volumе).ToList();
                    break;
                case PreAddTech.SortModels.spaceFactor:
                    if (PackingSettings.SortDirect == Sort.ascending)
                        tempModels = massiveListModels.OrderBy(m => m.Volumе / m.SizeX * m.SizeY * m.SizeZ).ToList();
                    else if (PackingSettings.SortDirect == Sort.descending)
                        tempModels = massiveListModels.OrderByDescending(m => m.Volumе / m.SizeX * m.SizeY * m.SizeZ).ToList();
                    break;
                case PreAddTech.SortModels.meanSizes:
                    if (PackingSettings.SortDirect == Sort.ascending)
                        tempModels = massiveListModels.OrderBy(m => m.SizeX + m.SizeY + m.SizeZ).ToList();
                    else if (PackingSettings.SortDirect == Sort.descending)
                        tempModels = massiveListModels.OrderByDescending(m => m.SizeX + m.SizeY + m.SizeZ).ToList();
                    break;
                case PreAddTech.SortModels.minSize:
                    if (PackingSettings.SortDirect == Sort.ascending)
                        tempModels = massiveListModels.OrderBy(m => new float[] { m.SizeX + m.SizeY + m.SizeZ }.Min()).ToList();
                    else if (PackingSettings.SortDirect == Sort.descending)
                        tempModels = massiveListModels.OrderByDescending(m => new float[] { m.SizeX + m.SizeY + m.SizeZ }.Min()).ToList();
                    break;
                case PreAddTech.SortModels.maxSize:
                    if (PackingSettings.SortDirect == Sort.ascending)
                        tempModels = massiveListModels.OrderBy(m => new float[] { m.SizeX + m.SizeY + m.SizeZ }.Max()).ToList();
                    else if (PackingSettings.SortDirect == Sort.descending)
                        tempModels = massiveListModels.OrderByDescending(m => new float[] { m.SizeX + m.SizeY + m.SizeZ }.Max()).ToList();
                    break;
                default:
                    break;
            }
            return tempModels;
        }

        /// <summary>
        /// Форма подсистемы
        /// </summary>
        FormAnalysis frmAnalysis = (FormAnalysis)Application.OpenForms["FormAnalysis"];

        /// <summary>
        /// Автоматическое размещение моделей в рабочем пространстве (по центру платформы с распределением по высоте) 
        /// </summary>
        /// <param name="massiveListModels">Модели</param>
        /// <param name="PlantSettings">Нстройки</param>
        /// <param name="toolStripProgressBarLocation">Прогрес выполнения</param>
        public void AutoPlaced(List<Base_model> massiveListModels, PlantParameters PlantSettings,
                               ToolStripProgressBar tempProgressBar)
        {
            int i = 0;
            float heightNewPlace = PlantSettings.WorkZmin + PlantSettings.SafeDistanceBody;
            foreach (var model in massiveListModels)
            {
                MyProcedures procPack = new MyProcedures();
                List<Base_vox> currentVoxels = new List<Base_vox>();
                currentVoxels = procPack.MoveVoxelsAuto(model.Voxels,
                     model.TransferX = (PlantSettings.WorkXmin + PlantSettings.WorkXmax - model.SizeX) / 2
                                           - model.CoordinateX - model.TransferX,
                     model.TransferY = (PlantSettings.WorkYmin + PlantSettings.WorkYmax - model.SizeY) / 2
                                           - model.CoordinateY - model.TransferY,
                     model.TransferZ = heightNewPlace - model.CoordinateZ - model.TransferZ);
                heightNewPlace += PlantSettings.SafeDistanceBody + model.SizeZ;
                procPack.ProgressBarRefresh(tempProgressBar, ++i, massiveListModels.Count());
            }
        }

        /// <summary>
        /// Визуализация размещения моделей в рабочем пространстве установки
        /// </summary>
        /// <param name="massiveListModels">Модели</param>
        /// <param name="PlantSettings">Настройки</param>
        /// <param name="tempProgressBar">Прогрессс выполнения</param>
        /// <returns></returns>
        public Bitmap[] ShowWorkPlace(List<Base_model> massiveListModels, PlantParameters PlantSettings,
                               float step, ToolStripProgressBar tempProgressBar, Color color0, Color color1)
        {
            int numX = (int)Math.Ceiling(PlantSettings.WorkLength / step),
                numY = (int)Math.Ceiling(PlantSettings.WorkWidth / step),
                numZ = (int)Math.Ceiling(PlantSettings.WorkHeight / step);

            float sizeXvoxel = 0, sizeYvoxel = 0, sizeZvoxel = 0;
            foreach (var model in massiveListModels)
            {
                if (((sizeXvoxel != model.SizeXvoxel) && (sizeXvoxel != 0)) ||
                    ((sizeYvoxel != model.SizeYvoxel) && (sizeYvoxel != 0)) ||
                    ((sizeZvoxel != model.SizeZvoxel) && (sizeZvoxel != 0)))
                {
                    MessageBox.Show("Не одинаковые размеры вокселей для некоторых моделей.", "Проблема...");
                    return null;
                }
                sizeXvoxel = model.SizeXvoxel;
                sizeYvoxel = model.SizeYvoxel;
                sizeZvoxel = model.SizeZvoxel;
            }

            MyProcedures procPack = new MyProcedures();
            List<int[,,]> distSum = new List<int[,,]>();

            foreach (var model in massiveListModels)
            {
                int[,,] distTemp = new MyProcedures().Distribution(model.Voxels, numX, numY, numZ,
                                    PlantSettings.WorkXmin, PlantSettings.WorkYmin, PlantSettings.WorkZmin,
                                    step);
                distSum.Add(distTemp);
            }

            int[,,] dist = new int[numX, numY, numZ]; // Общее распределение вокселей для всех моделей
            int countModel = 0;
            foreach (var distTemp in distSum)
            {
                procPack.ProgressBarRefresh(tempProgressBar, countModel++, distSum.Count() - 1);
                for (int i = 0; i < numX; i++)
                {
                    for (int j = 0; j < numY; j++)
                    {
                        for (int k = 0; k < numZ; k++)
                        {
                            dist[i, j, k] += distTemp[i, j, k];
                        }
                    }
                }
            }
            Bitmap imageZY = new Bitmap(numY, numZ),
                   imageZX = new Bitmap(numX, numZ),
                   imageXY = new Bitmap(numY, numX);
            //imageXY
            //максим.кол-во в интервале
            int maxVoxelsInIntervalXY = (int)(Math.Ceiling(step / sizeXvoxel) *
                                            Math.Ceiling(step / sizeYvoxel) *
                                            Math.Ceiling(numZ * step / sizeZvoxel));
            int[] tRGB = new int[3];

            for (int x = 0; x < numX; x++)
            {
                procPack.ProgressBarRefresh(tempProgressBar, x, numX - 1);
                for (int y = 0; y < numY; y++)
                {
                    int tempZ = 0;
                    for (int z = 0; z < numZ; z++)
                    { tempZ += dist[x, y, z]; }
                    int h = imageXY.Height - 1;
                    tRGB = procPack.ColorElementLineGarmonic(tempZ, 0, maxVoxelsInIntervalXY,
                                                    color0.R, color0.G, color0.B,
                                                    color1.R, color1.G, color1.B);
                    imageXY.SetPixel(y, h - x, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            //максим.кол-во в интервале
            int maxVoxelsInIntervalXZ = (int)(Math.Ceiling(step / sizeXvoxel) *
                                            Math.Ceiling(step / sizeZvoxel) *
                                            Math.Ceiling(numY * step / sizeYvoxel));
            //
            for (int x = 0; x < numX; x++)
            {
                procPack.ProgressBarRefresh(tempProgressBar, x, numX - 1);
                for (int z = 0; z < numZ; z++)
                {
                    int tempY = 0;
                    for (int y = 0; y < numY; y++)
                    { tempY += dist[x, y, z]; }
                    int h = imageZX.Height - 1;
                    tRGB = procPack.ColorElementLineGarmonic(tempY, 0, maxVoxelsInIntervalXZ,
                                                    color0.R, color0.G, color0.B,
                                                    color1.R, color1.G, color1.B);
                    imageZX.SetPixel(x, h - z, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            //максим.кол-во в интервале
            int maxVoxelsInIntervalZY = (int)(Math.Ceiling(step / sizeXvoxel) *
                                            Math.Ceiling(step / sizeZvoxel) *
                                            Math.Ceiling(numY * step / sizeYvoxel));
            //
            for (int y = 0; y < numY; y++)
            {
                procPack.ProgressBarRefresh(tempProgressBar, y, numY - 1);
                for (int z = 0; z < numZ; z++)
                {
                    int tempX = 0;
                    for (int x = 0; x < numX; x++)
                    { tempX += dist[x, y, z]; }
                    int h = imageZY.Height - 1;
                    tRGB = procPack.ColorElementLineGarmonic(tempX, 0, maxVoxelsInIntervalZY,
                                                    color0.R, color0.G, color0.B,
                                                    color1.R, color1.G, color1.B);
                    imageZY.SetPixel(y, h - z, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            return new Bitmap[3] { imageXY, imageZX, imageZY };
        }

        /// <summary>
        /// Определение корректного размещения моделей в рабочем пространстве установки 
        /// </summary>
        /// <param name="massiveListModels"></param>
        /// <param name="PlantSettings"></param>
        /// <param name="step"></param>
        /// <param name="tempProgressBar"></param>
        /// <returns></returns>
        public object[] VerifyModelsForPlace(List<Base_model> massiveListModels, PlantParameters PlantSettings,
                               float step, ToolStripProgressBar tempProgressBar)
        {
            string message = "";
            bool correctPlace = true;
            if (massiveListModels.Count() == 0)
                return new object[2] { "Нет 3D-моделей для проверки.\n", false };

            foreach (var model in massiveListModels)
            {
                if (model.Voxels.Select(v => v.Xv).Min() < PlantSettings.WorkXmin + PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Xv).Max() > PlantSettings.WorkXmax - PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Yv).Min() < PlantSettings.WorkYmin + PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Yv).Max() > PlantSettings.WorkYmax - PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Zv).Min() < PlantSettings.WorkZmin + PlantSettings.SafeDistanceBody ||
                    model.Voxels.Select(v => v.Zv).Max() > PlantSettings.WorkZmax)
                {
                    message += model.Name + " - выходит за пределы рабочего пространства; \n";
                    correctPlace = false;
                }
            }
            MyProcedures proc = new MyProcedures();

            for (int i = 0; i < massiveListModels.Count(); i++)
            {
                float iXMin = massiveListModels[i].Voxels.Select(v => v.Xv).Min() - PlantSettings.SafeDistanceBody / 2;
                float iYMin = massiveListModels[i].Voxels.Select(v => v.Yv).Min() - PlantSettings.SafeDistanceBody / 2;
                float iZMin = massiveListModels[i].Voxels.Select(v => v.Zv).Min() - PlantSettings.SafeDistanceBody / 2;
                float iXMax = massiveListModels[i].Voxels.Select(v => v.Xv).Max() + PlantSettings.SafeDistanceBody / 2;
                float iYMax = massiveListModels[i].Voxels.Select(v => v.Yv).Max() + PlantSettings.SafeDistanceBody / 2;
                float iZMax = massiveListModels[i].Voxels.Select(v => v.Zv).Max() + PlantSettings.SafeDistanceBody / 2;
                proc.ProgressBarRefresh(tempProgressBar, i, massiveListModels.Count());
                for (int j = i + 1; j < massiveListModels.Count(); j++)
                {
                    float jXMin = massiveListModels[j].Voxels.Select(v => v.Xv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jYMin = massiveListModels[j].Voxels.Select(v => v.Yv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jZMin = massiveListModels[j].Voxels.Select(v => v.Zv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jXMax = massiveListModels[j].Voxels.Select(v => v.Xv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float jYMax = massiveListModels[j].Voxels.Select(v => v.Yv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float jZMax = massiveListModels[j].Voxels.Select(v => v.Zv).Max() + PlantSettings.SafeDistanceBody / 2;
                    if (iXMin <= jXMax && jXMin <= iXMax &&
                        iYMin <= jYMax && jYMin <= iYMax &&
                        iZMin <= jZMax && jZMin <= iZMax)
                    {
                        List<Base_vox> itempVox = massiveListModels[i].Voxels.Where(
                                                 v => v.Xv >= jXMin && v.Xv <= jXMax &&
                                                      v.Yv >= jYMin && v.Yv <= jYMax &&
                                                      v.Zv >= jZMin && v.Zv <= jZMax).ToList();
                        List<Base_vox> jtempVox = massiveListModels[j].Voxels.Where(
                                                 v => v.Xv >= iXMin && v.Xv <= iXMax &&
                                                      v.Yv >= iYMin && v.Yv <= iYMax &&
                                                      v.Zv >= iZMin && v.Zv <= iZMax).ToList();

                        float safeDistanceSquared = PlantSettings.SafeDistanceBody * PlantSettings.SafeDistanceBody;
                        for (int k = 0; k < itempVox.Count(); k++)
                        {
                            for (int m = 0; m < jtempVox.Count(); m++)
                            {
                                if ((itempVox[k].Xv - jtempVox[m].Xv) * (itempVox[k].Xv - jtempVox[m].Xv) +
                                    (itempVox[k].Yv - jtempVox[m].Yv) * (itempVox[k].Yv - jtempVox[m].Yv) +
                                    (itempVox[k].Zv - jtempVox[m].Zv) * (itempVox[k].Zv - jtempVox[m].Zv) < safeDistanceSquared)
                                {
                                    message += massiveListModels[i].Name + " и  \n" +
                                               massiveListModels[j].Name + " \n - имеют общий материал или критически " +
                                               "малое расстояние между изделиями.\n";
                                    correctPlace = false;
                                    m = jtempVox.Count();
                                    k = itempVox.Count();
                                }
                            }
                        }
                    }
                }
            }
            return new object[2] { message, correctPlace };
        }

        /// <summary>
        /// Определение корректного размещения моделей в рабочем пространстве установки 
        /// </summary>
        /// <param name="massiveListModels"></param>
        /// <param name="PlantSettings"></param>
        /// <param name="step"></param>
        /// <param name="tempProgressBar"></param>
        /// <returns></returns>
        public object[] VerifyModelsForPlace(List<Base_model> massiveListModels, PlantParameters PlantSettings)
        {
            string message = "";
            bool correctPlace = true;
            if (massiveListModels.Count() == 0)
                return new object[2] { "Нет 3D-моделей для проверки.\n", false };

            foreach (var model in massiveListModels)
            {
                if (model.Voxels.Select(v => v.Xv).Min() < PlantSettings.WorkXmin + PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Xv).Max() > PlantSettings.WorkXmax - PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Yv).Min() < PlantSettings.WorkYmin + PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Yv).Max() > PlantSettings.WorkYmax - PlantSettings.SafeDistanceBorder ||
                    model.Voxels.Select(v => v.Zv).Min() < PlantSettings.WorkZmin + PlantSettings.SafeDistanceBody ||
                    model.Voxels.Select(v => v.Zv).Max() > PlantSettings.WorkZmax - PlantSettings.SafeDistanceBody)
                {
                    message += model.Name + " - выходит за пределы рабочего пространства; \n";
                    correctPlace = false;
                }
            }
            MyProcedures proc = new MyProcedures();

            for (int i = 0; i < massiveListModels.Count(); i++)
            {
                for (int j = i + 1; j < massiveListModels.Count(); j++)
                {
                    float iXMin = massiveListModels[i].Voxels.Select(v => v.Xv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jXMin = massiveListModels[j].Voxels.Select(v => v.Xv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float iYMin = massiveListModels[i].Voxels.Select(v => v.Yv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jYMin = massiveListModels[j].Voxels.Select(v => v.Yv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float iZMin = massiveListModels[i].Voxels.Select(v => v.Zv).Min() - PlantSettings.SafeDistanceBody / 2;
                    float jZMin = massiveListModels[j].Voxels.Select(v => v.Zv).Min() - PlantSettings.SafeDistanceBody / 2;

                    float jXMax = massiveListModels[j].Voxels.Select(v => v.Xv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float iXMax = massiveListModels[i].Voxels.Select(v => v.Xv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float jYMax = massiveListModels[j].Voxels.Select(v => v.Yv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float iYMax = massiveListModels[i].Voxels.Select(v => v.Yv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float jZMax = massiveListModels[j].Voxels.Select(v => v.Zv).Max() + PlantSettings.SafeDistanceBody / 2;
                    float iZMax = massiveListModels[i].Voxels.Select(v => v.Zv).Max() + PlantSettings.SafeDistanceBody / 2;

                    if (iXMin <= jXMax && jXMin <= iXMax &&
                        iYMin <= jYMax && jYMin <= iYMax &&
                        iZMin <= jZMax && jZMin <= iZMax)
                    {
                        List<Base_vox> itempVox = massiveListModels[i].Voxels.Where(
                                                 v => v.Xv >= jXMin && v.Xv <= jXMax &&
                                                      v.Yv >= jYMin && v.Yv <= jYMax &&
                                                      v.Zv >= jZMin && v.Zv <= jZMax).ToList();
                        List<Base_vox> jtempVox = massiveListModels[j].Voxels.Where(
                                                 v => v.Xv >= iXMin && v.Xv <= iXMax &&
                                                      v.Yv >= iYMin && v.Yv <= iYMax &&
                                                      v.Zv >= iZMin && v.Zv <= iZMax).ToList();

                        float safeDistanceSquared = PlantSettings.SafeDistanceBody * PlantSettings.SafeDistanceBody;
                        for (int k = 0; k < itempVox.Count(); k++)
                        {
                            for (int m = 0; m < jtempVox.Count(); m++)
                            {
                                if ((itempVox[k].Xv - jtempVox[m].Xv) * (itempVox[k].Xv - jtempVox[m].Xv) +
                                    (itempVox[k].Yv - jtempVox[m].Yv) * (itempVox[k].Yv - jtempVox[m].Yv) +
                                    (itempVox[k].Zv - jtempVox[m].Zv) * (itempVox[k].Zv - jtempVox[m].Zv) < safeDistanceSquared)
                                {
                                    message += massiveListModels[i].Name + " и  \n" +
                                               massiveListModels[j].Name + " \n - имеют общий материал или критически " +
                                               "малое расстояние между изделиями.\n";
                                    correctPlace = false;
                                    m = jtempVox.Count();
                                    k = itempVox.Count();
                                }
                            }
                        }
                    }
                }
            }
            return new object[2] { message, correctPlace };
        }

        /// <summary>
        /// Проверка возможности выполнения декомпозиции
        /// </summary>
        /// <param name="model"></param>
        /// <param name="DivisionX"></param>
        /// <param name="DivisionY"></param>
        /// <param name="DivisionZ"></param>
        /// <returns></returns>
        public bool VerifyDecompozition(Base_model model, float DivisionX, float DivisionY, float DivisionZ,
                                        CheckState checkX, CheckState checkY, CheckState checkZ)
        {
            if (checkX == CheckState.Unchecked && checkY == CheckState.Unchecked && checkZ == CheckState.Unchecked &&
                (DivisionX == 0f || DivisionX == 100f) && (DivisionY == 0f || DivisionY == 100f)
                  && (DivisionZ == 0f || DivisionZ == 100f))
            {
                return false;
            }
            else if (checkX == CheckState.Checked &&
                (model.Voxels.Min(v => v.Xv) >= DivisionX || model.Voxels.Max(v => v.Xv) <= DivisionX) &&
                      checkY == CheckState.Checked &&
                (model.Voxels.Min(v => v.Yv) >= DivisionY || model.Voxels.Max(v => v.Yv) <= DivisionY) &&
                      checkZ == CheckState.Checked &&
                (model.Voxels.Min(v => v.Zv) >= DivisionZ || model.Voxels.Max(v => v.Zv) <= DivisionZ)
                )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Процедура декомпозиции модели путем рассечения заданными плоскостями
        /// </summary>
        /// <param name="model"></param>
        /// <param name="DivisionX"></param>
        /// <param name="DivisionY"></param>
        /// <param name="DivisionZ"></param>
        /// <param name="checkX"></param>
        /// <param name="checkY"></param>
        /// <param name="checkZ"></param>
        /// <returns></returns>
        public List<Base_model> Decomposition(Base_model model, float DivisionX, float DivisionY, float DivisionZ,
                                        CheckState checkX, CheckState checkY, CheckState checkZ)
        {
            List<Base_model> listModel = new List<Base_model>();
            listModel.Add(model);
            float cutX, cutY, cutZ;
            //Пересчет относительных координат в абсолютные
            if (checkX == CheckState.Unchecked)
            {
                cutX = model.CoordinateX + model.TransferX + DivisionX * model.SizeX / 100;
            }
            else
            {
                cutX = DivisionX;
            }
            if (checkY == CheckState.Unchecked)
            {
                cutY = model.CoordinateY + model.TransferY + DivisionY * model.SizeY / 100;
            }
            else
            {
                cutY = DivisionY;
            }
            if (checkZ == CheckState.Unchecked)
            {
                cutZ = model.CoordinateZ + model.TransferZ + DivisionZ * model.SizeZ / 100;
            }
            else
            {
                cutZ = DivisionZ;
            }
            // Разделение плоскостью заданной по оси X
            if (model.Voxels.Count(v => v.Xv < cutX) != 0 && model.Voxels.Count(v => v.Xv > cutX) != 0)
            {
                listModel[listModel.Count - 1].Information += "\n Модель получена в результате рассечения плоскостью" +
                    "заданной по оси X: " + cutX + " \n";
                listModel[listModel.Count - 1].Voxels = model.Voxels.Where(v => v.Xv < cutX).ToList();
                listModel.Add(model);
                listModel[listModel.Count - 1].Information += "\n Модель получена в результате рассечения плоскостью" +
                    "заданной по оси X: " + cutX + " \n";
                listModel[listModel.Count - 1].Voxels = model.Voxels.Where(v => v.Xv >= cutX).ToList();
            }
            int limitY = listModel.Count();
            for (int i = 0; i < limitY; i++)
            {
                if (listModel[i].Voxels.Count(v => v.Yv < cutY) != 0 && listModel[i].Voxels.Count(v => v.Yv > cutY) != 0)
                {
                    listModel.Add(listModel[i]);
                    listModel[listModel.Count - 1].Information += "\n Модель получена в результате рассечения плоскостью" +
                        "заданной по оси Y: " + cutY + " \n";
                    listModel[listModel.Count - 1].Voxels = listModel[i].Voxels.Where(v => v.Yv < cutY).ToList();
                    List<Base_vox> tempVox = listModel[i].Voxels.Where(v => v.Yv >= cutY).ToList();
                    listModel[i].Information += "\n Модель получена в результате рассечения плоскостью" +
                        "заданной по оси Y: " + cutY + " \n";
                    listModel[i].Voxels = tempVox;
                }
            }
            int limitZ = listModel.Count();
            for (int i = 0; i < limitZ; i++)
            {
                if (listModel[i].Voxels.Count(v => v.Zv < cutZ) != 0 && listModel[i].Voxels.Count(v => v.Zv > cutZ) != 0)
                {
                    listModel.Add(listModel[i]);
                    listModel[listModel.Count - 1].Information += "\n Модель получена в результате рассечения плоскостью" +
                        "заданной по оси Z: " + cutZ + " \n";
                    listModel[listModel.Count - 1].Voxels = listModel[i].Voxels.Where(v => v.Zv < cutZ).ToList();
                    List<Base_vox> tempVox = listModel[i].Voxels.Where(v => v.Zv >= cutZ).ToList();
                    listModel[i].Information += "\n Модель получена в результате рассечения плоскостью" +
                        "заданной по оси Z: " + cutZ + " \n";
                    listModel[i].Voxels = tempVox;
                }
            }
            return listModel;
        }

        /// <summary>
        /// Процедура булевого отнимания от воксельной модели заданной второй модели
        /// </summary>
        /// <param name="baseModel"></param>
        /// <param name="cutModel"></param>
        /// <returns></returns>
        public List<Base_vox> Decomposition(Base_model baseModel, Base_model cutModel)
        {
            List<Base_vox> model = new List<Base_vox>();
            foreach (var voxel in baseModel.Voxels)
            {
                if (cutModel.Voxels.Count(v => v.Xv - voxel.Xv < v.SizeX &&
                                               v.Yv - voxel.Yv < v.SizeY &&
                                               v.Zv - voxel.Zv < v.SizeZ) == 0)
                {
                    model.Add(voxel);
                }
            }
            return model;
        }

        /// <summary>
        /// Автоматическое размещение моделей в рабочем пространстве по методу Монте-Карло 
        /// </summary>
        /// <param name="massiveListModels">Модели</param>
        /// <param name="PlantSettings">Нстройки</param>
        /// <param name="limit">Наибольшее количество вариантов размещения</param>
        /// <param name="numSearch">Наибольшее количество попыток размещения модели</param>
        /// <param name="toolStripProgressBarLocation">Прогрес выполнения</param>
        public void RandomPlaced(List<Base_model> massiveListModels, PlantParameters PlantSettings,
                                  PackingParameters packingParams, PackingAnalisys analisys, ToolStripProgressBar tempProgressBar)
        {
            MyProcedures proc = new MyProcedures();
            List<Base_VarPacking> variants = new List<Base_VarPacking>();
            float heightMinPlace = PlantSettings.WorkZmin + PlantSettings.SafeDistanceBody;
            for (int i = 0; i < packingParams.NumVariants; i++) // Варианты размещения всех моделей
            {
                Base_VarPacking variant = new Base_VarPacking() { Models = new List<Base_model>() };
                foreach (var model in massiveListModels)
                {
                    Random r = new Random();
                    float transferZ = heightMinPlace - model.Voxels.Select(v => v.Zv).Min();
                    if (variant.Models.Count() == 0)
                    {
                        variant.Models.Add(MoveRandomVoxelModel(model, PlantSettings, transferZ));
                        continue;
                    }
                    int j = 0;
                    List<Base_model> searchPlace = new List<Base_model>();
                    Base_model modelTemp = model;
                    do
                    {
                        searchPlace.Clear();
                        modelTemp = MoveRandomVoxelModel(modelTemp, PlantSettings, transferZ);

                        if (j++ >= packingParams.NumTimesFreeSpace)
                        {
                            j = 0;
                            transferZ = modelTemp.SizeZvoxel;
                            if (PlantSettings.WorkZmax < modelTemp.Voxels.Select(v => v.Zv).Max())
                            {
                                frmAnalysis.richTextBoxLocationInfo.Text += "\n  Не удалось разместить 3D-модель:\n" + model.Name + "\n";
                                break;
                            }
                        }
                        else
                        {
                            transferZ = 0;
                        }
                        searchPlace.AddRange(variant.Models);
                        searchPlace.Add(modelTemp);
                    } while (!(bool)VerifyModelsForPlace(searchPlace, PlantSettings)[1]);
                    if (searchPlace.Count() != 0)
                        variant.Models = searchPlace;
                }
                proc.ProgressBarRefresh(tempProgressBar, i, packingParams.NumVariants - 1);
                variants.Add(variant);
            }
            for (int k = 0; k < variants.Count(); k++)
            {
                switch (packingParams.Criterion)
                {
                    case PlacementCriterion.height:
                        variants[k].ValueCriterion = HeightBuilding(variants[k].Models, PlantSettings);
                        break;
                    case PlacementCriterion.spaceFactor:
                        variants[k].ValueCriterion = SpaceFactor(variants[k].Models, PlantSettings);
                        break;
                    case PlacementCriterion.fullSpaceFactor:
                        variants[k].ValueCriterion = FullSubSpaceFactor(variants[k].Models, PlantSettings,
                                                   analisys.LimitFullSubSpace, analisys.NumXSubSpace,
                                                   analisys.NumYSubSpace, analisys.NumZSubSpace, tempProgressBar);
                        break;
                    case PlacementCriterion.emptySpaceFactor:
                        variants[k].ValueCriterion = EmptySubSpaceFactor(variants[k].Models, PlantSettings,
                                                     analisys.LimitEmptySubSpace, analisys.NumXSubSpace,
                                                     analisys.NumYSubSpace, analisys.NumZSubSpace, tempProgressBar);
                        break;
                    case PlacementCriterion.countLayers:
                        unionListStl = UnionListSTL(variants[k].Models);
                        variants[k].ValueCriterion = CountLayersBuild(unionListStl, TypeLayering.variableTrim,
                                                                       analisys.StepMin, analisys.StepMax, analisys.ErrorMax,
                                                                       analisys.ValueTruncatedDistribution, tempProgressBar);
                        break;
                    default:
                        break;
                }
            }

            if (packingParams.Criterion == PlacementCriterion.height ||
                packingParams.Criterion == PlacementCriterion.emptySpaceFactor ||
                packingParams.Criterion == PlacementCriterion.countLayers)
            {
                massiveListModels = variants.Where(v => v.ValueCriterion == variants.Select(vc => vc.ValueCriterion).Min()).
                                    First().Models;
            }
            else
            {
                massiveListModels = variants.Where(v => v.ValueCriterion == variants.Select(vc => vc.ValueCriterion).Max()).
                                    First().Models;
            }
        }
        /// <summary>
        /// Процедура перемещения воксельной модели (XY-Random)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="PlantSettings"></param>
        /// <returns></returns>
        Base_model MoveRandomVoxelModel(Base_model model, PlantParameters PlantSettings, float transferZ)
        {
            MyProcedures proc = new MyProcedures();
            Random r = new Random();
            float Xmin = PlantSettings.WorkXmin - model.Voxels.Select(v => v.Xv).Min();
            float Xmax = PlantSettings.WorkXmax - model.Voxels.Select(v => v.Xv).Max();
            float Ymin = PlantSettings.WorkYmin - model.Voxels.Select(v => v.Yv).Min();
            float Ymax = PlantSettings.WorkYmax - model.Voxels.Select(v => v.Yv).Max();
            float transferX = Xmin + (Xmax - Xmin) * (float)r.NextDouble();
            float transferY = Ymin + (Ymax - Ymin) * (float)r.NextDouble();
            model.Voxels = proc.MoveVoxels(model.Voxels, transferX, transferY, transferZ);
            model.TransferX += transferX;
            model.TransferY += transferY;
            model.TransferZ += transferZ;
            return model;
        }

        /// <summary>
        /// Сообщение о результатах рассчетов
        /// </summary>
        public string mess;

        /// <summary>
        /// Варианты размещения при эволюционной оптимизации
        /// </summary>
        public List<Base_VarPacking> variantsGenAlg = new List<Base_VarPacking>();

        /// <summary>
        /// Список моделей (исходный)
        /// </summary>
        private static List<Base_model> listModels = new List<Base_model>();

        /// <summary>
        /// Координаты перемещения текущей модели
        /// </summary>
        private static double[] coordMove = new double[3];
        /// <summary>
        /// Углы вращения текущей модели
        /// </summary>
        private static double[] angleRotate = new double[3];

        /// <summary>
        /// Номер текущей модели
        /// </summary>
        private static int numCurrentModel;
        /// <summary>
        /// Текущая величина перемещения модели по оси X (отрицательная)
        /// </summary>
        private static float Xnegative;
        /// <summary>
        /// Текущая величина перемещения модели по оси X (положительная)
        /// </summary>
        private static float Xpositive;
        /// <summary>
        /// Текущая величина перемещения модели по оси Y (отрицательная)
        /// </summary>
        private static float Ynegative;
        /// <summary>
        /// Текущая величина перемещения модели по оси Y (положительная)
        /// </summary>
        private static float Ypositive;
        /// <summary>
        /// Текущая величина перемещения модели по оси Z (отрицательная)
        /// </summary>
        private static float Znegative;
        /// <summary>
        /// Текущая величина перемещения модели по оси Z (положительная)
        /// </summary>
        private static float Zpositive;

        /// <summary>
        /// Автоматическое размещение моделей в рабочем пространстве c генетическим алгоритмом 
        /// </summary>
        /// <param name="massiveListModels">Модели</param>
        /// <param name="PlantSettings">Нстройки</param>
        /// <param name="limit">Наибольшее количество вариантов размещения</param>
        /// <param name="toolStripProgressBarLocation">Прогрес выполнения</param>
        public void GeneticPlaced(List<Base_model> massiveListModels, PlantParameters settings,
                                   PackingParameters parametres, PackingAnalisys analisys,
                                   ToolStripProgressBar tempProgressBar)
        {
            MyProcedures proc = new MyProcedures();
            PackProcedures pakProc = new PackProcedures();
            float heightMinPlace = settings.WorkZmin + settings.SafeDistanceBody;
            packingParams = parametres;
            plantSettings = settings;
            pAnalisys = analisys;
            AutoPlaced(massiveListModels, settings, tempProgressBar);
            listModels = massiveListModels;
            for (int i = 0; i < listModels.Count(); i++)
            {
                numCurrentModel = i;
                pakProc.LimitMoveVoxelModel(i);
                pakProc.MoveGeneticVoxelModel(i);
                massiveListModels[i].Voxels = proc.MoveVoxels(proc.RotationVoxels( listModels[i].Voxels, 
                                              (float)angleRotate[0], (float)angleRotate[1], (float)angleRotate[2]),
                                                               (float)coordMove[0], (float)coordMove[1], (float)coordMove[2]);
                massiveListModels[i].TransferX += (float)coordMove[0];
                massiveListModels[i].TransferY += (float)coordMove[1];
                massiveListModels[i].TransferZ += (float)coordMove[2];
                massiveListModels[i].RotationX += (float)angleRotate[0];
                massiveListModels[i].RotationY += (float)angleRotate[1];
                massiveListModels[i].RotationZ += (float)angleRotate[2];
                proc.ProgressBarRefresh(tempProgressBar, i + 1, massiveListModels.Count());
            }
        }

        /// <summary>
        /// Определение предельных перемещений модели в рабочем пространстве
        /// </summary>
        /// <param name="m">Номер модели в массиве</param>
        private void LimitMoveVoxelModel(int m)
        {
            Xnegative = plantSettings.WorkXmin + plantSettings.SafeDistanceBorder - listModels[m].Voxels.Select(v => v.Xv).Min();
            Xpositive = plantSettings.WorkXmax - plantSettings.SafeDistanceBorder - listModels[m].Voxels.Select(v => v.Xv).Max();
            Ynegative = plantSettings.WorkYmin + plantSettings.SafeDistanceBorder - listModels[m].Voxels.Select(v => v.Yv).Min();
            Ypositive = plantSettings.WorkYmax - plantSettings.SafeDistanceBorder - listModels[m].Voxels.Select(v => v.Yv).Max();
            Znegative = plantSettings.WorkZmin + plantSettings.SafeDistanceBody - listModels[m].Voxels.Select(v => v.Zv).Min();
            Zpositive = plantSettings.WorkZmax - plantSettings.SafeDistanceBody - listModels[m].Voxels.Select(v => v.Zv).Max();
        }

        /// <summary>
        /// Процедура перемещения воксельной модели (XYZ-Genetic)
        /// </summary>
        /// <param name="m">Номер модели в массиве</param>
        /// <returns></returns>
        public void MoveGeneticVoxelModel(int m)
        {
            GA ga = new GA(packingParams.CrossoverRate, packingParams.MutationRate, packingParams.PopulationSize,
                           packingParams.GenerationSize, packingParams.GenomeSize);

            ga.FitnessFunction = new GAFunction(GeneticFunction);
            ga.FitnessFile = Application.StartupPath + @"\Data\fitness.csv";
            ga.Elitism = true;
            ga.Go();
            ga.GetBest(out double[] values, out double fitness);
            mess = string.Format("Best ({0}):", fitness);
            for (int i = 0; i < values.Length; i++)
                mess += string.Format("\n{0} ", values[i]);
            ga.GetWorst(out values, out fitness);
            mess += string.Format("\nWorst ({0}):", fitness);
            for (int i = 0; i < values.Length; i++)
                mess += string.Format("\n{0} ", values[i]);
            frmAnalysis.richTextBoxLocationInfo.Text += "\n Прогрес выполнения генетического алгоритма: \n" + mess + "\n";
        }

        private static PlantParameters plantSettings;
        private static PackingParameters packingParams;
        private static PackingAnalisys pAnalisys;

        /// <summary>
        /// Определение количества вокселей попавших за пределы рабочего пространства или наехавших на другие модели
        /// </summary>
        /// <param name="model"></param>
        /// <param name="plantSettings"></param>
        /// <param name="packingParams"></param>
        /// <returns></returns>
        int NumVoxelWork(List<Base_vox> VoxModel, PlantParameters plantSettings, PackingParameters packingParams)
        {
            if(VoxModel.Count() == 0)
                return int.MinValue;
            
            // Количество вокселей в пределах рабочего пространства 
            int numVoxIn = VoxModel.Count(v => v.Xv > plantSettings.WorkXmin + plantSettings.SafeDistanceBorder &
                                                    v.Xv < plantSettings.WorkXmax - plantSettings.SafeDistanceBorder &&
                                                    v.Yv > plantSettings.WorkYmin + plantSettings.SafeDistanceBorder &&
                                                    v.Yv < plantSettings.WorkYmax - plantSettings.SafeDistanceBorder &&
                                                    v.Zv > plantSettings.WorkZmin + plantSettings.SafeDistanceBody &&
                                                    v.Zv < plantSettings.WorkZmax);
            //int numVoxCommon = 0;
            float iXMin = VoxModel.Select(v => v.Xv).Min() - plantSettings.SafeDistanceBody / 2;
            float iYMin = VoxModel.Select(v => v.Yv).Min() - plantSettings.SafeDistanceBody / 2;
            float iZMin = VoxModel.Select(v => v.Zv).Min() - plantSettings.SafeDistanceBody / 2;
            float iXMax = VoxModel.Select(v => v.Xv).Max() + plantSettings.SafeDistanceBody / 2;
            float iYMax = VoxModel.Select(v => v.Yv).Max() + plantSettings.SafeDistanceBody / 2;
            float iZMax = VoxModel.Select(v => v.Zv).Max() + plantSettings.SafeDistanceBody / 2;
            for (int j = 0; j < numCurrentModel; j++)
            {
                float jXMin = listModels[j].Voxels.Select(v => v.Xv).Min() - plantSettings.SafeDistanceBody / 2;
                float jYMin = listModels[j].Voxels.Select(v => v.Yv).Min() - plantSettings.SafeDistanceBody / 2;
                float jZMin = listModels[j].Voxels.Select(v => v.Zv).Min() - plantSettings.SafeDistanceBody / 2;
                float jXMax = listModels[j].Voxels.Select(v => v.Xv).Max() + plantSettings.SafeDistanceBody / 2;
                float jYMax = listModels[j].Voxels.Select(v => v.Yv).Max() + plantSettings.SafeDistanceBody / 2;
                float jZMax = listModels[j].Voxels.Select(v => v.Zv).Max() + plantSettings.SafeDistanceBody / 2;
                if (iXMin <= jXMax && jXMin <= iXMax &&
                    iYMin <= jYMax && jYMin <= iYMax &&
                    iZMin <= jZMax && jZMin <= iZMax)
                {
                    List<Base_vox> itempVox = listModels[j].Voxels.Where(
                                                 v => v.Xv >= jXMin && v.Xv <= jXMax &&
                                                      v.Yv >= jYMin && v.Yv <= jYMax &&
                                                      v.Zv >= jZMin && v.Zv <= jZMax).ToList();
                    List<Base_vox> jtempVox = listModels[j].Voxels.Where(
                                                 v => v.Xv >= iXMin && v.Xv <= iXMax &&
                                                      v.Yv >= iYMin && v.Yv <= iYMax &&
                                                      v.Zv >= iZMin && v.Zv <= iZMax).ToList();
                    float safeDistanceSquared = plantSettings.SafeDistanceBody * plantSettings.SafeDistanceBody;
                    for (int k = 0; k < itempVox.Count(); k++)
                    {
                        for (int m = 0; m < jtempVox.Count(); m++)
                        {
                            if ((itempVox[k].Xv - jtempVox[m].Xv) * (itempVox[k].Xv - jtempVox[m].Xv) +
                                (itempVox[k].Yv - jtempVox[m].Yv) * (itempVox[k].Yv - jtempVox[m].Yv) +
                                (itempVox[k].Zv - jtempVox[m].Zv) * (itempVox[k].Zv - jtempVox[m].Zv) < safeDistanceSquared)
                            {
                                //numVoxCommon++;
                                //break;
                                return 0;
                            }
                        }
                    }
                }
            }
            return numVoxIn;
        }

        /// <summary>
        /// Оптимизируемая функция
        /// </summary>
        /// <param name="values">Массив параметров</param>
        /// <returns></returns>
        public static double GeneticFunction(double[] values)
        {
            float X = (float)values[0] * (Xpositive - Xnegative) + Xnegative;
            float Y = (float)values[1] * (Ypositive - Ynegative) + Ynegative;
            float Z = (float)values[2] * (Zpositive - Znegative) + Znegative;
            float angleX = 0;
            float angleY = 0;
            float angleZ = 0;
            PackProcedures pakProc = new PackProcedures();
            List<Base_vox> voxTemp = new List<Base_vox>();
            //RotationVoxels
            if (values.GetLength(0) == 3)
            {
                voxTemp = new MyProcedures().MoveVoxels(listModels[numCurrentModel].Voxels, X, Y, Z);
            }
            else if (values.GetLength(0) == 6)
            {
                int intervalAngle = 360;
                angleX = (float)values[3] * intervalAngle;
                angleY = (float)values[4] * intervalAngle;
                angleZ = (float)values[5] * intervalAngle;
                voxTemp = new MyProcedures().MoveVoxels(
                          new MyProcedures().RotationVoxels(listModels[numCurrentModel].Voxels, angleX, angleY, angleZ), X, Y, Z);
            }
            else
            {
                MessageBox.Show("Размер генома не соответствует требованиям расчета","Проблема...");
            }
            //Величина критерия по количеству вокселей не попавших за пределы рабочего пространства 
            // или наехавших на другие модели
            double valueCriterion = pakProc.NumVoxelWork(voxTemp, plantSettings, packingParams);
            coordMove = new double[3] { X, Y, Z };
            angleRotate = new double[3] { angleX, angleY, angleZ };
            List<Base_model> tempModel = new List<Base_model>();
            tempModel.Add(new Base_model() { Voxels = voxTemp });
            //
            // 15/07/2019
            // Нужно добавить влияние координат X и Y 
            //
            switch (packingParams.Criterion)
            {
                case PlacementCriterion.height:
                        valueCriterion += packingParams.Magnitude * voxTemp.Count() *
                                          (plantSettings.WorkHeight - pakProc.HeightBuilding(voxTemp, plantSettings));
                break;
                case PlacementCriterion.spaceFactor:
                        valueCriterion += packingParams.Magnitude * voxTemp.Count() *
                                          pakProc.SpaceFactor(tempModel, plantSettings);
                break;
                case PlacementCriterion.fullSpaceFactor:
                        valueCriterion += packingParams.Magnitude * voxTemp.Count() *
                                          pakProc.FullSubSpaceFactor(tempModel, plantSettings, pAnalisys.LimitFullSubSpace, 
                                          pAnalisys.NumXSubSpace, pAnalisys.NumYSubSpace, pAnalisys.NumZSubSpace,
                                          pakProc.frmAnalysis.toolStripProgressBarLocation);
                break;
                case PlacementCriterion.emptySpaceFactor:
                        valueCriterion += packingParams.Magnitude * voxTemp.Count() *
                                          pakProc.EmptySubSpaceFactor(tempModel, plantSettings, pAnalisys.LimitEmptySubSpace, pAnalisys.NumXSubSpace, 
                                          pAnalisys.NumYSubSpace, pAnalisys.NumZSubSpace, pakProc.frmAnalysis.toolStripProgressBarLocation);
                break;
                case PlacementCriterion.countLayers:
                        valueCriterion += packingParams.Magnitude * voxTemp.Count() *
                                          (1 - pakProc.CountLayersBuild(pakProc.UnionListSTL(tempModel), TypeLayering.variableTrim,
                                          pAnalisys.StepMin, pAnalisys.StepMax, pAnalisys.ErrorMax, pAnalisys.ValueTruncatedDistribution,
                                          pakProc.frmAnalysis.toolStripProgressBarLocation) /
                                          (plantSettings.WorkHeight / pAnalisys.StepMin));
                break;
                default:
                break;
            }
            return valueCriterion;
        }

        /// <summary>
        /// Анализ размещенных моделей в рабочем пространстве устаноки
        /// </summary>
        /// <param name="unionListStl">Модель объединенная</param>
        /// <param name="PlantSettings">Параметры установки</param>
        /// <param name="tempProgressBar">Панель прогресса выполнения</param>
        /// <returns></returns>
        public string PackingAnalysis(List<Base_model> massiveListModels, List<Base_stl> unionListStl, 
                                      PlantParameters PlantSettings, PackingAnalisys analisys, 
                                      ToolStripProgressBar tempProgressBar)
        {
            string messageAnalysis = string.Format("Высота построения: {0} ;\n" +
                                             "Коэффициент использования рабочего пространства: {1} ;\n" +
                                             "Коэффициент использования рабочего пространства по количеству " +
                                             "подпространств заполненных больше {4}%: {2} ;\n" +
                                             "по количеству подпространств заполненных менее или равных {5}%: {3}.\n", 
                                             HeightBuilding(massiveListModels, PlantSettings).ToString("### ##0.0#"),
                                             SpaceFactor(massiveListModels, PlantSettings).ToString("0.000#"),
                                             FullSubSpaceFactor(massiveListModels, PlantSettings, 
                                             analisys.LimitFullSubSpace, analisys.NumXSubSpace, analisys.NumYSubSpace,
                                             analisys.NumZSubSpace, tempProgressBar),
                                             EmptySubSpaceFactor(massiveListModels, PlantSettings, 
                                             analisys.LimitEmptySubSpace,
                                             analisys.NumXSubSpace, analisys.NumYSubSpace,
                                             analisys.NumZSubSpace, tempProgressBar), analisys.LimitFullSubSpace * 100,
                                             analisys.LimitEmptySubSpace * 100);

            messageAnalysis += "Параметры анализа: \n" +
                               "NumXSubSpace = " + analisys.NumXSubSpace + "; \n" +
                               "NumYSubSpace = " + analisys.NumYSubSpace + "; \n" + 
                               "NumZSubSpace = " + analisys.NumZSubSpace + "; \n" +
                               "StepMin = " + analisys.StepMin + "; \n" +
                               "StepMax = " + analisys.StepMax + "; \n" +
                               "ErrorMax = " + analisys.ErrorMax + "; \n" +
                               "ValueTruncatedDistribution = " + analisys.ValueTruncatedDistribution + "; \n";

            for (int i = 0; i < analisys.Layering.Length; i++)
            {
                if (analisys.Layering[i] != TypeLayering.no)
                messageAnalysis += string.Format("Количество слоев построения ( стратегия {0}): {1} .\n", 
                               analisys.Layering[i].ToString(), CountLayersBuild(unionListStl,
                               analisys.Layering[i], analisys.StepMin, analisys.StepMax, analisys.ErrorMax, 
                               analisys.ValueTruncatedDistribution, tempProgressBar));
            }
            return "\n" + messageAnalysis;
        }

        /// <summary>
        /// Определение высоты построения
        /// </summary>
        /// <param name="massiveListModels">Массив моделей</param>
        /// <returns></returns>
        public float HeightBuilding(List<Base_model> massiveListModels, PlantParameters PlantSettings)
        {
            float result = massiveListModels.Select(m => m.Voxels).Select(v => v.Max(vmax => vmax.Zv)).Max() - PlantSettings.WorkZmin;
            return result;
        }
        /// <summary>
        /// Определение высоты построения
        /// </summary>
        /// <param name="massiveListModels">Массив моделей</param>
        /// <returns></returns>
        public float HeightBuilding(List<Base_vox> models, PlantParameters PlantSettings)
        {
            float result = models.Select(v => v.Zv).Max() - PlantSettings.WorkZmin;
            return result;
        }

        /// <summary>
        /// Определение коэффициента использования рабочего пространства 
        /// </summary>
        /// <param name="massiveListModels">Массив моделей</param>
        /// <param name="PlantSettings">Параметры установки</param>
        /// <returns></returns>
        public float SpaceFactor(List<Base_model> massiveListModels, PlantParameters PlantSettings)
        {
            return massiveListModels.Select(m => m.Volumе).Sum() / PlantSettings.WorkLength
                           / PlantSettings.WorkWidth / HeightBuilding(massiveListModels, PlantSettings);
        }

        /// <summary>
        /// Определение коэффициента использования рабочего пространства по количеству заполненных подпространств 
        /// </summary>
        /// <param name="massiveListModels">Массив моделей</param>
        /// <param name="PlantSettings">Параметры установки</param>
        /// <param name="fullLimit">Минимальное относительное количество определяющее полное подпространство</param>
        /// <param name="numX">количество подпространств по оси X</param>
        /// <param name="numY">количество подпространств по оси Y</param>
        /// <param name="numZ">количество подпространств по оси Z</param>
        /// <returns></returns>
        public float FullSubSpaceFactor(List<Base_model> massiveListModels, PlantParameters PlantSettings, float fullLimit,
                                 int numX, int numY, int numZ, ToolStripProgressBar tempProgressBar)
        {
            List<Base_vox> sumVox = new List<Base_vox>();
            for (int i = 0; i < massiveListModels.Count(); i++)
            {
                sumVox.AddRange(massiveListModels[i].Voxels);
            }
            int[,,] distVox = new MyProcedures().Distribution(sumVox, numX, numY, numZ, PlantSettings.WorkXmin,
                PlantSettings.WorkYmin, PlantSettings.WorkZmin, PlantSettings.WorkXmax,
                PlantSettings.WorkYmax, sumVox.Select(v => v.Zv).Max(), tempProgressBar);
            int fullSubSpace = 0;
            foreach (var item in distVox)
            {
                fullSubSpace += item >= fullLimit ? 1 : 0;
            }
            return fullSubSpace / (float)distVox.Length;
        }

        /// <summary>
        /// Определение коэффициента использования рабочего пространства по количеству пустых подпространств 
        /// </summary>
        /// <param name="massiveListModels">Массив моделей</param>
        /// <param name="PlantSettings">Параметры установки</param>
        /// <param name="fullLimit">Минимальное относительное количество определяющее полное подпространство</param>
        /// <param name="numX">количество подпространств по оси X</param>
        /// <param name="numY">количество подпространств по оси Y</param>
        /// <param name="numZ">количество подпространств по оси Z</param>
        /// <returns></returns>
        public float EmptySubSpaceFactor(List<Base_model> massiveListModels, PlantParameters PlantSettings, float emptyLimit,
                                 int numX, int numY, int numZ, ToolStripProgressBar tempProgressBar)
        {
            List<Base_vox> sumVox = new List<Base_vox>();
            for (int i = 0; i < massiveListModels.Count(); i++)
            {
                sumVox.AddRange(massiveListModels[i].Voxels);
            }
            int[,,] distVox = new MyProcedures().Distribution(sumVox, numX, numY, numZ, PlantSettings.WorkXmin,
                PlantSettings.WorkYmin, PlantSettings.WorkZmin, PlantSettings.WorkXmax,
                PlantSettings.WorkYmax, sumVox.Select(v => v.Zv).Max(), tempProgressBar);
            int emptySubSpace = 0;
            foreach (var item in distVox)
            {
                emptySubSpace += item <= emptyLimit ? 1 : 0;
            }
            return emptySubSpace / (float)distVox.Length;
        }

        public List<Base_stl> unionListStl = new List<Base_stl>();
        
        /// <summary>
        /// Объединение несколько STL в один
        /// </summary>
        /// <param name="massiveListModels"></param>
        /// <returns></returns>
        public List<Base_stl> UnionListSTL(List<Base_model> massiveListModels)
        {
            if (unionListStl.Count != 0)
            {
                return unionListStl;
            }
            foreach (var model in massiveListModels)
            {
                List<Base_stl> tempSTL = new MyProcedures().RotationSTL(model);

                for (int i = 0; i < tempSTL.Count; i++)
                {
                    tempSTL[i].X1 += model.TransferX;
                    tempSTL[i].X2 += model.TransferX;
                    tempSTL[i].X3 += model.TransferX;
                    tempSTL[i].Y1 += model.TransferY;
                    tempSTL[i].Y2 += model.TransferY;
                    tempSTL[i].Y3 += model.TransferY;
                    tempSTL[i].Z1 += model.TransferZ;
                    tempSTL[i].Z2 += model.TransferZ;
                    tempSTL[i].Z3 += model.TransferZ;
                }
                unionListStl.AddRange(tempSTL);
            }
            return unionListStl;
        }

        /// <summary>
        /// Определение количества слоев построения
        /// </summary>
        /// <param name="models">Массив моделей</param>
        /// <param name="type">Вид рассечения моделей</param>
        /// <param name="step1">Минимальный шаг построения</param>
        /// <param name="step2">Максимальный шаг построения</param>
        /// <param name="errorMax">Максимально допустимая погрешность построения</param>
        /// <param name="volumTrim">Величина усечения гистограаммы распределения площадей граней</param>
        /// <param name="tempProgressBar">Панель прогресса выполнения</param>
        /// <returns>Количество слоев построения моделей</returns>
        public int CountLayersBuild(List<Base_stl> unionListStl, TypeLayering type, float step1, float step2, float errorMax,
                             float volumTrim, ToolStripProgressBar tempProgressBar)
        {
            if (unionListStl.Count() == 0)
            {
                MessageBox.Show("Выполните сохранение 3D-моделей для послойного анализа", "Проблема, нет базы данных");
            }
            float[] limits = new MyProcedures().LimitModel(unionListStl); // Определение мин. и макс. координат [0] - minZ; [1] - maxZ
            List<float> coordinateSectionZ = new List<float>(); //Список координат расположения сечений 
            float resolutionZ = float.Parse(SettingsUser.Default.PositionResolution.Replace('.', ',')); // Дискретность по оси Z
            List<float> listStep = new List<float>(); // Список шагов построения
            float tempZ = (float)(resolutionZ * Math.Round(limits[0] / resolutionZ));//Первый слой
            coordinateSectionZ.Add((float)Math.Round(tempZ < limits[0] ? tempZ + resolutionZ : tempZ, 3));
            if (step1 == step2 && type != TypeLayering.constant) return 0;
            List<float> coordinateResolutionZ;
            List<SurfaceSection> listSurfaceSectionAll;
            List<float[]> listStepAndZ;
            switch (type)
            {
                case TypeLayering.constant:
                    float stepConst = step1;
                    while (coordinateSectionZ[coordinateSectionZ.Count() - 1] < limits[1] - stepConst)
                    {
                        coordinateSectionZ.Add(coordinateSectionZ[coordinateSectionZ.Count() - 1] + stepConst);
                    }
                    for (int i = 0; i < coordinateSectionZ.Count(); i++)
                    { listStep.Add(stepConst); }
                    break;
                case TypeLayering.simpleVariable:
                    
                    listStep = new MyProcedures().ListStep(unionListStl, errorMax, limits[1], step1, step2, coordinateSectionZ,
                                            tempProgressBar);
                    break;
                case TypeLayering.variableNoTrim:
                    MyProcedures procNoTrim = new MyProcedures();
                    coordinateResolutionZ = new List<float>() { coordinateSectionZ[0] };
                    //Первоначальный массив координат построения по дискретности задания положения плоскости сечения
                    while (coordinateResolutionZ[coordinateResolutionZ.Count() - 1] < limits[1])
                    { coordinateResolutionZ.Add((float)Math.Round(coordinateResolutionZ[coordinateResolutionZ.Count() - 1] + resolutionZ, 3)); }

                    listSurfaceSectionAll = new List<SurfaceSection>();
                    listSurfaceSectionAll = procNoTrim.ListTTriangle(unionListStl, coordinateResolutionZ, resolutionZ, tempProgressBar);
                    listStepAndZ = procNoTrim.ListStepByResolution(unionListStl, errorMax, coordinateSectionZ[0], limits[1],
                                                                           step1, step2, coordinateResolutionZ,
                                                                           listSurfaceSectionAll, tempProgressBar, resolutionZ,
                                                                           TrimHistogram.no, 0f);
                    coordinateSectionZ = listStepAndZ.Select(i => i[1]).ToList(); // Координаты слоев по оси Z
                    listStep = listStepAndZ.Select(i => i[0]).ToList(); // Шаги построения
                    break;
                case TypeLayering.variableTrim:
                    MyProcedures procTrim = new MyProcedures();
                    coordinateResolutionZ = new List<float>() { coordinateSectionZ[0] };
                    //Первоначальный массив координат построения по дискретности задания положения плоскости сечения
                    while (coordinateResolutionZ[coordinateResolutionZ.Count() - 1] < limits[1])
                    { coordinateResolutionZ.Add((float)Math.Round(coordinateResolutionZ[coordinateResolutionZ.Count() - 1] + resolutionZ, 3)); }

                    listSurfaceSectionAll = new List<SurfaceSection>();
                    listSurfaceSectionAll = procTrim.ListTTriangle(unionListStl, coordinateResolutionZ, resolutionZ, tempProgressBar);
                    listStepAndZ = procTrim.ListStepByResolution(unionListStl, errorMax, coordinateSectionZ[0], limits[1],
                                                                       step1, step2, coordinateResolutionZ,
                                                                       listSurfaceSectionAll, tempProgressBar, resolutionZ,
                                                                       TrimHistogram.allTrim, volumTrim);
                    coordinateSectionZ = listStepAndZ.Select(i => i[1]).ToList(); // Координаты слоев по оси Z
                    listStep = listStepAndZ.Select(i => i[0]).ToList(); // Шаги построения
                    break;
                default:
                    return 0;
            }
            return listStep.Count();
        }
    }
}
