using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEasy
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            // Цвет фона для выбранного элемента
            if (e.Item.Selected)
            {
                Rectangle rr = e.Item.ContentRectangle;
                rr.Width *= 10;
                rr.X -= rr.Width/2;
                SolidBrush MBrush = new SolidBrush(Color.FromArgb(180, 190, 160));
                e.Graphics.FillRectangle(MBrush, rr);
            }
            else
            {
                Rectangle rr = e.Item.ContentRectangle;
                rr.Width *= 10;
                rr.X -= rr.Width / 2;
                SolidBrush MBrush = new SolidBrush(Color.FromArgb(119, 183, 36));
                e.Graphics.FillRectangle(MBrush, rr);
            }
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Цвет текста
            e.TextColor = Color.Black; // Задаем цвет текста
                                       // Устанавливаем прозрачный фон
            e.Item.BackColor = Color.Transparent;
            base.OnRenderItemText(e);
        }
    }
}
