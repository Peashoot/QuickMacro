using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace QuickMacro
{
    public class DynamicInvoke
    {
        #region 成员对象
        /// <summary>
        /// 类实例对象
        /// </summary>
        static object objExecute = null;
        /// <summary>
        /// 开始线程方法
        /// </summary>
        static MethodInfo scriptStart = null;
        /// <summary>
        /// 结束线程方法
        /// </summary>
        static MethodInfo scriptEnd = null;
        /// <summary>
        /// 线程正在执行
        /// </summary>
        static bool threadRunning = false;
        #endregion
        #region 对生成的代码进行编译
        /// <summary>
        /// 对生成的代码进行编译
        /// </summary>
        public bool ReCompiler(string Details)
        {
            if (threadRunning)
            {
                return false;
            }
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compParameters = new CompilerParameters();
            //添加程序集引用
            compParameters.ReferencedAssemblies.Add("System.dll");
            compParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            //不生成可执行文件
            compParameters.GenerateExecutable = false;
            //在内存中执行
            compParameters.GenerateInMemory = true;
            //获取编译的结果
            CompilerResults cr = codeProvider.CompileAssemblyFromSource(compParameters, GenerateCode(Details));
            if (cr.Errors.HasErrors)
            {
                StringBuilder strbud = new StringBuilder();
                MessageBox.Show("编译错误!");
                foreach (CompilerError err in cr.Errors)
                {
                    strbud.Append(err.ErrorText);
                }
                MessageBox.Show(strbud.ToString());
                return false;
            }
            else
            {
                // 通过反射，调用类的实例  
                Assembly objAssembly = cr.CompiledAssembly;
                objExecute = objAssembly.CreateInstance("DynamicCodeGenerate.ScriptExecute");
                scriptStart = objExecute.GetType().GetMethod("StartThread");
                scriptEnd = objExecute.GetType().GetMethod("EndThread");
                return true;
            }  
        }
        #endregion
        #region 启动线程
        /// <summary>
        /// 启动线程
        /// </summary>
        public void StartThread()
        {
            if (scriptStart != null && objExecute != null && !threadRunning)
            {
                scriptStart.Invoke(objExecute, null);
                threadRunning = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
            else
            {
                MessageBox.Show("线程异常!");
            }
        }
        #endregion
        #region 终止线程
        /// <summary>
        /// 终止线程
        /// </summary>
        public void EndThread()
        {
            if (scriptEnd != null && objExecute != null && threadRunning)
            {
                scriptEnd.Invoke(objExecute, null);
                threadRunning = false;
                System.Media.SystemSounds.Question.Play();
            }
            else
            {
                MessageBox.Show("线程异常!");
            }
        }
        #endregion
        #region 生成可执行代码
        /// <summary>
        /// C#
        /// </summary>
        /// <param name="Details"></param>
        /// <returns></returns>
        public string GenerateCode(string Details)
        {
            StringBuilder strbud = new StringBuilder();
            strbud.AppendEx(0, "using System;");
            strbud.AppendEx(0, "using System.Windows.Forms;");
            strbud.AppendEx(0, "using System.Runtime.InteropServices; ");
            strbud.AppendEx(0, "using System.Threading; ");
            strbud.AppendEx(0, "namespace DynamicCodeGenerate");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "public class ScriptExecute");
            strbud.AppendEx(1, "{");
            strbud.AppendEx(2, "Thread scriptThread = null;");
            strbud.AppendEx(2, "bool isStop = false;");
            strbud.AppendEx();
            strbud.AppendEx(2, "[DllImport(\"user32.dll\", EntryPoint = \"keybd_event\", SetLastError = true)] ");
            strbud.AppendEx(2, "public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo); ");
            strbud.AppendEx();
            strbud.AppendEx(2, "[DllImport(\"user32.dll\", EntryPoint = \"MapVirtualKey\", SetLastError = true)]");
            strbud.AppendEx(2, "public static extern uint MapVirtualKey(Keys uCode, uint uMapType);");
            strbud.AppendEx();
            strbud.AppendEx(2, "public byte Scan_Code(Keys pKey)");
            strbud.AppendEx(2, "{");
            strbud.AppendEx(3, "uint result = MapVirtualKey(pKey, 0);");
            strbud.AppendEx(3, "return (byte)result;");
            strbud.AppendEx(2, "}");
            strbud.AppendEx();
            strbud.AppendEx(2, "public void KeyPress(Keys pKey)");
            strbud.AppendEx(2, "{");
            strbud.AppendEx(3, "keybd_event(pKey, Scan_Code(pKey), 0, 0);");
            strbud.AppendEx(2, "}");
            strbud.AppendEx();
            strbud.AppendEx(2, "public void KeyRelease(Keys pKey)");
            strbud.AppendEx(2, "{");
            strbud.AppendEx(3, "keybd_event(pKey, Scan_Code(pKey), 2, 0);");
            strbud.AppendEx(2, "}");
            strbud.AppendEx();
            strbud.AppendEx(2, "public void StartThread()");
            strbud.AppendEx(2, "{");
            strbud.AppendEx(3, "if (scriptThread == null)");
            strbud.AppendEx(3, "{");
            strbud.AppendEx(4, "isStop = false; ");
            strbud.AppendEx(4, "scriptThread = new Thread(FunctionExecute); ");
            strbud.AppendEx(4, "scriptThread.IsBackground = true; ");
            strbud.AppendEx(4, "scriptThread.Start();");
            strbud.AppendEx(3, "}");
            strbud.AppendEx(2, "}");
            strbud.AppendEx();
            strbud.AppendEx(2, "public void EndThread()");
            strbud.AppendEx(2, "{");
            strbud.AppendEx(3, "if (scriptThread != null)");
            strbud.AppendEx(3, "{");
            strbud.AppendEx(4, "isStop = true;");
            strbud.AppendEx(4, "scriptThread = null;");
            strbud.AppendEx(3, "}");
            strbud.AppendEx(2, "}");
            strbud.AppendEx();
            strbud.AppendEx(2, "public void FunctionExecute()");
            strbud.AppendEx(2, "{");
            int curTab = 3;
            Regex reg = new Regex(@"\s+");
            string[] strarr = reg.Replace(Details, " ").Split(' ');
            for (int i = 0; i < strarr.Length; i += 2)
            {
                switch (strarr[i])
                {
                    case "Rem":
                        strbud.AppendEx(curTab++, "while (!isStop)");
                        strbud.AppendEx(curTab, "{");
                        break;
                    case "Goto":
                        strbud.AppendEx(--curTab, "}");
                        break;
                    case "KeyPress":
                        strbud.AppendEx(curTab, string.Format("KeyPress(Keys.{0}); ", strarr[i + 1]));
                        break;
                    case "KeyUp":
                        strbud.AppendEx(curTab, string.Format("KeyRelease(Keys.{0}); ", strarr[i + 1]));
                        break;
                    case "Delay":
                        strbud.AppendEx(curTab, string.Format("Thread.Sleep({0}); ", strarr[i + 1]));
                        break;
                    case "If":
                        strbud.AppendEx(curTab++, string.Format("if ({0})", strarr[i + 1]));
                        strbud.AppendEx(curTab, "{");
                        break;
                    case "Else":
                        strbud.AppendEx(--curTab, "}");
                        strbud.AppendEx(curTab, "else");
                        strbud.AppendEx(curTab++, "{");
                        break;
                    case "ElseIf": 
                        strbud.AppendEx(--curTab, "}");
                        strbud.AppendEx(curTab, string.Format("else if ({0})", strarr[i + 1]));
                        strbud.AppendEx(curTab++, "{");
                        break;
                    case "EndIf":
                        strbud.AppendEx(--curTab, "}");
                        strbud.AppendEx();
                        break;
                }
            }
            strbud.AppendEx(2, "}");
            strbud.AppendEx(1, "}");
            strbud.Append("}");
            return strbud.ToString();
        }
        /// <summary>
        /// C++
        /// </summary>
        /// <param name="Details"></param>
        /// <returns></returns>
        public string GenerateCodeJava(string Details)
        {
            StringBuilder strbud = new StringBuilder();
            strbud.AppendEx(0, "package DynamicCodeGenerate;");
            strbud.AppendEx(0, "import java.awt.Robot;");
            strbud.AppendEx(0, "import java.awt.event.KeyEvent;");
            strbud.AppendEx();
            strbud.AppendEx(0, "public class ScriptExecute {");
            strbud.AppendEx();
            strbud.AppendEx(1, "boolean isStop = false;");
            strbud.AppendEx();
            strbud.AppendEx(1, "Thread runThread = null;");
            strbud.AppendEx();
            strbud.AppendEx(1, "public void StartThread() {");
            strbud.AppendEx(2, "runThread = new ExecuteThread();");
            strbud.AppendEx(2, "isStop = false;");
            strbud.AppendEx(2, "runThread.start();");
            strbud.AppendEx(1, "}");
            strbud.AppendEx();
            strbud.AppendEx(1, "public void EndThread() {");
            strbud.AppendEx(2, "isStop = true;");
            strbud.AppendEx(2, "runThread = null;");
            strbud.AppendEx(1, "}");
            strbud.AppendEx();
            strbud.AppendEx(1, "class ExecuteThread extends Thread {");
            strbud.AppendEx(2, "@Override");
            strbud.AppendEx(2, "public void run() {");
            strbud.AppendEx(3, "Robot bot;");
            strbud.AppendEx(3, "try {");
            strbud.AppendEx(4, "bot = new Robot();");
            int curTab = 4;
            Regex reg = new Regex(@"\s+");
            string[] strarr = reg.Replace(Details, " ").Split(' ');
            for (int i = 0; i < strarr.Length; i += 2)
            {
                switch (strarr[i])
                {
                    case "Rem":
                        strbud.AppendEx(curTab++, "while (!isStop) {");
                        break;
                    case "Goto":
                        strbud.AppendEx(--curTab, "}");
                        break;
                    case "KeyPress":
                        strbud.AppendEx(curTab, string.Format("bot.keyPress(KeyEvent.VK_{0}); ", strarr[i + 1].ToUpper()));
                        break;
                    case "KeyUp":
                        strbud.AppendEx(curTab, string.Format("bot.keyRelease(KeyEvent.VK_{0}); ", strarr[i + 1].ToUpper()));
                        break;
                    case "Delay":
                        strbud.AppendEx(curTab, string.Format("bot.delay({0}); ", strarr[i + 1]));
                        break;
                }
            }
            strbud.AppendEx(3, "} catch (Exception e) {");
            strbud.AppendEx(4, "e.printStackTrace();");
            strbud.AppendEx(3, "}");
            strbud.AppendEx(2, "}");
            strbud.AppendEx(1, "}");
            strbud.Append("}");
            return strbud.ToString();
        }
        /// <summary>
        /// Java
        /// </summary>
        /// <param name="Details"></param>
        /// <returns></returns>
        public string GenerateCodeCPlus(string Details)
        {
            StringBuilder strbud = new StringBuilder();
            strbud.AppendEx(0, "#include <iostream>");
            strbud.AppendEx(0, "#include <windows.h>");
            strbud.AppendEx(0, "#include \"scriptexecute.h\"");
            strbud.AppendEx();
            strbud.AppendEx(0, "BYTE Scan_Code(Keys pKey)");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "const DWORD result = MapVirtualKey(pKey, MAPVK_VK_TO_VSC);");
            strbud.AppendEx(1, "return static_cast<BYTE> (result);");
            strbud.AppendEx(0, "}");
            strbud.AppendEx();
            strbud.AppendEx(0, "void KeyPress(Keys pKey)");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "keybd_event(pKey, Scan_Code(pKey), 0, 0);");
            strbud.AppendEx(0, "}");
            strbud.AppendEx();
            strbud.AppendEx(0, "void KeyRelease(Keys pKey)");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "keybd_event(pKey, Scan_Code(pKey), 2, 0);");
            strbud.AppendEx(0, "}");
            strbud.AppendEx();
            strbud.AppendEx(0, "HANDLE hThread;");
            strbud.AppendEx();
            strbud.AppendEx(0, "bool isStop = false;");
            strbud.AppendEx();
            strbud.AppendEx(0, "DWORD WINAPI FunctionExecute(LPVOID lpParamter)");
            strbud.AppendEx(0, "{");
            int curTab = 1;
            Regex reg = new Regex(@"\s+");
            string[] strarr = reg.Replace(Details, " ").Split(' ');
            for (int i = 0; i < strarr.Length; i += 2)
            {
                switch (strarr[i])
                {
                    case "Rem":
                        strbud.AppendEx(curTab++, "while (!isStop)");
                        strbud.AppendEx(curTab, "{");
                        break;
                    case "Goto":
                        strbud.AppendEx(--curTab, "}");
                        break;
                    case "KeyPress":
                        strbud.AppendEx(curTab, string.Format("KeyPress({0}); ", strarr[i + 1]));
                        break;
                    case "KeyUp":
                        strbud.AppendEx(curTab, string.Format("KeyRelease({0}); ", strarr[i + 1]));
                        break;
                    case "Delay":
                        strbud.AppendEx(curTab, string.Format("Sleep({0}); ", strarr[i + 1]));
                        break;
                }
            }
            strbud.AppendEx(1, "return 0L;");
            strbud.AppendEx(0, "}");
            strbud.AppendEx();
            strbud.AppendEx(0, "void StartThread()");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "if (hThread == NULL)");
            strbud.AppendEx(1, "{");
            strbud.AppendEx(2, "isStop = false;");
            strbud.AppendEx(2, "hThread = CreateThread(NULL, 0, FunctionExecute, NULL, 0, NULL);");
            strbud.AppendEx(1, "}");
            strbud.AppendEx(0, "}");
            strbud.AppendEx();
            strbud.AppendEx(0, "void EndThread()");
            strbud.AppendEx(0, "{");
            strbud.AppendEx(1, "if (hThread != NULL)");
            strbud.AppendEx(1, "{");
            strbud.AppendEx(2, "isStop = true;");
            strbud.AppendEx(2, "CloseHandle(hThread);");
            strbud.AppendEx(2, "hThread = NULL;");
            strbud.AppendEx(1, "}");
            strbud.Append("}");
            return strbud.ToString();
        }
        /// <summary>
        /// VB
        /// </summary>
        /// <param name="Details"></param>
        /// <returns></returns>
        public string GenerateCodeVB(string Details)
        {
            StringBuilder strbud = new StringBuilder();
            return strbud.ToString();
        }
        #endregion
    }
}
