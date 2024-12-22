using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEasy
{
    public class ToggleButton : Button
    {
        public bool isPressed = false;

        public ToggleButton()
        {
            this.FlatAppearance.BorderSize = 1;
            //this.FlatStyle = FlatStyle.Flat;
            //this.FlatAppearance.MouseDownBackColor = Color.FromArgb(84, 130, 26);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(84, 130, 26);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ToggleState();
        }

        private void ToggleState()
        {
        }

        public void UpdateButtonAppearance()
        {
            if (isPressed)
            {
                
                this.BackColor = Color.FromArgb(84, 130, 26);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(126, 150, 96);
                this.ForeColor = Color.White;
            }
        }
    }
}
