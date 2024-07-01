//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00003 : BaseService, IMNMSVE00003
    {
        #region Properties

        IPFMDAO00042 report_TlfDAO { get; set; }
        IPFMDAO00033 balDAO { get; set; }
        IPFMDAO00057 newSetupDAO { get; set; }
        IPFMDAO00009 rateFileDAO { get; set; }
        ICXSVE00010 cxsve00010 { get; set; }
        ICXDAO00006 cxDao00006 { get; set; }
        IPFMDAO00040 siDAO { get; set; }
        IPFMDAO00056 Sys001DAO { get; set; }

        #endregion

        #region Private Variables

        DateTime m_FirstDay = default(DateTime);
        DateTime endDate = default(DateTime);
        string m_FileMonth = string.Empty;        
        IList<PFMDTO00042> reportTlfDTOlist = new List<PFMDTO00042>();
        IList<PFMDTO00042> interstList = new List<PFMDTO00042>();

        #endregion

        #region Methods

        [Transaction(TransactionPropagation.Required)]
        public void Save(int month, int year,int updatedUserId,string sourceBr,string WorkstationName)
        {
            this.GetStartDate_EndDate(month, year);

            PFMDTO00042 output = cxsve00010.GetReportDataGenerateInSQL(this.GetReportParameter(updatedUserId, WorkstationName,sourceBr));     //Call Store Procedure (insert Report_TLF)

            IList<PFMDTO00042> DebitList = this.report_TlfDAO.SelectReport_TLF(WorkstationName, month, year, "S", "D", sourceBr);  // Select Report_TLF Debit List
            IList<PFMDTO00042> CreditList = this.report_TlfDAO.SelectReport_TLF(WorkstationName, month, year, "S", "C", sourceBr);    //Select Report_TLF Credit List
            IList<PFMDTO00033> balList = this.balDAO.SelectBal(m_FirstDay, m_FileMonth, "S", sourceBr);    //Select Bal List
            PFMDTO00057 newSetupDTO = newSetupDAO.SelectByVariable("SAVINTDAY");    //Select Saving Interest Day
            DateTime calculateDate = Convert.ToDateTime(month.ToString() + "/" + newSetupDTO.Value + "/" + year);

            CreditList = CreditList.Where<PFMDTO00042>(x => x.DATE_TIME.Value.Date <= calculateDate.Date).ToList(); //Filter CreditList Before Saving Interest Day

            foreach (PFMDTO00042 reportTLF in DebitList)    //collect as Temp table
            {
                reportTLF.TransactionCode = "W";
                reportTLF.File_Month = m_FileMonth;
                reportTlfDTOlist.Add(reportTLF);    
            }

            foreach (PFMDTO00042 reportTLF in CreditList)   //collect as Temp table
            {
                reportTLF.TransactionCode = "D";
                reportTLF.File_Month = m_FileMonth;
                reportTlfDTOlist.Add(reportTLF);    
            }
            
            foreach (PFMDTO00033 bal in balList)    //collect as Temp table
            {
                PFMDTO00042 reportTlf = new PFMDTO00042();
                reportTlf.AcctNo = bal.AccountNo;
                reportTlf.DATE_TIME = bal.DATE_TIME;
                reportTlf.AccountSign = bal.AccountSign;
                reportTlf.TransactionCode = "C";
                reportTlf.File_Month = m_FileMonth;
                reportTlf.BalMonth = bal.Amt;

                reportTlfDTOlist.Add(reportTlf);
            }

            this.CalculateInterest(month, year);    //Interest Calculation
            this.UpdateInterest(updatedUserId);     //Update SI
            string sysMonYear = String.Format("{0:MM/yyyy}", DateTime.Now);
            this.Sys001DAO.UpdateSysMonYear(sysMonYear, updatedUserId, "SAV_INT_CAL", sourceBr);    //Update sys001 set SysMonYear
        }

        private void GetStartDate_EndDate(int month,int year)
        {
            m_FirstDay = Convert.ToDateTime(month.ToString() + "/01/" + year.ToString());
            m_FileMonth = month < 4 ? "M" + (month + 9).ToString() : "M" + (month - 3).ToString();

            if (month == DateTime.Now.Month)
            {
                endDate = DateTime.Now;
            }

            else if (month == 12)
            {
                endDate = Convert.ToDateTime(month.ToString() + "/31/" + year.ToString());
            }
            else
            {
                DateTime tempDate = Convert.ToDateTime((month + 1).ToString() + "/01/" + year.ToString());
                endDate = tempDate.AddDays(-1);
            }
        }

        private CXDTO00006 GetReportParameter(int createdUserId,string workstationName,string sourceBr)
        {
            CXDTO00006 reportParameter = new CXDTO00006();
            reportParameter.StartDate = m_FirstDay;
            reportParameter.EndDate = endDate;
            reportParameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportParameter.UserNo = workstationName;
            reportParameter.BDateType = "T";
            reportParameter.ACSign = "S";
            reportParameter.SpecialCondition = "sourceBr = '" + sourceBr + "'";
            reportParameter.CreatedUserId = createdUserId;           

            return reportParameter;
        }

        [Transaction(TransactionPropagation.Required)]
        private void CalculateInterest(int month,int year)
        {
            PFMDTO00009 rateFileDTO = this.rateFileDAO.SelectByCode("SAVINGRATE");  //Select Rate

            reportTlfDTOlist = reportTlfDTOlist.OrderBy(x => x.AcctNo).ToList();

            string tempAccountNo = string.Empty;
            string tempCloseAccountNo = string.Empty;
            decimal tempBal = 0;
            string closeAccount = string.Empty;

            foreach (PFMDTO00042 reportTLFDTO in reportTlfDTOlist)
            {
                if (reportTLFDTO.AcctNo != tempAccountNo)
                {
                    if (tempBal > 0)
                    {
                        decimal saving_Interest = ((tempBal * rateFileDTO.Rate) / 100) / 12;
                        PFMDTO00042 interestDTO = new PFMDTO00042();
                        interestDTO.AcctNo = tempAccountNo;
                        interestDTO.Amount = saving_Interest;
                        interstList.Add(interestDTO);
                    }

                    tempAccountNo = reportTLFDTO.AcctNo;
                    tempBal = 0;

                    if (!cxDao00006.CheckAccountNo(tempAccountNo))
                    {
                        closeAccount = tempAccountNo;
                        continue;
                    }
                }
                else
                {
                    if (reportTLFDTO.AcctNo == closeAccount)
                        continue;
                }

                if (reportTLFDTO.TransactionCode == "W")
                {
                    tempBal -= reportTLFDTO.Amount.Value;
                }
                else
                {
                    tempBal += reportTLFDTO.TransactionCode == "C" ? reportTLFDTO.BalMonth : reportTLFDTO.Amount.Value;
                }             
            }

            if (tempBal >= 0)
            {
                decimal saving_Interest = ((tempBal * rateFileDTO.Rate) / 100) / 12;
                PFMDTO00042 interestDTO = new PFMDTO00042();
                interestDTO.AcctNo = tempAccountNo;
                interestDTO.Amount = saving_Interest;
                interstList.Add(interestDTO);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        private void UpdateInterest(int updatedUserId)
        {
            foreach (PFMDTO00042 interestDTO in interstList)
            {
                bool IsUpdated = this.siDAO.UpdateInterest(interestDTO.AcctNo, interestDTO.Amount.Value, m_FileMonth, updatedUserId);
            }
        }

        #endregion
    }
}
