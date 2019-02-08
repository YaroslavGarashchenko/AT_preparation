using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Drawing;
using MSExel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Globalization;

public class Class1
{
    /// <summary>
    /// Распределение объемов воксельной модели
    /// </summary>
    /// <param name="voxModel">воксельная модель</param>
    /// <param name="numX">количество интервалов по оси X</param>
    /// <param name="numY">количество интервалов по оси Y</param>
    /// <param name="numZ">количество интервалов по оси Z</param>
    /// <returns>массив распределения объемов по номерам интервалов</returns>
    public int[, ,] Distribution(List<Base_vox> voxModel, int numX, int numY, int numZ,
                               float Xmin, float Ymin, float Zmin, float Xmax, float Ymax, float Zmax)
    {
        int[, ,] dist = new int[numX, numY, numZ];
        float intXmin, intXmax, intYmin, intYmax, intZmin, intZmax;
        float Xstep = (Xmax - Xmin) / numX;
        float Ystep = (Ymax - Ymin) / numY;
        float Zstep = (Zmax - Zmin) / numZ;

        for (int i = 0; i < numX; i++)
        {
            for (int j = 0; j < numY; j++)
            {
                for (int k = 0; k < numZ; k++)
                {
                    dist[i, j, k] = voxModel.;
                }
            }
        }

        foreach (var item in voxModel)
        {
            for (int i = 0; i < numX; i++)
            {
                intXmin = Xmin + i * Xstep;
                intXmax = Xmin + (i + 1) * Xstep;
                if (item.Xv >= intXmin && item.Xv < intXmax)
                {
                    for (int j = 0; j < numY; j++)
                    {
                        intYmin = Ymin + j * Ystep;
                        intYmax = Ymin + (j + 1) * Ystep;
                        if (item.Yv >= intYmin && item.Yv < intYmax)
                        {
                            for (int k = 0; k < numZ; k++)
                            {
                                intZmin = Zmin + k * Zstep;
                                intZmax = Zmin + (k + 1) * Zstep;

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
    /// Автоматическое размещение моделей в рабочем пространстве (по центру платформы с распределением по высоте) 
    /// </summary>
    /// <param name="massiveListModels">Модели</param>
    /// <param name="PlantSettings">Нстройки</param>
    /// <param name="toolStripProgressBarLocation">Прогрес выполнения</param>
    public void RandPlaced(List<Base_model> massiveListModels, PlantParameters PlantSettings, int limit,
                           ToolStripProgressBar tempProgressBar)
    {
        int i = 0; // Количество проб для нахождения оптимального варианта
        float heightNewPlace = PlantSettings.SafeDistanceBody / 2;
        foreach (var model in massiveListModels)
        {
            MyProcedures procPack = new MyProcedures();
            List<Base_vox> currentVoxels = new List<Base_vox>();
            currentVoxels = procPack.MoveVoxels(model.Voxels,
                 model.TransferX = (PlantSettings.WorkXmin + PlantSettings.WorkXmax - model.SizeX) / 2
                                       - model.CoordinateX - model.TransferX,
                 model.TransferY = (PlantSettings.WorkYmin + PlantSettings.WorkYmax - model.SizeY) / 2
                                       - model.CoordinateY - model.TransferY,
                 model.TransferZ = heightNewPlace - model.CoordinateZ - model.TransferZ);
            heightNewPlace += PlantSettings.SafeDistanceBody + model.SizeZ;
            procPack.ProgressBarRefresh(tempProgressBar, i, massiveListModels.Count());
        }
    }
}
