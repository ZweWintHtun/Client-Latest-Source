using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Report_TLF DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00042 : EntityBase<PFMDTO00042>
    {
        public PFMDTO00042() { }
        public PFMDTO00042(decimal depositAmount)
        {
            this.Amount = depositAmount;
        }

        public PFMDTO00042(int rowCount, string viewName)
        {
            this.Row_Count = rowCount;
            this.ViewName = viewName;
        }

        public PFMDTO00042(string branchcode, string branchdesp,decimal amount)
        {
            this.SourceBranch = branchcode;
            this.BranchName = branchdesp;
            this.Amount = amount;
        }

        public PFMDTO00042(int rowCount, string viewName, string eNo, string acctNo, decimal amount, string aCode, DateTime date_time)
        {
            this.Row_Count = rowCount;
            this.ViewName = viewName;
            this.Eno = eNo;
            this.AcctNo = acctNo;
            this.Amount = amount;
            this.ACode = ACode;
            this.DATE_TIME = date_time;
        }

        public PFMDTO00042(string eNo, string acctNo, string desp, decimal amount, string userno, DateTime date_time, DateTime time, string acsign, string sourcecur, string workstation)
        {
            this.Eno = eNo;
            this.AcctNo = acctNo;
            this.Description = desp;
            this.Amount = amount;
            this.UserNo = userno;
            this.DATE_TIME = date_time;
            this.Time = time.ToShortTimeString();
            this.AccountSign = acsign;
            this.SourceCur = sourcecur;
            this.WorkStation = workstation;
        }

        public PFMDTO00042(decimal withdrawAmount, decimal depositAmount)
        {
            this.Amount = withdrawAmount;
            this.HomeAmount = depositAmount;
        }

        public PFMDTO00042(DateTime dateTime, string accountNo, string Cheque, string description, decimal withdrawAmount, decimal depositAmount)
        {
            this.CheckTime = dateTime.ToShortDateString();
            this.AcctNo = accountNo;

            this.Cheque = Cheque;
            this.Description = description;
            this.Amount = withdrawAmount;
            this.HomeAmount = depositAmount;
        }

        public PFMDTO00042(DateTime dateTime, string accountNo, string Cheque, string description, decimal withdrawAmount, decimal depositAmount, DateTime createdDate)
        {
            this.CheckTime = dateTime.ToShortDateString();
            this.AcctNo = accountNo;

            this.Cheque = Cheque;
            this.Description = description;
            this.Amount = withdrawAmount;
            this.HomeAmount = depositAmount;
            this.CreatedDate = createdDate;//Updated By HWKO ( 17-May-2017)
        }

        public PFMDTO00042(string eno)
        {
            this.Eno = eno;
        }

        public PFMDTO00042(int id, string eno, string accountNo, string description, decimal amount, string userNo, DateTime dateTime, DateTime time, string accountSign, string sourceCur, string workStation)
        {
            this.Id = id;
            this.Eno = eno;
            this.AcctNo = accountNo;
            this.Description = description;
            this.Amount = amount;
            this.UserNo = userNo;
            this.DATE_TIME = dateTime;
            this.TIME = time;
            this.AccountSign = accountSign;
            this.SourceCur = sourceCur;
            this.WorkStation = workStation;

        }

        public PFMDTO00042(int id, string eno, string accountNo, string description, decimal amount, string userNo, DateTime dateTime, DateTime time, string accountSign, string sourceCur, string workStation, string sourceBr)
        {
            this.Id = id;
            this.Eno = eno;
            this.AcctNo = accountNo;
            this.Description = description;
            this.Amount = amount;
            this.UserNo = userNo;
            this.DATE_TIME = dateTime;
            this.TIME = time;
            this.AccountSign = accountSign;
            this.SourceCur = sourceCur;
            this.WorkStation = workStation;
            this.SourceBranch = sourceBr;
        }
        /*Bank Cash ZMS*/
        public PFMDTO00042(string acode, decimal homeamt, decimal homeoamt, string status, string narration,string sourcebr,string workstation)
        {
            this.ACode = acode;
            this.HomeAmt = homeamt;
            this.HomeOamt = homeoamt;
            this.Status = status;
            this.Narration = narration;
            this.SourceBranch = sourcebr;
            //this.WorkStation = workstation;
        }

        public PFMDTO00042(string acode, decimal homeamt, decimal homeoamt, string status, string narration)
        {
            this.ACode = acode;
            this.HomeAmt = homeamt;
            this.HomeOamt = homeoamt;
            this.Status = status;
            this.Narration = narration;
        }

        /* Edited by HOW(To get branch code)*/
        public PFMDTO00042(string acode, decimal homeamt, decimal homeoamt, string status, string narration, string branch, string cur, string workStation)
        {
            this.ACode = acode;
            this.HomeAmt = homeamt;
            this.HomeOamt = homeoamt;
            this.Status = status;
            this.Narration = narration;
            this.SourceBranch = branch;
            this.SourceCur = cur;
            this.WorkStation = workStation;
        }
        //Bank Cash
        public PFMDTO00042(string acode, decimal homeamt, decimal homeoamt, string status, string narration, string workStation)
        {
            this.ACode = acode;
            this.HomeAmt = homeamt;
            this.HomeOamt = homeoamt;
            this.Status = status;
            this.Narration = narration;
            this.WorkStation = workStation;
        }
        public PFMDTO00042(string acode, string status, decimal homeAmt, string currency, string branch)
        {
            this.ACode = acode;
            this.Status = status;
            this.HomeAmt = homeAmt;
            this.SourceCur = currency;
            this.SourceBranch = branch;
        }

        public PFMDTO00042(string acode, string status, decimal localAmt, string currency, string branch, string workStation)
        {
            this.ACode = acode;
            this.Status = status;
            this.LocalAmt = localAmt;
            this.SourceCur = currency;
            this.SourceBranch = branch;
            this.WorkStation = workStation;

        }

        public PFMDTO00042(string acctno, string otherbank, string otherbankcheque, string bankdesp, DateTime datetime, decimal? localamount, string workstation, string sourcecur, DateTime settlementdate)
        {
            this.AcctNo = acctno;
            this.OtherBank = otherbank;
            this.OtherBankChq = otherbankcheque;
            this.BankDescription = bankdesp;
            this.DATE_TIME = datetime;
            this.LocalAmount = localamount.Value;
            this.WorkStation = workstation;
            this.SourceCur = sourcecur;
            this.SettlementDate = settlementdate;
        }
        public PFMDTO00042(string eno, string acctno, decimal amount, string acode, decimal homeamount, decimal homeamt, decimal homeOamt, decimal localamount, decimal localamt, decimal localOamt, string sourceCur, string curCode, string cheque, string pono, string drge, string erge, string lgno, string lno, string desp, string narration, DateTime datetime, string status, string tranCode, string acsign, string dombankpost, string clrpoststatus, string orgneno, string organTrancode, string orgncheque, string orgnpono, string orgndrgeno, string orgnergeno, string orgnLgno, string orgnlno, string userno, string contraEno, string contraLno, DateTime contraDate, string otherbank, bool deliverReturn, string receiptNo, string otherBankCheque, string otherBankAcctno, string custID, string gcNo, DateTime chktime, string workstation, string sourcebr, decimal rate, DateTime settlementdate, string channel, string refvno, string reftype, string uID, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Eno = eno;
            this.AcctNo = acctno;
            this.Amount = amount;
            this.ACode = acode;
            this.HomeAmount = homeamount;
            this.HomeAmt = homeamt;
            this.HomeOamt = homeOamt;
            this.LocalAmount = localamount;
            this.LocalAmt = localamt;
            this.LocalOamt = localOamt;
            this.SourceCur = sourceCur;
            this.CurCode = curCode;
            this.Cheque = cheque;
            this.PaymentOrderNo = pono;
            this.DrawingRegisterNo = drge;
            this.EncashRegisterNo = erge;
            this.LGNo = lgno;
            this.LoanNo = lno;
            this.Description = desp;
            this.Narration = narration;
            this.DATE_TIME = datetime;
            this.Status = status;
            this.TransactionCode = tranCode;
            this.AccountSign = acsign;
            this.DomBankPost = dombankpost;
            this.ClearingPostStatus = clrpoststatus;
            this.OrgnENo = orgneno;
            this.OrgnTranCode = organTrancode;
            this.OrgnCheque = orgncheque;
            this.OrgnPoNo = orgnpono;
            this.OrgnDReg = orgndrgeno;
            this.OrgnEReg = orgnergeno;
            this.OrgnLgNo = orgnLgno;
            this.OrgnLNo = orgnlno;
            this.UserNo = userno;
            this.ConTraEno = contraEno;
            this.ConTraLno = contraLno;
            this.Contra_Date = contraDate;
            this.OtherBank = otherbank;
            this.Deliver_Return = deliverReturn;
            this.ReceiptNo = receiptNo;
            this.OtherBankChq = otherBankCheque;
            this.OtherBankAccountNo = OtherBankAccountNo;
            this.CustId = custID;
            this.GChequeNo = gcNo;
            this.ChkTime = chktime;
            this.WorkStation = workstation;
            this.SourceBranch = sourcebr;
            this.Rate = rate;
            this.SettlementDate = settlementdate;
            this.Channel = channel;
            this.RefVNo = refvno;
            this.RefType = reftype;
            this.UniqueIdentifier = uID;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;


        }
        public PFMDTO00042(bool active, string eno, string trancode, string otherbank, string otherbankchq, string cheque, string orgnpono, string refvno, string bankdesp
            , System.Nullable<DateTime> datetime, decimal? localamount, string workstation, string sourcecur, System.Nullable<DateTime> settlementdate, string pono, string reftype)
        {
            this.Eno = eno;
            this.TransactionCode = trancode;
            this.OtherBank = otherbank;
            this.OtherBankChq = otherbankchq;
            this.Cheque = cheque;
            this.OrgnPoNo = orgnpono;
            this.RefVNo = refvno;
            this.BankDescription = bankdesp;
            this.DATE_TIME = datetime;
            this.LocalAmount = localamount.Value;
            this.WorkStation = workstation;
            this.SourceCur = sourcecur;
            this.SettlementDate = settlementdate.Value;
            if ((!String.IsNullOrEmpty(otherbankchq)) || (!String.IsNullOrEmpty(orgnpono)) || (String.IsNullOrEmpty(otherbankchq) && String.IsNullOrEmpty(orgnpono) && String.IsNullOrEmpty(pono) && trancode.Equals("RCLRECE")))
            {
                this.Deliver = localamount.Value;
            }
            else
            {
                this.Deliver = 0;
            }
            if ((!String.IsNullOrEmpty(cheque) && eno.ToString().Substring(0, 1).Equals("R") || (String.IsNullOrEmpty(cheque) && eno.ToString().Substring(0, 1).Equals("R"))) || 
                (!String.IsNullOrEmpty(refvno) && !String.IsNullOrEmpty(reftype) && reftype.Equals("PORCL")) ||
                String.IsNullOrEmpty(otherbankchq) && String.IsNullOrEmpty(cheque) && String.IsNullOrEmpty(orgnpono) && String.IsNullOrEmpty(pono) && trancode.Equals("RCLDELI"))
            {
                this.Receipt = localamount.Value;
            }
            else
            {
                this.Receipt = 0;
            }
        }

        public PFMDTO00042(string acctno, string otherbankchq, string bdesp, decimal? localamount, System.Nullable<DateTime> date_time, string eno, System.Nullable<DateTime> settlementDate,
                            string sourcecur, string workstation)
        {
            this.AcctNo = acctno;
            this.Particular = (String.IsNullOrEmpty(otherbankchq)) ? (otherbankchq + " " + bdesp) : bdesp;
            this.Debit = localamount;
            this.Credit = 0;
            this.DATE_TIME = date_time;
            this.Eno = eno;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourcecur;
            this.WorkStation = workstation;
        }

        public PFMDTO00042(bool active, string acctno)
        {
            this.Active = active;
        }

        public PFMDTO00042(string acctno, System.Nullable<DateTime> datetime, string description, decimal withdrawalamount, decimal depositamount, string cheque)
        {
            this.AcctNo = acctno;
            this.DATE_TIME = datetime;
            this.Description = description;
            this.WithdrawalAmount = withdrawalamount;
            this.DepositAmount = depositamount;
            this.Cheque = cheque;
        }

        public PFMDTO00042(string acctno, decimal? localamount, System.Nullable<DateTime> date_time, string eno, System.Nullable<DateTime> settlementDate,
                    string sourcecur, string workstation)
        {
            this.AcctNo = acctno;
            this.Particular = acctno;
            this.Credit = localamount;
            this.Debit = 0;
            this.DATE_TIME = date_time;
            this.Eno = eno;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourcecur;
            this.WorkStation = workstation;
        }

        public PFMDTO00042(string acctno, decimal? localamount, System.Nullable<DateTime> date_time, System.Nullable<DateTime> settlementDate,
            string sourcecur, string workstation)
        {
            this.Particular = acctno;
            this.Debit = localamount;
            this.Credit = 0;
            this.DATE_TIME = date_time;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourcecur;
            this.WorkStation = workstation;
        }

        public PFMDTO00042(string acctNo, DateTime date_time, decimal localAmount, string acSign, decimal amount)
        {
            this.AcctNo = acctNo;
            this.DATE_TIME = date_time;
            this.LocalAmount = localAmount;
            this.AccountSign = acSign;
            this.Amount = amount;
        }

        public PFMDTO00042(string particular, decimal debit, decimal credit)
        {
            this.Particular = particular;
            this.Debit = debit;
            this.Credit = credit;
        }

        //For Monthly Posting
        public PFMDTO00042(string aCode, string branchCode)
        {
            this.ACode = aCode;
            this.SourceBranch = branchCode;
        }

        /// <summary>
        /// OverDraft Daybook Constructor
        /// </summary>
        public PFMDTO00042(string status, string acctno, string coaAccountno, string coaAccName, decimal? amount, decimal? localOAmt, System.Nullable<DateTime> date_time,
                            string workstation, string sourceCur, decimal? rate, System.Nullable<DateTime> sDate_time, string sourcebr)
        {
            if (!acctno.Length.Equals(6))
            {
                this.COAName = string.Empty;
            }
            else
            {
                this.COAName = coaAccountno;
            }
            if ((status.Substring(0, 2).Equals("CD")))
            {
                if (acctno.Equals(coaAccountno))
                    this.DebitCash = amount.Value;
                else
                    this.DebitCash = localOAmt.Value;
            }
            else
                this.DebitCash = 0;

            if ((status.Substring(0, 2).Equals("TD")))
            {
                if (acctno.Equals(coaAccountno))
                    this.DebitTransfer = amount.Value;
                else
                    this.DebitTransfer = localOAmt.Value;
            }
            else
                this.DebitTransfer = 0;

            if ((status.Substring(0, 2).Equals("LD")))
            {
                if (acctno.Equals(coaAccountno))
                    this.DebitClearing = amount.Value;
                else
                    this.DebitClearing = localOAmt.Value;
            }
            else
                this.DebitClearing = 0;

            if ((status.Substring(0, 2).Equals("CD")) || (status.Substring(0, 2).Equals("TD")) || (status.Substring(0, 2).Equals("LD")))
            {
                if (acctno.Equals(coaAccountno))
                    this.DebitTotal = amount.Value;
                else
                    this.DebitTotal = localOAmt.Value;
            }
            else
                this.DebitTotal = 0;


            this.AcctNo = acctno;


            if ((status.Substring(0, 2).Equals("CC")))
            {
                if (acctno.Equals(coaAccountno))
                    this.CreditCash = amount.Value;
                else
                    this.CreditCash = localOAmt.Value;
            }
            else
                this.CreditCash = 0;

            if ((status.Substring(0, 2).Equals("TC")))
            {
                if (acctno.Equals(coaAccountno))
                    this.CreditTransfer = amount.Value;
                else
                    this.CreditTransfer = localOAmt.Value;
            }
            else
                this.CreditTransfer = 0;

            if ((status.Substring(0, 2).Equals("LC")))
            {
                if (acctno.Equals(coaAccountno))
                    this.CreditClearing = amount.Value;
                else
                    this.CreditClearing = localOAmt.Value;
            }
            else
                this.CreditClearing = 0;

            if ((status.Substring(0, 2).Equals("CC")) || (status.Substring(0, 2).Equals("TC")) || (status.Substring(0, 2).Equals("LC")))
            {
                if (acctno.Equals(coaAccountno))
                    this.CreditTotal = amount.Value;
                else
                    this.CreditTotal = localOAmt.Value;
            }
            else
                this.CreditTotal = 0;

            this.DATE_TIME = date_time;
            this.WorkStation = workstation;
            this.SourceCur = sourceCur;
            this.Rate = rate;
            this.SettlementDate = sDate_time;
            this.SourceBranch = sourcebr;
        }

        public PFMDTO00042(string aCode, string status, decimal localAmt, decimal localOAmt, DateTime dateTime, string workStatiion, string sourceCurrency, DateTime settlementDate, string narration)
        {
            this.ACode = aCode;
            this.Status = status;
            this.LocalAmt = localAmt;
            this.LocalOamt = localOAmt;
            this.DATE_TIME = dateTime;
            this.WorkStation = workStatiion;
            this.SourceCur = sourceCurrency;
            this.SettlementDate = settlementDate;
            this.Narration = narration;
        }

        public PFMDTO00042(decimal amount, bool active)
        {

        }

        public PFMDTO00042(decimal returnOBalance, decimal transferCL, string workStation)
        {
            this.ReturnObalance = returnOBalance;
            this.TrCL = transferCL;
            this.WorkStation = workStation;
        }

        /// <summary>
        /// Clearing Paid Cheque Listing Report
        /// </summary>
        public PFMDTO00042(string eno, string acctno, string cheque, string sourcecur, decimal? localamount, DateTime? date_time,
                           string otherbank, string userno, string orgnno,decimal amount)
        {
            this.Eno = eno;
            this.AcctNo = acctno;
            this.Cheque = cheque;
            this.SourceCur = sourcecur;
            this.LocalAmount = localamount;
            this.DATE_TIME = date_time;
            this.OtherBank = otherbank;
            this.UserNo = userno;
            this.OrgnENo = orgnno;
            this.Amount = amount;
        }

        /// <summary>
        /// Cheque PO Receipt Report
        /// </summary>
        public PFMDTO00042(string eno, string acctno, string pono, DateTime? adate, DateTime? idate, string sourcecur, decimal? localamount, DateTime date_time, string otherbank, string userno, string orgneno, string workstation,decimal amount)
        {
            this.Eno = eno;
            this.AcctNo = acctno;
            this.PaymentOrderNo = pono;
            this.ADate = adate;
            this.IDate = idate;
            this.SourceCur = sourcecur;
            this.LocalAmount = localamount;
            this.DATE_TIME = date_time;
            this.OtherBank = otherbank;
            this.UserNo = userno;
            this.OrgnENo = orgneno;
            this.WorkStation = workstation;
            this.Amount = amount;
        }

        public PFMDTO00042(DateTime matureDate, int diffDay, string message)
        {
            this.MatureDate = matureDate;
            this.DiffDay = diffDay;
            this.Message = message;
        }

        public PFMDTO00042(int returnMonth, int returnWeek, decimal returnInterest)
        {
            this.ReturnMonth = returnMonth;
            this.ReturnWeek = returnWeek;
            this.ReturnInterest = returnInterest;
        }

        public PFMDTO00042(string acode, string cbmaCode, string acName, string acType, string status, string cur, decimal amount, decimal homeAmount, int reversal, DateTime dateTime, DateTime settlementDate, string workstation, string sourceBr)
        {
            this.ACode = acode;
            this.CBMACode = cbmaCode;
            this.ACName = acName;
            this.ACType = acType;
            this.Status = status;
            this.SourceCur = cur;
            this.Amount = amount;
            this.HomeAmount = homeAmount;
            this.Reversal = reversal;
            this.DATE_TIME = dateTime;
            this.SettlementDate = settlementDate;
            this.WorkStation = workstation;
            this.SourceBranch = sourceBr;
        }

        //Clearing Receipt Reversal Listing Enquiry (9 args)(7 strings,1 Decimal,1 DateTime)
        public PFMDTO00042(string entryNo, string acctNo, string orgneNo, string description, string otherBank, string otherbankCheq, string sourceCur, Nullable<decimal> localAmount, DateTime dateTime)
        {
            this.Eno = entryNo;
            this.AcctNo = acctNo;
            this.OrgnENo = orgneNo;
            this.Description = description;
            this.OtherBank = otherBank;
            this.OtherBankChq = otherbankCheq;
            this.SourceCur = sourceCur;
            this.LocalAmount = localAmount;
            this.DATE_TIME = dateTime;
        }


        //Sub Ledger Customer (All/Specific)
        public PFMDTO00042(string acctno, DateTime dateTime, string description, decimal withdrawAmount, decimal depositAmount)
        {
            this.AcctNo = acctno;
            this.TIME = dateTime;
            this.Description = description;
            this.DebitTotal = withdrawAmount;
            this.CreditTotal = depositAmount;
        }


        public PFMDTO00042(bool active, string eno, string acctno, string otherbankcheque, string sourcecur, decimal localamount, DateTime datetime, string otherbank, string clrpoststatus,
            string workstation)
        {
            this.Active = active;
            this.Eno = eno;
            this.AcctNo = acctno;
            this.OtherBankChq = otherbankcheque;
            this.SourceCur = sourcecur;
            this.LocalAmount = localamount;
            this.DATE_TIME = datetime;
            this.OtherBank = otherbank;
            this.ClearingPostStatus = clrpoststatus;
            this.WorkStation = workstation;
        }

        //PO And IR Listing (Cash/Transfer/All)
        public PFMDTO00042(string poNo, decimal amount, string acctNo, DateTime aDate, DateTime iDate, string status,            string toAcctNo, string aCode, string acNoName, string registerNo, string cur, DateTime settlementDate, DateTime refundsDate)
        {
            this.OrgnPoNo = poNo;
            this.Amount = amount;
            this.AcctNo = acctNo;
            this.ADate = aDate;
            this.IDate = iDate;
            this.Status = status;
            this.ToAccountNo = toAcctNo;
            this.ACName = acNoName;
            this.ACode = aCode;
            this.DrawingRegisterNo = registerNo;
            this.CurrencyType = cur;
            this.SettlementDate = settlementDate;
            this.RefundsDate = refundsDate;
        }

      



        //Fixed Deposid Interest Listing
        public PFMDTO00042(string eno , string acSign , string status, DateTime datetime, string cr_AcctNo, decimal cr_Current, decimal cr_Saving, decimal cr_call , decimal cr_fixed, decimal cr_domestic,
            string dr_AcctNo, decimal dr_Current, decimal dr_Saving, decimal dr_call, decimal dr_fixed, decimal dr_domestic)
        {
            this.Eno = eno;
            this.AccountSign = acSign;
            this.Status= status;
            this.DATE_TIME= datetime;
            this.CR_ACCTNO = cr_AcctNo;
            this.CR_CURRENT = cr_Current;
            this.CR_SAVING =  cr_Saving;
            this.CR_CALL = cr_call;
            this.CR_FIXED = cr_fixed;
            this.CR_DOMESTIC =  cr_domestic;
            this.DR_ACCTNO = dr_AcctNo;
            this.DR_CURRENT = dr_Current;
            this.DR_SAVING = dr_Saving;
            this.DR_CALL = dr_call;
            this.DR_FIXED = dr_fixed;
            this.DR_DOMESTIC = dr_domestic;
        }

        //Auto Link Debit / Credit Listing      //Added by ASDA
        public PFMDTO00042(string eno, string acctNo, string name, decimal debit)  
        {
            this.Eno = eno;
            this.AcctNo = acctNo;
            this.Name = name;
            this.Debit = debit;
        }

        //PO register(Encash) Listing
        public PFMDTO00042(string pono, string sourcecur, string orgno,decimal amount, DateTime startdate, DateTime enddate)   
        {
            this.PaymentOrderNo = pono;
            this.SourceCur = sourcecur;
            this.EncashRegisterNo = orgno;
            
            this.Amount = amount;
            this.ADate = startdate;
            this.IDate = enddate;
            
         }

        //POWithdrawlEncash (Cash/Transfer/All)
        public PFMDTO00042(string poNo, string cur,string acctNo,string registerNo,decimal amount, DateTime aDate, string aCode,DateTime iDate,string toAcctNo, string status,string acName )
        {
            this.PaymentOrderNo = poNo;
            this.Amount = amount;
            this.AcctNo = acctNo;
            this.ADate = aDate;
            this.IDate = iDate;
            this.ToAccountNo = toAcctNo;
            this.Status = status;       
            this.ACode = aCode;
            this.EncashRegisterNo = registerNo;
            this.SourceCur = cur;
            this.ACName = acName;
        }
        
        //LegalCase (LOMCTL00016)
        public PFMDTO00042(string acctNo, decimal amount, Nullable<DateTime> datetime)
        {
            this.AcctNo = acctNo;
            this.Amount = amount;
            this.DATE_TIME = datetime;
        }

        //CashFlow
        public PFMDTO00042(decimal ca_db_amount, decimal ca_cr_amount, decimal loan_db_amount, decimal loan_cr_amount, decimal ir_db_amount, decimal ir_cr_amount,
            decimal cbm_db_amount, decimal cbm_cr_amount, decimal meb_db_amount, decimal meb_cr_amount,
            decimal present_db,decimal present_cr,decimal other_db,decimal other_cr,decimal expense_db_amount, decimal expense_cr_amount)
        {
            this.Ca_db_amount = ca_db_amount;
            this.Ca_cr_amount = ca_cr_amount;
            this.Loan_db_amount = loan_db_amount;
            this.Loan_cr_amount = loan_cr_amount;
            this.Ir_db_amount = ir_db_amount;
            this.Ir_cr_amount = ir_cr_amount;
            this.Cbm_db_amount = cbm_db_amount;
            this.Cbm_cr_amount = cbm_cr_amount;
            this.Meb_db_amount = meb_db_amount;
            this.Meb_cr_amount = meb_cr_amount;
            this.Present_cr_amount = present_db;
            this.Present_cr_amount = present_cr;
            this.OtherBank_db_amount = other_db;
            this.OtherBank_cr_amount = other_cr;
            this.Expense_db_amount = expense_db_amount;
            this.Expense_cr_amount = expense_cr_amount;
        }

        //LR
        public PFMDTO00042(decimal ca_db_amount, decimal ca_cr_amount,decimal Tr_db_amount,decimal Tr_cr_amount,decimal cashinhand,
            decimal loan_cr_amt,decimal loan_tran_cr_amt,decimal loan_dr_amt,decimal loan_tran_dr_amt,decimal loan,
            decimal cashTran,decimal depAuct,decimal foreginClose,decimal cashOPS,decimal cBMClosing,decimal cBMForegin,decimal stateClose,
            decimal stateForegin,decimal otherClose,decimal otherForegin,decimal treasury,decimal laonCBM,decimal pOBal,decimal drawingCash,
            decimal encash,decimal outstandingCash,decimal todayCash,decimal yesterdayCash,decimal liquidity,decimal loansDeposit,decimal cashForegin)
        {
            this.Transfer_Dr_Amt = Tr_db_amount;
            this.Transfer_Cr_Amt = Tr_cr_amount;
            this.Cash_Dr_Amt = ca_db_amount;
            this.Cash_Cr_Amt = ca_cr_amount;
            this.CashInHandAmt = cashinhand;
            this.Loan_Cr_Amt = loan_cr_amt;
            this.Loan_Tran_Cr_Amt = loan_tran_cr_amt;
            this.Loan_Dr_Amt = loan_dr_amt;
            this.Loan_Tran_Dr_Amt = loan_tran_dr_amt;
            this.Loan_OD_HPAmt = loan;
            this.Cash_Tran = cashTran;
            this.Dep_Auct = depAuct;
            this.Forgein_Close = foreginClose;
            this.Cash_OPS = cashOPS;
            this.CBM_Closing = cBMClosing;
            this.CBM_Foregin = cBMForegin;
            this.State_Closing = stateClose;
            this.State_Foregin = stateForegin;
            this.Other_Closing = otherClose;
            this.Other_Foregin = otherForegin;
            this.Treasury = treasury;
            this.Loan_CBM = laonCBM;
            this.PO_Bal = pOBal;
            this.Out_Cash = outstandingCash;
            this.Liq_ratio = liquidity;
            this.Loan_Depo = loansDeposit;
            this.D_Cash = drawingCash;
            this.E_Cash = encash;
            this.Today_Cash = todayCash;
            this.Yesterday_Cash = yesterdayCash;
            this.CashInHandForegin = cashForegin;
        }

        //DailyPosition
        public PFMDTO00042(string sourcebr, string branchdesp, decimal cashinhand, decimal cbm, decimal loan, decimal cur, decimal sav, decimal fix)
        {
            this.SourceBranch = sourcebr;
            this.BranchName = branchdesp;
            this.CashInHandAmt = cashinhand;
            this.CBMAmt = cbm;
            this.Loan_OD_HPAmt = loan;
            this.CurrentAmt = cur;
            this.SavingAmt = sav;
            this.FixedAmt = fix;
        }

        //DailyImprovement
        public PFMDTO00042(string sourcebr, string branchdesp, decimal deposit, decimal loan, decimal transfer_dr_amt, decimal transfer_cr_amt,
            decimal cash_dr_amt, decimal cash_cr_amt, decimal loan_dr_amt, decimal loan_cr_amt, decimal cashinhand)
        {
            this.SourceBranch = sourcebr;
            this.BranchName = branchdesp;
            if (this.DepositAmt == 0)
                this.DepositAmt = 0;
            else
                this.DepositAmt = deposit;
            this.Loan_OD_HPAmt = loan;
            this.Transfer_Dr_Amt = transfer_dr_amt;
            this.Transfer_Cr_Amt = transfer_cr_amt;
            this.Cash_Dr_Amt = cash_dr_amt;
            this.Cash_Cr_Amt = cash_cr_amt;
            this.Loan_Dr_Amt = loan_dr_amt;
            this.Loan_Cr_Amt = loan_cr_amt;
            this.CashInHandAmt = cashinhand;
        }

        //DailyProgress
        public PFMDTO00042(string date_time, decimal deposit, decimal loan, decimal transfer_dr_amt, decimal transfer_cr_amt,
            decimal cash_dr_amt, decimal cash_cr_amt,decimal loan_cr_amt,decimal loan_tran_cr_amt,
             decimal loan_dr_amt, decimal loan_tran_dr_amt, decimal cashinhand)
        {
            this.TranDate = date_time;
            this.DepositAmt = deposit;
            this.Loan_OD_HPAmt = loan;
            this.Transfer_Dr_Amt = transfer_dr_amt;
            this.Transfer_Cr_Amt = transfer_cr_amt;
            this.Cash_Dr_Amt = cash_dr_amt;
            this.Cash_Cr_Amt = cash_cr_amt;
            this.Loan_Cr_Amt = loan_cr_amt;
            this.Loan_Tran_Cr_Amt=loan_tran_cr_amt;
            this.Loan_Dr_Amt = loan_dr_amt;
            this.Loan_Tran_Dr_Amt=loan_tran_dr_amt;
            this.CashInHandAmt = cashinhand;
        }

        //Financial Statement
        public PFMDTO00042(string date_time, decimal capital, decimal cur, decimal sav, decimal fix, decimal cal,
            decimal loans, decimal income, decimal expense, decimal tbond, decimal cashinhand, decimal cbm,string name)
        {
            this.TranDate = date_time;
            this.CapitalAmt = capital;
            this.CurrentAmt = cur;
            this.SavingAmt = sav;
            this.FixedAmt = fix;
            this.CallAmt = cal;
            this.Loan_OD_HPAmt = loans;
            this.IncomeAmt = income;
            this.ExpenseAmt = expense;
            this.TBondsAmt = tbond;
            this.CashInHandAmt = cashinhand;
            this.CBMAmt = cbm;
            this.success = name;
        }


        //Deposit Listing (GroupNo Include) -- Added by AAM (18-Jan-2018)
        public PFMDTO00042(string groupNo, string eno,string acctNo,string desp,decimal amount,string userNo,DateTime datetime,
                           string time, string acSign, string sourceCur, string workStationId, string sourceBr)
        {
            GroupNo = groupNo;
            Eno = eno;
            AcctNo = acctNo;
            Description = desp;
            Amount = amount;
            UserNo = userNo;
            DATE_TIME = datetime;
            Time = time;
            AccountSign = acSign;
            this.SourceCur = sourceCur;
            WorkStation = workStationId;
            SourceBranch = sourceBr;
        }

        ////Withdrawal Listing (GroupNo Include) -- Added by JZT (06-Feb-2018)
        //public PFMDTO00042(string groupNo, string eno, string acctNo, string desp, decimal amount, string userNo, DateTime datetime,
        //                   string time, string acSign, string sourceCur, string workStationId, string sourceBr)
        //{
        //    GroupNo = groupNo;
        //    Eno = eno;
        //    AcctNo = acctNo;
        //    Description = desp;
        //    Amount = amount;
        //    UserNo = userNo;
        //    DATE_TIME = datetime;
        //    Time = time;
        //    AccountSign = acSign;
        //    this.SourceCur = sourceCur;
        //    WorkStation = workStationId;
        //    SourceBranch = sourceBr;
        //}

        #region Cash Flow
        public virtual decimal Ca_db_amount { get; set; }
        public virtual decimal Ca_cr_amount { get; set; }
        public virtual decimal Loan_db_amount { get; set; }
        public virtual decimal Loan_cr_amount { get; set; }
        public virtual decimal Ir_db_amount { get; set; }
        public virtual decimal Ir_cr_amount { get; set; }
        public virtual decimal Cbm_db_amount { get; set; }
        public virtual decimal Cbm_cr_amount { get; set; }
        public virtual decimal Meb_db_amount { get; set; }
        public virtual decimal Meb_cr_amount { get; set; }
        public virtual decimal Present_db_amount { get; set; }
        public virtual decimal Present_cr_amount { get; set; }
        public virtual decimal OtherBank_db_amount { get; set; }
        public virtual decimal OtherBank_cr_amount { get; set; }
        public virtual decimal Expense_db_amount { get; set; }
        public virtual decimal Expense_cr_amount { get; set; }
        #endregion

        #region Daily
        public virtual string TranDate { get; set; }
        public virtual decimal CashInHandAmt { get; set; }
        public virtual decimal DepositAmt { get; set; }
        public virtual decimal Transfer_Dr_Amt { get; set; }
        public virtual decimal Transfer_Cr_Amt { get; set; }
        public virtual decimal Cash_Dr_Amt { get; set; }
        public virtual decimal Cash_Cr_Amt { get; set; }
        public virtual decimal Loan_Dr_Amt { get; set; }
        public virtual decimal Loan_Cr_Amt { get; set; }
        public virtual decimal CBMAmt { get; set; }
        public virtual decimal Loan_OD_HPAmt { get; set; }
        public virtual decimal CurrentAmt { get; set; }
        public virtual decimal SavingAmt { get; set; }
        public virtual decimal FixedAmt { get; set; }

        public virtual decimal CallAmt { get; set; }
        public virtual decimal IncomeAmt { get; set; }
        public virtual decimal ExpenseAmt { get; set; }
        public virtual decimal TBondsAmt { get; set; }
        public virtual decimal CapitalAmt { get; set; }

        public virtual decimal Loan_Tran_Cr_Amt { get; set; }
        public virtual decimal Loan_Tran_Dr_Amt { get; set; }
        #endregion

        public virtual string GroupNo { get; set; } // added by AAM(18-Jan-2018)
        public virtual string Eno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal? Amount { get; set; }
        public virtual string ACode { get; set; }
        public virtual decimal? HomeAmount { get; set; }
        public virtual decimal? HomeAmt { get; set; }
        public virtual string strHomeAmt { get; set; }  //Added By MTSKK 
        public virtual decimal HomeOamt { get; set; }
        public virtual decimal? LocalAmount { get; set; }
        public virtual decimal? LocalAmt { get; set; }
        public virtual decimal LocalOamt { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string CurCode { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string PaymentOrderNo { get; set; }
        public virtual string DrawingRegisterNo { get; set; }
        public virtual string EncashRegisterNo { get; set; }
        public virtual string LGNo { get; set; }
        public virtual string LoanNo { get; set; }
        public virtual string Description { get; set; }
        public virtual string Narration { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string Status { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string DomBankPost { get; set; }
        public virtual string ClearingPostStatus { get; set; }
        public virtual string OrgnENo { get; set; }
        public virtual string OrgnTranCode { get; set; }
        public virtual string OrgnCheque { get; set; }
        public virtual string OrgnPoNo { get; set; }
        public virtual string OrgnDReg { get; set; }
        public virtual string OrgnEReg { get; set; }
        public virtual string OrgnLgNo { get; set; }
        public virtual string OrgnLNo { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ConTraEno { get; set; }
        public virtual string ConTraLno { get; set; }
        public virtual string ContraDate { get; set; }
        public virtual string OtherBank { get; set; }
        public virtual bool DeliverReturn { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual string OtherBankChq { get; set; }
        public virtual string OtherBankAccountNo { get; set; }
        public virtual string CustId { get; set; }
        public virtual string GChequeNo { get; set; }
        public virtual string CheckTime { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual string UniqueIdentifier { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string Channel { get; set; }
        public virtual string RefVNo { get; set; }
        public virtual string RefType { get; set; }
        public virtual string CurrencyType { get; set; }
        public virtual string DateType { get; set; }
        public virtual bool IsAllBranches { get; set; }
        public virtual bool IsWithReversal { get; set; }
        public virtual bool IsHomeCurrency { get; set; }
        public virtual string Time { get; set; }
        public virtual string BankName { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string TransactionStatus { get; set; }
        public virtual int WithdrawalCount { get; set; }
        public virtual int DepositCount { get; set; }
        public virtual string ReportTitle { get; set; }
        public virtual DateTime TIME { get; set; }
        public decimal ReturnObalance { get; set; }
        public decimal TrCL { get; set; }
        public string BankDescription { get; set; }
        public virtual DateTime Contra_Date { get; set; }
        public virtual bool Deliver_Return { get; set; }
        public virtual DateTime ChkTime { get; set; }
        public virtual System.Nullable<decimal> Deliver { get; set; }
        public virtual System.Nullable<decimal> Receipt { get; set; }
        public decimal BalMonth { get; set; }
        public virtual string File_Month { get; set; }
        public virtual string Particular { get; set; }
        public virtual System.Nullable<decimal> Debit { get; set; }
        public virtual System.Nullable<decimal> Credit { get; set; }
        public virtual int WorkStationId { get; set; }
        public virtual int CreditCount { get; set; }
        public virtual int DebitCount { get; set; }
        public virtual string ACName { get; set; }
        public virtual System.Nullable<decimal> ClosingBalance { get; set; }
        public virtual string StringDateTime { get; set; }
        public virtual System.Nullable<DateTime> ADate { get; set; }
        public virtual System.Nullable<DateTime> IDate { get; set; }
        public virtual string ADateString { get; set; }
        public virtual string IDateString { get; set; }
        public virtual string ChequeType { get; set; }
        public virtual string RequiredType { get; set; }
        public virtual DateTime MatureDate { get; set; }
        public virtual int DiffDay { get; set; }
        public virtual string Message { get; set; }
        public virtual int ReturnMonth { get; set; }
        public virtual int ReturnWeek { get; set; }
        public virtual decimal ReturnInterest { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual string SourceBr { get; set; }
        #region OverDraftDayBookFiled
        public virtual decimal DebitCash { get; set; }
        public virtual decimal DebitTransfer { get; set; }
        public virtual decimal DebitClearing { get; set; }
        public virtual decimal DebitTotal { get; set; }
        public virtual decimal CreditCash { get; set; }
        public virtual decimal CreditTransfer { get; set; }
        public virtual decimal CreditClearing { get; set; }
        public virtual decimal CreditTotal { get; set; }
        public virtual string COAName { get; set; }

        // added for DayBookSummaryRPT
        public virtual Nullable<decimal> CD_Total { get; set; }
        public virtual decimal Cash { get; set; }
        public virtual int CashCount { get; set; }
        public virtual decimal Transfer { get; set; }
        public virtual int TransferCount { get; set; }
        public virtual decimal Clearing { get; set; }
        public virtual int ClearingCount { get; set; }
        public virtual string HeadCode { get; set; }
        public virtual string FirstCode { get; set; }

        #endregion

        #region For StoreProcedure Output Parameters
        public virtual int Row_Count { get; set; }
        public virtual string ViewName { get; set; }
        #endregion

        public virtual decimal MinimumAmount { get; set; }
        public virtual decimal MaximumAmount { get; set; }

        public virtual decimal TotalCash { get; set; }
        public virtual decimal ClearingTotal { get; set; }
        public virtual string CBMACode { get; set; }
        public virtual string ACType { get; set; }
        public virtual int Reversal { get; set; }
        public string Name { get; set; }
        public virtual decimal WithdrawalAmount { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual DateTime RefundsDate { get; set; }

        #region Fixed Deposit Interest Listing
        public virtual string CR_ACCTNO { get; set; }
        public virtual decimal CR_CURRENT { get; set; }
        public virtual decimal CR_SAVING { get; set; }
        public virtual decimal CR_CALL { get; set; }
        public virtual decimal CR_FIXED { get; set; }
        public virtual decimal CR_DOMESTIC { get; set; }
        public virtual string DR_ACCTNO { get; set; }
        public virtual decimal DR_CURRENT { get; set; }
        public virtual decimal DR_SAVING { get; set; }
        public virtual decimal DR_CALL { get; set; }
        public virtual decimal DR_FIXED { get; set; }
        public virtual decimal DR_DOMESTIC { get; set; }
        #endregion

        public Nullable<Decimal> HomeOAmt_Credit { get; set; }
        public Nullable<Decimal> HomeOAmt_Debit { get; set; }

        #region Liquidity Ratio
        public virtual decimal Cash_Tran { get; set; }
        public virtual decimal Dep_Auct { get; set; }
        public virtual decimal Forgein_Close { get; set; }
        public virtual decimal Cash_OPS { get; set; }
        public virtual decimal CBM_Closing { get; set; }
        public virtual decimal CBM_Foregin { get; set; }
        public virtual decimal State_Closing{ get; set; }
        public virtual decimal State_Foregin { get; set; }
        public virtual decimal Other_Closing { get; set; }
        public virtual decimal Other_Foregin { get; set; }
        public virtual decimal Treasury { get; set; }
        public virtual decimal Loan_CBM { get; set; }
        public virtual decimal PO_Bal { get; set; }
        public virtual decimal D_Cash { get; set; }
        public virtual decimal E_Cash { get; set; }
        public virtual decimal Out_Cash { get; set; }
        public virtual decimal Today_Cash { get; set; }
        public virtual decimal Yesterday_Cash { get; set; }
        public virtual decimal Liq_ratio { get; set; }
        public virtual decimal Loan_Depo { get; set; }
        public virtual decimal CashInHandForegin { get; set; }
#endregion

        #region Liquidity Ratio
        public virtual string success{ get; set; }
#endregion


    }
}
