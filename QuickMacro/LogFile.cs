using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QuickMacro
{
    public class LogFile
    {
        public static bool writeLog = true;

        public static string folderPath
        {
            get { return folderPath; }
            set
            {
                folderPath = folderPath.TrimEnd('\\');
                folderPath = folderPath + '\\';
            }
        }

        public static void initLogFile(string logFolder)
        {
            folderPath = logFolder;
        }

        private static FileStream OpenLogFile(string logName)
        {
            string totalPath = folderPath + logName;
            if (!File.Exists(totalPath))
            {
                return File.Create(totalPath);
            }
            else
            {
                return new FileStream(totalPath, FileMode.Append);
            }
        }

        private static void WriteLogFile(string logName, string logInfo)
        {
                FileStream fs = OpenLogFile(logName);
                string timePrefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss |");
                logInfo = timePrefix + logInfo + "\r\n";
                byte[] bytes = Encoding.Default.GetBytes(logInfo);
                fs.Write(bytes, 0, bytes.Length);
        }

        public static void WriteLogFile(string logInfo)
        {
            if (writeLog)
            {
                string normalLogName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                WriteLogFile(normalLogName, logInfo);
            }
        }

        public static void WriteErrorLogFile(string logInfo)
        {
            if (writeLog)
            {
                string errorLogName = DateTime.Now.ToString("yyyy-MM-dd") + "_Error.txt";
                WriteLogFile(errorLogName, logInfo);
            }
        }

        public static void WriteSystemLogFile(string logInfo)
        {
            if (writeLog)
            {
                string sysLogName = DateTime.Now.ToString("yyyy-MM-dd") + "_System.txt";
                WriteLogFile(sysLogName, logInfo);
            }
        }
    }
}
