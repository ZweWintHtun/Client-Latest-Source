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

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00006 : BaseForm
    {
        public GLMVEW00006()
        {
            InitializeComponent();
        }

        public string ParentMenu { get; set; }

        private void GLVEW00006_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            string formatType = string.Empty;
            string formatStatus = string.Empty;
            if (rdoProfitAndLoss.Checked)
            {
                formatType = "Profit And Loss";
                formatStatus = "PL";
            }
            else if (rdoBalanceSheet.Checked)
            {
                formatType = "Balance Sheet";
                formatStatus = "BS";
            }
            else if (rdoTrialBalance.Checked)
            {
                formatType = "Trial Balance";
                formatStatus = "TB";
            }
            else if (rdoIncomeAndExp.Checked)
            {
                formatType = "Income And Expenditure";
                formatStatus = "IE";
            }

            if (this.ParentMenu == "Report Format Entry")
                CXUIScreenTransit.Transit("frmGLMVEW00007", true, new object[] { formatType, formatStatus });
            else
                CXUIScreenTransit.Transit("frmGLMVEW00011", true, new object[] { formatType, formatStatus });
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoProfitAndLoss.Checked = true;
        }
    }
}
