using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMacro
{
    internal class HideOnStartupApplicationContext : ApplicationContext
    {
        private Form mainFormInternal;

        public HideOnStartupApplicationContext(Form mainForm)
        {
            this.mainFormInternal = mainForm;
            this.mainFormInternal.FormClosed += new FormClosedEventHandler(mainFormInternal_FormClosed);
        }

        void mainFormInternal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
