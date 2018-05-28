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
using System.Collections.Generic;
using Model;
namespace BLL
{
	/// <summary>
	/// SysParamInfo
	/// </summary>
	public partial class SysParamInfo
	{
		private readonly DAL.SysParamInfo dal=new DAL.SysParamInfo();
		public SysParamInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RecordID)
		{
			return dal.Exists(RecordID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.SysParamInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.SysParamInfo model)
		{
			return dal.Update(model);
		}

        public bool Update(string ItemName, string ItemValue1, string ItemValue2)
        {
            Model.SysParamInfo model = GetModelList(string.Format(" ItemName={0}",ItemName))[0];
            model.ItemValue1 = ItemValue1;
            model.ItemValue2 = ItemValue2;
            return Update(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RecordID)
		{
			
			return dal.Delete(RecordID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RecordIDlist )
		{
			return dal.DeleteList(RecordIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.SysParamInfo GetModel(int RecordID)
		{
			
			return dal.GetModel(RecordID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public Model.SysParamInfo GetModelByCache(int RecordID)
        //{
			
        //    string CacheKey = "SysParamInfoModel-" + RecordID;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(RecordID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Model.SysParamInfo)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.SysParamInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.SysParamInfo> DataTableToList(DataTable dt)
		{
			List<Model.SysParamInfo> modelList = new List<Model.SysParamInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.SysParamInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

