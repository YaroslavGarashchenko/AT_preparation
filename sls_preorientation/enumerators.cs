using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Список методов определения фрактальной размерности {0 - клеточный, 1 - масштабов }
    /// </summary>
    public enum FractalMethod
    {
        cell,
        scale
    };

    /// <summary>
    /// Усечение гистограммы плотности распределения
    /// </summary>
    public enum TrimHistogram
    {
        no,
        leftTrim,
        rightTrim,
        allTrim
    };

    /// <summary>
    /// Внутренний/внешний контур
    /// </summary>
    public enum Inout
    {
        inside,
        outer
    };

    /// <summary>
    /// Справедлива или не справедлива нулевая гипотеза
    /// </summary>
    public enum Validity
    {
        no,
        yes,
        excluded
    };

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
    };

    /// <summary>
    /// Сортировака данных
    /// </summary>
    public enum Sort
    {
        no,
        descending,
        ascending
    };

    /// <summary>
    /// Сортировка моделей по геометрическим их характеристикам
    /// </summary>
    public enum SortModels
    {
        volume,
        spaceFactor,
        meanSizes,
        minSize,
        maxSize
    };

    /// <summary>
    /// Режим размещения изделий в рабочем протсранстве
    /// </summary>
    public enum PlacementMode
    {
        manual,
        random,
        geneticAlgorithm,
        geneticAlgorithmGenomeSize6,
        geneticAlgorithmRationalOrientation,
        autoRelocation
    };

    /// <summary>
    /// Критерий оптимизации размещения изделий
    /// </summary>
    public enum PlacementCriterion
    {
        height,
        spaceFactor,
        fullSpaceFactor,
        emptySpaceFactor,
        countLayers
    };
    
    /// <summary>
    /// Список решаемых задач
    /// </summary>
    public enum SwitchActiveTask
    {
        analizeDecomposing = 0,
        analizeOrientation,
        analizeSlising,
        analizePacking,
        analizeVisual,
        evaluation
    };

    /// <summary>
    /// Вид послойного рассечения
    /// </summary>
    public enum TypeLayering
    {
        no,
        constant,
        simpleVariable,
        variableNoTrim,
        variableTrim
    };
}
