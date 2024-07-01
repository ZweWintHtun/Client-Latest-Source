using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00046 : BaseForm
    {
        public LOMVEW00046()
        {
            InitializeComponent();
        }

        private void LOMVEW00046_Load(object sender, EventArgs e)
        {
            this.Text = "Loans Interest Listing";
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (this.rdoJanMar.Checked == true)
            {
                this.HelperTransit("Q4");
            }
            else if (this.rdoAprJun.Checked == true)
            {
                this.HelperTransit("Q1");
            }
            else if (this.rdoJulSep.Checked == true)
            {
                this.HelperTransit("Q2");
            }
            else if (this.rdoOctDec.Checked == true)
            {
                this.HelperTransit("Q3");
            }
        }

        private void HelperTransit(string selectedQuater)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00045", true, new object[] { selectedQuater });
        }
    }
}
