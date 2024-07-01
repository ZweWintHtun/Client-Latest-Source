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
    public partial class MNMVEW00145 : Form
    {
        public MNMVEW00145()
        {
            InitializeComponent();
        }

        private void MNMVEW00145_Load(object sender, EventArgs e)
        {

            this.rpvAutoLinkCreditListing.RefreshReport();
        }
    }
}
