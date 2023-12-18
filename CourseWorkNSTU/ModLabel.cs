using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public class ModLabel : Label
    {
        public ModLabel()
        {
            // Указываем, что элемент должен рисовать свой собственный фон
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Очищаем фон элемента
            e.Graphics.Clear(this.BackColor);

            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center; // Выравнивание по центру
                format.LineAlignment = StringAlignment.Center; // Выравнивание по центру
                // Рисуем текст с использованием объекта Graphics
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, format);
            }
        }
    }
}
