using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace QuickMacro
{
    public class LocalScript
    {
        #region 成员变量
        /// <summary>
        /// 保存脚本的文件名
        /// </summary>
        string scriptFile = "Script.txt";
        /// <summary>
        /// 分割线内容
        /// </summary>
        string dividingLine = "################分########割########线##################";
        /// <summary>
        /// 脚本列表
        /// </summary>
        public List<ScriptClass> scriptList = new List<ScriptClass>();
        #endregion
        /// <summary>
        /// 读取Script的TXT文件
        /// </summary>
        public void ReadScript()
        {
            if (File.Exists(scriptFile))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(scriptFile))
                    {
                        string line;
                        StringBuilder strAppend = new StringBuilder();
                        ScriptClass sc = null;
                        while ((line = sr.ReadLine()) != null)
                        {
                            switch (line)
                            {
                                case "NAME:":
                                    sc = new ScriptClass();
                                    strAppend.Clear();
                                    break;
                                case "DETAILS:":
                                    sc.ScriptName = strAppend.ToString().Trim("\r\n");
                                    strAppend.Clear();
                                    break;
                                case "################分########割########线##################":
                                    sc.Details = strAppend.ToString().Trim("\r\n");
                                    scriptList.Add(sc);
                                    break;
                                default:
                                    strAppend.AppendEx(line);
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                #region 增加默认脚本
                ScriptClass sc = new ScriptClass();
                sc.ScriptName = "Default";
                StringBuilder strapp = new StringBuilder();
                strapp.AppendEx("Rem go");
                strapp.AppendEx("KeyPress W");
                strapp.AppendEx("Delay 100");
                strapp.AppendEx("KeyPress Control");
                strapp.AppendEx("Delay 100");
                strapp.AppendEx("KeyPress E");
                strapp.AppendEx("Delay 100");
                strapp.AppendEx("KeyUp E");
                strapp.AppendEx("Delay 10");
                strapp.AppendEx("KeyUp Control");
                strapp.AppendEx("Delay 10");
                strapp.AppendEx("KeyUp W");
                strapp.AppendEx("Delay 200");
                strapp.AppendEx("Goto go");
                sc.Details = strapp.ToString();
                scriptList.Add(sc);
                #endregion
            }
        }
        /// <summary>
        /// 写入Script的TXT文件
        /// </summary>
        public void WriteScript()
        {
            try
            {
                if (File.Exists(scriptFile))
                {
                    File.Delete(scriptFile);
                }
                using (FileStream fs = new FileStream(scriptFile, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (ScriptClass sc in scriptList)
                        {
                            sw.WriteLine("NAME:");
                            sw.WriteLine(sc.ScriptName.Trim("\r\n"));
                            sw.WriteLine("DETAILS:");
                            sw.WriteLine(sc.Details.Trim("\r\n"));
                            sw.WriteLine(dividingLine);
                        }
                        sw.Flush();
                        sw.Close();
                    }
                    fs.Close();
                }
                MessageBox.Show("保存完成");
            }
            catch
            {
                throw;
            }
        }
    }

    public class ScriptClass
    {
        public string ScriptName;
        public string Details;
    }

    static class Extend
    {
        public static StringBuilder AppendEx(this StringBuilder strapp, string str)
        {
            try
            {
                return strapp.Append(str + "\r\n");
            }
            catch
            {
                throw;
            }
        }

        public static string Trim(this string str, string trim)
        {
            try
            {
                while (str.StartsWith(trim))
                {
                    str = str.Substring(trim.Length);
                }
                while (str.EndsWith(trim))
                {
                    str = str.Substring(0, str.LastIndexOf(trim));
                }
                return str;
            }
            catch
            {
                throw;
            }
        }
    }
}
