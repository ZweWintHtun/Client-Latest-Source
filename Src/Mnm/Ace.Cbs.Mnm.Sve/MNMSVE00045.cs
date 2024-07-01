//----------------------------------------------------------------------
//<copyright file="MNMSVE00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>01/22/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00045:BaseService,IMNMSVE00045
    {
        DateTime date;
        //bool isAllBranch;
        ICXSVE00010 cxsve00010 { get; set; }
        IPFMDAO00036 csDAO { get; set; }
        ICXDAO00009 ViewDAO { get; set; }


        public IList<PFMDTO00042> print(bool isHomeCur,DateTime date,int updatedUserId,string dateType,string branchCode,string cur,string workstation,string sourceBr,bool isReversal)
        {
            decimal openingBalance;
            PFMDTO00042 BankCashDTO;
            IList<PFMDTO00042> PrintData;
            this.date = date;
            //this.isAllBranch = isAllBranch;
            PFMDTO00042 output = cxsve00010.GetReportDataGenerateInSQL(this.GetReportParameter(workstation,updatedUserId, dateType, branchCode));     //Call Store Procedure (insert Report_TLF)
            if (output == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039";     //No data for Report
                return null;
            }

            if (isHomeCur)
            {
                //SP_BANKING_BANKCASH_CALC_BYHOMECURALL
                BankCashDTO = this.cxsve00010.BankCashScroll(workstation, date, 1, dateType, branchCode, updatedUserId);

            }
            else
            {
                //sp_banking_bankcash_calc
                BankCashDTO = this.cxsve00010.BankCashScrollCALC(workstation, date, 1, dateType, cur, branchCode, updatedUserId);
            }

            if (BankCashDTO == null)
            {
                openingBalance = 0;
            }
            else
            {
                openingBalance = BankCashDTO.ReturnObalance;
            }

            IList<PFMDTO00036> CSDTO = this.csDAO.SelectByDateTime(date, sourceBr);
            if (CSDTO.Count > 0)
            {
                if (date > CSDTO[0].Date_Time.Value)
                {
                    this.ServiceResult.MessageCode = "MI00043," + CSDTO[0].Date_Time.Value.ToShortDateString(); //Cash Balance Will be carried from {0}
                }
            }

            if (isReversal)
            {
                PrintData = this.ViewDAO.SelectTrialSheetWithReversal(cur, workstation, sourceBr);
            }
            else
            {
                PrintData = this.ViewDAO.SelectTrialSheetWithoutReversal(cur, workstation, sourceBr);
            }

            PrintData.Add(BankCashDTO);
            return PrintData;
        }

        public CXDTO00006 GetReportParameter(string workstation,int createdUserId,string dateType,string branchCode)
        {
            CXDTO00006 reportParameter = new CXDTO00006();
            reportParameter.StartDate = this.date;
            reportParameter.EndDate = this.date;
            reportParameter.UserNo = workstation;
            reportParameter.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportParameter.BDateType = dateType;
            reportParameter.SpecialCondition = "SourceBr = '" + branchCode + "'";
            reportParameter.CreatedUserId = createdUserId;

            return reportParameter;
        }
    }
}
