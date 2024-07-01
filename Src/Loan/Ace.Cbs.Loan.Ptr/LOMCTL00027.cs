//----------------------------------------------------------------------
// <copyright file="LOMCTL00027" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>07.02.2015</CreatedDate>
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
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00027 : AbstractPresenter, ILOMCTL00027
    {
        #region "Wire To"
        private ILOMVEW00027 view;
        public ILOMVEW00027 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00027 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        private LOMDTO00013 GetEntity()
        {
            LOMDTO00013 LoanEntity = new LOMDTO00013();            
            LoanEntity.Lno = this.view.LoanNo;            
            LoanEntity.Amount = this.view.RepaymentAmount;
            return LoanEntity;
        }
      //  string currentBal { get; set; }
        string currency { get; set; }
        string aType { get; set; }
        string accountSign { get; set; }
        string customerName { get; set; }
        string aCodeFromCOASetup { get; set; }
        IList<LOMDTO00013> GridDataSource = new List<LOMDTO00013>();
        #endregion

        #region validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    IList<LOMDTO00013> LegalList = CXClientWrapper.Instance.Invoke<ILOMSVE00027, IList<LOMDTO00013>>(x => x.CheckLegalLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                    if (LegalList == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);  //Invalid Loan No.
                        return;
                    }
                    else
                    {
                        this.view.AccountNo = LegalList[0].AcctNo;

                        var amount = (from value in LegalList                                   
                                   select value.Amount).Sum();//cledger currentbalance
                        if (!string.IsNullOrEmpty(this.view.AccountNo))
                        {
                            //IList<PFMDTO00072> CustomerList = CXClientWrapper.Instance.Invoke<ILOMSVE00027, IList<PFMDTO00072>>(x => x.GetCustNames(this.view.AccountNo));
                            string[] CustomerList = new string[LegalList[0].NameList.Count()];
                            if (LegalList[0].NameList != null)
                                for (int i = 0; i < LegalList[0].NameList.Count() ; i++ )
                                {
                                    CustomerList[i] = LegalList[0].NameList[i];
                                }

                            if (CustomerList != null)
                            {
                                this.view.BindNameList(CustomerList);
                            }
                        }
                       
                      //  this.currentBal = LegalList[0].Bal;
                        this.view.CurrentBalance = LegalList[0].Bal.Value;
                       // this.view.CurrentBalance = amount;
                        this.currency = LegalList[0].Cur;
                        this.aType = LegalList[0].AcType;
                        this.accountSign = LegalList[0].AccountSign;
                        this.customerName = LegalList[0].NameList[0];
                       
                        
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
                }
            }
            else
            { 
                
                return;
            
            
            }
        }

        public void txtRepaymentAmount_CustomValidating(object sender, ValidationEventArgs e)
        {            
            this.GridDataSource.Clear();            
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    aCodeFromCOASetup = CXCLE00002.Instance.GetScalarObject<string>("COASetup.AccountClose.Select", new object[] { "LEGALACCU", currency, CurrentUserEntity.BranchCode, true });
                    ChargeOfAccountDTO coa = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { aCodeFromCOASetup, CurrentUserEntity.BranchCode, true });

                    //Bank Account
                    LOMDTO00013 DebitVoucher = new LOMDTO00013();
                    DebitVoucher.Lno = this.view.LoanNo;
                    DebitVoucher.DrAccountNo = aCodeFromCOASetup;
                    DebitVoucher.AType = aType;
                    DebitVoucher.AcctNo = aCodeFromCOASetup;
                    DebitVoucher.LoansDesp = coa.AccountName;
                    DebitVoucher.SAmt = this.view.RepaymentAmount;
                    DebitVoucher.Name = "Dr";
                    GridDataSource.Add(DebitVoucher);

                    //Customer Account
                    LOMDTO00013 CreditVoucher = new LOMDTO00013();
                    CreditVoucher.Lno = this.view.LoanNo;
                    CreditVoucher.DrAccountNo = aCodeFromCOASetup;
                    CreditVoucher.AType = aType;
                    CreditVoucher.AcctNo = this.view.AccountNo;
                    CreditVoucher.LoansDesp = customerName;
                    CreditVoucher.SAmt = this.view.RepaymentAmount;
                    CreditVoucher.Name = "Cr";
                    GridDataSource.Add(CreditVoucher);

                    this.view.BindGridView(GridDataSource);
                }
                catch (Exception ex)
                {                   
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                this.view.BindGridView(GridDataSource);
               
                this.view.Status = "err";
                return; 
            }
        }
    
        #endregion

        #region Method
        public void Save()
        {
            this.view.Status = string.Empty;
            if (!ValidateForm(this.GetEntity()))
            {
                return;
            }
           
            string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            CXClientWrapper.Instance.Invoke<ILOMSVE00027>(x => x.SaveLoanRepayment(GridDataSource,this.view.CurrentBalance, currency,channel, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                return;
            }
            else                
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);  //Saving Successful
            }
        }        
        #endregion
    }
}
