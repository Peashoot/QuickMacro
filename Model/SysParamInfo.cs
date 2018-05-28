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
namespace Model
{
	/// <summary>
	/// SysParamInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysParamInfo
	{
		public SysParamInfo()
		{}
		#region Model
		private int _recordid;
		private string _itemname;
		private string _itemvalue1;
		private string _itemvalue2;
		/// <summary>
		/// 
		/// </summary>
		public int RecordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemValue1
		{
			set{ _itemvalue1=value;}
			get{return _itemvalue1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemValue2
		{
			set{ _itemvalue2=value;}
			get{return _itemvalue2;}
		}
		#endregion Model

	}
}

