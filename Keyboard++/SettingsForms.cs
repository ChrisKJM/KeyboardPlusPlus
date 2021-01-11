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
using System.IO;
using Newtonsoft.Json;

namespace Keyboard__
{
    public partial class SettingsForms : Form
    {
        int Margin = 12;
        int RimBig, RimSmall;
        List<BindControl> Binds = new List<BindControl>();
        List<Keyboard> TempKeyboards = new List<Keyboard>();

        public SettingsForms()
        {
            RimSmall = (Size.Width - ClientSize.Width) / 2;
            RimBig = Size.Height - ClientSize.Height - RimSmall;

            InitializeComponent();

            TempKeyboards = Program.Keyboards;

            foreach (Keyboard kb in TempKeyboards)
            {
                cmb_keyboard.Items.Add(cmb_keyboard.Items.Count + 1);
            }

            OnKeyboardChange();

            AutoScrollPosition = new Point(0, 0);
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
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(Program.JsonPath);
            }
            catch
            {
                MessageBox.Show("Unable to save binds. Make sure the binds.json file isn't open in any other program.");
                return;
            }

            sw.Write(JsonConvert.SerializeObject(new Dictionary<string, object> { { "Keyboards", TempKeyboards }, { "SettingsKey", Program.SettingsKey }, { "ExitKey", Program.ExitKey } }));
            Program.Keyboards = TempKeyboards;
            sw.Close();
            
            MessageBox.Show("Binds saved succesfully!");
            Close();
        }

        private void btn_addKeyboard_Click(object sender, EventArgs e)
        {
            AddKeyboard();
        }

        private void btn_deleteKeyboard_Click(object sender, EventArgs e)
        {
            DeleteKeyboard();
        }

        private void SettingsForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.IsSettings = false;
        }

        private void cmb_keyboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnKeyboardChange();
        }

        private void btn_other_Click(object sender, EventArgs e)
        {
            OtherForm otherForm = new OtherForm(this);
            Enabled = false;
            otherForm.Show();
        }

        private BindControl AddBindControl()
        {
            AutoScrollPosition = new Point(0, 0);
            BindControl bindControl = new BindControl();
            bindControl.Location = new Point(Margin, Binds.Count * (bindControl.Height + Margin) + 4 * Margin + modifierBindControl1.Height + cmb_keyboard.Height + 26);
            Binds.Add(bindControl);
            Controls.Add(bindControl);
            UpdateBinds();
            return bindControl;
        }

        private BindControl DeleteBindControl()
        {
            if (Binds.Count > 0)
            {
                BindControl bindControl = Binds.Last();
                Binds.Remove(bindControl);
                Controls.Remove(bindControl);
                bindControl.Dispose();
                UpdateBinds();
                return bindControl;
            }
            return null;
        }

        private void AddKeyboard()
        {
            cmb_keyboard.Items.Add(cmb_keyboard.Items.Count + 1);
            TempKeyboards.Add(new Keyboard(new Dictionary<string, string>(), ""));
        }
        
        private void DeleteKeyboard()
        {
            if (cmb_keyboard.Items.Count > 1)
            {
                cmb_keyboard.Items.RemoveAt(cmb_keyboard.Items.Count - 1);
                TempKeyboards.RemoveAt(TempKeyboards.Count - 1);
            }
        }

        public void UpdateBinds()
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            for (int i = 0; i < Binds.Count; i++)
            {
                if (Binds[i].txt_inputKey.Text != "")
                    temp.Add(Binds[i].txt_inputKey.Text, Binds[i].txt_outputString.Text);
            }
            TempKeyboards[int.Parse(cmb_keyboard.Text) - 1].KeyMaps = temp;
        }

        public void UpdateModifier()
        {
            TempKeyboards[int.Parse(cmb_keyboard.Text) - 1].ModifierKey = modifierBindControl1.txt_modifierKey.Text;
        }

        private void OnKeyboardChange()
        {
            foreach (BindControl bc in Binds)
            {
                bc.Dispose();
            }
            Binds.Clear();
            Keyboard kb = TempKeyboards[int.Parse(cmb_keyboard.Text) - 1];
            modifierBindControl1.txt_modifierKey.Text = kb.ModifierKey;
            foreach (var elem in kb.KeyMaps)
            {
                BindControl bc = AddBindControl();
                bc.txt_inputKey.Text = elem.Key;
                bc.txt_outputString.Text = elem.Value;
            }
        }
    }
}
