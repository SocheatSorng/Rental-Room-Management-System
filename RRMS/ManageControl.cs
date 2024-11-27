using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRMS
{
    public class ManageControl
    {
        public static void EnableControl(Control control, bool state)
        {
            if(control is Button button)
            {
                button.Enabled = state;
                button.BackColor = state ? Color.FromArgb(255, 255, 128) : Color.Gray;
            }
            else if (control is TextBox textBox)
            {
                textBox.Enabled = state;
                textBox.BackColor = state ? Color.White : Color.LightGray;
            }
        }
    }
}
