using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using System.Globalization;

namespace PreAddTech
{
    
    public partial class ATPreparation : Form
    {
        /// <summary>
        /// Основная экранная форма
        /// </summary>
        public ATPreparation()
        {
            InitializeComponent();
        }
        //Список данных для анализа
        public List<VarDatas> varDatasMassive = new List<VarDatas>();
        
        /// <summary>
        /// Процесс для запуска внешних приложений
        /// </summary>
        Process procBase = new Process();

        /// <summary>
        /// Вызов системы "Создание триангуляционных моделей"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFox_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.FoxProPath) && File.Exists(@SettingsUser.Default.Anal_MorPath))
                {
                    procBase.StartInfo.FileName = @SettingsUser.Default.FoxProPath;
                    //procBase.StartInfo.Arguments = @SettingsUser.Default.Base_TriPath;
                    procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файлов: \n" +
                        @SettingsUser.Default.FoxProPath + " \n" + @SettingsUser.Default.Base_TriPath);
                }
            }
            catch (Exception e11)
            {
                MessageBox.Show(e11.Message);
            }
        }

        /// <summary>
        /// Запуск подсистемы создания воксельной модели (декомпозиции)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateVoxModel_Click(object sender, EventArgs e)
        {
            FormAnalysis formCreateVoxModel = new FormAnalysis();
            formCreateVoxModel.Activate();
            formCreateVoxModel.AnalColorVisual.Dispose();
            formCreateVoxModel.AnalLocation.Dispose();
            formCreateVoxModel.AnalLayer.Dispose();
            formCreateVoxModel.analOrient.Dispose();
            formCreateVoxModel.Show();
            if (CultureInfo.CurrentCulture.Name == "en")
            {
                formCreateVoxModel.Text = "Structural reversible decomposition";
            }
            else
            {
                formCreateVoxModel.Text = ((Button)sender).Text;
            }
            activeTask = (int)SwitchActiveTask.analizeDecomposing;
            formCreateVoxModel.activeTask = SwitchActiveTask.analizeDecomposing;
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += "Подсистема анализа декомпозиции изделия" + "\n";
        }

        /// <summary>
        /// Вызов программы просмотра STL файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGLC_Player_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.GLC_PlayerPuth))
                {
                    procBase.StartInfo.FileName = @SettingsUser.Default.GLC_PlayerPuth;
                    procBase.StartInfo.Arguments = @"";
                    procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                        @SettingsUser.Default.FoxProPath);
                }
            }
            catch (Exception e12)
            {
                MessageBox.Show(e12.Message);
            }
        }

        /// <summary>
        /// Открытие блокнота для редактирования файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNotepad_Click(object sender, EventArgs e)
        {
            procBase.StartInfo.FileName = @"Notepad.exe";
            procBase.StartInfo.Arguments = "";
            procBase.Start();
        }

        /// <summary>
        /// Открытие системы "Статистическое моделирование рабочих процессов интегрированных технологий"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStat_Mod_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.FoxProPath) && File.Exists(@SettingsUser.Default.Stat_Mod))
                {
                    procBase.StartInfo.FileName = @SettingsUser.Default.FoxProPath;
                    procBase.StartInfo.Arguments = @SettingsUser.Default.Stat_Mod;
                    procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                        @SettingsUser.Default.FoxProPath +  "\n" + @SettingsUser.Default.Stat_Mod);
                }
            }
            catch (Exception e13)
            {
                MessageBox.Show(e13.Message);
            }
        }

        /// <summary>
        /// Открытие системы "Морфологический анализ триангуляционных моделей"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnalMorfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.FoxProPath) && File.Exists(@SettingsUser.Default.Base_TriPath))
                {
                    procBase.StartInfo.FileName = @SettingsUser.Default.FoxProPath;
                    //procBase.StartInfo.Arguments = @SettingsUser.Default.Anal_MorPath;
                    procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                        @SettingsUser.Default.FoxProPath + "\n" + @SettingsUser.Default.Anal_MorPath);
                }
            }
            catch (Exception e14)
            {
                MessageBox.Show(e14.Message);
            }
        }

        /// <summary>
        /// Открытие системы "Интегрированные генеративные технологии (классификация технологий, характеристики оборудования)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonIGT_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.FoxProPath) && File.Exists(@SettingsUser.Default.RP_TechnPath))
                {
                    procBase.StartInfo.FileName = @SettingsUser.Default.FoxProPath;
                    procBase.StartInfo.Arguments = @SettingsUser.Default.RP_TechnPath;
                    procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файла: \n" +
                        @SettingsUser.Default.FoxProPath + "\n" + @SettingsUser.Default.RP_TechnPath);
                }
            }
            catch (Exception e15)
            {
                MessageBox.Show(e15.Message);
            }
        }

        /// <summary>
        /// Раскрытие на всю форму поля справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RichTextBoxHistory_DoubleClick(object sender, EventArgs e)
        {
            if (richTextBoxHistory.Dock == DockStyle.None)
            {
                panel2.Dock = DockStyle.Fill;
                richTextBoxHistory.Dock = DockStyle.Fill;
                labelHelp.Visible = false;
            }
            else
            {
                panel2.Dock = DockStyle.None;
                richTextBoxHistory.Dock = DockStyle.None;
                labelHelp.Visible = true;
            }
                
        }

        /// <summary>
        /// Просмотр информации о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAboutProgram_Click(object sender, EventArgs e)
        {
            AboutProgram formAboutProgram = new AboutProgram();
            formAboutProgram.Activate();
            formAboutProgram.Show();
        }

        /*
        /// <summary>
        /// Литература (Book)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@SettingsUser.Default.FoxProPath) && File.Exists(@SettingsUser.Default.BookPath))
                {
                procBase.StartInfo.FileName = @SettingsUser.Default.FoxProPath;
                procBase.StartInfo.Arguments = @SettingsUser.Default.BookPath;
                procBase.Start();
                }
                else
                {
                    MessageBox.Show("Проверьте настройки. Нет файлов: \n" +
                        @SettingsUser.Default.FoxProPath +" \n"+ @SettingsUser.Default.BookPath);
                }
            }
            catch (Exception e10)
            {
                MessageBox.Show(e10.Message);
            }
        }
        */
        /// <summary>
        /// Загрузка основной формы системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ATPreparation_Load(object sender, EventArgs e)
        {
            //Загрузка БД вариантов рассчетов
            try
            {
                XmlDocument xDoc = new XmlDocument();
                string fileXml = "VarModels.xml";
                if (File.Exists(fileXml))
                {
                    List<VarModels> varMassive = new List<VarModels>();
                    xDoc.Load(fileXml);
                    //корневой элемент
                    XmlElement xRoot = xDoc.DocumentElement;
                    // обход всех узлов в корневом элементе
                    foreach (XmlNode xnode in xRoot)
                    {
                        VarModels tempVar = new VarModels();
                        // получаем атрибут name
                        if (xnode.Attributes.Count > 0)
                        {
                            XmlNode attr = xnode.Attributes.GetNamedItem("id");
                            if (attr != null)
                                tempVar.Variant = attr.Value;
                        }
                        // обходим все дочерние узлы элемента user
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            // если узел - group
                            if (childnode.Name == "group")
                            {
                                tempVar.Group = childnode.InnerText;
                            }
                            // если узел comment
                            if (childnode.Name == "comment")
                            {
                                tempVar.Comment = childnode.InnerText;
                            }
                            // если узел history
                            if (childnode.Name == "history")
                            {
                                tempVar.History = childnode.InnerText;
                            }
                        }
                        varMassive.Add(tempVar);
                    }

                    foreach (var item in varMassive)
                    {
                        varModelsBindingSource.Add(item);
                    }
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "varModelsDataSet.Variants". При необходимости она может быть перемещена или удалена.
                    //this.variantsTableAdapter.Fill(this.varModelsDataSet.Variants);
                }
            }
            catch (Exception e7)
            {
                MessageBox.Show("Не загрузилась БД! \n" + e7.Message);
                return;
            }
        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Настройки системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingSys formSettingSys = new SettingSys();
            formSettingSys.Activate();
            formSettingSys.Show();
        }
        /// <summary>
        /// Главная форма закрывается (данные обновляются в БД)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ATPreparation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            varModelsBindingSource.EndEdit();
            try
            {
                string fileXml = "VarModels.xml";
                XmlTextWriter textWritter = new XmlTextWriter(fileXml, Encoding.UTF8);
                textWritter.WriteStartDocument();
                //Тело (Variants):
                textWritter.WriteStartElement("Variants");
                textWritter.WriteEndElement();
                textWritter.Close();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fileXml);
                //
                foreach (VarModels item in varModelsBindingSource)
                {
                    XmlNode element = xDoc.CreateElement("Variant");
                    xDoc.DocumentElement.AppendChild(element);
                    XmlAttribute attribute = xDoc.CreateAttribute("id"); // атрибут
                    attribute.Value = item.Variant; // значение атрибута
                    element.Attributes.Append(attribute); // добавляем атрибут
                    //group
                    XmlNode group = xDoc.CreateElement("group"); // имя
                    group.InnerText = item.Group; // значение
                    element.AppendChild(group); // кому принадлежит
                    //comment
                    XmlNode comment = xDoc.CreateElement("comment"); // имя
                    comment.InnerText = item.Comment; // значение
                    element.AppendChild(comment); // кому принадлежит
                    //history
                    XmlNode history = xDoc.CreateElement("history"); // имя
                    history.InnerText = item.History; // значение
                    element.AppendChild(history); // кому принадлежит
                }
                xDoc.Save(fileXml);
            }
            catch (Exception e7)
            {
                MessageBox.Show("Не Записана БД! \n" + e7.Message);
            }

            /*
            this.Validate();
            variantsBindingSource.EndEdit();
            
            VarModelsDataSet.VariantsDataTable deleteVariant =
                (VarModelsDataSet.VariantsDataTable)varModelsDataSet.Variants.GetChanges(DataRowState.Deleted);

            VarModelsDataSet.VariantsDataTable newVariant =
                (VarModelsDataSet.VariantsDataTable)varModelsDataSet.Variants.GetChanges(DataRowState.Added);

            VarModelsDataSet.VariantsDataTable modifiedVariant =
                (VarModelsDataSet.VariantsDataTable)varModelsDataSet.Variants.GetChanges(DataRowState.Modified);

            try
            {

                // Remove all deleted orders from the Orders table.
                if (deleteVariant != null)
                {
                    variantsTableAdapter.Update(deleteVariant);
                }
                // Add new orders to the Orders table.
                if (newVariant != null)
                {
                    variantsTableAdapter.Update(newVariant);
                }
                // Update all modified Orders.
                if (modifiedVariant != null)
                {
                    variantsTableAdapter.Update(modifiedVariant);
                }
                varModelsDataSet.AcceptChanges();
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                if (deleteVariant != null)
                {
                    deleteVariant.Dispose();
                }
                if (newVariant != null)
                {
                    newVariant.Dispose();
                }
                if (modifiedVariant != null)
                {
                    modifiedVariant.Dispose();
                }
            }
            */
        }

        /// <summary>
        /// Активная решаемая задача
        /// </summary>
        public int activeTask;

        /// <summary>
        /// Подсистема "Анализ ориентации модели"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnalisysOrientation_Click(object sender, EventArgs e)
        {
            FormAnalysis formAnalisysOrientationModel = new FormAnalysis();
            formAnalisysOrientationModel.Activate();
            formAnalisysOrientationModel.AnalVox.Dispose();
            formAnalisysOrientationModel.Vox_model.Dispose();
            formAnalisysOrientationModel.AnalLocation.Dispose();
            formAnalisysOrientationModel.AnalLayer.Dispose();
            formAnalisysOrientationModel.Show();
            formAnalisysOrientationModel.Text = ((Button)sender).Text;
            activeTask = (int)SwitchActiveTask.analizeOrientation;
            formAnalisysOrientationModel.activeTask = SwitchActiveTask.analizeOrientation;
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += "Подсистема анализа ориентации модели" + "\n";
        }
        /// <summary>
        /// Подсистема послойного анализа модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnalisysLayer_Click(object sender, EventArgs e)
        {
            FormAnalysis formAnalisysLayerModel = new FormAnalysis();
            formAnalisysLayerModel.Activate();
            formAnalisysLayerModel.AnalVox.Dispose();
            formAnalisysLayerModel.Vox_model.Dispose();
            formAnalisysLayerModel.analOrient.Dispose();
            formAnalisysLayerModel.AnalColorVisual.Dispose();
            formAnalisysLayerModel.AnalLocation.Dispose();
            formAnalisysLayerModel.Show();
            formAnalisysLayerModel.Text = ((Button)sender).Text;
            activeTask = (int)SwitchActiveTask.analizeSlising;
            formAnalisysLayerModel.activeTask = SwitchActiveTask.analizeSlising;
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += "Подсистема послойного анализа модели" + "\n";
        }

        /// <summary>
        /// Подсистема рационального расположения моделей изделий на рабочей платформе установки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnalPacking_Click(object sender, EventArgs e)
        {
            ShowFormAnalPacking();
            activeTask = (int)SwitchActiveTask.analizePacking;
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += "Подсистема рационального расположения моделей изделий на рабочей платформе установки" + "\n";

        }
        /// <summary>
        /// Показать форму подсистемы расположения 3D-моделей изделий в рабочей области построения
        /// </summary>
        void ShowFormAnalPacking()
        {
            FormAnalysis formPacking = new FormAnalysis();
            formPacking.Activate();
            formPacking.ImportSTL.Dispose();
            formPacking.AnalVox.Dispose();
            formPacking.AnalLayer.Dispose();
            formPacking.analOrient.Dispose();
            formPacking.AnalColorVisual.Dispose();
            formPacking.Text = "Подсистема расположения 3D-моделей изделий в рабочей области построения";
            formPacking.Show();
            formPacking.activeTask = SwitchActiveTask.analizePacking;
        }

        /// <summary>
        /// Подсистема визуального анализа технологичности изделия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnalysisManufacturability_Click(object sender, EventArgs e)
        {
            FormAnalysis formAnalysisManufacturability = new FormAnalysis();
            formAnalysisManufacturability.Activate();
            formAnalysisManufacturability.AnalVox.Dispose();
            formAnalysisManufacturability.Vox_model.Dispose();
            formAnalysisManufacturability.analOrient.Dispose();
            formAnalysisManufacturability.AnalLayer.Dispose();
            formAnalysisManufacturability.AnalLocation.Dispose();
            formAnalysisManufacturability.Show();
            formAnalysisManufacturability.Text = ((Button)sender).Text;
            formAnalysisManufacturability.activeTask = SwitchActiveTask.analizeVisual;
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += ((Button)sender).Text + "\n";
        }
        
        /// <summary>
        /// Оценка сложности модели (разнообразие треугольных граней)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEvaluation_Click_1(object sender, EventArgs e)
        {
            FormStatAnal formEvaluation = new FormStatAnal();
            formEvaluation.Activate();
            formEvaluation.Show();
            //Запись данных в историю
            richTextBoxHistory.Text += "Дата: " + DateTime.Now.ToShortDateString() + ";  ";
            richTextBoxHistory.Text += "Время: " + DateTime.Now.ToLongTimeString() + "\n";
            richTextBoxHistory.Text += ((Button)sender).Text + "\n";
        }

        /// <summary>
        /// Справочная система
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.Activate();
            formHelp.Show();
        }

        private void ButtonLanguage_Click(object sender, EventArgs e)
        {
            if (buttonLanguage.Text == "Русский")
            {
            CultureInfo.CurrentCulture = new CultureInfo("ru");
            CultureInfo.CurrentUICulture = new CultureInfo("ru");
            buttonLanguage.Text = "English";
            }
            else if(buttonLanguage.Text == "English")
            {
                CultureInfo.CurrentCulture = new CultureInfo("en");
                CultureInfo.CurrentUICulture = new CultureInfo("en");
                buttonLanguage.Text = "Русский";
            }
        }
    }
}
