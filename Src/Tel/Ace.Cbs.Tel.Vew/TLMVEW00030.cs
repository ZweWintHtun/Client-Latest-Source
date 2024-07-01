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
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00030 : BaseForm
    {
        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public TLMVEW00030()
        {
            InitializeComponent();

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.Text = this.GetFormNameString();

            if (this.Text == "Encash Remittance Listing")
            {
                this.HideControls("Encash.AmountOutstanding.HideControls");
            }

        }

        private string GetFormNameString()
        {
            switch (this.FormName)
            {
                case "Drawing Remittance Listing":
                    return "Drawing Remittance Listing ";

                case "Encash Remittance Listing":
                    return "Encash Remittance Listing";
                default:
                    return string.Empty;
            }
        }

        private void TLMVEW00030_Load(object sender, EventArgs e)
        {
            this.InitializeControls();

        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (rdoByOutstanding.Checked && this.FormName == "Encash Remittance Listing")
            {
                string sourceBr = CurrentUserEntity.BranchCode;
                IList<TLMDTO00001> redto = CXClientWrapper.Instance.Invoke<ITLMSVE00059, IList<TLMDTO00001>>(x => x.SelectEncashOutStanding(sourceBr));
                if (redto != null)
                {
                    if (redto.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00059", true, new object[] { false, this.Name, redto });
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");

                }
            }
            else if (rdoByOutstanding.Checked && this.FormName == "Drawing Remittance Listing")
            {
                IList<TLMDTO00017> rdlist = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStanding(CurrentUserEntity.BranchCode));  //edited by ASDA
                if (rdlist.Count > 0 )
                { CXUIScreenTransit.Transit("frmTLMVEW00057", true, new object[] { false, this.Name, "Outstanding" }); }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
            }

            else if (rdoByAmountOutstanding.Checked && this.FormName == "Drawing Remittance Listing")
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00037", true, new object[] { false, this.Name }) == DialogResult.OK)
                {
                    return;
                }
            }

            else if (rdoByAmount.Checked)
            {

                if (CXUIScreenTransit.Transit("frmTLMVEW00039", true, new object[] { false, this.FormName }) == DialogResult.OK)
                {
                    return;
                }

            }

            else if (rdoAllByBranch.Checked)
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00038", true, new object[] { false, this.FormName }) == DialogResult.OK)
                {
                    return;
                }
            }

            else if (rdoByNRC.Checked)
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00040", true, new object[] { false, this.FormName, "ByNRC" }) == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00040", true, new object[] { false, this.FormName, "ByName" }) == DialogResult.OK)
                {
                    return;
                }

            }

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoByOutstanding.Checked = true;
        }
    }
}
