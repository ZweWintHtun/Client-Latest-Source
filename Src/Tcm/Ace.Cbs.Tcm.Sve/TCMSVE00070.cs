//----------------------------------------------------------------------
// <copyright file="TCMSVE00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2014/08/01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tcm.Sve
{
    /* Gift Cheque Issued By Transfer ( Income ) Service*/
    /* Gift Cheque Issued By Transfer (No Income ) Service*/
    public class TCMSVE00070 : BaseService, ITCMSVE00070
    {
        #region "DAO & Service"
        private ICXSVE00006 CodeChecker { get; set; }
        private ICXSVE00010 DataGenerateSerice { get; set; }
        private IPFMDAO00006 ChequeDAO { get; set; }
        #endregion

        public TLMDTO00059 CheckAccountNo(string accountNo, bool isVIP, bool isWithIncome, string workStation, int createdUserId, string sourceBr)
        {          
            TLMDTO00059 GCDTO = new TLMDTO00059();
            bool isfaof = this.CodeChecker.isFAOFAccountNo(accountNo);
            if (isfaof == true)
            {
                //Show Invalid Current, Saving and Chart of Account(MV00197)
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00197;
                return null;
            }
            else
            {
                if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV00044;
                    return null;
                }
                else
                {
                    if (this.CodeChecker.IsFreezeAccount(accountNo))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV00057;
                        return null;
                    }
                    else
                    {
                        PFMDTO00028 cledgerDTO = this.CodeChecker.GetAccountInfoOfCledgerByAccountNo(accountNo);
                        if (cledgerDTO.AccountSign != null)
                        {
                            string acSign = cledgerDTO.AccountSign.Substring(0, 1);
                            switch (acSign)
                            {
                                case "S": if (isVIP == false)
                                    {
                                        CXDTO00006 reportparameters = new CXDTO00006();
                                        reportparameters.AccountNo = accountNo;
                                        reportparameters.StartDate = DateTime.Now;
                                        reportparameters.EndDate = DateTime.Now;
                                        reportparameters.BDateType = "T";
                                        reportparameters.SpecialCondition = "Substring(Status,2,1) = 'D' and sourceBr = '" + sourceBr + "'";
                                        reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForCheck;
                                        reportparameters.UserNo = workStation;
                                        reportparameters.CreatedUserId = createdUserId;
                                        //reportparameters.UserNo = CurrentUserEntity.WorkStationId.ToString();
                                        //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;

                                        PFMDTO00042 DataGenerateDTO = this.DataGenerateSerice.GetReportDataGenerateInSQL(reportparameters);
                                        if (DataGenerateDTO != null)
                                        {
                                            this.ServiceResult.ErrorOccurred = true;
                                            this.ServiceResult.MessageCode = CXMessage.MV00135; //Not Allow Saving debit transaction for more than one time in a week.
                                            return null;
                                        }
                                        //else
                                        //{
                                        //    PODTO.Currency = this.SelectCurrencyByAccNo(accountNo);
                                        //    PODTO.AcSign = acSign;
                                        //    PODTO.AccountNo = accountNo;
                                        //}

                                    }
                                    GCDTO.NAME = this.SelectCustomerNameByAccNo(accountNo,acSign);
                                    GCDTO.NAME = acSign;
                                    GCDTO.ACCTNO = accountNo;
                                    break;
                                case "C":
                                    {
                                        if (accountNo.Length != 6)
                                        {
                                            IList<PFMDTO00006> ChequeDTOList = this.ChequeDAO.SelectListByChequeBookNoByAccountNo(accountNo);
                                            if (ChequeDTOList.Count > 0)
                                            {
                                                //if (ChequeDTOList.Count == 3)
                                                //{
                                                //    GCDTO.ChequeThree = "3." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                                //    GCDTO.ChequeTwo = "2." + "[" + ChequeDTOList[ChequeDTOList.Count - 2].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 2].EndNo + "]";
                                                //    GCDTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 3].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 3].EndNo + "]";
                                                //}
                                                //else if (ChequeDTOList.Count == 2)
                                                //{
                                                //    GCDTO.ChequeThree = string.Empty;
                                                //    GCDTO.ChequeTwo = "2." + "[" + ChequeDTOList[ChequeDTOList.Count - 2].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 2].EndNo + "]";
                                                //    GCDTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                                //}
                                                //else
                                                //{
                                                //    GCDTO.ChequeThree = string.Empty;
                                                //    GCDTO.ChequeTwo = string.Empty;
                                                //    GCDTO.ChequeOne = "1." + "[" + ChequeDTOList[ChequeDTOList.Count - 1].StartNo + "-" + ChequeDTOList[ChequeDTOList.Count - 1].EndNo + "]";
                                                //}
                                            }
                                            else
                                            {
                                                //GCDTO.ChequeOne = string.Empty;
                                                //GCDTO.ChequeTwo = string.Empty;
                                                //GCDTO.ChequeThree = string.Empty;
                                            }
                                           // GCDTO.Currency = this.SelectCurrencyByAccNo(accountNo);
                                            GCDTO.NAME = this.SelectCustomerNameByAccNo(accountNo,acSign);
                                        }
                                        //SELECT * FROM dbo.COASETUP WHERE ACNONAME='PO'
                                        //Select Information using account no
                                        // select Top * from Bal where accountNo=''
                                    }
                                    break;
                            }

                        }

                    }
                }
            }
            return GCDTO;
        }

        #region "Private Methods"
        private string SelectCustomerNameByAccNo(string accountno, string acSign)
        {
            PFMDTO00017 customerDTO = new PFMDTO00017();
             customerDTO = this.CodeChecker.SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(accountno, acSign);
             return customerDTO.Name;
        }
        #endregion
    }
}
