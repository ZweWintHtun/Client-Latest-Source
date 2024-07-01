using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
//using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00028 : AbstractPresenter, ILOMCTL00028
    {
        #region "Wire To"
        private ILOMVEW00028 view;
        public ILOMVEW00028 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00028 view)
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
            LoanEntity.Amount = this.view.DepositAmount;
            LoanEntity.DrAccountNo = this.view.DrAccountNo;
            return LoanEntity;
        }
    
        IList<LOMDTO00013> GridDataSource = new List<LOMDTO00013>();
        IList<LOMDTO00013> LegalList { get; set; }
        IList<PFMDTO00001> AccountInformationList { get; set; }
       
        #endregion

        #region Validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    LegalList = CXClientWrapper.Instance.Invoke<ILOMSVE00028, IList<LOMDTO00013>>(x => x.CheckLegalLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                    if (LegalList == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);  //Invalid Loan No.
                        return;
                    }
                    else
                    {
                        this.view.AccountNo = LegalList[0].AcctNo;
                        this.view.TypeOfLoan = LegalList[0].AcType;
                        this.view.LegalDate = LegalList[0].LegalDate.Value.ToString("dd/MM/yyyy");

                        var amount = (from value in LegalList
                                      select value.Amount).Sum();    //cledger currentbalance

                        this.view.BindNameList(LegalList);

                        this.view.CurrentBalance = amount;
                        this.SetFocus("mtxtAccountNo");
                                          
                    }
                }
                catch (Exception ex)
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
                    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
                    //this.ClearControls();                    
                }
            }
            else
            { return; }
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;
            if (!string.IsNullOrEmpty(this.view.DrAccountNo))
            {
                this.view.Status = "Transfer";
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    AccountInformationList = CXClientWrapper.Instance.Invoke<ITLMSVE00010, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.View.DrAccountNo));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    else
                    {
                        if (AccountInformationList[0].CurrencyCode != LegalList[0].Cur)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00092);  //Currency of debit A/C and credit A/C should be same.
                            return;
                        }                       
                    }
                }
            }
            else
            {
                //this.view.Status = "Cash";
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);  //Invalid Account No.
            }
        }
      
        public void txtDepositAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            this.GridDataSource.Clear();
            if (e.HasXmlBaseError == false)
            {                
                //Bank Account
                LOMDTO00013 CreditVoucher = new LOMDTO00013();
                CreditVoucher.Lno = this.view.LoanNo;
                CreditVoucher.AcctNo = this.view.AccountNo;
                CreditVoucher.DrAccountNo = this.view.DrAccountNo;
                CreditVoucher.AccountSign = LegalList[0].AccountSign;
                CreditVoucher.Cur = LegalList[0].Cur;
                CreditVoucher.AType = this.view.TypeOfLoan;
                CreditVoucher.LoansDesp = LegalList[0].Name;
                CreditVoucher.SAmt = this.view.DepositAmount;                
                CreditVoucher.Name = "Cr";
                GridDataSource.Add(CreditVoucher);

                //Customer Account
                LOMDTO00013 DebitVoucher = new LOMDTO00013();
                DebitVoucher.Lno = this.view.LoanNo;
                DebitVoucher.AcctNo = this.view.DrAccountNo;
                DebitVoucher.DrAccountNo = this.view.DrAccountNo;
                DebitVoucher.AccountSign = AccountInformationList[0].AccountSign;
                DebitVoucher.Cur = AccountInformationList[0].CurrencyCode;
                DebitVoucher.AType = this.view.TypeOfLoan;
                DebitVoucher.LoansDesp = AccountInformationList[0].Name;
                DebitVoucher.SAmt = this.view.DepositAmount;
                DebitVoucher.Name = "Dr";
                GridDataSource.Add(DebitVoucher);

                this.view.BindGridView(GridDataSource);
            }
            else 
            {
                this.view.BindGridView(GridDataSource);
                return; 
            }            
        }

        
        #endregion
         
        #region Method

        public void Save()
        {
            if(!ValidateForm(this.GetEntity()))
                return ;
            try
            {
            string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            CXClientWrapper.Instance.Invoke<ILOMSVE00028>(x => x.SaveLegalODRepayment(GridDataSource, this.view.CurrentBalance+this.view.DepositAmount, channel, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID));
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        #endregion
    }
}
