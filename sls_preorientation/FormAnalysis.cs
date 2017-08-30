using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Linq;
using MSExel = Microsoft.Office.Interop.Excel;


namespace PreAddTech
{

    public partial class FormAnalysis : Form
    {
        public FormAnalysis()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int textlength = richTextBox_review.TextLength;
            toolStripComboBox1.ToolTipText = textlength.ToString() + " символов в тексте";
        }
        /// <summary>
        /// Массив моделей
        /// </summary>
        List<base_model> massiveListModels = new List<base_model>();

        /// <summary>
        /// Задача активной формы
        /// </summary>
        public ATPreparation.switchActiveTask activeTask;
        //предварительное количество треугольников
        int countTr = 0;
        /// <summary>
        /// Открытие и просмотр STL файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel_info.Text = "Открытие и просмотр STL-файла";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "STL files (*.stl)|*.stl|All files (*.*)|*.*";
            float StartTimeSecunds, EndTimeSecunds;
            // количество строк для просмотра
            ulong n = Convert.ToUInt64(toolStripTextBoxVol.Text);
            ulong i = 0;
            //
            bool metka = toolStripComboBox1.Text.TrimEnd() == "весь файл" ? false : true;
            ///
            MyProcedures proc = new MyProcedures();
            string line;
            string VibFileName;

