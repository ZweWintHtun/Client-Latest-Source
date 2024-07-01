using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00009:AbstractPresenter,ITCMCTL00009
    {
        #region Properties
        private ITCMVEW00009 view;
        public ITCMVEW00009 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        #endregion

        #region Methods
        private void WireTo(ITCMVEW00009 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetInterestEditData());
            }
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        //public void ClearFormControls()
        //{
        //    this.view.AccountNo = string.Empty;
        //    this.view.LoansNo = string.Empty;
        //    this.view.OverdraftLimit = Decimal.Zero;
        //    this.view.LastCalculateDate = string.Empty;
        //    this.view.Rate = Decimal.Zero;
        //    this.view.InterestOfLastDate = Decimal.Zero;
        //    this.view.InterestMonth1 = Decimal.Zero;
        //    this.view.InterestMonth2 = Decimal.Zero;
        //    this.view.InterestMonth3 = Decimal.Zero;
        //    this.view.InterestTotal = Decimal.Zero;
        //    this.SetFocus("txtLoansNo");
        //    //this.view.Month1 = string.Empty;
        //    //this.view.Month2 = string.Empty;
        //    //this.view.Month3 = string.Empty;

        //}

        public TCMDTO00045 GetInterestEditData()
        {
            TCMDTO00045 interestEditDTO = new TCMDTO00045();
           // interestEditDTO.AccountNo = this.view.AccountNo;
            interestEditDTO.LoansNo = this.view.LoansNo;
            interestEditDTO.AccountNo = this.view.AccountNo;
            interestEditDTO.OverdraftLimit = this.view.OverdraftLimit;
            interestEditDTO.LastCalculateDate = this.view.LastCalculateDate;
            interestEditDTO.Rate = this.view.Rate;
            interestEditDTO.InterestOfLastDate = this.view.InterestOfLastDate;
            interestEditDTO.InterestMonth1 = this.view.InterestMonth1;
            interestEditDTO.InterestMonth2 = this.view.InterestMonth2;
            interestEditDTO.InterestMonth3 = this.view.InterestMonth3;
            interestEditDTO.InterestTotal = this.view.InterestTotal;
            interestEditDTO.Column_1 = this.view.Month1;
            interestEditDTO.Column_2 = this.view.Month2;
            interestEditDTO.Column_3 = this.view.Month3;
            interestEditDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
            interestEditDTO.BranchCode = CurrentUserEntity.BranchCode;
            return interestEditDTO;
        }

        public void Save()
        {            
            if (this.ValidateForm(this.GetInterestEditData()))
        
            {                
              TCMDTO00045 interestDTO = this.GetInterestEditData();
              CXClientWrapper.Instance.Invoke<ITCMSVE00009>(x => x.Save(interestDTO,this.view.FormName));
              if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
              {
                  this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                  this.view.ClearControls();
              }
              else
              {
                  this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                  this.view.ClearFormControls();
                  
              }
            }
        }
        #endregion

        #region Validation Logic
        public void txtLoansNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            TLMDTO00018 LoanDTo = new TLMDTO00018();
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula

                try
                {
                   // Nullable<CXDMD00011> accountType;
                 //  if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    LoanDTo = CXClientWrapper.Instance.Invoke<ITCMSVE00009, TLMDTO00018>(x => x.isValidLoanNo(this.view.LoansNo, CurrentUserEntity.BranchCode, this.view.FormName));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoansNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);

                        this.view.ClearControls();
                        return;
                    }
                    else  
                    {
                   
                     TCMDTO00045 info = CXClientWrapper.Instance.Invoke<ITCMSVE00009, TCMDTO00045>(x => x.GetAccountNoInformation(this.view.LoansNo,LoanDTo.AccountNo, CurrentUserEntity.BranchCode, this.view.FormName, this.view.Month1));
                     
                          
                        // LoanDTo = CXClientWrapper.Instance.Invoke<ITCMSVE00009, TLMDTO00018>(x => x.isValidLoanNo(this.view.LoansNo, CurrentUserEntity.BranchCode));
                     if (info != null && !CXClientWrapper.Instance.ServiceResult.ErrorOccurred && this.view.isValidate)
                        {   info.AccountNo = LoanDTo.AccountNo;
                            this.view.LoansNo = info.LoansNo;
                            this.view.AccountNo = info.AccountNo;
                            this.view.OverdraftLimit = info.OverdraftLimit;
                            this.view.LastCalculateDate = CXCOM00006.Instance.GetDateFormat(Convert.ToDateTime(info.LastCalculateDate)).ToString(); ;
                            this.view.Rate = info.Rate;
                            this.view.InterestOfLastDate = info.InterestOfLastDate;
                            this.view.InterestMonth1 = info.InterestMonth1;
                            this.view.InterestMonth2 = info.InterestMonth2;
                            this.view.InterestMonth3 = info.InterestMonth3;
                            this.view.InterestTotal = info.InterestMonth1 + info.InterestMonth2 + info.InterestMonth3;
                            this.view.LabelTotalInterest = "Total Interest Up to " + this.view.LastCalculateDate;
                            this.view.DisableControls();
                           // this.view.SetFocus();
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoansNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //this.view.AccountNo = string.Empty;
                            //this.view.OverdraftLimit = 0;
                            //this.view.InterestOfLastDate = 0;
                            //this.view.LastCalculateDate = string.Empty;
                           // this.view.ClearControls();
                            return;
                        }
                    }
                
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoansNo"), ex.Message);                    
                }
            }
            else
            {

                return;
            }
        }

     




        #endregion
    }
}
