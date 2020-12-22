/*
MIT License

Copyright (c) 2020 Krzysztof Jan Matusiak

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard__
{
    public partial class SettingsForms : Form
    {
        int margin = 12;
        int rimBig, rimSmall;
        List<BindControl> binds = new List<BindControl>();

        public SettingsForms()
        {
            rimSmall = (Size.Width - ClientSize.Width) / 2;
            rimBig = Size.Height - ClientSize.Height - rimSmall;

            InitializeComponent();

            modifierBindControl1.txt_modifierKey.Text = Program.modifierKey;

            foreach (var elem in Program.keyMaps)
            {
                BindControl bc = AddBindControl();
                bc.txt_inputKey.Text = elem.Key;
                bc.txt_outputString.Text = elem.Value;
            }
            //UpdateButtonLocation();
        }

        private void UpdateButtonLocation()
        {
            BindControl last = binds.Last();
            btn_add.Location = new Point(btn_add.Location.X, last.Location.Y + last.Size.Height + margin);
            btn_delete.Location = new Point(btn_delete.Location.X, last.Location.Y + last.Size.Height + margin);
            btn_save.Location = new Point(btn_save.Location.X, last.Location.Y + last.Size.Height + margin);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddBindControl();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteBindControl();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (BindControl bc in binds)
            {
                if (bc.txt_inputKey.Text != "")
                    temp.Add(bc.txt_inputKey.Text, bc.txt_outputString.Text);
            }
            Program.keyMaps = temp;
            Close();
        }

        private void SettingsForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.isF6 = false;
        }

        private BindControl AddBindControl()
        {
            Point temp = new Point(Math.Abs(AutoScrollPosition.X), Math.Abs(AutoScrollPosition.Y) + 26 + margin);
            AutoScrollPosition = new Point(0, 0);
            BindControl bindControl = new BindControl();
            bindControl.Location = new Point(margin, (binds.Count + 1) * (26 + margin) + margin);
            binds.Add(bindControl);
            Controls.Add(bindControl);
            UpdateButtonLocation();
            AutoScrollPosition = temp;
            return bindControl;
        }

        private BindControl DeleteBindControl()
        {
            if (binds.Count > 0)
            {
                BindControl bindControl = binds.Last();
                binds.Remove(bindControl);
                Controls.Remove(bindControl);
                bindControl.Dispose();
                UpdateButtonLocation();
                return bindControl;
            }
            return null;
        }
    }
}
