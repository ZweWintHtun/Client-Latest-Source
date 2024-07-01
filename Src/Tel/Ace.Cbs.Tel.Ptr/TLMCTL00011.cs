using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00011 : AbstractPresenter, ITLMCTL00011
    {
        #region "Wire To"
        private ITLMVEW00011 view;
        public ITLMVEW00011 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00011 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.DenoData);
            }
        }
        #endregion

        #region Methods

        public bool Save()
        {
            //added by ASDA**
            //if (this.view.ParentFormId == "TLMVEW00075")
            if (this.view.ParentFormId == "TLMVEW00078")
            {
                if (this.View.RefundAmount != 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037);
                    return false;
                }
                else
                {
                    for (int i = 0; i < this.View.DenoData.Count; i++)
                    {
                        this.View.DenoData[i].TotalAmount = this.View.TotalAmount;
                        //this.View.DenoData[i].AdjustAmount = 0;
                    }

                    var list = from x in this.View.DenoData where x.RefundCount > 0 || x.DenoCount > 0 select x;

                    CXDTO00001 DenoDetail = CXCLE00009.Instance.GetDenoString(list.ToList<TLMDTO00012>(), true, this.View.BranchCode);
                    DenoDetail.AdjustAmount = this.View.DenoData[0].AdjustAmount;
                    DenoDetail.TotalAmount = this.View.DenoData[0].TotalAmount;
                    DenoDetail.Surplus = this.View.DenoData[0].Surplus == 0 ? 0 : this.View.DenoData[0].Surplus;
                    DenoDetail.Shortage = this.View.DenoData[0].Shortage == 0 ? 0 : this.View.DenoData[0].Shortage;
                    DenoDetail.CounterNo = this.View.CounterNo;

                    CXUIScreenTransit.SetData(this.View.ParentFormId, DenoDetail);
                    return true;
                }
            }
            //End****
            else
            {
                if (View.TotalAmount < View.Amount)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00037); //Invalid Amount.
                    return false;
                }

                if (this.View.RefundAmount != 0)
                {
                    if (CXUIScreenTransit.Transit("frmTLMVEW00012", true, new object[] { this.View.RefundAmount, this.View.DenoData, this.View.ParentFormId }) == DialogResult.OK)
                        this.View.DenoData = CXUIScreenTransit.GetData<IList<TLMDTO00012>>(this.View.ParentFormId);
                    else
                        return false;
                }

                for (int i = 0; i < this.View.DenoData.Count; i++)
                {
                    this.View.DenoData[i].TotalAmount = this.View.TotalAmount;
                    //this.View.DenoData[i].AdjustAmount = 0;
                }

                var list = from x in this.View.DenoData where x.RefundCount > 0 || x.DenoCount > 0 select x;

                CXDTO00001 DenoDetail = CXCLE00009.Instance.GetDenoString(list.ToList<TLMDTO00012>(), true, this.View.BranchCode);
                DenoDetail.AdjustAmount = this.View.DenoData[0].AdjustAmount;
                DenoDetail.TotalAmount = this.View.DenoData[0].TotalAmount;
                DenoDetail.Surplus = this.View.DenoData[0].Surplus == 0 ? 0 : this.View.DenoData[0].Surplus;
                DenoDetail.Shortage = this.View.DenoData[0].Shortage == 0 ? 0 : this.View.DenoData[0].Shortage;
                DenoDetail.CounterNo = this.View.CounterNo;

                CXUIScreenTransit.SetData(this.View.ParentFormId, DenoDetail);
                return true;
            }
        }

        public void ClearControls()
        {
            this.View.RefundAmount = 0;
            this.View.TotalAmount = 0;
            this.View.Amount = this.View.DefaultAmount;
            this.View.BindDenoInformation();
            this.View.counttotal = 0;
        }

        #endregion

    }

}