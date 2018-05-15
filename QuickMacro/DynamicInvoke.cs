using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

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
            }
            else
            {
                MessageBox.Show("线程异常!");
            }
        }
        #endregion
        #region 生成可执行代码
        /// <summary>
        /// 生成可执行代码
        /// </summary>
        /// <param name="Details"></param>
        /// <returns></returns>
        public string GenerateCode(string Details)
        {
            StringBuilder strbud = new StringBuilder();
            strbud.Append("using System; ");
            strbud.Append("using System.Windows.Forms; ");
            strbud.Append("using System.Runtime.InteropServices; ");
            strbud.Append("using System.Threading; ");
            strbud.Append("namespace DynamicCodeGenerate {");
            strbud.Append("public class ScriptExecute { ");
            strbud.Append("[DllImport(\"user32.dll\", EntryPoint = \"keybd_event\", SetLastError = true)] ");
            strbud.Append("public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo); ");
            strbud.Append("Thread scriptThread = null;");
            strbud.Append("public void StartThread() {");
            strbud.Append("if (scriptThread == null) {");
            strbud.Append("scriptThread = new Thread(FunctionExecute); ");
            strbud.Append("scriptThread.IsBackground = true; ");
            strbud.Append("scriptThread.Start();");
            strbud.Append("}}");
            strbud.Append("public void EndThread() {");
            strbud.Append("if (scriptThread != null) {");
            strbud.Append("scriptThread.Abort();");
            strbud.Append("scriptThread = null;");
            strbud.Append("}}");
            strbud.Append("public void FunctionExecute() { ");
            Regex reg = new Regex(@"\s+");
            string[] strarr = reg.Replace(Details, " ").Split(' ');
            for (int i = 0; i < strarr.Length; i += 2)
            {
                switch (strarr[i])
                {
                    case "Rem":
                        strbud.Append(strarr[i + 1] + ": ");
                        break;
                    case "Goto":
                        strbud.Append("goto " + strarr[i + 1] + "; ");
                        break;
                    case "KeyPress":
                        strbud.Append(string.Format("keybd_event(Keys.{0}, 0, 0, 0); ", strarr[i + 1]));
                        break;
                    case "KeyUp":
                        strbud.Append(string.Format("keybd_event(Keys.{0}, 0, 2, 0); ", strarr[i + 1]));
                        break;
                    case "Delay":
                        strbud.Append(string.Format("Thread.Sleep({0}); ", strarr[i + 1]));
                        break;
                }
            }
                strbud.Append("}}}");
            return strbud.ToString();
        }
        #endregion
    }
}
