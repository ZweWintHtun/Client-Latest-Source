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
    public class TLMCTL00054 : AbstractPresenter, ITLMCTL00054
    {
        #region Properties
        private ITLMVEW00054 view;
        public ITLMVEW00054 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        string workStation { get; set; }
        private void WireTo(ITLMVEW00054 view)
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

        public IList<TLMDTO00058> SelectSavingDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
          //  Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.SavControl);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, CurrentUserEntity.BranchCode,workStation,this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode,workStation, this.view.IsSettlementDate));

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectSavingReversalDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
         //   Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.SavControl);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation,this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate));
            return dayBooks;
        }

        public IList<TLMDTO00058> SelectFixedDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
           // Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.FixControl);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation,this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate));

            return dayBooks;
        }

        public IList<TLMDTO00058> SelectFixedReversalDayBook()
        {
            workStation = Convert.ToString(CurrentUserEntity.WorkStationId);
          //  Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTO = CXCLE00001.Instance.SelectACode(CXCOM00009.FixControl);
            //IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, CurrentUserEntity.BranchCode, workStation,this.view.IsSettlementDate));
            IList<TLMDTO00058> dayBooks = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workStation, this.view.IsSettlementDate));

            return dayBooks;
        }


    
    }
}
