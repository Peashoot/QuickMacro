using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace DynamicCodeGenerate
{
    public class ScriptExecute
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "MapVirtualKey", SetLastError = true)]
        public static extern uint MapVirtualKey(Keys uCode, uint uMapType);

        public byte Scan_Code(Keys pKey)
        {
            uint result = MapVirtualKey(pKey, 0);
            return (byte)result;
        }

        public void KeyPress(Keys pKey)
        {
            keybd_event(pKey, Scan_Code(pKey), 0, 0);
        }

        public void KeyRelease(Keys pKey)
        {
            keybd_event(pKey, Scan_Code(pKey), 2, 0);
        }

        Thread scriptThread = null;

        bool isStop = false;

        public void StartThread()
        {
            if (scriptThread == null)
            {
                isStop = false;
                scriptThread = new Thread(FunctionExecute);
                scriptThread.IsBackground = true;
                scriptThread.Start();
            }
        }

        public void EndThread()
        {
            if (scriptThread != null)
            {
                isStop = true;
                scriptThread = null;
            }
        }

        public void FunctionExecute()
        {
            while (!isStop)
            {
                KeyPress(Keys.W);
                Thread.Sleep(100);
                KeyPress(Keys.Control);
                Thread.Sleep(100);
                KeyPress(Keys.E);
                Thread.Sleep(100);
                KeyRelease(Keys.E);
                Thread.Sleep(10);
                KeyRelease(Keys.Control);
                Thread.Sleep(10);
                KeyRelease(Keys.W);
                Thread.Sleep(200);
            }
        }
    }
}