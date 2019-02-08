using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Список методов определения фрактальной размерности {0 - клеточный, 1 - масштабов }
    /// </summary>
    public enum FractalMethod { cell, scale };

    /// <summary>
    /// Усечение гистограммы плотности распределения
    /// </summary>
    public enum TrimHistogram { no, leftTrim, rightTrim, allTrim };

    /// <summary>
    /// Внутренний/внешний контур
    /// </summary>
    public enum Inout { inside, outer };

    /// <summary>
    /// Справедлива или не справедлива нулевая гипотеза
    /// </summary>
    public enum Validity { no, yes, excluded }

    /// <summary>
    /// Статистические критерии проверки нулевой гипотезы о принадлежности выборки равномерному закону
    /// </summary>
    public enum StatisticalCriterion
    {
        Wilcoxon,
        Chesnokov,
        KruskallWallis,
        MannWhitney,
        WaldWolfowitz,
        Sherman,
        Kimball,
        Moran1,
        Moran2,
        ChengSpiring,
        HegaziGreen,
        Youngs,
        Frosini,
        Greenwoods,
        GreenwoodQuesenberryMiller,
        NeymanBarton1polinom,
        NeymanBarton2polinom,
        NeymanBarton3polinom,
        NeymanBarton4polinom,
        DudevichVanDerMuelen,
        Etropy2,
        Cressi1,
        Cressi2,
        Pardo,
        Schwartzs,
        SarkadiKosika,
        Kolmogorov,
        Coopers,
        KramerMisesSmirnov,
        Watsons,
        AndersonDarling,
        Zhang,
        PearsonsChiSquare
    }
}
