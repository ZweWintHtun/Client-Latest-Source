using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class PFMVEW00035 : BaseDockingForm
    {
        public PFMVEW00035()
        {
            InitializeComponent();
        }
        public PFMVEW00035(string accountNo)
        {            
            InitializeComponent();
            this.lblAccountNo.Text = accountNo;
        }

        public string AccountNo { get; set; }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (this.rdoPassbook.Checked)
            {
                CXUIScreenTransit.SetData("PFMVEW00035", "0");   //Passbook                   
                this.Close();
            }
            else
            {                
                CXUIScreenTransit.SetData("PFMVEW00035", "1");   //Certificate
                this.Close();
            }
        }
    }
}
