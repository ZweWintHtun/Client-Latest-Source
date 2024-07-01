using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00053 : AbstractPresenter, ITLMCTL00053
    {
        #region Properties
        private ITLMVEW00053 view;
        public ITLMVEW00053 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(ITLMVEW00053 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetDayBookEntity());
            }
        }
       
        public TLMDTO00058 GetDayBookEntity()
        {
            TLMDTO00058 daybookEntity = new TLMDTO00058();
            return daybookEntity;

        }
        #endregion

       

        public IList<TLMDTO00058> SelectCurrentDayBook()
        {
            //string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
        //    Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.CurControl);
          //  string acode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.view.CurrencyCode, this.view.BranchCode, true });
           IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID,

               this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));
           
            return dayBooks;
        }

        public IList<TLMDTO00058> SelectCurrentReversalDayBook()
        {
           // string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
          //  Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.CurControl);
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectCurrentHomeDayBook()
        {
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
           // Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.CurControl);
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentHomeDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectCurrentHomeReversalDayBook()
        {
            //string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
            // Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.CurControl);
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentHomeReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate,this.view.SortByTime));

            return dayBooks;
        }
    }

}
