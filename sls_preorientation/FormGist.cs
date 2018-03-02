using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreAddTech
{
    /// <summary>
    /// Экранная форма вывода гистограммы 
    /// </summary>
    public partial class FormGist : Form
    {
        public FormGist()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Переключатель "Интегральная функция распределения/Плотность распределения"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            if (buttonSwitch.Text == "Интегральная функция распределения")
            {
                buttonSwitch.Text = "Плотность распределения";
                chartIntegral.Visible = true;
                chartGistogram.Visible = false;
            }
            else
            {
                buttonSwitch.Text = "Интегральная функция распределения";
                chartIntegral.Visible = false;
                chartGistogram.Visible = true;
            }
        }
        
    }
}
