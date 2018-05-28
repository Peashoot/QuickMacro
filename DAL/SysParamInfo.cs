/**  版本信息模板在安装目录下，可自行修改。
* SysParamInfo.cs
*
* 功 能： N/A
* 类 名： SysParamInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/05/23 14:36:27   N/A    初版
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
	/// 数据访问类:SysParamInfo
	/// </summary>
	public partial class SysParamInfo
	{
		public SysParamInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("RecordID", "SysParamInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RecordID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysParamInfo");
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
		public int Add(Model.SysParamInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysParamInfo(");
			strSql.Append("ItemName,ItemValue1,ItemValue2)");
			strSql.Append(" values (");
			strSql.Append("@ItemName,@ItemValue1,@ItemValue2)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ItemName", DbType.String),
					new SQLiteParameter("@ItemValue1", DbType.String),
					new SQLiteParameter("@ItemValue2", DbType.String)};
			parameters[0].Value = model.ItemName;
			parameters[1].Value = model.ItemValue1;
			parameters[2].Value = model.ItemValue2;

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
		public bool Update(Model.SysParamInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysParamInfo set ");
			strSql.Append("ItemName=@ItemName,");
			strSql.Append("ItemValue1=@ItemValue1,");
			strSql.Append("ItemValue2=@ItemValue2");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ItemName", DbType.String),
					new SQLiteParameter("@ItemValue1", DbType.String),
					new SQLiteParameter("@ItemValue2", DbType.String),
					new SQLiteParameter("@RecordID", DbType.Int32,8)};
			parameters[0].Value = model.ItemName;
			parameters[1].Value = model.ItemValue1;
			parameters[2].Value = model.ItemValue2;
			parameters[3].Value = model.RecordID;

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
			strSql.Append("delete from SysParamInfo ");
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
			strSql.Append("delete from SysParamInfo ");
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
		public Model.SysParamInfo GetModel(int RecordID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RecordID,ItemName,ItemValue1,ItemValue2 from SysParamInfo ");
			strSql.Append(" where RecordID=@RecordID");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,4)
			};
			parameters[0].Value = RecordID;

			Model.SysParamInfo model=new Model.SysParamInfo();
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
		public Model.SysParamInfo DataRowToModel(DataRow row)
		{
			Model.SysParamInfo model=new Model.SysParamInfo();
			if (row != null)
			{
				if(row["RecordID"]!=null && row["RecordID"].ToString()!="")
				{
					model.RecordID=int.Parse(row["RecordID"].ToString());
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
				if(row["ItemValue1"]!=null)
				{
					model.ItemValue1=row["ItemValue1"].ToString();
				}
				if(row["ItemValue2"]!=null)
				{
					model.ItemValue2=row["ItemValue2"].ToString();
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
			strSql.Append("select RecordID,ItemName,ItemValue1,ItemValue2 ");
			strSql.Append(" FROM SysParamInfo ");
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
			strSql.Append("select count(1) FROM SysParamInfo ");
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
			strSql.Append(")AS Row, T.*  from SysParamInfo T ");
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
			parameters[0].Value = "SysParamInfo";
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

