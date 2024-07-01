//----------------------------------------------------------------------
// <copyright file="MNMSVE00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    ///Cash Voucher Reversal
    /// Service
    /// </summary>
    public class MNMSVE00008 : BaseService, IMNMSVE00008
    {
        #region "Properties"
      
        public IPFMDAO00054 TlfDAO { get; set; }
        public ITLMDAO00004 ibltlfDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 ReversalSVE { get; set; }

        #endregion

        #region "Main Methods"

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SelectTlfInfoByEntryNoandDateTime(string eno, string dtranCode, string ctranCode, string sourcebr)
        {
            IList<PFMDTO00054> tlflist = this.TlfDAO.SelectTlfInfoByEnoandDate(eno, dtranCode, ctranCode, sourcebr);
            if (tlflist.Count > 0)
            {
                foreach (PFMDTO00054 tlfdto in tlflist)
                {
                    string acctno = tlfdto.AccountNo;

                    if (this.ibltlfDAO.CheckExist(acctno))                 //check accountno in ibltlf(If not exist,return true)
                    {
                        if (!string.IsNullOrEmpty(tlfdto.OrgnEno))
                            {
                                this.ServiceResult.ErrorOccurred = true;
                                this.ServiceResult.MessageCode = "ME30003";     //Already Reverse
                                return null;
                            }
                            return tlflist;
                    }                

                    else
                    {    //if exist in IBLTLF
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV90001";        //data already exists 
                    }
                }
            }
        
            return null; 
        }

        [Transaction(TransactionPropagation.Required)]
        public string Save_CashVoucher(PFMDTO00054 entity)
        {
            string ReversalVouno = string.Empty;
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), entity.SourceBranchCode ,true});
           
            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            int updatedUserId = entity.CreatedUserId;

           //to get vouno => " R + day + month + year + serial "
            //ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Voucher", string.Empty, updatedUserId, entity.SourceBranchCode, new object[] { day, month, year });                                 //To get Reversal Voucher No 
            ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, updatedUserId, entity.SourceBranchCode, new object[] { day, month, year });
           //call common module for reversal process
            this.ReversalSVE.ReversalProcess(entity.Eno, ReversalVouno, null, entity.SourceBranchCode, entity.DateTime, entity.SourceBranchCode, updatedUserId, new TLMDTO00015(), string.Empty,true);  // Call Commodule to save Tlf table 

            return ReversalVouno;
        }

       #endregion
    }
}