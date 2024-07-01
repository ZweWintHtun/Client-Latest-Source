// <copyright file="LOMCTL00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> TAK </CreatedUser>
// <CreatedDate>12-01-2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;
using System.Globalization;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00013 : AbstractPresenter, ILOMCTL00013
    {
        #region "Properties"
        ILOMVEW00013 view;
        public ILOMVEW00013 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(ILOMVEW00013 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        #endregion

        #region "Variables & Lists"
        
        public IList<TLMDTO00018> LoansList { get; set; }
        public TLMDTO00018 loanDto {get;set;}
       
        #endregion

        #region "Validation Methods"
        public TLMDTO00018 GetEntity()
        {
            TLMDTO00018 entity = new TLMDTO00018();
            entity.Lno = this.view.LoanNo;
            entity.AccountNo = this.view.AccountNo;
            return entity;
        }

        public bool ValidateForm()
        {
            return this.ValidateForm(this.GetEntity());
        }

        public void ClearAllCustomErrors()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError) return;
          
            loanDto = this.SelectByLoanNo(this.view.LoanNo);

            if (loanDto != null)
            {
                if (this.loanDto.CloseDate != null && !this.loanDto.CloseDate.Equals(System.DateTime.MinValue))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //already close
                    this.SetFocus("txtLoanNo");
                    return;
                }
                else if (this.loanDto.LegalCase == true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90066, this.view.LoanNo);  // Legal Case is already exist !!! 
                    this.SetFocus("txtLoanNo");
                    return;
                }
                else if (this.loanDto.NPLCase == true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90078, this.view.LoanNo);  // MV90078 => Release non performanace
                    return;
                }

                this.view.AccountNo = loanDto.AccountNo;
                this.view.Type = loanDto.AType;
                this.view.Amount = Convert.ToDecimal(loanDto.SAmount);

                this.view.OutstandingInt = loanDto.OutstandingInt;
                this.view.OutstandingChg = loanDto.OutstandingChg;
                this.view.PenlityFees = loanDto.PenlityFees;
                this.view.Total = Convert.ToDecimal(loanDto.SAmount);
                this.view.ServiceCharges = loanDto.ServiceCharges;
                this.view.Interest = loanDto.Interest;
                this.view.CommitmentFees = loanDto.CommitmentFees;
                this.view.BindInfo(loanDto.CaofList);

                #region oldCode
                //caofList = SelectCAOFData(loanDto.AccountNo);
                //legalIntList = SelectlegalIntData(loanDto.Lno);
                //commitList = SelectCommitFeeByLoanNo(loanDto.AccountNo, loanDto.Lno);
                //liList = SelectLIByLoanNo(loanDto.AccountNo, loanDto.Lno);
                //schargeList = SelectSChargeByLoanNo(loanDto.AccountNo, loanDto.Lno);
                //if (!legalIntList.Equals(null) && !legalIntList.Count.Equals(0))
                //{
                //    this.view.OutstandingInt = legalIntList.Where(x => x.Type == "INTEREST" && x.LNo == loanDto.Lno).Sum(x => x.Amount);
                //    this.view.OutstandingChg = legalIntList.Where(x => x.Type == "CHARGES" && x.LNo == loanDto.Lno).Sum(x => x.Amount);
                //    this.view.PenlityFees = this.view.OutstandingInt * 13 / 100 / 366 * (DateTime.Now.Subtract(legalIntList[0].Date_Time).Days);
                //    this.view.Total = Convert.ToDecimal("0") +         //Where 0 for ODInt
                //                         Convert.ToDecimal("0") +         //Where 0 for LoanInt                                                            
                //                         this.view.OutstandingInt +
                //                         this.view.OutstandingChg +
                //                         this.view.PenlityFees +
                //                         this.view.ServiceCharges +                                    
                //                         this.view.CommitmentFees;
                //}
                //else
                //{
                //    this.view.OutstandingChg = 0;
                //    this.view.OutstandingInt = 0;
                //    this.view.PenlityFees = 0;
                //    this.view.ServiceCharges = 0;
                //}

                //if (!commitList.Equals(null) && !commitList.Count.Equals(0))
                //{
                //    this.view.CommitmentFees = commitList.Where(x => x.LNo == loanDto.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12);
                //}
                //else
                //{
                //    this.view.CommitmentFees = 0;
                //}

                //if (!liList.Equals(null) && !liList.Count.Equals(0))
                //{
                //    this.view.Interest = liList.Where(x => x.LNo == loanDto.Lno).Sum(x => Convert.ToDecimal(x.Q1 + x.Q2 + x.Q3 + x.Q4));
                //}
                //else
                //{
                //    this.view.Interest = 0;
                //}

                //if (!schargeList.Equals(null) && !schargeList.Count.Equals(0))
                //{
                //    this.view.ServiceCharges = schargeList.Where(x => x.LNo == loanDto.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12);
                //}
                //else
                //{
                //    this.view.ServiceCharges = 0;
                //}
                #endregion
               
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);     //Invalid Loans No.
                this.SetFocus("txtLoanNo");
            }
        }
        #endregion

        #region "Methods"
        public TLMDTO00018 SelectByLoanNo(string loanNo)
        {
            TLMDTO00018 loanList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, TLMDTO00018>(x => x.SelectByLoanNo(loanNo, CurrentUserEntity.BranchCode));            
            return loanList;
        }

        public IList<PFMDTO00017> SelectCAOFData(string acctNo)
        {
            IList<PFMDTO00017> caofList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, PFMDTO00017>(x => x.SelectCAOFData(acctNo));

            return caofList;
        }

        public IList<MNMDTO00012> SelectlegalIntData(string loanNo)
        {
            IList<MNMDTO00012> legalIntList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, MNMDTO00012>(x => x.SelectlegalIntData(loanNo));

            return legalIntList;
        }

        public IList<MNMDTO00011> SelectCommitFeeByLoanNo(string accountNo, string loanNo)
        {
            IList<MNMDTO00011> commitList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, MNMDTO00011>(x => x.SelectCommitFeeByLoanNo(accountNo, loanNo));

            return commitList;
        }

        public IList<LOMDTO00021> SelectLIByLoanNo(string accountNo, string loanNo)
        {
            IList<LOMDTO00021> liList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, LOMDTO00021>(x => x.SelectLIByLoanNo(accountNo, loanNo));

            return liList;
        }

        public IList<MNMDTO00027> SelectSChargeByLoanNo(string accountNo, string loanNo)
        {
            IList<MNMDTO00027> schargeList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, MNMDTO00027>(x => x.SelectSChargeByLoanNo(accountNo, loanNo));

            return schargeList;
        }

        public void Save(TLMDTO00018 loan, IList<PFMDTO00017> caof, IList<MNMDTO00012> legal, IList<MNMDTO00011> commit, IList<LOMDTO00021> li, IList<MNMDTO00027> scharge,
            string cur, DateTime SettlementDate, ChargeOfAccountDTO CoaACName, string creditVoucher, string debitVoucher, string creditTranCode, string debitTranCode, bool isOD, decimal amount)
        {
            loan.UpdatedDate = DateTime.Now;
            loan.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            CXClientWrapper.Instance.Invoke<ITLMSVE00018>(x => x.SaveCloseAC(loan,
                                                                                caof,
                                                                                legal,
                                                                                commit,
                                                                                li,
                                                                                scharge,
                                                                                cur,
                                                                                SettlementDate,
                                                                                CoaACName,
                                                                                creditVoucher,
                                                                                debitVoucher,
                                                                                creditTranCode,
                                                                                debitTranCode,
                                                                                isOD,
                                                                                amount
                                                                            ));
        }
        #endregion
    }
}
