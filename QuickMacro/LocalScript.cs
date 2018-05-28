using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace QuickMacro
{
    static class Extend
    {
        #region StringBuilder扩展
        /// <summary>
        /// + num个"\t" + str
        /// </summary>
        /// <param name="strapp"></param>
        /// <param name="num"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static StringBuilder Append(this StringBuilder strapp, int num, string str)
        {
            try
            {
                StringBuilder strbud = new StringBuilder();
                for (int i = 0; i < num; i++)
                {
                    strbud.Append("\t");
                }
                return strapp.Append(strbud.ToString() + str);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// + "\r\n"
        /// </summary>
        /// <param name="strapp"></param>
        /// <returns></returns>
        public static StringBuilder AppendEx(this StringBuilder strapp)
        {
            try
            {
                return strapp.Append("\r\n");
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// + "str" + "\r\n"
        /// </summary>
        /// <param name="strapp"></param>
        /// <param name="str"></param>
        /// <returns></returns>
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
        /// <summary>
        /// + num个"\t" + str + "\r\n"
        /// </summary>
        /// <param name="strapp"></param>
        /// <param name="num"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static StringBuilder AppendEx(this StringBuilder strapp, int num, string str)
        {
            try
            {
                StringBuilder strbud = new StringBuilder();
                for (int i = 0; i < num; i++)
                {
                    strbud.Append("\t");
                }
                return strapp.Append(strbud.ToString() + str + "\r\n");
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region 去除字符串首尾的字符串
        /// <summary>
        /// 去除字符串首尾的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trim"></param>
        /// <returns></returns>
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
        #endregion
        #region 根据Value获取字典中的Key
        /// <summary>
        /// 根据Value获取字典中的Key
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetKey(this Dictionary<string, int> dic, int obj)
        {
            string ret = "";
            foreach (string str in dic.Keys)
            {
                if (dic[str] == obj)
                {
                    ret = str;
                    break;
                }
            }
            return ret;
        }
        #endregion
    }
}
