using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard__
{
    public partial class ModifierBindControl : UserControl
    {
        public ModifierBindControl()
        {
            InitializeComponent();
        }

        private void txt_modifierKey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            txt_modifierKey.Text = e.KeyCode.ToString();
        }
    }
}