            // текстовый файл
            if (toolStripComboBox2.Text.Substring(0, 2) == "1."
                && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                timer1.Enabled = true;
                //Определение количества треугольников
                countTr = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.IndexOf("outer") != -1)
                    {
                        countTr++;
                    }
                }
                sr.Close();
                sr = new StreamReader(openFileDialog1.FileName);
                //
                StartTimeSecunds = 3600 * DateTime.Now.Hour +
                    60 * DateTime.Now.Minute + DateTime.Now.Second;
                VibFileName = openFileDialog1.FileName;
                toolStripTextBoxFileName.Text = VibFileName;
                ///
                if (metka)
                {
                    richTextBox_review.Text = "";
                    try
                    {
                        while ((line = sr.ReadLine()) != null & i < n)
                        {
                            ++i;
                            richTextBox_review.Text += line + "\n";
                            ///
                        }
                    }
                    catch (Exception e0)
                    {
                        MessageBox.Show(e0.Message);
                    }
                }
                else
                {
                    //чтение всего файла
                    richTextBox_review.Text = sr.ReadToEnd();
                }
                ///
                EndTimeSecunds = 3600 * DateTime.Now.Hour +
                                 60 * DateTime.Now.Minute + DateTime.Now.Second;
                toolStripStatusLabel_time_loud.Text = "Время загрузки: " +
                    (EndTimeSecunds - StartTimeSecunds).ToString() + " c.";
                ///
                toolStripStatusLabel_info.Text = "Количество символов " + richTextBox_review.TextLength.ToString("###,0");
                sr.Close();
                ///
                timer1.Enabled = false;
                MessageBox.Show("Выбран файл и загружен для просмотра: " + VibFileName);
            }
            // бинарный файл
            if (toolStripComboBox2.Text.Substring(0, 2) == "2."
                && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StartTimeSecunds = 3600 * DateTime.Now.Hour +
                    60 * DateTime.Now.Minute + DateTime.Now.Second;
                VibFileName = openFileDialog1.FileName;
                toolStripTextBoxFileName.Text = VibFileName;
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(VibFileName, FileMode.Open)))
                    {
                        float x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn;
                        ushort AddAttr;
                        richTextBox_review.Text = "";

                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            byte[] header = br.ReadBytes(80);
                            richTextBox_review.Text += "Бинарный файл" + "\n";
                            uint numTr = br.ReadUInt32();
                            countTr = (int)numTr;
                            int ProgressBarNumTr = countTr - 1;
                            base_stl[] TrStl = new base_stl[numTr];
                            richTextBox_review.Text += "Количество треугольников: " + numTr.ToString("###,0") + " шт." + "\n";
                            StreamWriter sw = new StreamWriter(VibFileName.Remove(VibFileName.LastIndexOf('.'), 4) + "_ascii.txt", false);
                            for (uint ui = 0; ui < numTr; ui++)
                            {
                                proc.ProgressBarRefresh(toolStripProgressBarOpenSTL, (int)ui, ProgressBarNumTr);
                                // нормальный вектор
                                xn = br.ReadSingle(); yn = br.ReadSingle(); zn = br.ReadSingle();
                                // 1 вершина
                                x1 = br.ReadSingle(); y1 = br.ReadSingle(); z1 = br.ReadSingle();
                                // 2 вершина
                                x2 = br.ReadSingle(); y2 = br.ReadSingle(); z2 = br.ReadSingle();
                                // 3 вершина
                                x3 = br.ReadSingle(); y3 = br.ReadSingle(); z3 = br.ReadSingle();
                                //
                                AddAttr = br.ReadUInt16();
                                line = "facet normal " +
                                    xn.ToString("0.000000E-000") + " " + yn.ToString("0.000000E-000") + " " + zn.ToString("0.000000E-000") + "\r\n" +
                                "vertex " +
                                    x1.ToString("0.000000E-000") + " " + y1.ToString("0.000000E-000") + " " + z1.ToString("0.000000E-000") + "\r\n" +
                                "vertex " +
                                    x2.ToString("0.000000E-000") + " " + y2.ToString("0.000000E-000") + " " + z2.ToString("0.000000E-000") + "\r\n" +
                                "vertex " +
                                    x3.ToString("0.000000E-000") + " " + y3.ToString("0.000000E-000") + " " + z3.ToString("0.000000E-000") + "\r\n" +
                                "AddAttr = " + AddAttr + "\r\n" +
                                "endfacet";
                                if (!metka)
                                {
                                    // запись в richTextBox 
                                    richTextBox_review.Text += line;
                                }
                                // запись в новый файл c именем + "_ascii.txt", в текстовый формат

                                sw.Write(line);
                                sw.Write("\r\n");
                            }
                            sw.Close();
                        }
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString() + "\n Выбран не верный тип файла");
                    richTextBox_review.Text = "Выберите текстовый формат файла (ASCII)";
                    toolStripComboBox2.Text = "1. Текстовый формат файла (ASCII)";
                    timer1.Enabled = false;
                    if (VibFileName.Substring((int)(VibFileName.Length - 3)).ToLower() == "stl")
                    {
                        toolStripButton1_Click(sender, e);
                    }
                    else
                    { return; }
                }
                ///
                EndTimeSecunds = 3600 * DateTime.Now.Hour +
                                 60 * DateTime.Now.Minute + DateTime.Now.Second;
                toolStripStatusLabel_time_loud.Text = "Время загрузки: " +
                    (EndTimeSecunds - StartTimeSecunds).ToString() + " c.";
                ///
                toolStripStatusLabel_info.Text = "Количество символов " + richTextBox_review.TextLength.ToString("###,0");
                ///
                timer1.Enabled = false;
                /*
                MessageBox.Show("Выбран файл и загружен для просмотра: " + VibFileName + "\n" +
                                "Создан массив данных координат вершин и нормального вектора треугольных граней");
                */
                try
                {
                    frmMain.richTextBoxHistory.Text += "Выбран файл и загружен для просмотра: " + VibFileName + "\n" +
                                "Создан массив данных координат вершин и нормального вектора треугольных граней" +" \n";
                }
                catch (Exception e9)
                {
                    MessageBox.Show(e9.Message);
                }
                toolStripStatusLabel1.Text = "Массив исходных данных не создан";
                toolStripStatusLabel2.Text = "Массив исходных данных не создан";
                toolStripStatusLabelInphoOrientation.Text = "Массив исходных данных не создан";
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabelInphoOrientation.ForeColor = Color.Red;
                Calculate_size.Enabled = false;
                toolStripButtonCreateVoxModel.Enabled = false;
                toolStripButtonASC.Enabled = false;
                toolStripButtonVerification.Enabled = false;
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text.TrimEnd() != "весь файл")
            {
                toolStripTextBoxVol.ReadOnly = false;
                toolStripTextBoxVol.Visible = true;
            }
            else
            {
                toolStripTextBoxVol.ReadOnly = true;
                toolStripTextBoxVol.Visible = false;
            }
        }
        //Mассив данных о треугольниках для расчетов
        public List<base_stl> ListStl = new List<base_stl>();
        /// <summary>
        /// Преобразование stl файла в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string VibFileName = toolStripTextBoxFileName.Text;
            string VibFileName2 = "";
            if (VibFileName == "")
            {
                MessageBox.Show("Не выбран файл для импорта. См. закладку \"Открыть STL\".", "Отсутствуют данные");
                toolStripStatusLabel2.Text = "Не выбран STL-файл для импорта. Отсутствуют данные.";
                return;
            }
            else
            { VibFileName2 = VibFileName.Remove(VibFileName.LastIndexOf('.'), 4) + "_ascii.txt"; }
            //2016/03/09
            //Очищаем таблицу от данных
            if (dataGridView1.ColumnCount != 0)
                dataGridView1.Columns.Clear();
            //Добавление колонок в текущую таблицу для возможности добавления записей по треугольникам
            dataGridView1.Columns.Add("Nom", "№ треуг."); // 1-я колонка
            dataGridView1.Columns.Add("x1", "X1"); // 2-я колонка
            dataGridView1.Columns.Add("y1", "Y1"); // 3-я колонка
            dataGridView1.Columns.Add("z1", "Z1"); // 4-я колонка
            dataGridView1.Columns.Add("x2", "X2"); // 5-я колонка
            dataGridView1.Columns.Add("y2", "Y2"); // 6-я колонка
            dataGridView1.Columns.Add("z1", "Z2"); // 7-я колонка
            dataGridView1.Columns.Add("x3", "X3"); // 8-я колонка
            dataGridView1.Columns.Add("y3", "Y3"); // 9-я колонка
            dataGridView1.Columns.Add("z3", "Z3"); // 10-я колонка
            dataGridView1.Columns.Add("xn", "XN"); // 11-я колонка
            dataGridView1.Columns.Add("yn", "YN"); // 12-я колонка
            dataGridView1.Columns.Add("zn", "ZN"); // 13-я колонка
            dataGridView1.Columns.Add("str", "Площадь, мм2");
            // 14-я колонка
            //поток данных создаем по таблице выбранной на первой закладке
            StreamReader sr4 = new StreamReader((toolStripComboBox2.Text.Substring(0, 2) == "2." ? VibFileName2 : VibFileName), Encoding.Default);
            string str_temp = "";
            int Nom = 0; // порядковый номер треугольника
            string StrNom;
            int NomVertex = 0; // порядковый номер вершины
            ///string x1 ="", y1 = "", z1 = "", x2 = "", y2 = "", z2 = "", x3 = "", y3 = "", z3 = "", xn = "", yn = "", zn = "", str = "";
            string x1 = "", y1 = "", z1 = "", x2 = "", y2 = "", z2 = "", x3 = "", y3 = "", z3 = "", xn = "", yn = "", zn = "";
            double[] fstr;
            string[] p1; // вспомогательный массив
            //string[] p2; // вспомогательный массив
            //Экземпляр для класса процедур расчета
            MyProcedures proc = new MyProcedures();
            //Mассив для расчетов
            //List<base_stl> ListStl = new List<base_stl>();
            ListStl.Clear();

            while (!sr4.EndOfStream)
            {
                str_temp = sr4.ReadLine();
                if (str_temp.Trim().IndexOf("facet normal", 0) != -1)
                {
                    ++Nom;
                    p1 = str_temp.Trim().Split(new Char[] { ' ', '\t' });
                    for (int i = 4; i > 1; i--)
                    {
                        switch (i)
                        {
                            case 4:
                                zn = p1[i].Trim();
                                break;
                            case 3:
                                yn = p1[i].Trim();
                                break;
                            case 2:
                                xn = p1[i].Trim();
                                break;
                        }
                        //Проверка на пустую запись
                        if (p1[i].Trim() == "")
                        {
                            MessageBox.Show("Проблема c записью координат нормали треугольника");
                            return;
                        }
                    }
                }
                if (str_temp.IndexOf("vertex", 0) != -1)
                {
                    ++NomVertex;
                    p1 = str_temp.Remove(0, str_temp.IndexOf("vertex", 0) + 6).Trim().Split(new Char[] { ' ', '\t' });
                    for (int i = 2; i >= 0; i--)
                    {
                        switch (NomVertex * 10 + i)
                        {
                            case 12:
                                z1 = p1[i].Trim();
                                //MessageBox.Show("z1 = " + z1);
                                break;
                            case 11:
                                y1 = p1[i].Trim();
                                //MessageBox.Show("y1 = " + y1);
                                break;
                            case 10:
                                x1 = p1[i].Trim();
                                //MessageBox.Show("x1 = " + x1);
                                break;
                            case 22:
                                z2 = p1[i].Trim();
                                break;
                            case 21:
                                y2 = p1[i].Trim();
                                break;
                            case 20:
                                x2 = p1[i].Trim();
                                break;
                            case 32:
                                z3 = p1[i].Trim();
                                break;
                            case 31:
                                y3 = p1[i].Trim();
                                break;
                            case 30:
                                x3 = p1[i].Trim();
                                break;
                        }
                        //Проверка на пустую запись
                        if (p1[i].Trim() == "")
                        {
                            toolStripStatusLabel2.Text = "Проблема c записью координат вершин. Номер проблемной грани - " + Nom;
                            return;
                        }
                    }
                }
                // Запись данных треугольника
                if (str_temp.Trim() == "endfacet")
                {
                    StrNom = Nom.ToString();
                    NomVertex = 0;
                    if (x1.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) == -1)
                    {
                        if (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ".")
                        {
                            x1 = x1.Replace(',', '.'); y1 = y1.Replace(',', '.'); z1 = z1.Replace(',', '.');
                            x2 = x2.Replace(',', '.'); y2 = y2.Replace(',', '.'); z2 = z2.Replace(',', '.');
                            x3 = x3.Replace(',', '.'); y3 = y3.Replace(',', '.'); z3 = z3.Replace(',', '.');
                            xn = xn.Replace(',', '.'); yn = yn.Replace(',', '.'); zn = zn.Replace(',', '.');
                        }
                        if (NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ",")
                        {
                            x1 = x1.Replace('.', ','); y1 = y1.Replace('.', ','); z1 = z1.Replace('.', ',');
                            x2 = x2.Replace('.', ','); y2 = y2.Replace('.', ','); z2 = z2.Replace('.', ',');
                            x3 = x3.Replace('.', ','); y3 = y3.Replace('.', ','); z3 = z3.Replace('.', ',');
                            xn = xn.Replace('.', ','); yn = yn.Replace('.', ','); zn = zn.Replace('.', ',');
                        }
                    }
                    if ((x1.IndexOf("e") != -1))
                    {
                        x1 = x1.Replace('e', 'E'); y1 = y1.Replace('e', 'E'); z1 = z1.Replace('e', 'E');
                        x2 = x2.Replace('e', 'E'); y2 = y2.Replace('e', 'E'); z2 = z2.Replace('e', 'E');
                        x3 = x3.Replace('e', 'E'); y3 = y3.Replace('e', 'E'); z3 = z3.Replace('e', 'E');
                        xn = xn.Replace('e', 'E'); yn = yn.Replace('e', 'E'); zn = zn.Replace('e', 'E');
                        /*Второй вариант решения проблемы 2016/03/11
                        p2 = proc.DeleteFraction(x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn);
                        x1 = p2[0]; y1 = p2[1]; z1 = p2[2];
                        x2 = p2[3]; y2 = p2[4]; z2 = p2[5];
                        x3 = p2[6]; y3 = p2[7]; z3 = p2[8];
                        xn = p2[9]; yn = p2[10];zn = p2[11];
                        */
                    }
                    ///fstr = proc.Str(double.Parse(x1), double.Parse(y1), double.Parse(z1),
                    ///                double.Parse(x2), double.Parse(y2), double.Parse(z2),
                    ///                double.Parse(x3), double.Parse(y3), double.Parse(z3));
                    ///str = fstr.ToString("0.###E-000");
                    ///Действие по выбранной активности
                    //1.Просмотр в таблице
                    //2.Просмотр и записать в файл
                    //3.Записать в массив для расчетов

                    toolStripProgressBarCreateTable.Value = (int)(toolStripProgressBarCreateTable.Minimum +
                                 (toolStripProgressBarCreateTable.Maximum - toolStripProgressBarCreateTable.Minimum) * int.Parse(StrNom) / countTr);

                    Application.DoEvents();

                    try
                    {
                        switch (toolStripComboBox3.Text.Substring(0, 1))
                        {
                            case "1":
                                //Просмотр в таблице
                                ///dataGridView1.Rows.Add(StrNom, x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn, str);
                                dataGridView1.Rows.Add(StrNom, x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn);
                                break;
                            case "2":
                                //Просмотр и записать в файл
                                base_stl TrSTL1 = new base_stl();
                                //Записать в массив для расчетов
                                TrSTL1.X1 = float.Parse(x1);
                                TrSTL1.Y1 = float.Parse(y1);
                                TrSTL1.Z1 = float.Parse(z1);
                                TrSTL1.X2 = float.Parse(x2);
                                TrSTL1.Y2 = float.Parse(y2);
                                TrSTL1.Z2 = float.Parse(z2);
                                TrSTL1.X3 = float.Parse(x3);
                                TrSTL1.Y3 = float.Parse(y3);
                                TrSTL1.Z3 = float.Parse(z3);
                                fstr = TrSTL1.CalcSTr();
                                //
                                //dataGridView1.Rows.Add(StrNom, x1, y1, z1, x2, y2, z2, x3, y3, z3, xn, yn, zn, fstr[3].ToString("0.###E-000"));
                                //
                                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, true, Encoding.Default);
                                sw.WriteLine(zn + "\t" + fstr[3]);
                                sw.Close();
                                //
                                break;
                            case "3":
                                base_stl TrSTL = new base_stl();
                                //Записать в массив для расчетов
                                TrSTL.Nom = int.Parse(StrNom);
                                TrSTL.X1 = float.Parse(x1);
                                TrSTL.Y1 = float.Parse(y1);
                                TrSTL.Z1 = float.Parse(z1);
                                TrSTL.X2 = float.Parse(x2);
                                TrSTL.Y2 = float.Parse(y2);
                                TrSTL.Z2 = float.Parse(z2);
                                TrSTL.X3 = float.Parse(x3);
                                TrSTL.Y3 = float.Parse(y3);
                                TrSTL.Z3 = float.Parse(z3);
                                TrSTL.XN = float.Parse(xn);
                                TrSTL.YN = float.Parse(yn);
                                TrSTL.ZN = float.Parse(zn);
                                //Исходный цвет - серый
                                TrSTL.Rface = 128;
                                TrSTL.Gface = 128;
                                TrSTL.Bface = 128;
                                //
                                ListStl.Add(TrSTL);
                                break;
                            default:
                                toolStripStatusLabel2.Text = "Не выбрана операция!";
                                break;
                        }
                    }
                    catch (Exception e3)
                    {
                        MessageBox.Show(e3.Message + "\n" + "Возможно не выбрана активность(операция)");
                        toolStripStatusLabel2.Text = "Не выбрана операция!";
                        return;
                    }
                }
            }
            sr4.Close();

            if (toolStripComboBox3.Text.Substring(0, 1) == "2")
            {
                toolStripStatusLabel2.Text = "Файл сохранен " + (string)saveFileDialog1.FileName;
                toolStripStatusLabel2.ForeColor = Color.Black;
            }
            if (toolStripComboBox3.Text.Substring(0, 1) == "3")
            {
                //MessageBox.Show("Массив объектов класса треугольники создан. \n" +
                //                "Количество треугольников: " + ListStl.Count.ToString("###,0"));
                toolStripStatusLabel1.Text = "Массив исходных данных создан, количество треугольников: " + ListStl.Count.ToString("###,0");
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel2.Text = "Массив исходных данных создан, количество треугольников: " + ListStl.Count.ToString("###,0");
                toolStripStatusLabel2.ForeColor = Color.Black;
                toolStripStatusLabelColorVisual.Text = "Расчет не выполнен.";
                toolStripStatusLabelColorVisual.ForeColor = Color.Red;
                Calculate_size.Enabled = true;
                toolStripButtonCreateVoxModel.Enabled = false;
                toolStripButtonASC.Enabled = false;
                toolStripButtonVerification.Enabled = false;
                toolStripStatusLabelInphoOrientation.Text = "Массив исходных данных создан, количество треугольников: " + ListStl.Count.ToString("###,0");
                toolStripStatusLabelInphoOrientation.ForeColor = Color.Black;
                // Обнуление списка вершин
                listVertex.Clear();

            }
        }

        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "stl_" +
                                       DateTime.Now.Year.ToString() + "_" +
                                       DateTime.Now.Month.ToString() + "_" +
                                       DateTime.Now.Day.ToString() + "_" +
                                       DateTime.Now.Hour.ToString() + "_" +
                                       DateTime.Now.Minute.ToString();
            saveFileDialog1.DefaultExt = "txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new
                    StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                float Sum = 0, Sum0 = 0;
                int Num = int.Parse(toolStripTextBox2.Text);
                for (int i = 0; i < ListStl.Count; i++)
                {
                    Sum0 += (float)ListStl[i].CalcSTr()[3];
                }
                for (int i = 0; i < ListStl.Count; i++)
                {
                    Sum += (float)ListStl[i].CalcSTr()[3];
                    if (Sum >= Sum0/Num)
                    {
                        sw.WriteLine(i);
                        Sum = 0;
                    }
                }
                sw.WriteLine(ListStl.Count);
                toolStripStatusLabel2.Text = "Файл сохранен" + saveFileDialog1.FileName;
                sw.Close();
            }
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBarOpenSTL.Value < (toolStripProgressBarOpenSTL.Maximum))
                toolStripProgressBarOpenSTL.Value++;
        }
        ///создаем новый процесс
        ///http://csharpcoding.org/zapusk-iz-programmy-drugogo-prilozheniya/
        Process proc = new Process();
        /// <summary>
        /// Запускает Блокнот с загруженным файлом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void блокнотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            proc.StartInfo.FileName = @"Notepad.exe";
            proc.StartInfo.Arguments = toolStripTextBoxFileName.Text.Trim();
            proc.Start();
        }
        /// <summary>
        /// Запускает Magics с загруженным файлом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.MagicsPuth) &&
                    File.Exists(toolStripTextBoxFileName.Text.Trim()))
                {
                    proc.StartInfo.FileName = @SettingsUser.Default.MagicsPuth;
                    proc.StartInfo.Arguments = toolStripTextBoxFileName.Text.Trim();
                    proc.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                        @SettingsUser.Default.MagicsPuth + "\n" + toolStripTextBoxFileName.Text.Trim());
                }
            }
            catch (Exception e17)
            {
                MessageBox.Show(e17.Message);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        public int totalvoxpre = 0;
        /// <summary>
        /// Определение исходных параметров триангуляционной модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_size_Click(object sender, EventArgs e)
        {

            float minX = float.MaxValue, minY = float.MaxValue, minZ = float.MaxValue,
                  maxX = float.MinValue, maxY = float.MinValue, maxZ = float.MinValue;

            foreach (var TempSTL in ListStl)
            {
                minX = (minX < TempSTL.MinX()) ? minX : TempSTL.MinX();
                /* 2016/03/15
                richTextBoxInfo.Text += "minX: " + minX + "\n";
                richTextBoxInfo.Text += "TempSTL.MinX(): " + TempSTL.MinX() + "\n";
                richTextBoxInfo.Text += TempSTL.X1 + "   " + TempSTL.X2 + "   " + TempSTL.X3 + "\n";
                richTextBoxInfo.Text += TempSTL.Y1 + "   " + TempSTL.Y2 + "   " + TempSTL.Y3 + "\n";
                richTextBoxInfo.Text += TempSTL.Z1 + "   " + TempSTL.Z2 + "   " + TempSTL.Z3 + "\n";
                */
                minY = (minY < TempSTL.MinY()) ? minY : TempSTL.MinY();
                minZ = (minZ < TempSTL.MinZ()) ? minZ : TempSTL.MinZ();
                //
                maxX = (maxX > TempSTL.MaxX()) ? maxX : TempSTL.MaxX();
                maxY = (maxY > TempSTL.MaxY()) ? maxY : TempSTL.MaxY();
                maxZ = (maxZ > TempSTL.MaxZ()) ? maxZ : TempSTL.MaxZ();
            }
            richTextBoxInfo.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxInfo.Text += toolStripTextBoxFileName.Text + "\n" + "*********" + "\n" +
                "Минимальное значение координат вершин по оси Х:  " + minX.ToString("E03") + "\n" +
                "Минимальное значение координат вершин по оси Y:  " + minY.ToString("E03") + "\n" +
                "Минимальное значение координат вершин по оси Z:  " + minZ.ToString("E03") + "\n" + "\n" +
                "Максимальное значение координат вершин по оси Х: " + maxX.ToString("E03") + "\n" +
                "Максимальное значение координат вершин по оси Y: " + maxY.ToString("E03") + "\n" +
                "Максимальное значение координат вершин по оси Z: " + maxZ.ToString("E03") + "\n" + "\n" +
                "Габаритные размеры модели по осям X, Y, Z:  " + (maxX - minX).ToString("N03") + " ;  " +
                                                                (maxY - minY).ToString("N03") + " ;  " +
                                                                (maxZ - minZ).ToString("N03") + "\n" + "\n";
            richTextBoxInfo.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            ///
            toolStripButtonCreateVoxModel.Enabled = true;
            toolStripButtonASC.Enabled = false;
            toolStripButtonVerification.Enabled = false;
            ///запись данных в соответствующие поля
            textBoxMinX.Text = minX.ToString("N02");
            textBoxMaxX.Text = maxX.ToString("N02");
            textBoxSizeX.Text = (maxX - minX).ToString("N02");
            //
            textBoxMinY.Text = minY.ToString("N02");
            textBoxMaxY.Text = maxY.ToString("N02");
            textBoxSizeY.Text = (maxY - minY).ToString("N02");
            //
            textBoxMinZ.Text = minZ.ToString("N02");
            textBoxMaxZ.Text = maxZ.ToString("N02");
            textBoxSizeZ.Text = (maxZ - minZ).ToString("N02");
            //предварительный расчет количества вокселей
            textBoxTotalVox.Text = ((maxX - minX) * (maxY - minY) * (maxZ - minZ) /
                                    (float)numericUpDownVoxX.Value /
                                    (float)numericUpDownVoxY.Value /
                                    (float)numericUpDownVoxZ.Value).ToString("N0");
            toolStripStatusLabel1.Text = "Массив создан. Исходные данные определены";
        }
        /// <summary>
        /// Параметры воксельной модели (количество вокселей по осям X,Y,Z)
        /// </summary>
        int CountVoxelsX, CountVoxelsY, CountVoxelsZ;
        /// <summary>
        /// Список вокселей модели
        /// </summary>
        List<base_vox> ListVox = new List<base_vox>();

        /// Процедура создания воксельной модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCreateVoxModel_Click(object sender, EventArgs e)
        {
            ListVox.Clear();
            toolStripButtonStatAnal.Enabled = true;
            int StartTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
            richTextBoxInfo.Text += "Время (начало создания воксельной модели): " + DateTime.Now.ToLongTimeString() + "\n";
            toolStripButtonASC.Enabled = false;
            toolStripButtonVerification.Enabled = false;
            toolStripStatusLabel1.Text = "Воксельная модель создается... ";
            string temptext = richTextBoxInfo.Text;
            MyProcedures proc = new MyProcedures();
            ///исходные данные
            float MinX = float.Parse(textBoxMinX.Text) + (float)numericUpDownVoxX.Value / 2;
            float MaxX = float.Parse(textBoxMaxX.Text) - (float)numericUpDownVoxX.Value / 2;
            //
            float MinY = float.Parse(textBoxMinY.Text) + (float)numericUpDownVoxY.Value / 2;
            float MaxY = float.Parse(textBoxMaxY.Text) - (float)numericUpDownVoxY.Value / 2;
            //
            float MinZ = float.Parse(textBoxMinZ.Text) + (float)numericUpDownVoxZ.Value / 2;
            float MaxZ = float.Parse(textBoxMaxZ.Text) - (float)numericUpDownVoxZ.Value / 2;
            //размеры вокселя
            float SizeX = (float)numericUpDownVoxX.Value;
            float SizeY = (float)numericUpDownVoxY.Value;
            float SizeZ = (float)numericUpDownVoxZ.Value;
            //количество вокселей по каждой из осей
            int numX = (int)((MaxX - MinX) / SizeX);
            int numY = (int)((MaxY - MinY) / SizeY);
            int numZ = (int)((MaxZ - MinZ) / SizeZ);
            //Запись в глобальные параметры
            CountVoxelsX = numX;
            CountVoxelsY = numY;
            CountVoxelsZ = numZ;
            //
            float tempX = 0;
            float tempY = 0;
            float tempZ = 0;
            /// <summary>
            /// Список координат пересечений треугольников
            /// </summary>
            List<float> MPeresZ = new List<float>();
            int k = 0; //количество полных вокселей
            // Общее количество вокселей
            int TotalCount = 0;
            //создание массива вокселей
            for (int i = 0; i <= numX; i++)
            {
                tempX = MinX + i * SizeX;

                proc.ProgressBarRefresh(toolStripProgressBarCreateVoxel, i, numX);

                for (int j = 0; j <= numY; j++)
                {
                    tempY = MinY + j * SizeY;
                    MPeresZ.Clear();
                    float tempPeresZ;
                    // сканирование списка данных координат треугольников class "base_stl"

                    foreach (var TempSTL in ListStl)
                    {
                        if (TempSTL.PeresZ(tempX, tempY))
                        {
                            tempPeresZ = TempSTL.KoordZ(tempX, tempY);
                            //запись координат пересечения с гранями модели
                            if (MPeresZ.Count == 0)
                            {
                                MPeresZ.Add(tempPeresZ);
                            }
                            else if (Math.Abs(tempPeresZ - MPeresZ[MPeresZ.Count - 1]) > (SizeZ / 2))
                            { MPeresZ.Add(tempPeresZ); }
                        }
                    }
                    MPeresZ.Sort();
                    //
                    for (int m = 0; m <= numZ; m++)
                    {
                        tempZ = MinZ + m * SizeZ;
                        base_vox tempVoxLine = new base_vox();
                        tempVoxLine.Xv = tempX;
                        tempVoxLine.Yv = tempY;
                        tempVoxLine.Zv = tempZ;
                        tempVoxLine.SizeX = SizeX;
                        tempVoxLine.SizeY = SizeY;
                        tempVoxLine.SizeZ = SizeZ;
                        //Простановка метки модели
                        if (MPeresZ.Count > 1 && Math.IEEERemainder((double)MPeresZ.Count, 2) == 0)
                        {
                            for (int n = 0; n < MPeresZ.Count;)
                            {
                                try
                                {
                                    float LineMinZ = MPeresZ[n];
                                    float LineMaxZ = MPeresZ[n + 1];
                                    n = n + 2;
                                    tempZ = MinZ + (m + (1 / 2)) * SizeZ;
                                    if (tempZ >= LineMinZ && tempZ <= LineMaxZ)
                                    {
                                        tempVoxLine.Lfull = true;
                                        k++;
                                    }
                                }
                                catch (Exception e2)
                                {
                                    toolStripStatusLabel1.Text = e2.Message + ". Отсутствует грань или имеются накладывающиеся, пересекающиеся грани";
                                    //MessageBox.Show(e2.Message + "\n" + MPeresZ.Count + "\n" + "Возможно модель имеет дефекты:" +
                                    //    "отсутствует треугольник или имеются накладывающиеся, пересекающиеся треугольники");
                                    return;
                                }
                            }
                        }
                        //
                        ListVox.Add(tempVoxLine);
                    }
                }
            }
            //
            int EndTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond - StartTime;
            richTextBoxInfo.Text = temptext + "Количество вокселей модели: " + k + "\n";
            richTextBoxInfo.Text += "Количество вокселей свободного пространства: " + (ListVox.Count - k) + "\n";
            TotalCount = ((numX) * (numY) * (numZ));
            richTextBoxInfo.Text += "Расчетное количество вокселей (общее): " + TotalCount + "\n";
            textBoxTotalVox.Text = TotalCount.ToString("N0");
            richTextBoxInfo.Text += "Размеры вокселя (по осям X, Y, Z): " + numericUpDownVoxX.Value + "; " + numericUpDownVoxY.Value + "; " + numericUpDownVoxZ.Value + "\n";
            richTextBoxInfo.Text += "Объем воксельной модели: " + (k * SizeX * SizeY * SizeZ).ToString() + "(мм3)" + "\n";
            richTextBoxInfo.Text += "Время создания: " + EndTime.ToString("###,0") + " мc. \n";
            toolStripButtonASC.Enabled = true;
            toolStripButtonVerification.Enabled = true;
            toolStripStatusLabel1.Text = "Воксельная модель создана.";
            toolStripStatusLabelLocation.Text = "Воксельная модель создана.";

            //Создание массива моделей для размещения на рабочей платформе
            if (activeTask == ATPreparation.switchActiveTask.analizePacking)
            {
                base_model model = new base_model();
                model.Name = toolStripTextBoxFileName.Text;
                model.Stl = ListStl;
                //Создание списка вокселей для модели изделия
                List<base_vox> tempListVox = new List<base_vox>();
                foreach (var item in ListVox)
                {
                    if(item.Lfull)
                        tempListVox.Add(item);
                }
                model.Voxels = tempListVox;
                //
                model.totalCountVoxels = TotalCount;
                model.sizeXvoxel = SizeX;
                model.sizeYvoxel = SizeY;
                model.sizeZvoxel = SizeZ;
                float Vstl = 0;
                foreach (var tempstl in ListStl)
                {
                    Vstl += tempstl.CalcVol();
                }

                model.Volumе = Vstl;
                model.angleX = 0;
                model.angleY = 0;
                model.coordinateX = MinX;
                model.coordinateY = MinY;
                model.coordinateZ = MinZ;
                model.sizeX = MaxX - MinX;
                model.sizeY = MaxY - MinY;
                model.sizeZ = MaxZ - MinZ;
                model.information = richTextBoxInfo.Text;
                massiveListModels.Add(model);
                //добавление в список выбора
                toolStripComboBoxListModels.Items.Add(massiveListModels.Count.ToString("000") +
                           " "+ toolStripTextBoxFileName.Text.Remove(0, 1 + toolStripTextBoxFileName.Text.LastIndexOf(@"\")));
            }
            try
            {
                frmMain.richTextBoxHistory.Text += "Создана воксельная модель. \n";
            }
            catch (Exception e9)
            {
                MessageBox.Show(e9.Message);
            }
        }
        /// <summary>
        /// Определение списка свойств треугольников для расчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ListStl.Count != 0)
            {
                dataGridView1.Columns.Clear();
                //Добавление колонок в текущую таблицу для возможности добавления записей по треугольникам
                dataGridView1.Columns.Add("Nom1", "№ 1-го треуг."); // 1-я колонка
                dataGridView1.Columns.Add("Nom2", "№ 2-го треуг."); // 2-я колонка
                dataGridView1.Columns.Add("fi", "fi угол между нормалями"); // 3-я колонка
                dataGridView1.Columns.Add("cosfi", "cos(fi)"); // 4-я колонка
                dataGridView1.Columns.Add("str", "Площадь, мм2"); // 5-я колонка
                //
                MyProcedures proced = new MyProcedures();
                double fi = 0; // угол между нормалями смежных граней 
                for (int i = 0; i < ListStl.Count; i++)
                {
                    var item1 = ListStl[i];
                    int j = i + 1;
                    for (; j < ListStl.Count; j++)
                    {
                        var item2 = ListStl[j];
                        if (proced.contiguity(item1, item2))
                        {
                            fi = proced.AngleBetweenNormals(item1, item2);

                            dataGridView1.Rows.Add(i + 1, j + 1, fi, 180 * Math.Acos(fi) / Math.PI, item1.CalcSTr()[3]);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Вкл/откл. ReadOnly для размеров вокселя по трем осям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVox.Checked == false)
            {
                numericUpDownVoxY.ReadOnly = false;
                numericUpDownVoxZ.ReadOnly = false;
            }
            else
            {
                numericUpDownVoxY.ReadOnly = true;
                numericUpDownVoxZ.ReadOnly = true;
                numericUpDownVoxY.Value = numericUpDownVoxX.Value;
                numericUpDownVoxZ.Value = numericUpDownVoxX.Value;
            }
        }
        /// <summary>
        /// Изменение размеров вокселя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownVoxX_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxVox.Checked == true)
            {
                numericUpDownVoxY.Value = numericUpDownVoxX.Value;
                numericUpDownVoxZ.Value = numericUpDownVoxX.Value;
            }
            if (toolStripButtonCreateVoxModel.Enabled)
                textBoxTotalVox.Text = ((float.Parse(textBoxMaxX.Text) - float.Parse(textBoxMinX.Text)) *
                                        (float.Parse(textBoxMaxY.Text) - float.Parse(textBoxMinY.Text)) *
                                        (float.Parse(textBoxMaxZ.Text) - float.Parse(textBoxMinZ.Text)) /
                            (float)numericUpDownVoxX.Value /
                            (float)numericUpDownVoxY.Value /
                            (float)numericUpDownVoxZ.Value).ToString("N0");
        }
        /// <summary>
        /// Сохранение данных по воксельной модели в файл формата ASC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Сохранение модели...";
            saveFileDialog1.FileName = "vox_" +
                           DateTime.Now.Year.ToString() + "_" +
                           DateTime.Now.Month.ToString() + "_" +
                           DateTime.Now.Day.ToString() + "_" +
                           DateTime.Now.Hour.ToString() + "_" +
                           DateTime.Now.Minute.ToString();
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".asc";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int StartTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
                StreamWriter sw = new
                    StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                sw.WriteLine("------- Next Cloud : VoxModel : PointsModel ---------- ");
                int numTempvoxstr = 0;
                foreach (var tempvoxstr in ListVox)
                {
                    if (tempvoxstr.Lfull)
                    {
                        sw.WriteLine(tempvoxstr.ToString().Replace(',', '.'));
                    }
                    toolStripProgressBarCreateVoxel.Value = toolStripProgressBarCreateVoxel.Minimum +
                        (toolStripProgressBarCreateVoxel.Maximum - toolStripProgressBarCreateVoxel.Minimum) * (numTempvoxstr++ / ListVox.Count);
                }
                sw.Close();
                //MessageBox.Show("Файл записан: " + saveFileDialog1.FileName);
                int dTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond - StartTime;
                richTextBoxInfo.Text += "Записан файл: " + saveFileDialog1.FileName + ", за " + dTime.ToString("###,0") + " мс. \n";
            }
            toolStripStatusLabel1.Text = "Модель сохранена в файл: " + saveFileDialog1.FileName;
        }
        /// <summary>
        /// Проверка воксельной модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonVerification_Click(object sender, EventArgs e)
        {
            int StartTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

            float minX = float.MaxValue, minY = float.MaxValue, minZ = float.MaxValue,
                  maxX = float.MinValue, maxY = float.MinValue, maxZ = float.MinValue;
            //расчет количества/объема вокселей
            int CountVox = 0;
            foreach (var tempvox in ListVox)
            {
                if (tempvox.Lfull)
                {
                    minX = (minX < tempvox.Xv) ? minX : tempvox.Xv;
                    minY = (minY < tempvox.Yv) ? minY : tempvox.Yv;
                    minZ = (minZ < tempvox.Zv) ? minZ : tempvox.Zv;
                    //
                    maxX = (maxX > tempvox.Xv) ? maxX : tempvox.Xv;
                    maxY = (maxY > tempvox.Yv) ? maxY : tempvox.Yv;
                    maxZ = (maxZ > tempvox.Zv) ? maxZ : tempvox.Zv;
                    //
                    CountVox++;
                }
            }
            //вывод данных в текстовые поля
            textBoxVoxMinX.Text = minX.ToString("N02") + " / " + (minX - (float)numericUpDownVoxX.Value / 2).ToString("N02");
            textBoxVoxMinY.Text = minY.ToString("N02") + " / " + (minY - (float)numericUpDownVoxY.Value / 2).ToString("N02");
            textBoxVoxMinZ.Text = minZ.ToString("N02") + " / " + (minZ - (float)numericUpDownVoxZ.Value / 2).ToString("N02");
            //
            textBoxVoxMaxX.Text = maxX.ToString("N02") + " / " + (maxX + (float)numericUpDownVoxX.Value / 2).ToString("N02");
            textBoxVoxMaxY.Text = maxY.ToString("N02") + " / " + (maxY + (float)numericUpDownVoxY.Value / 2).ToString("N02");
            textBoxVoxMaxZ.Text = maxZ.ToString("N02") + " / " + (maxZ + (float)numericUpDownVoxZ.Value / 2).ToString("N02");
            //размеры
            textBoxVoxSizeX.Text = (maxX - minX).ToString("N02") + " / " + (maxX - minX + (float)numericUpDownVoxX.Value).ToString("N02");
            textBoxVoxSizeY.Text = (maxY - minY).ToString("N02") + " / " + (maxY - minY + (float)numericUpDownVoxY.Value).ToString("N02");
            textBoxVoxSizeZ.Text = (maxZ - minZ).ToString("N02") + " / " + (maxZ - minZ + (float)numericUpDownVoxZ.Value).ToString("N02");
            //погрешности размеров
            textBoxErrorX.Text = (float.Parse(textBoxSizeX.Text) - (float)numericUpDownVoxX.Value - (maxX - minX)).ToString("N02") + " мм / " +
                (100 * (float.Parse(textBoxSizeX.Text) - (float)numericUpDownVoxX.Value - (maxX - minX)) / float.Parse(textBoxSizeX.Text)).ToString("N01") + " %";
            textBoxErrorY.Text = (float.Parse(textBoxSizeY.Text) - (float)numericUpDownVoxY.Value - (maxY - minY)).ToString("N02") + " мм / " +
                (100 * (float.Parse(textBoxSizeY.Text) - (float)numericUpDownVoxY.Value - (maxY - minY)) / float.Parse(textBoxSizeY.Text)).ToString("N01") + " %";
            textBoxErrorZ.Text = (float.Parse(textBoxSizeZ.Text) - (float)numericUpDownVoxZ.Value - (maxZ - minZ)).ToString("N02") + " мм / " +
                (100 * (float.Parse(textBoxSizeZ.Text) - (float)numericUpDownVoxZ.Value - (maxZ - minZ)) / float.Parse(textBoxSizeZ.Text)).ToString("N01") + " %";

            textBoxTotalVoxRez.Text = CountVox.ToString("N0") + " / " + (CountVox * (float)numericUpDownVoxX.Value *
                                    (float)numericUpDownVoxY.Value *
                                    (float)numericUpDownVoxZ.Value).ToString("N2");
            //площадь и объем триангуляционной модели
            double Sstl = 0;
            float Vstl = 0;
            foreach (var tempstl in ListStl)
            {
                Sstl += tempstl.CalcSTr()[3];
                Vstl += tempstl.CalcVol();
            }
            richTextBoxInfo.Text += "Площадь триангуляционной модели: " + Sstl.ToString("N3") + " mm2 \n";
            richTextBoxInfo.Text += "Объем триангуляционной модели: " + Vstl.ToString("N3") + " mm3 \n";
            richTextBoxInfo.Text += "Объем воксельной модели: " + (CountVox * (float)numericUpDownVoxX.Value *
                                    (float)numericUpDownVoxY.Value * (float)numericUpDownVoxZ.Value).ToString("N3") + " mm3 \n";
            richTextBoxInfo.Text += "Погрешность создания воксельной модели по объему: " + ((CountVox * (float)numericUpDownVoxX.Value *
                                    (float)numericUpDownVoxY.Value * (float)numericUpDownVoxZ.Value - Vstl) / Vstl).ToString("P01") + ".\n";
            richTextBoxInfo.Text += "Коэффициент заполнения объема: " + ((float)CountVox / (float)ListVox.Count).ToString("P01") + ".\n";
            //
            int EndTime = DateTime.Now.Hour * 3600000 + DateTime.Now.Minute * 60000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond - StartTime;
            richTextBoxInfo.Text += "Время проверки: " + EndTime.ToString("###,0") + " мc. \n";
            toolStripStatusLabel1.Text = "Выполнена проверка модели. ";
        }
        /// <summary>
        /// Статистические характеристики (результаты анализа)
        /// </summary>
        public float[] resultStat_X = new float[13];
        public float[] resultStat_Y = new float[13];
        public float[] resultStat_Z = new float[13];
        List<Stat_analysis.elementGist> gistX = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistY = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistZ = new List<Stat_analysis.elementGist>();
        //
        public float[] resultStat_XEmpty = new float[13];
        public float[] resultStat_YEmpty = new float[13];
        public float[] resultStat_ZEmpty = new float[13];
        List<Stat_analysis.elementGist> gistXEmpty = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistYEmpty = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistZEmpty = new List<Stat_analysis.elementGist>();
        //
        public float[] resultStat_XSum = new float[13];
        public float[] resultStat_YSum = new float[13];
        public float[] resultStat_ZSum = new float[13];
        List<Stat_analysis.elementGist> gistXSum = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistYSum = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistZSum = new List<Stat_analysis.elementGist>();

        /// <summary>
        /// Статистический анализ воксельной модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (ListVox.Count == 0)
            {
                toolStripComboBoxShowAnalysis.Enabled = true;
                MessageBox.Show("Нет данных для анализа");
                return;
            }
            Stat_analysis statisticaX = new Stat_analysis();
            Stat_analysis statisticaY = new Stat_analysis();
            Stat_analysis statisticaZ = new Stat_analysis();
            //
            List<float> tempMassiveVoxelX = new List<float>();
            List<float> tempMassiveVoxelY = new List<float>();
            List<float> tempMassiveVoxelZ = new List<float>();
            //Пустые воксели
            Stat_analysis statisticaXEmpty = new Stat_analysis();
            Stat_analysis statisticaYEmpty = new Stat_analysis();
            Stat_analysis statisticaZEmpty = new Stat_analysis();
            //
            List<float> tempMassiveVoxelXEmpty = new List<float>();
            List<float> tempMassiveVoxelYEmpty = new List<float>();
            List<float> tempMassiveVoxelZEmpty = new List<float>();
            //Решение проблемы гистограмм с относителным содержанием вокселей для матеньких деталей
            Stat_analysis statisticaXSum = new Stat_analysis();
            Stat_analysis statisticaYSum = new Stat_analysis();
            Stat_analysis statisticaZSum = new Stat_analysis();
            //
            List<float> tempMassiveVoxelXSum = new List<float>();
            List<float> tempMassiveVoxelYSum = new List<float>();
            List<float> tempMassiveVoxelZSum = new List<float>();

            for (int i = 0; i < ListVox.Count; i++)
            {
                if (ListVox[i].Lfull)
                {
                    tempMassiveVoxelX.Add(ListVox[i].Xv);
                    tempMassiveVoxelY.Add(ListVox[i].Yv);
                    tempMassiveVoxelZ.Add(ListVox[i].Zv);
                }
                else
                {
                    tempMassiveVoxelXEmpty.Add(ListVox[i].Xv);
                    tempMassiveVoxelYEmpty.Add(ListVox[i].Yv);
                    tempMassiveVoxelZEmpty.Add(ListVox[i].Zv);
                }
                tempMassiveVoxelXSum.Add(ListVox[i].Xv);
                tempMassiveVoxelYSum.Add(ListVox[i].Yv);
                tempMassiveVoxelZSum.Add(ListVox[i].Zv);
            }

            //
            // 1. Распределение вокселей модели
            if (toolStripComboBoxShowAnalysis.SelectedIndex == 0)
            {
                gistX = statisticaX.Gist(tempMassiveVoxelX.ToArray(), (int)numericUpDownNumIntX.Value);
                resultStat_X = statisticaX.Stat(tempMassiveVoxelX.ToArray(), gistX);
                //
                gistY = statisticaY.Gist(tempMassiveVoxelY.ToArray(), (int)numericUpDownNumIntY.Value);
                resultStat_Y = statisticaY.Stat(tempMassiveVoxelY.ToArray(), gistY);
                //
                gistZ = statisticaZ.Gist(tempMassiveVoxelZ.ToArray(), (int)numericUpDownNumIntZ.Value);
                resultStat_Z = statisticaZ.Stat(tempMassiveVoxelZ.ToArray(), gistZ);
            }
            // 2.Распределение свободного пространства
            if (toolStripComboBoxShowAnalysis.SelectedIndex == 1)
            {
                gistX = statisticaXEmpty.Gist(tempMassiveVoxelXEmpty.ToArray(), (int)numericUpDownNumIntX.Value);
                resultStat_X = statisticaXEmpty.Stat(tempMassiveVoxelXEmpty.ToArray(), gistX);
                //
                gistY = statisticaYEmpty.Gist(tempMassiveVoxelYEmpty.ToArray(), (int)numericUpDownNumIntY.Value);
                resultStat_Y = statisticaYEmpty.Stat(tempMassiveVoxelYEmpty.ToArray(), gistY);
                //
                gistZ = statisticaZEmpty.Gist(tempMassiveVoxelZEmpty.ToArray(), (int)numericUpDownNumIntZ.Value);
                resultStat_Z = statisticaZEmpty.Stat(tempMassiveVoxelZEmpty.ToArray(), gistZ);
            }
            //
            gistXSum = statisticaXSum.Gist(tempMassiveVoxelXSum.ToArray(), (int)numericUpDownNumIntX.Value);
            resultStat_XSum = statisticaXSum.Stat(tempMassiveVoxelXSum.ToArray(), gistXSum);
            //
            gistYSum = statisticaYSum.Gist(tempMassiveVoxelYSum.ToArray(), (int)numericUpDownNumIntY.Value);
            resultStat_YSum = statisticaYSum.Stat(tempMassiveVoxelYSum.ToArray(), gistYSum);
            //
            gistZSum = statisticaZSum.Gist(tempMassiveVoxelZSum.ToArray(), (int)numericUpDownNumIntZ.Value);
            resultStat_ZSum = statisticaZSum.Stat(tempMassiveVoxelZSum.ToArray(), gistZSum);
            ///
            toolStripComboBoxShowAnalysis.Enabled = true;
            toolStripButtonShowStatisticalDataX.Enabled = true;
            toolStripButtonShowStatisticalDataY.Enabled = true;
            toolStripButtonShowStatisticalDataZ.Enabled = true;
            toolStripButtonShowHistogramXYZ.Enabled = true;
            try
            {
                frmMain.richTextBoxHistory.Text += "Выполнен статистический анализ воксельной модели \n";
            }
            catch (Exception e9)
            {
                MessageBox.Show(e9.Message);
            }
        }

        private void textBoxSizeX_TextChanged(object sender, EventArgs e)
        {
            textBoxSizeX2.Text = textBoxSizeX.Text;
        }

        private void textBoxSizeY_TextChanged(object sender, EventArgs e)
        {
            textBoxSizeY2.Text = textBoxSizeY.Text;
        }

        private void textBoxSizeZ_TextChanged(object sender, EventArgs e)
        {
            textBoxSizeZ2.Text = textBoxSizeZ.Text;
        }
        /// <summary>
        /// Вкл/откл. ReadOnly для кол-ва интервалов гистограмм по трем осям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNumInterval.Checked == false)
            {
                numericUpDownNumIntY.ReadOnly = false;
                numericUpDownNumIntZ.ReadOnly = false;
            }
            else
            {
                numericUpDownNumIntY.ReadOnly = true;
                numericUpDownNumIntZ.ReadOnly = true;
                numericUpDownNumIntY.Value = numericUpDownNumIntX.Value;
                numericUpDownNumIntZ.Value = numericUpDownNumIntX.Value;
            }
        }
        /// <summary>
        /// Изменение кол-ва интервалов гистограммы по оси X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownNumIntX_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxNumInterval.Checked == true)
            {
                numericUpDownNumIntY.Value = numericUpDownNumIntX.Value;
                numericUpDownNumIntZ.Value = numericUpDownNumIntX.Value;
            }
            try
            { textBoxSizeIntervalsX.Text = (decimal.Parse(textBoxSizeX2.Text) / numericUpDownNumIntX.Value).ToString("N03"); }
            catch
            { MessageBox.Show("Создайте воксельную модель. Отсутствуют данные."); }
        }
        /// <summary>
        /// Изменение кол-ва интервалов гистограммы по оси Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownNumIntY_ValueChanged(object sender, EventArgs e)
        {

            textBoxSizeIntervalsY.Text = (decimal.Parse(textBoxSizeY2.Text) / numericUpDownNumIntY.Value).ToString("N03");
        }
        /// <summary>
        /// Изменение кол-ва интервалов гистограммы по оси Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownNumIntZ_ValueChanged(object sender, EventArgs e)
        {
            textBoxSizeIntervalsZ.Text = (decimal.Parse(textBoxSizeZ2.Text) / numericUpDownNumIntZ.Value).ToString("N03");
        }
        /// <summary>
        /// Отображение данных в закладке "Анализа воксельной модели"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalVox_Enter(object sender, EventArgs e)
        {
            try
            {
                this.numericUpDownNumIntX_ValueChanged(sender, e);
                this.numericUpDownNumIntY_ValueChanged(sender, e);
                this.numericUpDownNumIntZ_ValueChanged(sender, e);
            }
            catch (Exception e4)
            {
                MessageBox.Show("Нет данных! \n" + e4.Message);
            }
        }

        private Chart activeChart;
        /// <summary>
        /// Вывод данных статистического анализа по распределению координат вокселей по оси X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonShowStatisticalDataX_Click(object sender, EventArgs e)
        {
            toolStripButtonShowStatisticalDataX.Font = new Font(this.Font, FontStyle.Bold);
            toolStripButtonShowStatisticalDataY.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataZ.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowHistogramXYZ.Font = new Font(this.Font, FontStyle.Regular);
            activeChartType = switchChartType.X;

            ///0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
            /// 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
            textBoxMin.Text = resultStat_X[0].ToString("0.0000E-00");
            textBoxMax.Text = resultStat_X[1].ToString("0.0000E-00");
            textBoxInterval.Text = resultStat_X[2].ToString("0.0000E-00");
            textBoxDispersion.Text = resultStat_X[3].ToString("0.0000E-00");
            textBoxStandardDeviation.Text = resultStat_X[4].ToString("0.0000E-00");
            textBoxAverage.Text = resultStat_X[5].ToString("0.0000E-00");
            textBoxSkewness.Text = resultStat_X[6].ToString("0.0000E-00");
            textBoxCoefficientOfExcess.Text = resultStat_X[7].ToString("0.0000E-00");
            textBoxCoefficientOfVariation.Text = resultStat_X[8].ToString("0.0000E-00");
            textBoxMean.Text = resultStat_X[9].ToString("0.0000E-00");
            textBoxMode.Text = resultStat_X[10].ToString("0.0000E-00");
            textBoxMedian.Text = resultStat_X[11].ToString("0.0000E-00");

            //Предварительная очистка данных гистограммы
            chartHistogramVoxelX.Series.Clear();
            chartHistogramVoxelX.Series.Dispose();
            chartHistogramVoxelXRelation.Series.Clear();
            chartHistogramVoxelXRelation.Series.Dispose();
            chartHistogramVoxelX.ChartAreas.Clear();
            chartHistogramVoxelXRelation.ChartAreas.Clear();
            chartHistogramVoxelX.ChartAreas.Add("ChartArea1");
            chartHistogramVoxelXRelation.ChartAreas.Add("ChartArea1");
            //Вывод данных на гистограмму распределения
            Series seriesStatisticalDataX = new Series();
            Series seriesStatisticalDataXRelation = new Series();
            textBoxDataHistogram.Clear();
            if (gistX.Count != gistXSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistX.Count != gistXSum.Count");
                return;
            }

            for (int i = 0; i < gistX.Count; i++)
            {
                seriesStatisticalDataX.Points.Add(new DataPoint(Math.Round((gistX[i].Xmin + gistX[i].Xmax) / 2, 2), gistX[i].Y));
                seriesStatisticalDataXRelation.Points.Add(new DataPoint(Math.Round((gistX[i].Xmin + gistX[i].Xmax) / 2, 2),
                    gistX[i].Y / gistXSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistX[i].Xmin + "; Xmax = " + gistX[i].Xmax + "; Y = " + gistX[i].Y +
                                              "  (" + (gistX[i].Y / gistXSum[i].Y).ToString("N03") + "); \r\n";
            }
            seriesStatisticalDataX.ChartArea = "ChartArea1";
            seriesStatisticalDataX.Name = "Гистограмма распределения плотности вокселей модели по оси X";
            seriesStatisticalDataX.ChartType = SeriesChartType.Column;
            chartHistogramVoxelX.Palette = ChartColorPalette.BrightPastel;

            chartHistogramVoxelX.Series.Add(seriesStatisticalDataX);
            chartHistogramVoxelXRelation.Series.Add(seriesStatisticalDataXRelation);

            SwitchChart(activeChartType, activeChartAbsRel);
            if (activeChartAbsRel == switchChartAbsRel.Relative)
                activeChart = chartHistogramVoxelXRelation;
            else if (activeChartAbsRel == switchChartAbsRel.Absolute)
                activeChart = chartHistogramVoxelX;
        }
        /// <summary>
        /// Вывод данных статистического анализа по распределению координат вокселей по оси Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonShowStatisticalDataY_Click(object sender, EventArgs e)
        {
            toolStripButtonShowStatisticalDataX.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataY.Font = new Font(this.Font, FontStyle.Bold);
            toolStripButtonShowStatisticalDataZ.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowHistogramXYZ.Font = new Font(this.Font, FontStyle.Regular);
            activeChartType = switchChartType.Y;

            textBoxMin.Text = resultStat_Y[0].ToString("0.0000E-00");
            textBoxMax.Text = resultStat_Y[1].ToString("0.0000E-00");
            textBoxInterval.Text = resultStat_Y[2].ToString("0.0000E-00");
            textBoxDispersion.Text = resultStat_Y[3].ToString("0.0000E-00");
            textBoxStandardDeviation.Text = resultStat_Y[4].ToString("0.0000E-00");
            textBoxAverage.Text = resultStat_Y[5].ToString("0.0000E-00");
            textBoxSkewness.Text = resultStat_Y[6].ToString("0.0000E-00");
            textBoxCoefficientOfExcess.Text = resultStat_Y[7].ToString("0.0000E-00");
            textBoxCoefficientOfVariation.Text = resultStat_Y[8].ToString("0.0000E-00");
            textBoxMean.Text = resultStat_Y[9].ToString("0.0000E-00");
            textBoxMode.Text = resultStat_Y[10].ToString("0.0000E-00");
            textBoxMedian.Text = resultStat_Y[11].ToString("0.0000E-00");

            //Предварительная очистка данных гистограммы
            //
            chartHistogramVoxelY.Series.Clear();
            chartHistogramVoxelYRelation.Series.Clear();
            chartHistogramVoxelY.Series.Dispose();
            chartHistogramVoxelYRelation.Series.Dispose();
            chartHistogramVoxelY.ChartAreas.Clear();
            chartHistogramVoxelYRelation.ChartAreas.Clear();
            chartHistogramVoxelY.ChartAreas.Add("ChartArea1");
            chartHistogramVoxelYRelation.ChartAreas.Add("ChartArea1");

            //Вывод данных на гистограмму распределения
            Series seriesStatisticalDataY = new Series();
            Series seriesStatisticalDataYRelation = new Series();
            textBoxDataHistogram.Clear();

            if (gistY.Count != gistYSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistY.Count != gistYSum.Count");
                return;
            }

            for (int i = 0; i < gistY.Count; i++)
            {
                seriesStatisticalDataY.Points.Add(new DataPoint(Math.Round((gistY[i].Xmin + gistY[i].Xmax) / 2, 2), gistY[i].Y));
                seriesStatisticalDataYRelation.Points.Add(new DataPoint(Math.Round((gistY[i].Xmin + gistY[i].Xmax) / 2, 2),
                    gistY[i].Y / gistYSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistY[i].Xmin + "; Xmax = " + gistY[i].Xmax + "; Y = " + gistY[i].Y +
                                              "  (" + (gistY[i].Y / gistYSum[i].Y).ToString("N03") + "); \r\n";
            }
            /*
            int i = 0;
            foreach (var temp in gistY)
            {
                seriesStatisticalDataY.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2), temp.Y));
                seriesStatisticalDataYRelation.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2),
                    temp.Y / ((ListVox.Count) / (float)numericUpDownNumIntY.Value)));

                textBoxDataHistogram.Text += ++i + ") Xmin = " + temp.Xmin + "; Xmax = " + temp.Xmax + "; Y = " + temp.Y +
                                              "  (" + (temp.Y / (ListVox.Count / (float)numericUpDownNumIntX.Value)).ToString("N03") + "); \r\n";
            }
            */
            seriesStatisticalDataY.ChartArea = "ChartArea1";
            seriesStatisticalDataY.Name = "Гистограмма распределения плотности вокселей модели по оси Y";
            seriesStatisticalDataY.ChartType = SeriesChartType.Column;
            chartHistogramVoxelY.Palette = ChartColorPalette.BrightPastel;

            chartHistogramVoxelY.Series.Add(seriesStatisticalDataY);
            chartHistogramVoxelYRelation.Series.Add(seriesStatisticalDataYRelation);

            SwitchChart(activeChartType, activeChartAbsRel);

        }
        /// <summary>
        /// Вывод данных статистического анализа по распределению координат вокселей по оси Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonShowStatisticalDataZ_Click(object sender, EventArgs e)
        {
            toolStripButtonShowStatisticalDataX.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataY.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataZ.Font = new Font(this.Font, FontStyle.Bold);
            toolStripButtonShowHistogramXYZ.Font = new Font(this.Font, FontStyle.Regular);
            activeChartType = switchChartType.Z;

            textBoxMin.Text = resultStat_Z[0].ToString("0.0000E-00");
            textBoxMax.Text = resultStat_Z[1].ToString("0.0000E-00");
            textBoxInterval.Text = resultStat_Z[2].ToString("0.0000E-00");
            textBoxDispersion.Text = resultStat_Z[3].ToString("0.0000E-00");
            textBoxStandardDeviation.Text = resultStat_Z[4].ToString("0.0000E-00");
            textBoxAverage.Text = resultStat_Z[5].ToString("0.0000E-00");
            textBoxSkewness.Text = resultStat_Z[6].ToString("0.0000E-00");
            textBoxCoefficientOfExcess.Text = resultStat_Z[7].ToString("0.0000E-00");
            textBoxCoefficientOfVariation.Text = resultStat_Z[8].ToString("0.0000E-00");
            textBoxMean.Text = resultStat_Z[9].ToString("0.0000E-00");
            textBoxMode.Text = resultStat_Z[10].ToString("0.0000E-00");
            textBoxMedian.Text = resultStat_Z[11].ToString("0.0000E-00");

            //Предварительная очистка данных гистограммы
            //
            chartHistogramVoxelZ.Series.Clear();
            chartHistogramVoxelZRelation.Series.Clear();
            chartHistogramVoxelZ.Series.Dispose();
            chartHistogramVoxelZRelation.Series.Dispose();
            chartHistogramVoxelZ.ChartAreas.Clear();
            chartHistogramVoxelZRelation.ChartAreas.Clear();
            chartHistogramVoxelZ.ChartAreas.Add("ChartArea1");
            chartHistogramVoxelZRelation.ChartAreas.Add("ChartArea1");

            //Вывод данных на гистограмму распределения
            Series seriesStatisticalDataZ = new Series();
            Series seriesStatisticalDataZRelation = new Series();
            textBoxDataHistogram.Clear();

            if (gistZ.Count != gistZSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistZ.Count != gistZSum.Count");
                return;
            }

            for (int i = 0; i < gistZ.Count; i++)
            {
                seriesStatisticalDataZ.Points.Add(new DataPoint(Math.Round((gistZ[i].Xmin + gistZ[i].Xmax) / 2, 2), gistZ[i].Y));
                seriesStatisticalDataZRelation.Points.Add(new DataPoint(Math.Round((gistZ[i].Xmin + gistZ[i].Xmax) / 2, 2),
                    gistZ[i].Y / gistZSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistZ[i].Xmin + "; Xmax = " + gistZ[i].Xmax + "; Y = " + gistZ[i].Y +
                                              "  (" + (gistZ[i].Y / gistZSum[i].Y).ToString("N03") + "); \r\n";
            }

            /*
            int i = 0;
            foreach (var temp in gistZ)
            {
                seriesStatisticalDataZ.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2), temp.Y));
                seriesStatisticalDataZRelation.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2),
                                  temp.Y / ((ListVox.Count) / (float)numericUpDownNumIntZ.Value)));

                textBoxDataHistogram.Text += ++i + ") Xmin = " + temp.Xmin + "; Xmax = " + temp.Xmax + "; Y = " + temp.Y +
                                              "  (" + (temp.Y / (ListVox.Count / (float)numericUpDownNumIntX.Value)).ToString("N03") + "); \r\n";
            }
            */
            seriesStatisticalDataZ.Name = "Гистограмма распределения плотности вокселей модели по оси Z";
            seriesStatisticalDataZ.ChartType = SeriesChartType.Column;
            chartHistogramVoxelZ.Palette = ChartColorPalette.BrightPastel;

            chartHistogramVoxelZ.Series.Add(seriesStatisticalDataZ);
            chartHistogramVoxelZRelation.Series.Add(seriesStatisticalDataZRelation);

            SwitchChart(activeChartType, activeChartAbsRel);

        }
        /// <summary>
        /// Вывод данных статистического анализа по распределению координат вокселей по трем осям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonShowHistogramXYZ_Click(object sender, EventArgs e)
        {
            toolStripButtonShowStatisticalDataX.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataY.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowStatisticalDataZ.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonShowHistogramXYZ.Font = new Font(this.Font, FontStyle.Bold);

            activeChartType = switchChartType.XYZ;
            //
            textBoxMin.Clear();
            textBoxMax.Clear();
            textBoxInterval.Clear();
            textBoxDispersion.Clear();
            textBoxStandardDeviation.Clear();
            textBoxAverage.Clear();
            textBoxSkewness.Clear();
            textBoxCoefficientOfExcess.Clear();
            textBoxCoefficientOfVariation.Clear();
            textBoxMean.Clear();
            textBoxMode.Clear();
            textBoxMedian.Clear();

            //Предварительная очистка данных гистограммы
            //
            chartHistogramVoxelXYZ.Series.Clear();
            chartHistogramVoxelXYZRelative.Series.Clear();
            chartHistogramVoxelXYZ.Series.Dispose();
            chartHistogramVoxelXYZRelative.Series.Dispose();
            chartHistogramVoxelXYZ.ChartAreas.Clear();
            chartHistogramVoxelXYZRelative.ChartAreas.Clear();
            chartHistogramVoxelXYZ.ChartAreas.Add("ChartAreaX");
            chartHistogramVoxelXYZ.ChartAreas.Add("ChartAreaY");
            chartHistogramVoxelXYZ.ChartAreas.Add("ChartAreaZ");
            chartHistogramVoxelXYZRelative.ChartAreas.Add("ChartAreaX");
            chartHistogramVoxelXYZRelative.ChartAreas.Add("ChartAreaY");
            chartHistogramVoxelXYZRelative.ChartAreas.Add("ChartAreaZ");

            //Вывод данных на гистограмму распределения
            Series seriesStatisticalDataX = new Series();
            Series seriesStatisticalDataXRelation = new Series();

            Series seriesStatisticalDataY = new Series();
            Series seriesStatisticalDataYRelation = new Series();

            Series seriesStatisticalDataZ = new Series();
            Series seriesStatisticalDataZRelation = new Series();

            textBoxDataHistogram.Clear();

            if (gistX.Count != gistXSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistX.Count != gistXSum.Count");
                return;
            }

            for (int i = 0; i < gistX.Count; i++)
            {
                seriesStatisticalDataX.Points.Add(new DataPoint(Math.Round((gistX[i].Xmin + gistX[i].Xmax) / 2, 2), gistX[i].Y));
                seriesStatisticalDataXRelation.Points.Add(new DataPoint(Math.Round((gistX[i].Xmin + gistX[i].Xmax) / 2, 2),
                    gistX[i].Y / gistXSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistX[i].Xmin + "; Xmax = " + gistX[i].Xmax + "; Y = " + gistX[i].Y +
                                              "  (" + (gistX[i].Y / gistXSum[i].Y).ToString("N03") + "); \r\n";
            }

            /*
            int i = 0;
            foreach (var temp in gistX)
            {
                seriesStatisticalDataX.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2), temp.Y));
                seriesStatisticalDataXRelation.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2),
                    temp.Y / ((CountVoxelsX * CountVoxelsY * CountVoxelsZ) / (float)numericUpDownNumIntX.Value)));

                textBoxDataHistogram.Text += ++i + "X) Xmin = " + temp.Xmin + "; Xmax = " + temp.Xmax + "; Y = " + temp.Y +
                                              "  (" + (temp.Y / (ListVox.Count / (float)numericUpDownNumIntX.Value)).ToString("N03") + "); \r\n";

            }
            */
            seriesStatisticalDataX.ChartType = SeriesChartType.Column;
            seriesStatisticalDataXRelation.ChartType = SeriesChartType.Column;

            chartHistogramVoxelXYZ.Series.Add(seriesStatisticalDataX);
            chartHistogramVoxelXYZ.Series[0].ChartArea = "ChartAreaX";

            chartHistogramVoxelXYZRelative.Series.Add(seriesStatisticalDataXRelation);
            chartHistogramVoxelXYZRelative.Series[0].ChartArea = "ChartAreaX";

            //
            if (gistY.Count != gistYSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistY.Count != gistYSum.Count");
                return;
            }

            for (int i = 0; i < gistY.Count; i++)
            {
                seriesStatisticalDataY.Points.Add(new DataPoint(Math.Round((gistY[i].Xmin + gistY[i].Xmax) / 2, 2), gistY[i].Y));
                seriesStatisticalDataYRelation.Points.Add(new DataPoint(Math.Round((gistY[i].Xmin + gistY[i].Xmax) / 2, 2),
                    gistY[i].Y / gistYSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistY[i].Xmin + "; Xmax = " + gistY[i].Xmax + "; Y = " + gistY[i].Y +
                                              "  (" + (gistY[i].Y / gistYSum[i].Y).ToString("N03") + "); \r\n";
            }
            /*
            int j = 0;
            foreach (var temp in gistY)
            {
                seriesStatisticalDataY.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2), temp.Y));
                seriesStatisticalDataYRelation.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2),
                    temp.Y / ((CountVoxelsX * CountVoxelsY * CountVoxelsZ) / (float)numericUpDownNumIntY.Value)));

                textBoxDataHistogram.Text += ++j + "Y) Xmin = " + temp.Xmin + "; Xmax = " + temp.Xmax + "; Y = " + temp.Y +
                                              "  (" + (temp.Y / (ListVox.Count / (float)numericUpDownNumIntX.Value)).ToString("N03") + "); \r\n";
            }
            */
            seriesStatisticalDataY.ChartType = SeriesChartType.Column;
            seriesStatisticalDataYRelation.ChartType = SeriesChartType.Column;

            chartHistogramVoxelXYZ.Series.Add(seriesStatisticalDataY);
            chartHistogramVoxelXYZ.Series[1].ChartArea = "ChartAreaY";

            chartHistogramVoxelXYZRelative.Series.Add(seriesStatisticalDataYRelation);
            chartHistogramVoxelXYZRelative.Series[1].ChartArea = "ChartAreaY";

            //
            if (gistZ.Count != gistZSum.Count)
            {
                MessageBox.Show("Проблема статистического анализа: gistZ.Count != gistZSum.Count");
                return;
            }

            for (int i = 0; i < gistZ.Count; i++)
            {
                seriesStatisticalDataZ.Points.Add(new DataPoint(Math.Round((gistZ[i].Xmin + gistZ[i].Xmax) / 2, 2), gistZ[i].Y));
                seriesStatisticalDataZRelation.Points.Add(new DataPoint(Math.Round((gistZ[i].Xmin + gistZ[i].Xmax) / 2, 2),
                    gistZ[i].Y / gistZSum[i].Y));
                textBoxDataHistogram.Text += (i + 1) + ") Xmin = " + gistZ[i].Xmin + "; Xmax = " + gistZ[i].Xmax + "; Y = " + gistZ[i].Y +
                                              "  (" + (gistZ[i].Y / gistZSum[i].Y).ToString("N03") + "); \r\n";
            }
            /*
            int k = 0;
            foreach (var temp in gistZ)
            {
                seriesStatisticalDataZ.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2), temp.Y));
                seriesStatisticalDataZRelation.Points.Add(new DataPoint(Math.Round((temp.Xmin + temp.Xmax) / 2, 2),
                    temp.Y / ((CountVoxelsX * CountVoxelsY * CountVoxelsZ) / (float)numericUpDownNumIntZ.Value)));

                textBoxDataHistogram.Text += ++k + "Z) Xmin = " + temp.Xmin + "; Xmax = " + temp.Xmax + "; Y = " + temp.Y +
                                              "  (" + (temp.Y / (ListVox.Count / (float)numericUpDownNumIntX.Value)).ToString("N03") + "); \r\n";
            }
            */
            seriesStatisticalDataZ.ChartType = SeriesChartType.Column;
            seriesStatisticalDataZRelation.ChartType = SeriesChartType.Column;

            chartHistogramVoxelXYZ.Series.Add(seriesStatisticalDataZ);
            chartHistogramVoxelXYZ.Series[2].ChartArea = "ChartAreaZ";

            chartHistogramVoxelXYZRelative.Series.Add(seriesStatisticalDataZRelation);
            chartHistogramVoxelXYZRelative.Series[2].ChartArea = "ChartAreaZ";

            SwitchChart(activeChartType, activeChartAbsRel);
        }

        /// <summary>
        /// Увеличение гистограммы на всю экранную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartHistogramVoxel_DoubleClick(object sender, EventArgs e)
        {
            if (activeChart.Dock != DockStyle.Fill)
            {
                activeChart.Dock = DockStyle.Fill;
                activeChart.Update();
            }
            else
            {
                activeChart.Dock = DockStyle.None;
                activeChart.Update();
            }
        }

        private void исходныеДанныепоказатьскрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxDataHistogram.Visible = !textBoxDataHistogram.Visible;
        }
        /// <summary>
        /// Растянуть/Сжать график
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            chartHistogramVoxel_DoubleClick(activeChart, e);
        }
        /// <summary>
        /// Абсолютные/относительные значения на графике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Chart[] massiveChart = { chartHistogramVoxelX, chartHistogramVoxelY, chartHistogramVoxelZ, chartHistogramVoxelXYZ,
                                     chartHistogramVoxelXRelation, chartHistogramVoxelYRelation, chartHistogramVoxelZRelation,
                                     chartHistogramVoxelXYZRelative};

            SwitchChart(activeChartType, (activeChartAbsRel == switchChartAbsRel.Absolute ? switchChartAbsRel.Relative : switchChartAbsRel.Absolute));
        }
        /// <summary>
        /// Создание списка цветовых палитр для выбора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void цветоваяПалитраГистограммsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemColorSсhemе.Items.Clear();
            foreach (string strChartColorPalette in Enum.GetNames(typeof(ChartColorPalette)))
            { ToolStripMenuItemColorSсhemе.Items.Add(strChartColorPalette); }

        }
        /// <summary>
        /// Выбор цветовой палитры для текущего графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemColorSсhemе_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in Enum.GetValues(typeof(ChartColorPalette)))
                {
                    if (ToolStripMenuItemColorSсhemе.Text == (string)Enum.GetName(typeof(ChartColorPalette), i))
                    {
                        if (activeChart.Visible != false)
                            activeChart.Palette = (ChartColorPalette)i;
                    }
                }
            }
            catch (Exception e5)
            {
                MessageBox.Show("Ошибка...!  \n" + e5.Message);
            }
        }
        /// <summary>
        /// Скрыть/Показать гистограмму по оси X для XYZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if ((chartHistogramVoxelXYZ.Visible != false) && (chartHistogramVoxelXYZ.ChartAreas.Count >= 1))
                chartHistogramVoxelXYZ.ChartAreas[0].Visible = !chartHistogramVoxelXYZ.ChartAreas[0].Visible;
        }
        /// <summary>
        /// Скрыть / Показать гистограмму по оси Y для XYZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if ((chartHistogramVoxelXYZ.Visible != false) && (chartHistogramVoxelXYZ.ChartAreas.Count >= 2))
                chartHistogramVoxelXYZ.ChartAreas[1].Visible = !chartHistogramVoxelXYZ.ChartAreas[1].Visible;
        }
        /// <summary>
        /// Скрыть/Показать гистограмму по оси Z для XYZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if ((chartHistogramVoxelXYZ.Visible != false) && (chartHistogramVoxelXYZ.ChartAreas.Count >= 3))
                chartHistogramVoxelXYZ.ChartAreas[2].Visible = !chartHistogramVoxelXYZ.ChartAreas[2].Visible;
        }
        /// <summary>
        /// Создание списка типов диаграммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemTypeDiagram_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemTypeDiagram.Items.Clear();
            foreach (string strTypeDiagram in Enum.GetNames(typeof(SeriesChartType)))
            { ToolStripMenuItemTypeDiagram.Items.Add(strTypeDiagram); }
        }
        /// <summary>
        /// Задание типа диаграммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemTypeDiagram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int k in Enum.GetValues(typeof(SeriesChartType)))
                {
                    if (ToolStripMenuItemTypeDiagram.Text == (string)Enum.GetName(typeof(SeriesChartType), k))
                    {
                        if (activeChart.Visible != false)
                        {
                            for (int j = 0; j < activeChart.Series.Count; j++)
                            { activeChart.Series[j].ChartType = (SeriesChartType)k; }
                            activeChart.Update();
                        }
                    }
                }
            }
            catch (Exception e6)
            {
                MessageBox.Show("Ошибка...!  \n" + e6.Message);
            }
        }

        /// <summary>
        /// Показать/Скрыть гистограмму с количеством вокселей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAbsolute_Click(object sender, EventArgs e)
        {
            toolStripButtonAbsolute.Font = new Font(this.Font, FontStyle.Bold);
            toolStripButtonRelative.Font = new Font(this.Font, FontStyle.Regular);

            activeChartAbsRel = switchChartAbsRel.Absolute;
            SwitchChart(activeChartType, activeChartAbsRel);
        }
        /// <summary>
        /// Показать гистограмму с относительным заполнением объема
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRelative_Click(object sender, EventArgs e)
        {
            toolStripButtonAbsolute.Font = new Font(this.Font, FontStyle.Regular);
            toolStripButtonRelative.Font = new Font(this.Font, FontStyle.Bold);

            activeChartAbsRel = switchChartAbsRel.Relative;
            SwitchChart(activeChartType, activeChartAbsRel);
        }
        /// <summary>
        /// Список гистограмм (абсолютные значения, относительные значения)
        /// </summary>
        private enum switchChartAbsRel { Absolute = 0, Relative };
        private enum switchChartType { X = 0, Y, Z, XYZ };
        /// <summary>
        /// Активная гистограмма - с абсолютными или относительными величинами
        /// </summary>
        private switchChartAbsRel activeChartAbsRel = switchChartAbsRel.Absolute;
        /// <summary>
        /// Активная гистограмма - по какой оси X, Y, Z, XYZ
        /// </summary>
        private switchChartType activeChartType = switchChartType.X;
        /// <summary>
        /// Загрузка формы (Настройка формы в зависимости от решаемой задачи)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///Метка заполненности таблицы интервалов для цветовой визуализации 
        /// </summary>
        bool gridColor = false;
        /// <summary>
        /// Статистические характеристики (результаты анализа)
        /// </summary>
        public float[] resultStatPar = new float[13];
        /// <summary>
        /// Данные гистограммы
        /// </summary>
        List<Stat_analysis.elementGist> gistPar = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistParS = new List<Stat_analysis.elementGist>();
        List<object> gistParMassive = new List<object>();
        List<object> gistParMassiveOrientation = new List<object>();
        List<object> gistParMassiveS = new List<object>();
        /// <summary>
        /// Массив данных для анализа и визуализации
        /// </summary>
        List<float> tempMassivePar = new List<float>();
        /// <summary>
        /// Массив площадей граней
        /// </summary>
        List<float> tempMassiveParS = new List<float>();
        /// <summary>
        /// Список граней базовой модели (сферы)
        /// </summary>
        List<base_stl> ListStl2 = new List<base_stl>();
        /// <summary>
        /// Основная форма приложения
        /// </summary>
        ATPreparation frmMain = (ATPreparation)Application.OpenForms["ATPreparation"];
        /// <summary>
        /// Процедура для обновления progressBar
        /// </summary>
        MyProcedures progressBarVis = new MyProcedures();
    /// <summary>
    /// Расчет характеристик модели для визуального анализа
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripButtonColorVisual_Click(object sender, EventArgs e)
        {
            toolStripProgressBarVisualization.Value = 0;
            try
            {
            frmMain.richTextBoxHistory.Text += "Выполнен расчет характеристик модели для визуального анализа. \n";
            frmMain.richTextBoxHistory.Text += "Исследуемый признак: \n";
            frmMain.richTextBoxHistory.Text += toolStripComboBoxStrategicVisual.Text + ". \n";
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
            }
            ListStl2.Clear();
            ///
            if (ListStl.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа");
                return;
            }
            //
            Stat_analysis statisticaPar = new Stat_analysis();
            Stat_analysis statisticaParS = new Stat_analysis();
            //
            tempMassivePar.Clear();
            tempMassiveParS.Clear();
            if (toolStripComboBoxStrategicVisual.SelectedIndex != 7) //Не сферическое отображение модели
            {
                foreach (var TempSTL in ListStl)
                { tempMassiveParS.Add((float)TempSTL.CalcSTr()[3]); }
            }

            //Исследуемые признаки
            /*
            0 Количество смежных граней по общим ребрам
            1 Количество смежных граней по общим вершинам
            2 Коэффициент вектора нормали по оси Z (угол в градусах)
            3 Коэффициент вектора нормали по оси Z (миним. значение угла в градусах в текущем слое)
            4 Коэффициент вектора нормали по оси Z (размах значений угла в градусах в текущем слое)
            5 Коэффициент вектора нормали по оси X
            6 Коэффициент вектора нормали по оси Y
            7 Отображение нормалей треугольных граней модели изделия на базовую модель
            8 Двугранный угол между смежными гранями (минимальное значение)
            9 Двугранный угол между смежными гранями (максимальное значение)
            10 Двугранный угол между смежными гранями (среднее значение)
            11 Площадь треугольных граней
            12 Отношение радиусов вписанной и описанной окружности для треуг. грани
            13 Толщина материала по оси Z
            14 Последовательность триангуляции
            15 Плотность граней
            16 Разнообразие треугольников по площади  (количество граней на единицу площади поверхности)
             */
            switch (toolStripComboBoxStrategicVisual.SelectedIndex)
            {
                    // 0 Количество смежных граней по общим ребрам
                case 0:
                    MyProcedures tempproced0 = new MyProcedures();
                    float smegnostiRebroNum; // количество смежных граней 
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        smegnostiRebroNum = 0;
                        for (int j = 0; j < ListStl.Count; j++)
                        {
                            if (tempproced0.contiguity(ListStl[i], ListStl[j]))
                            {
                                smegnostiRebroNum++;
                            }
                        }
                        tempMassivePar.Add(smegnostiRebroNum);
                        //Прогресс
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl.Count);
                    }
                    break;

                    // 1 Количество смежных граней по общим вершинам
                case 1:
                    MyProcedures tempproced1 = new MyProcedures();
                    float smegnostiVertexNum; // количество смежных граней 
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        smegnostiVertexNum = 0;
                        for (int j = 0; j < ListStl.Count; j++)
                        {
                            if (i != j && tempproced1.contiguityVertex(ListStl[i], ListStl[j]) >= 1)
                            {
                                smegnostiVertexNum++;
                            }
                        }
                        tempMassivePar.Add(smegnostiVertexNum);
                        //Прогресс
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl.Count);
                    }
                    break;

                // 2 Коэффициент вектора нормали по оси Z
                case 2:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add((float)(Math.Acos(TempSTL.ZN) / Math.PI * 180));
                        //Прогресс
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                    
                    // 3 Коэффициент вектора нормали по оси Z (миним.значение в слое)
                case 3:
                    ///Создание массива слоев
                    float step = (float)numericUpDownStep.Value; //Шаг построения
                    tempMassivePar.Clear();
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add(TempSTL.Z1);
                        tempMassivePar.Add(TempSTL.Z2);
                        tempMassivePar.Add(TempSTL.Z3);

                    }
                    tempMassivePar.Sort();
                    float minZ = tempMassivePar[0];
                    float maxZ = tempMassivePar[tempMassivePar.Count - 1];
                    tempMassivePar.Clear();
                    int sizeMassiveStep = (int)Math.Ceiling((maxZ - minZ) / step);
                    float[] massiveStep = new float[sizeMassiveStep];

                    for (int s = 0; s < sizeMassiveStep; s++)
                    { massiveStep[s] = minZ + s * step; }
                    List<float> tempMassive = new List<float>();

                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        tempMassivePar.Add(float.MaxValue);
                    }

                    for (int t = 0; t < sizeMassiveStep; t++)
                    {
                        for (int y = 0; y < ListStl.Count; y++)
                        {
                            
                            if ((ListStl[y].MinZ() >= massiveStep[t] && ListStl[y].MinZ() <= massiveStep[t] + step) ||
                                (ListStl[y].MaxZ() >= massiveStep[t] && ListStl[y].MaxZ() <= massiveStep[t] + step) ||
                                (ListStl[y].MinZ() <= massiveStep[t] && ListStl[y].MaxZ() >= massiveStep[t] + step))
                            {
                                tempMassive.Add((float)(Math.Acos(ListStl[y].ZN) / Math.PI * 180));
                            }
                        }
                        tempMassive.Sort();
                        for (int i = 0; i < ListStl.Count; i++)
                        {
                            if ((ListStl[i].MinZ() >= massiveStep[t] && ListStl[i].MinZ() <= massiveStep[t] + step) ||
                               (ListStl[i].MaxZ() >= massiveStep[t] && ListStl[i].MaxZ() <= massiveStep[t] + step) ||
                               (ListStl[i].MinZ() <= massiveStep[t] && ListStl[i].MaxZ() >= massiveStep[t] + step))
                            {
                                tempMassivePar[i] = (tempMassivePar[i] > tempMassive[0]) ? tempMassive[0]: tempMassivePar[i];
                            }
                        }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, t, sizeMassiveStep);
                    }
                    break;
                
                    // 4 Коэффициент вектора нормали по оси Z (размах значений угла в градусах в текущем слое)
                case 4:
                    ///Создание массива слоев
                    float step2 = (float)numericUpDownStep.Value; //Шаг построения
                    tempMassivePar.Clear();
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add(TempSTL.Z1);
                        tempMassivePar.Add(TempSTL.Z2);
                        tempMassivePar.Add(TempSTL.Z3);
                    }
                    tempMassivePar.Sort();
                    float minZ2 = tempMassivePar[0];
                    float maxZ2 = tempMassivePar[tempMassivePar.Count - 1];
                    tempMassivePar.Clear();
                    int sizeMassiveStep2 = (int)Math.Ceiling((maxZ2 - minZ2) / step2);
                    float[] massiveStep2 = new float[sizeMassiveStep2];

                    for (int s = 0; s < sizeMassiveStep2; s++)
                    {
                        massiveStep2[s] = minZ2 + s * step2;
                    }
                    List<float> tempMassive2 = new List<float>();
                    //Создание пустого массива
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        tempMassivePar.Add(float.MinValue);
                    }

                    for (int t = 0; t < sizeMassiveStep2; t++)
                    {
                        for (int y = 0; y < ListStl.Count; y++)
                        {

                            if ((ListStl[y].MinZ() >= massiveStep2[t] && ListStl[y].MinZ() <= massiveStep2[t] + step2) ||
                                (ListStl[y].MaxZ() >= massiveStep2[t] && ListStl[y].MaxZ() <= massiveStep2[t] + step2) ||
                                (ListStl[y].MinZ() <= massiveStep2[t] && ListStl[y].MaxZ() >= massiveStep2[t] + step2))
                            {
                                tempMassive2.Add((float)(Math.Acos(ListStl[y].ZN) / Math.PI * 180));
                            }
                        }
                        tempMassive2.Sort();
                        float razmah = tempMassive2[tempMassive2.Count - 1] - tempMassive2[0];
                        for (int i = 0; i < ListStl.Count; i++)
                        {
                            if ((ListStl[i].MinZ() >= massiveStep2[t] && ListStl[i].MinZ() <= massiveStep2[t] + step2) ||
                               (ListStl[i].MaxZ() >= massiveStep2[t] && ListStl[i].MaxZ() <= massiveStep2[t] + step2) ||
                               (ListStl[i].MinZ() <= massiveStep2[t] && ListStl[i].MaxZ() >= massiveStep2[t] + step2))
                            {
                                tempMassivePar[i] = (tempMassivePar[i] < razmah) ? razmah : tempMassivePar[i];
                            }
                        }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, t, sizeMassiveStep2);
                    }

                    break;
                
                    // 5 Коэффициент вектора нормали по оси X
                case 5:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add((float)(Math.Acos(TempSTL.XN) / Math.PI * 180));
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                
                    // 6 Коэффициент вектора нормали по оси Y
                case 6:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add((float)(Math.Acos(TempSTL.YN) / Math.PI * 180));
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                
                    // 7 Отображение нормалей треугольных граней модели изделия на базовую модель
                case 7:
                    //Проверка отображения модели 2017/04/24
                    //string mess = "";
                    //Выбор файла для базовой модели
                    string FileName = @"Sphere.stl";
                    if (File.Exists(FileName))
                    {
                        MyProcedures ProcTranslation = new MyProcedures(); // Процедура для перевода данных из STL в список List<base_stl>
                        // Базовая модель для анализа (по умолчанию - сфера)
                        ListStl2 = ProcTranslation.translationSTLtoList(FileName);
                        List<float> zenit = new List<float>();
                        List<float> azimut = new List<float>();
                        float Radius = 50;
                        float tempValue, tempSValue;
                        float azimutSTL = 0;
                        float azimutError = (float)Math.PI / 360;
                        //Определение количества треугольников в полюсах сферы
                        int numPoleTr = 0;
                        for (int i = 0; i < ListStl2.Count; i++)
                        {
                            if((ListStl2[i].X1 == 0 && ListStl2[i].Y1 == 0) ||
                               (ListStl2[i].X2 == 0 && ListStl2[i].Y2 == 0) ||
                               (ListStl2[i].X3 == 0 && ListStl2[i].Y3 == 0))
                            numPoleTr++;
                        }
                        numPoleTr /= 2;
                        //MessageBox.Show("numPoleTr = " + numPoleTr.ToString());
                            //
                        for (int i = 0; i < ListStl2.Count; i++)
                        {
                            zenit.Clear();
                            azimut.Clear();
                            //определяем углы в сферической системе координат
                            zenit.Add(ListStl2[i].Z1 / Radius);
                            zenit.Add(ListStl2[i].Z2 / Radius);
                            zenit.Add(ListStl2[i].Z3 / Radius);
                            zenit.Sort();
                            //
                            azimut.Add((float)Math.Atan2(ListStl2[i].Y1, ListStl2[i].X1) >= 0 ?
                                (float)Math.Atan2(ListStl2[i].Y1, ListStl2[i].X1) :
                                (float)(2 * Math.PI + Math.Atan2(ListStl2[i].Y1, ListStl2[i].X1)));
                            azimut.Add((float)Math.Atan2(ListStl2[i].Y2, ListStl2[i].X2) >= 0 ?
                                (float)Math.Atan2(ListStl2[i].Y2, ListStl2[i].X2) :
                                (float)(2 * Math.PI + Math.Atan2(ListStl2[i].Y2, ListStl2[i].X2)));
                            azimut.Add((float)Math.Atan2(ListStl2[i].Y3, ListStl2[i].X3) >= 0 ?
                                (float)Math.Atan2(ListStl2[i].Y3, ListStl2[i].X3) :
                                (float)(2 * Math.PI + Math.Atan2(ListStl2[i].Y3, ListStl2[i].X3)));
                            //
                            azimut.Sort();
                            //
                            tempValue = 0;
                            tempSValue = 0;
                            for (int j = 0; j < ListStl.Count; j++)
                            {
                                azimutSTL = (float)Math.Atan2(ListStl[j].YN, ListStl[j].XN) >= 0 ?
                                (float)Math.Atan2(ListStl[j].YN, ListStl[j].XN) :
                                (float)(2 * Math.PI + Math.Atan2(ListStl[j].YN, ListStl[j].XN));
                                /*
                                mess += "ListStl[j].ZN = " + ListStl[j].ZN + " ;\n" +
                                        "zenit[0] = " + zenit[0] + " ; " + "zenit[2] = " + zenit[2] + " ; \n" +
                                        "azimutSTL = " + azimutSTL + " ;\n" +
                                        "azimut[0] = " + azimut[0] + " ; " + "azimut[2] = " + azimut[2] + " ;\n \n";
                                */
                                if (((ListStl[j].ZN > 0.999F && Math.Abs(zenit[2] - ListStl[j].ZN) < azimutError) || 
                                    (ListStl[j].ZN < -0.999F && Math.Abs(zenit[0] - ListStl[j].ZN) < azimutError)) )
                                {
                                    tempValue += 1 / (float)numPoleTr;
                                    tempSValue += (float)((base_stl)ListStl[j]).CalcSTr()[3] / numPoleTr;
                                    //tempSValue += (float)((base_stl)ListStl[j]).CalcSTr()[3] / numPoleTr / (float)((base_stl)ListStl2[i]).CalcSTr()[3];
                                }
                                else if (
                                    ((ListStl[j].ZN >= zenit[0] && ListStl[j].ZN < zenit[2]) && 
                                    ((azimut[0] == 0 && azimut[2] - azimut[0] < Math.PI && azimutSTL >= azimut[0] && azimutSTL < azimut[2]) ||
                                       ((((azimut[2] - azimut[0]) < Math.PI && azimutSTL >= azimut[0] && azimutSTL < azimut[2]) ||
                                         ((azimut[2] - azimut[0]) > Math.PI && ((azimutSTL >= 0 && azimutSTL < azimut[0]) ||
                                           (azimutSTL >= azimut[2] && azimutSTL < 2 * Math.PI))))))))
                                {
                                      tempValue++;
                                    //tempSValue += (float)((base_stl)ListStl[j]).CalcSTr()[3] / (float)((base_stl)ListStl2[i]).CalcSTr()[3];
                                    tempSValue += (float)((base_stl)ListStl[j]).CalcSTr()[3];
                                    
                                }
                            }
                            tempMassivePar.Add(tempValue);
                            tempMassiveParS.Add(tempSValue);
                            progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl2.Count);
                        }
                        toolStripButtonColorVisual.Enabled = true;
                    }
                    else
                    {
                        toolStripButtonColorVisual.Enabled = false;
                        toolStripButtonSavePLY.Enabled = false;
                    }
                    //Запись данных для анализа
                    //richTextBox_review.Text = mess;
                    break;
                    
                    // 8 Двугранный угол между смежными гранями(минимальное значение)
                case 8:
                    MyProcedures tempproced8 = new MyProcedures();
                    List<float> fiTemp8 = new List<float>(); // угол между нормалями смежных граней 
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        for (int j = 0; j < ListStl.Count; j++)
                        {
                            if (tempproced8.contiguity(ListStl[i], ListStl[j]))
                            {
                                fiTemp8.Add((float)tempproced8.AngleBetweenNormals(ListStl[i], ListStl[j]));
                            }
                        }
                        if (fiTemp8.Count != 0)
                        {
                            fiTemp8.Sort();
                            tempMassivePar.Add((float)(180 * Math.Acos(fiTemp8[0]) / Math.PI));
                        }
                        else
                        {
                            tempMassivePar.Add(0f);
                        }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl.Count);
                    }
                    break;
                //9 Двугранный угол между смежными гранями (максимальное значение)
                case 9:
                    MyProcedures tempproced9 = new MyProcedures();
                    List<float> fiTemp9 = new List<float>(); // угол между нормалями смежных граней 
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        for (int j = 0; j < ListStl.Count; j++)
                        {
                            if (tempproced9.contiguity(ListStl[i], ListStl[j]))
                            {
                                fiTemp9.Add((float)tempproced9.AngleBetweenNormals(ListStl[i], ListStl[j]));
                            }
                        }
                        if (fiTemp9.Count != 0)
                        {
                            fiTemp9.Sort();
                            tempMassivePar.Add((float)(180 * Math.Acos(fiTemp9[fiTemp9.Count - 1]) / Math.PI));
                        }
                        else
                        {
                            tempMassivePar.Add(180f);
                        }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl.Count);
                    }
                    break;
                //10 Двугранный угол между смежными гранями (среднее значение)
                case 10:
                    MyProcedures tempproced10 = new MyProcedures();
                    float fiTemp10; // угол между нормалями смежных граней 
                    int numfi; // количество смежных граней
                    for (int i = 0; i < ListStl.Count; i++)
                    {
                        fiTemp10 = 0;
                        numfi = 0;
                        
                        for (int j = 0; j < ListStl.Count; j++)
                        {
                            if (tempproced10.contiguity(ListStl[i], ListStl[j]))
                            {
                                fiTemp10 += (float)tempproced10.AngleBetweenNormals(ListStl[i], ListStl[j]);
                                numfi++;
                            }
                        }
                        if (numfi != 0)
                        { tempMassivePar.Add((float)(180 * Math.Acos(fiTemp10 / numfi) / Math.PI)); }
                        else
                        { tempMassivePar.Add(0f); }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, i, ListStl.Count);
                    }
                    break;
                //11 Площадь треугольных граней
                case 11:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add((float)TempSTL.CalcSTr()[3]);
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                //12 Отношение радиусов вписанной и описанной окружности для треуг. грани
                case 12:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add(TempSTL.CalcR()[0] / TempSTL.CalcR()[1]);
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                //13 Толщина материала по оси Z
                case 13:
                    //
                    List<float> MPeresZ = new List<float>();
                    //Проверка работоспособности
                    //StreamWriter sw = new StreamWriter(@"d:\report.txt", false);
                    int nomTr;
                    for (int k = 0; k < ListStl.Count; k++)
                    {
                        // сканирование списка данных координат треугольников class "base_stl"
                        if (ListStl[k].ZN != 0)
                        {
                            nomTr = 0;

                            //центр тяжести
                            float tempX = (ListStl[k].X1 + ListStl[k].X2 + ListStl[k].X3) / 3;
                            float tempY = (ListStl[k].Y1 + ListStl[k].Y2 + ListStl[k].Y3) / 3;
                            float tempZ = (ListStl[k].Z1 + ListStl[k].Z2 + ListStl[k].Z3) / 3;

                            MPeresZ.Clear();
                            foreach (var item in ListStl)
                            {
                                if (item.PeresZ(tempX, tempY))
                               {
                                    //запись координат пересечения с гранями модели
                                    MPeresZ.Add(item.KoordZ(tempX, tempY));
                                    /*
                                    sw.Write("ListStl[k] = " + ListStl[k].Nom +
                                                    "; Nom = " + item.Nom +
                                                    "; X = " + tempX +
                                                    "; Y = " + tempY + 
                                                    "; Z = " + item.KoordZ(tempX, tempY) + "\r\n");
                                    */
                                }
                            }
                            //sw.Write("___ MPeresZ.Count = " + MPeresZ.Count + "\r\n");
                            MPeresZ.Sort();
                            if (MPeresZ.Count == 2)
                            { tempMassivePar.Add(MPeresZ[1] - MPeresZ[0]); }
                          else if (MPeresZ.Count != 0 && MPeresZ.Count != 1)
                          {
                            
                            for (int i = 0; i < MPeresZ.Count; i++)
                            {
                                if (Math.Abs(MPeresZ[i] - tempZ) < (1 / 1000))
                                {
                                    nomTr = i;
                                }
                            }
                                if (Math.IEEERemainder(nomTr + 1, 2) == 0)
                                { tempMassivePar.Add(MPeresZ[nomTr] - MPeresZ[nomTr - 1]); }
                                else if (Math.IEEERemainder(nomTr + 1, 2) == 1)
                                {
                                    if (MPeresZ.Count >= nomTr + 2)
                                    {
                                        tempMassivePar.Add(MPeresZ[nomTr + 1] - MPeresZ[nomTr]);
                                    }
                                    else
                                    { tempMassivePar.Add(0f); }
                                }
                          }
                          else
                          {
                            tempMassivePar.Add(0f);
                          }
                        }
                        else
                        {
                            tempMassivePar.Add(0f);
                        }
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, k, ListStl.Count);
                    }
                    //sw.Close();
                    break;
                    //Последовательность триангуляции
                case 14:
                    foreach (var TempSTL in ListStl)
                    {
                        tempMassivePar.Add(TempSTL.Nom);
                        //Прогресс
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                    //Плотность граней
                case 15:
                    int numArea = (int)numericUpDownIntVisual.Value - 1; //Количество интервалов
                    float Ssum = 0; //Общая площадь модели
                    foreach (var TempSTL in ListStl)
                    { Ssum += (float)TempSTL.CalcSTr()[3]; }
                    //номер треугольника
                    int num = 0, tempNum = 0;
                    float STreangleInt = 0; //площадь интервала
                    foreach (var TempSTL in ListStl)
                    {
                        num++;
                        STreangleInt += (float)TempSTL.CalcSTr()[3];
                        if (STreangleInt >= Ssum / numArea)
                        {
                                for (int i = tempNum; i < num; i++)
                                {
                                    tempMassivePar.Add((num - tempNum) / STreangleInt);
                                }
                            tempNum = num;
                            STreangleInt = 0;
                        }

                        //Прогресс
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    if (tempMassivePar.Count < ListStl.Count)
                        {
                        STreangleInt = 0;
                        for (int m = tempNum; m < ListStl.Count; m++)
                            {
                                STreangleInt += (float)ListStl[m].CalcSTr()[3];
                            }
                        for (int i = tempNum; i < ListStl.Count; i++)
                            {
                                tempMassivePar.Add((ListStl.Count - tempNum) / STreangleInt);
                            }
                        }
                    //MessageBox.Show(ListStl.Count + "tempMassivePar.Count = " + tempMassivePar.Count);
                    //Сообщение с характеристиками плотности распределения
                    //MessageBox.Show("Среднее значение плотности граней" + (ListStl.Count / Ssum).ToString() + "шт/мм2");
                    break;
                //Разнообразие треугольников по площади  (количество граней на единицу площади поверхности)
                case 16:
                    float tempSsum = 0;
                    foreach (var TempSTL in ListStl)
                    {
                        tempSsum += (float)TempSTL.CalcSTr()[3];

                        tempMassivePar.Add(TempSTL.Nom / tempSsum);
                        progressBarVis.ProgressBarRefresh(toolStripProgressBarVisualization, TempSTL.Nom, ListStl.Count);
                    }
                    break;
                /* Проблема... Существенная неоднозначность определения толщины.
                    //14 Толщина материала в плоскости XY
                case 14:
                    //
                    List<float[]> MPeresZ14 = new List<float[]>();
                    int nomTr14 = int.MinValue;
                    for (int k = 0; k < ListStl.Count; k++)
                    {
                        //номер треугольника в порядке пересечении линией триангуляционной модели
                        nomTr14 = int.MinValue;
                        MPeresZ14.Clear();
                        //центр тяжести
                        float tempX = (ListStl[k].X1 + ListStl[k].X2 + ListStl[k].X3) / 3;
                        float tempY = (ListStl[k].Y1 + ListStl[k].Y2 + ListStl[k].Y3) / 3;
                        float tempZ = (ListStl[k].Z1 + ListStl[k].Z2 + ListStl[k].Z3) / 3;
                        // сканирование списка данных координат треугольников class "base_stl"
                            for (int m = 0; m < ListStl.Count; m++)
                            {
                                if (ListStl[m].PeresXY(tempX, tempY, tempZ, ListStl[k].XN, ListStl[k].YN))
                                {
                                    //запись расстояния до точки пересечения с гранями модели
                                    MPeresZ14.Add(ListStl[m].KoordXY(tempX, tempY, tempZ, ListStl[k].XN, ListStl[k].YN));
                                }
                            }
                            if (MPeresZ14.Count == 2)
                            { tempMassivePar.Add(Math.Abs(MPeresZ14[0][3] - MPeresZ14[1][3])); }
                            else if (MPeresZ14.Count != 0)
                            {
                                var sortedMPeresXY = from XY in MPeresZ14
                                                     orderby XY[0]
                                                     select XY;

                                var sortedMPeres = sortedMPeresXY.ToList<float[]>();
                                //
                                float tempR = (float)Math.Sqrt(tempX * tempX + tempY * tempY);

                                for (int i = 0; i < sortedMPeres.Count; i++)
                                {
                                    if (Math.Abs(sortedMPeres[i][0] - tempR) < (1 / 1000))
                                    {
                                        nomTr14 = i;
                                    }
                                }
                                //
                                if(nomTr14 == int.MinValue)
                                { tempMassivePar.Add(0f); }
                                else if (Math.IEEERemainder(nomTr14 + 1, 2) == 0)
                                {
                                    tempMassivePar.Add(sortedMPeres[nomTr14][3] - sortedMPeres[nomTr14 - 1][3]);
                                }
                                else if (Math.IEEERemainder(nomTr14 + 1, 2) == 1)
                                {
                                    if (sortedMPeres.Count >= nomTr14 + 2)
                                    {
                                        tempMassivePar.Add(sortedMPeres[nomTr14 + 1][3] - sortedMPeres[nomTr14][3]);
                                    }
                                    else
                                    { tempMassivePar.Add(0f); }
                                }
                            }
                            else
                            {
                                tempMassivePar.Add(0f);
                            }
                    }
                    break;
                    */
                default:
                    MessageBox.Show("Не выбран исследуемый признак");
                    return;
            }
            

            if (tempMassivePar.Count != 0)
            {
                //Гистограмма по количеству треугольников
                gistPar = statisticaPar.Gist(tempMassivePar.ToArray(), (int)numericUpDownIntVisual.Value);
                //Гистограмма по площади треугольников
                gistParS = statisticaParS.Gist(tempMassivePar.ToArray(), (int)numericUpDownIntVisual.Value, tempMassiveParS.ToArray());
                gistParMassive.Add(gistPar);
                gistParMassiveS.Add(gistParS);

                resultStatPar = statisticaPar.Stat(tempMassivePar.ToArray(), gistPar);
                //0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
                // 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
                /* 2017/06/12
                if (!checkBoxGist.Checked)
                { resultStatPar = statisticaPar.Stat(tempMassivePar.ToArray(), gistPar); }
                else
                { resultStatPar = statisticaParS.Stat(tempMassiveParS.ToArray(), gistPar); }
                */
                textBoxRazmahPar.Text = resultStatPar[2].ToString("0.00E-00");
                textBoxSizeInt.Text = (resultStatPar[2] / (float)numericUpDownIntVisual.Value).ToString("0.00E-00");
                //Определение цвета для каждого интервала
                float[] beginInt = new float[(int)numericUpDownIntVisual.Value];
                byte rHome = (byte)numericUpDownR1.Value;
                byte gHome = (byte)numericUpDownG1.Value;
                byte bHome = (byte)numericUpDownB1.Value;
                byte rEnd = (byte)numericUpDownR2.Value;
                byte gEnd = (byte)numericUpDownG2.Value;
                byte bEnd = (byte)numericUpDownB2.Value;
                byte ri, gi, bi;
                //
                if (dataGridViewIntervals.Rows.Count != 0)
                    dataGridViewIntervals.Rows.Clear();
                //
                for (int i = 0; i < (int)numericUpDownIntVisual.Value; i++)
                {
                    beginInt[i] = resultStatPar[0] + (float)(i / numericUpDownIntVisual.Value) * resultStatPar[2];
                    /*2017/06/04
                    ri = (byte)(rHome + (int)Math.Floor((decimal)(rEnd - rHome) * ((decimal)i / numericUpDownIntVisual.Value)));
                    gi = (byte)(gHome + (int)Math.Floor((decimal)(gEnd - gHome) * ((decimal)i / numericUpDownIntVisual.Value)));
                    bi = (byte)(bHome + (int)Math.Floor((decimal)(bEnd - bHome) * ((decimal)i / numericUpDownIntVisual.Value)));
                    */
                    ri = (byte)((rEnd + rHome)/2 + (int)Math.Floor((decimal)((rEnd - rHome)/2) 
                        * ((decimal)Math.Cos(2 * Math.PI * i / (double)numericUpDownIntVisual.Value))));
                    gi = (byte)((gEnd + gHome) / 2 + (int)Math.Floor((decimal)((gEnd - gHome) / 2)
                        * ((decimal)Math.Cos(2 * Math.PI/3 + 2 * Math.PI * i / (double)numericUpDownIntVisual.Value))));
                    bi = (byte)((bEnd + bHome) / 2 + (int)Math.Floor((decimal)((bEnd - bHome) / 2)
                        * ((decimal)Math.Cos(4 * Math.PI / 3 + 2 * Math.PI * i / (double)numericUpDownIntVisual.Value))));

                    dataGridViewIntervals.Rows.Add(beginInt[i], ri, gi, bi, 0, 0, 0);
                    dataGridViewIntervals.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(ri, gi, bi);
                    dataGridViewIntervals.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(
                        (ri + 128) <= 255 ? (ri + 128) : (ri - 128),
                        (gi > 128 ? 0 : 255),
                        (bi + 128) <= 255 ? (bi + 128) : (bi - 128));
                    dataGridViewIntervals[dataGridViewIntervals.Columns["H"].Index, i].Value =
                           dataGridViewIntervals.Rows[i].DefaultCellStyle.BackColor.GetHue();
                    dataGridViewIntervals[dataGridViewIntervals.Columns["S"].Index, i].Value =
                           dataGridViewIntervals.Rows[i].DefaultCellStyle.BackColor.GetSaturation();
                    dataGridViewIntervals[dataGridViewIntervals.Columns["V"].Index, i].Value =
                           dataGridViewIntervals.Rows[i].DefaultCellStyle.BackColor.GetBrightness();
                }
                //Добавление в dataGridView варианта визуализации
                dataGridViewVariantsVisualization.Rows.Add(
                    (dataGridViewVariantsVisualization.Rows.Count + 1),
                    toolStripComboBoxStrategicVisual.Text,
                    "",
                    "Не создан файл",
                    "Просмотр",
                    numericUpDownR1.Value,
                    numericUpDownG1.Value,
                    numericUpDownB1.Value,
                    numericUpDownR2.Value,
                    numericUpDownG2.Value,
                    numericUpDownB2.Value,
                    numericUpDownIntVisual.Value,
                    resultStatPar[0],
                    resultStatPar[1],
                    resultStatPar[2],
                    resultStatPar[3],
                    resultStatPar[4],
                    resultStatPar[5],
                    resultStatPar[6],
                    resultStatPar[7],
                    resultStatPar[8],
                    resultStatPar[9],
                    resultStatPar[10],
                    resultStatPar[11]);
                // Выделение цветом если анализ исследуемого признака по площади граней
                if (checkBoxGist.Checked)
                {
                    dataGridViewVariantsVisualization.Rows[dataGridViewVariantsVisualization.Rows.Count - 1].DefaultCellStyle.BackColor =
                                Color.FromArgb(180, 180, 255);
                    dataGridViewVariantsVisualization.Rows[dataGridViewVariantsVisualization.Rows.Count - 1].DefaultCellStyle.Font =
                                      new Font(this.Font, FontStyle.Bold);
                }
                //
                gridColor = true;
                toolStripStatusLabelColorVisual.Text = "Статистический анализ данных по выбранному параметру выполнен.";
                toolStripStatusLabelColorVisual.ForeColor = Color.Black;
                //
                
                toolStripButtonColorVisual.Enabled = true;
            }
            else
            { toolStripButtonColorVisual.Enabled = false; }

            toolStripButtonSavePLY.Enabled = false;
        }

        //Массив цветов визуализации 
        public List<colorVisual> ListColorDistribution = new List<colorVisual>();
        /// <summary>
        /// Визуализация модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonColorVisual_Click_1(object sender, EventArgs e)
        {
            if (!gridColor)
            { return; }
            //Чистка списка
            ListColorDistribution.Clear();
            try
            {
                for (int i = 0; i < dataGridViewIntervals.Rows.Count; i++)
                {
                    if (dataGridViewIntervals[dataGridViewIntervals.Columns["Begin"].Index, i].Value != null)
                    {
                        colorVisual tempTablColorDistribution = new colorVisual();
                        tempTablColorDistribution.Nom = i;
                        tempTablColorDistribution.Begin = float.Parse(dataGridViewIntervals[dataGridViewIntervals.Columns["Begin"].Index, i].Value.ToString());
                        tempTablColorDistribution.R = byte.Parse(dataGridViewIntervals[dataGridViewIntervals.Columns["R"].Index, i].Value.ToString());
                        tempTablColorDistribution.G = byte.Parse(dataGridViewIntervals[dataGridViewIntervals.Columns["G"].Index, i].Value.ToString());
                        tempTablColorDistribution.B = byte.Parse(dataGridViewIntervals[dataGridViewIntervals.Columns["B"].Index, i].Value.ToString());
                        ListColorDistribution.Add(tempTablColorDistribution);
                    }
                }
            }
            catch (Exception e5)
            {
                MessageBox.Show(e5.Message + "\n" + "ListColorDistribution.Count = " + ListColorDistribution.Count);
                return;
            }
            float tempPar = 0;
            if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
            {
                for (int i = 0; i < ListStl.Count; i++)
                {
                    tempPar = tempMassivePar[i];
                    for (int j = 0; j < ListColorDistribution.Count; j++)
                    {
                        if (((j < (ListColorDistribution.Count - 1)) && tempPar >= ListColorDistribution[j].Begin &&
                            tempPar < ListColorDistribution[j + 1].Begin) ||
                            ((j == (ListColorDistribution.Count - 1)) && (tempPar >= ListColorDistribution[j].Begin)))
                        {
                            ListStl[i].Rface = ListColorDistribution[j].R;
                            ListStl[i].Gface = ListColorDistribution[j].G;
                            ListStl[i].Bface = ListColorDistribution[j].B;
                        }
                    }
                }
            }
            else
            {
                //Отображение на сферу
                for (int i = 0; i < ListStl2.Count; i++)
                {
                    // По количеству граней или площади
                    if (checkBoxGist.Checked)
                    { tempPar = tempMassiveParS[i]; }
                    else
                    { tempPar = tempMassivePar[i]; }
                    for (int j = 0; j < ListColorDistribution.Count; j++)
                    {
                        if (((j < (ListColorDistribution.Count - 1)) && tempPar >= ListColorDistribution[j].Begin &&
                            tempPar < ListColorDistribution[j + 1].Begin) ||
                            ((j == (ListColorDistribution.Count - 1)) && (tempPar >= ListColorDistribution[j].Begin)))
                        {
                            ListStl2[i].Rface = ListColorDistribution[j].R;
                            ListStl2[i].Gface = ListColorDistribution[j].G;
                            ListStl2[i].Bface = ListColorDistribution[j].B;
                        }
                    }
                }
            }

            toolStripStatusLabelColorVisual.Text = "Данные готовы для сохранения файла";
            toolStripStatusLabelColorVisual.ForeColor = Color.Green;
            toolStripButtonSavePLY.Enabled = true;
        }

    private void AnalColorVisual_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDownG1_ValueChanged(object sender, EventArgs e)
        {
            labelRGB1.BackColor = Color.FromArgb((int)numericUpDownR1.Value,
                                  (int)numericUpDownG1.Value, (int)numericUpDownB1.Value);
            if (numericUpDownR1.Value < 64 || numericUpDownG1.Value < 64 || numericUpDownB1.Value < 64)
            {
                labelRGB1.ForeColor = Color.White;
            }
            else if (numericUpDownR1.Value < 128 || numericUpDownG1.Value < 128 || numericUpDownB1.Value < 128)
            { labelRGB1.ForeColor = Color.Yellow; }
            else
            { labelRGB1.ForeColor = Color.Black; }
        }
        /// <summary>
        /// Задание первого цвета (MouseDoubleClick)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelRGB1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                labelRGB1.BackColor = colorDialogSelect.Color;
                numericUpDownR1.Value = colorDialogSelect.Color.R;
                numericUpDownG1.Value = colorDialogSelect.Color.G;
                numericUpDownB1.Value = colorDialogSelect.Color.B;
            }
            if (colorDialogSelect.Color.R < 40 || colorDialogSelect.Color.G < 40 || colorDialogSelect.Color.B < 40)
            {
                labelRGB1.ForeColor = Color.White;
            }
            else if (colorDialogSelect.Color.R < 128 || colorDialogSelect.Color.G < 128 || colorDialogSelect.Color.B < 128)
            { labelRGB1.ForeColor = Color.Yellow; }
            else
            { labelRGB1.ForeColor = Color.Black; }
        }
        /// <summary>
        /// Задание второго цвета (MouseDoubleClick)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelRGB2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                labelRGB2.BackColor = colorDialogSelect.Color;
                numericUpDownR2.Value = colorDialogSelect.Color.R;
                numericUpDownG2.Value = colorDialogSelect.Color.G;
                numericUpDownB2.Value = colorDialogSelect.Color.B;
            }
            if (colorDialogSelect.Color.R < 40 || colorDialogSelect.Color.G < 40 || colorDialogSelect.Color.B < 40)
            {
                labelRGB2.ForeColor = Color.White;
            }
            else if (colorDialogSelect.Color.R < 128 || colorDialogSelect.Color.G < 128 || colorDialogSelect.Color.B < 128)
            { labelRGB2.ForeColor = Color.Yellow; }
            else
            { labelRGB2.ForeColor = Color.Black; }
        }

        private void numericUpDownR2_ValueChanged(object sender, EventArgs e)
        {
            labelRGB2.BackColor = Color.FromArgb((int)numericUpDownR2.Value,
                      (int)numericUpDownG2.Value, (int)numericUpDownB2.Value);
            if (numericUpDownR2.Value < 64 || numericUpDownG2.Value < 64 || numericUpDownB2.Value < 64)
            {
                labelRGB2.ForeColor = Color.White;
            }
            else if (numericUpDownR2.Value < 128 || numericUpDownG2.Value < 128 || numericUpDownB2.Value < 128)
            { labelRGB2.ForeColor = Color.Yellow; }
            else
            { labelRGB2.ForeColor = Color.Black; }
        }
        /// <summary>
        /// Обновление формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalColorVisual_Enter(object sender, EventArgs e)
        {
            numericUpDownG1_ValueChanged(sender, e);
            numericUpDownR2_ValueChanged(sender, e);
            if (ListStl.Count != 0 && numericUpDownIntVisual.Value > ListStl.Count)
            {
                MessageBox.Show("Количество интервалов меньше количества граней в модели.", "Предупреждение!");
                numericUpDownIntVisual.Value = (decimal)ListStl.Count;
            }
        }
        /// <summary>
        /// Выбор цвета в таблице интервалов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewIntervals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //игнорирование нажатия вне кнопки
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewIntervals.Columns["SetColor"].Index) return;
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorDialogSelect.Color;
            }
            //2017/03/07
            dataGridViewIntervals[dataGridViewIntervals.Columns["R"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.R;
            dataGridViewIntervals[dataGridViewIntervals.Columns["G"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.G;
            dataGridViewIntervals[dataGridViewIntervals.Columns["B"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.B;
            dataGridViewIntervals[dataGridViewIntervals.Columns["H"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.GetHue();
            dataGridViewIntervals[dataGridViewIntervals.Columns["S"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.GetSaturation();
            dataGridViewIntervals[dataGridViewIntervals.Columns["V"].Index, e.RowIndex].Value =
                   dataGridViewIntervals.Rows[e.RowIndex].DefaultCellStyle.BackColor.GetBrightness();
        }
        /// <summary>
        /// Список вершин
        /// </summary>
        List<base_vertex> listVertex = new List<base_vertex>();
        List<base_vertex> listVertex2 = new List<base_vertex>();

        /// <summary>
        /// Сохранение данных о триангуляционной модели в формат PLY, AMF, XLS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSavePLY_Click(object sender, EventArgs e)
        {
            if (ListStl.Count == 0 || (ListStl2.Count == 0 && toolStripComboBoxStrategicVisual.SelectedIndex == 7))
            {
                return;
            }
            //Начало процедуры
            DateTime StartTime, EndTime;
            StartTime = DateTime.Now;
            // Простановка номеров вершин
            //listVertex.Clear();
            MyProcedures MyProclistVertex = new MyProcedures();
            if (toolStripComboBoxSelestFormatFile.SelectedIndex != 2)
            {
                if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                {
                    if (listVertex.Count == 0)
                    {
                        var tempList = MyProclistVertex.translationSTLtoListVertex(ListStl, toolStripProgressBarVisualization);
                        listVertex = (List<base_vertex>)tempList[0];
                        ListStl = (List<base_stl>)tempList[1];
                    }
                }
                else
                {
                        var tempList2 = MyProclistVertex.translationSTLtoListVertex(ListStl2, toolStripProgressBarVisualization);
                        listVertex2 = (List<base_vertex>)tempList2[0];
                        ListStl2 = (List<base_stl>)tempList2[1];
                }
            }
            EndTime = DateTime.Now;
            //Запись файла
            toolStripStatusLabelColorVisual.Text = "Сохранение модели...";
            saveFileDialog1.FileName = "Anal_" +
                           DateTime.Now.Year.ToString() + "_" +
                           DateTime.Now.Month.ToString() + "_" +
                           DateTime.Now.Day.ToString() + "_" +
                           DateTime.Now.Hour.ToString() + "_" +
                           DateTime.Now.Minute.ToString();
            saveFileDialog1.AddExtension = true;
            if (toolStripComboBoxSelestFormatFile.SelectedIndex == 1) //PLY формат
            { 

            saveFileDialog1.DefaultExt = ".ply";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    StreamWriter sw = new
                        StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                    sw.WriteLine("ply");
                    sw.WriteLine("format ascii 1.0");
                    sw.WriteLine("comment Color analysis: PLY; " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                    {
                        sw.WriteLine("element vertex " + listVertex.Count);
                    }
                    else
                    {
                        sw.WriteLine("element vertex " + listVertex2.Count);
                    }
                    sw.WriteLine("property float x");
                    sw.WriteLine("property float y");
                    sw.WriteLine("property float z");
                    if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                    { 
                        sw.WriteLine("element face " + ListStl.Count);
                    }
                    else
                    {
                        sw.WriteLine("element face " + ListStl2.Count);
                    }
                    sw.WriteLine("property list uchar int vertex_indices " + "\n" +
                                 "property uchar red" + "\n" +
                                 "property uchar green" + "\n" +
                                 "property uchar blue" + "\n" +
                                 "end_header");

                    //Список вершин и граней
                    if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                    {
                        foreach (var tempVertex in listVertex)
                        {
                            sw.WriteLine(tempVertex.ToString().Replace(',', '.'));
                        }
                        foreach (var tempFace in ListStl)
                        {
                            sw.WriteLine("3 " + tempFace.NomV1 + " " + tempFace.NomV2 + " " + tempFace.NomV3 + " " +
                                         tempFace.Rface + " " + tempFace.Gface + " " + tempFace.Bface);
                        }
                    }
                    else
                    {
                        foreach (var tempVertex in listVertex2)
                        {
                            sw.WriteLine(tempVertex.ToString().Replace(',', '.'));
                        }
                        foreach (var tempFace in ListStl2)
                        {
                            sw.WriteLine("3 " + tempFace.NomV1 + " " + tempFace.NomV2 + " " + tempFace.NomV3 + " " +
                                         tempFace.Rface + " " + tempFace.Gface + " " + tempFace.Bface);
                        }
                    }
                    sw.Close();
                    
                    ///
                    //dataGridViewVariantsVisualization
                    //NameFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["NameFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 saveFileDialog1.FileName;
                    //ButtonOpenFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["ButtonOpenFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 "Просмотр";
                    try
                    {
                        frmMain.richTextBoxHistory.Text += "Сохранена цветовая модель для анализа: \n";
                        frmMain.richTextBoxHistory.Text += saveFileDialog1.FileName + " \n";
                        
                        toolStripStatusLabelColorVisual.Text = "Файл сохранен за " +
                                       (EndTime - StartTime).Minutes + " мин " +
                                       (EndTime - StartTime).Seconds + " с " +
                                       (EndTime - StartTime).Milliseconds + " мс";
                    }
                    catch (Exception e8)
                    {
                        MessageBox.Show(e8.Message);
                    }
                }
            }
            else if (toolStripComboBoxSelestFormatFile.SelectedIndex == 0) //AMF формат
            {

                saveFileDialog1.DefaultExt = ".amf";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    XmlTextWriter AMFWritter = new XmlTextWriter(saveFileDialog1.FileName, Encoding.UTF8);
                    AMFWritter.WriteStartDocument();

                    //amf
                    AMFWritter.WriteStartElement("amf");
                    AMFWritter.WriteAttributeString("unit", "millimeter");
                    AMFWritter.WriteEndElement();
                    AMFWritter.Close();
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(saveFileDialog1.FileName);
                    /*
                    //constellation
                    XmlNode constellation = xDoc.CreateElement("constellation");
                    xDoc.DocumentElement.AppendChild(constellation);
                    XmlAttribute attribute = xDoc.CreateAttribute("id"); // атрибут
                    attribute.Value = "0"; // значение атрибута
                    constellation.Attributes.Append(attribute); // добавляем атрибут
                    
                    //instance
                    XmlNode instance = xDoc.CreateElement("instance"); // имя
                    constellation.AppendChild(instance); // кому принадлежит
                    XmlAttribute objectid = xDoc.CreateAttribute("objectid"); // атрибут
                    objectid.Value = toolStripTextBox1.Text; // значение атрибута - имя файла исходной модели
                    instance.Attributes.Append(objectid); // добавляем атрибут
                    */
                    //object
                    XmlNode Xmlobject = xDoc.CreateElement("object"); // имя
                    xDoc.DocumentElement.AppendChild(Xmlobject); // кому принадлежит
                    XmlAttribute id = xDoc.CreateAttribute("id"); // атрибут
                    id.Value = "0"; // значение атрибута - имя файла исходной модели
                    Xmlobject.Attributes.Append(id); // добавляем атрибут
                    XmlAttribute file = xDoc.CreateAttribute("file"); // атрибут
                    XmlAttribute type = xDoc.CreateAttribute("type"); // атрибут
                    type.Value = toolStripComboBoxStrategicVisual.Text; // значение атрибута - исследуемый признак
                    file.Value = toolStripTextBoxFileName.Text; // значение атрибута - имя файла исходной модели
                    Xmlobject.Attributes.Append(type); // добавляем атрибут
                    Xmlobject.Attributes.Append(file); // добавляем атрибут
                    //mesh
                    XmlNode mesh = xDoc.CreateElement("mesh");
                    Xmlobject.AppendChild(mesh);
                    //vertices
                    XmlNode vertices = xDoc.CreateElement("vertices");
                    mesh.AppendChild(vertices);
                    // listVertex

                    if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                    {
                        foreach (var item in listVertex)
                        {
                            //vertex
                            XmlNode vertex = xDoc.CreateElement("vertex");
                            vertices.AppendChild(vertex);
                            //coordinates
                            XmlNode coordinates = xDoc.CreateElement("coordinates");
                            vertex.AppendChild(coordinates);
                            //
                            XmlNode x = xDoc.CreateElement("x"); // имя
                            x.InnerText = item.X.ToString().Replace(',','.'); // значение
                            coordinates.AppendChild(x); // кому принадлежит
                            XmlNode y = xDoc.CreateElement("y"); // имя
                            y.InnerText = item.Y.ToString().Replace(',', '.'); // значение
                            coordinates.AppendChild(y); // кому принадлежит
                            XmlNode z = xDoc.CreateElement("z"); // имя
                            z.InnerText = item.Z.ToString().Replace(',', '.'); // значение
                            coordinates.AppendChild(z); // кому принадлежит
                        }
                        //volume
                        XmlNode volume = xDoc.CreateElement("volume");
                        mesh.AppendChild(volume);
                        // listSTL
                        foreach (var item in ListStl)
                        {
                            //triangle
                            XmlNode triangle = xDoc.CreateElement("triangle");
                            volume.AppendChild(triangle);
                            
                            //color
                            XmlNode color = xDoc.CreateElement("color");
                            triangle.AppendChild(color);
                            //
                            XmlNode r = xDoc.CreateElement("r"); // имя
                            r.InnerText = ((float)item.Rface/255).ToString("0.0000").Replace(',','.'); // значение
                            color.AppendChild(r); // кому принадлежит
                            XmlNode g = xDoc.CreateElement("g"); // имя
                            g.InnerText = ((float)item.Gface / 255).ToString("0.0000").Replace(',', '.'); // значение
                            color.AppendChild(g); // кому принадлежит
                            XmlNode b = xDoc.CreateElement("b"); // имя
                            b.InnerText = ((float)item.Bface / 255).ToString("0.0000").Replace(',', '.'); // значение
                            color.AppendChild(b); // кому принадлежит
                            
                                                  //
                            XmlNode v1 = xDoc.CreateElement("v1"); // имя
                            v1.InnerText = item.NomV1.ToString(); // значение
                            triangle.AppendChild(v1); // кому принадлежит
                            XmlNode v2 = xDoc.CreateElement("v2"); // имя
                            v2.InnerText = item.NomV2.ToString(); // значение
                            triangle.AppendChild(v2); // кому принадлежит
                            XmlNode v3 = xDoc.CreateElement("v3"); // имя
                            v3.InnerText = item.NomV3.ToString(); // значение
                            triangle.AppendChild(v3); // кому принадлежит
                        }
                    }
                    else
                    {
                        foreach (var item in listVertex2)
                        {
                            //vertex
                            XmlNode vertex = xDoc.CreateElement("vertex");
                            vertices.AppendChild(vertex);
                            //coordinates
                            XmlNode coordinates = xDoc.CreateElement("coordinates");
                            vertex.AppendChild(coordinates);
                            //
                            XmlNode x = xDoc.CreateElement("x"); // имя
                            x.InnerText = item.X.ToString().Replace(',', '.'); // значение
                            coordinates.AppendChild(x); // кому принадлежит
                            XmlNode y = xDoc.CreateElement("y"); // имя
                            y.InnerText = item.Y.ToString().Replace(',', '.'); // значение
                            coordinates.AppendChild(y); // кому принадлежит
                            XmlNode z = xDoc.CreateElement("z"); // имя
                            z.InnerText = item.Z.ToString().Replace(',', '.'); // значение
                            coordinates.AppendChild(z); // кому принадлежит
                        }
                        //volume
                        XmlNode volume = xDoc.CreateElement("volume");
                        mesh.AppendChild(volume);
                        // listSTL2
                        foreach (var item in ListStl2)
                        {
                            //triangle
                            XmlNode triangle = xDoc.CreateElement("triangle");
                            volume.AppendChild(triangle);

                            //color
                            XmlNode color = xDoc.CreateElement("color");
                            triangle.AppendChild(color);
                            //
                            XmlNode r = xDoc.CreateElement("r"); // имя
                            r.InnerText = ((float)item.Rface / 255).ToString("0.0000").Replace(',', '.'); // значение
                            color.AppendChild(r); // кому принадлежит
                            XmlNode g = xDoc.CreateElement("g"); // имя
                            g.InnerText = ((float)item.Gface / 255).ToString("0.0000").Replace(',', '.'); // значение
                            color.AppendChild(g); // кому принадлежит
                            XmlNode b = xDoc.CreateElement("b"); // имя
                            b.InnerText = ((float)item.Bface / 255).ToString("0.0000").Replace(',', '.'); // значение
                            color.AppendChild(b); // кому принадлежит

                            //
                            XmlNode v1 = xDoc.CreateElement("v1"); // имя
                            v1.InnerText = item.NomV1.ToString(); // значение
                            triangle.AppendChild(v1); // кому принадлежит
                            XmlNode v2 = xDoc.CreateElement("v2"); // имя
                            v2.InnerText = item.NomV2.ToString(); // значение
                            triangle.AppendChild(v2); // кому принадлежит
                            XmlNode v3 = xDoc.CreateElement("v3"); // имя
                            v3.InnerText = item.NomV3.ToString(); // значение
                            triangle.AppendChild(v3); // кому принадлежит
                        }
                    }
                    xDoc.Save(saveFileDialog1.FileName);

                    toolStripStatusLabelColorVisual.Text = "Модель сохранена за " +
                                                           (EndTime - StartTime).Minutes + " мин " +
                                                           (EndTime - StartTime).Seconds + " с " +
                                                           (EndTime - StartTime).Milliseconds + " мс";
                    ///
                    //dataGridViewVariantsVisualization
                    //NameFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["NameFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 saveFileDialog1.FileName;
                    //ButtonOpenFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["ButtonOpenFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 "Просмотр";
                    try
                    {
                        frmMain.richTextBoxHistory.Text += "Создана и сохранена модель для цветового анализа: \n";
                        frmMain.richTextBoxHistory.Text += saveFileDialog1.FileName + " \n";
                    }
                    catch (Exception e9)
                    {
                        MessageBox.Show(e9.Message);
                    }
                }
            }
            else if (toolStripComboBoxSelestFormatFile.SelectedIndex == 2) //XLS формат
            {
                saveFileDialog1.DefaultExt = ".xls";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    try
                    {
                        MSExel.Application ExcelApp = new MSExel.Application();
                        MSExel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add();
                        MSExel.Sheets Sheets = ExcelWorkBook.Worksheets;
                        MSExel.Worksheet ExcelWorkSheet = (MSExel.Worksheet)Sheets.get_Item(1);
                        //заголовки
                        ExcelApp.Cells[1, 1] = "R";
                        ExcelApp.Cells[1, 2] = "G";
                        ExcelApp.Cells[1, 3] = "B";
                        ExcelApp.Cells[1, 4] = "Data";

                        if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                        {
                            // listSTL
                            for (int i = 0; i < ListStl.Count; i++)
                            {

                                ExcelApp.Cells[i + 1, 1] = ListStl[i].Rface;
                                ExcelApp.Cells[i + 1, 2] = ListStl[i].Gface;
                                ExcelApp.Cells[i + 1, 3] = ListStl[i].Bface;
                                // По количеству граней или площади
                                if (checkBoxGist.Checked)
                                { ExcelApp.Cells[i + 1, 4] = tempMassiveParS[i]; }
                                else
                                { ExcelApp.Cells[i + 1, 4] = tempMassivePar[i]; }

                            }
                        }
                        else
                        {
                            // listSTL2
                            for (int i = 0; i < ListStl2.Count; i++)
                            {

                                ExcelApp.Cells[i + 1, 1] = ListStl2[i].Rface;
                                ExcelApp.Cells[i + 1, 2] = ListStl2[i].Gface;
                                ExcelApp.Cells[i + 1, 3] = ListStl2[i].Bface;
                                // По количеству граней или площади
                                if (checkBoxGist.Checked)
                                { ExcelApp.Cells[i + 1, 4] = tempMassiveParS[i]; }
                                else
                                { ExcelApp.Cells[i + 1, 4] = tempMassivePar[i]; }

                            }
                        }
                        ExcelApp.Visible = false;
                        ExcelApp.AlertBeforeOverwriting = false;
                        ExcelWorkBook.SaveAs(fileName);
                        ExcelApp.Quit();
                        
                    }
                    catch (Exception err)
                    {
                        fileName = fileName.Replace(".xls", ".txt");
                        StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);
                        sw.WriteLine("R \t G \t B \t Data");
                        if (toolStripComboBoxStrategicVisual.SelectedIndex != 7)
                        {
                            // listSTL
                            for (int i = 0; i < ListStl.Count; i++)
                            {
                                // По количеству граней или площади
                                if (checkBoxGist.Checked)
                                { sw.WriteLine(ListStl[i].Rface + "\t" + ListStl[i].Gface + "\t" + ListStl[i].Bface + "\t" + tempMassiveParS[i]); }
                                else
                                { sw.WriteLine(ListStl[i].Rface + "\t" + ListStl[i].Gface + "\t" + ListStl[i].Bface + "\t" + tempMassivePar[i]); }
                            }
                        }
                        else
                        {
                            // listSTL2
                            for (int i = 0; i < ListStl2.Count; i++)
                            {
                                // По количеству граней или площади
                                if (checkBoxGist.Checked)
                                { sw.WriteLine(ListStl2[i].Rface + "\t" + ListStl2[i].Gface + "\t" + ListStl2[i].Bface + "\t" + tempMassiveParS[i]); }
                                else
                                { sw.WriteLine(ListStl2[i].Rface + "\t" + ListStl2[i].Gface + "\t" + ListStl2[i].Bface + "\t" + tempMassivePar[i]); }
                            }
                        }
                        sw.Close();
                        
                        MessageBox.Show("Проблемы с приложением MS Excel \n" +
                                        "Данные сохранены в текстовый файл. \n\n" + err.Message);
                    }
                    toolStripStatusLabelColorVisual.Text = "Данные сохранены за " +
                                                           (EndTime - StartTime).Minutes + " мин " +
                                                           (EndTime - StartTime).Seconds + " с " +
                                                           (EndTime - StartTime).Milliseconds + " мс";
                    ///
                    //dataGridViewVariantsVisualization
                    //NameFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["NameFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 fileName;
                    //ButtonOpenFile
                    dataGridViewVariantsVisualization[dataGridViewVariantsVisualization.Columns
                        ["ButtonOpenFile"].Index, (dataGridViewVariantsVisualization.Rows.Count - 1)].Value =
                                 "Просмотр";
                    try
                    {
                        frmMain.richTextBoxHistory.Text += "Сохранены данные для анализа: \n";
                        frmMain.richTextBoxHistory.Text += fileName + " \n";
                    }
                    catch (Exception e10)
                    {
                        MessageBox.Show(e10.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Сохранение модели (списка )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (var TempSTL in ListStl)
            {

            }
            richTextBoxInfo.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxInfo.Text += "Сохранены данные списка ListStl в файл" + "\n";
        }
        /// <summary>
        /// Вызов гистограммы и просмотра модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewVariantsVisualization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //игнорирование нажатия вне кнопки
            if (e.RowIndex < 0) return;
            //Просмотр модели
            if (e.ColumnIndex == dataGridViewVariantsVisualization.Columns["ButtonOpenFile"].Index)
            {
                try
                {
                    string tempNameFile = dataGridViewVariantsVisualization
                                   [dataGridViewVariantsVisualization.Columns["NameFile"].Index, e.RowIndex].Value.ToString();
                    if (tempNameFile.Substring(tempNameFile.LastIndexOf('.') + 1).ToLower() == "ply" ||
                        tempNameFile.Substring(tempNameFile.LastIndexOf('.') + 1).ToLower() == "amf")
                    {
                        if (File.Exists(@SettingsUser.Default.MagicsPuth) &&
                          File.Exists(tempNameFile))
                        {

                            proc.StartInfo.FileName = @SettingsUser.Default.MagicsPuth;
                            proc.StartInfo.Arguments = @tempNameFile;
                            proc.Start();
                        }
                        else
                        {
                            MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                                @SettingsUser.Default.MagicsPuth + " или \n" + tempNameFile);
                        }
                    }
                    else if (tempNameFile.Substring(tempNameFile.LastIndexOf('.') + 1).ToLower() == "xls")
                    {
                        if (File.Exists(@SettingsUser.Default.ExcelPath) &&
                        File.Exists(tempNameFile))
                        {
                            proc.StartInfo.FileName = @SettingsUser.Default.ExcelPath;
                            proc.StartInfo.Arguments = @tempNameFile;
                            proc.Start();
                        }
                        else
                        {
                            MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                                @SettingsUser.Default.ExcelPath + " или \n" + tempNameFile);
                        }
                    }
                    else if (tempNameFile.Substring(tempNameFile.LastIndexOf('.') + 1).ToLower() == "txt")
                    {
                        if ( File.Exists(tempNameFile))
                        {
                            proc.StartInfo.FileName = @"Notepad.exe";
                            proc.StartInfo.Arguments = @tempNameFile;
                            proc.Start();
                        }
                        else
                        {
                            MessageBox.Show("Нет файла: \n" + tempNameFile);
                        }
                    }
                }
                catch (Exception e16)
                {
                    MessageBox.Show(e16.Message);
                }
            }
            //Просмотр гистограммы (при проверке - Range)
            if (e.ColumnIndex == dataGridViewVariantsVisualization.Columns["ReviewGist"].Index &&
                dataGridViewVariantsVisualization.Rows[e.RowIndex].Cells["Range"].Value.ToString().TrimEnd() != "0" &&
                dataGridViewVariantsVisualization.Rows[e.RowIndex].Cells["Range"].Value.ToString().TrimEnd().ToLower() != "не число")
            {
                try
                {
                    FormGist formGistogram = new FormGist();
                    formGistogram.Activate();
                    formGistogram.Show();
                    formGistogram.Text = dataGridViewVariantsVisualization
                                         [dataGridViewVariantsVisualization.Columns["Parametr"].Index, e.RowIndex].Value.ToString();
                    ///
                    //Предварительная очистка данных гистограммы
                    formGistogram.chartGistogram.Series.Clear();
                    formGistogram.chartGistogram.Series.Dispose();
                    formGistogram.chartGistogram.ChartAreas.Clear();
                    formGistogram.chartGistogram.ChartAreas.Add("ChartArea1");

                    formGistogram.chartGistogram.ChartAreas[0].AxisX.Minimum = double.Parse(dataGridViewVariantsVisualization
                                     [dataGridViewVariantsVisualization.Columns["MinInterval"].Index, e.RowIndex].Value.ToString());
                    formGistogram.chartGistogram.ChartAreas[0].AxisX.Maximum = double.Parse(dataGridViewVariantsVisualization
                         [dataGridViewVariantsVisualization.Columns["MaxInterval"].Index, e.RowIndex].Value.ToString());
                    ///
                    //Предварительная очистка данных графика интегральной функции
                    formGistogram.chartIntegral.Series.Clear();
                    formGistogram.chartIntegral.Series.Dispose();
                    formGistogram.chartIntegral.ChartAreas.Clear();
                    formGistogram.chartIntegral.ChartAreas.Add("ChartArea1");

                    formGistogram.chartIntegral.ChartAreas[0].AxisX.Minimum =
                    formGistogram.chartGistogram.ChartAreas[0].AxisX.Minimum = double.Parse(dataGridViewVariantsVisualization
                                     [dataGridViewVariantsVisualization.Columns["MinInterval"].Index, e.RowIndex].Value.ToString());
                    formGistogram.chartIntegral.ChartAreas[0].AxisX.Maximum =
                    formGistogram.chartGistogram.ChartAreas[0].AxisX.Maximum = double.Parse(dataGridViewVariantsVisualization
                         [dataGridViewVariantsVisualization.Columns["MaxInterval"].Index, e.RowIndex].Value.ToString());
                    //Вывод данных на гистограмму распределения
                    Series seriesStatisticalPar = new Series();
                    Series seriesStatisticalPar2 = new Series();
                    List<Stat_analysis.elementGist> gistParTemp = new List<Stat_analysis.elementGist>();
                    if (checkBoxGist.CheckState == CheckState.Unchecked)
                    {
                        gistParTemp = (List<Stat_analysis.elementGist>)gistParMassive[e.RowIndex];
                    }
                    else if (checkBoxGist.CheckState == CheckState.Checked)
                    {
                        gistParTemp = (List<Stat_analysis.elementGist>)gistParMassiveS[e.RowIndex];
                    }
                    float SumInt = 0;
                    float SumPar = 0;
                    //Относительные величины
                    for (int i = 0; i < gistParTemp.Count; i++)
                    {
                        SumPar += gistParTemp[i].Y;
                    }
                    //
                    for (int i = 0; i < gistParTemp.Count; i++)
                    {
                        seriesStatisticalPar.Points.Add(
                            new DataPoint(Math.Round((gistParTemp[i].Xmin + gistParTemp[i].Xmax) / 2, 2), gistParTemp[i].Y / SumPar));
                        SumInt += gistParTemp[i].Y;
                        seriesStatisticalPar2.Points.Add(
                            new DataPoint(Math.Round((gistParTemp[i].Xmin + gistParTemp[i].Xmax) / 2, 2), SumInt / SumPar));
                    }
                    seriesStatisticalPar2.ChartArea =
                    seriesStatisticalPar.ChartArea = "ChartArea1";
                    seriesStatisticalPar2.ChartType =
                    seriesStatisticalPar.ChartType = SeriesChartType.Column;
                    formGistogram.chartIntegral.Palette =
                    formGistogram.chartGistogram.Palette = ChartColorPalette.BrightPastel;

                    formGistogram.chartGistogram.Series.Add(seriesStatisticalPar);
                    formGistogram.chartIntegral.Series.Add(seriesStatisticalPar2);
                }
                catch (Exception e17)
                {
                    MessageBox.Show(e17.Message);
                }
            }
        }
        /// <summary>
        /// Флажок для настройки гистограммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxGist_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxGist.CheckState == CheckState.Checked)
            {
                checkBoxGist.Text = "Площадь граней";
            }
            else if (checkBoxGist.CheckState == CheckState.Unchecked)
            { 
                checkBoxGist.Text = "Кол-во граней";
            }
        }

        /// <summary>
        /// Защита от дурака (блокирование кнопок последующих действий)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBoxStrategicVisual_TextChanged(object sender, EventArgs e)
        {
            toolStripButtonColorVisual.Enabled = false;
            toolStripButtonSavePLY.Enabled = false;
        }
        /// <summary>
        /// Изменение количества интервалов области значений исследуемого признака для визуализации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownIntVisual_ValueChanged(object sender, EventArgs e)
        {
            if (textBoxRazmahPar.Text.Trim() != "")
            textBoxSizeInt.Text = (float.Parse(textBoxRazmahPar.Text) / (int)numericUpDownIntVisual.Value).ToString("0.00E-00");
        }
        /// <summary>
        /// Сохранение данных из таблицы результатов статистического анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXls_Click(object sender, EventArgs e)
        {

            try
            {
                MSExel.Application ExcelApp = new MSExel.Application();
                MSExel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add();
                MSExel.Sheets Sheets = ExcelWorkBook.Worksheets;
                MSExel.Worksheet ExcelWorkSheet = (MSExel.Worksheet)Sheets.get_Item(1);

                for (int j = 0; j < dataGridViewVariantsVisualization.ColumnCount; j++)
                    ExcelApp.Cells[1, j + 1] = dataGridViewVariantsVisualization.Columns[j].HeaderText;
                //
                for (int i = 0; i < dataGridViewVariantsVisualization.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewVariantsVisualization.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridViewVariantsVisualization.Rows[i].Cells[j].Value;
                    }
                }
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch (Exception err)
            {
                Clipboard.Clear();
                string clipboardTable = "";
                for (int j = 0; j < dataGridViewVariantsVisualization.ColumnCount; j++)
                {
                    clipboardTable += dataGridViewVariantsVisualization.Columns[j].HeaderText;
                    clipboardTable += "\t";
                }
                clipboardTable += "\n";
                //
                for (int i = 0; i < dataGridViewVariantsVisualization.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewVariantsVisualization.ColumnCount; j++)
                    {
                        if (dataGridViewVariantsVisualization.Rows[i].Cells[j].Value.ToString() != null &&
                            dataGridViewVariantsVisualization.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            clipboardTable += dataGridViewVariantsVisualization.Rows[i].Cells[j].Value.ToString();
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
        /// Список гистограмм плотности распределния для анализа
        /// </summary>
        List<object> gistParMassiveOrientationDensity = new List<object>();
        List<float> MassiveHeight = new List<float>();
        /// <summary>
        /// Расчет (статистический анализ) вариантов ориентации изделия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCalculateOrientation_Click(object sender, EventArgs e)
        {
            MyProcedures proc = new MyProcedures();
            float[] resultStatParOrientation = new float[13];
        DateTime StartTime = DateTime.Now;
            ///
            if (ListStl.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа");
                return;
            }
            List<surfaceNormal> ListStlNormal = new List<surfaceNormal>();
            List<vertexXYZ> ListvertexXYZ = new List<vertexXYZ>();
            //
            MassiveHeight.Clear();
            // Площадь модели
            float SumS = 0;
            //Относительная площадь граней по трем исследуемым условиям
            float value1varRelS = 0;
            float value2varRelS = 0;
            float value3varRelS = 0;
            ///
            foreach (var item in ListStl)
            {
                surfaceNormal tempSurfaceNormal = new surfaceNormal();
                vertexXYZ tempvertexXYZ = new vertexXYZ();
                tempvertexXYZ.X = item.X1;
                tempvertexXYZ.Y = item.Y1;
                tempvertexXYZ.Z = item.Z1;
                ListvertexXYZ.Add(tempvertexXYZ);
                tempvertexXYZ.X = item.X2;
                tempvertexXYZ.Y = item.Y2;
                tempvertexXYZ.Z = item.Z2;
                ListvertexXYZ.Add(tempvertexXYZ);
                tempvertexXYZ.X = item.X3;
                tempvertexXYZ.Y = item.Y3;
                tempvertexXYZ.Z = item.Z3;
                ListvertexXYZ.Add(tempvertexXYZ);
                tempSurfaceNormal.XN = item.XN;
                tempSurfaceNormal.YN = item.YN;
                tempSurfaceNormal.ZN = item.ZN;
                SumS += tempSurfaceNormal.Str = (float)item.CalcSTr()[3];
                ListStlNormal.Add(tempSurfaceNormal);

            }
            //Запрос LINQ, группирование по уникальным координатам XYZ
            var uniqueVox = from XYZ in ListvertexXYZ
                            group XYZ by XYZ.X.ToString() + ";" + XYZ.Y.ToString() + ";" + XYZ.Z.ToString();
            //
            try
            {
                frmMain.richTextBoxHistory.Text += "Выполнен статистический анализ вариантов ориентации изделия. \n";
                frmMain.richTextBoxHistory.Text += "Количество вариантов: " + ". \n";
            }
            catch (Exception e8)
            {
                MessageBox.Show(e8.Message);
            }
            int numVariants = (int)((360 * 360) /
                              (float.Parse(toolStripComboBoxDX.Text) * float.Parse(toolStripComboBoxDY.Text)));
            int numVariantsX = (int)(360 / float.Parse(toolStripComboBoxDX.Text));
            int numVariantsY = (int)(360 / float.Parse(toolStripComboBoxDY.Text));
            //
            
            gistParMassiveOrientation.Clear();
            gistParMassiveOrientationDensity.Clear();
            float[] tempMassiveParNormals = new float[ListStlNormal.Count];
            float[] tempMassiveParNormalsZ = new float[uniqueVox.Count()];
            float[] tempMassiveParNormalsS = new float[ListStlNormal.Count];
            for (int i = 0; i < ListStlNormal.Count; i++)
            {
                tempMassiveParNormalsS[i] = ListStlNormal[i].Str / SumS;
            }
            dataGridViewOrientation.Rows.Clear();
            //счетчик
            int m = 0;
            //высота изделия
            float height = 0;
            //
            for (int j = 0; j < numVariantsY; j++)
            {
                for (int i = 0; i < numVariantsX; i++)
                {
                    Stat_analysis statisticaParOrient = new Stat_analysis();
                    Stat_analysis statisticaParOrientAll = new Stat_analysis();
                    proc.ProgressBarRefresh(toolStripProgressBarOrientation, ++m, numVariants);
                    //поворот модели
                    int p = 0;
                    foreach (var item in uniqueVox)
                    {
                        tempMassiveParNormalsZ[p++] = proc.turnXY(item.ToArray()[0].X, item.ToArray()[0].Y, item.ToArray()[0].Z,
                                                   i * float.Parse(toolStripComboBoxDX.Text),
                                                   j * float.Parse(toolStripComboBoxDY.Text))[2];
                    }
                    height = tempMassiveParNormalsZ.Max() - tempMassiveParNormalsZ.Min();
                    MassiveHeight.Add(height);
                    for (int k = 0; k < ListStlNormal.Count; k++)
                    {
                        tempMassiveParNormals[k] = (float)(180*Math.Acos(proc.turnXY(
                                                   ListStlNormal[k].XN, ListStlNormal[k].YN, ListStlNormal[k].ZN,
                                                   i * float.Parse(toolStripComboBoxDX.Text), 
                                                   j * float.Parse(toolStripComboBoxDY.Text))[2])/Math.PI);
                    }
                    //Статистический анализ
                    List<Stat_analysis.elementGist> tempGistPar = statisticaParOrient.Gist(
                                          tempMassiveParNormals, (int)numericUpDownIntOrientation.Value, tempMassiveParNormalsS);
                    List<Stat_analysis.elementGist> tempGistParAll = statisticaParOrientAll.Gist(
                                          tempMassiveParNormals, 180, tempMassiveParNormalsS, 0, 180);
                    gistParMassiveOrientation.Add(tempGistPar);
                    gistParMassiveOrientationDensity.Add(tempGistParAll);
                    //
                    resultStatParOrientation = statisticaParOrient.Stat(tempMassiveParNormals, tempGistPar);
                    //0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
                    // 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
                    //
                    if (dataGridViewIntervals.Rows.Count != 0)
                        //Добавление в dataGridView варианта расчета
                        dataGridViewOrientation.Rows.Add(
                                (dataGridViewOrientation.Rows.Count + 1),
                                height.ToString("### ###.00"),
                                value1varRelS,
                                value2varRelS,
                                value3varRelS,
                                "Просмотр", 
                                numericUpDownIntOrientation.Value,
                                resultStatParOrientation[0].ToString("0.##E-00"),
                                resultStatParOrientation[1].ToString("0.##E-00"),
                                resultStatParOrientation[2].ToString("0.##E-00"),
                                resultStatParOrientation[3].ToString("0.##E-00"),
                                resultStatParOrientation[4].ToString("0.##E-00"),
                                resultStatParOrientation[5].ToString("0.##E-00"),
                                resultStatParOrientation[6].ToString("0.##E-00"),
                                resultStatParOrientation[7].ToString("0.##E-00"),
                                resultStatParOrientation[8].ToString("0.##E-00"),
                                resultStatParOrientation[9].ToString("0.##E-00"),
                                resultStatParOrientation[10].ToString("0.##E-00"),
                                resultStatParOrientation[11].ToString("0.##E-00"),
                                (i * float.Parse(toolStripComboBoxDX.Text)),
                                (j * float.Parse(toolStripComboBoxDY.Text)),
                                "Сохранение..."
                                );
                    //
                    toolStripStatusLabelInphoOrientation.ForeColor = Color.Black;
                    toolStripButtonColorAnalysis.Enabled = true;
                }
            }
            //
            toolStripStatusLabelInphoOrientation.Text = "Анализ выполнен. Время расчета: " +
                                                   (DateTime.Now - StartTime).Hours + " ч. " +
                                                   (DateTime.Now - StartTime).Minutes + " мин. " +
                                                   (DateTime.Now - StartTime).Seconds + " с. " +
                                                   (DateTime.Now - StartTime).Milliseconds + " мс.";
        }

        private void toolStripComboBoxDX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBoxVarCount.Text = ((360*360) / 
                    (float.Parse(toolStripComboBoxDX.Text) * float.Parse(toolStripComboBoxDY.Text))).ToString() + 
                    " вариантов";
            }
            catch (Exception e22)
            {
                MessageBox.Show(e22.Message);
            }
        }

        private void toolStripComboBoxDX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { MessageBox.Show("Введено не число"); }

        }

        private void toolStripComboBoxDY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { MessageBox.Show("Введено не число"); }
        }
        /// <summary>
        /// Просмотр гистограммы распределения площадей граней при определении рациональной ориентации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOrientation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //игнорирование нажатия вне кнопки
            if (e.RowIndex < 0) return;
            //Просмотр гистограммы (при проверке - Range)
            if (e.ColumnIndex == dataGridViewOrientation.Columns["ReviewGistOrient"].Index &&
                dataGridViewOrientation.Rows[e.RowIndex].Cells["RangeOrient"].Value.ToString().TrimEnd() != "0" &&
                dataGridViewOrientation.Rows[e.RowIndex].Cells["RangeOrient"].Value.ToString().TrimEnd().ToLower() != "не число")
            {
                try
                {
                    FormGist formGistogramOrientation = new FormGist();
                    formGistogramOrientation.Activate();
                    formGistogramOrientation.Show();
                    formGistogramOrientation.Text = "Плотность распределения при повороте модели вокруг оси X - " + 
                                         dataGridViewOrientation
                                         [dataGridViewOrientation.Columns["XOrient"].Index, e.RowIndex].Value.ToString() +
                                         " град. и Y - " +
                                         dataGridViewOrientation
                                         [dataGridViewOrientation.Columns["YOrient"].Index, e.RowIndex].Value.ToString() +
                                         " град.";
                    ///
                    //Предварительная очистка данных гистограммы
                    formGistogramOrientation.chartGistogram.Series.Clear();
                    formGistogramOrientation.chartGistogram.Series.Dispose();
                    formGistogramOrientation.chartGistogram.ChartAreas.Clear();
                    formGistogramOrientation.chartGistogram.ChartAreas.Add("ChartArea1");
                    ///
                    //Предварительная очистка данных графика интегральной функции
                    formGistogramOrientation.chartIntegral.Series.Clear();
                    formGistogramOrientation.chartIntegral.Series.Dispose();
                    formGistogramOrientation.chartIntegral.ChartAreas.Clear();
                    formGistogramOrientation.chartIntegral.ChartAreas.Add("ChartArea1");

                    formGistogramOrientation.chartIntegral.ChartAreas[0].AxisX.Minimum =
                    formGistogramOrientation.chartGistogram.ChartAreas[0].AxisX.Minimum = double.Parse(dataGridViewOrientation
                                     [dataGridViewOrientation.Columns["MinIntervalOrient"].Index, e.RowIndex].Value.ToString());
                    formGistogramOrientation.chartIntegral.ChartAreas[0].AxisX.Maximum =
                    formGistogramOrientation.chartGistogram.ChartAreas[0].AxisX.Maximum = double.Parse(dataGridViewOrientation
                         [dataGridViewOrientation.Columns["MaxIntervalOrient"].Index, e.RowIndex].Value.ToString());
                    //Вывод данных на гистограмму распределения
                    Series seriesStatisticalPar = new Series();
                    Series seriesStatisticalPar2 = new Series();
                    List<Stat_analysis.elementGist> gistParTemp = new List<Stat_analysis.elementGist>();
                        gistParTemp = (List<Stat_analysis.elementGist>)gistParMassiveOrientation[e.RowIndex];
                    float SumInt = 0;
                    float SumPar = 0;
                    //Относительные величины
                    for (int i = 0; i < gistParTemp.Count; i++)
                    {
                        SumPar += gistParTemp[i].Y;
                    }
                    //
                    for (int i = 0; i < gistParTemp.Count; i++)
                    {
                        seriesStatisticalPar.Points.Add(
                            new DataPoint(Math.Round((gistParTemp[i].Xmin + gistParTemp[i].Xmax) / 2, 2), gistParTemp[i].Y / SumPar));
                        SumInt += gistParTemp[i].Y;
                        seriesStatisticalPar2.Points.Add(
                            new DataPoint(Math.Round((gistParTemp[i].Xmin + gistParTemp[i].Xmax) / 2, 2), SumInt / SumPar));
                    }
                    seriesStatisticalPar2.ChartArea =
                    seriesStatisticalPar.ChartArea = "ChartArea1";
                    seriesStatisticalPar2.ChartType =
                    seriesStatisticalPar.ChartType = SeriesChartType.Column;
                    formGistogramOrientation.chartIntegral.Palette =
                    formGistogramOrientation.chartGistogram.Palette = ChartColorPalette.BrightPastel;

                    formGistogramOrientation.chartGistogram.Series.Add(seriesStatisticalPar);
                    formGistogramOrientation.chartIntegral.Series.Add(seriesStatisticalPar2);
                }
                catch (Exception e17)
                {
                    MessageBox.Show(e17.Message);
                }
            }
            //
            //Сохранение STL-файла с текущими значениями поворота модели
            if (e.ColumnIndex == dataGridViewOrientation.Columns["Save"].Index)
            {
                if (ListStl.Count == 0) return;
                //Запись файла
                toolStripStatusLabelColorVisual.Text = "Сохранение модели...";
                //
                float turnX = (float)dataGridViewOrientation
                         [dataGridViewOrientation.Columns["XOrient"].Index, e.RowIndex].Value;
                float turnY = (float)dataGridViewOrientation
                         [dataGridViewOrientation.Columns["YOrient"].Index, e.RowIndex].Value;

                saveFileDialog1.FileName = "Model_Or_X" + turnX.ToString() + "Y" + turnY.ToString();
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = ".stl";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sw = new
                            StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                        sw.WriteLine("solid " + DateTime.Now.ToShortDateString() + " " 
                                                      + DateTime.Now.ToShortTimeString());
                    //Начало процедуры
                    DateTime StartTime = DateTime.Now;
                    MyProcedures proc = new MyProcedures();
                    float[] tempN = new float[3];
                    float[] temp1 = new float[3];
                    float[] temp2 = new float[3];
                    float[] temp3 = new float[3];

                    foreach (var tempFace in ListStl)
                    {
                        tempN = proc.turnXY(tempFace.XN, tempFace.YN, tempFace.ZN, turnX, turnY);
                        sw.WriteLine("facet normal " + tempN[0].ToString().Replace(',', '.') + 
                                                 " " + tempN[1].ToString().Replace(',', '.') + 
                                                 " " + tempN[2].ToString().Replace(',', '.'));
                        sw.WriteLine("outer loop");

                        temp1 = proc.turnXY(tempFace.X1, tempFace.Y1, tempFace.Z1, turnX, turnY);
                        sw.WriteLine("vertex " + temp1[0].ToString().Replace(',', '.') + 
                                           " " + temp1[1].ToString().Replace(',', '.') + 
                                           " " + temp1[2].ToString().Replace(',', '.'));

                        temp2 = proc.turnXY(tempFace.X2, tempFace.Y2, tempFace.Z2, turnX, turnY);
                        sw.WriteLine("vertex " + temp2[0].ToString().Replace(',', '.') +
                                           " " + temp2[1].ToString().Replace(',', '.') +
                                           " " + temp2[2].ToString().Replace(',', '.'));

                        temp3 = proc.turnXY(tempFace.X3, tempFace.Y3, tempFace.Z3, turnX, turnY);
                        sw.WriteLine("vertex " + temp3[0].ToString().Replace(',', '.') +
                                           " " + temp3[1].ToString().Replace(',', '.') +
                                           " " + temp3[2].ToString().Replace(',', '.'));
                        sw.WriteLine("endloop");
                        sw.WriteLine("endfacet");
                     }
                        sw.WriteLine("endsolid");
                        sw.Close();
                        var dTime = DateTime.Now - StartTime;
                    //Выделение текущей строки
                    dataGridViewOrientation.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);

                        toolStripStatusLabelInphoOrientation.Text = "Сохранен файл: " +
                                                                    saveFileDialog1.FileName + ", за "
                                                                   + dTime.Seconds + "с "
                                                                   + dTime.Milliseconds + "мс";
                        try
                        {
                            frmMain.richTextBoxHistory.Text += "Сохранена модель (STL-файл): \n";
                            frmMain.richTextBoxHistory.Text += saveFileDialog1.FileName + " \n";
                        }
                        catch (Exception e8)
                        {
                            MessageBox.Show(e8.Message);
                        }
                    }
                
            }
        }
        /// <summary>
        /// Сохранение данных из таблицы результатов анализа ориентации модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonXlsOrient_Click(object sender, EventArgs e)
        {
            try
            {
                MSExel.Application ExcelApp = new MSExel.Application();
                MSExel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Add();
                MSExel.Sheets Sheets = ExcelWorkBook.Worksheets;
                MSExel.Worksheet ExcelWorkSheet = (MSExel.Worksheet)Sheets.get_Item(1);

                for (int j = 0; j < dataGridViewOrientation.ColumnCount; j++)
                    ExcelApp.Cells[1, j + 1] = dataGridViewOrientation.Columns[j].HeaderText;
                //
                for (int i = 0; i < dataGridViewOrientation.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewOrientation.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridViewOrientation.Rows[i].Cells[j].Value;
                    }
                }
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch (Exception err)
            {
                Clipboard.Clear();
                string clipboardTable = "";
                for (int j = 0; j < dataGridViewOrientation.ColumnCount; j++)
                {
                    clipboardTable += dataGridViewOrientation.Columns[j].HeaderText;
                    clipboardTable += "\t";
                }
                clipboardTable += "\n";
                //
                for (int i = 0; i < dataGridViewOrientation.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewOrientation.ColumnCount; j++)
                    {
                        if (dataGridViewOrientation.Rows[i].Cells[j].Value.ToString() != null &&
                            dataGridViewOrientation.Rows[i].Cells[j].Value.ToString() != "")
                        {
                            clipboardTable += dataGridViewOrientation.Rows[i].Cells[j].Value.ToString();
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

        private void numericUpDown1varR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1var.CheckState == CheckState.Checked)
            {
                label1var.BackColor = Color.FromArgb((int)numericUpDown1varR.Value,
                                      (int)numericUpDown1varG.Value, (int)numericUpDown1varB.Value);
                if (numericUpDown1varR.Value < 64 || numericUpDown1varG.Value < 64 || numericUpDown1varB.Value < 64)
                {
                    label1var.ForeColor = Color.White;
                }
                else if (numericUpDown1varR.Value < 128 || numericUpDown1varG.Value < 128 || numericUpDown1varB.Value < 128)
                { label1var.ForeColor = Color.Yellow; }
                else
                { label1var.ForeColor = Color.Black; }
            }
            else
            {
                label1var.BackColor = Color.Transparent;
                label1var.ForeColor = Color.Black;
            }
        }

        private void numericUpDown2varR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox2var.CheckState == CheckState.Checked)
            {
                label2var.BackColor = Color.FromArgb((int)numericUpDown2varR.Value,
                                  (int)numericUpDown2varG.Value, (int)numericUpDown2varB.Value);
                if (numericUpDown2varR.Value < 64 || numericUpDown2varG.Value < 64 || numericUpDown2varB.Value < 64)
                {
                    label2var.ForeColor = Color.White;
                }
                else if (numericUpDown2varR.Value < 128 || numericUpDown2varG.Value < 128 || numericUpDown2varB.Value < 128)
                { label2var.ForeColor = Color.Yellow; }
                else
                { label2var.ForeColor = Color.Black; }
            }
            else
            {
                label2var.BackColor = Color.Transparent;
                label2var.ForeColor = Color.Black;
            }
        }

        private void numericUpDown3varR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox3var.CheckState == CheckState.Checked)
            {
                label3var.BackColor = Color.FromArgb((int)numericUpDown3varR.Value,
                                  (int)numericUpDown3varG.Value, (int)numericUpDown3varB.Value);
                if (numericUpDown3varR.Value < 64 || numericUpDown3varG.Value < 64 || numericUpDown3varB.Value < 64)
                {
                    label3var.ForeColor = Color.White;
                }
                else if (numericUpDown3varR.Value < 128 || numericUpDown3varG.Value < 128 || numericUpDown3varB.Value < 128)
                { label3var.ForeColor = Color.Yellow; }
                else
                { label3var.ForeColor = Color.Black; }
            }
            else
            {
                label3var.BackColor = Color.Transparent;
                label3var.ForeColor = Color.Black;
            }
        }

        private void numericUpDownIntOrientation_ValueChanged(object sender, EventArgs e)
        {
            textBoxIntOrient.Text = (180 / numericUpDownIntOrientation.Value).ToString("###.0");
        }

        private void numericUpDown1varAngleMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1varAngleMin.Value >= numericUpDown1varAngleMax.Value)
            { numericUpDown1varAngleMin.Value = numericUpDown1varAngleMax.Value - 1; }
        }

        private void numericUpDown2varAngleMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2varAngleMin.Value >= numericUpDown2varAngleMax.Value)
            { numericUpDown2varAngleMin.Value = numericUpDown2varAngleMax.Value - 1; }
        }

        private void numericUpDown3varAngleMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3varAngleMin.Value >= numericUpDown3varAngleMax.Value)
            { numericUpDown3varAngleMin.Value = numericUpDown3varAngleMax.Value - 1; }
        }

        private void numericUpDown1varRelSMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1varRelSMin.Value >= numericUpDown1varRelSMax.Value)
            { numericUpDown1varRelSMin.Value = numericUpDown1varRelSMax.Value - 1; }
        }

        private void numericUpDown2varRelSMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2varRelSMin.Value >= numericUpDown2varRelSMax.Value)
            { numericUpDown2varRelSMin.Value = numericUpDown2varRelSMax.Value - 1; }
        }

        private void numericUpDown3varRelSMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3varRelSMin.Value >= numericUpDown3varRelSMax.Value)
            { numericUpDown3varRelSMin.Value = numericUpDown3varRelSMax.Value - 1; }
        }

        private void numericUpDownHMin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownHMin.Value >= numericUpDownHMax.Value)
            { numericUpDownHMin.Value = numericUpDownHMax.Value - 1; }
        }

        private void checkBoxAndOrAddCondition_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxAndOrAddCondition.CheckState == CheckState.Checked)
            {
                checkBoxAndOrAddCondition.Text = "OR";
            }
            else
            {
                checkBoxAndOrAddCondition.Text = "AND";
            }
        }
        /// <summary>
        /// Анализ статистических данных по вариантам ориентации модели изделия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonColorAnalysis_Click(object sender, EventArgs e)
        {
            if (gistParMassiveOrientationDensity.Count == 0 || (checkBox1var.CheckState == CheckState.Unchecked &&
                checkBox2var.CheckState == CheckState.Unchecked && checkBox3var.CheckState == CheckState.Unchecked))
            {
                dataGridViewOrientation.DefaultCellStyle.BackColor = Color.White;
                return;
            }
            float HeightMin = MassiveHeight.Min();
            float HeightMax = MassiveHeight.Max();
            float rangeHeight = HeightMax - HeightMin;
            float areaRel1var = 0, areaRel2var = 0, areaRel3var = 0;
            float Var1AngleMin = (float)numericUpDown1varAngleMin.Value;
            float Var1AngleMax = (float)numericUpDown1varAngleMax.Value;
            float Var2AngleMin = (float)numericUpDown2varAngleMin.Value;
            float Var2AngleMax = (float)numericUpDown2varAngleMax.Value;
            float Var3AngleMin = (float)numericUpDown3varAngleMin.Value;
            float Var3AngleMax = (float)numericUpDown3varAngleMax.Value;
            int num = 0;
            foreach (var item in gistParMassiveOrientationDensity)
            {
                foreach (var subitem in (List<Stat_analysis.elementGist>)item)
                {
                    if (subitem.Xmin >= Var1AngleMin && subitem.Xmax <= Var1AngleMax)
                    {
                        areaRel1var += subitem.Y;
                    }
                    if (subitem.Xmin >= Var2AngleMin && subitem.Xmax <= Var2AngleMax)
                    {
                        areaRel2var += subitem.Y;
                    }
                    if (subitem.Xmin >= Var3AngleMin && subitem.Xmax <= Var3AngleMax)
                    {
                        areaRel3var += subitem.Y;
                    }
                }
                dataGridViewOrientation.Rows[num].Cells["Reaserch1varRelS"].Value = Math.Round(areaRel1var * 100, 1) + " %";
                dataGridViewOrientation.Rows[num].Cells["Reaserch2varRelS"].Value = Math.Round(areaRel2var * 100, 1) + " %";
                dataGridViewOrientation.Rows[num].Cells["Reaserch3varRelS"].Value = Math.Round(areaRel3var * 100, 1) + " %";

                if (checkBox1var.CheckState != CheckState.Unchecked &&
                    (areaRel1var * 100) <= (float)numericUpDown1varRelSMax.Value &&
                   (areaRel1var * 100) >= (float)numericUpDown1varRelSMin.Value)
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch1varRelS"].Style.BackColor =
                  Color.FromArgb((int)numericUpDown1varR.Value, (int)numericUpDown1varG.Value, (int)numericUpDown1varB.Value);
                    if (checkBoxAndOrAddCondition.CheckState != CheckState.Checked &&
                        checkBox1varAddH.CheckState == CheckState.Checked &&
                    MassiveHeight[num] >= HeightMin + rangeHeight * (float)numericUpDownHMin.Value / 100 &&
                    MassiveHeight[num] <= HeightMin + rangeHeight * (float)numericUpDownHMax.Value / 100)
                    {
                        dataGridViewOrientation.Rows[num].Cells["ColumnHeight"].Style.BackColor = Color.LightSkyBlue;
                    }
                }
                else
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch1varRelS"].Style.BackColor = Color.White;
                }

                if (checkBox2var.CheckState != CheckState.Unchecked &&
                    (areaRel2var * 100) <= (float)numericUpDown2varRelSMax.Value &&
                   (areaRel2var * 100) >= (float)numericUpDown2varRelSMin.Value)
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch2varRelS"].Style.BackColor =
                  Color.FromArgb((int)numericUpDown2varR.Value, (int)numericUpDown2varG.Value, (int)numericUpDown2varB.Value);
                    if (checkBoxAndOrAddCondition.CheckState != CheckState.Checked &&
                        checkBox2varAddH.CheckState == CheckState.Checked &&
                    MassiveHeight[num] >= HeightMin + rangeHeight * (float)numericUpDownHMin.Value / 100 &&
                    MassiveHeight[num] <= HeightMin + rangeHeight * (float)numericUpDownHMax.Value / 100)
                    {
                        dataGridViewOrientation.Rows[num].Cells["ColumnHeight"].Style.BackColor =
                   Color.LightSkyBlue;
                    }
                }
                else
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch2varRelS"].Style.BackColor = Color.White;
                }

                if (checkBox3var.CheckState != CheckState.Unchecked &&
                    (areaRel3var * 100) <= (float)numericUpDown3varRelSMax.Value &&
                   (areaRel3var * 100) >= (float)numericUpDown3varRelSMin.Value)
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch3varRelS"].Style.BackColor =
                  Color.FromArgb((int)numericUpDown3varR.Value, (int)numericUpDown3varG.Value, (int)numericUpDown3varB.Value);
                    if (checkBoxAndOrAddCondition.CheckState != CheckState.Checked &&
                        checkBox3varAddH.CheckState == CheckState.Checked &&
                    MassiveHeight[num] >= HeightMin + rangeHeight * (float)numericUpDownHMin.Value / 100 &&
                    MassiveHeight[num] <= HeightMin + rangeHeight * (float)numericUpDownHMax.Value / 100)
                    {
                        dataGridViewOrientation.Rows[num].Cells["ColumnHeight"].Style.BackColor =
                   Color.LightSkyBlue;
                    }
                }
                else
                {
                    dataGridViewOrientation.Rows[num].Cells["Reaserch3varRelS"].Style.BackColor = Color.White;
                }

                if (checkBoxAndOrAddCondition.CheckState == CheckState.Checked &&
                    MassiveHeight[num] >= HeightMin + rangeHeight * (float)numericUpDownHMin.Value / 100 &&
                    MassiveHeight[num] <= HeightMin + rangeHeight * (float)numericUpDownHMax.Value / 100)
                {
                    dataGridViewOrientation.Rows[num].Cells["ColumnHeight"].Style.BackColor =
                Color.LightSkyBlue;
                }
                else
                {
                    dataGridViewOrientation.Rows[num].Cells["ColumnHeight"].Style.BackColor =
                Color.White;
                }
                num++;
                areaRel1var = 0;
                areaRel2var = 0;
                areaRel3var = 0;
            }
        }
        /// <summary>
        /// Анализ триангуляционной модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            //площадь и объем триангуляционной модели
            double Sstl = 0;
            float Vstl = 0;
            //Сумма произведений объема и координат центра тяжести треугольника
            float VXc = 0;
            float VYc = 0;
            float VZc = 0;
            foreach (var tempstl in ListStl)
            {
                Sstl += tempstl.CalcSTr()[3];
                var temp = tempstl.CenterOfGravity();
                VXc += temp[0] * temp[3];
                VYc += temp[1] * temp[3];
                VZc += temp[2] * temp[3];
                Vstl += temp[3];
            }
            richTextBoxResultAnalysis.Text +=  "Анализ выполнен: " + DateTime.Now.ToShortDateString() + "; " + DateTime.Now.ToShortTimeString() + "\n";
            richTextBoxResultAnalysis.Text += "Модель изделия: " + toolStripTextBoxFileName.Text + "\n";
            richTextBoxResultAnalysis.Text += "Площадь триангуляционной модели: " + Sstl.ToString("N3") + " mm2 \n";
            richTextBoxResultAnalysis.Text += "Объем триангуляционной модели: " + Vstl.ToString("N3") + " mm3 \n";
            richTextBoxResultAnalysis.Text += "Координаты центра тяжести триангуляционной модели: \n" + 
                                              "Xc = "+ (VXc / Vstl).ToString("N3") + " mm \n" +
                                              "Yc = " + (VYc / Vstl).ToString("N3") + " mm \n" +
                                              "Zc = " + (VZc / Vstl).ToString("N3") + " mm \n\n";
            
        }
        /// <summary>
        /// Вызов формы для задания зависимости угла наклона грани от исследуемого признака
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonExpression_Click(object sender, EventArgs e)
        {
            string expr = "4*2+2*4*5";
            
            MessageBox.Show(new DataTable().Compute(expr, "").ToString());
        }
        /// <summary>
        /// Параметры установки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLocalSettings_Click(object sender, EventArgs e)
        {
            PackingSettings formPackingSettings = new PackingSettings();
            formPackingSettings.Activate();
            formPackingSettings.Show();
        }
        //Временка 2017/06/25
        PlantParameters PlantSettings = new PlantParameters()
        {
            nameEquipment = "Vanguard Si2 SLS",
            safeDistanceBody = 0.5f,
            safeDistanceBorder = 25f,
            workXmax = 190.5f,
            workXmin = -190.5f,
            workYmax = 165.1f,
            workYmin = -167.64f,
            workZmax = 457.2f,
            workZmin = -2.54f,
            workHeight = 460f,
            workLength = 381f,
            workWidth = 333f
        };

        //
        // Количество размещенных моделей в рабочем пространстве построения
        int numModels = 0;
        /// <summary>
        /// Размещение модели в рабочем пространстве установки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonPack_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxListModels.SelectedIndex == -1)
            { return; }
            base_model currentModel = massiveListModels[toolStripComboBoxListModels.SelectedIndex];
            List<base_vox> currentVoxels = new List<base_vox>();
            float[] sizesPlant = new float[3]
            { PlantSettings.workHeight, PlantSettings.workLength, PlantSettings.workWidth};
            //Условия размещения модели в рабочем пространстве установки

            if (currentModel.sizeX > sizesPlant.Max() ||
                currentModel.sizeY > sizesPlant.Max() ||
                currentModel.sizeZ > sizesPlant.Max())
            {
                MessageBox.Show("Необходимо применить стуктурную обратимую декомпозицию");
                return;
            }
            else if (currentModel.sizeX > PlantSettings.workLength ||
                     currentModel.sizeY > PlantSettings.workWidth ||
                     currentModel.sizeZ > PlantSettings.workHeight)
            {
                MessageBox.Show("Необходимо поменять ориентацию модели \n" +
                                "или применить стуктурную обратимую декомпозицию");
                return;
            }
            MyProcedures procPack = new MyProcedures();
            //Шаг построения
            float step;
            float.TryParse(toolStripTextBoxStep.Text, out step);
            //
            if (numModels == 0)
            {
                toolStripStatusLabelLocation.Text = "Определение расположения модели...";
                toolStripStatusLabelLocation.ForeColor = Color.Black;
                Application.DoEvents();

                currentVoxels = procPack.moveVoxels(currentModel.Voxels,
                     ((PlantSettings.workXmin + PlantSettings.workXmax - currentModel.sizeX) / 2),
                     ((PlantSettings.workYmin + PlantSettings.workYmax - currentModel.sizeY) / 2),
                    0f,
                    currentModel.coordinateX,
                    currentModel.coordinateY,
                    currentModel.coordinateZ,
                    toolStripProgressBarLocation);

                currentModel.transferX = (PlantSettings.workXmin + PlantSettings.workXmax - currentModel.sizeX) / 2
                                       - currentModel.coordinateX;
                currentModel.transferY = (PlantSettings.workYmin + PlantSettings.workYmax - currentModel.sizeY) / 2
                                       - currentModel.coordinateY;
                currentModel.transferZ -= currentModel.coordinateZ;
                numModels++;
            }
            else
            {
                currentVoxels = procPack.moveVoxels(currentModel.Voxels,
                ((PlantSettings.workXmin + PlantSettings.workXmax - currentModel.sizeX) / 2),
                ((PlantSettings.workYmin + PlantSettings.workYmax - currentModel.sizeY) / 2),
                  0f,
                  currentModel.coordinateX,
                  currentModel.coordinateY,
                  currentModel.coordinateZ,
                  toolStripProgressBarLocation);

                currentModel.transferX = (PlantSettings.workXmin + PlantSettings.workXmax - currentModel.sizeX) / 2
                                       - currentModel.coordinateX;
                currentModel.transferY = (PlantSettings.workYmin + PlantSettings.workYmax - currentModel.sizeY) / 2
                                       - currentModel.coordinateY;
                currentModel.transferZ -= currentModel.coordinateZ;
                numModels++;
            }
            
            //Вывод на экран распределения объемов
            Bitmap imageZY, imageZX, imageXY;
            int numX = (int)Math.Ceiling(PlantSettings.workLength / step),
                numY = (int)Math.Ceiling(PlantSettings.workWidth / step),
                numZ = (int)Math.Ceiling(PlantSettings.workHeight / step);

            imageXY = new Bitmap(numY, numX);
            imageZX = new Bitmap(numX, numZ);
            imageZY = new Bitmap(numY, numZ);
            toolStripStatusLabelLocation.Text = "Определение распределения объемов...";
            Application.DoEvents();
            int[,,] dist = procPack.distribution(currentVoxels, numX, numY, numZ,
                                             PlantSettings.workXmin,
                                             PlantSettings.workYmin,
                                             PlantSettings.workZmin,
                                             step, toolStripProgressBarLocation);
            //
            //imageXY
            //максим.кол-во в интервале
            int maxVoxelsInIntervalXY = (int)(Math.Ceiling(step / currentModel.sizeXvoxel) *
                                            Math.Ceiling(step / currentModel.sizeYvoxel) *
                                            Math.Ceiling(numZ * step / currentModel.sizeZvoxel));
            int[] tRGB = new int[3];

            int[] RGB1 = new int[3] { toolStripButtonRGB1.BackColor.R,
                                      toolStripButtonRGB1.BackColor.G,
                                      toolStripButtonRGB1.BackColor.B };

            int[] RGB2 = new int[3] { toolStripButtonRGB2.BackColor.R,
                                      toolStripButtonRGB2.BackColor.G,
                                      toolStripButtonRGB2.BackColor.B };

            toolStripStatusLabelLocation.Text = "Вывод распределения объемов по проекциям...";
            Application.DoEvents();
            for (int x = 0; x < numX; x++)
            {
                procPack.ProgressBarRefresh(toolStripProgressBarLocation, x, numX);
                for (int y= 0; y < numY; y++)
                {
                    int tempZ = 0;
                    for (int z = 0; z < numZ; z++)
                    { tempZ += dist[x, y, z]; }
                    int h = imageXY.Height - 1;
                    tRGB = procPack.colorElementLineGarmonic(tempZ, 0, maxVoxelsInIntervalXY,
                                                    RGB1[0], RGB1[1], RGB1[2],
                                                    RGB2[0], RGB2[1], RGB2[2]);
                    imageXY.SetPixel(y, h - x, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            pictureBoxTop.Image = imageXY;
            //
            //максим.кол-во в интервале
            int maxVoxelsInIntervalXZ = (int)(Math.Ceiling(step / currentModel.sizeXvoxel) *
                                            Math.Ceiling(step / currentModel.sizeZvoxel) *
                                            Math.Ceiling(numY * step / currentModel.sizeYvoxel));
            //
            for (int x = 0; x < numX; x++)
            {
                procPack.ProgressBarRefresh(toolStripProgressBarLocation, x, numX);
                for (int z = 0; z < numZ; z++)
                {
                    int tempY = 0;
                    for (int y = 0; y < numY; y++)
                    { tempY += dist[x, y, z]; }
                    int h = imageZX.Height - 1;
                    tRGB = procPack.colorElementLineGarmonic(tempY, 0, maxVoxelsInIntervalXZ,
                                                    RGB1[0], RGB1[1], RGB1[2],
                                                    RGB2[0], RGB2[1], RGB2[2]);
                    imageZX.SetPixel(x, h - z, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            pictureBoxFront.Image = imageZX;

            //
            //максим.кол-во в интервале
            int maxVoxelsInIntervalZY = (int)(Math.Ceiling(step / currentModel.sizeXvoxel) *
                                            Math.Ceiling(step / currentModel.sizeZvoxel) *
                                            Math.Ceiling(numY * step / currentModel.sizeYvoxel));
            //
            for (int y = 0; y < numY; y++)
            {
                procPack.ProgressBarRefresh(toolStripProgressBarLocation, y, numY);
                for (int z = 0; z < numZ; z++)
                {
                    int tempX = 0;
                    for (int x = 0; x < numX; x++)
                    { tempX += dist[x, y, z]; }
                    int h = imageZY.Height - 1;
                    tRGB = procPack.colorElementLineGarmonic(tempX, 0, maxVoxelsInIntervalZY,
                                                    RGB1[0], RGB1[1], RGB1[2],
                                                    RGB2[0], RGB2[1], RGB2[2]);
                    imageZY.SetPixel(y, h - z, Color.FromArgb(tRGB[0], tRGB[1], tRGB[2]));
                }
            }
            //
            pictureBoxRight.Image = imageZY;
        }
        /// <summary>
        /// Удаление текущей модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxListModels.SelectedIndex != -1)
            {
                massiveListModels.RemoveAt(toolStripComboBoxListModels.SelectedIndex);
                toolStripComboBoxListModels.Items.RemoveAt(toolStripComboBoxListModels.SelectedIndex);
            }
            
        }
        /// <summary>
        /// Задание цвета для неполных элементарных объемов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRGB1_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                toolStripButtonRGB1.BackColor = colorDialogSelect.Color;
            }
        }
        /// <summary>
        /// Задание цвета для полностью заполненных элементарных объемов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRGB2_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                toolStripButtonRGB2.BackColor = colorDialogSelect.Color;
            }
        }
        /// <summary>
        /// Расширение на всю экранную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxFront_DoubleClick(object sender, EventArgs e)
        {
            pictureBoxRight.Visible = !pictureBoxRight.Visible;
            pictureBoxTop.Visible = !pictureBoxTop.Visible;
            if (pictureBoxFront.Dock == DockStyle.None)
            {
                pictureBoxFront.Dock = DockStyle.Fill;
            }
            else
            {
                pictureBoxFront.Dock = DockStyle.None;
            }
            
        }
        /// <summary>
        /// Расширение на всю экранную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            pictureBoxFront.Visible = !pictureBoxFront.Visible;
            pictureBoxTop.Visible = !pictureBoxTop.Visible;
            if (pictureBoxRight.Dock == DockStyle.None)
            {
                pictureBoxRight.Dock = DockStyle.Fill;
            }
            else
            {
                pictureBoxRight.Dock = DockStyle.None;
            }
        }
        /// <summary>
        /// Расширение на всю экранную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxTop_Click(object sender, EventArgs e)
        {
            pictureBoxFront.Visible = !pictureBoxFront.Visible;
            pictureBoxRight.Visible = !pictureBoxRight.Visible;
            if (pictureBoxTop.Dock == DockStyle.None)
            {
                pictureBoxTop.Dock = DockStyle.Fill;
            }
            else
            {
                pictureBoxTop.Dock = DockStyle.None;
            }
        }
        private bool nonNumberEntered = false;
        private void toolStripTextBoxStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true) { e.Handled = true; }
        }

        private void toolStripTextBoxStep_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back) { nonNumberEntered = true; }
                }
            }
            if (e.KeyCode == Keys.Decimal) { nonNumberEntered = false; }

            if (Control.ModifierKeys == Keys.Shift) { nonNumberEntered = true; }
        }
        /// <summary>
        /// Список конутров набора сечений 3D-модели
        /// </summary>
        List<base_curveContourSection> listContour = new List<base_curveContourSection>();

        /// <summary>
        /// Предельные координаты модели
        /// Массив: 0-minZ, 1-maxZ, 2-minX, 3-maxX, 4-minY, 5-maxY
        /// </summary>
        float[] limits = new float[6];

        /// <summary>
        /// Статистические характеристики (результаты анализа по слоям)
        /// </summary>
        public float[] resultStatParLayer = new float[13];
        public float[] resultStatParLayerA = new float[13];
        /// <summary>
        /// Данные гистограммы по анализу слоев
        /// </summary>
        List<Stat_analysis.elementGist> gistParLayer = new List<Stat_analysis.elementGist>();
        List<Stat_analysis.elementGist> gistParLayerA = new List<Stat_analysis.elementGist>();
        List<object> gistParMassiveLayer = new List<object>();
        List<object> gistParMassiveLayerA = new List<object>();
        List<object> ParMassiveLayer = new List<object>();
        List<object> ParMassiveLayerA = new List<object>();
        
        /// <summary>
        /// Формирование слоев послойного построения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLayerCreate_Click(object sender, EventArgs e)
        {
            if (ListStl.Count == 0)
            {
                MessageBox.Show("Нет исходных данных...", "Ошибка!");
                return;
            }
            gistParMassiveLayer.Clear();
            ParMassiveLayer.Clear();
            MyProcedures proc = new MyProcedures();
            //Определение мин. и макс. координат вершин по оси Z
            limits = proc.limitModel(ListStl);

            float minZ = limits[0];
            float maxZ = limits[1];
            float[] tempZ = new float[3];
            float[] coordinateSectionZ;

            //Шаг построения
            float stepConst;
            //Выбрана стратегия с постоянным шагом построения
            if (toolStripComboBoxLayerAnalysis.SelectedIndex == 0 && float.TryParse(toolStripTextBoxMinStep.Text, out stepConst))
            {
                //Массив координат расположения сечений
                coordinateSectionZ = new float[(int)Math.Ceiling((maxZ - minZ) / stepConst)];

                if (dataGridViewSetLayer.RowCount != 0)
                    dataGridViewSetLayer.Rows.Clear();

                //Заполнение таблицы
                string[] strEmpty = new string[30];
                //Массив для анализа смещения центра тяжести
                float[,] SXYCentre = new float[coordinateSectionZ.Length, 3]; 

                for (int i = 0; i < coordinateSectionZ.Length; i++)
                {
                    coordinateSectionZ[i] = (float)Math.Round(minZ + i*stepConst, 3);
                    proc.ProgressBarRefresh(toolStripProgressBarLayerAnalysis, i, coordinateSectionZ.Length);
                    //Добавление в dataGridViewSetLayer
                    dataGridViewSetLayer.Rows.Add(
                                i+1,
                                stepConst,
                                coordinateSectionZ[i],
                                strEmpty
                                );
                }
            }
            else
            {
                MessageBox.Show("Не выбрана стратегия или не задана корректная величина шага построения."
                    , "Ошибка!");
                return;
            }
            listContour.Clear();
            //Периметр
            float Perimeter;
            //Площадь
            float Section;

            //Рассечение 3D-модели плоскостями
            for (int i = 0; i < coordinateSectionZ.Length; i++)
            {
                proc.ProgressBarRefresh(toolStripProgressBarLayerAnalysis, i, coordinateSectionZ.Length);
                Perimeter = 0;
                Section = 0;
                base_curveContourSection tempContour = new base_curveContourSection();
                tempContour.h = stepConst;
                tempContour.Z = coordinateSectionZ.Length;
                List<base_elementOfCurve> tempElementOfCurve = new List<base_elementOfCurve>();
                //Массив данных для стат.анализа
                List<float> tempMassiveParLayer = new List<float>();
                //List<float> tempMassiveParLayerA = new List<float>();
                //
                foreach (var item in ListStl)
                {
                    tempZ[0] = item.Z1;
                    tempZ[1] = item.Z2;
                    tempZ[2] = item.Z3;
                    // 6 ситуаций пересечения треугольной грани участвующей в формировании контура
                    if (tempZ.Min() <= coordinateSectionZ[i] && coordinateSectionZ[i] <= tempZ.Max())
                    {
                        base_elementOfCurve tempElement = new base_elementOfCurve();

                        if (coordinateSectionZ[i] != item.Z1 && coordinateSectionZ[i] == item.Z2 && coordinateSectionZ[i] == item.Z3)
                        {
                            tempElement.point1 = new PointF() { X = item.X2, Y = item.Y2 };
                            tempElement.point2 = new PointF() { X = item.X3, Y = item.Y3 };
                        }
                        else if (coordinateSectionZ[i] == item.Z1 && coordinateSectionZ[i] != item.Z2 && coordinateSectionZ[i] == item.Z3)
                        {
                            tempElement.point1 = new PointF() { X = item.X1, Y = item.Y1 };
                            tempElement.point2 = new PointF() { X = item.X3, Y = item.Y3 };
                        }
                        else if (coordinateSectionZ[i] == item.Z1 && coordinateSectionZ[i] == item.Z2 && coordinateSectionZ[i] != item.Z3)
                        {
                            tempElement.point1 = new PointF() { X = item.X1, Y = item.Y1 };
                            tempElement.point2 = new PointF() { X = item.X2, Y = item.Y2 };
                        }
                        if ((item.Z1 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z2) ||
                                 (item.Z2 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z1))
                        {
                            tempElement.point1 = proc.PlaneCrossLine(item.X1, item.Y1, item.Z1, 
                                                                     item.X2, item.Y2, item.Z2, 
                                                                     coordinateSectionZ[i]);
                        }
                        if ((item.Z2 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z3) ||
                                 (item.Z3 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z2))
                        {
                            if (tempElement.point1 == PointF.Empty)
                            {
                                tempElement.point1 = proc.PlaneCrossLine(item.X2, item.Y2, item.Z2,
                                                                         item.X3, item.Y3, item.Z3,
                                                                         coordinateSectionZ[i]);
                            }
                            else
                            {
                                tempElement.point2 = proc.PlaneCrossLine(item.X2, item.Y2, item.Z2, 
                                                                         item.X3, item.Y3, item.Z3, 
                                                                         coordinateSectionZ[i]);
                            }
                        }
                        if ((item.Z3 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z1) ||
                                 (item.Z1 < coordinateSectionZ[i] && coordinateSectionZ[i] < item.Z3))
                        {
                            if (tempElement.point1 == PointF.Empty)
                            {
                                tempElement.point1 = proc.PlaneCrossLine(item.X3, item.Y3, item.Z3,
                                                                         item.X1, item.Y1, item.Z1,
                                                                         coordinateSectionZ[i]);
                            }
                            else if (tempElement.point2 == PointF.Empty)
                            {
                                tempElement.point2 = proc.PlaneCrossLine(item.X3, item.Y3, item.Z3,
                                                                         item.X1, item.Y1, item.Z1,
                                                                         coordinateSectionZ[i]);
                            }
                        }
                        tempElement.mark = true;
                        tempElementOfCurve.Add(tempElement);
                        Perimeter += proc.length(tempElement.point1, tempElement.point2);
                        Section += proc.squareSection(tempElement.point1, tempElement.point2);

                        tempMassiveParLayer.Add((float)(Math.Acos(item.ZN) / Math.PI * 180));

                    }
                }
                tempContour.listElement = tempElementOfCurve;
                listContour.Add(tempContour);
                //Периметр
                dataGridViewSetLayer[dataGridViewSetLayer.Columns["P"].Index, i].Value = Math.Round(Perimeter,3);
                //Площадь сечения
                dataGridViewSetLayer[dataGridViewSetLayer.Columns["Ssection"].Index, i].Value = Section;
                //Барицентр сечения
                dataGridViewSetLayer[dataGridViewSetLayer.Columns["centroidOfArea"].Index, i].Value = 
                                     proc.barycenterSection(tempElementOfCurve).ToString();
                //Смещение центра тяжести контура от центра тяжести модели
                dataGridViewSetLayer[dataGridViewSetLayer.Columns["Delta"].Index, i].Value = 0f;

                //Данные для стат.анализа
                //ParMassiveLayerA = proc.

                ParMassiveLayer.Add(tempMassiveParLayer);

            }
            toolStripStatusLabelLayerAnalysis.Text = "Данные по сечениям готовы";
            toolStripStatusLabelLayerAnalysis.ForeColor = Color.Black;
        }

        private void toolStripTextBoxMinStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { MessageBox.Show("Введено не число"); }
        }

        private void toolStripTextBoxMaxStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { MessageBox.Show("Введено не число"); }
        }

        private void toolStripTextBoxMinStep_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelLayerAnalysis.Text = "Изменились исходные данные.";
            toolStripStatusLabelLayerAnalysis.ForeColor = Color.Red;
        }
        /// <summary>
        /// Номер текущего сечения
        /// </summary>
        int numSection;

        /// <summary>
        /// Список ребер контура для просмотра
        /// </summary>
        List<base_elementOfCurve> tempElementOfCurveSection = new List<base_elementOfCurve>();

        /// <summary>
        /// Список ребер контура для просмотра
        /// </summary>
        List<List<base_elementOfCurve>> tempElementOfCurveSectionMassive = new List<List<base_elementOfCurve>>();

        /// <summary>
        /// Просмотр сечения секущей плоскости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSetLayer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewSetLayer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            numSection = e.RowIndex;
            tempElementOfCurveSection = listContour[numSection].listElement;

            if(checkBoxOneOrAll.CheckState == CheckState.Checked)
            tempElementOfCurveSectionMassive.Add(listContour[numSection].listElement);

            panelReviewContourSection.Refresh();
        }

        /// <summary>
        /// Просмотр контура текущего сечения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelReviewContourSection_Paint(object sender, PaintEventArgs e)
        {
            //Размеры поля для визуализации
            int Hvis = panelReviewContourSection.Height;
            int Wvis = panelReviewContourSection.Width;
            //Размеры модели
            float Hmodel = limits[5] - limits[4];
            float Wmodel = limits[3] - limits[2];
            //Масштаб
            float Kscale = 1;

            if (dataGridViewSetLayer.RowCount != 0 && float.TryParse(toolStripComboBoxScale.Text, out Kscale))
            {
                Pen myPen = new Pen(colorPen);
                Graphics contourGraphics = panelReviewContourSection.CreateGraphics();
                if (checkBoxOneOrAll.CheckState != CheckState.Checked)
                {
                    foreach (var item in tempElementOfCurveSection)
                    {
                        contourGraphics.DrawLine(myPen,
                                                 Kscale * (item.point1.X - limits[2] - Wmodel / 2) + Wvis / 2, 
                                                 Hvis / 2 - Kscale * (item.point1.Y - limits[4] - Hmodel / 2),
                                                 Kscale * (item.point2.X - limits[2] - Wmodel / 2) + Wvis / 2, 
                                                 Hvis / 2 - Kscale * (item.point2.Y - limits[4] - Hmodel / 2));
                    }
                }
                else 
                {
                    foreach (var item0 in tempElementOfCurveSectionMassive)
                    {
                        foreach (var item in item0)
                        {
                            contourGraphics.DrawLine(myPen,
                                                 Kscale * (item.point1.X - limits[2] - Wmodel / 2) + Wvis / 2,
                                                 Hvis / 2 - Kscale * (item.point1.Y - limits[4] - Hmodel / 2),
                                                 Kscale * (item.point2.X - limits[2] - Wmodel / 2) + Wvis / 2,
                                                 Hvis / 2 - Kscale * (item.point2.Y - limits[4] - Hmodel / 2));
                        }
                    }
                }
                //
                myPen.Dispose();
                contourGraphics.Dispose();
            }
        }
        /// <summary>
        /// Цвет пера для прорисовки контура
        /// </summary>
        Color colorPen = Color.Red;
        private void toolStripButtonColorLine_Click(object sender, EventArgs e)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                colorPen = colorDialogSelect.Color;
            }
            toolStripButtonColorLine.ForeColor = colorPen;
        }
        /// <summary>
        /// Просмотр непрерывный контуров сечений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSetLayer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBoxPreview.CheckState == CheckState.Checked && 
                checkBoxOneOrAll.CheckState != CheckState.Checked)
            {
                dataGridViewSetLayer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                numSection = e.RowIndex;
                tempElementOfCurveSection = listContour[numSection].listElement;
                panelReviewContourSection.Refresh();
            }
        }

        private void checkBoxPreview_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxPreview.CheckState == CheckState.Checked)
            { 
                checkBoxPreview.Text = "Показывать контур";
            }
            else
            {
                checkBoxPreview.Text = "Не показывать контур";
            }
        }

        private void checkBoxOneOrAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxPreview.CheckState == CheckState.Checked)
            {
                checkBoxOneOrAll.Text = "Отображать несколько слоев";
            }
            else
            {
                checkBoxOneOrAll.Text = "Отображать один слой";
            }
            tempElementOfCurveSectionMassive.Clear();
        }

        /// <summary>
        /// Развернуть таблицу с данными по сечениям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            dataGridViewSetLayer.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// Вернуть в исходные размеры таблицу по сечениям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemReduce_Click(object sender, EventArgs e)
        {
            dataGridViewSetLayer.Dock = DockStyle.None;
        }

        /// <summary>
        /// Статистический анализ характеристик контура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLayerAnalysis_Click(object sender, EventArgs e)
        {
            if (ParMassiveLayer.Count != 0)
            {
                for (int i = 0; i < ParMassiveLayer.Count; i++)
                {
                    Stat_analysis statisticaPar = new Stat_analysis();
                    if (((List<float>)ParMassiveLayer[i]).Count == 0)
                    {
                        MessageBox.Show("Массив данных для анализа отсутствует", "Проблема!");
                        return;
                    }
                    //Гистограмма
                    gistParLayer = statisticaPar.Gist(((List<float>)ParMassiveLayer[i]).ToArray(), (int)numericUpDownLayerInt.Value);
                    gistParMassiveLayer.Add(gistParLayer);
                //
                    resultStatParLayer = statisticaPar.Stat(((List<float>)ParMassiveLayer[i]).ToArray(), gistParLayer);
                    //0 - мин., 1 - макс., 2 - интервал, 3 - дисперсия, 4 - ср.кв.откл., 5 - ср.арифм., 
                    // 6 - коэф.асимметрии, 7 - эксцесса, 8 - вариации, 9- меана, 10 - мода (0), 11 - медиана, 12 - объем выборки
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzMinInterval"].Index, i].Value = resultStatParLayer[0];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzMaxInterval"].Index, i].Value = resultStatParLayer[1];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzRange"].Index, i].Value = resultStatParLayer[2];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzDispersion"].Index, i].Value = resultStatParLayer[3];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzSigma"].Index, i].Value = resultStatParLayer[4];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzMean"].Index, i].Value = resultStatParLayer[5];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzKasim"].Index, i].Value = resultStatParLayer[6];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzKeks"].Index, i].Value = resultStatParLayer[7];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzKv"].Index, i].Value = resultStatParLayer[8];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzMeana"].Index, i].Value = resultStatParLayer[9];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzModa"].Index, i].Value = resultStatParLayer[10];
                    dataGridViewSetLayer[dataGridViewSetLayer.Columns["NzMediana"].Index, i].Value = resultStatParLayer[11];

                }
            }
            else
            { return; }

            toolStripStatusLabelLayerAnalysis.Text ="Выполнен анализ стат. характеристик исследуемых признаков";
            toolStripStatusLabelLayerAnalysis.BackColor = Color.Black;
        }

        /// <summary>
        /// Переключатель гистограмм
        /// </summary>
        /// <param name="setChartType">Показывать значения X, Y, Z или XYZ</param> 
        /// <param name="setAbsRel">абсолютные или относительные</param>
        private void SwitchChart(switchChartType setChartType, switchChartAbsRel setAbsRel)
        {
            Chart[] massiveChart = { chartHistogramVoxelX, chartHistogramVoxelY, chartHistogramVoxelZ, chartHistogramVoxelXYZ,
                                     chartHistogramVoxelXRelation, chartHistogramVoxelYRelation, chartHistogramVoxelZRelation,
                                     chartHistogramVoxelXYZRelative};
            foreach (var tempChart in massiveChart)
            {
                tempChart.Visible = false;
            }
            activeChart = massiveChart[(int)setAbsRel * 4 + (int)setChartType];
            activeChart.Visible = true;
        }
 
        /// <summary>
        /// Выбор пункта "2. Просмотр и запись в файл"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox3_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox3.SelectedIndex == 1) // 2. Просмотр и записать в файл
            {
                saveFileDialog1.FileName = "stl_" + DateTime.Now.Year.ToString() + "_" +
                                    DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" +
                                    DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString();
                saveFileDialog1.ShowDialog();
            }
        }
    }
}