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
    public partial class MNMVEW00109 : Form
    {
        public MNMVEW00109()
        {
            InitializeComponent();
        }

        private void MNMVEW00109_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
