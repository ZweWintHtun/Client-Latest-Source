using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00004 : AbstractPresenter, IMNMCTL00004
    {
        public MNMCTL00004()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #region Property

        private string BranchCode { get; set; }

        private IMNMVEW00004 view;
        public IMNMVEW00004 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region WireTo

        private void WireTo(IMNMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        }

        //private void WireTo(IMNMVEW00004 view)
        //{
        //    if (this.view == null)
        //    {
        //        this.view = view;
        //        this.Initialize(this.view, this.GetSys001InfoEntity());
        //    }
        //}

        #endregion WireTo

        #region Method

        public DateTime SelectSysDate()
        {
            PFMDTO00056 sysDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate("FIXINTDATE", this.BranchCode));
            return sysDTO.SysDate.Value;
        }

        public void Save()
        {

            CXClientWrapper.Instance.Invoke<IMNMSVE00004>(x => x.FixedDepositAutoRenewalUpdating(this.View.RenewalStartDate, this.View.RenewalEndDate, this.View.start, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, 0, string.Empty));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {

                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                
            }
        }

        #endregion
    }
}
