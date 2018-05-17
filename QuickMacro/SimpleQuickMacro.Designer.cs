namespace QuickMacro
{
    partial class SimpleQuickMacro
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleQuickMacro));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.page_Choose = new System.Windows.Forms.TabPage();
            this.btn_Run = new System.Windows.Forms.Button();
            this.txt_Details_c = new System.Windows.Forms.TextBox();
            this.btn_Quit_c = new System.Windows.Forms.Button();
            this.btn_CodeCSharp = new System.Windows.Forms.Button();
            this.btn_Delete_c = new System.Windows.Forms.Button();
            this.btn_Edit_c = new System.Windows.Forms.Button();
            this.cmb_Choose_c = new System.Windows.Forms.ComboBox();
            this.page_Record = new System.Windows.Forms.TabPage();
            this.btn_Compiler = new System.Windows.Forms.Button();
            this.txt_Details_r = new System.Windows.Forms.TextBox();
            this.txt_FileName_r = new System.Windows.Forms.TextBox();
            this.btn_Quit_r = new System.Windows.Forms.Button();
            this.btn_Code_Java = new System.Windows.Forms.Button();
            this.btn_Record_r = new System.Windows.Forms.Button();
            this.btn_Save_r = new System.Windows.Forms.Button();
            this.page_Set = new System.Windows.Forms.TabPage();
            this.btn_Quit_s = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Reset_s = new System.Windows.Forms.Button();
            this.btn_Save_s = new System.Windows.Forms.Button();
            this.cmb_Resize_Main = new System.Windows.Forms.ComboBox();
            this.cmb_Start_Main = new System.Windows.Forms.ComboBox();
            this.cmb_Stop_Main = new System.Windows.Forms.ComboBox();
            this.cmb_Activate_Main = new System.Windows.Forms.ComboBox();
            this.cmb_Resize_Shift = new System.Windows.Forms.ComboBox();
            this.cmb_Start_Shift = new System.Windows.Forms.ComboBox();
            this.cmb_Stop_Shift = new System.Windows.Forms.ComboBox();
            this.cmb_Activate_Shift = new System.Windows.Forms.ComboBox();
            this.lab_Resize = new System.Windows.Forms.Label();
            this.lab_Start = new System.Windows.Forms.Label();
            this.lab_Stop = new System.Windows.Forms.Label();
            this.lab_Activate = new System.Windows.Forms.Label();
            this.page_Exchange = new System.Windows.Forms.TabPage();
            this.btn_Quit_e = new System.Windows.Forms.Button();
            this.btn_Delete_e = new System.Windows.Forms.Button();
            this.btn_Save_e = new System.Windows.Forms.Button();
            this.btn_Clear_e = new System.Windows.Forms.Button();
            this.txt_PrintText_e = new System.Windows.Forms.TextBox();
            this.cmb_RecvKey_Main = new System.Windows.Forms.ComboBox();
            this.cmb_RecvKey_Shift = new System.Windows.Forms.ComboBox();
            this.lbl_PrintText = new System.Windows.Forms.Label();
            this.lbl_RecvKey = new System.Windows.Forms.Label();
            this.dgv_KeyTextPair = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_MaxSize = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Quit_m = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTab.SuspendLayout();
            this.page_Choose.SuspendLayout();
            this.page_Record.SuspendLayout();
            this.page_Set.SuspendLayout();
            this.page_Exchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeyTextPair)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.page_Choose);
            this.MainTab.Controls.Add(this.page_Record);
            this.MainTab.Controls.Add(this.page_Set);
            this.MainTab.Controls.Add(this.page_Exchange);
            this.MainTab.Location = new System.Drawing.Point(4, 5);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(212, 194);
            this.MainTab.TabIndex = 0;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // page_Choose
            // 
            this.page_Choose.Controls.Add(this.btn_Run);
            this.page_Choose.Controls.Add(this.txt_Details_c);
            this.page_Choose.Controls.Add(this.btn_Quit_c);
            this.page_Choose.Controls.Add(this.btn_CodeCSharp);
            this.page_Choose.Controls.Add(this.btn_Delete_c);
            this.page_Choose.Controls.Add(this.btn_Edit_c);
            this.page_Choose.Controls.Add(this.cmb_Choose_c);
            this.page_Choose.Location = new System.Drawing.Point(4, 22);
            this.page_Choose.Name = "page_Choose";
            this.page_Choose.Padding = new System.Windows.Forms.Padding(3);
            this.page_Choose.Size = new System.Drawing.Size(204, 168);
            this.page_Choose.TabIndex = 0;
            this.page_Choose.Text = "选择";
            this.page_Choose.UseVisualStyleBackColor = true;
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(155, 6);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(43, 21);
            this.btn_Run.TabIndex = 7;
            this.btn_Run.Text = "运行";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // txt_Details_c
            // 
            this.txt_Details_c.Location = new System.Drawing.Point(6, 32);
            this.txt_Details_c.Multiline = true;
            this.txt_Details_c.Name = "txt_Details_c";
            this.txt_Details_c.ReadOnly = true;
            this.txt_Details_c.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Details_c.Size = new System.Drawing.Size(192, 103);
            this.txt_Details_c.TabIndex = 1;
            // 
            // btn_Quit_c
            // 
            this.btn_Quit_c.Location = new System.Drawing.Point(153, 141);
            this.btn_Quit_c.Name = "btn_Quit_c";
            this.btn_Quit_c.Size = new System.Drawing.Size(43, 21);
            this.btn_Quit_c.TabIndex = 4;
            this.btn_Quit_c.Text = "退出";
            this.btn_Quit_c.UseVisualStyleBackColor = true;
            this.btn_Quit_c.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_CodeCSharp
            // 
            this.btn_CodeCSharp.Location = new System.Drawing.Point(104, 141);
            this.btn_CodeCSharp.Name = "btn_CodeCSharp";
            this.btn_CodeCSharp.Size = new System.Drawing.Size(43, 21);
            this.btn_CodeCSharp.TabIndex = 3;
            this.btn_CodeCSharp.Text = "代码";
            this.btn_CodeCSharp.UseVisualStyleBackColor = true;
            this.btn_CodeCSharp.Click += new System.EventHandler(this.btn_CodeCSharp_Click);
            // 
            // btn_Delete_c
            // 
            this.btn_Delete_c.Location = new System.Drawing.Point(55, 141);
            this.btn_Delete_c.Name = "btn_Delete_c";
            this.btn_Delete_c.Size = new System.Drawing.Size(43, 21);
            this.btn_Delete_c.TabIndex = 3;
            this.btn_Delete_c.Text = "删除";
            this.btn_Delete_c.UseVisualStyleBackColor = true;
            this.btn_Delete_c.Click += new System.EventHandler(this.btn_Delete_c_Click);
            // 
            // btn_Edit_c
            // 
            this.btn_Edit_c.Location = new System.Drawing.Point(6, 141);
            this.btn_Edit_c.Name = "btn_Edit_c";
            this.btn_Edit_c.Size = new System.Drawing.Size(43, 21);
            this.btn_Edit_c.TabIndex = 2;
            this.btn_Edit_c.Text = "编辑";
            this.btn_Edit_c.UseVisualStyleBackColor = true;
            this.btn_Edit_c.Click += new System.EventHandler(this.btn_Edit_c_Click);
            // 
            // cmb_Choose_c
            // 
            this.cmb_Choose_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Choose_c.FormattingEnabled = true;
            this.cmb_Choose_c.Location = new System.Drawing.Point(6, 6);
            this.cmb_Choose_c.Name = "cmb_Choose_c";
            this.cmb_Choose_c.Size = new System.Drawing.Size(148, 20);
            this.cmb_Choose_c.TabIndex = 0;
            this.cmb_Choose_c.Tag = "select";
            this.cmb_Choose_c.SelectedIndexChanged += new System.EventHandler(this.cmb_Choose_c_SelectedIndexChanged);
            // 
            // page_Record
            // 
            this.page_Record.Controls.Add(this.btn_Compiler);
            this.page_Record.Controls.Add(this.txt_Details_r);
            this.page_Record.Controls.Add(this.txt_FileName_r);
            this.page_Record.Controls.Add(this.btn_Quit_r);
            this.page_Record.Controls.Add(this.btn_Code_Java);
            this.page_Record.Controls.Add(this.btn_Record_r);
            this.page_Record.Controls.Add(this.btn_Save_r);
            this.page_Record.Location = new System.Drawing.Point(4, 22);
            this.page_Record.Name = "page_Record";
            this.page_Record.Padding = new System.Windows.Forms.Padding(3);
            this.page_Record.Size = new System.Drawing.Size(204, 168);
            this.page_Record.TabIndex = 1;
            this.page_Record.Text = "录制";
            this.page_Record.UseVisualStyleBackColor = true;
            // 
            // btn_Compiler
            // 
            this.btn_Compiler.Location = new System.Drawing.Point(155, 6);
            this.btn_Compiler.Name = "btn_Compiler";
            this.btn_Compiler.Size = new System.Drawing.Size(43, 21);
            this.btn_Compiler.TabIndex = 6;
            this.btn_Compiler.Text = "编译";
            this.btn_Compiler.UseVisualStyleBackColor = true;
            this.btn_Compiler.Click += new System.EventHandler(this.btn_Compiler_Click);
            // 
            // txt_Details_r
            // 
            this.txt_Details_r.Location = new System.Drawing.Point(6, 32);
            this.txt_Details_r.Multiline = true;
            this.txt_Details_r.Name = "txt_Details_r";
            this.txt_Details_r.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Details_r.Size = new System.Drawing.Size(192, 103);
            this.txt_Details_r.TabIndex = 7;
            // 
            // txt_FileName_r
            // 
            this.txt_FileName_r.Location = new System.Drawing.Point(6, 6);
            this.txt_FileName_r.Name = "txt_FileName_r";
            this.txt_FileName_r.Size = new System.Drawing.Size(148, 21);
            this.txt_FileName_r.TabIndex = 5;
            // 
            // btn_Quit_r
            // 
            this.btn_Quit_r.Location = new System.Drawing.Point(153, 141);
            this.btn_Quit_r.Name = "btn_Quit_r";
            this.btn_Quit_r.Size = new System.Drawing.Size(43, 21);
            this.btn_Quit_r.TabIndex = 10;
            this.btn_Quit_r.Text = "退出";
            this.btn_Quit_r.UseVisualStyleBackColor = true;
            this.btn_Quit_r.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Code_Java
            // 
            this.btn_Code_Java.Location = new System.Drawing.Point(104, 141);
            this.btn_Code_Java.Name = "btn_Code_Java";
            this.btn_Code_Java.Size = new System.Drawing.Size(43, 21);
            this.btn_Code_Java.TabIndex = 9;
            this.btn_Code_Java.Text = "代码";
            this.btn_Code_Java.UseVisualStyleBackColor = true;
            this.btn_Code_Java.Click += new System.EventHandler(this.btn_Code_Java_Click);
            // 
            // btn_Record_r
            // 
            this.btn_Record_r.Location = new System.Drawing.Point(6, 141);
            this.btn_Record_r.Name = "btn_Record_r";
            this.btn_Record_r.Size = new System.Drawing.Size(43, 21);
            this.btn_Record_r.TabIndex = 9;
            this.btn_Record_r.Text = "录制";
            this.btn_Record_r.UseVisualStyleBackColor = true;
            this.btn_Record_r.Click += new System.EventHandler(this.btn_Record_r_Click);
            // 
            // btn_Save_r
            // 
            this.btn_Save_r.Location = new System.Drawing.Point(55, 141);
            this.btn_Save_r.Name = "btn_Save_r";
            this.btn_Save_r.Size = new System.Drawing.Size(43, 21);
            this.btn_Save_r.TabIndex = 8;
            this.btn_Save_r.Text = "保存";
            this.btn_Save_r.UseVisualStyleBackColor = true;
            this.btn_Save_r.Click += new System.EventHandler(this.btn_Save_r_Click);
            // 
            // page_Set
            // 
            this.page_Set.Controls.Add(this.btn_Quit_s);
            this.page_Set.Controls.Add(this.button2);
            this.page_Set.Controls.Add(this.btn_Reset_s);
            this.page_Set.Controls.Add(this.btn_Save_s);
            this.page_Set.Controls.Add(this.cmb_Resize_Main);
            this.page_Set.Controls.Add(this.cmb_Start_Main);
            this.page_Set.Controls.Add(this.cmb_Stop_Main);
            this.page_Set.Controls.Add(this.cmb_Activate_Main);
            this.page_Set.Controls.Add(this.cmb_Resize_Shift);
            this.page_Set.Controls.Add(this.cmb_Start_Shift);
            this.page_Set.Controls.Add(this.cmb_Stop_Shift);
            this.page_Set.Controls.Add(this.cmb_Activate_Shift);
            this.page_Set.Controls.Add(this.lab_Resize);
            this.page_Set.Controls.Add(this.lab_Start);
            this.page_Set.Controls.Add(this.lab_Stop);
            this.page_Set.Controls.Add(this.lab_Activate);
            this.page_Set.Location = new System.Drawing.Point(4, 22);
            this.page_Set.Name = "page_Set";
            this.page_Set.Padding = new System.Windows.Forms.Padding(3);
            this.page_Set.Size = new System.Drawing.Size(204, 168);
            this.page_Set.TabIndex = 2;
            this.page_Set.Text = "设置";
            this.page_Set.UseVisualStyleBackColor = true;
            // 
            // btn_Quit_s
            // 
            this.btn_Quit_s.Location = new System.Drawing.Point(153, 141);
            this.btn_Quit_s.Name = "btn_Quit_s";
            this.btn_Quit_s.Size = new System.Drawing.Size(43, 21);
            this.btn_Quit_s.TabIndex = 21;
            this.btn_Quit_s.Text = "退出";
            this.btn_Quit_s.UseVisualStyleBackColor = true;
            this.btn_Quit_s.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 21);
            this.button2.TabIndex = 20;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Reset_s
            // 
            this.btn_Reset_s.Location = new System.Drawing.Point(55, 141);
            this.btn_Reset_s.Name = "btn_Reset_s";
            this.btn_Reset_s.Size = new System.Drawing.Size(43, 21);
            this.btn_Reset_s.TabIndex = 20;
            this.btn_Reset_s.Text = "重置";
            this.btn_Reset_s.UseVisualStyleBackColor = true;
            this.btn_Reset_s.Click += new System.EventHandler(this.btn_Reset_s_Click);
            // 
            // btn_Save_s
            // 
            this.btn_Save_s.Location = new System.Drawing.Point(6, 141);
            this.btn_Save_s.Name = "btn_Save_s";
            this.btn_Save_s.Size = new System.Drawing.Size(43, 21);
            this.btn_Save_s.TabIndex = 19;
            this.btn_Save_s.Text = "保存";
            this.btn_Save_s.UseVisualStyleBackColor = true;
            // 
            // cmb_Resize_Main
            // 
            this.cmb_Resize_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Resize_Main.FormattingEnabled = true;
            this.cmb_Resize_Main.Location = new System.Drawing.Point(137, 105);
            this.cmb_Resize_Main.Name = "cmb_Resize_Main";
            this.cmb_Resize_Main.Size = new System.Drawing.Size(61, 20);
            this.cmb_Resize_Main.TabIndex = 18;
            this.cmb_Resize_Main.Tag = "main";
            // 
            // cmb_Start_Main
            // 
            this.cmb_Start_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Start_Main.FormattingEnabled = true;
            this.cmb_Start_Main.Location = new System.Drawing.Point(137, 73);
            this.cmb_Start_Main.Name = "cmb_Start_Main";
            this.cmb_Start_Main.Size = new System.Drawing.Size(61, 20);
            this.cmb_Start_Main.TabIndex = 16;
            this.cmb_Start_Main.Tag = "main";
            // 
            // cmb_Stop_Main
            // 
            this.cmb_Stop_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Stop_Main.FormattingEnabled = true;
            this.cmb_Stop_Main.Location = new System.Drawing.Point(137, 41);
            this.cmb_Stop_Main.Name = "cmb_Stop_Main";
            this.cmb_Stop_Main.Size = new System.Drawing.Size(61, 20);
            this.cmb_Stop_Main.TabIndex = 14;
            this.cmb_Stop_Main.Tag = "main";
            // 
            // cmb_Activate_Main
            // 
            this.cmb_Activate_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Activate_Main.FormattingEnabled = true;
            this.cmb_Activate_Main.Location = new System.Drawing.Point(137, 9);
            this.cmb_Activate_Main.Name = "cmb_Activate_Main";
            this.cmb_Activate_Main.Size = new System.Drawing.Size(61, 20);
            this.cmb_Activate_Main.TabIndex = 12;
            this.cmb_Activate_Main.Tag = "main";
            // 
            // cmb_Resize_Shift
            // 
            this.cmb_Resize_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Resize_Shift.FormattingEnabled = true;
            this.cmb_Resize_Shift.Location = new System.Drawing.Point(70, 105);
            this.cmb_Resize_Shift.Name = "cmb_Resize_Shift";
            this.cmb_Resize_Shift.Size = new System.Drawing.Size(60, 20);
            this.cmb_Resize_Shift.TabIndex = 17;
            this.cmb_Resize_Shift.Tag = "shift";
            // 
            // cmb_Start_Shift
            // 
            this.cmb_Start_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Start_Shift.FormattingEnabled = true;
            this.cmb_Start_Shift.Location = new System.Drawing.Point(70, 73);
            this.cmb_Start_Shift.Name = "cmb_Start_Shift";
            this.cmb_Start_Shift.Size = new System.Drawing.Size(60, 20);
            this.cmb_Start_Shift.TabIndex = 15;
            this.cmb_Start_Shift.Tag = "shift";
            // 
            // cmb_Stop_Shift
            // 
            this.cmb_Stop_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Stop_Shift.FormattingEnabled = true;
            this.cmb_Stop_Shift.Location = new System.Drawing.Point(70, 41);
            this.cmb_Stop_Shift.Name = "cmb_Stop_Shift";
            this.cmb_Stop_Shift.Size = new System.Drawing.Size(60, 20);
            this.cmb_Stop_Shift.TabIndex = 13;
            this.cmb_Stop_Shift.Tag = "shift";
            // 
            // cmb_Activate_Shift
            // 
            this.cmb_Activate_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Activate_Shift.FormattingEnabled = true;
            this.cmb_Activate_Shift.Location = new System.Drawing.Point(70, 9);
            this.cmb_Activate_Shift.Name = "cmb_Activate_Shift";
            this.cmb_Activate_Shift.Size = new System.Drawing.Size(60, 20);
            this.cmb_Activate_Shift.TabIndex = 11;
            this.cmb_Activate_Shift.Tag = "shift";
            // 
            // lab_Resize
            // 
            this.lab_Resize.AutoSize = true;
            this.lab_Resize.Location = new System.Drawing.Point(8, 108);
            this.lab_Resize.Name = "lab_Resize";
            this.lab_Resize.Size = new System.Drawing.Size(65, 12);
            this.lab_Resize.TabIndex = 3;
            this.lab_Resize.Text = "缩放界面：";
            // 
            // lab_Start
            // 
            this.lab_Start.AutoSize = true;
            this.lab_Start.Location = new System.Drawing.Point(8, 76);
            this.lab_Start.Name = "lab_Start";
            this.lab_Start.Size = new System.Drawing.Size(65, 12);
            this.lab_Start.TabIndex = 2;
            this.lab_Start.Text = "开始录制：";
            // 
            // lab_Stop
            // 
            this.lab_Stop.AutoSize = true;
            this.lab_Stop.Location = new System.Drawing.Point(8, 44);
            this.lab_Stop.Name = "lab_Stop";
            this.lab_Stop.Size = new System.Drawing.Size(65, 12);
            this.lab_Stop.TabIndex = 1;
            this.lab_Stop.Text = "停止脚本：";
            // 
            // lab_Activate
            // 
            this.lab_Activate.AutoSize = true;
            this.lab_Activate.Location = new System.Drawing.Point(8, 12);
            this.lab_Activate.Name = "lab_Activate";
            this.lab_Activate.Size = new System.Drawing.Size(65, 12);
            this.lab_Activate.TabIndex = 0;
            this.lab_Activate.Text = "启动脚本：";
            // 
            // page_Exchange
            // 
            this.page_Exchange.Controls.Add(this.btn_Quit_e);
            this.page_Exchange.Controls.Add(this.btn_Delete_e);
            this.page_Exchange.Controls.Add(this.btn_Save_e);
            this.page_Exchange.Controls.Add(this.btn_Clear_e);
            this.page_Exchange.Controls.Add(this.txt_PrintText_e);
            this.page_Exchange.Controls.Add(this.cmb_RecvKey_Main);
            this.page_Exchange.Controls.Add(this.cmb_RecvKey_Shift);
            this.page_Exchange.Controls.Add(this.lbl_PrintText);
            this.page_Exchange.Controls.Add(this.lbl_RecvKey);
            this.page_Exchange.Controls.Add(this.dgv_KeyTextPair);
            this.page_Exchange.Location = new System.Drawing.Point(4, 22);
            this.page_Exchange.Name = "page_Exchange";
            this.page_Exchange.Padding = new System.Windows.Forms.Padding(3);
            this.page_Exchange.Size = new System.Drawing.Size(204, 168);
            this.page_Exchange.TabIndex = 3;
            this.page_Exchange.Text = "替换";
            this.page_Exchange.UseVisualStyleBackColor = true;
            // 
            // btn_Quit_e
            // 
            this.btn_Quit_e.Location = new System.Drawing.Point(153, 141);
            this.btn_Quit_e.Name = "btn_Quit_e";
            this.btn_Quit_e.Size = new System.Drawing.Size(43, 21);
            this.btn_Quit_e.TabIndex = 19;
            this.btn_Quit_e.Text = "退出";
            this.btn_Quit_e.UseVisualStyleBackColor = true;
            this.btn_Quit_e.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Delete_e
            // 
            this.btn_Delete_e.Location = new System.Drawing.Point(104, 141);
            this.btn_Delete_e.Name = "btn_Delete_e";
            this.btn_Delete_e.Size = new System.Drawing.Size(43, 21);
            this.btn_Delete_e.TabIndex = 18;
            this.btn_Delete_e.Text = "删除";
            this.btn_Delete_e.UseVisualStyleBackColor = true;
            this.btn_Delete_e.Click += new System.EventHandler(this.btn_Delete_e_Click);
            // 
            // btn_Save_e
            // 
            this.btn_Save_e.Location = new System.Drawing.Point(55, 141);
            this.btn_Save_e.Name = "btn_Save_e";
            this.btn_Save_e.Size = new System.Drawing.Size(43, 21);
            this.btn_Save_e.TabIndex = 17;
            this.btn_Save_e.Text = "保存";
            this.btn_Save_e.UseVisualStyleBackColor = true;
            this.btn_Save_e.Click += new System.EventHandler(this.btn_Save_e_Click);
            // 
            // btn_Clear_e
            // 
            this.btn_Clear_e.Location = new System.Drawing.Point(6, 141);
            this.btn_Clear_e.Name = "btn_Clear_e";
            this.btn_Clear_e.Size = new System.Drawing.Size(43, 21);
            this.btn_Clear_e.TabIndex = 16;
            this.btn_Clear_e.Text = "清空";
            this.btn_Clear_e.UseVisualStyleBackColor = true;
            this.btn_Clear_e.Click += new System.EventHandler(this.btn_Clear_e_Click);
            // 
            // txt_PrintText_e
            // 
            this.txt_PrintText_e.Location = new System.Drawing.Point(67, 116);
            this.txt_PrintText_e.Name = "txt_PrintText_e";
            this.txt_PrintText_e.Size = new System.Drawing.Size(128, 21);
            this.txt_PrintText_e.TabIndex = 15;
            // 
            // cmb_RecvKey_Main
            // 
            this.cmb_RecvKey_Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RecvKey_Main.FormattingEnabled = true;
            this.cmb_RecvKey_Main.Location = new System.Drawing.Point(134, 90);
            this.cmb_RecvKey_Main.Name = "cmb_RecvKey_Main";
            this.cmb_RecvKey_Main.Size = new System.Drawing.Size(61, 20);
            this.cmb_RecvKey_Main.TabIndex = 14;
            this.cmb_RecvKey_Main.Tag = "main";
            // 
            // cmb_RecvKey_Shift
            // 
            this.cmb_RecvKey_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RecvKey_Shift.FormattingEnabled = true;
            this.cmb_RecvKey_Shift.Location = new System.Drawing.Point(68, 90);
            this.cmb_RecvKey_Shift.Name = "cmb_RecvKey_Shift";
            this.cmb_RecvKey_Shift.Size = new System.Drawing.Size(60, 20);
            this.cmb_RecvKey_Shift.TabIndex = 13;
            this.cmb_RecvKey_Shift.Tag = "shift";
            // 
            // lbl_PrintText
            // 
            this.lbl_PrintText.AutoSize = true;
            this.lbl_PrintText.Location = new System.Drawing.Point(6, 119);
            this.lbl_PrintText.Name = "lbl_PrintText";
            this.lbl_PrintText.Size = new System.Drawing.Size(65, 12);
            this.lbl_PrintText.TabIndex = 2;
            this.lbl_PrintText.Text = "输出文本：";
            // 
            // lbl_RecvKey
            // 
            this.lbl_RecvKey.AutoSize = true;
            this.lbl_RecvKey.Location = new System.Drawing.Point(6, 93);
            this.lbl_RecvKey.Name = "lbl_RecvKey";
            this.lbl_RecvKey.Size = new System.Drawing.Size(65, 12);
            this.lbl_RecvKey.TabIndex = 1;
            this.lbl_RecvKey.Text = "接收按键：";
            // 
            // dgv_KeyTextPair
            // 
            this.dgv_KeyTextPair.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_KeyTextPair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KeyTextPair.Location = new System.Drawing.Point(2, 3);
            this.dgv_KeyTextPair.Name = "dgv_KeyTextPair";
            this.dgv_KeyTextPair.ReadOnly = true;
            this.dgv_KeyTextPair.RowHeadersVisible = false;
            this.dgv_KeyTextPair.RowTemplate.Height = 23;
            this.dgv_KeyTextPair.Size = new System.Drawing.Size(199, 82);
            this.dgv_KeyTextPair.TabIndex = 0;
            this.dgv_KeyTextPair.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KeyTextPair_CellClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "按键精灵";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_MaxSize,
            this.btn_Quit_m});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // btn_MaxSize
            // 
            this.btn_MaxSize.Name = "btn_MaxSize";
            this.btn_MaxSize.Size = new System.Drawing.Size(100, 22);
            this.btn_MaxSize.Text = "显示";
            this.btn_MaxSize.Click += new System.EventHandler(this.btn_MaxSize_Click);
            // 
            // btn_Quit_m
            // 
            this.btn_Quit_m.Name = "btn_Quit_m";
            this.btn_Quit_m.Size = new System.Drawing.Size(100, 22);
            this.btn_Quit_m.Text = "退出";
            this.btn_Quit_m.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // SimpleQuickMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 200);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SimpleQuickMacro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按键精灵";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleQuickMacro_FormClosing);
            this.Load += new System.EventHandler(this.SimpleQuickMacro_Load);
            this.SizeChanged += new System.EventHandler(this.SimpleQuickMacro_SizeChanged);
            this.MainTab.ResumeLayout(false);
            this.page_Choose.ResumeLayout(false);
            this.page_Choose.PerformLayout();
            this.page_Record.ResumeLayout(false);
            this.page_Record.PerformLayout();
            this.page_Set.ResumeLayout(false);
            this.page_Set.PerformLayout();
            this.page_Exchange.ResumeLayout(false);
            this.page_Exchange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KeyTextPair)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage page_Choose;
        private System.Windows.Forms.TextBox txt_Details_c;
        private System.Windows.Forms.ComboBox cmb_Choose_c;
        private System.Windows.Forms.TabPage page_Record;
        private System.Windows.Forms.Button btn_Quit_c;
        private System.Windows.Forms.Button btn_Delete_c;
        private System.Windows.Forms.TabPage page_Set;
        private System.Windows.Forms.TextBox txt_Details_r;
        private System.Windows.Forms.TextBox txt_FileName_r;
        private System.Windows.Forms.Button btn_Quit_r;
        private System.Windows.Forms.Button btn_Record_r;
        private System.Windows.Forms.Button btn_Save_r;
        private System.Windows.Forms.Label lab_Stop;
        private System.Windows.Forms.Label lab_Activate;
        private System.Windows.Forms.Label lab_Start;
        private System.Windows.Forms.Label lab_Resize;
        private System.Windows.Forms.ComboBox cmb_Activate_Main;
        private System.Windows.Forms.ComboBox cmb_Activate_Shift;
        private System.Windows.Forms.ComboBox cmb_Resize_Main;
        private System.Windows.Forms.ComboBox cmb_Start_Main;
        private System.Windows.Forms.ComboBox cmb_Stop_Main;
        private System.Windows.Forms.ComboBox cmb_Resize_Shift;
        private System.Windows.Forms.ComboBox cmb_Start_Shift;
        private System.Windows.Forms.ComboBox cmb_Stop_Shift;
        private System.Windows.Forms.Button btn_Quit_s;
        private System.Windows.Forms.Button btn_Reset_s;
        private System.Windows.Forms.Button btn_Save_s;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btn_MaxSize;
        private System.Windows.Forms.ToolStripMenuItem btn_Quit_m;
        private System.Windows.Forms.Button btn_Compiler;
        private System.Windows.Forms.TabPage page_Exchange;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Button btn_CodeCSharp;
        private System.Windows.Forms.Button btn_Code_Java;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_PrintText;
        private System.Windows.Forms.Label lbl_RecvKey;
        private System.Windows.Forms.DataGridView dgv_KeyTextPair;
        private System.Windows.Forms.Button btn_Edit_c;
        private System.Windows.Forms.Button btn_Quit_e;
        private System.Windows.Forms.Button btn_Delete_e;
        private System.Windows.Forms.Button btn_Save_e;
        private System.Windows.Forms.Button btn_Clear_e;
        private System.Windows.Forms.TextBox txt_PrintText_e;
        private System.Windows.Forms.ComboBox cmb_RecvKey_Main;
        private System.Windows.Forms.ComboBox cmb_RecvKey_Shift;

    }
}

