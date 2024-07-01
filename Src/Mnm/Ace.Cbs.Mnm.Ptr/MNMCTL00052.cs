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


namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00052 : AbstractPresenter, IMNMCTL00052
    {
        #region Properties
        private IMNMVEW00052 view;
        public IMNMVEW00052 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        IList<PFMDTO00001> AccountInfo { get; set; }
        IList<PFMDTO00054> CustomerDTO { get; set; }
        public PFMDTO00001 accountinfo { get; set; }
        
        #endregion

        #region Helper Methods

        private PFMDTO00042 GetVlaidateData()
        {
            PFMDTO00042 ValidateDto = new PFMDTO00042();
            ValidateDto.AcctNo = view.AccountNumber;
            ValidateDto.StartDate = view.GetStartDate();
            ValidateDto.EndDate = view.GetEndDate();
            return ValidateDto;
        }

        private void WireTo(IMNMVEW00052 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetVlaidateData());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        #endregion

        #region Events calling Methods
        public void mtxtAccountNo_CustomValidate(object sender, ValidationEventArgs e)
        {

            if (string.IsNullOrEmpty(view.AccountNumber))
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046");
            }
            else
            {
                Nullable<CXDMD00011> accountType;
                string accountNo = this.View.AccountNumber.Replace("-", "");
                try
                {
                    if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        string AcSign = CXClientWrapper.Instance.Invoke<IMNMSVE00052, string>(x => x.CheckingAccountNo(accountNo, CurrentUserEntity.BranchCode, this.view.FormName));
                        if (AcSign != null)
                        {
                            if (this.view.CheckDate())
                            {
                               // this.PrintAll(accountNo, AcSign, string.Empty, string.Empty, string.Empty);
                            }
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
        }

        public void PrintAll(string AcctNo,string acSign,string name , string nrc, string address)
        {
            IList<PFMDTO00001> PrintDataLists = new List<PFMDTO00001>();
            PFMDTO00042 DataDTO = this.GetVlaidateData();           
            if(acSign == null)
                acSign = CXClientWrapper.Instance.Invoke<IMNMSVE00052, string>(x => x.CheckingAccountNo(AcctNo, CurrentUserEntity.BranchCode, this.view.FormName));            

            DataDTO.AccountSign = acSign;
            DataDTO.SourceBranch = CurrentUserEntity.BranchCode;

            CXClientWrapper.Instance.Invoke<IMNMSVE00052, IList<PFMDTO00042>>(x => x.GetReportData(DataDTO,CurrentUserEntity.WorkStationId,CurrentUserEntity.CurrentUserID));

            PrintDataLists = CXClientWrapper.Instance.Invoke<IMNMSVE00052, IList<PFMDTO00001>>(x => x.SelectBankStatementAll_ByAcctNo(AcctNo, DataDTO.StartDate,DataDTO.EndDate, CurrentUserEntity.BranchCode, this.view.FormName));
            if (PrintDataLists.Count > 0)
            {
                PrintDataLists[0].CustomerId = name;
                PrintDataLists[0].NRC = nrc;
                PrintDataLists[0].Address = address;
                if (this.view.FormName == "Current All" || this.view.FormName == "Saving All")
                {
                   CXUIScreenTransit.Transit("frmMNMVEW00101", true, new object[] { PrintDataLists, this.View.FormName,this.view.StartPeriod,this.view.EndPeriod });
                }
                else if (this.view.FormName == "Current Specific" || this.view.FormName == "Saving Specific")
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00104", true, new object[] { PrintDataLists, this.View.FormName,this.view.StartPeriod,this.view.EndPeriod });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00040",new object[]{this.view.AccountNumber}); //No data for Report for Account No {0}.
            }  
        }

        public IList<PFMDTO00001> GetAccountInfo()
        {
            AccountInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00052, IList<PFMDTO00001>>(x => x.SelectCustomerInfoAll(CurrentUserEntity.BranchCode,this.view.FormName));
            if (AccountInfo.Count < 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");
                return null;
            }
            return AccountInfo;
        }      
        #endregion
    }
}
