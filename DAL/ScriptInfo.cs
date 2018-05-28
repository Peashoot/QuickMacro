/**  版本信息模板在安装目录下，可自行修改。
* ScriptInfo.cs
*
* 功 能： N/A
* 类 名： ScriptInfo
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
	/// 数据访问类:ScriptInfo
	/// </summary>
	public partial class ScriptInfo
	{
		public ScriptInfo()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ScriptInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ScriptInfo(");
			strSql.Append("RecordID,ScriptName,ScriptDetails)");
			strSql.Append(" values (");
			strSql.Append("@RecordID,@ScriptName,@ScriptDetails)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,8),
					new SQLiteParameter("@ScriptName", DbType.String),
					new SQLiteParameter("@ScriptDetails", DbType.String)};
			parameters[0].Value = model.RecordID ;
			parameters[1].Value = model.ScriptName;
			parameters[2].Value = model.ScriptDetails;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.ScriptInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScriptInfo set ");
			strSql.Append("RecordID=@RecordID,");
			strSql.Append("ScriptName=@ScriptName,");
			strSql.Append("ScriptDetails=@ScriptDetails");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@RecordID", DbType.Int32,8),
					new SQLiteParameter("@ScriptName", DbType.String),
					new SQLiteParameter("@ScriptDetails", DbType.String)};
			parameters[0].Value = model.RecordID ;
			parameters[1].Value = model.ScriptName;
			parameters[2].Value = model.ScriptDetails;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScriptInfo ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Model.ScriptInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RecordID,ScriptName,ScriptDetails from ScriptInfo ");
			strSql.Append(" where ");
			SQLiteParameter[] parameters = {
			};

			Model.ScriptInfo model=new Model.ScriptInfo();
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
		public Model.ScriptInfo DataRowToModel(DataRow row)
		{
			Model.ScriptInfo model=new Model.ScriptInfo();
			if (row != null)
			{
				if(row["RecordID"]!=null && row["RecordID"].ToString()!="")
				{
					model.RecordID =int.Parse(row["RecordID"].ToString());
				}
				if(row["ScriptName"]!=null)
				{
					model.ScriptName=row["ScriptName"].ToString();
				}
				if(row["ScriptDetails"]!=null)
				{
					model.ScriptDetails=row["ScriptDetails"].ToString();
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
			strSql.Append("select RecordID,ScriptName,ScriptDetails ");
			strSql.Append(" FROM ScriptInfo ");
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
			strSql.Append("select count(1) FROM ScriptInfo ");
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
			strSql.Append(")AS Row, T.*  from ScriptInfo T ");
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
			parameters[0].Value = "ScriptInfo";
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

