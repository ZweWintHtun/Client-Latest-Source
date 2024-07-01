//----------------------------------------------------------------------
// <copyright file="MNMSVE00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser>Haymar</UpdatedUser>
// <UpdatedDate>27/08/2014</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
//using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXServer.Utt;

namespace Ace.Cbs.Mnm.Sve
{
    class MNMSVE00009 : BaseService, IMNMSVE00009
    {
        #region Properties
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 CodeValidationChecker { get; set; }
        public IPFMDAO00054 TlfDao { get; set; }

        #endregion

        #region Main Method

        public IList<PFMDTO00054> SelectForClrVoucherReversal(string eno, string sourceBr)
        {
            IList<PFMDTO00054> tlfData = this.TlfDao.SelectForReversal(eno, sourceBr);
            if (tlfData.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30015"; //Entry No Not Found
                return null;
            }
            else if (!string.IsNullOrEmpty(tlfData[1].OrgnEno))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30003"; //Already Reverse
                return null;
            }
            else if (tlfData[1].DateTime.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
                return null;
            }
            
            return tlfData;
        }

        [Transaction(TransactionPropagation.Required)]
        public string Reverse(PFMDTO00054 tlfdto)
        {
            string ReversalVouno = string.Empty;
            //call server sqlite db for settlementdate from sys001 table 
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), tlfdto.SourceBranchCode ,true });

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            int updatedUserId = Convert.ToInt32(tlfdto.UpdatedUserId);

            //to get vouno => " R + day + month + year + serial "
            ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, updatedUserId, tlfdto.SourceBranchCode, new object[] { day, month, year });                                 //To get Reversal Voucher No 
            //call common module in CXSVE00006 for Reversal Process
            this.CodeValidationChecker.ReversalProcess(tlfdto.Eno, ReversalVouno, null, tlfdto.SourceBranchCode, tlfdto.DateTime, tlfdto.SourceBranchCode, updatedUserId, new Tel.Dmd.TLMDTO00015(), null,true);
            if (CodeValidationChecker.ServiceResult.ErrorOccurred)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30002"; //Not Allow Back Date Transaction
            }

            return ReversalVouno;
        }
        #endregion
    }
}
