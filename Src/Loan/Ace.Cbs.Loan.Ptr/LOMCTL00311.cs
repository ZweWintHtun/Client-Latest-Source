using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00311 : AbstractPresenter, ILOMCTL00311
    {
        #region Constructor
        LOMCTL00311()
        {
            this.BranchCode = CurrentUserEntity.BranchCode;
        }
        #endregion

        #region Properties

        ILOMVEW00311 view;
        public ILOMVEW00311 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }
        private void wierTo(ILOMVEW00311 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetEntity());
            }
        }

        public string LoanNo { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        public IList<LOMDTO00012> penalList { get; set; }
        public LOMDTO00311 loansdto { get; set; }
        public string BranchCode { get; set; }
        public string Acsign { get; set; }
        public string Guarantee_Address { get; set; }
        public IList<PFMDTO00072> AccountInfoList { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }

        #endregion

        #region ValidationMethods

        public LOMDTO00311 GetEntity()
        {
            LOMDTO00311 entity = new LOMDTO00311();
            // entity.Lno = this.view.LoanNo;
            entity.ACNo = this.view.AccountNo;
            //entity.IntRate = this.view.RepaymentPeriod;
            entity.SCharges = Convert.ToDecimal(this.view.RepaymentPeriod);
            entity.GuarantorCompanyName = this.view.GuarantorCompanyName;
            return entity;
        }

        public void ClearAllCustomErrors()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool CheckPersonalLoanAccountNo(string acctNo, string formname)
        {
            try
            {
                if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode.Trim())
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        TLMDTO00018 tLMDTO00018 = CXClientWrapper.Instance.Invoke<ILOMSVE00405, TLMDTO00018>(x => x.CountofLoan_byAccountNo(this.View.AccountNo, "PL"));

                        if (tLMDTO00018.Loans_Type.Equals(""))
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046); ;
                            return false;
                        }
                        else
                        {
                            if (formname.Contains("Entry"))
                            {
                                if (tLMDTO00018.RCount > 0)
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90233);
                                    return false;
                                }
                            }
                            /*
                            else // Edit
                            {
                                if (tLMDTO00018.RCount == 0)
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90235);
                                    return false;
                                }
                            }
                            */
                            AccountInfoList = new List<PFMDTO00072>();
                            AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AccountNo));

                            if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                                if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.CurrentAccountNo}
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode, new object[] { this.View.AccountNo }); //Invalid Account No.
                                    //this.SetFocus("mtxtAccountNo");
                                    return false;
                                }

                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                    //this.SetFocus("mtxtAccountNo");
                                    return false;
                                }
                            }
                            else if (AccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
                                //this.SetFocus("mtxtAccountNo");
                                return false;
                            }
                            else
                            {
                                Acsign = AccountInfoList[0].AccountSignature;
                                this.view.BindAccountInfo(AccountInfoList);
                            }
                        }

                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        //this.SetFocus("mtxtAccountNo");
                        return false;
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046); ;
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                CXUIMessageUtilities.ShowMessageByCode(ex.Message);
                return false;
            }
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (!e.HasXmlBaseError && !this.view.isSaveValidate)
            {
                try
                {
                    if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        Nullable<CXDMD00011> accountType;
                        if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                        {
                            AccountInfoList = new List<PFMDTO00072>();
                            AccountInfoList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<PFMDTO00072>>(x => x.IsValidForLoanAcctno(this.View.AccountNo));

                            if (AccountInfoList.Count < 1 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                string msgCode = CXClientWrapper.Instance.ServiceResult.MessageCode;

                                if (msgCode == "MV00056" || msgCode == "MV90069")//new object[]{this.linkAccountView.CurrentAccountNo}
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode, new object[] { this.View.AccountNo }); //Invalid Account No.
                                    this.SetFocus("mtxtAccountNo");
                                }

                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(msgCode);
                                    this.SetFocus("mtxtAccountNo");
                                }
                            }
                            else if (AccountInfoList[0].CurrencyCode != this.view.CurrencyCode)
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode }); //Currency of this account should be {0}.
                                this.SetFocus("mtxtAccountNo");
                            }
                            else
                            {
                                Acsign = AccountInfoList[0].AccountSignature;
                                this.view.BindAccountInfo(AccountInfoList);
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00224, new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode }); //Invalid Account No {0} for Branch {1}.
                        this.SetFocus("mtxtAccountNo");
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
        }

        //public void txtPenalDuration_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    // if xml base error does not exist.
        //    if (!e.HasXmlBaseError)
        //    {
        //        try
        //        {
        //            int duration = this.view.Duration;

        //            if (duration == 0)
        //                CXUIMessageUtilities.ShowMessageByCode("MV00034"); // Invalid Duration
        //            else if (duration < 5)
        //                CXUIMessageUtilities.ShowMessageByCode("MV00034"); // Invalid Duration
        //            else
        //            {
        //                penalList = new List<LOMDTO00012>();
        //                LOMDTO00012 penalDto = new LOMDTO00012();

        //                for (int i = 1; penalDto.EndDay < duration; i++) //12/4
        //                {
        //                    LOMDTO00012 Dto = new LOMDTO00012();

        //                    if (i == 1) penalDto.StartDay = i;
        //                    else penalDto.StartDay = penalDto.EndDay + 1;
        //                    penalDto.EndDay = penalDto.StartDay + 4;
        //                    if (penalDto.EndDay < duration)
        //                    {
        //                        Dto.StartDay = penalDto.StartDay;
        //                        Dto.EndDay = penalDto.EndDay;
        //                        penalList.Add(Dto);
        //                    }
        //                    else
        //                    {
        //                        Dto.StartDay = penalDto.StartDay;
        //                        Dto.EndDay = duration - Dto.StartDay;  //For the value of greater than endday 
        //                        penalList.Add(Dto);
        //                    }
        //                }

        //                this.view.BindPeanlFee(penalList);
        //                this.SetFocus("gdvPenalFee");

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.SetCustomErrorMessage(this.GetControl("txtRepaymentPeriod"), ex.Message);
        //        }
        //    }

        //    //else if(e.HasXmlBaseError == true)
        //    //{
        //    //    CXUIMessageUtilities.ShowMessageByCode("MV00034");
        //    //    this.SetFocus("txtPenalDuration");
        //    //}
        //}

        #endregion 

        #region Methods        

        public void Save(string sourceBranch)
        {
            try
            {
                if (!this.view.FormName.Contains("Entry"))
                {
                    if (!this.ValidateForm())
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90055");      //Invalid Loan No.
                        return;
                    }
                }
                LOMDTO00311 loanDto = this.view.GetViewDataForCommon;
                
                IList<LOMDTO00012> penalList = new List<LOMDTO00012>();
                //penalList = this.view.GetPenalFeeList();

                if (this.view.FormName.Contains("Entry"))
                {
                    loanDto.status = "save";
                }
                else
                {
                    loanDto.status = "update";
                }

                
                LOMDTO00313 personal_guaranteeDto = this.view.GetViewDataForGuarantee;
                personal_guaranteeDto.Active = true;
                personal_guaranteeDto.UpdatedDate = DateTime.Now;
                personal_guaranteeDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                // personal_guaranteeDto.LNo = LoanNo;

                LoanNo = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.Save_PersonalLoans(personal_guaranteeDto, loanDto, penalList, sourceBranch.Trim()));
                

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
                    this.view.isSaveValidate = false;
                }
                else
                {
                    if (this.view.FormName.Contains("Entry"))
                    {
                        this.view.LoanNo = LoanNo;
                    }
                    CXUIMessageUtilities.ShowMessageByCode("MI90001");      //Saving Successful.                    
                    this.view.isActive = false;
                    //  this.view.ClearFormControls();
                    this.view.GetFormControlSetting();
                    
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("ME90000");      //Saving Error
            }
        }

        public void BindPersonalLoanInfo()
        {
            LOMDTO00311 personalLoanInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00311, LOMDTO00311>(x => x.SelectPersonalLoanInfoByLnoAndSourceBr(this.View.LoanNo, CurrentUserEntity.BranchCode));
            if (personalLoanInfo == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                string code = CXClientWrapper.Instance.ServiceResult.MessageCode;

                if (code == "MV90069") CXUIMessageUtilities.ShowMessageByCode(code, personalLoanInfo.ACNo);    //Invalid Loan No.
                else CXUIMessageUtilities.ShowMessageByCode(code);    //Invalid Loan No.

                this.SetFocus("txtLoanNo");
            }
            else
            {
                this.view.BindPersonalLoanToView(personalLoanInfo);                
            }
        }

        public IList<LOMDTO00243> Get_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00243>>(x => x.Get_PLInfoRegisterEdit_ByAcctNo(acctNo,sourceBr));
        }

        public string Save_PLInfoRegisterEdit_ByAcctNo(string acctNo, string sourceBr, string companyName, string guaCompanyName
                                                       , string guaName, string guaNRC, string guaPhone, int createdUserId)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.Save_PLInfoRegisterEdit_ByAcctNo(acctNo, sourceBr, companyName, guaCompanyName
                                                                                        ,guaName, guaNRC, guaPhone, createdUserId));

        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 28-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion
    }
}
