//----------------------------------------------------------------------
// <copyright file="TCMSVE00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// System Start Up Service
    /// </summary>
    public class TCMSVE00014 : BaseService, ITCMSVE00014
    {
        #region DAO
        public IPFMDAO00056 SysDAO { get; set; }
        public ITCMDAO00001 StartDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00075 RateInfoDAO { get; set; }
        public IPFMDAO00009 RateFileDAO { get; set; }
        public ITLMDAO00018 LoansDAO { get; set; }
        public IPFMDAO00057 NewsetupDAO { get; set; }
        public ICXSVE00010 SPDAO { get; set; }
        public IMNMDAO00012 LegalIntDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITCMDAO00002 ServiceChargesDAO { get; set; }
        public ITCMDAO00003 NPLINTDAO { get; set; }
        public ICXSVE00006 CodeCheckerDAO { get; set; }
        #endregion

        #region Helper Method

        public IList<PFMDTO00075> SelectAllByLastModify()
        {
            IList<PFMDTO00075> rateInfodtos = this.RateInfoDAO.SelectAllByLastModify();
            return rateInfodtos;

        }

        public void GetHelp(string sourcebr, int updateduserid)
        {
            this.StartDAO.UpdateBySourceBr(sourcebr, updateduserid, "C");

            this.ServiceResult.ErrorOccurred = false;
            this.ServiceResult.MessageCode = CXMessage.MI50004;
        }


        public DateTime[] GetQuarterStartAndEndDate()
        {
            DateTime[] dtReturn = new DateTime[2];
            DateTime dtNow = System.DateTime.Now;
            if (dtNow.Month >= 1 && dtNow.Month <= 3)
            {
                dtReturn[0] = DateTime.Parse("1/1/" + dtNow.Year.ToString());
                dtReturn[1] = DateTime.Parse("3/31/" + dtNow.Year.ToString());
            }
            else if (dtNow.Month >= 4 && dtNow.Month <= 6)
            {
                dtReturn[0] = DateTime.Parse("4/1/" + dtNow.Year.ToString());
                dtReturn[1] = DateTime.Parse("6/3/" + dtNow.Year.ToString());
            }
            else if (dtNow.Month >= 7 && dtNow.Month <= 9)
            {
                dtReturn[0] = DateTime.Parse("7/1/" + dtNow.Year.ToString());
                dtReturn[1] = DateTime.Parse("9/30/" + dtNow.Year.ToString());
            }
            else if (dtNow.Month >= 10 && dtNow.Month <= 12)
            {
                dtReturn[0] = DateTime.Parse("10/1/" + dtNow.Year.ToString());
                dtReturn[1] = DateTime.Parse("12/31/" + dtNow.Year.ToString());
            }
            return dtReturn;
        }
        #endregion

        #region Main Method

        public TCMDTO00001 SelectStartBySourceBr(string sourcebr)
        {
            try
            {
                DateTime sysDate = this.SysDAO.SelectSysDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixInterestDate), sourcebr);

                TCMDTO00001 startdto = this.StartDAO.SelectStartBySourceBr(sourcebr);
                if (startdto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90047";//System Start Up File has no record.
                    return null;
                }
                else
                {
                    startdto.FixInterestDate = sysDate;
                    return startdto;
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00064;
                return null;

            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool StartUp(TCMDTO00001 startdto)
        {
            try
            {
                #region Start.Date!= GetDate
                if (startdto.Date.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    if (startdto.Status != "C")
                    {
                        this.CledgerDAO.UpdateDOBal(startdto.SourceBr, DateTime.Now, startdto.UpdatedUserId.Value);
                        this.GetHelp(startdto.SourceBr, startdto.UpdatedUserId.Value);
                        return true;
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.ME00066; //Please change System Date to {0} and Shut Down First.
                        return false; 
                    }

                }
                #endregion

                #region Start.Date = GetDate
                else
                {
                    if (startdto.Status == "I")
                    {
                        this.GetHelp(startdto.SourceBr, startdto.UpdatedUserId.Value);
                        return true;
                    }

                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV20076;
                        return false;
                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00064;
                throw new Exception(this.ServiceResult.MessageCode);
                //return false;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void GetCurRate(int updatedUserid, IList<PFMDTO00075> rateInfodtos, PFMDTO00075 newRateDto,int rowCount, DataVersionChangedValueDTO dvcvDto)
        {
            try
            { 
                IList<DataVersionChangedValueDTO> dvcvList = new List<DataVersionChangedValueDTO>();
                dvcvList.Add(dvcvDto);
                this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, updatedUserid, newRateDto.Id.ToString());
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "LastModify", false }, { "UpdatedUserId", updatedUserid }, { "UpdatedDate", DateTime.Now } };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", newRateDto.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00074", updateColumnsandValues, whereColumnsandValues));
            
                    //if (j == i)
                    if (rowCount == rateInfodtos.Count)
                    {
                        this.RateInfoDAO.UpdateByLastModify(updatedUserid);
                        if (rateInfodtos.Count > 0)
                        {
                            foreach (PFMDTO00075 item in rateInfodtos)
                            {
                                PFMORM00074 rateInfo = new PFMORM00074();
                                //rateInfo.Id = item.Id;
                                rateInfo.Id = this.RateInfoDAO.SelectMaxId() + 1;
                                rateInfo.CurrencyCode = item.CurrencyCode;
                                rateInfo.RateType = item.RateType;
                                rateInfo.Rate = item.Rate;
                                rateInfo.DenoRate = item.DenoRate;
                                rateInfo.RegisterDate = DateTime.Now;
                                rateInfo.LastModify = true;
                                rateInfo.ToCurrencyCode = item.ToCurrencyCode;
                                rateInfo.CreatedUserId = item.CreatedUserId;
                                rateInfo.CreatedDate = DateTime.Now;
                                this.RateInfoDAO.Save(rateInfo);

                                PFMDTO00075 itemInfo = new PFMDTO00075();
                                itemInfo.Id = rateInfo.Id;
                                itemInfo.CurrencyCode = rateInfo.CurrencyCode;
                                itemInfo.RateType = rateInfo.RateType;
                                itemInfo.Rate = rateInfo.Rate;
                                itemInfo.DenoRate = rateInfo.DenoRate;
                                itemInfo.RegisterDate = rateInfo.RegisterDate;
                                itemInfo.LastModify = rateInfo.LastModify;
                                itemInfo.ToCurrencyCode = rateInfo.ToCurrencyCode;
                                itemInfo.CreatedUserId = rateInfo.CreatedUserId;
                                itemInfo.CreatedDate = rateInfo.CreatedDate;

                                //**save rateInfo in Sqlite
                                this.SaveServerAndServerClient(itemInfo);
                                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), rateInfo.CreatedUserId, rateInfo.Id.ToString());
                                //**End save
                            }
                        }
                        else
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = CXMessage.ME00067;
                        }
                    }
                   
                    //}
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateRateInfo_ForCurRate(int currentuserId, DateTime clientDate, IList<DataVersionChangedValueDTO> dvcvList, int rowcount, IList<PFMDTO00075> newrateinfos, IList<PFMDTO00075> rateinfos)
        {
            for (int i = 0; i < rowcount - 1;  i++)
                this.GetCurRate(currentuserId, rateinfos, newrateinfos[i], i + 1 , dvcvList[i]);           
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CalculateServiceCharge(int createduserid, string sourcebr)
        {
            try
            {
                #region Require Fields
                decimal doAmt = 0;
                PFMDTO00009 ratefiledto = this.RateFileDAO.SelectByCode("SCHARGENEW");
                if (ratefiledto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00065;
                    return false;
                }
                decimal scharges = ratefiledto.Rate;
                int daysinyear = new DateTime(DateTime.Now.Year, 12, 31).DayOfYear;
                string CoaSetupLsIncome = CXCOM00010.Instance.GetCoaSetupAccountNo("SCHARGENEW", sourcebr);
                if (string.IsNullOrEmpty(CoaSetupLsIncome))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI30024;
                    return false;
                }

                //Remove comment if you want to calculate sundryod
                string CoaSetupNPLLsIncome = CXCOM00010.Instance.GetCoaSetupAccountNo("SUNDRYOD", sourcebr);
                if (string.IsNullOrEmpty(CoaSetupNPLLsIncome))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MI30024;
                    return false;
                }

                PFMDTO00056 sys001dto = this.SysDAO.SelectAllByName("SERVICE_EXPIRED", sourcebr);
                if (sys001dto == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30028";
                    return false;
                }

                DateTime[] dt = this.GetQuarterStartAndEndDate();
                TimeSpan sysdate = (DateTime.Today.AddDays(-1)).Subtract(sys001dto.SysDate.Value);
                int sysdatecount = Convert.ToInt32(sysdate.TotalDays);
                #endregion

                #region Update Settlement Date
                if (!this.SysDAO.UpdateDatePosting("SERVICE_EXPIRED", sourcebr, createduserid))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI90005";
                    return false;
                }
                #endregion

                #region 1 Qtr deduct For Over.Exp

                if (DateTime.Now.Month == 4 || DateTime.Now.Month == 7 || DateTime.Now.Month == 12 || DateTime.Now.Month == 1)
                {
                    if (DateTime.Now.Month != sys001dto.SysDate.Value.Month)
                    {
                        IList<TLMDTO00018> loan = this.LoansDAO.SelectLoanLessthanSysDate(sourcebr, sys001dto.SysDate.Value);

                        if (loan.Count > 0)
                        {

                            if (sysdatecount >= 0)
                            {
                                this.NewsetupDAO.UpdateByVariable("RunTrigger", "Disable", createduserid);

                                #region Loop
                                foreach (TLMDTO00018 item in loan)
                                {
                                    #region Require Data
                                    TimeSpan ts = dt[1].Subtract(dt[0]);
                                    int restday = Convert.ToInt32(ts.TotalDays + 1);
                                    if (item.SAmount != null)
                                    {
                                        doAmt = (item.SAmount.Value * (ratefiledto.Rate / 100) / daysinyear) * restday;
                                    }

                                    string voucherNo = this.CodeGenerator.GetGenerateCode("ServiceVoucher", string.Empty, createduserid, sourcebr);
                                    decimal rate = CXCOM00010.Instance.GetExchangeRate(item.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                                    DateTime settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourcebr ,true });
                                    #endregion

                                    #region Not Legal
                                    if (!item.LegalCase)
                                    {
                                        CXDTO00010 servicechargedto = new CXDTO00010();
                                        servicechargedto.ENO = voucherNo;
                                        servicechargedto.MACCTNO = item.AccountNo;
                                        servicechargedto.LNO = item.Lno;
                                        servicechargedto.NAR = "Service Charges for expired";
                                        servicechargedto.AMOUNT = doAmt;
                                        servicechargedto.OAMOUNT = 0;
                                        servicechargedto.USERNO = Convert.ToString(createduserid);
                                        servicechargedto.VOUSTATUS = "D";
                                        servicechargedto.TSTATUS = false;
                                        servicechargedto.CUR = item.Currency;
                                        servicechargedto.HOMEEXRATE = rate;
                                        servicechargedto.SOURCEBR = sourcebr;
                                        servicechargedto.SETTLEMENTDATE = settlementdate;
                                        servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                        this.SPDAO.ServiceCharges(servicechargedto);

                                        #region NPL
                                        if (item.NPLDate == null && item.NPLCase == false)
                                        {
                                            CXDTO00010 nplservicechargedto = new CXDTO00010();
                                            servicechargedto.ENO = voucherNo;
                                            servicechargedto.MACCTNO = CoaSetupLsIncome;
                                            servicechargedto.LNO = item.Lno;
                                            servicechargedto.NAR = "Service Charges for expired";
                                            servicechargedto.AMOUNT = doAmt;
                                            servicechargedto.OAMOUNT = 0;
                                            servicechargedto.USERNO = Convert.ToString(createduserid);
                                            servicechargedto.VOUSTATUS = "C";
                                            servicechargedto.TSTATUS = false;
                                            servicechargedto.CUR = item.Currency;
                                            servicechargedto.HOMEEXRATE = rate;
                                            servicechargedto.SOURCEBR = sourcebr;
                                            servicechargedto.SETTLEMENTDATE = settlementdate;
                                            servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                            this.SPDAO.ServiceCharges(servicechargedto);
                                        }

                                        else
                                        {
                                            CXDTO00010 nplservicechargedto = new CXDTO00010();
                                            servicechargedto.ENO = voucherNo;
                                            servicechargedto.MACCTNO = CoaSetupNPLLsIncome;
                                            servicechargedto.LNO = item.Lno;
                                            servicechargedto.NAR = "Service Charges for expired";
                                            servicechargedto.AMOUNT = doAmt;
                                            servicechargedto.OAMOUNT = 0;
                                            servicechargedto.USERNO = Convert.ToString(createduserid);
                                            servicechargedto.VOUSTATUS = "C";
                                            servicechargedto.TSTATUS = false;
                                            servicechargedto.CUR = item.Currency;
                                            servicechargedto.HOMEEXRATE = rate;
                                            servicechargedto.SOURCEBR = sourcebr;
                                            servicechargedto.SETTLEMENTDATE = settlementdate;
                                            servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

                                            this.SPDAO.NPLServiceCharges(servicechargedto);

                                        }
                                        #endregion

                                        #region Insert Service Charges

                                        if (item.NPLDate == null && item.NPLCase == false)
                                        {
                                            TCMORM00002 servicecharges = new TCMORM00002();
                                            servicecharges.LNo = item.Lno;
                                            servicecharges.AcctNo = item.AccountNo;
                                            servicecharges.Desp = "Expired Loans/OD Service Charges";
                                            servicecharges.GetColo = "Expired Loans/OD Service Charges";
                                            servicecharges.VouDate = DateTime.Now;
                                            servicecharges.Amount = doAmt;
                                            servicecharges.CreatedDate = DateTime.Now;
                                            servicecharges.CreatedUserId = createduserid;
                                            servicecharges.SourceBr = sourcebr;
                                            servicecharges.Cur = item.Currency;
                                            this.ServiceChargesDAO.Save(servicecharges);
                                        }

                                        else
                                        {
                                            TCMORM00002 servicecharges = new TCMORM00002();
                                            servicecharges.LNo = item.Lno;
                                            servicecharges.AcctNo = item.AccountNo;
                                            servicecharges.Desp = "'Expired NPL Loans/OD Service Charges";
                                            servicecharges.GetColo = "'Expired NPL Loans/OD Service Charges";
                                            servicecharges.VouDate = DateTime.Now;
                                            servicecharges.Amount = doAmt;
                                            servicecharges.CreatedDate = DateTime.Now;
                                            servicecharges.CreatedUserId = createduserid;
                                            servicecharges.SourceBr = sourcebr;
                                            servicecharges.Cur = item.Currency;
                                            this.ServiceChargesDAO.Save(servicecharges);

                                            TCMORM00003 nplint = new TCMORM00003();
                                            nplint.LNo = item.Lno;
                                            nplint.AcctNo = item.AccountNo;
                                            nplint.Narration = "'Expired NPL Loans/OD Service Charges";
                                            nplint.Date_Time = DateTime.Now;
                                            nplint.Amount = doAmt;
                                            nplint.CreatedDate = DateTime.Now;
                                            nplint.CreatedUserId = createduserid;
                                            nplint.SourceBr = sourcebr;

                                            this.NPLINTDAO.Save(nplint);
                                        }

                                        #endregion
                                    }

                                    #endregion

                                    #region Legal
                                    else
                                    {
                                        MNMORM00012 legalint = new MNMORM00012();
                                        legalint.LNo = item.Lno;
                                        legalint.AcctNo = item.AccountNo;
                                        legalint.AType = "S";
                                        legalint.Amount = doAmt;
                                        legalint.Date_Time = DateTime.Now;
                                        legalint.Narration = "Expired Services Charges For Legal Loans/OD";
                                        legalint.Type = CoaSetupLsIncome;
                                        legalint.UserNo = Convert.ToString(createduserid);
                                        legalint.CRAcctno = string.Empty;
                                        legalint.CreatedDate = DateTime.Now;
                                        legalint.CreatedUserId = createduserid;
                                        legalint.SourceBr = sourcebr;
                                        legalint.Cur = item.Currency;
                                        this.LegalIntDAO.Save(legalint);
                                    }
                                    #endregion


                                #endregion

                                    this.NewsetupDAO.UpdateByVariable("RunTrigger", "Enable", createduserid);
                                }

                            }
                        }
                    }

                }
                #endregion

                #region Have Expired Or Not

                IList<TLMDTO00018> loaninfo = this.LoansDAO.SelectLoanBetweenSysDateandToday(sourcebr, sys001dto.SysDate.Value);

                if (loaninfo.Count > 0)
                {
                    if (sysdatecount == 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MI50007;
                        //throw new Exception(this.ServiceResult.MessageCode);
                        //return false;
                    }
                    else
                    {
                        this.NewsetupDAO.UpdateByVariable("RunTrigger", "Disable", createduserid);

                        foreach (TLMDTO00018 item in loaninfo)
                        {
                            string voucherNo = this.CodeGenerator.GetGenerateCode("ServiceVoucher", string.Empty, createduserid, sourcebr, new object[] { });
                            PFMDTO00028 cledgerdto = this.CledgerDAO.SelectByAccountNoAndSourceBr(item.AccountNo, sourcebr);
                            decimal rate = CXCOM00010.Instance.GetExchangeRate(item.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                            DateTime settlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourcebr ,true});

                            if (cledgerdto != null)
                            {
                                int restofday = Convert.ToInt32(item.ExpireDate.Value.Subtract(dt[1]).TotalDays);
                                decimal douAmt = ((item.SAmount.Value * (ratefiledto.Rate / 100)) / daysinyear) * restofday;

                                if (!item.LegalCase)
                                {
                                    CXDTO00010 servicechargedto = new CXDTO00010();
                                    servicechargedto.ENO = voucherNo;
                                    servicechargedto.MACCTNO = item.AccountNo;
                                    servicechargedto.LNO = item.Lno;
                                    servicechargedto.NAR = "Service Charges for expired";
                                    servicechargedto.AMOUNT = douAmt;
                                    servicechargedto.OAMOUNT = 0;
                                    servicechargedto.USERNO = Convert.ToString(createduserid);
                                    servicechargedto.VOUSTATUS = "D";
                                    servicechargedto.TSTATUS = false;
                                    servicechargedto.CUR = item.Currency;
                                    servicechargedto.HOMEEXRATE = rate;
                                    servicechargedto.SOURCEBR = sourcebr;
                                    servicechargedto.SETTLEMENTDATE = settlementdate;
                                    servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                    this.SPDAO.ServiceCharges(servicechargedto);

                                    #region NPL
                                    if (item.NPLDate == null && item.NPLCase == false)
                                    {
                                        CXDTO00010 nplservicechargedto = new CXDTO00010();
                                        servicechargedto.ENO = voucherNo;
                                        servicechargedto.MACCTNO = CoaSetupLsIncome;
                                        servicechargedto.LNO = item.Lno;
                                        servicechargedto.NAR = "Service Charges for expired";
                                        servicechargedto.AMOUNT = douAmt;
                                        servicechargedto.OAMOUNT = 0;
                                        servicechargedto.USERNO = Convert.ToString(createduserid);
                                        servicechargedto.VOUSTATUS = "C";
                                        servicechargedto.TSTATUS = false;
                                        servicechargedto.CUR = item.Currency;
                                        servicechargedto.HOMEEXRATE = rate;
                                        servicechargedto.SOURCEBR = sourcebr;
                                        servicechargedto.SETTLEMENTDATE = settlementdate;
                                        servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                        this.SPDAO.ServiceCharges(servicechargedto);
                                    }

                                    else
                                    {
                                        CXDTO00010 nplservicechargedto = new CXDTO00010();
                                        servicechargedto.ENO = voucherNo;
                                        servicechargedto.MACCTNO = CoaSetupNPLLsIncome;
                                        servicechargedto.LNO = item.Lno;
                                        servicechargedto.NAR = "Service Charges for expired";
                                        servicechargedto.AMOUNT = douAmt;
                                        servicechargedto.OAMOUNT = 0;
                                        servicechargedto.USERNO = Convert.ToString(createduserid);
                                        servicechargedto.VOUSTATUS = "C";
                                        servicechargedto.TSTATUS = false;
                                        servicechargedto.CUR = item.Currency;
                                        servicechargedto.HOMEEXRATE = rate;
                                        servicechargedto.SOURCEBR = sourcebr;
                                        servicechargedto.SETTLEMENTDATE = settlementdate;
                                        servicechargedto.CHANNEL = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                                        this.SPDAO.NPLServiceCharges(servicechargedto);

                                    }
                                    #endregion

                                    #region Insert Service Charges

                                    if (item.NPLDate == null && item.NPLCase == false)
                                    {
                                        TCMORM00002 servicecharges = new TCMORM00002();
                                        servicecharges.LNo = item.Lno;
                                        servicecharges.AcctNo = item.AccountNo;
                                        servicecharges.Desp = "Expired Loans/OD Service Charges";
                                        servicecharges.GetColo = "Expired Loans/OD Service Charges";
                                        servicecharges.VouDate = DateTime.Now;
                                        servicecharges.Amount = douAmt;
                                        servicecharges.CreatedDate = DateTime.Now;
                                        servicecharges.CreatedUserId = createduserid;
                                        servicecharges.SourceBr = sourcebr;
                                        servicecharges.Cur = item.Currency;
                                        this.ServiceChargesDAO.Save(servicecharges);
                                    }

                                    else
                                    {
                                        TCMORM00002 servicecharges = new TCMORM00002();
                                        servicecharges.LNo = item.Lno;
                                        servicecharges.AcctNo = item.AccountNo;
                                        servicecharges.Desp = "Expired NPL Loans/OD Service Charges";
                                        servicecharges.GetColo = "Expired NPL Loans/OD Service Charges"; ;
                                        servicecharges.VouDate = DateTime.Now;
                                        servicecharges.Amount = douAmt;
                                        servicecharges.CreatedDate = DateTime.Now;
                                        servicecharges.CreatedUserId = createduserid;
                                        servicecharges.SourceBr = sourcebr;
                                        servicecharges.Cur = item.Currency;
                                        this.ServiceChargesDAO.Save(servicecharges);

                                        TCMORM00003 nplint = new TCMORM00003();
                                        nplint.LNo = item.Lno;
                                        nplint.AcctNo = item.AccountNo;
                                        nplint.Narration = "'Expired NPL Loans/OD Service Charges";
                                        nplint.Date_Time = DateTime.Now;
                                        nplint.Amount = douAmt;
                                        nplint.CreatedDate = DateTime.Now;
                                        nplint.CreatedUserId = createduserid;
                                        nplint.SourceBr = sourcebr;
                                        this.NPLINTDAO.Save(nplint);
                                    }

                                    #endregion

                                }

                                else
                                {
                                    MNMORM00012 legalint = new MNMORM00012();
                                    legalint.LNo = item.Lno;
                                    legalint.AcctNo = item.AccountNo;
                                    legalint.AType = "S";
                                    legalint.Amount = douAmt;
                                    legalint.Date_Time = DateTime.Now;
                                    legalint.Narration = "Expired Services Charges For Legal Loans/OD";
                                    legalint.Type = CoaSetupLsIncome;
                                    legalint.UserNo = Convert.ToString(createduserid);
                                    legalint.CRAcctno = string.Empty;
                                    legalint.CreatedDate = DateTime.Now;
                                    legalint.CreatedUserId = createduserid;
                                    legalint.SourceBr = sourcebr;
                                    legalint.Cur = item.Currency;
                                    this.LegalIntDAO.Save(legalint);
                                }
                            }
                        }


                        this.NewsetupDAO.UpdateByVariable("RunTrigger", "Enable", createduserid);

                    }

                }

                else
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV20078";
                    //throw new Exception(this.ServiceResult.MessageCode);
                   // return false;
                }

                #endregion

                return true;
            }

            catch(Exception ex)
            { throw new Exception(ex.Message); }
          
        }
        #endregion
       
        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00074 RateInfoORM = new PFMORM00074();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RateInfoORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            //CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }
        #endregion

        #region Client Server
        public void SaveServerAndServerClient(PFMDTO00075 item)
        {
            //PFMORM00074 rateInfo = null;
            PFMDTO00075 rateInfoEntity = null;
            try
            {
                rateInfoEntity = this.RateInfoDAO.SelectById(item.Id);
                if (rateInfoEntity != null)
                {
                    int lastmodify = 0;
                    if (rateInfoEntity.LastModify)
                        lastmodify = 1;

                    Dictionary<string, object> rateInfoKeyPair = new Dictionary<string, object> { { "Id", rateInfoEntity.Id }, { "Cur", rateInfoEntity.CurrencyCode }, { "RateType", rateInfoEntity.RateType }, { "Rate", rateInfoEntity.Rate }, { "DenoRate", rateInfoEntity.DenoRate }, { "RDate", rateInfoEntity.RegisterDate }, { "LastModify", lastmodify }, { "ToCur", rateInfoEntity.ToCurrencyCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RateInfo", rateInfoKeyPair, rateInfoEntity.TS, item.CreatedUserId, item.CreatedDate));                    
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
