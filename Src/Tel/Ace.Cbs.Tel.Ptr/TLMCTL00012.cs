using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00012 : AbstractPresenter, ITLMCTL00012
    {
        private ITLMVEW00012 view;

        public ITLMVEW00012 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00012 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.DenoData);
            }
        }     

        #region Method

        public bool Save()
        {
            if (this.View.RefundAmount != this.View.TotalAmount)
            {
                if (this.View.SurPlus > this.View.DenoAdjustAmount)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00163, new object[] { "Surplus", this.View.DenoAdjustAmount });
                    return false;
                }
                else if( this.View.Shortage > this.View.DenoAdjustAmount)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00163, new object[] { "Shortage", this.View.DenoAdjustAmount });
                    return false;
                }
                else if (this.View.SurPlus < this.View.DenoAdjustAmount || this.View.Shortage < this.View.DenoAdjustAmount)
                {
                    if ((Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00018)) != System.Windows.Forms.DialogResult.Yes)
                        return false;
                    else
                    {
                        this.View.DenoData[0].Shortage = this.View.Shortage == 0 ? 0 : (-1 * this.View.Shortage);
                        this.View.DenoData[0].Surplus = this.View.SurPlus;
                        this.View.DenoData[0].TotalAmount = this.View.TotalAmount;
                        this.View.DenoData[0].AdjustAmount = (this.View.SurPlus > 0) ? this.View.SurPlus : (this.View.Shortage == 0 ? 0 : (-1 * this.View.Shortage));
                    }   
                }
            }
            else
            {
                for (int i = 0; i < this.View.DenoData.Count; i++)
                {
                    this.View.DenoData[i].TotalAmount = this.View.RefundAmount;
                    this.View.DenoData[i].AdjustAmount = this.View.TotalAmount;
                    this.View.DenoData[i].Shortage = this.View.Shortage;
                    this.View.DenoData[i].Surplus = this.View.SurPlus;
                }
                
            }
            CXUIScreenTransit.SetData(this.View.ParentFormId, this.View.DenoData);
            return true;
        }

        public void ClearControls()
        {
            this.View.TotalAmount = 0;
            this.View.SurPlus = 0;
            this.View.Shortage = 0;
            this.View.RefundAmount = this.View.DefaultRefundAmount;
            this.View.BindDenoInformation();
        }
               
        #endregion

    }

}