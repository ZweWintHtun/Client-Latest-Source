using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00074 : BaseForm
    {
        public MNMVEW00074()
        {
            InitializeComponent();
        }

        private void MNMVEW00074_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
