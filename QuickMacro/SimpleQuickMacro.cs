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

        #region 成员变量
        /// <summary>
        /// 是否重新编辑
        /// </summary>
        bool reEdit = false;
        /// <summary>
        /// 本地Script
        /// </summary>
        LocalScript localScript = new LocalScript();
        /// <summary>
        /// 动态执行类
        /// </summary>
        DynamicInvoke dicInvoke = new DynamicInvoke();
        /// <summary>
        /// 键盘钩子类
        /// </summary>
        KeyboardHook keyHook;
        /// <summary>
        /// 运行状态
        /// </summary>
        bool runState = false;
        /// <summary>
        /// 录制状态
        /// </summary>
        bool recordState = false;
        /// <summary>
        /// 键值对
        /// </summary>
        Dictionary<string, string> dicKeyText = new Dictionary<string, string>();
        /// <summary>
        /// 对应按键注册的热键
        /// </summary>
        Dictionary<string, int> dicHotKeyId = new Dictionary<string, int>();
        /// <summary>
        /// 热键ID
        /// </summary>
        int hotKeyId;
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
            hotKeyId = 7010;
            localScript.ReadScript();
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
            foreach (KeyValuePair<string, int> kvp in dicHotKeyId)
            {
                SystemHotKey.RegHotKey(this.Handle, kvp.Value, (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), kvp.Key.Split('+')[0]), (Keys)Enum.Parse(typeof(Keys), kvp.Key.Split('+')[1]));
            }
        }
        #endregion
        #region 捕获键盘事件
        /// <summary>
        /// 捕获键盘事件
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:    //这个是window消息定义的注册的热键消息
                    switch (m.WParam.ToString())
                    {
                        case "7001":
                            if (!runState)
                            {
                                dicInvoke.ReCompiler(txt_Details_c.Text.Trim());
                                dicInvoke.StartThread();
                                btn_Run.Text = "停止";
                                runState = true;
                            }
                            break;
                        case "7002":
                            if (runState)
                            {
                                dicInvoke.EndThread();
                                btn_Run.Text = "开始";
                                runState = false;
                            }
                            break;
                        case "7003":
                            BeginRecord();
                            break;
                        case "7004":
                            ShowAndHideForm();
                            break;
                    }
                    int msg = Convert.ToInt32(m.WParam.ToString());
                    if (msg > 7009 && msg < hotKeyId)
                    {
                        SendKeys.Send(dicKeyText[dicHotKeyId.GetKey(msg)]);
                    }
                    break;
            }
            base.WndProc(ref m);
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
                this.Visible = false;//隐藏窗体
                this.notifyIcon.Visible = true;//显示托盘图标   
            }
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        private void ShowForm()
        {
            this.Visible = true;//隐藏窗体
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;//显示托盘图标
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
            UnRegHotKeys();
            this.Close();
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
            foreach (KeyValuePair<string, int> kvp in dicHotKeyId)
            {
                SystemHotKey.UnRegHotKey(this.Handle, kvp.Value);
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
            cmb_Choose_c.DataSource = localScript.scriptList.Select(i => i.ScriptName).ToArray();
            cmb_Choose_c.SelectedItem = ConfigInfo.LastUseScript;
            txt_Details_c.Text = localScript.scriptList.Find(i => i.ScriptName == cmb_Choose_c.SelectedItem.ToString()).Details;
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
            if (!runState)
            {
                dicInvoke.ReCompiler(txt_Details_c.Text.Trim());
                dicInvoke.StartThread();
                btn_Run.Text = "停止";
                runState = true;
                ConfigInfo.LastUseScript = cmb_Choose_c.Text;
                ConfigInfo.UpdateAppConfig("LastUseScript", ConfigInfo.LastUseScript);
            }
            else
            {
                dicInvoke.EndThread();
                btn_Run.Text = "开始";
                runState = false;
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
            txt_Details_c.Text = localScript.scriptList.Find(i => i.ScriptName == cmb_Choose_c.SelectedItem.ToString()).Details;
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
                localScript.scriptList.RemoveAll(i => i.ScriptName == cmb_Choose_c.Text);
                cmb_Choose_c.DataSource = localScript.scriptList.Select(i => i.ScriptName).ToArray();
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
            ScriptClass sc;
            if ((sc = localScript.scriptList.Find(i => i.ScriptName == txt_FileName_r.Text.Trim("\r\n").Trim())) != null)
            {
                sc.Details = txt_Details_r.Text;
                localScript.WriteScript();
            }
            else
            {
                sc = new ScriptClass();
                sc.ScriptName = txt_FileName_r.Text.Trim("\r\n").Trim();
                sc.Details = txt_Details_r.Text.Trim("\r\n").Trim();
                localScript.scriptList.Add(sc);
                localScript.WriteScript();
                cmb_Choose_c.DataSource = localScript.scriptList.Select(i => i.ScriptName).ToArray();
            }
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
            ConfigInfo.Get_ConfigInfo();
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
            string[] strs = ConfigInfo.ActivateHotKey.Split('+');
            cmb_Activate_Shift.SelectedItem = strs[0];
            cmb_Activate_Main.SelectedItem = strs[1];
            strs = ConfigInfo.StopHotKey.Split('+');
            cmb_Stop_Shift.SelectedItem = strs[0];
            cmb_Stop_Main.SelectedItem = strs[1];
            strs = ConfigInfo.RecordHotKey.Split('+');
            cmb_Start_Shift.SelectedItem = strs[0];
            cmb_Start_Main.SelectedItem = strs[1];
            strs = ConfigInfo.ShowHideHotKey.Split('+');
            cmb_Resize_Shift.SelectedItem = strs[0];
            cmb_Resize_Main.SelectedItem = strs[1];
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
            ConfigInfo.UpdateAppConfig("ActivateHotKey", "None+F10");
            ConfigInfo.UpdateAppConfig("StopHotKey", "None+F11");
            ConfigInfo.UpdateAppConfig("RecordHotKey", "None+F2");
            ConfigInfo.UpdateAppConfig("ShowHideHotKey", "None+F1");
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
            dgv_KeyTextPair.DataSource = dicKeyText.ToArray();
            dgv_KeyTextPair.Columns["Key"].HeaderText = "接收按键";
            dgv_KeyTextPair.Columns["Value"].HeaderText = "输出文本";
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
            dicKeyText.Clear();
            foreach (KeyValuePair<string, int> kvp in dicHotKeyId)
            {
                SystemHotKey.UnRegHotKey(this.Handle, kvp.Value);
            }
            dicHotKeyId.Clear();
            dgv_KeyTextPair.DataSource = dicKeyText.ToArray();
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
            string selectstr = cmb_RecvKey_Shift.Text + "+" + cmb_RecvKey_Main.Text;
            if (dicKeyText.ContainsKey(selectstr))
            {
                dicKeyText[selectstr] = txt_PrintText_e.Text.Trim();
                SystemHotKey.UnRegHotKey(this.Handle, dicHotKeyId[selectstr]);
                SystemHotKey.RegisterHotKey(this.Handle, dicHotKeyId[selectstr], (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_RecvKey_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_RecvKey_Main.Text));
            }
            else
            {
                dicKeyText.Add(selectstr, txt_PrintText_e.Text.Trim());
                dicHotKeyId.Add(selectstr, hotKeyId++);
                SystemHotKey.RegisterHotKey(this.Handle, dicHotKeyId[selectstr], (EnumClass.KeyModifiers)Enum.Parse(typeof(EnumClass.KeyModifiers), cmb_RecvKey_Shift.Text), (Keys)Enum.Parse(typeof(Keys), cmb_RecvKey_Main.Text));
            }

            dgv_KeyTextPair.DataSource = dicKeyText.ToArray();
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
            string selectStr = dgv_KeyTextPair.SelectedRows[0].Cells[0].Value.ToString();
            dicKeyText.Remove(selectStr);
            SystemHotKey.UnRegHotKey(this.Handle, dicHotKeyId[selectStr]);
            dicHotKeyId.Remove(selectStr);
            dgv_KeyTextPair.DataSource = dicKeyText.ToArray();
            dgv_KeyTextPair.Columns["Key"].HeaderText = "接收按键";
            dgv_KeyTextPair.Columns["Value"].HeaderText = "输出文本";
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
            string[] strarr = dgv_KeyTextPair.Rows[e.RowIndex].Cells[0].Value.ToString().Split('+');
            cmb_RecvKey_Shift.Text = strarr[0];
            cmb_RecvKey_Main.Text = strarr[1];
            txt_PrintText_e.Text = dgv_KeyTextPair.Rows[e.RowIndex].Cells[1].Value.ToString();
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
