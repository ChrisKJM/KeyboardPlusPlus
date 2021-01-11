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
using Newtonsoft.Json.Linq;

namespace Keyboard__
{
    public class Program
    {
        public static List<Keyboard> Keyboards = new List<Keyboard>();
        private static IKeyboardMouseEvents m_GlobalHook;
        public static bool IsSettings = false;
        public static string JsonPath = @".\binds.json";
        public static string SettingsKey = "F6";
        public static string ExitKey = "F7";

        static void Main(string[] args)
        {
            m_GlobalHook = Hook.GlobalEvents();
            
            if (File.Exists(JsonPath))
            {
                JsonSerializer js = JsonSerializer.Create();
                StreamReader sr = new StreamReader(JsonPath);
                Dictionary<string, object> temp = JsonConvert.DeserializeObject<Dictionary<string, object>>(sr.ReadToEnd());
                Keyboards = (List<Keyboard>) ((JArray) temp["Keyboards"]).ToObject(typeof(List<Keyboard>));
                SettingsKey = (string) temp["SettingsKey"];
                ExitKey = (string) temp["ExitKey"];

                sr.Close();
                MessageBox.Show("Binds loaded succesfully!");
            }
            
            m_GlobalHook.KeyDown += OnKeyDown;
            m_GlobalHook.KeyUp += OnKeyUp;

            MessageBox.Show($"Press {SettingsKey} to open settings. | Press {ExitKey} to quit.");

            Application.Run();
        }

        static private void OnKeyDown(object sender, KeyEventArgs e)
        {
            string keyCode = e.KeyCode.ToString();

            foreach (Keyboard kb in Keyboards)
            {
                if (keyCode == kb.ModifierKey && !IsSettings)
                {
                    e.SuppressKeyPress = true;
                    kb.IsDown = true;
                    return;
                }
                else if (kb.KeyMaps.ContainsKey(keyCode) && kb.IsDown && !IsSettings)
                {
                    e.SuppressKeyPress = true;
                    string send = "";
                    kb.KeyMaps.TryGetValue(keyCode, out send);
                    m_GlobalHook.KeyDown -= OnKeyDown;
                    SendKeys.SendWait(send);
                    m_GlobalHook.KeyDown += OnKeyDown;
                    return;
                }
            }
            if (keyCode == SettingsKey && !IsSettings)
            {
                IsSettings = true;
                SettingsForms sf = new SettingsForms();
                sf.Show();
            }
            else if (keyCode == ExitKey)
            {
                Environment.Exit(0);
            }
        }

        static private void OnKeyUp(object sender, KeyEventArgs e)
        {
            string keyCode = e.KeyCode.ToString();

            foreach (Keyboard kb in Keyboards)
            {
                if (keyCode == kb.ModifierKey)
                {
                    e.SuppressKeyPress = true;
                    kb.IsDown = false;
                }
                else if (kb.KeyMaps.ContainsKey(e.KeyCode.ToString()) && kb.IsDown)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
