using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00097 : Form
    {
        public MNMVEW00097()
        {
            InitializeComponent();
        }

        private void MNMVEW00097_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
