using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace QuickMacro
{
    public class ConfigInfo
    {
        #region 配置参数
        /// <summary>
        /// 启动热键
        /// </summary>
        public static string ActivateHotKey;
        /// <summary>
        /// 停止热键
        /// </summary>
        public static string StopHotKey;
        /// <summary>
        /// 录制热键
        /// </summary>
        public static string RecordHotKey;
        /// <summary>
        /// 缩放热键
        /// </summary>
        public static string ShowHideHotKey;
        /// <summary>
        /// 上一次使用的脚本名称
        /// </summary>
        public static string LastUseScript;
        /// <summary>
        /// 开始是否显示界面
        /// </summary>
        public static bool StartShow;
        #endregion
        #region 获取配置
        /// <summary>
        /// 获取配置
        /// </summary>
        public static void Get_ConfigInfo()
        {
            try
            {
                ActivateHotKey = Get_ConfigValue("ActivateHotKey")[0];
            }
            catch 
            {
                ActivateHotKey = "None+F10"; 
                UpdateAppConfig("ActivateHotKey", ActivateHotKey);
            }
            try
            {
                StopHotKey = Get_ConfigValue("StopHotKey")[0];
            }
            catch
            {
                StopHotKey = "None+F11";
                UpdateAppConfig("StopHotKey", StopHotKey);
            }
            try
            {
                RecordHotKey = Get_ConfigValue("RecordHotKey")[0];
            }
            catch
            {
                RecordHotKey = "None+F2";
                UpdateAppConfig("RecordHotKey", RecordHotKey);
            }
            try
            {
                ShowHideHotKey = Get_ConfigValue("ShowHideHotKey")[0];
            }
            catch
            {
                ShowHideHotKey = "None+F1";
                UpdateAppConfig("ShowHideHotKey", ShowHideHotKey);
            }
            try
            {
                LastUseScript = Get_ConfigValue("LastUseScript")[0];
            }
            catch
            {
                LastUseScript = "Default";
                UpdateAppConfig("LastUseScript", LastUseScript);
            }
        }
        #endregion
        #region 获取config值
        /// <summary>
        /// 获取config值
        /// </summary>
        /// <param name="AppKey"></param>
        /// <returns></returns>
        public static List<string> Get_ConfigValue(string strKey, bool isFuzzy = false)
        {
            List<string> retlist = new List<string>();
            string file = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (isFuzzy)
                {
                    if (key.Contains(strKey))
                    {
                        retlist.Add(config.AppSettings.Settings[key].Value.ToString());
                    }
                }
                else
                {
                    if (key == strKey)
                    {
                        retlist.Add(config.AppSettings.Settings[key].Value.ToString());
                    }
                }
            }
            return retlist;
        }
        #endregion
        #region 设置config值
        /// <summary>
        /// 设置config值
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
                if (key == newKey)
                    exist = true;
            if (exist)
                config.AppSettings.Settings.Remove(newKey);
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
        #region 删除config值
        /// <summary>
        /// 删除config值
        /// </summary>
        /// <param name="deleteKey"></param>
        /// <param name="isFuzzy"></param>
        public static void DeleteAppConfig(string deleteKey, bool isFuzzy = false)
        {
            List<string> dellist = new List<string>();
            string file = Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (isFuzzy)
                {
                    if (key.Contains(deleteKey))
                    {
                        dellist.Add(config.AppSettings.Settings[key].Value.ToString());
                    }
                }
                else
                {
                    if (key == deleteKey)
                    {
                        dellist.Add(config.AppSettings.Settings[key].Value.ToString());
                    }
                }
            }
            foreach (string key in dellist)
            {
                config.AppSettings.Settings.Remove(key);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
    }
}
