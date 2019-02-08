using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace PreAddTech
{
    /// <summary>
    /// Форма системных настроек
    /// </summary>
    public partial class SettingSys : Form
    {
        public SettingSys()
        {
            InitializeComponent();
        }
        //
                         
        /// <summary>
        /// Загрузка данных Settings_AT в таблицу настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingSys_Load(object sender, EventArgs e)
        {
            textBoxNumPar.Text = SettingsUser.Default.Properties.Count.ToString();
            //Заполнение таблицы
            dataGridViewSYS.Rows.Add(
                "Система FoxPro", 
                "FoxProPath", SettingsUser.Default.FoxProPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Программа Book",
                "BookPath", SettingsUser.Default.BookPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Cистема \"Создание триангуляционных моделей\"",
                "Base_TriPath", SettingsUser.Default.Base_TriPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Система \"Морфологический анализ триангуляционных моделей\"",
                "Anal_MorPath", SettingsUser.Default.Anal_MorPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Cистема \"Интегрированные генеративные технологии(классификация технологий, характеристики оборудования)\"",
                "RP_TechnPath", SettingsUser.Default.RP_TechnPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Система \"Статистическое моделирование рабочих процессов интегрированных технологий\"",
                "Stat_Mod", SettingsUser.Default.Stat_Mod, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Программа для просмотра STL",
                "GLC_PlayerPuth", SettingsUser.Default.GLC_PlayerPuth, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
                "Программа Magics", "MagicsPuth", SettingsUser.Default.MagicsPuth, "Путь к файлу");
            //ExcelPath
            dataGridViewSYS.Rows.Add(
                "Программа Excel", "ExcelPath", SettingsUser.Default.ExcelPath, "Путь к файлу");
            //Точность округления координат вершин для операций сравнения
            dataGridViewSYS.Rows.Add(
                "Точность сравнения координат вершин", "RoundingKoord", SettingsUser.Default.RoundingKoord, "float");
            //Точность задания координат по оси Z (дискретность)
            dataGridViewSYS.Rows.Add(
                "Дискретность задания координат по оси Z", "PositionResolution", SettingsUser.Default.PositionResolution, "float");
            //Поддержка многопоточной обработки данных
            dataGridViewSYS.Rows.Add(
                "Многопоточная обработка данных", "Multithreading", SettingsUser.Default.Multithreading, "bool");
            dataGridViewSYS.Rows.Add(
                "Название установки", "NameEquipment", SettingsUser.Default.NameEquipment, "string");
            // Параметры для размещения 3D-моделей изделий в рабочем пространстве
            dataGridViewSYS.Rows.Add(
                "Безопасное расстояние между моделями", "SafeDistanceBody", SettingsUser.Default.SafeDistanceBody, "float");
            dataGridViewSYS.Rows.Add(
                "Безопасное расстояние до границ платформы", "SafeDistanceBorder", SettingsUser.Default.SafeDistanceBorder, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси X рабочей платформы", "WorkXmax", SettingsUser.Default.WorkXmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси X рабочей платформы", "WorkXmin", SettingsUser.Default.WorkXmin, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси Y рабочей платформы", "WorkYmax", SettingsUser.Default.WorkYmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси Y рабочей платформы", "WorkYmin", SettingsUser.Default.WorkYmin, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси Z рабочей платформы", "WorkZmax", SettingsUser.Default.WorkZmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси Z рабочей платформы", "WorkZmin", SettingsUser.Default.WorkZmin, "float");
            dataGridViewSYS.Rows.Add(
                "Высота рабочего пространства установки", "WorkHeight", SettingsUser.Default.WorkHeight, "float");
            dataGridViewSYS.Rows.Add(
                "Длина платформы установки", "WorkLength", SettingsUser.Default.WorkLength, "float");
            dataGridViewSYS.Rows.Add(
                "Ширина платформы установки", "WorkWidth", SettingsUser.Default.WorkWidth, "float");
        }
        /// <summary>
        /// Сохранение изменений настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSYS.Rows.Count; i++)
            {
                try
                {
                    if (dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, i].Value.ToString() == "Путь к файлу" ||
                        dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, i].Value.ToString() == "string" ||
                        dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, i].Value.ToString() == "float")
                    SettingsUser.Default[dataGridViewSYS[dataGridViewSYS.Columns["NamePar"].Index, i].Value.ToString()] =
                        dataGridViewSYS[dataGridViewSYS.Columns["Value"].Index, i].Value.ToString();

                    else if (dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, i].Value.ToString() == "bool")
                        SettingsUser.Default[dataGridViewSYS[dataGridViewSYS.Columns["NamePar"].Index, i].Value.ToString()] =
                            bool.Parse(dataGridViewSYS[dataGridViewSYS.Columns["Value"].Index, i].Value.ToString());
                }
                catch (Exception e6)
                {
                    MessageBox.Show("Недопустимое значение. Возможно отсутствует параметр \n" +
                        e6.Message);
                    return;
                }
            }
            SettingsUser.Default.Save();
            
        }
        /// <summary>
        /// Значения по умолчанию настроек системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDefolt_Click(object sender, EventArgs e)
        {
            dataGridViewSYS.Rows.Clear();
            dataGridViewSYS.Rows.Add(
            "Система FoxPro", "FoxProPath", Settings_AT.Default.FoxProPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Программа Book",
            "BookPath", Settings_AT.Default.BookPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Cистема \"Создание триангуляционных моделей\"",
            "Base_TriPath", Settings_AT.Default.Base_TriPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Система \"Морфологический анализ триангуляционных моделей\"",
            "Anal_MorPath", Settings_AT.Default.Anal_MorPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Cистема \"Интегрированные генеративные технологии(классификация технологий, характеристики оборудования)\"",
            "RP_TechnPath", Settings_AT.Default.RP_TechnPath, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Система \"Статистическое моделирование рабочих процессов интегрированных технологий\"",
            "Stat_Mod", Settings_AT.Default.Stat_Mod, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Программа для просмотра STL",
            "GLC_PlayerPuth", Settings_AT.Default.GLC_PlayerPuth, "Путь к файлу");
            dataGridViewSYS.Rows.Add(
            "Программа Magics", "MagicsPuth", Settings_AT.Default.MagicsPuth, "Путь к файлу");
            //ExcelPath
            dataGridViewSYS.Rows.Add(
            "Программа Excel", "ExcelPath", Settings_AT.Default.ExcelPath, "Путь к файлу");
            //Точность округления координат вершин для операций сравнения
            dataGridViewSYS.Rows.Add(
            "Точность сравнения координат вершин", "RoundingKoord", Settings_AT.Default.RoundingKoord, "float");
            //Точность задания координат по оси Z (дискретность)
            dataGridViewSYS.Rows.Add(
            "Дискретность задания координат по оси Z", "PositionResolution", Settings_AT.Default.PositionResolution, "float");
            //Поддержка многопоточной обработки данных
            dataGridViewSYS.Rows.Add(
            "Многопоточная обработка данных", "Multithreading", Settings_AT.Default.Multithreading, "bool");
            dataGridViewSYS.Rows.Add(
                "Название установки", "NameEquipment", Settings_AT.Default.NameEquipment, "string");
            // Параметры для размещения 3D-моделей изделий в рабочем пространстве
            dataGridViewSYS.Rows.Add(
                "Безопасное расстояние между моделями", "SafeDistanceBody", Settings_AT.Default.SafeDistanceBody, "float");
            dataGridViewSYS.Rows.Add(
                "Безопасное расстояние до границ платформы", "SafeDistanceBorder", Settings_AT.Default.SafeDistanceBorder, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси X рабочей платформы", "WorkXmax", Settings_AT.Default.WorkXmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси X рабочей платформы", "WorkXmin", Settings_AT.Default.WorkXmin, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси Y рабочей платформы", "WorkYmax", Settings_AT.Default.WorkYmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси Y рабочей платформы", "WorkYmin", Settings_AT.Default.WorkYmin, "float");
            dataGridViewSYS.Rows.Add(
                "Максимальная координата по оси Z рабочей платформы", "WorkZmax", Settings_AT.Default.WorkZmax, "float");
            dataGridViewSYS.Rows.Add(
                "Минимальная координата по оси Z рабочей платформы", "WorkZmin", Settings_AT.Default.WorkZmin, "float");
            dataGridViewSYS.Rows.Add(
                "Высота рабочего пространства установки", "WorkHeight", Settings_AT.Default.WorkHeight, "float");
            dataGridViewSYS.Rows.Add(
                "Длина платформы установки", "WorkLength", Settings_AT.Default.WorkLength, "float");
            dataGridViewSYS.Rows.Add(
                "Ширина платформы установки", "WorkWidth", Settings_AT.Default.WorkWidth, "float");
        }
        /// <summary>
        /// Задание пути к файлу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewSYS_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewSYS.Columns["Value"].Index)
            { return; }

            if ( dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, e.RowIndex].Value.ToString() == "Путь к файлу")
            {
                if (openFileDialogSelectFile.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewSYS[e.ColumnIndex, e.RowIndex].Value = openFileDialogSelectFile.FileName;
                }
            }

            if (dataGridViewSYS[dataGridViewSYS.Columns["Type"].Index, e.RowIndex].Value.ToString().Trim() == "bool")
            {
                if (dataGridViewSYS[dataGridViewSYS.Columns["Value"].Index, e.RowIndex].Value.ToString().ToLower() != "true")
                {
                    dataGridViewSYS[dataGridViewSYS.Columns["Value"].Index, e.RowIndex].Value = "true";
                }
                else
                {
                    dataGridViewSYS[dataGridViewSYS.Columns["Value"].Index, e.RowIndex].Value = "false";
                }
            }
        }
    }
}
