using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Keyboard__
{
    class Program
    {
        static Dictionary<string, string> keyMaps;
        static private IKeyboardMouseEvents m_GlobalHook;
        static bool isDown = false;

        static void Main(string[] args)
        {
            //dodać możliwość zmieniania oraz zapisywania
            m_GlobalHook = Hook.GlobalEvents();
            keyMaps = new Dictionary<string, string>()
            {
                { "Q", "£" },
                { "W", "­" },
                { "E", "€" },
                { "R", "‰" },
                { "T", "∑" },
                { "Y", "✓" },
                { "U", "∏" },
                { "I", "↑" },
                { "O", "∞" },
                { "P", "∫" },
                { "A", "æ" },
                { "S", "§" },
                { "D", "¶" },
                { "F", "•" },
                { "G", "∧" },
                { "H", "∨" },
                { "J", "←" },
                { "K", "↓" },
                { "L", "→" },
                { "Z", "♪" },
                { "X", "𝄞" },
                { "C", "♭" },
                { "V", "♯" },
                { "B", "₿" },
                { "N", "✗" },
                { "M", "¬" },
                { "D1", "°" },
                { "D2", "½" },
                { "D3", "⅓" },
                { "D4", "¼" },
                { "D5", "√" },
                { "D6", "±" },
                { "D7", "≈" },
                { "D8", "≠" },
                { "D9", "≤" },
                { "D0", "≥" }
            };
            m_GlobalHook.KeyDown += OnKeyDown;
            m_GlobalHook.KeyUp += OnKeyUp;
            Application.Run();
        }

        static private void OnKeyDown(object sender, KeyEventArgs e)
        {
            string keyCode = e.KeyCode.ToString();
            if (keyCode == "Apps" && !isDown)
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
            MessageBox.Show(e.KeyCode.ToString());
        }
    }
}
