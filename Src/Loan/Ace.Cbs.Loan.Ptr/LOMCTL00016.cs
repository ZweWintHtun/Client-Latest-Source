//----------------------------------------------------------------------
// <copyright file="LOMCTL00016" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>15.01.2015</CreatedDate>
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00016 : AbstractPresenter, ILOMCTL00016
    {
        #region "Wire To"
        private ILOMVEW00016 view;
        public ILOMVEW00016 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        TLMDTO00018 LoanDTO { get; set; }
        LOMDTO00013 LegalDTO { get; set; }

        string MtodDate;
        string MAType = string.Empty;       
        string MAccountNo = string.Empty;
        string MSDate = string.Empty;
        string File = string.Empty;
        string CurMonth = string.Empty;
        string currency = string.Empty ;

        IList<MNMDTO00012> LegalIntList;

        private void WireTo(ILOMVEW00016 view)
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
            LoanEntity.LegaLawer = this.View.LegalCaseLawyer;
            return LoanEntity;
        }
        #endregion

        #region Variables

        #region Interest(TLMDTO00018 LoanDTO)

        decimal lostInterest;
        //DateTime dt;
        decimal lostCharges;
        decimal penFees;
        string[] typelist = { "INTEREST", "CHARGES" };

        #endregion

        #region CheckDate()
        string InterestMonths = string.Empty;
        string MonthInterestService = string.Empty;
        string CurQtr = string.Empty;
        DateTime Qsdate;
        DateTime Qedate;
        #endregion

        #endregion

        #region validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    //Legal Release Case
                    if (this.view.FormName == "Release Legal Sue Case (Loan/OD)")
                    {
                        IList<LOMDTO00013> LegalDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<LOMDTO00013>>(x => x.isLegalLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));
                        if (LegalDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);  //Invalid Loan No.
                            this.ClearControls();
                            return;
                        }
                        else
                        {
                            
                             this.view.AccountNo = LegalDTO[0].AcctNo;
                             this.view.AdvanceType = LegalDTO[0].AcType;
                             this.view.MakingDate = LegalDTO[0].LegalDate.Value.ToString("dd/MM/yyyy");
                             this.view.AcceptanceDate = LegalDTO[0].AcceptDate.Value.ToString("dd/MM/yyyy");
                             this.view.LegalReleaseLawyer = LegalDTO[0].LegalLawyer;
                        }
                    }
                    else  //Legal Case
                    {
                        LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00014, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                        if (LoanDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90055);  //Invalid Loan No.
                            this.ClearControls();
                            return;
                        }
                        else
                        {
                            if (LoanDTO.LegalCase == true)
                            {
                                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90066); //Legal Case is already exit !!! 
                                return;
                            }
                            else if (!string.IsNullOrEmpty(LoanDTO.CloseDate.ToString()))
                            {
                                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90057); //Loans No. Already Closed!
                                return;
                            }
                            else
                            {
                                IList<PFMDTO00072> GetCustomerInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<PFMDTO00072>>(x => x.CheckCustomerInformation(LoanDTO.AccountNo, CurrentUserEntity.BranchCode));
                                {
                                    if (GetCustomerInfo == null || GetCustomerInfo.Count < 1)
                                    {
                                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
                                        return;
                                    }
                                }
                                this.CheckDate(LoanDTO);

                                if (LoanDTO.TodCloseDate != null)
                                    MtodDate = LoanDTO.TodCloseDate.Value.ToShortDateString();

                                //MAType = LoanDTO.AType;
                                //MAccountNo = LoanDTO.AccountNo;
                                currency = LoanDTO.Currency;

                                if (LoanDTO.AType != "TOD" && LoanDTO.AType != "TOD_REMIT")
                                {
                                    MSDate = LoanDTO.SDate == null ? null : LoanDTO.SDate.Value.ToShortDateString();   //MM/DD/YYYY
                                }
                                //decimal LoansRate = LoanDTO.IntRate.Value;


                                this.View.AccountNo = LoanDTO.AccountNo;

                                this.View.AdvanceType = LoanDTO.AType;
                                this.View.InterestRate = LoanDTO.IntRate == null ? 0 : LoanDTO.IntRate.Value;   //txtUsed                            
                                this.View.LedgerBalance = GetCustomerInfo[0].CurrentBalance;
                                this.View.SanctionAmount = LoanDTO.SAmount == null ? 0 : LoanDTO.SAmount.Value;
                               //this.View.LegalCaseLawyer = LoanDTO.LegaLawer;
                              
                                
                                this.Interest(LoanDTO);
                                this.CalculateInterest(LoanDTO);
                            }
                         }
                        //this.SetEnableDisable("txtLegalCaseLawyer",true);
                       
                         // this.SetFocus("txtLegalCaseLawyer");
                       
                    }
                }
                catch (Exception ex)
                {
                    //this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
                    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
                    this.ClearControls();                    
                }
            }
            else
            { return; }
        }

        //public void txtLegalCaseLawyer_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    // if xml base error does not exist.
        //    if (e.HasXmlBaseError == false)
        //    {
        //        this.SetFocus("butSave");
        //    }
        //    else
        //    {
        //        this.view.Status = "err";
        //        return;
        //    }
        //}
        #endregion

        #region LegalCase Method
        //public void CheckDate(TLMDTO00018 LoanDTO)   //CheckDate()
        //{
        //    string Month = DateTime.Now.Month.ToString();
        //    //string InterestMonths = string.Empty;
        //    //string MonthInterestService = string.Empty;
        //    //string CurQtr = string.Empty;
        //    //DateTime Qsdate;
        //    //DateTime Qedate;

        //    switch (LoanDTO.AType)   //MAtype
        //    {
        //        case "LOANS": File = "LI";
        //            CurMonth = "Q" + (Convert.ToInt32(CXCOM00010.Instance.GetBudgetMonth4()) - 1).ToString();   //Curmonth = "Q" & Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 4) - 1))
        //            break;

        //        case "TOD" : File = "TOD_SCHARGE";
        //            CurMonth = "S" + CXCOM00010.Instance.GetBudgetMonth(); //Curmonth = "S" & Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 3)))
        //            break ;

        //        case "OVERDRAFTS" : File = "OI";
        //            CurMonth = "M" +  CXCOM00010.Instance.GetBudgetMonth(); //Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 3)))  --M10
        //            break ;
        //    }
         
        //    string dt = DateTime.Now.ToShortDateString();
        //    string[] dtarray = dt.Split('/');  //01/16/2015
        //    dt = dtarray[2];
        //    if(Month.Contains("4") || Month.Contains("5") || Month.Contains("6"))
        //    {
        //        InterestMonths = "M1+M2+M3";
        //        MonthInterestService = "S1+S2+S3";
        //        //CurQtr = "Q1";
        //        Qsdate = Convert.ToDateTime("04/01/" + dt );
        //        Qedate = Convert.ToDateTime("06/30/" + dt);
        //    }
        //    else if (Month.Contains("7") || Month.Contains("8") || Month.Contains("9"))
        //    {
        //        InterestMonths = "M4+M5+M6";
        //        MonthInterestService = "S4+S5+S6";
        //        //CurQtr = "Q2";
        //        Qsdate = Convert.ToDateTime("07/01/" + dt);
        //        Qedate = Convert.ToDateTime("09/30/" + dt);
        //    }
        //    else if (Month.Contains("10") || Month.Contains("11") || Month.Contains("12"))
        //    {
        //        InterestMonths = "M7+M8+M9";
        //        MonthInterestService = "S7+S8+S9";
        //        //CurQtr = "Q3";
        //        Qsdate = Convert.ToDateTime("10/01/" + dt);
        //        Qedate = Convert.ToDateTime("12/31/" + dt);
        //    }
        //    else
        //    {
        //        InterestMonths = "M10+M11+M12";
        //        MonthInterestService = "S10+S11+S12";
        //        //CurQtr = "Q4";
        //        Qsdate = Convert.ToDateTime("01/01/" + dt);
        //        Qedate = Convert.ToDateTime("03/31/" + dt);
        //    }
        //}

        public void CheckDate(TLMDTO00018 LoanDTO)   //CheckDate()
        {
            string Month = DateTime.Now.Month.ToString();           

            switch (LoanDTO.AType)   //MAtype
            {
                case "LOANS": File = "LI";
                    CurMonth = "Q" + (Convert.ToInt32(CXCOM00010.Instance.GetBudgetMonth4()) - 1).ToString();   //Curmonth = "Q" & Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 4) - 1))
                    break;

                case "TOD": File = "TOD_SCHARGE";
                    CurMonth = "S" + CXCOM00010.Instance.GetBudgetMonth(); //Curmonth = "S" & Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 3)))
                    break;

                case "OVERDRAFTS": File = "OI";
                    CurMonth = "M" + CXCOM00010.Instance.GetBudgetMonth(); //Trim(Str(objBudinfo.Budinfo(Format(Date, "dd/mm/yyyy"), 3)))  --M10
                    break;
            }

            string dt = DateTime.Now.ToShortDateString();
            string[] dtarray = dt.Split('/');  //01/16/2015
            dt = dtarray[2];
            if (Month.Contains("4") || Month.Contains("5") || Month.Contains("6"))
            {
                InterestMonths = "M1+M2+M3";
                MonthInterestService = "S1+S2+S3";
                CurQtr = "Q1";
                Qsdate = Convert.ToDateTime("04/01/" + dt);
                Qedate = Convert.ToDateTime("06/30/" + dt);
            }
            else if (Month.Contains("7") || Month.Contains("8") || Month.Contains("9"))
            {
                InterestMonths = "M4+M5+M6";
                MonthInterestService = "S4+S5+S6";
                CurQtr = "Q2";
                Qsdate = Convert.ToDateTime("07/01/" + dt);
                Qedate = Convert.ToDateTime("09/30/" + dt);
            }
            else if (Month.Contains("10") || Month.Contains("11") || Month.Contains("12"))
            {
                InterestMonths = "M7+M8+M9";
                MonthInterestService = "S7+S8+S9";
                CurQtr = "Q3";
                Qsdate = Convert.ToDateTime("10/01/" + dt);
                Qedate = Convert.ToDateTime("12/31/" + dt);
            }
            else
            {
                InterestMonths = "M10+M11+M12";
                MonthInterestService = "S10+S11+S12";
                CurQtr = "Q4";
                Qsdate = Convert.ToDateTime("01/01/" + dt);
                Qedate = Convert.ToDateTime("03/31/" + dt);
            }
        }

        public void Interest(TLMDTO00018 LoanDTO)   //Interest()
        {
            //decimal lostInterest;
            ////DateTime dt;
            //decimal lostCharges;
            //decimal penFees;
            //string[] typelist = { "INTEREST", "CHARGES" };

            if (LoanDTO.AType == "LOANS")
            {  
                LegalIntList = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<MNMDTO00012>>(x => x.GetLegalIntList(typelist,this.View.LoanNo, CurrentUserEntity.BranchCode));
                //"Select PenFees = Sum(Amount * " & LoansRate & "/100/366*(DateDiff(Day,Date_Time,GetDate()))),LOstInt = Sum(Amount) From Legalint Where Type = 'INTEREST' And Lno= '" & MLno & "'"
                if (LegalIntList.Count > 0)
                {

                    var LostInt = (from value in LegalIntList
                                   where value.Type == "INTEREST" & value.LNo == LoanDTO.Lno
                                   select value.Amount).Sum();
                    lostInterest = LostInt;

                    var datetime = (from value in LegalIntList
                                    where value.Type == "INTEREST" & value.LNo == LoanDTO.Lno
                                    select value.Date_Time).Single();

                    penFees = LostInt * LoanDTO.IntRate.Value / 100 / 366 * DateTime.Now.Subtract(datetime).Days;

                    var LostChg = (from value in LegalIntList
                                   where value.Type == "CHARGES" & value.LNo == LoanDTO.Lno
                                   select value.Amount).Sum();
                    lostCharges = LostChg;

                    var date_time = (from value in LegalIntList
                                     where value.Type == "CHARGES" & value.LNo == LoanDTO.Lno
                                     select value.Date_Time).Single();

                    penFees = LostChg * LoanDTO.IntRate.Value / 100 / 366 * DateTime.Now.Subtract(date_time).Days + penFees;
                }
                else { penFees = 0; }
            }
            else
            {                
                LegalIntList = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<MNMDTO00012>>(x => x.GetLegalIntList(typelist,this.View.LoanNo, CurrentUserEntity.BranchCode));

                if (LegalIntList.Count > 0)
                {
                    var LostInt = (from value in LegalIntList
                                   where value.Type == "INTEREST" & value.AcctNo == LoanDTO.AccountNo & value.AType == "O"
                                   select value.Amount).Sum();
                    lostInterest = LostInt;

                    var datetime = (from value in LegalIntList
                                    where value.Type == "INTEREST" & value.AcctNo == LoanDTO.AccountNo & value.AType == "O"
                                    select value.Date_Time).Single();

                    penFees = LostInt * LoanDTO.IntRate.Value / 100 / 366 * DateTime.Now.Subtract(datetime).Days;

                    var LostChg = (from value in LegalIntList
                                   where value.Type == "CHARGES" & value.AcctNo == LoanDTO.AccountNo & value.AType == "O"
                                   select value.Amount).Sum();
                    lostCharges = LostChg;

                    var date_time = (from value in LegalIntList
                                     where value.Type == "CHARGES" & value.AcctNo == LoanDTO.AccountNo & value.AType == "O"
                                     select value.Date_Time).Single();

                    penFees = LostChg * LoanDTO.IntRate.Value / 100 / 366 * DateTime.Now.Subtract(date_time).Days + penFees;
                }
                else { penFees = 0; }
            }
        }   

        public void CalculateInterest(TLMDTO00018 LoanDTO)  //Calint()
        {
            if (LoanDTO.AType == "LOANS")
            {
                this.CalculateLoansInterest(LoanDTO);
            }
            LOMDTO00013 m_typeInterest = this.Return_Interest(LoanDTO.AccountNo, LoanDTO.Lno, LoanDTO.AType);
            this.view.ExtraCharges = m_typeInterest.Tod_SchargeInterest;
            this.view.Interest = LoanDTO.AType == "LOANS" ? m_typeInterest.LoansInterest : m_typeInterest.ODInterest;
            this.view.ServicesCharges = m_typeInterest.OldScharge.Value;
            decimal Mtotal = m_typeInterest.ODInterest + m_typeInterest.LoansInterest + m_typeInterest.OldScharge.Value + lostInterest + lostCharges + penFees + m_typeInterest.Tod_SchargeInterest;

            #region vb
            //MInterest = Format(IIf(MAtype = "LOANS", m_typeInterest.LoansInterest, m_typeInterest.ODInterest), "###,###,###,##0.#0")
            //If MInterest = "" Then MInterest = Format(0, "###########0.#0")
       
            //MExtInterest = Format(m_typeInterest.Tod_SchargeInterest, "###########0.#0") '--Mae Mae For Extra Charges
            //If MExtInterest = 0 Then MExtInterest = Format(0, "###########0.#0")
   
            //TxtExtra.Text = IIf(IsNull(MExtInterest), "", Format(MExtInterest, "###,###,###,##0.#0"))
            //TxtInt.Text = IIf(IsNull(MInterest), "", MInterest)   
            //TxtSChag.Text = Format(m_typeInterest.SChargeInterest, "###,###,###,##0.00")

            //MTotal = m_typeInterest.ODInterest + m_typeInterest.LoansInterest + m_typeInterest.SChargeInterest + IIf(IsNull(LOstInt), 0, LOstInt) + IIf(IsNull(LOstChg), 0, LOstChg) + IIf(IsNull(PenFees), 0, PenFees) + m_typeInterest.Tod_SchargeInterest
            #endregion
        }

        public void CalculateLoansInterest(TLMDTO00018 LoanDTO)  //CalLoansInt()
        {
            int period = CurQtr == "Q1" ? 1 : CurQtr == "Q2" ? 2 : CurQtr == "Q3" ? 3 : 4;
            int daysInYear = this.DaysInYear();
            bool returnResult = CXClientWrapper.Instance.Invoke<ILOMSVE00016, bool>(x => x.GetLoanInterestAndUpdateLI(this.View.LoanNo, daysInYear, Qsdate, Qedate, period, 0, CurQtr, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
            //EXEC" & " Sp_LoanInterest '" & Trim(txtLno2.Text) & "'," & Daysinyear & " ," & " '" & LoansSDate & "','" & Format(Date - 1, "yyyy/mm/dd") & "'," & Right(CurQtr, 1) & ",@RETINT OUTPUT SELECT @RETINT" 
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
            {
                //CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); //Require A/C No. is not available in Loans Int. file
                throw new Exception(CXClientWrapper.Instance.ServiceResult.MessageCode);
                //return;
            }
        }

        public LOMDTO00013 Return_Interest(string accountNo, string lno, string aType)  //Return_Interest(ByVal pAcctno As String, ByVal pLno As String, ByVal pAtype As String)
        {
            int interestMonth = 0;
            int interestMonthStart = 0;
            int interestLen  = 0;
            string MMonth = string.Empty;
            string SMonth = string.Empty;
            string QtrLI = string.Empty;

            //**GET QUARTER INFO**//
            interestMonth = DateTime.Now.Month;
            if (interestMonth >= 10)    
            {
                interestMonthStart = 7;
                interestLen = interestMonth - 10 + 1;
                QtrLI = "3"; //QtrLI = "Q3";
            }          
            else if (interestMonth >= 7)
            {
                interestMonthStart = 4;
                interestLen = interestMonth - 7 + 1;
                QtrLI = "2"; //QtrLI = "Q2";
            }
            else if (interestMonth >= 4)
            {
                interestMonthStart = 1;
                interestLen = interestMonth - 4 + 1;
                QtrLI = "1"; //QtrLI = "Q1";
            }
            else
            {
                interestMonthStart = 10;
                interestLen = interestMonth;
                QtrLI = "4"; //QtrLI = "Q4";
            }

            switch (interestLen)
            {
                case 1: MMonth = "M" + interestMonthStart;
                        SMonth = "S" + interestMonthStart;
                    break;

                case 2: MMonth = "M" + interestMonthStart + "+" + "M" + (interestMonthStart + 1)  ;
                        SMonth = "S" + interestMonthStart + "+" + "S" + (interestMonthStart + 1);
                    break;

                case 3: MMonth = "M" + interestMonthStart + "+" + "M" + (interestMonthStart + 1) + "+" + "M" + (interestMonthStart + 2)  ;
                        SMonth = "S" + interestMonthStart + "+" + "S" + (interestMonthStart + 1) + "+" + "S" + (interestMonthStart + 2) ;
                    break;
            }

            //**END OF  GET QUARTER INFO**//
            LOMDTO00013 tmpinterest = new LOMDTO00013();
            tmpinterest.Tod_SchargeInterest = 0;
            tmpinterest.LoansInterest = 0;
            tmpinterest.ODInterest = 0;
            tmpinterest.OldScharge = 0;
            LOMDTO00021 topLiInfo = new LOMDTO00021();
            if (aType == "LOANS")
            {
                IList<LOMDTO00021> LI_Info = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<LOMDTO00021>>(x => x.GetLI_Info(accountNo, this.View.LoanNo, CurrentUserEntity.BranchCode));
                //"SELECT TOP 1 * FROM LI WITH(NOLOCK) WHERE ACCTNO='" & pAcctno & "' AND LNO ='" & pLno & "' AND ISNULL(CLOSEDATE,'')=''"
                //var Li = from n in LI_Info
                //         group n by n.TNo into g
                //         select g.OrderByDescending(t => t.EndDate).First();       
   
                var query = from LOMDTO00021 li in LI_Info 
                            orderby li.TNo descending 
                            select li;
                
                topLiInfo = query.First();
               
               // IList<LOMDTO00021> Li_interest = Li;
                //if (LI_Info != null)
                //{
                //    switch (QtrLI)
                //    {
                //        case "Q1": tmpinterest.LoansInterest = LI_Info.Q1 == null? 0 : LI_Info.Q1.Value; break;
                //        case "Q2": tmpinterest.LoansInterest = LI_Info.Q2 == null ? 0 : LI_Info.Q2.Value; break;
                //        case "Q3": tmpinterest.LoansInterest = LI_Info.Q3 == null ? 0 : LI_Info.Q3.Value; break;
                //        case "Q4": tmpinterest.LoansInterest = LI_Info.Q4 == null ? 0 : LI_Info.Q4.Value; break;
                //    }
                //}
                if (topLiInfo != null)
                {
                    tmpinterest.LoansInterest = topLiInfo.IntRate == null ? 0 : topLiInfo.IntRate.Value;
                }
                else
                    tmpinterest.LoansInterest = 0;

                //CalSInt(tmpInterest.SChargeInterest, QtrLI)
                //this.CalculateSInt(accountNo, lno, aType, tmpinterest.OldScharge.Value, QtrLI);
                this.CalculateSInt(accountNo, lno, aType, tmpinterest.OldScharge.Value, topLiInfo.TNo);

            }
            else   //aType = OVERDRAFT  or  TOD  or TOD_REMIT
            {
                MNMDTO00008 OI_Info = CXClientWrapper.Instance.Invoke<ILOMSVE00016, MNMDTO00008>(x => x.GetOI_Info(accountNo, this.View.LoanNo, MMonth,CurrentUserEntity.BranchCode));
                // "SELECT TOP 1 ACCTNO, " & MMth & " AS TOTAL_INT, CONVERT(CHAR(10),LASTDATE,111) " & "AS LASTDATE, LASTINT FROM OI WITH(NOLOCK) " & "WHERE ACCTNO='" & pAcctno & "' AND LNO ='" & pLno & "' AND ISNULL(CLOSEDATE,'')=''"

                if (OI_Info != null)
                {
                    tmpinterest.ODInterest = OI_Info.Total_Interest;
                    if (OI_Info.LastDate != null)
                    {
                        if (OI_Info.LastDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                            tmpinterest.ODInterest = tmpinterest.ODInterest - OI_Info.LastInt;
                        else
                        {
                            int dateDifferent = DateTime.Now.Subtract(OI_Info.LastDate.Value).Days >= 0 ? DateTime.Now.Subtract(OI_Info.LastDate.Value).Days - 1 : 0;
                            tmpinterest.ODInterest = tmpinterest.ODInterest - OI_Info.LastInt * dateDifferent;
                        }
                    }
                    else
                        tmpinterest.LoansInterest = 0;                    
                    #region vb
                    //    tmpInterest.ODInterest = IIf(IsNull(tmpRS.rdoColumns("TOTAL_INT").Value), 0, tmpRS.rdoColumns("TOTAL_INT").Value)
                    //    If IsDate(tmpRS.rdoColumns("LASTDATE")) Then
                    //        If Format(tmpRS.rdoColumns("LASTDATE"), "YYYY/MM/DD") = Format(Date, "YYYY/MM/DD") Then
                    //            tmpInterest.ODInterest = tmpInterest.ODInterest - IIf(IsNull(tmpRS.rdoColumns("LASTINT").Value), 0, tmpRS.rdoColumns("LASTINT").Value)
                    //        Else
                    //            tmpInterest.ODInterest = tmpInterest.ODInterest + (IIf(IsNull(tmpRS.rdoColumns("LASTINT").Value), 0, tmpRS.rdoColumns("LASTINT").Value) * IIf(DateDiff("d", tmpRS.rdoColumns("LASTDATE"), Date) >= 0, (DateDiff("d", tmpRS.rdoColumns("LASTDATE"), Date) - 1), 0))
                    //        End If
                    //    End If
                    //Else
                    //    tmpInterest.LoansInterest = 0
                    //End If
                    #endregion
                }

                 //this.CalculateSInt(accountNo, lno, aType, tmpinterest.OldScharge.Value, QtrLI);
                this.CalculateSInt(accountNo, lno, aType, tmpinterest.OldScharge.Value, topLiInfo.TNo);
                    ////**FOR TOD SCHARGE**//
                    //if (aType == "TOD" || aType == "TOD_REMIT")
                    //{
                    //    this.CalculateExtraInterest(accountNo);
                    //    tmpinterest.Tod_SchargeInterest = this.view.ExtraCharges;   // tmpinterest.Tod_SchargeInterest = MExtInterest
                    //}

                    #region vb
                    // ''''' FOR TOD SCHARGE
                    // If pAtype = "TOD" Or pAtype = "TOD_REMIT" Then

                    //    Call CalExtraInt
                    //    tmpInterest.Tod_SchargeInterest = MExtInterest
                    //End If
                    #endregion
            }
            return tmpinterest;
        }

        //public void CalculateSInt(string accountNo,string lno,string aType,decimal servicesCharges, string qtrLI)   //CalSInt(Scharge#, Qtr$)
        public void CalculateSInt(string accountNo, string lno, string aType, decimal servicesCharges, string termNo)   //CalSInt(Scharge#, Qtr$)
        {
            decimal OpeningBal;
            decimal CurrentBalance;
            Nullable<DateTime> OpenDate;            
            DateTime CurrentDate;
            Nullable<DateTime> TlfDate = null;
            DateTime dt;
            decimal  Interest1;
            decimal  Interest2;
            decimal Ovdlimit;          
            decimal Used;
            decimal Unused;
            decimal TotalInterest = 0;           
            decimal SCharge; 
            string SBudMTh;

            string loansSDate = Qsdate.ToString("yyyy/mm/dd");
            int CurrentMonth = DateTime.Now.Month;
            int CurrentYear = DateTime.Now.Year;
            DateTime StartOfMonth = Convert.ToDateTime(CurrentMonth + "/01/" + CurrentYear);
            //DateTime EndOfMonth = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            string endMonth = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime EndOfMonth = DateTime.ParseExact(endMonth, "dd/MM/yyyy", null);

            string CurQtr = CXCOM00010.Instance.GetBudgetMonth4();

            string budmth = "M" + CXCOM00010.Instance.GetBudgetMonth();
            
            SBudMTh = "S" + CXCOM00010.Instance.GetBudgetMonth();
            string BudYear = CXCOM00010.Instance.GetBudgetYear4(CXCOM00009.BudgetYearCode, DateTime.Now);

            PFMDTO00009 SChargeRate = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "ODSCHARGERATE", true, true }); //hm

            //if (aType == "LOANS")
            //{
            //    int daysInYear = this.DaysInYear();
            //    int period = CurQtr == "Q1" ? 1 : CurQtr == "Q2" ? 2 : CurQtr == "Q3" ? 3 : 4;
            //    decimal returnLaonSCharges = CXClientWrapper.Instance.Invoke<ILOMSVE00016, decimal>(x => x.GetLoanSCharges_NewLogic(this.View.LoanNo, daysInYear, Qsdate, Qedate, termNo, 0));                
            //        //exec Sp_LoanScharge '" & TxtLno1.Text & "'," & Daysinyear & " ," & " '" & LoansSDate & "','" & Format(Date - 1, "yyyy/mm/dd") & "'," & CurQtr & ",
            //    TotalInterest = LoanScharges;
            //}
            if (aType == "LOANS")
            {
                int daysInYear = this.DaysInYear();
                LOMDTO00021 loanScharges = CXClientWrapper.Instance.Invoke<ILOMSVE00016, LOMDTO00021>(x => x.CalculateLoanScharge(this.View.LoanNo, daysInYear, Qsdate, Qedate, termNo, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));                
                TotalInterest = loanScharges.InterestAmount.Value;
            }
            else  //OD
            {
                PFMDTO00033 Bal= CXClientWrapper.Instance.Invoke<ILOMSVE00016, PFMDTO00033>(x => x.GetAccountInfoFromCledgerAndBal(BudYear, EndOfMonth,accountNo,CurrentUserEntity.BranchCode));
                //"Select Cledger.Acctno,Cledger.Acsign,Cledger.Date_time,Cledger.Ovdlimit,Cledger.Usedrate,Cledger.Unusedrate, Bal." & budmth & " From Cledger,Bal WITH(NOLOCK) Where Bal.Budget = " & "'" & BudYear & "'" & " and convert(Char(10),Cledger.date_time,111) <= '" & Format(EndofMonth, "yyyy/mm/dd") & "' and Isnull(Cledger.CloseDate,'') = ''  And Cledger.Acsign Like 'C%' and Cledger.acctno = Bal.acctno And ( Cledger.Ovdlimit <> 0 or Cledger.TODLimit<>0) And Cledger.Acctno ='" & txtAcctNo.Value & "'"
                if (Bal == null)
                {
                    //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90022);  
                    throw new Exception(CXMessage.MI90022); //No Record to Calculate" & vbLf & "Please carefully check data associated with this loans no"                    
                    //this.ClearControls();
                    //return;
                }
                else
                {
                    IList<TLMDTO00018> LoansAccountInfo = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<TLMDTO00018>>(x => x.GetLoansAccountInfoByAccountNo( accountNo, CurrentUserEntity.BranchCode));
                    //Select Sdate From Loans with(nolock) Where Isnull(Closedate,'') = '' and Acctno = '" & txtAcctNo.Value & "' And Atype <> 'LOANS'"
                    if (LoansAccountInfo != null)
                    {
                        if (LoansAccountInfo.Count > 0)
                        {
                            switch (budmth)
                            {
                                case "M1": OpeningBal = Bal.Month1; break;                                   
                                case "M2": OpeningBal = Bal.Month2; break;
                                case "M3": OpeningBal = Bal.Month3; break;
                                case "M4": OpeningBal = Bal.Month4; break;
                                case "M5": OpeningBal = Bal.Month5; break;
                                case "M6": OpeningBal = Bal.Month6; break;
                                case "M7": OpeningBal = Bal.Month7; break;
                                case "M8": OpeningBal = Bal.Month8; break;
                                case "M9": OpeningBal = Bal.Month9; break;
                                case "M10": OpeningBal = Bal.Month10; break;
                                case "M11": OpeningBal = Bal.Month11; break;
                                case "M12": OpeningBal = Bal.Month12; break;
                                default: OpeningBal = 0; break;
                            }
                            OpenDate = Bal.Date_Time;
                            Ovdlimit = Bal.OverdraftLimit;
                            Used = Bal.UsedRate;
                            Unused = Bal.UnUsedRate;

                            if (OpenDate.Value.Month == DateTime.Now.Month && OpenDate.Value.Year == DateTime.Now.Year)
                            {
                                CurrentBalance = 0;
                                CurrentDate = OpenDate.Value;
                            }
                            else
                            {
                                CurrentBalance = OpeningBal;
                                if (Convert.ToDateTime(OpenDate.Value.ToShortDateString()) < Convert.ToDateTime(StartOfMonth.ToShortDateString()))
                                    CurrentDate = StartOfMonth;
                                else
                                    CurrentDate = OpenDate.Value;
                            }

                            // for OD A/C is Closed in Same Month
                            IList<PFMDTO00042> ReportTlfList = CXClientWrapper.Instance.Invoke<ILOMSVE00016, IList<PFMDTO00042>>(x => x.GetDataFromReportTlf(accountNo, StartOfMonth, EndOfMonth, CurrentUserEntity.WorkStationId, CurrentUserEntity.BranchCode));
                            //"Select Acctno, Amount, Date_Time From VW_MTHSCHARGE With (NoLock) where ltrim(Rtrim(WorkStation)) = '" & Environ("COMPUTERNAME") & "' And Date_time between '" & Format(StartofMonth, "yyyy/mm/dd") & "' and '" & Format(EndofMonth, "yyyy/mm/dd") & "' and acctno = '" & txtAcctno.Value & "
                            if (ReportTlfList != null)
                            {
                                if (ReportTlfList.Count > 0)
                                {
                                    foreach (PFMDTO00042 reportTlf in ReportTlfList)
                                    {
                                        CurrentBalance += reportTlf.Amount.Value;
                                        TlfDate = reportTlf.DATE_TIME.Value;
                                        dt = reportTlf.DATE_TIME.Value;

                                        if (Convert.ToDateTime(TlfDate.Value.ToShortDateString()) > Convert.ToDateTime(CurrentDate.ToShortDateString()))
                                        {
                                            if (CurrentBalance < 0 && Convert.ToDateTime(LoansAccountInfo[0].SDate.Value.ToShortDateString()) <= Convert.ToDateTime(TlfDate.Value.ToShortDateString()))
                                            {
                                                Interest1 = this.UsedInterest(CurrentBalance, CurrentDate.Subtract(TlfDate.Value).Days, SChargeRate.Rate);
                                                Interest2 = 0;
                                            }
                                            else
                                            {
                                                Interest1 = 0;
                                                Interest2 = 0;
                                            }
                                            TotalInterest += Interest1 + Interest2;
                                        }
                                        #region vb
                                        //    CurrentBalance = CurrentBalance + .rdoColumns("Amount")
                                        //    TlfDate = .rdoColumns("Date_Time")
                                        //    ' Modified by AAL for OD A/C is Closed in Same Month
                                        //    If TlfDate > Format(InterestDate, "mm/dd/yyyy") And TlfDate <> Format(CurrentDate, "mm/dd/yyyy") Then
                                        //        If InterestBalance < 0 And Format(SDate, "mm/dd/yyyy") <= TlfDate Then
                                        //            Interest1 = UseInt(InterestBalance, DateDiff("d", InterestDate, TlfDate), SChargeRate)
                                        //            Interest2 = 0
                                        //        Else
                                        //            Interest1 = 0
                                        //            Interest2 = 0
                                        //        End If

                                        //        TotalInterest = TotalInterest + Interest1 + Interest2
                                        //        InterestBalance = CurrentBalance
                                        //        InterestDate = TlfDate
                                        //    Else
                                        //        InterestBalance = CurrentBalance
                                        //    End If
                                        //    .MoveNext
                                        //Wend
                                        #endregion
                                    }

                                    if (CurrentBalance < 0)
                                    {
                                        Interest1 = this.UsedInterest(CurrentBalance, EndOfMonth.Subtract(TlfDate.Value).Days, SChargeRate.Rate);
                                        Interest2 = 0;
                                    }
                                    else
                                    {
                                        Interest1 = 0;
                                        Interest2 = 0;
                                    }
                                    TotalInterest += Interest1 + Interest2;
                                }
                            }
                            MNMDTO00027 SchargeDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00016, MNMDTO00027>(x => x.GetSCharge(InterestMonths, BudYear, accountNo, lno, CurrentUserEntity.BranchCode)); //Scharge Table
                            {                       //Select IntMonths = M10+M11+M12 - M10 ,LastDate,LastInt From Scharge Where Acctno = '001111000001326' and lno = 'L001' And Isnull(Closedate,'') = ''
                                if (SchargeDTO != null)
                                {
                                    switch (InterestMonths)
                                    {
                                        case "M1+M2+M3": SCharge = SchargeDTO.M1 + SchargeDTO.M2 + SchargeDTO.M3 - (budmth == "M1" ? SchargeDTO.M1 : budmth == "M2" ? SchargeDTO.M2 : budmth == "M3" ? SchargeDTO.M3 : budmth == "M4" ? SchargeDTO.M4 : budmth == "M5" ? SchargeDTO.M5 : budmth == "M6" ? SchargeDTO.M6 : 
                                                                          budmth == "M7" ? SchargeDTO.M7 : budmth == "M8" ? SchargeDTO.M8 : budmth == "M9" ? SchargeDTO.M9 : budmth == "M10" ? SchargeDTO.M10 : budmth == "M11" ? SchargeDTO.M11 : SchargeDTO.M12 ) + TotalInterest;
                                            break;

                                        case "M4+M5+M6": SCharge = SchargeDTO.M4 + SchargeDTO.M5 + SchargeDTO.M6 - (budmth == "M1" ? SchargeDTO.M1 : budmth == "M2" ? SchargeDTO.M2 : budmth == "M3" ? SchargeDTO.M3 : budmth == "M4" ? SchargeDTO.M4 : budmth == "M5" ? SchargeDTO.M5 : budmth == "M6" ? SchargeDTO.M6 :
                                                                      budmth == "M7" ? SchargeDTO.M7 : budmth == "M8" ? SchargeDTO.M8 : budmth == "M9" ? SchargeDTO.M9 : budmth == "M10" ? SchargeDTO.M10 : budmth == "M11" ? SchargeDTO.M11 : SchargeDTO.M12) + TotalInterest;
                                            break;

                                        case "M7+M8+M9": SCharge = SchargeDTO.M7 + SchargeDTO.M8 + SchargeDTO.M9 - (budmth == "M1" ? SchargeDTO.M1 : budmth == "M2" ? SchargeDTO.M2 : budmth == "M3" ? SchargeDTO.M3 : budmth == "M4" ? SchargeDTO.M4 : budmth == "M5" ? SchargeDTO.M5 : budmth == "M6" ? SchargeDTO.M6 :
                                                                      budmth == "M7" ? SchargeDTO.M7 : budmth == "M8" ? SchargeDTO.M8 : budmth == "M9" ? SchargeDTO.M9 : budmth == "M10" ? SchargeDTO.M10 : budmth == "M11" ? SchargeDTO.M11 : SchargeDTO.M12) + TotalInterest;
                                            break;

                                        case "M10+M11+M12": SCharge = SchargeDTO.M10 + SchargeDTO.M11 + SchargeDTO.M12 - (budmth == "M1" ? SchargeDTO.M1 : budmth == "M2" ? SchargeDTO.M2 : budmth == "M3" ? SchargeDTO.M3 : budmth == "M4" ? SchargeDTO.M4 : budmth == "M5" ? SchargeDTO.M5 : budmth == "M6" ? SchargeDTO.M6 :
                                                                      budmth == "M7" ? SchargeDTO.M7 : budmth == "M8" ? SchargeDTO.M8 : budmth == "M9" ? SchargeDTO.M9 : budmth == "M10" ? SchargeDTO.M10 : budmth == "M11" ? SchargeDTO.M11 : SchargeDTO.M12) + TotalInterest;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                } 
            }
        }

        public void CalculateExtraInterest(string accountNo)  //CalExtraInt()
        { 
        //    string budmth ;
        //    string BudYear;
        //    string OdAcctno;

        //    decimal OpeningBal;
        //    decimal CurrentBalance; 
        //    decimal InterestBalance;

        //    string BalString;
        //    Nullable<DateTime> OpenDate;
        //    DateTime interestDate;
        //    DateTime CurrentDate;
        //    DateTime TlfDate;
        //    decimal TotalInterest;
        //    decimal Interest1 ;
        //    decimal Interest2 ;
        //    decimal Ovdlimit;
        //    DateTime SDate ;
        //    decimal Used;
        //    decimal UnUsed;

        //    //' Extra Charges
        //    DateTime ExpireDate;
        //    decimal ExtraCharges ;
        //    decimal TotalExtraCharges;
        //    decimal OneDayInterest;            
        //    string SBudMTh;
        //    int Cmonth ;
        //    int Cyear;

        //    decimal Tint1 ;

        //    decimal LastInt;
        //    bool bAlreadyExpired ;
        //    bool bExpiredLater;
        //    bool bExpiredWithin;

        //   // string loansSDate = Qsdate.ToString("yyyy/mm/dd");
        //    int CurrentMonth = DateTime.Now.Month;
        //    int CurrentYear = DateTime.Now.Year;
        //    DateTime StartOfMonth = Convert.ToDateTime(CurrentMonth + "/01/" + CurrentYear);
        //    DateTime EndOfMonth = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

        //    string CurQtr = CXCOM00010.Instance.GetBudgetMonth4();

        //    budmth = "M" + CXCOM00010.Instance.GetBudgetMonth();
        //    SBudMTh = "S" + CXCOM00010.Instance.GetBudgetMonth();
        //    BudYear = CXCOM00010.Instance.GetBudgetYear4(CXCOM00009.BudgetYearCode, DateTime.Now);

        //    PFMDTO00009 ExtraChargeRate = CXCOM00010.Instance.GetRateFromRateFile("Tscharges");

        //    PFMDTO00033 Bal = CXClientWrapper.Instance.Invoke<ILOMSVE00016, PFMDTO00033>(x => x.GetAccountInfoFromCledgerAndBal(BudYear, EndOfMonth, accountNo, CurrentUserEntity.BranchCode));
        }

        public decimal UsedInterest(decimal amount, int days, decimal rate)
        {
            int daysInYear = this.DaysInYear();
            decimal usedInterest = Math.Abs(amount * rate / 100 / daysInYear * days);
            return usedInterest;
        }
 
        public int DaysInYear()
        {
            int daysInYear;

            if (DateTime.IsLeapYear(DateTime.Now.Year))
                return daysInYear = 366;
            else
                return daysInYear = 365;
        }

        public void Save()
        {
            this.view.Status = string.Empty;
            //if (!ValidateForm(this.GetEntity()))
            //    return;         

            //if (string.IsNullOrEmpty(this.view.LegalCaseLawyer))
            //{
            //    CXUIMessageUtilities.ShowMessageByCode("MV90072"); //Legal Lawyer cannot be blank   
            //    this.view.Status = "err";
            //    return;
            //}
           
            if (!this.ValidateForm(this.GetEntity()))
            {
                return;
            }
            else
            {

                LOMDTO00013 Legaldto = this.GetLegalCaseData();
                CXClientWrapper.Instance.Invoke<ILOMSVE00016>(x => x.SaveLegalCase(Legaldto, CurrentUserEntity.CurrentUserName, this.View.LegalCaseLawyer));
            }
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);  //Saving Successfully
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);  //err           
            }
        }

        public LOMDTO00013 GetLegalCaseData()
        {
            LOMDTO00013 LegalCaseDto = new LOMDTO00013();
            try
            {
                LegalCaseDto.Lno = this.view.LoanNo;
                LegalCaseDto.AcctNo = this.view.AccountNo;
                LegalCaseDto.AcType  = this.view.AdvanceType;
                LegalCaseDto.LegalDate = DateTime.Now;
                if(MAType == "LOANS")
                    LegalCaseDto.Bal = this.view.SanctionAmount;
                else
                    LegalCaseDto.Bal = this.view.LedgerBalance;

                LegalCaseDto.NewBal = this.view.LedgerBalance ;
                LegalCaseDto.OldInt = this.view.Interest;
                LegalCaseDto.OldScharge = this.view.ServicesCharges;
                LegalCaseDto.OldExtra  = this.view.ExtraCharges;               
                LegalCaseDto.IntRate = this.view.InterestRate ;
                LegalCaseDto.AcceptDate = DateTime.Now;
                LegalCaseDto.SourceBr = CurrentUserEntity.BranchCode ;
                LegalCaseDto.Cur = currency;                
                LegalCaseDto.CreatedUserId = CurrentUserEntity.CurrentUserID;                
                LegalCaseDto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            }
            catch
            {
                throw new Exception(CXMessage.ME00021);    //Client Data Not Found.
            }
            return LegalCaseDto;
        }

        public void ClearControls()
        {   
            this.view.AccountNo = string.Empty;
            this.view.AdvanceType = string.Empty;
            this.view.InterestRate = 0;
            this.view.ServicesCharges = 0;
            this.view.LedgerBalance = 0;
            this.view.SanctionAmount = 0;
            this.view.Interest = 0;
            this.view.ExtraCharges = 0;
            this.view.LegalCaseLawyer = string.Empty;
            this.SetFocus("txtLoanNo");
        }

        #endregion

        #region LegalRelease Method
        
        public void Release()
        {

            if (!ValidateForm(this.GetEntity()))
                return;

            try
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00020) == DialogResult.Yes) //Are you sure to release.?
                {
                    CXClientWrapper.Instance.Invoke<ILOMSVE00016>(x => x.ReleaseLegalSueCase(this.view.LoanNo, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90023); //This loan is now release from legal case.                   
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
