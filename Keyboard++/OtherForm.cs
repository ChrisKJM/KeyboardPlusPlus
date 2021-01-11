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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard__
{
    public partial class OtherForm : Form
    {
        public OtherForm(SettingsForms settingsForms)
        {
            InitializeComponent();
            FormClosed += (object sender, FormClosedEventArgs e) => settingsForms.Enabled = true;
            txt_settings.Text = Program.SettingsKey;
            txt_exit.Text = Program.ExitKey;
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

            sw.Write(JsonConvert.SerializeObject(new Dictionary<string, object> { { "Keyboards", Program.Keyboards }, { "SettingsKey", txt_settings.Text }, { "ExitKey", txt_exit.Text } }));
            Program.SettingsKey = txt_settings.Text;
            Program.ExitKey = txt_exit.Text;

            sw.Close();

            MessageBox.Show("Binds saved succesfully!");
            Close();
        }

        private void txt_settings_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            txt_settings.Text = e.KeyCode.ToString();
        }

        private void txt_exit_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            txt_exit.Text = e.KeyCode.ToString();
        }


    }
}
