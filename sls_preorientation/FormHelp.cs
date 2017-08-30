﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreAddTech
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }
        string mainHelp = Application.StartupPath + @"\help\index.html";
        private void FormHelp_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowserHelp.Navigate(new Uri(mainHelp));
            }
            catch (System.UriFormatException)
            {
                
                return;
            }
        }
    }
}
