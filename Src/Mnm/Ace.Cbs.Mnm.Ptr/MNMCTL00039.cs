using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00039 : AbstractPresenter, IMNMCTL00039
    {
        #region Properties

        private IMNMVEW00039 view;
        public IMNMVEW00039 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        
        #endregion

        #region Helper Method
        private void WireTo(IMNMVEW00039 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetValidateData());
            }
        }
      
        public PFMDTO00042 GetValidateData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this.view.RequiredDate;
            ViewData.CurrencyType = this.view.Currency;
            if (this.view.IsSettlementDate == true)
            {
                ViewData.TransactionStatus = "S";
            }
            else
            {
                ViewData.TransactionStatus = "T";
            }
            
            ViewData.IsWithReversal = this.view.IsWithReversal;
            ViewData.SourceBranch = CurrentUserEntity.BranchCode;
            return ViewData;
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetValidateData());
        }

        public void ClearCustomErrorMessages()
        {
            this.ClearAllCustomErrorMessage();
        }

        #endregion

        #region Main Method

        public void Print()
        {
            PFMDTO00042 DataDTO = this.GetValidateData();

            IList<PFMDTO00029> PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00039, IList<PFMDTO00029>>(x => x.GetAutoLinkListing(DataDTO,CurrentUserEntity.WorkStationId,CurrentUserEntity.CurrentUserID));
            if (PrintDataList.Count > 0)
            {
                CXUIScreenTransit.Transit("frmMNMVEW00088", true, new object[] { PrintDataList,this.view.RequiredDate,this.view.IsWithReversal});
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data For Report
            }

        }
        #endregion
    }
}
