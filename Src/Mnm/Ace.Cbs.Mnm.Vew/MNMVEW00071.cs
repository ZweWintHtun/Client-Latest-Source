using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;

using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00071 : BaseForm,IMNMVEW00071
    {
        public MNMVEW00071()
        {
            InitializeComponent();
        }

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Value = value; }
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Value = value; }
        }



    

        #region Controller
        private IMNMCTL00071 controller;
        public IMNMCTL00071 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        private void MNMVEW00071_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.tsbCRUD.butPrint.TabIndex = 0;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            dtpStartDate.Text = DateTime.Now.ToString() ;
            dtpEndDate.Text = DateTime.Now.ToString();
            rdoWithdraw.Checked = true;
            rdoAllWithdraw.Checked = true;
        }

        private void cxC00092_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            gbWithdrawType.Enabled = false;
        }

        private void cxC00091_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            gbWithdrawType.Enabled = true;
        }        

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            
                if (CXCOM00006.Instance.IsValidStartDateEndDate(dtpStartDate.Value, dtpEndDate.Value))
                {
                    if (rdoOutstanding.Checked)
                    {
                        IList<MNMDTO00071> savingAccuredOutstanding = this.controller.SelectSavingAccuredInterestAll();
                        if (savingAccuredOutstanding.Count > 0)
                            CXUIScreenTransit.Transit("frmMNMVEW00159", true, new object[] { savingAccuredOutstanding });
                        else
                            CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data for Report.
                    }
                    else if (rdoWithdraw.Checked && rdoAllWithdraw.Checked)
                    {
                        IList<MNMDTO00071> savingAccuredbetweenDates = this.controller.SelectSavingAccuredInterestBetweenStartDateandEndDate();
                       if(savingAccuredbetweenDates.Count>0)
                        CXUIScreenTransit.Transit("frmMNMVEW00158", true, new object[] { savingAccuredbetweenDates });
                        else
                           CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data for Report.
                    }
                    else if (rdoWithdraw.Checked && rdoCash.Checked)
                    {
                        IList<MNMDTO00071> savingAccuredbyCash = this.controller.SelectSavingAccuredInterestByCash();
                        if(savingAccuredbyCash.Count>0)
                        CXUIScreenTransit.Transit("frmMNMVEW00158", true, new object[] { savingAccuredbyCash });
                        else
                            CXUIMessageUtilities.ShowMessageByCode("ME90033");  //No Data for Report.
                    }
                    else if (rdoWithdraw.Checked && rdoTransfer.Checked)
                    {
                        IList<MNMDTO00071> savingAccuredbyTransfer = this.controller.SelectSavingAccuredInterestByTransfer();
                        if(savingAccuredbyTransfer.Count>0)
                        CXUIScreenTransit.Transit("frmMNMVEW00158", true, new object[] { savingAccuredbyTransfer });
                        else
                            CXUIMessageUtilities.ShowMessageByCode("ME90033");
                    }
                }           
        }

        
    }
}
