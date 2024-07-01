//----------------------------------------------------------------------
// <copyright file="LOMSVE00015" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>14.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Cle;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00015 : AbstractPresenter, ILOMCTL00015
    {
        #region "Wire To"
        private ILOMVEW00015 view;
        public ILOMVEW00015 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00015 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private TLMDTO00018 GetEntity()
        {
            TLMDTO00018 LoanEntity = new TLMDTO00018();
            LoanEntity.Lno = this.view.LoanNo;
            return LoanEntity;
        }
        #endregion

        IList<TCMDTO00003> NPLIntList  { get; set; }
        bool IsVoucher { get; set; }
        string currency { get; set; }
        string LoanAType { get; set; }

        #region validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {           
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    TLMDTO00018 LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00014, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                    if (LoanDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90055);  //Invalid Loan No.
                        return;
                    }
                    else
                    {
                        if (LoanDTO.NPLDate == null || LoanDTO.NPLCase == false)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90065, new object[] {this.view.LoanNo}); //Loan No.{0} is not in Non Performance Loan Case.
                            return;
                        }                        
                        else
                        {
                            this.currency = LoanDTO.Currency;
                            this.view.AccountNo = LoanDTO.AccountNo;
                            this.view.AccountType = LoanDTO.AType;
                            this.view.MakingDate = LoanDTO.NPLDate.Value.ToString("dd/MM/yyyy");

                            IList<TCMDTO00003> GridDataList = this.GetGridViewData(LoanDTO);
                            this.view.BindGridView(GridDataList);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
                    //this.ClearControls();
                    throw new Exception(ex.Message);                    
                }
            }
            else
            { return; }
        }
        #endregion

        #region Method

        public IList<TCMDTO00003> GetGridViewData(TLMDTO00018 LoanDTO)
        {
            string AType = string.Empty;
            string SAccountNo = string.Empty;
            string Description = string.Empty;
            string SAccountNoName = string.Empty;
            IList<TCMDTO00003> ReturnNPLIntList = new List<TCMDTO00003>();
            LoanAType = LoanDTO.AType;
            switch (LoanDTO.AType)
            {               
                case "LOANS": AType = "L,S";
                    break;
                case "OVERDRAFT": AType = "O,C,S";
                    break;
                case "TOD": AType = "T,C,S";
                    break;
            }

            NPLIntList = CXClientWrapper.Instance.Invoke<ILOMSVE00015, IList<TCMDTO00003>>(x => x.GetNPLIntList(this.View.LoanNo, AType, CurrentUserEntity.BranchCode));
            if (NPLIntList != null)             
            {
                if(NPLIntList .Count > 0)
                {
                    IsVoucher = true;
                    SAccountNoName = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.OverDraftAccountName);
                    SAccountNo = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { SAccountNoName, LoanDTO.Currency, CurrentUserEntity.BranchCode, true });  //AcNoName = SundryOD
                    NPLIntList[0].ACode = SAccountNo;
                    //To Bind in GridView                
                    foreach (TCMDTO00003 Creditdata in NPLIntList)
                    {
                        TCMDTO00003 NPlDtoForCredit = new TCMDTO00003();
                        NPlDtoForCredit.AcctNo = Creditdata.Type;        //Account  - IF0010                      
                        //NPlDtoForCredit.Narration = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.SelectByAccountNo", new object[] { Creditdata.Type, LoanDTO.Currency, CurrentUserEntity.BranchCode, true }); 
                        ChargeOfAccountDTO coaForCredit = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { Creditdata.Type, CurrentUserEntity.BranchCode, true }); //Description - check with Atype and get description from (coa table)
                        NPlDtoForCredit.Narration = coaForCredit.AccountName;
                        //NPlDtoForCredit.Narration = Creditdata.Narration;  //Description - check with Atype and get description from (coa table)
                        NPlDtoForCredit.Amount = Creditdata.Amount;        //Amount
                        NPlDtoForCredit.AType = "CR";          //CR/DR
                        ReturnNPLIntList.Add(NPlDtoForCredit);

                        foreach (TCMDTO00003 Debitdata in NPLIntList)
                        {
                            TCMDTO00003 NPlDtoForDebit = new TCMDTO00003();
                            NPlDtoForDebit.AcctNo = SAccountNo;         //Account  - LAN026 - SUNDRY DEPOSIT A/C 
                           // NPlDtoForDebit.Narration = SAccountNoName;  //Description - check with Atype and get description from (coa table)                            
                            ChargeOfAccountDTO coaForDebit = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { SAccountNo, CurrentUserEntity.BranchCode, true });  //Description - check with Atype and get description from (coa table)
                            NPlDtoForDebit.Narration = coaForDebit.AccountName;
                            NPlDtoForDebit.Amount = Debitdata.Amount;   //Amount
                            NPlDtoForDebit.AType = "DR";                //CR/DR
                            ReturnNPLIntList.Add(NPlDtoForDebit);
                        }
                    }
                }
            }
            return ReturnNPLIntList;
        }

        public void Save()
        {     
            if(!ValidateForm(this.GetEntity()))
                return ;

            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90007) == DialogResult.Yes)
            {
                string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                if (NPLIntList == null || NPLIntList.Count == 0)
                {
                    IList<TCMDTO00003> list = new List<TCMDTO00003>();
                    TCMDTO00003 npldto = new TCMDTO00003();
                    npldto.LNo = this.view.LoanNo;
                    list.Add(npldto); //if NPLIntList.count < 0
                    CXClientWrapper.Instance.Invoke<ILOMSVE00015, bool>(x => x.ReleaseNPLCase(list, IsVoucher, currency, LoanAType, channel, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID));
                }
                else
                    CXClientWrapper.Instance.Invoke<ILOMSVE00015, bool>(x => x.ReleaseNPLCase(NPLIntList, IsVoucher,currency,LoanAType,channel,CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId,CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID));

                if(CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);  //Saving Successful                
            }
        }

        //public void ClearControls()
        //{
        //    this.view.LoanNo = string.Empty;
        //    this.view.AccountNo = string.Empty;
        //    this.view.AccountType = string.Empty;
        //    this.view.MakingDate = string.Empty;
        //}
        
        #endregion

    }
}
