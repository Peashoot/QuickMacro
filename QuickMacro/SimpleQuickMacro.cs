using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuickMacro
{
    public partial class SimpleQuickMacro : Form
    {
        public SimpleQuickMacro()
        {
            InitializeComponent();
        }
        ///// <summary>
        ///// 修改窗体的类名
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams createParams = base.CreateParams;
        //        createParams.ClassName = "SimpleQuickMacrByW";
        //        return createParams;
        //    }
        //}

        #region 成员变量
        /// <summary>
        /// 系统参数操作类
        /// </summary>
        BLL.SysParamInfo sysBll = new BLL.SysParamInfo();
        /// <summary>
        /// 脚本操作类
        /// </summary>
        BLL.ScriptInfo scriptBll = new BLL.ScriptInfo();
        /// <summary>
        /// 替换操作类
        /// </summary>
        BLL.ExchangeInfo exchangeBll = new BLL.ExchangeInfo();
        /// <summary>
        /// 是否重新编辑
        /// </summary>
        bool reEdit = false;
        /// <summary>
        /// 脚本列表
        /// </summary>
        List<Model.ScriptInfo> scriptList;
        /// <summary>
        /// 动态执行类
        /// </summary>
        DynamicInvoke dicInvoke
        {
            get { return dicInvoke; }
            set
            {
                if (dicInvoke != null && dicInvoke.threadRunning)
                {
                    return;
                }
                dicInvoke = value;
            }
        }
        /// <summary>
        /// 键盘钩子类
        /// </summary>
        KeyboardHook keyHook;
        /// <summary>
        /// 录制状态
        /// </summary>
        bool recordState = false;
        /// <summary>
        /// 文本替换列表
        /// </summary>
        List<Model.ExchangeInfo> exchangeList;
        /// <summary>
        /// 文本替换对象 
        /// </summary>
        Model.ExchangeInfo exchangeModel;
        /// <summary>
        /// 热键ID
        /// </summary>
        int maxHotKeyId;
        /// <summary>
        /// 自定义事件ID
        /// </summary>
        public const int WM_USER = 0x0400;
        /// <summary>
        /// 窗体是否加载
        /// </summary>
        bool isLoaded = false;
        #endregion
        #region 总的
        #region 窗体加载
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleQuickMacro_Load(object sender, EventArgs e)
        {
            isLoaded = true;
            scriptList = scriptBll.GetModelList("");
            initPage_Set();
            initPage_Choose();
            RegHotKeys();
        }
        #endregion
        #region 注册热键
        /// <summary>
        /// 注册热键
        /// </summary>
        private void RegHotKeys()
        {
            UnRegHotKeys();
            SystemHotKey.RegHotKey(this.Handle, 7001, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_Activate_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_Activate_Main.Text));
            SystemHotKey.RegHotKey(this.Handle, 7002, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_Stop_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_Stop_Main.Text));
            SystemHotKey.RegHotKey(this.Handle, 7003, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_Start_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_Start_Main.Text));
            SystemHotKey.RegHotKey(this.Handle, 7004, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_Resize_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_Resize_Main.Text));
            foreach (Model.ExchangeInfo model in exchangeList)
            {
                SystemHotKey.RegHotKey(this.Handle, model.HotKeyID.Value, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), model.ShiftKey), (Keys)Enum.Parse(typeof(Keys), model.MainKey));
            }
        }
        #endregion
        #region 处理Windows消息
        /// <summary>
        /// 处理热键消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (WM_USER + 1):
                    ShowForm();
                    break;
                case 0x0312:    //这个是window消息定义的注册的热键消息
                    switch (m.WParam.ToString())
                    {
                        case "7001":
                            if (!dicInvoke.threadRunning)
                            {
                                dicInvoke.ReCompiler(txt_Details_c.Text.Trim());
                                dicInvoke.StartThread();
                                btn_Run.Text = "停止";
                            }
                            break;
                        case "7002":
                            if (dicInvoke.threadRunning)
                            {
                                dicInvoke.EndThread();
                                btn_Run.Text = "开始";
                            }
                            break;
                        case "7003":
                            BeginRecord();
                            break;
                        case "7004":
                            ShowAndHideForm();
                            break;
                    }
                    int hotkeyId = Convert.ToInt32(m.WParam.ToString());
                    if (hotkeyId > 7009 && hotkeyId < maxHotKeyId)
                    {
                        try
                        {
                            SendKeys.Send(exchangeList.Find(i => i.HotKeyID == hotkeyId).ExchangeText);
                        }
                        catch { }
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// 处理自定义消息
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case (WM_USER + 1):
                    ShowForm();
                    break;
                default:
                    base.DefWndProc(ref m);//一定要调用基类函数，以便系统处理其它消息。
                    break;
            }
        }
        #endregion
        #region 选项卡选择变更
        /// <summary>
        /// 选项卡选择变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MainTab.SelectedTab.Name)
            {
                case "page_Choose":
                    initPage_Choose();
                    break;
                case "page_Record":
                    initPage_Record();
                    break;
                case "page_Set":
                    initPage_Set();
                    break;
                case "page_Exchange":
                    initPage_Exchange();
                    break;
            }
        }
        #endregion
        #region 显示或隐藏窗体
        /// <summary>
        /// 隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleQuickMacro_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();//隐藏窗体
                this.notifyIcon.Visible = true;//显示托盘图标   
            }
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        private void ShowForm()
        {
            this.Show();//隐藏窗体
            this.notifyIcon.Visible = false;//显示托盘图标
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        /// <summary>
        /// 隐藏窗体
        /// </summary>
        private void HideForm()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 显示或隐藏窗体
        /// </summary>
        private void ShowAndHideForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowForm();
            }
            else
            {
                HideForm();
            }
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MaxSize_Click(object sender, EventArgs e)
        {
            ShowForm();
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
        #endregion
        #region 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                UnRegHotKeys();
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleQuickMacro_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnRegHotKeys();
        }
        #endregion
        #region 注销热键
        /// <summary>
        /// 注销热键
        /// </summary>
        private void UnRegHotKeys()
        {
            SystemHotKey.UnRegHotKey(this.Handle, 7001);
            SystemHotKey.UnRegHotKey(this.Handle, 7002);
            SystemHotKey.UnRegHotKey(this.Handle, 7003);
            SystemHotKey.UnRegHotKey(this.Handle, 7004);
            foreach (Model.ExchangeInfo model in exchangeList)
            {
                SystemHotKey.UnRegHotKey(this.Handle, model.HotKeyID.Value);
            }
        }
        #endregion
        #endregion
        #region 选择选项卡
        #region 选项卡初始化
        /// <summary>
        /// 选择选项卡初始化
        /// </summary>
        private void initPage_Choose()
        {
            dicInvoke = new DynamicInvoke();
            cmb_Choose_c.DataSource = scriptList.Select(i => i.ScriptName).ToArray();
            cmb_Choose_c.SelectedItem = sysBll.GetModelList(" ItemName='LastUseScript'")[0].ItemValue1;
            txt_Details_c.Text = scriptList.Find(i => i.ScriptName == cmb_Choose_c.SelectedItem.ToString()).ScriptDetails;
        }
        #endregion
        #region 运行停止
        /// <summary>
        /// 运行停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (!dicInvoke.threadRunning)
            {
                dicInvoke.ReCompiler(txt_Details_c.Text.Trim());
                dicInvoke.StartThread();
                btn_Run.Text = "停止";
                sysBll.Update("LastUseScript", cmb_Choose_c.Text, "");
            }
            else
            {
                dicInvoke.EndThread();
                btn_Run.Text = "开始";
            }
        }
        #endregion
        #region 重新编辑
        /// <summary>
        /// 重新编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_c_Click(object sender, EventArgs e)
        {
            reEdit = true;
            MainTab.SelectedTab = page_Record;
            reEdit = false;
        }
        #endregion
        #region 选择不同的脚本
        /// <summary>
        /// 选择不同的脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Choose_c_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Details_c.Text = scriptList.Find(i => i.ScriptName == cmb_Choose_c.SelectedItem.ToString()).ScriptDetails;
        }
        #endregion
        #region 显示脚本构成C#的代码
        /// <summary>
        /// 显示脚本构成的C#代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CodeCSharp_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dicInvoke.GenerateCode(txt_Details_c.Text.Trim("\r\n").Trim()));
            MessageBox.Show("C#代码已复制到剪切板中。");
        }
        #endregion
        #region 删除脚本
        /// <summary>
        /// 删除脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_c_Click(object sender, EventArgs e)
        {
            if (cmb_Choose_c.Text != "Default")
            {
                scriptList.RemoveAll(i => i.ScriptName == cmb_Choose_c.Text);
                cmb_Choose_c.DataSource = scriptList.Select(i => i.ScriptName).ToArray();
                cmb_Choose_c.SelectedItem = "Default";
            }
            else
            {
                MessageBox.Show("默认脚本不能删除");
            }
        }
        #endregion
        #endregion
        #region 录制选项卡
        #region 录制选项卡初始化
        /// <summary>
        /// 录制选项卡初始化
        /// </summary>
        private void initPage_Record()
        {
            keyHook = new KeyboardHook(txt_Details_r);
            if (reEdit)
            {
                txt_FileName_r.Text = cmb_Choose_c.Text;
                txt_Details_r.Text = txt_Details_c.Text;
            }
            else
            {
                txt_FileName_r.Text = "新建脚本";
                txt_Details_r.Clear();
            }
        }
        #endregion
        #region 保存脚本
        /// <summary>
        /// 保存脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_r_Click(object sender, EventArgs e)
        {
            if (!new DynamicInvoke().ReCompiler(txt_Details_r.Text.Trim("\r\n").Trim()))
                return;
            Model.ScriptInfo sc;
            if ((sc = scriptList.Find(i => i.ScriptName == txt_FileName_r.Text.Trim("\r\n").Trim())) != null)
            {
                sc.ScriptDetails = txt_Details_r.Text;
                scriptBll.Update(sc);
            }
            else
            {
                sc = new Model.ScriptInfo();
                sc.ScriptName = txt_FileName_r.Text.Trim("\r\n").Trim();
                sc.ScriptDetails = txt_Details_r.Text.Trim("\r\n").Trim();
                scriptList.Add(sc);
                scriptBll.Add(sc);
                cmb_Choose_c.DataSource = scriptList.Select(i => i.ScriptName).ToArray();
            }
            MessageBox.Show("保存完毕");
        }
        #endregion
        #region 录制
        /// <summary>
        /// 录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Record_r_Click(object sender, EventArgs e)
        {
            BeginRecord();
        }
        /// <summary>
        /// 录制
        /// </summary>
        private void BeginRecord()
        {
            if (!recordState)
            {
                UnRegHotKeys();
                keyHook.Start();
                btn_Record_r.Text = "停止";
                recordState = true;
            }
            else
            {
                keyHook.Stop();
                btn_Record_r.Text = "录制";
                recordState = false;
                RegHotKeys();
            }
        }
        #endregion
        #region 编译
        /// <summary>
        /// 编译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Compiler_Click(object sender, EventArgs e)
        {
            new DynamicInvoke().ReCompiler(txt_Details_r.Text.Trim("\r\n").Trim());
        }
        #endregion
        #region 显示脚本构成的Java代码
        /// <summary>
        /// 显示脚本构成的Java代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Code_Java_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dicInvoke.GenerateCodeJava(txt_Details_c.Text.Trim("\r\n").Trim()));
            MessageBox.Show("Java代码已复制到剪切板中。");
        }
        #endregion
        #endregion
        #region 设置选项卡
        #region 设置选项卡初始化
        /// <summary>
        /// 设置选项卡初始化
        /// </summary>
        private void initPage_Set()
        {
            foreach (Control c in page_Set.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    if (c.Tag.ToString() == "shift")
                    {
                        ((ComboBox)c).DataSource = System.Enum.GetNames(typeof(EnumClass.KeyModifiers));
                    }
                    else if (c.Tag.ToString() == "main")
                    {
                        ((ComboBox)c).DataSource = System.Enum.GetNames(typeof(EnumClass.KeyMain));
                    }
                }
            }
            Model.SysParamInfo model = sysBll.GetModelList("  ItemName='ActivateHotKey'")[0];
            cmb_Activate_Shift.SelectedItem = model.ItemValue1;
            cmb_Activate_Main.SelectedItem = model.ItemValue2;
            model = sysBll.GetModelList("  ItemName='StopHotKey'")[0];
            cmb_Stop_Shift.SelectedItem = model.ItemValue1;
            cmb_Stop_Main.SelectedItem = model.ItemValue2;
            model = sysBll.GetModelList("  ItemName='RecordHotKey'")[0];
            cmb_Start_Shift.SelectedItem = model.ItemValue1;
            cmb_Start_Main.SelectedItem = model.ItemValue2;
            model = sysBll.GetModelList("  ItemName='ShowHideHotKey'")[0];
            cmb_Resize_Shift.SelectedItem = model.ItemValue1;
            cmb_Resize_Main.SelectedItem = model.ItemValue2;
        }
        #endregion
        #region 重置参数
        /// <summary>
        /// 重置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_s_Click(object sender, EventArgs e)
        {
            sysBll.Update("ActivateHotKey", "None", "F10");
            sysBll.Update("StopHotKey", "None", "F11");
            sysBll.Update("RecordHotKey", "None", "F2");
            sysBll.Update("ShowHideHotKey", "None", "F1");
            cmb_Activate_Shift.SelectedItem = "None";
            cmb_Activate_Main.SelectedItem = "F10";
            cmb_Stop_Shift.SelectedItem = "None";
            cmb_Stop_Main.SelectedItem = "F11";
            cmb_Start_Shift.SelectedItem = "None";
            cmb_Start_Main.SelectedItem = "F2";
            cmb_Resize_Shift.SelectedItem = "None";
            cmb_Resize_Main.SelectedItem = "F1";
            RegHotKeys();
        }
        #endregion
        #endregion
        #region 替换选项卡
        #region 初始化替换选项卡
        /// <summary>
        /// 初始化替换选项卡
        /// </summary>
        private void initPage_Exchange()
        {
            BLL.ExchangeInfo exchangeBll = new BLL.ExchangeInfo();
            exchangeList = exchangeBll.GetModelList(" 1=1 ORDER BY HotKeyID DESC");
            if (exchangeList != null && exchangeList.Count > 0)
            {
                maxHotKeyId = exchangeList[0].HotKeyID.Value;
                dgv_KeyTextPair.DataSource = exchangeList.ToArray();
                dgv_KeyTextPair.Columns["Key"].HeaderText = "接收按键";
                dgv_KeyTextPair.Columns["Value"].HeaderText = "输出文本";
            }
            txt_PrintText_e.Clear();
            cmb_RecvKey_Shift.DataSource = System.Enum.GetNames(typeof(EnumClass.KeyModifiers));
            cmb_RecvKey_Main.DataSource = System.Enum.GetNames(typeof(EnumClass.KeyMain));
            cmb_RecvKey_Shift.SelectedIndex = 0;
            cmb_RecvKey_Main.SelectedIndex = 0;
        }
        #endregion
        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_e_Click(object sender, EventArgs e)
        {
            exchangeList.Clear();
            foreach (Model.ExchangeInfo model in exchangeList)
            {
                SystemHotKey.UnRegHotKey(this.Handle, model.HotKeyID.Value);
            }
        }
        #endregion
        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_e_Click(object sender, EventArgs e)
        {
            if (cmb_RecvKey_Shift.Text == "None" && cmb_RecvKey_Main.Text == "None")
            {
                return;
            }
            if (exchangeModel != null)
            {
                exchangeModel.ExchangeText = txt_PrintText_e.Text;
                exchangeModel.ShiftKey = cmb_RecvKey_Shift.Text;
                exchangeModel.MainKey = cmb_RecvKey_Main.Text;
                exchangeList.RemoveAll(i => i.RecordID == exchangeModel.RecordID);
                exchangeList.Add(exchangeModel);
                exchangeBll.Update(exchangeModel);
                SystemHotKey.UnRegHotKey(this.Handle, exchangeModel.HotKeyID.Value);
            }
            else
            {
                exchangeModel = new Model.ExchangeInfo();
                for (int i = 7010; i < 10000; i++)
                {
                    if (!exchangeList.Select(m => m.HotKeyID).Contains(i))
                    {
                        exchangeModel.HotKeyID = i;
                        break;
                    }
                }
                exchangeModel.ExchangeText = txt_PrintText_e.Text;
                exchangeModel.ShiftKey = cmb_RecvKey_Shift.Text;
                exchangeModel.MainKey = cmb_RecvKey_Main.Text;
                exchangeList.Add(exchangeModel);
                exchangeBll.Add(exchangeModel);
            }
            if (!SystemHotKey.RegisterHotKey(this.Handle, exchangeModel.HotKeyID.Value, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), exchangeModel.ShiftKey), (Keys)Enum.Parse(typeof(Keys), exchangeModel.MainKey)))
            {
                MessageBox.Show("热键注册失败");
            }
            dgv_KeyTextPair.DataSource = exchangeList.ToArray();
            dgv_KeyTextPair.Columns["Key"].HeaderText = "接收按键";
            dgv_KeyTextPair.Columns["Value"].HeaderText = "输出文本";
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_e_Click(object sender, EventArgs e)
        {
            if (dgv_KeyTextPair.SelectedRows.Count < 0)
            {
                return;
            }
            exchangeModel = GetDataRowModel(dgv_KeyTextPair.SelectedRows[0]);
            exchangeList.RemoveAll(i => i.RecordID == exchangeModel.RecordID);
            SystemHotKey.UnRegHotKey(this.Handle, exchangeModel.HotKeyID.Value);
            exchangeList.RemoveAll(i => i.RecordID == exchangeModel.RecordID);
        }
        #endregion
        #region 单元格点击
        /// <summary>
        /// 单元格点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_KeyTextPair_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            exchangeModel = GetDataRowModel(dgv_KeyTextPair.Rows[e.RowIndex]);
            cmb_RecvKey_Shift.Text = exchangeModel.ShiftKey;
            cmb_RecvKey_Main.Text = exchangeModel.MainKey;
            txt_PrintText_e.Text = exchangeModel.ExchangeText;
        }
        #endregion
        #region 列表中的某一行转换成Model
        /// <summary>
        /// 列表中的某一行转换成Model
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.ExchangeInfo GetDataRowModel(DataGridViewRow dr)
        {
            Model.ExchangeInfo retmodel = new Model.ExchangeInfo();
            retmodel.RecordID = int.Parse(dr.Cells["RecordID"].Value.ToString());
            retmodel.HotKeyID = int.Parse(dr.Cells["HotKeyID"].Value.ToString());
            retmodel.ShiftKey = dr.Cells["ShiftKey"].Value.ToString();
            retmodel.MainKey = dr.Cells["MainKey"].Value.ToString();
            retmodel.ExchangeText = dr.Cells["ExchangeText"].Value.ToString();
            return retmodel;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dicInvoke.GenerateCodeCPlus(txt_Details_c.Text.Trim("\r\n").Trim()));
            MessageBox.Show("C++代码已复制到剪切板中。");
        }
        #endregion
    }
}
