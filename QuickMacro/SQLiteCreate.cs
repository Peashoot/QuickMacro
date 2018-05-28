using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using DBUtility;

namespace QuickMacro
{
    public class SQLiteCreate
    {
        /// <summary>
        /// 创建DB文件
        /// </summary>
        private void CreateSQLiteDB()
        {
            SQLiteConnection.CreateFile("Datalib.db");
        }
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="connection"></param>
        private void CreateTables(SQLiteConnection connection)
        {
            string sql = "DROP TABLE IF EXISTS \"SysParamInfo\";" +
                            "CREATE TABLE \"SysParamInfo\" (" +
                            "\"RecordID\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "\"ItemName\"  TEXT," +
                            "\"ItemValue1\"  TEXT," +
                            "\"ItemValue2\"  TEXT" +
                            ");";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "DROP TABLE IF EXISTS \"ScriptInfo\";" +
                            "CREATE TABLE \"ScriptInfo\" (" +
                            "\"RecordID\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "\"ScriptName\"  TEXT," +
                            "\"ScriptDetails\"  TEXT" +
                            ");";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "DROP TABLE IF EXISTS \"ExchangeInfo\";" +
                            "CREATE TABLE \"ExchangeInfo\" (" +
                            "\"RecordID\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "\"HotKeyID\"  INTEGER," +
                            "\"ExchangeText\"  TEXT," +
                            "\"ShiftKey\"  TEXT," +
                            "\"MainKey\"  TEXT" +
                            ");";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 添加SysParamInfo表
        /// </summary>
        /// <param name="connection"></param>
        private void InsertIntoSysParamInfo(SQLiteConnection connection)
        {
            string sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('ShowBegin', 'true', NULL, 1);";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
                sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('ActivateHotKey', 'None', 'F10', 2);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('StopHotKey', 'None', 'F11', 3);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('RecordHotKey', 'None', 'F2', 4);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('ShowHideHotKey', 'None', 'F1', 5);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('LastUseScript', 'Default', NULL, 6);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "INSERT INTO \"SysParamInfo\" (\"ItemName\", \"ItemValue1\", \"ItemValue2\", \"ROWID\") VALUES ('WriteLog', 'true', NULL, 7);";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 添加ScriptInfo表
        /// </summary>
        /// <param name="connection"></param>
        private void InsertIntoScriptInfo(SQLiteConnection connection)
        {
            string sql = "INSERT INTO \"ScriptInfo\" (\"RecordID\", \"ScriptName\", \"ScriptDetails\", \"ROWID\") VALUES (1, 'Default', " +
                            "'Rem go\r\n" +
                            "KeyPress W\r\n" +
                            "Delay 100\r\n" +
                            "KeyPress LControlKey\r\n" +
                            "Delay 100\r\n" +
                            "KeyPress E\r\n" +
                            "Delay 100\r\n" +
                            "KeyUp E\r\n" +
                            "Delay 10\r\n" +
                            "KeyUp LControlKey\r\n" +
                            "Delay 10\r\n" +
                            "KeyUp W\r\n" +
                            "Delay 200\r\n" +
                            "Goto go', 1);";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 创建DB文件
        /// </summary>
        public void BuildDataBase()
        {
            if (File.Exists("Datalib.db"))
            {
                return;
            }
            CreateSQLiteDB();
            using (SQLiteConnection connection = new SQLiteConnection(DbHelperSQLite.connectionString))
            {
                connection.Open();
                CreateTables(connection);
                InsertIntoSysParamInfo(connection);
                InsertIntoScriptInfo(connection);
                connection.Close();
            }
        }
    }
}
