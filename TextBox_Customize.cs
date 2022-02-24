using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UB._1
{
    public class TextBox_Customize
    {
        public string DefaultText;
        public Color DefaultColor;

        public Button button;
        public bool Lock;

        public TextBox_Customize(TextBox textBox, bool Lock)
        {            
            this.DefaultText = textBox.Text;
            this.DefaultColor = textBox.ForeColor;
            this.Lock = Lock;
        }
    }
}
