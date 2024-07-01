//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00054 : AbstractPresenter, IMNMCTL00054
    {
        #region Properties
        private IMNMVEW00054 view;
        public IMNMVEW00054 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }
        #endregion
     
        #region Helper Methods

        private PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.ACode = this.view.AccountCode;
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            ViewData.IsHomeCurrency = this.view.IsHomeCurrency;
            if (this.view.IsHomeCurrency == true)
            {
                ViewData.CurCode = "KYT";
            }
            else
            {
                ViewData.CurCode = this.view.Currency;
            }
            ViewData.CurrencyType = this.view.Currency;
            if (this.view.IsTransactionDate == true)
            {
                ViewData.TransactionStatus = "T";
            }
            else 
            {
                ViewData.TransactionStatus = "S";
            }

            ViewData.Description = this.view.AccountDescription;
            ViewData.SourceBranch = CurrentUserEntity.BranchCode;

            return ViewData;
        }


        private PFMDTO00042 GetDataForValidate()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.ACode = this.view.AccountCode;
            ViewData.CurrencyType = this.view.Currency;
            return ViewData;
        }

        private void WireTo(IMNMVEW00054 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public void ClearCustomErrorMessages()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool ValidateForm()
        {
            return this.ValidateForm(this.GetDataForValidate());
        }

        #endregion

        #region Events calling Methods

        public void cboAccountCode_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (string.IsNullOrEmpty(this.View.AccountCode))
                {
                    this.SetCustomErrorMessage(this.GetControl("cboAccountCode"), CXMessage.MV00046); //Invalid AccountNo.             
                                   
                }
                else
                {
                    var acctnodesp = (from value in this.View.AccountTypeList where value.ACode == this.View.AccountCode select value.AccountName).Single();
                    this.View.AccountDescription = Convert.ToString(acctnodesp);
                }
            }
        }

        public void Print()
        {
            if (ValidateForm())
            {
                string returnCashCode = CXCOM00010.Instance.GetCoaSetupAccountNo("CASH", CurrentUserEntity.BranchCode);
                string returnODACode = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", CurrentUserEntity.BranchCode);

                string returnODACode1 = CXCOM00010.Instance.GetCoaSetupAccountNo("LOANSTOD", CurrentUserEntity.BranchCode);
                string returnODACode2 = CXCOM00010.Instance.GetCoaSetupAccountNo("HPTOD", CurrentUserEntity.BranchCode);

                IList<MNMDTO00054> PrintDataLists = new List<MNMDTO00054>();
                PFMDTO00042 DataDTO = this.GetViewData();

                if (returnCashCode.Substring(0, 3).ToUpper() == this.view.AccountCode.Substring(0, 3).ToUpper())// Modified By AAM (29-Jan-2018)
                    //(returnCashCode.Substring(1, 3).ToUpper() == this.view.AccountCode.Substring(1, 3).ToUpper()) // Commented By AAM (29-Jan-2018)
                {
                    DataDTO.ACode = returnCashCode;
                    DataDTO.Status = "Cash";
                }
                // For Pristine Version ZMS (28.11.2017) ///

                //else if (returnODACode.Substring(1, 3).ToUpper() == this.view.AccountCode.Substring(1, 3).ToUpper())
                //{
                //    DataDTO.ACode = returnODACode;
                //    DataDTO.Status = "OD";
                //}
                else if (returnODACode1.ToUpper() == this.view.AccountCode.Substring(0, 3).ToUpper())// Modified By AAM (29-Jan-2018)
                    //(returnODACode1.ToUpper() == this.view.AccountCode.Substring(1, 3).ToUpper())// Commented By AAM (29-Jan-2018)
                {
                    DataDTO.ACode = returnODACode1;
                    DataDTO.Status = "LOANSTOD";
                }
                else if (returnODACode2.ToUpper() == this.view.AccountCode.Substring(0, 3).ToUpper())// Modified By AAM (29-Jan-2018)
                    //(returnODACode2.ToUpper() == this.view.AccountCode.Substring(1, 3).ToUpper())// Commented By AAM (29-Jan-2018)
                {
                    DataDTO.ACode = returnODACode2;
                    DataDTO.Status = "HPTOD";
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else
                {
                    DataDTO.ACode = DataDTO.ACode;
                    DataDTO.Status = "A";
                }

                string sourceBr= CurrentUserEntity.BranchCode;//Added By ZMS For Budget End

                PrintDataLists = CXClientWrapper.Instance.Invoke<IMNMSVE00054, IList<MNMDTO00054>>(x => x.GetReportData(DataDTO, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserID, sourceBr));
                if (PrintDataLists == null)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    return;
                }

                CXUIScreenTransit.Transit("frmMNMVEW00103", true, new object[] { PrintDataLists, this.view.AccountCode, this.view.StartDate, this.view.EndDate, this.view.Currency,this.view.AccountDescription });
            }
        }
             
        #endregion
    }
}
