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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Gma.System.MouseKeyHook;
using System.IO;
using Newtonsoft.Json;

namespace Keyboard__
{
    public class Program
    {
        public static Dictionary<string, string> keyMaps;
        public static string modifierKey = "Apps";
        static private IKeyboardMouseEvents m_GlobalHook;
        static bool isDown = false;
        public static bool isF6 = false;
        public static string jsonPath = @".\binds.json";

        static void Main(string[] args)
        {
            //dodać możliwość zmieniania oraz zapisywania
            m_GlobalHook = Hook.GlobalEvents();
            JsonSerializer js = JsonSerializer.Create();
            StreamReader sr = new StreamReader(jsonPath);
            keyMaps = (Dictionary<string, string>) js.Deserialize(sr, typeof(Dictionary<string, string>));
            sr.Close();
            m_GlobalHook.KeyDown += OnKeyDown;
            m_GlobalHook.KeyUp += OnKeyUp;
            Application.Run();
        }

        static private void OnKeyDown(object sender, KeyEventArgs e)
        {
            string keyCode = e.KeyCode.ToString();
            if (keyCode == modifierKey && !isDown)
            {
                isDown = true;
                e.SuppressKeyPress = true;
            }
            else if (keyMaps.ContainsKey(keyCode) && isDown)
            {
                e.SuppressKeyPress = true;
                string send = "";
                keyMaps.TryGetValue(keyCode, out send);
                m_GlobalHook.KeyDown -= OnKeyDown;
                SendKeys.SendWait(send);
                m_GlobalHook.KeyDown += OnKeyDown;
            }
            else if (keyCode == "F6" && !isF6)
            {
                isF6 = true;
                SettingsForms sf = new SettingsForms();
                sf.Show();
            }
            else if (keyCode == "F7")
            {
                Environment.Exit(0);
            }
        }

        static private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Apps")
            {
                e.SuppressKeyPress = true;
                isDown = false;
            }
            else if (keyMaps.ContainsKey(e.KeyCode.ToString()))
            {
                e.SuppressKeyPress = true;
            }
            //MessageBox.Show(e.KeyCode.ToString());
        }
    }
}
