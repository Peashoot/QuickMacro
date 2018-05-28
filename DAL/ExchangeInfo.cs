/**  版本信息模板在安装目录下，可自行修改。
* ExchangeInfo.cs
*
* 功 能： N/A
* 类 名： ExchangeInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-05-25 15:34:03   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:ExchangeInfo
	/// </summary>
	public partial class ExchangeInfo
	{
		public ExchangeInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("RecordID", "ExchangeInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ExchangeInfo");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,4)
			};
			parameters[0].Value = RecordID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.ExchangeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ExchangeInfo(");
			strSql.Append("HotKeyID,ExchangeText,ShiftKey,MainKey)");
			strSql.Append(" values (");
			strSql.Append("@HotKeyID,@ExchangeText,@ShiftKey,@MainKey)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@HotKeyID", DbType.Int32,8),
					new SQLiteParameter("@ExchangeText", DbType.String),
					new SQLiteParameter("@ShiftKey", DbType.String),
					new SQLiteParameter("@MainKey", DbType.String)};
			parameters[0].Value = model.HotKeyID;
			parameters[1].Value = model.ExchangeText;
			parameters[2].Value = model.ShiftKey;
			parameters[3].Value = model.MainKey;

			object obj = DbHelperSQLite.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.ExchangeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ExchangeInfo set ");
			strSql.Append("HotKeyID=@HotKeyID,");
			strSql.Append("ExchangeText=@ExchangeText,");
			strSql.Append("ShiftKey=@ShiftKey,");
			strSql.Append("MainKey=@MainKey");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@HotKeyID", DbType.Int32,8),
					new SQLiteParameter("@ExchangeText", DbType.String),
					new SQLiteParameter("@ShiftKey", DbType.String),
					new SQLiteParameter("@MainKey", DbType.String),
					new SQLiteParameter("@RecordID", DbType.Int32,8)};
			parameters[0].Value = model.HotKeyID;
			parameters[1].Value = model.ExchangeText;
			parameters[2].Value = model.ShiftKey;
			parameters[3].Value = model.MainKey;
			parameters[4].Value = model.RecordID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RecordID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExchangeInfo ");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,4)
			};
			parameters[0].Value = RecordID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string RecordIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExchangeInfo ");
			strSql.Append(" where RecordID in ("+RecordIDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.ExchangeInfo GetModel(int RecordID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RecordID,HotKeyID,ExchangeText,ShiftKey,MainKey from ExchangeInfo ");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,4)
			};
			parameters[0].Value = RecordID;

			Model.ExchangeInfo model=new Model.ExchangeInfo();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.ExchangeInfo DataRowToModel(DataRow row)
		{
			Model.ExchangeInfo model=new Model.ExchangeInfo();
			if (row != null)
			{
				if(row["RecordID"]!=null && row["RecordID"].ToString()!="")
				{
					model.RecordID=int.Parse(row["RecordID"].ToString());
				}
				if(row["HotKeyID"]!=null && row["HotKeyID"].ToString()!="")
				{
					model.HotKeyID=int.Parse(row["HotKeyID"].ToString());
				}
				if(row["ExchangeText"]!=null)
				{
					model.ExchangeText=row["ExchangeText"].ToString();
				}
				if(row["ShiftKey"]!=null)
				{
					model.ShiftKey=row["ShiftKey"].ToString();
				}
				if(row["MainKey"]!=null)
				{
					model.MainKey=row["MainKey"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RecordID,HotKeyID,ExchangeText,ShiftKey,MainKey ");
			strSql.Append(" FROM ExchangeInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ExchangeInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.RecordID desc");
			}
			strSql.Append(")AS Row, T.*  from ExchangeInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "ExchangeInfo";
			parameters[1].Value = "RecordID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

