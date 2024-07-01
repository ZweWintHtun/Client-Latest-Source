using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00012 : BaseService, ILOMSVE00012
    {
        public ITLMDAO00018 LoansDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00057 NewSetupDAO { get; set; }
        public IPFMDAO00009 RateFileDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ITCMDAO00002 ServiceChargesDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public ILOMDAO00011 LMT99DAO { get; set; }
        public bool isOD { get; set; }
        public TLMDTO00018 odLimitChangeEntity { get; set; }
        DateTime SettlementDate;
        decimal Rate;
       // decimal douAmt;
        decimal servicesRate;

        public TLMDTO00018 isValidLoanNo(string lno, string sourceBr)
        {            
            TLMDTO00018 LoanDTO = LoansDAO.GetLoansAccountInformation(lno, sourceBr);
           //LoanDataByLoanNo = LoanDTO;
            if (LoanDTO == null )
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90055; //Invalid Loan No.
                return null;
            }            
            else if (LoanDTO.AType == "LOANS")    
            {
                //AType must be "OVERDRAFT" and "TOD"
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90056; //Overdraft Only 
                return null;
            }
            else
            {
                //'If Loans No. is closed in Loans File Display Message Box
                if (!string.IsNullOrEmpty(LoanDTO.CloseDate.ToString()))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90056;  //Loans No. Already Closed!
                    return null;
                }
                else if (LoanDTO.AType == "OVERDRAFTS" && !string.IsNullOrEmpty(LoanDTO.Charges_Status) && LoanDTO.Charges_Status == "Y")
                {
                    if (LoanDTO.SDate.Value.ToString("yyyy/MM/dd") == DateTime.Now.ToString("yyyy/MM/dd"))
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV90056;  //Can't change OD limit, service charges already has been taken from this account.
                        return null;
                    }
                    if (Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")) > Convert.ToDateTime(LoanDTO.ExpireDate.Value.ToString("yyyy/MM/dd")))
                    {                      
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = CXMessage.MV90056;  //This Loans no. is expired.
                        return null;
                    }

                }
                else
                {  
                    IList<PFMDTO00072> GetCustomerInfo = CodeChecker.GetCurrentAccountInfoByAccountNumber(LoanDTO.AccountNo);
                    if (GetCustomerInfo != null)
                    {
                        if (GetCustomerInfo[0].CurrentBalance > 0)
                            LoanDTO.OverdraftAmount = 0;
                        else
                            LoanDTO.OverdraftAmount = Math.Abs(GetCustomerInfo[0].CurrentBalance);

                        //LoanDTO.TotalODLimit = this.view.PresentODLimit;
                        LoanDTO.Name = GetCustomerInfo[0].CustomerName;
                        LoanDTO.Currency = GetCustomerInfo[0].CurrencyCode;
                        LoanDTO.ACSign = GetCustomerInfo[0].AccountSignature;
                        
                    }
                }
            }
            return LoanDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveODLimitChangeData(TLMDTO00018 odLimitChangeEntity)
        {
            try
            {
                Rate = CXCOM00010.Instance.GetExchangeRate(odLimitChangeEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                if (Rate == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return;
                }
                SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), odLimitChangeEntity.SourceBranchCode, true });
                if (SettlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return;
                }
                //if (odLimitChangeEntity.NewTotalODLimit > odLimitChangeEntity.TotalODLimit)  //IF New Limit >Old Limit then
                //{
                //    if (!this.ODOnly(odLimitChangeEntity))
                //    {
                //        this.ServiceResult.ErrorOccurred = true;
                //        return;
                //    }
                //}
                    //else
                    //{
                        NewSetupDAO.UpdateValueOfRunTrigger("Enable", odLimitChangeEntity.UpdatedUserId.Value);

                        //*** Update on Cledger ***
                        decimal oVDLimit = odLimitChangeEntity.TotalODLimit + (odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit);
                        CledgerDAO.UpdateOVDLimitInCledger(oVDLimit, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

                        //'*** Update on Loans ***
                        LoansDAO.UpdateSamtAndFirstSamt(odLimitChangeEntity.NewODLimit, odLimitChangeEntity.Lno, odLimitChangeEntity.SourceBranchCode, odLimitChangeEntity.AccountNo, odLimitChangeEntity.UpdatedUserId.Value);

                        //'*** Insert into LMT99#00 ***
                        LMT99DAO.Save(this.ConvertToLimitFileORM(odLimitChangeEntity));                     

                       //ODOnly(odLimitChangeEntity);
                         if (!this.ODOnly(odLimitChangeEntity))
                         {
                             this.ServiceResult.ErrorOccurred = true;
                             return;
                         }
                    //}
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public bool ODOnly(TLMDTO00018 odLimitChangeEntity)
        {
            
           //**** update Chargesstatus of Loan file when this a/c is OD
            LoansDAO.UpdateChargesstatus("Y", odLimitChangeEntity.Lno, Convert.ToInt32(odLimitChangeEntity.UpdatedUserId));

            string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, odLimitChangeEntity.UpdatedUserId.Value, odLimitChangeEntity.SourceBranchCode, new object[] { SettlementDate.Day.ToString().PadLeft(2, '0'), SettlementDate.Month.ToString().PadLeft(2, '0'), SettlementDate.Year.ToString().Substring(2) });  //Transaction Voucher
          
            //int restofdays = 0;
            //bool autolink = true;
            string commissionCode;
            //int Dayinyear=0;

            //if (odLimitChangeEntity != null)
            //{
            //    restofdays = (Convert.ToDateTime(odLimitChangeEntity.ExpireDate)-DateTime.Now).Days + 2;
            //}

           // PFMDTO00009 SCharges = RateFileDAO.SelectByRateCode("SchargeNew");            
           // int Dayinyear = 337 + (Convert.ToInt32(Convert.ToDateTime("03/01/" + (DateTime.Now.Year)).Day-1));    //number of days in 1 year           
            
            //if(DateTime.IsLeapYear(DateTime.Now.Year))
            //    Dayinyear=366;
            //else
            //    Dayinyear=365;

           // douAmt = (((odLimitChangeEntity.NewODLimit - odLimitChangeEntity.PresentODLimit) * (SCharges.Rate / 100)) / Dayinyear) * Convert.ToDecimal(restofdays);  //' 1% amount
            decimal rate = CXCOM00010.Instance.GetExchangeRate(odLimitChangeEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
            PFMDTO00075 rateDto = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { odLimitChangeEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true, odLimitChangeEntity.Currency, true });
             
            servicesRate = odLimitChangeEntity.NewODLimit * Convert.ToDecimal(odLimitChangeEntity.serviceChargesRate.Value) / 100;
            int exRate = Convert.ToInt32(rateDto.Rate);
            int sRate = Convert.ToInt32(servicesRate);
            this.ServiceResult.MessageCode = CXMessage.MV90063 + "." + servicesRate.ToString();  //Service Charges {0} will be deducted from Account no.: {1}            

            commissionCode = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NewServiceCharge), odLimitChangeEntity.Currency, odLimitChangeEntity.SourceBranchCode, true });   // a/c code for Commssion

            //update Chargesstatus of Loan file when this a/c is OD
          //  LoansDAO.UpdateChargesstatus("Y", odLimitChangeEntity.Lno, Convert.ToInt32(odLimitChangeEntity.UpdatedUserId));

         

            //if (douAmt < odLimitChangeEntity.OverdraftAmount) //ouAmt Begin
            //{
            //    autolink = false ;   // 1 - Autolink(true) , 0 - Normal(false)
            //}

            string[] vouType = new string[] {"D","C"};
            string[] accountNo = new string[] { odLimitChangeEntity.AccountNo, commissionCode };
            string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

            for(int i=0; i < vouType.Count() ; i++)
            {
                string account =accountNo[i].ToString();
                string voucherType = vouType[i].ToString();                
                ///*** Insert into tlf ***   (2 transaction will save. one with customerAcc and one with acode)
                if (!CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.Sp_SERVICECHARGES_VOU(voucherNumber, account, odLimitChangeEntity.Lno, "1 Year Service Charges", servicesRate, 0, odLimitChangeEntity.UserNo, voucherType,
                false, odLimitChangeEntity.Currency, sRate, odLimitChangeEntity.SourceBranchCode, SettlementDate, channel, true, string.Empty)))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00018;   //Transaction is not Success!
                    //throw new Exception(this.ServiceResult.MessageCode);                   
                }
            }
            /*** Insert into Services_Charges ***/
            this.ServiceChargesDAO.Save(this.ConvertToService_ChargesORM(odLimitChangeEntity));
            return true;
        }

        public TCMORM00002 ConvertToService_ChargesORM(TLMDTO00018 odLimitChangeEntity)
        {
            TCMORM00002 ServiceChargesORM = new TCMORM00002();
            
            ServiceChargesORM.LNo = odLimitChangeEntity.Lno;
            ServiceChargesORM.AcctNo = odLimitChangeEntity.AccountNo;
            ServiceChargesORM.Desp = "OD Limit Change";
            ServiceChargesORM.GetColo = string.Empty;
            ServiceChargesORM.VouDate = DateTime.Now;
            ServiceChargesORM.Amount = servicesRate;
            ServiceChargesORM.SourceBr = odLimitChangeEntity.SourceBranchCode;
            ServiceChargesORM.Cur = odLimitChangeEntity.Currency;
            ServiceChargesORM.Active = true;
            ServiceChargesORM.CreatedDate = DateTime.Now;
            ServiceChargesORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
           // ServiceChargesORM.FirstSAmount = odLimitChangeEntity.SAmount;
            return ServiceChargesORM;
        }

        public LOMORM00011 ConvertToLimitFileORM(TLMDTO00018 odLimitChangeEntity)
        {
            LOMORM00011 LimitFileORM = new LOMORM00011();
            LimitFileORM.AcctNo = odLimitChangeEntity.AccountNo;
            LimitFileORM.CloseDate = odLimitChangeEntity.CloseDate ;
            LimitFileORM.Cur = odLimitChangeEntity.Currency ;
            LimitFileORM.Date_Time = DateTime.Now ;
            LimitFileORM.LoanNo = odLimitChangeEntity.Lno ;
            LimitFileORM.OLDLimit = odLimitChangeEntity.TotalODLimit ;
            LimitFileORM.OVDLimit = odLimitChangeEntity.NewODLimit ;
            LimitFileORM.SourceBr = odLimitChangeEntity.SourceBranchCode ;
            LimitFileORM.UserNo = odLimitChangeEntity.UserNo ;
            LimitFileORM.Active = true ;
            LimitFileORM.CreatedDate = DateTime.Now;
            LimitFileORM.CreatedUserId = odLimitChangeEntity.CreatedUserId;
            return LimitFileORM;
        }
    }
}
