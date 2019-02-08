using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PreAddTech
{
    /// <summary>
    /// Экранная форма настроек размещения изделий на рабочей платформе
    /// </summary>
    public partial class PackingSettings : Form
    {
        public PackingSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Основная форма приложения
        /// </summary>
        ATPreparation frmMain = (ATPreparation)Application.OpenForms["ATPreparation"];

        /// <summary>
        /// Форма подсистемы
        /// </summary>
        FormAnalysis frmAnalysis = (FormAnalysis)Application.OpenForms["FormAnalysis"];

        /// <summary>
        /// Процедуры рассчета/анализа параметров
        /// </summary>
        MyProcedures proc = new MyProcedures();
        PackProcedures procPacking = new PackProcedures();

        /// <summary>
        /// Проверка на непересечение 3D-моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonVerify_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            float.TryParse(frmAnalysis.toolStripTextBoxStep.Text, out float step);
            labelAct.Text = "Проверка выполняется.";
            labelAct.ForeColor = Color.Red;
            string message = (string)procPacking.VerifyModelsForPlace( frmAnalysis.massiveListModels,
                             frmAnalysis.PlantSettings, step, frmAnalysis.toolStripProgressBarLocation)[0];
            if (message.Trim().Length != 0)
            {
                MessageBox.Show(message, "Результаты проверки!");
                frmAnalysis.richTextBoxLocationInfo.Text += "Выполнена проверка корректности размещения 3D-моделей. \n" 
                                                          + message + "\n";
            }
            else
            {
                frmAnalysis.richTextBoxLocationInfo.Text += "Проверка прошла успешно.\n" +
                    "3D-модели имеют корректное размещение.\n";
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            labelAct.Text = "Проверка выполнена. Время расчета: " +
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }

        /// <summary>
        /// Применение перемещения/вращения и рассечения текущей 3D-модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            frmAnalysis.unionListStl.Clear();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int indexModel = frmAnalysis.toolStripComboBoxListModels.SelectedIndex;

            if (indexModel != -1)
            {
                /// Перемещение модели
                frmAnalysis.massiveListModels[indexModel].Voxels =
                                proc.MoveVoxels(frmAnalysis.massiveListModels[indexModel].Voxels,
                                (float)numericUpDownDeltaX.Value,
                                (float)numericUpDownDeltaY.Value,
                                (float)numericUpDownDeltaZ.Value);
                frmAnalysis.massiveListModels[indexModel].TransferX += (float)numericUpDownDeltaX.Value;
                frmAnalysis.massiveListModels[indexModel].TransferY += (float)numericUpDownDeltaY.Value;
                frmAnalysis.massiveListModels[indexModel].TransferZ += (float)numericUpDownDeltaZ.Value;
                ShowModels(); // Вывод на экран
                numericUpDownDeltaX.Value =
                numericUpDownDeltaY.Value =
                numericUpDownDeltaZ.Value = 0;
                /// Поворот модели
                frmAnalysis.massiveListModels[indexModel].Voxels =
                                proc.RotationVoxels(frmAnalysis.massiveListModels[indexModel].Voxels,
                                (float)numericUpDownAroundX.Value,
                                (float)numericUpDownAroundY.Value,
                                (float)numericUpDownAroundZ.Value);
                frmAnalysis.massiveListModels[indexModel].RotationX += (float)numericUpDownAroundX.Value;
                frmAnalysis.massiveListModels[indexModel].RotationY += (float)numericUpDownAroundY.Value;
                frmAnalysis.massiveListModels[indexModel].RotationZ += (float)numericUpDownAroundZ.Value;
                ShowModels(); // Вывод на экран
                numericUpDownAroundX.Value =
                numericUpDownAroundY.Value =
                numericUpDownAroundZ.Value = 0;
                /// Декомпозиция модели
                if (checkBoxDecomposition.CheckState == CheckState.Checked &&
                    procPacking.VerifyDecompozition(frmAnalysis.massiveListModels[indexModel], 
                    (float)numericUpDownDivisionX.Value, (float)numericUpDownDivisionY.Value, (float)numericUpDownDivisionZ.Value,
                    checkBoxRelativeOrAbsX.CheckState, checkBoxRelativeOrAbsY.CheckState, checkBoxRelativeOrAbsZ.CheckState))
                {
                    List<Base_model> tempList = procPacking.Decomposition(frmAnalysis.massiveListModels[indexModel],
                                                (float)numericUpDownDivisionX.Value, (float)numericUpDownDivisionY.Value,
                                                (float)numericUpDownDivisionZ.Value, checkBoxRelativeOrAbsX.CheckState,
                                                checkBoxRelativeOrAbsY.CheckState, checkBoxRelativeOrAbsZ.CheckState);
                    if (tempList.Count() != 0)
                    {
                        string nameModel = frmAnalysis.toolStripComboBoxListModels.Items[indexModel].ToString();
                        if (checkBoxDeleteBaseModel.CheckState == CheckState.Checked)
                        {
                            frmAnalysis.massiveListModels.RemoveAt(indexModel);
                            frmAnalysis.toolStripComboBoxListModels.Items.RemoveAt(indexModel);
                        }
                        frmAnalysis.massiveListModels.AddRange(tempList);
                        for (int i = 0; i < tempList.Count(); i++)
                        {
                            frmAnalysis.toolStripComboBoxListModels.Items.Add(nameModel + String.Format(" часть ({0})", i + 1));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите 3D-модель в подсистеме.", "Расчет не выполнен!");
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            labelAct.Text = "Действие выполнено. Время расчета: " +
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            labelAct.ForeColor = Color.Black;
            buttonOK.Enabled = false;
        }
        /// <summary>
        /// Изменение (задание) настроек перемещения, поворота и декомпозиции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownDeltaX_ValueChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        /// <summary>
        /// Автоматическое размещение модели в центре рабочей платформы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOnDefault_Click(object sender, EventArgs e)
        {
            frmAnalysis.unionListStl.Clear();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            procPacking.AutoPlaced(frmAnalysis.massiveListModels, frmAnalysis.PlantSettings, frmAnalysis.toolStripProgressBarLocation);
            ShowModels(); // Вывод на экран
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            labelAct.Text = "Действие выполнено. Время расчета: " + 
                String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            labelAct.ForeColor = Color.Black;
            buttonOnDefault.Enabled = false;
        }

        /// <summary>
        /// Вывод на экран распределения объемов imageZY, imageZX, imageXY
        /// </summary>
        private void ShowModels()
        {
            float.TryParse(frmAnalysis.toolStripTextBoxStep.Text, out float step);
            Bitmap[] image = procPacking.ShowWorkPlace(frmAnalysis.massiveListModels, frmAnalysis.PlantSettings, 
                                                       step, frmAnalysis.toolStripProgressBarLocation,
                                                       frmAnalysis.toolStripButtonRGB2.BackColor, 
                                                       frmAnalysis.toolStripButtonRGB1.BackColor);
            if (image != null)
            {
                frmAnalysis.pictureBoxTop.Image = image[0]; //imageXY;
                frmAnalysis.pictureBoxFront.Image = image[1]; //imageZX;
                frmAnalysis.pictureBoxRight.Image = image[2]; //imageZY;
                frmAnalysis.toolStripStatusLabelLocation.Text = "Визуализация распределения объемов по проекциям.";
                frmAnalysis.toolStripStatusLabelLocation.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Переход к следующей модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNextModel_Click(object sender, EventArgs e)
        {
            if (frmAnalysis.toolStripComboBoxListModels.SelectedIndex < 
                frmAnalysis.toolStripComboBoxListModels.Items.Count - 1)
            {
                frmAnalysis.toolStripComboBoxListModels.SelectedIndex++;
            }
            else
            {
                buttonNext.Enabled = false;
            }
            
        }
        
        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PackingSettings_Load(object sender, EventArgs e)
        {
            decimal.TryParse(frmAnalysis.toolStripTextBoxStep.Text, out decimal step);
            numericUpDownDeltaX.Increment =
            numericUpDownDeltaY.Increment =
            numericUpDownDeltaZ.Increment = step;
        }
        
        /// <summary>
        /// Выполнять/не выполнять декомпозицию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxDecomposition.CheckState == CheckState.Checked)
            {
                checkBoxDecomposition.Text = "Выполнить декомпозицию";
                numericUpDownDeltaX.Value = 0;
                numericUpDownDeltaY.Value = 0;
                numericUpDownDeltaZ.Value = 0;
                numericUpDownAroundX.Value = 0;
                numericUpDownAroundY.Value = 0;
                numericUpDownAroundZ.Value = 0;
                numericUpDownDeltaX.ReadOnly = true;
                numericUpDownDeltaY.ReadOnly = true;
                numericUpDownDeltaZ.ReadOnly = true;
                numericUpDownAroundX.ReadOnly = true;
                numericUpDownAroundY.ReadOnly = true;
                numericUpDownAroundZ.ReadOnly = true;
                buttonOK.Enabled = true;
            }
            else
            {
                checkBoxDecomposition.Text = "Не выполнять декомпозицию";
                numericUpDownDeltaX.ReadOnly = false;
                numericUpDownDeltaY.ReadOnly = false;
                numericUpDownDeltaZ.ReadOnly = false;
                numericUpDownAroundX.ReadOnly = false;
                numericUpDownAroundY.ReadOnly = false;
                numericUpDownAroundZ.ReadOnly = false;
                buttonOK.Enabled = false;
            }
            numericUpDownDivisionX.Enabled = !numericUpDownDivisionX.Enabled;
            numericUpDownDivisionY.Enabled = !numericUpDownDivisionY.Enabled;
            numericUpDownDivisionZ.Enabled = !numericUpDownDivisionZ.Enabled;
            checkBoxDeleteBaseModel.Enabled = !checkBoxDeleteBaseModel.Enabled;
            checkBoxRelativeOrAbsX.Enabled = !checkBoxRelativeOrAbsX.Enabled;
            checkBoxRelativeOrAbsY.Enabled = !checkBoxRelativeOrAbsY.Enabled;
            checkBoxRelativeOrAbsZ.Enabled = !checkBoxRelativeOrAbsZ.Enabled;
        }
        
        /// <summary>
        /// Задавать координаты для плоскости разделения модели относительно ее габаритных размеров
        /// или абсолютных координат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxRelativeOrAbsX_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).CheckState == CheckState.Checked)
            {
                ((CheckBox)sender).Text = "Абсол.";
            }
            else
            {
                ((CheckBox)sender).Text = "Относит.";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxDeleteBaseModel_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).CheckState == CheckState.Checked)
            {
                ((CheckBox)sender).Text = "Удалить";
            }
            else
            {
                ((CheckBox)sender).Text = "Не удалять";
            }
        }

        /// <summary>
        /// Изменение настроек анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownNumX_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.NumXSubSpace = (int)numericUpDownNumX.Value;
        }

        /// <summary>
        /// Изменение настроек анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownNumY_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.NumYSubSpace = (int)numericUpDownNumY.Value;
        }

        /// <summary>
        /// Изменение настроек анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownNumZ_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.NumZSubSpace = (int)numericUpDownNumZ.Value;
        }

        private void NumericUpDownEmptySubSpace_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.LimitEmptySubSpace = (float)numericUpDownEmptySubSpace.Value;
        }

        private void NumericUpDownFullSubSpace_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.LimitFullSubSpace = (float)numericUpDownFullSubSpace.Value;
        }

        private void NumericUpDownStepMin_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.StepMin = (float)numericUpDownStepMin.Value;
        }

        private void NumericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.StepMax = (float)numericUpDownStepMax.Value;
        }
        /// <summary>
        /// Изменение величины предельно допустимой погрешности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownError_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.ErrorMax = (float)numericUpDownError.Value;
        }
        /// <summary>
        /// Изменение величины усечения плотности распределения углов нормалей поверхностей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownTruncated_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingAnalisysSettings.ValueTruncatedDistribution = (float)numericUpDownTruncated.Value;
        }
        /// <summary>
        /// Изменение вариантов анализа послойного рассечения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxConstantStep_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxConstantStep.CheckState == CheckState.Unchecked)
            {
                frmAnalysis.PackingAnalisysSettings.Layering[0] = TypeLayering.no;
            }
            else
            {
                frmAnalysis.PackingAnalisysSettings.Layering[0] = TypeLayering.constant;
            }
        }

        private void CheckBoxVariableStep_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxVariableStep.CheckState == CheckState.Unchecked)
            {
                frmAnalysis.PackingAnalisysSettings.Layering[1] = TypeLayering.no;
            }
            else
            {
                frmAnalysis.PackingAnalisysSettings.Layering[1] = TypeLayering.simpleVariable;
            }
        }

        private void CheckBoxNoTruncated_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxNoTruncated.CheckState == CheckState.Unchecked)
            {
                frmAnalysis.PackingAnalisysSettings.Layering[2] = TypeLayering.no;
            }
            else
            {
                frmAnalysis.PackingAnalisysSettings.Layering[2] = TypeLayering.variableNoTrim;
            }
        }

        private void CheckBoxTruncated_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxTruncated.CheckState == CheckState.Unchecked)
            {
                frmAnalysis.PackingAnalisysSettings.Layering[3] = TypeLayering.no;
            }
            else
            {
                frmAnalysis.PackingAnalisysSettings.Layering[3] = TypeLayering.variableTrim;
            }
        }

        /// <summary>
        /// Изменение CrossoverRate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownCrossoverRate_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.CrossoverRate = (double)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// Изменение количества вариантов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownVariants_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.NumVariants = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// Изменение количества поиска свободного пространства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownSearchFree_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.NumTimesFreeSpace = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// GenerationSize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownGenerationSize_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.GenerationSize = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// GenomeSize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownGenomeSize_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.GenomeSize = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// PopulationSize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownPopulationSize_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.PopulationSize = (int)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// MutationRate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownMutationRate_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.MutationRate = (double)((NumericUpDown)sender).Value;
        }
        /// <summary>
        /// Коэффициент Magnitude - усиление критерия оптимизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDownMagnitude_ValueChanged(object sender, EventArgs e)
        {
            frmAnalysis.PackingSettings.Magnitude = (float)((NumericUpDown)sender).Value;
        }
    }
}
