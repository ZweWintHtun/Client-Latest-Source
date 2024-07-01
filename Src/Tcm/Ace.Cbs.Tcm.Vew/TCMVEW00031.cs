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

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00031 : BaseForm
    {
        public TCMVEW00031()
        {
            InitializeComponent();
        }

        public string ParentMenu { get; set; }

        private void TCMVEW00031_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);            
        }

        private void butContinue_Click(object sender, EventArgs e)
        {
            
            if (rdoCashReceipt.Checked)
            {
                
                if (CXUIScreenTransit.Transit("frmTCMVEW00010", true, new object[] { "R" }) == DialogResult.OK)
                {
                    return;
                }
            }
            else if (rdoCashPayment.Checked)
            {
                if (CXUIScreenTransit.Transit("frmTCMVEW00010", true, new object[] { "P" }) == DialogResult.OK)
                {                              
                    return;
                }
            }


            else if (rdoAll.Checked)
            {
                if (CXUIScreenTransit.Transit("frmTCMVEW00010", true, new object[] { }) == DialogResult.OK)
                {
                    return;
                }
            }
            else if (rdoIndividual.Checked)
            {
                if (CXUIScreenTransit.Transit("frmTCMVEW00011", true, new object[] { }) == DialogResult.OK)
                {
                    return;
                }
            }

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoCashReceipt.Checked = true;
        }

    }
}
