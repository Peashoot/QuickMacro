using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace QuickMacro
{
    public class KeyboardHook
    {
        public KeyboardHook(TextBox detailTextBox)
        {
            this.detailTextBox = detailTextBox;
        }
        /// <summary>
        /// 
        /// </summary>
        public TextBox detailTextBox;
        /// <summary>
        /// 上一个按键
        /// </summary>
        Keys oldKey;
        /// <summary>
        /// 上一个按键的事件
        /// </summary>
        int oldwParam;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        public static int hKeyboardHook = 0; //声明键盘钩子处理的初始值
        //值在Microsoft SDK的Winuser.h里查询
        public const int WH_KEYBOARD_LL = 13;   //线程键盘钩子监听鼠标消息设为2，全局键盘监听鼠标消息设为13
        HookProc KeyboardHookProcedure; //声明KeyboardHookProcedure作为HookProc类型
        /// <summary>
        /// 计时器
        /// </summary>
        Stopwatch sw = new Stopwatch();

        //键盘结构
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  //定一个虚拟键码。该代码必须有一个价值的范围1至254
            public int scanCode; // 指定的硬件扫描码的关键
            public int flags;  // 键标志
            public int time; // 指定的时间戳记的这个讯息
            public int dwExtraInfo; // 指定额外信息相关的信息
        }
        //使用此功能，安装了一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);


        //调用此函数卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);


        //使用此功能，通过信息钩子继续下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        /// <summary>
        /// 启动钩子
        /// </summary>
        public void Start()
        {
            // 安装键盘钩子
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (!sw.IsRunning)
                {
                    sw.Start();
                }
                else
                {
                    sw.Restart();
                }
                //如果SetWindowsHookEx失败
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("安装键盘钩子失败");
                }
            }
        }
        /// <summary>
        /// 停止钩子
        /// </summary>
        public void Stop()
        {
            bool retKeyboard = true;
            if (sw.IsRunning)
            {
                sw.Stop();
                detailTextBox.Text += string.Format("Delay {0}\r\n", sw.ElapsedMilliseconds);
            }

            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }

            if (!(retKeyboard)) throw new Exception("卸载钩子失败！");
        }
        //ToAscii职能的转换指定的虚拟键码和键盘状态的相应字符或字符
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] 指定虚拟关键代码进行翻译。
                                         int uScanCode, // [in] 指定的硬件扫描码的关键须翻译成英文。高阶位的这个值设定的关键，如果是（不压）
                                         byte[] lpbKeyState, // [in] 指针，以256字节数组，包含当前键盘的状态。每个元素（字节）的数组包含状态的一个关键。如果高阶位的字节是一套，关键是下跌（按下）。在低比特，如果设置表明，关键是对切换。在此功能，只有肘位的CAPS LOCK键是相关的。在切换状态的NUM个锁和滚动锁定键被忽略。
                                         byte[] lpwTransKey, // [out] 指针的缓冲区收到翻译字符或字符。
                                         int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.

        //获取按键的状态
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        private const int WM_KEYDOWN = 0x100;                       //KEYDOWN
        private const int WM_KEYUP = 0x101;                         //KEYUP
        private const int WM_SYSKEYDOWN = 0x104;                    //SYSKEYDOWN
        private const int WM_SYSKEYUP = 0x105;                      //SYSKEYUP

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if (nCode >= 0)
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                // 键盘按下
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    if (oldKey != keyData || oldwParam != wParam)
                    {
                        sw.Stop();
                        detailTextBox.Text += string.Format("Delay {0}\r\n", sw.ElapsedMilliseconds);
                        detailTextBox.Text += string.Format("KeyPress {0}\r\n", keyData.ToString());
                        oldKey = keyData;
                        oldwParam = wParam;
                        sw.Restart();
                    }
                }
                // 键盘抬起
                if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {
                    if (oldKey != keyData || oldwParam != wParam)
                    {
                        sw.Stop();
                        detailTextBox.Text += string.Format("Delay {0}\r\n", sw.ElapsedMilliseconds);
                        detailTextBox.Text += string.Format("KeyUp {0}\r\n", keyData.ToString());
                        oldKey = keyData;
                        oldwParam = wParam;
                        sw.Restart();
                    }
                }

            }
            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
        ~KeyboardHook()
        {
            Stop();
        }
    }
}
