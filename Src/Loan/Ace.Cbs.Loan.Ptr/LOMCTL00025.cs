//----------------------------------------------------------------------
// <copyright file="LOMCTL00014" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>13.01.2015</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00025 : AbstractPresenter, ILOMCTL00025
    {
        #region "Wire To"
        public TLMDTO00018 LoanDTO { get; set; }
        public PFMDTO00028 cledgerDTO { get; set; }
        private ILOMVEW00025 view;
        public ILOMVEW00025 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00025 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private LOMDTO00025 GetEntity()
        {
            LOMDTO00025 LoanEntity = new LOMDTO00025();
            LoanEntity.LoanNo = this.view.LoanNo;
            LoanEntity.RepaymentAmount = this.view.RepaymentAmount;
            return LoanEntity;
        }
        #endregion

        #region MainMethod       

        public TLMDTO00018 SaveDecrease(int userId, string userName, string branchCode)
        {
            string acode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), LoanDTO.Currency, branchCode, true });
            LoanDTO.CreditAccountCode = acode; //LAE001
            LoanDTO.CreditAccountDesp = this.view.CustomerName; //Customer' Name
            LoanDTO.AType = this.view.CreditAccountCode ; // AKA003
            LoanDTO.BType = this.view.CreditAccountDesp ; // Loans To Construction
            LoanDTO.SAmount = this.view.TotalOutstanding;
            LoanDTO.LastRepaymentNo = (Convert.ToInt32(this.view.RepaymentNo)+1).ToString();
            LoanDTO.CreatedDate = Convert.ToDateTime(LoanDTO.VoucherDate); //DateTime.Now;
            LoanDTO.CreatedUserId = userId;
            LoanDTO.SourceBranchCode = branchCode;
            LoanDTO.Assessor = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel); //Channel
            LoanDTO.ACSign = this.view.AccountSign;
            LoanDTO.OldIntRate = this.view.Rate;//Added by HMW (26-04-2023)
            LoanDTO.NewIntRate = this.view.Rate;//Added by HMW (26-04-2023)
            //TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayLoan(LoanDTO, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount, (this.view.RepaymentAmount + this.view.InterestOnSamt + this.view.LateFee + this.view.OutstandingInterest), CurrentUserEntity.CurrentUserName,this.view.Amount,CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode,this.view.CBal,this.view.CurrentSAmtDate));
            //TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayDecreaseAmount(LoanDTO,this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount,false,this.view.TermNo));
            //TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayLoan(LoanDTO, this.view.FullSettlement, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount, CurrentUserEntity.CurrentUserName,CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
            //TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayDecreaseAmount(LoanDTO, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount,this.view.InterestOnSamt,CurrentUserEntity.CurrentUserName,this.view.acctInfoList, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.view.CBal,this.view.CurrentSAmtDate,int termNo));
            TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayDecreaseAmount(LoanDTO, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount, this.view.InterestOnSamt, LoanDTO.UserNo, this.view.acctInfoList, userId, LoanDTO.SourceBranchCode, this.view.CBal, this.view.CurrentSAmtDate, this.view.TermNo));
            return dto;
        }

        public TLMDTO00018 SaveIncrease(int userId, string userName, string branchCode)
        {
            //string acode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), LoanDTO.Currency, branchCode, true });
            //LoanDTO.CreditAccountCode = acode; //LAE001
            //LoanDTO.CreditAccountDesp = this.view.CustomerName; //Customer' Name
            //LoanDTO.AType = this.view.CreditAccountCode; // AKA003
            //LoanDTO.BType = this.view.CreditAccountDesp; // Loans To Construction
            //LoanDTO.SAmount = this.view.TotalOutstanding;
            //LoanDTO.LastRepaymentNo = (Convert.ToInt32(this.view.RepaymentNo) + 1).ToString();
            //LoanDTO.CreatedDate = DateTime.Now;
            //LoanDTO.CreatedUserId = userId;
            //LoanDTO.SourceBranchCode = branchCode;
            //LoanDTO.Assessor = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel); //Channel

            LoanDTO.LastRepaymentNo = (Convert.ToInt32((String.IsNullOrWhiteSpace(this.view.RepaymentNo)) ? "0" : this.view.RepaymentNo) + 1).ToString();
            LoanDTO.CreatedDate = Convert.ToDateTime(LoanDTO.VoucherDate); // DateTime.Now;
            LoanDTO.CreatedUserId = userId;
            LoanDTO.SourceBranchCode = branchCode;
            LoanDTO.Assessor = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel); //Channel
            LoanDTO.ACSign = this.view.AccountSign;
            LoanDTO.OldIntRate = this.view.OldIntRate;//Added by HMW (04-04-2023)
            LoanDTO.NewIntRate = this.view.NewIntRate;//Added by HMW (04-04-2023)
            
            TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.RepayIncreaseAmount(LoanDTO, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount, this.view.InterestOnSamt, userName, this.view.InterestOnSamt, this.view.RepaymentAmount, userId, branchCode, this.view.CBal, this.view.CurrentSAmtDate, this.view.TermNo, this.view.SCharge, this.view.Rate, this.view.DocFee));
            if (dto.ResultCode == "2222")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00070);//Please check the "System Date" and "Settlement Date" First!
                return null;
            }
            else
                return dto;
        }

        public string CheckingCasesBLLimitChange(string blNo,string sourceBr)
        {
            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00025, string>(x =>x.CheckingCasesBLLimitChange(blNo,sourceBr));
            return str;
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion

        //Added by HMW at 29-08-2019
        public void Call_AccountInformationEnquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmLOMVEW00025", this.View.AccountNo });
        }

        #region ValidationMethod
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    GetLoanInfo();
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
                }

              //  this.SetFocus("txtLoanNo");
            }
            else
            { return; }
        }

        public void txtRepaymentAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            //if (e.HasXmlBaseError == false)
            //{
            //    try
            //    {
            //        if (this.view.RepaymentCheck() == true || this.view.RepaymentAmount!=0 || this.view.RepaymentAmount.ToString()!= "*")
            //        {
            //            LOMDTO00401 outLoanDto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, LOMDTO00401>(x => x.GetLoansInterestLateFeeTODByRepayAmt(this.view.LoanNo, this.view.RepaymentAmount, CurrentUserEntity.BranchCode));
            //            if (outLoanDto == null || outLoanDto.ResultCode != "0000")
            //            {
            //                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No.
            //                this.SetFocus("txtRepaymentAmount");
            //                return;
            //            }
            //            this.view.InterestOnSamt = Convert.ToDecimal(outLoanDto.InterestOnSamt);
            //            this.view.LateFee = Convert.ToDecimal(outLoanDto.TotalLateFee);
            //            this.view.OutstandingInterest = Convert.ToDecimal(outLoanDto.TOD);
            //            this.view.CurrentSAmtDate = Convert.ToDateTime(outLoanDto.CurrentSanDate);                        
            //            this.view.RepaymentNo = outLoanDto.RepayNo;
            //            if (this.view.TermNo == 0) //For Limit Change in Initial Term
            //            {
            //                this.view.TermNo = outLoanDto.TermNo + 1;
            //            }
            //            else
            //            {
            //                this.view.TermNo = outLoanDto.TermNo;
            //            }
            //            if (this.view.DecreaseAmt == true)
            //            {
            //                this.view.TotalAmt = Convert.ToDecimal(outLoanDto.InterestOnSamt) + Convert.ToDecimal(outLoanDto.TotalLateFee) + Convert.ToDecimal(outLoanDto.TODAmt) + Convert.ToDecimal(this.view.RepaymentAmount);
            //                this.view.DataBindAccountList();
            //            }
            //            else if (this.view.IncreaseAmt == true)
            //            {
            //                this.view.TotalAmt = Convert.ToDecimal(outLoanDto.InterestOnSamt) + Convert.ToDecimal(outLoanDto.TotalLateFee) + Convert.ToDecimal(outLoanDto.TODAmt);
            //                this.view.Rate = Convert.ToDecimal(outLoanDto.IntRate);
            //            }
                        
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtRepaymentAmount"), "MV90079"); //Invalid Repayment Amount
            //    }

            //   // this.SetFocus("txtRepaymentAmount");
            //}
            //else
            //{ return; }
        }

        public bool GetLoanInfo()
        {
            try
            {
                LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));
                
                if (LoanDTO == null || LoanDTO.ResultCode == "0001")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No.
                    this.SetFocus("txtLoanNo");
                    return false;                   
                }

                if (LoanDTO.ResultCode == "0002")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90085);// Loans Account Only 
                    this.SetFocus("txtLoanNo");
                    return false;                    
                }

                if (LoanDTO.ResultCode == "0003")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90087);// Not vouchered yet 
                    this.SetFocus("txtLoanNo");
                    return false;                    
                }

                if (LoanDTO.ResultCode == "0004")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057);// Loans Account Closed 
                    this.SetFocus("txtLoanNo");
                    return false; 
                }

                if (LoanDTO.ResultCode == "0005")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90086);//No Sanction Amount
                    this.SetFocus("txtLoanNo");
                    return false; 
                }

                if (LoanDTO.ResultCode == "0006")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00137);//This Account is in Legal Case.
                    this.SetFocus("txtLoanNo");
                    return false;
                }
               
                this.view.AccountNo = LoanDTO.AccountNo;
                this.view.TotalOutstanding = LoanDTO.SAmount.Value;
                this.view.TypeOfSecurity = LoanDTO.Loans_Type;
                this.view.WithdrawableBalance = LoanDTO.WithdrawableBalance;
                this.view.CreditAccountDesp = LoanDTO.CreditAccountDesp;
                this.view.InterestAccountDesp = LoanDTO.InterestAccountDesp;

                //Commented and Modified by HMW at 02-Sept-2019 : To show all customer name line by line                
                //this.view.CustomerName = customerName;
                this.view.CustomerName = this.GetCustomerName_LinebyLine_Wordbreak(LoanDTO.Name);
                /*
                if (LoanDTO.AccountNo.Substring(5, 1) != "3" && LoanDTO.Name.Contains(", "))
                {
                    this.view.CustomerName = LoanDTO.Name.Replace(", ", ",\n");//For Individual and Joint Account (New Line)
                }
                else//For Company Name (New Line with word break)
                {
                    int lineNo = (int)Math.Ceiling((decimal)LoanDTO.Name.Length / 26);
                    this.view.CustomerName = null;

                    if (lineNo == 1)//**** Company Name (Single Line) ****
                    {
                        this.view.CustomerName = LoanDTO.Name;
                    }
                    else//**** Company Name (Multi Line) ****
                    {
                        int idx = LoanDTO.Name.LastIndexOf(' ');
                        if (idx != -1)
                        {
                            string temp = null, name = null;
                            int startPosition = 0;

                            for (int i = 0; i < lineNo; i++)// Start Word Break
                            {
                                if (LoanDTO.Name.Substring(startPosition, 1) == " " && i == lineNo - 1) //TempString start with " " and it is the last string to concact
                                {
                                    startPosition = startPosition + 1;
                                    temp = LoanDTO.Name.TrimStart().Substring(startPosition, temp.Length);
                                    this.view.CustomerName = this.view.CustomerName + temp;
                                    break;
                                }
                                else if (LoanDTO.Name.Substring(startPosition, 1) == " ")//TempString start with " "
                                {
                                    startPosition = startPosition + 1;
                                    temp = LoanDTO.Name.TrimStart().Substring(startPosition, 26);
                                }
                                else//TempString is normal (not start with "space")
                                    temp = LoanDTO.Name.TrimStart().Substring(startPosition, 26);

                                if (idx > 26)
                                {
                                    idx = temp.LastIndexOf(' ');
                                    name = temp.TrimStart().Substring(0, idx);
                                    name = name + "\n";// +LoanDTO.Name.Substring(idx + 1);

                                    startPosition += idx;

                                    temp = LoanDTO.Name.Substring(startPosition + 1);//Initial for the next line
                                    idx = temp.LastIndexOf(' ');
                                }
                                else
                                {
                                    name = temp.TrimStart().Substring(0, idx);
                                    name = name + "\n";

                                    startPosition += idx;
                                    temp = LoanDTO.Name.Substring(startPosition + 1);//Initial for the next line
                                    idx = temp.LastIndexOf(' ');
                                }
                                this.view.CustomerName = this.view.CustomerName + name;
                            }
                        }
                    }//end of multiline
                }
                */
                //this.view.CustomerName = LoanDTO.Name;
                this.view.BLType = LoanDTO.BType;
                this.view.InterestAccountCode = LoanDTO.InterestAccountCode;
                this.view.CreditAccountCode = LoanDTO.CreditAccountCode;
                this.view.Currency = LoanDTO.Currency;
                this.SetEnableDisable("txtRepaymentAmount", true);                       
                //this.SetFocus("txtRepaymentAmount");
                this.SetFocus("rdoIncrease");
                PFMDTO00028 cledgerDTO = CheckCBalMinBalAmoutByAcctno();
                this.view.CurrentBal=cledgerDTO.CurrentBal;
                this.view.MinimumBalance=cledgerDTO.MinimumBalance;
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
            }
            return true;
        }

        public PFMDTO00028 CheckCBalMinBalAmoutByAcctno()
        {
            PFMDTO00028 cledgerDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00025,PFMDTO00028>(x => x.CheckCBalMinBalAmoutByAcctno(this.view.AccountNo));
            return cledgerDTO;
        }
        public void CheckRepayAmount()
        {
            try
            {
                LOMDTO00401 outLoanDto=new LOMDTO00401();
                //if (this.view.RepaymentCheck() == true || this.view.RepaymentAmount != 0 || this.view.RepaymentAmount.ToString() != "*")
                //{
                if (view.LC_ChangeState == "D")
                {
                    outLoanDto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, LOMDTO00401>(x => x.GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(this.view.LoanNo, this.view.RepaymentAmount, CurrentUserEntity.BranchCode));
                    this.view.OldIntRate = Convert.ToDecimal(outLoanDto.IntRate);//Added by HMW (26-04-2023) 
                    this.view.NewIntRate = Convert.ToDecimal(outLoanDto.IntRate);//Added by HMW (26-04-2023)
                }
                else if (view.LC_ChangeState == "I")
                {
                    //Modify by HMW : 27-03-2022 : For New Interest Rate Change Issue
                    //outLoanDto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, LOMDTO00401>(x => x.GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(this.view.LoanNo, this.view.RepaymentAmount, CurrentUserEntity.BranchCode));
                    
                    outLoanDto = CXClientWrapper.Instance.Invoke<ILOMSVE00025, LOMDTO00401>(x => x.GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(this.view.LoanNo, this.view.RepaymentAmount, this.view.Rate, CurrentUserEntity.BranchCode));
                    this.view.OldIntRate = Convert.ToDecimal(outLoanDto.Old_IntRate);//Added by HMW (25-04-2023) 
                    this.view.NewIntRate = Convert.ToDecimal(outLoanDto.New_IntRate);//Added by HMW (25-04-2023)
                }
                    if (outLoanDto == null || outLoanDto.ResultCode != "0000")
                    {
                        
                        if (outLoanDto.ResultCode == "1111")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90191);//Limit Change Not Allowed After Installment Auto Pay Process!
                            this.SetFocus("txtRepaymentAmount");
                            return;
                        }
                        else if (outLoanDto == null || outLoanDto.ResultCode != "1111")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No.
                            this.SetFocus("txtRepaymentAmount");
                            return;
                        }
                    }                    
                    this.view.InterestOnSamt = Convert.ToDecimal(outLoanDto.InterestOnSamt);
                    this.view.LateFee = Convert.ToDecimal(outLoanDto.TotalLateFee);
                    this.view.OutstandingInterest = Convert.ToDecimal(outLoanDto.TOD);
                    this.view.CurrentSAmtDate = Convert.ToDateTime(outLoanDto.CurrentSanDate);
                    this.view.RepaymentNo = outLoanDto.RepayNo;
                    
                    if (outLoanDto.TermNo == 0) //For Limit Change in Initial Term
                    {
                        this.view.TermNo = outLoanDto.TermNo + 1;
                    }
                    else
                    {
                        this.view.TermNo = outLoanDto.TermNo;
                    }
                    if (this.view.DecreaseAmt == true)
                    {
                        this.view.TotalAmt = Convert.ToDecimal(outLoanDto.InterestOnSamt) + Convert.ToDecimal(outLoanDto.TotalLateFee) + Convert.ToDecimal(outLoanDto.TODAmt) + Convert.ToDecimal(this.view.RepaymentAmount);
                        this.view.DataBindAccountList();
                    }
                    else if (this.view.IncreaseAmt == true)
                    {
                        this.view.TotalAmt = Convert.ToDecimal(outLoanDto.InterestOnSamt) + Convert.ToDecimal(outLoanDto.TotalLateFee) + Convert.ToDecimal(outLoanDto.TODAmt);
                        //this.view.Rate = Convert.ToDecimal(outLoanDto.IntRate);
                        if (outLoanDto.New_IntRate != null || outLoanDto.New_IntRate != 0)
                        {
                            this.view.Rate = Convert.ToDecimal(outLoanDto.New_IntRate);//Modify by HMW at 06-04-2023 : For Old Interst Rate Binding
                        }
                        else
                            this.view.Rate = Convert.ToDecimal(outLoanDto.Old_IntRate);//Modify by HMW at 18-05-2023
                    }

                }
            //}
            catch (Exception ex)
            {
                //this.SetCustomErrorMessage(this.GetControl("txtRepaymentAmount"), "MV90079"); //Invalid Repayment Amount
            }

        }
        
        //No Use. Comment by HMW at 18-05-2023 (I replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling
        /*
        public TLMDTO00018 GetNewInterestForNewRateLCIncrease(string intRate, string Lno, decimal RepayAmt, string branchCode)
        {
            TLMDTO00018 result = CXClientWrapper.Instance.Invoke<ILOMSVE00025, TLMDTO00018>(x => x.GetNewInterestForNewRateLCIncrease(intRate,Lno,RepayAmt,branchCode));
            return result;
        }
        */

        //added by SHO [22-Nov-21] for Project loan type separate
        public  LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string LoanNo, decimal RepaymentAmount, string BranchCode)
        {
            LOMDTO00401 loanCode = CXClientWrapper.Instance.Invoke<ILOMSVE00025, LOMDTO00401>(x => x.GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(LoanNo, RepaymentAmount, BranchCode));
            return loanCode;
           
        }

        #region GetCustomerName_LinebyLine_Wordbreak ==> Created by HMW at 02-Sept-2019 : To show all customer name line by line (Word Break)
        public string GetCustomerName_LinebyLine_Wordbreak(string originalCustomerName)
        {
            string customerName = "";
            if (LoanDTO.AccountNo.Substring(5, 1) != "3" && originalCustomerName.Contains(", "))
            {
                customerName = originalCustomerName.Replace(", ", ",\n");//For Individual and Joint Account (New Line)
            }
            else//For Company Name (New Line with word break)
            {
                int lineNo = (int)Math.Ceiling((decimal)originalCustomerName.Length / 26);
                customerName = null;

                if (lineNo == 1)//**** Company Name (Single Line) ****
                {
                    customerName = originalCustomerName;
                }
                else//**** Company Name (Multi Line) ****
                {
                    int idx = originalCustomerName.LastIndexOf(' ');
                    if (idx != -1)
                    {
                        string tempStr = "", tempName = "";
                        int startPosition = 0;

                        for (int i = 0; i < lineNo; i++)// Start Word Break
                        {
                            if (originalCustomerName.Substring(startPosition, 1) == " " && i == lineNo - 1) //TempString start with " " and it is the last string to concact
                            {
                                startPosition = startPosition + 1;
                                tempStr = originalCustomerName.TrimStart().Substring(startPosition, tempStr.Length);
                                customerName = customerName + tempStr;
                                break;
                            }
                            else if (originalCustomerName.Substring(startPosition, 1) == " ")//TempString start with " "
                            {
                                startPosition = startPosition + 1;
                                tempStr = originalCustomerName.TrimStart().Substring(startPosition, 26);
                            }
                            else//TempString is normal (not start with "space")
                                tempStr = originalCustomerName.TrimStart().Substring(startPosition, 26);

                            if (idx > 26)
                            {
                                idx = tempStr.LastIndexOf(' ');
                                tempName = tempStr.TrimStart().Substring(0, idx);
                                tempName = tempName + "\n";

                                startPosition += idx;

                                tempStr = originalCustomerName.Substring(startPosition + 1);//Initial for the next line
                                idx = tempStr.LastIndexOf(' ');
                            }
                            else
                            {
                                tempName = tempStr.TrimStart().Substring(0, idx);
                                tempName = tempName + "\n";

                                startPosition += idx;
                                tempStr = originalCustomerName.Substring(startPosition + 1);//Initial for the next line
                                idx = tempStr.LastIndexOf(' ');
                            }
                            customerName = customerName + tempName;
                        }
                    }
                }//end of multiline
            }
            return customerName;
        }
        #endregion
    #endregion
    }   

}
