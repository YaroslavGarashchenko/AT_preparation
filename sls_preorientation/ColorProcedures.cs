using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace PreAddTech
{
    /// <summary>
    /// Класс процедур работы с цветом
    /// </summary>
    public class ColorProcedures
    {
        /// <summary>
        /// Изменение цвета объекта Label
        /// </summary>
        /// <param name="objLabel"></param>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <param name="check"></param>
        public void ChangeColorLabel(object objLabel, int R, int G, int B, bool check = true)
        {
            if (check)
            {
                ((Label)objLabel).BackColor = Color.FromArgb(R, G, B);
                if (R < 64 || G < 64 || B < 64)
                {
                    ((Label)objLabel).ForeColor = Color.White;
                }
                else if (R < 128 || G < 128 || B < 128)
                { ((Label)objLabel).ForeColor = Color.Yellow; }
                else
                { ((Label)objLabel).ForeColor = Color.Black; }
            }
            else
            {
                ((Label)objLabel).BackColor = Color.Transparent;
                ((Label)objLabel).ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Задание цвета в форме выбора цвета по двойному щелчку на объекте Label
        /// </summary>
        /// <param name="objLabel"></param>
        /// <param name="colorDialogSelect"></param>
        /// <param name="R1"></param>
        /// <param name="G1"></param>
        /// <param name="B1"></param>
        public void DoubleClickColorLabel(object objLabel, ColorDialog colorDialogSelect, object R1,
                                          object G1, object B1)
        {
            if (colorDialogSelect.ShowDialog() == DialogResult.OK)
            {
                ((Label)objLabel).BackColor = colorDialogSelect.Color;
                ((NumericUpDown)R1).Value = colorDialogSelect.Color.R;
                ((NumericUpDown)G1).Value = colorDialogSelect.Color.G;
                ((NumericUpDown)B1).Value = colorDialogSelect.Color.B;
            }
            if (colorDialogSelect.Color.R < 40 || colorDialogSelect.Color.G < 40 || colorDialogSelect.Color.B < 40)
            {
                ((Label)objLabel).ForeColor = Color.White;
            }
            else if (colorDialogSelect.Color.R < 128 || colorDialogSelect.Color.G < 128 || colorDialogSelect.Color.B < 128)
            { ((Label)objLabel).ForeColor = Color.Yellow; }
            else
            { ((Label)objLabel).ForeColor = Color.Black; }
        }
    }
}
