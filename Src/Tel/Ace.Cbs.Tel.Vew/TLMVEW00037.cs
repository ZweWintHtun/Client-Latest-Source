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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00037 : BaseDockingForm
    {
        public TLMVEW00037()
        {
            InitializeComponent();
        }
        
        public TLMVEW00037(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00037_Load(object sender, EventArgs e)
        {
            //Enable Disable menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoIncomeOustand.Checked = true;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (rdoIncomeOustand.Checked)
            {
                IList<TLMDTO00017> rdlist = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStandingByIncomeOutstand(CurrentUserEntity.BranchCode));  //edited (with sourcebr)
                if (rdlist.Count > 0)
                { CXUIScreenTransit.Transit("frmTLMVEW00057", true, new object[] { false, this.Name, "IncomeOutstanding" }); }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
              
            }

            else if(rdoDrawingAmountOutstand.Checked)
            {
                IList<TLMDTO00017> rdlist = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStandingByDrawingAmountOutstand(CurrentUserEntity.BranchCode));  //edited (with sourcebr)
                if (rdlist.Count > 0)
                { CXUIScreenTransit.Transit("frmTLMVEW00056", true, new object[] { false, this.Name, "DrawingAmountOutstanding" }); }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
              
            }

            else if(rdoAmountAndIncomeOutstand.Checked)
            {
                IList<TLMDTO00017> rdlist = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStanding(CurrentUserEntity.BranchCode));  //edited (with sourcebr)
                if (rdlist.Count > 0)
                { CXUIScreenTransit.Transit("frmTLMVEW00057", true, new object[] { false, this.Name, "AmountAndIncomeOutstanding" }); }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
            }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
              
        }
        
      
    }
}
