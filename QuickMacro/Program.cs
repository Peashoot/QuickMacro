using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace QuickMacro
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //0106add  一次打开一个应用程序  
            Process instance = RunningInstance();
            if (instance != null)
            {
                if (instance.MainWindowHandle.ToInt32() == 0) //是否托盘化  
                {
                    IntPtr hwnd;
                    hwnd = FindWindow("WindowsForms10.Window.8.app.0.13965fa_r9_ad1", "按键精灵");
                    if (hwnd == IntPtr.Zero)
                    {
                        hwnd = FindWindow(null, "按键精灵");
                    }
                    PostMessage(hwnd, SimpleQuickMacro.WM_USER + 1, 0, 0);
                    return;
                }
                //1.2 已经有一个实例在运行  
                HandleRunningInstance(instance);
                return;
            }
            //LoadResourceDll.RegistDLL();
            new SQLiteCreate().BuildDataBase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleQuickMacro());
            //Application.Run(new HideOnStartupApplicationContext(new SimpleQuickMacro()));

            //MyRegisterForm form = new MyRegisterForm();
            //form.Create();
            //form.Show();
            //Application.Run();
        }

        #region 确保程序只运行一个实例
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表   
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程   
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径  
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的进程  
                        return process;
                    }
                }
            }
            return null;
        }
        //3.已经有了就把它激活，并将其窗口放置最前端  
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, 1); //调用api函数，正常显示窗口  
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端  
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        #endregion  
    }
}
