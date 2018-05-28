/**  版本信息模板在安装目录下，可自行修改。
* ExchangeInfo.cs
*
* 功 能： N/A
* 类 名： ExchangeInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-05-25 15:29:57   N/A    初版
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
	/// ExchangeInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ExchangeInfo
	{
		public ExchangeInfo()
		{}
		#region Model
		private int _recordid;
		private int? _hotkeyid;
		private string _exchangetext;
		private string _shiftkey;
		private string _mainkey;
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
		public int? HotKeyID
		{
			set{ _hotkeyid=value;}
			get{return _hotkeyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExchangeText
		{
			set{ _exchangetext=value;}
			get{return _exchangetext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShiftKey
		{
			set{ _shiftkey=value;}
			get{return _shiftkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainKey
		{
			set{ _mainkey=value;}
			get{return _mainkey;}
		}
		#endregion Model

	}
}

