using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00009:BaseService,ITCMSVE00009
    {
        #region DAO
        public IPFMDAO00028 CLedgerDAO { get; set; }
        public ITLMDAO00018 LoansDAO { get; set; }
        public IMNMDAO00008 OIDAO { get; set; }
        public IMNMDAO00011 CommitmentFeesDAO { get; set; }
        public IMNMDAO00005 TODSChargeDAO { get; set; }
        public IMNMDAO00027 SChargeDAO { get; set; }
        public bool isValidLno { get; set; }
       
        #endregion

        public TCMDTO00045 GetAccountNoInformation(string loanNo,string accountNo,string sourceBr, string formName, string month1)
        {
            TCMDTO00045 dto = new TCMDTO00045();
            try
            {

                PFMDTO00028 cledgerDTO = this.CLedgerDAO.GetLoansInformation(accountNo, sourceBr);
               // IList<MNMDTO00008> oIDTO = this.OIDAO.SelectByLoanNo(loanNo,sourceBr);
                if (cledgerDTO == null || cledgerDTO.AccountSign.Substring(0, 1) != "C")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00058";//Invalid Current Account No  
                    return null;
                }
              
                
                else
                {
                    if (cledgerDTO.OverdraftLimit <= 0)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV20083";//This is not Overdraft Account   
                        return null;
                    }
                    else
                    {
                        string[] aType = this.GetAType(formName);
                        IList<TLMDTO00018> loansList = new List<TLMDTO00018>();
                        loansList = this.LoansDAO.SelectInterestRate(accountNo, aType[0], aType[1]);
                        TLMDTO00018 loansDTO = loansList.Count > 0? loansList.First() : null ;
                        if (loansDTO == null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                           // this.ServiceResult.MessageCode = "MV00046";//Invalid AccountNo
                            ServiceResult.MessageCode = "MV90055";//Loan No is Valid   
                            return null;
                        }
                      
                        dto.OverdraftLimit = cledgerDTO.OverdraftLimit;
                        dto.Rate = Convert.ToDecimal(loansDTO.SAmount);
                        accountNo = cledgerDTO.AccountNo;
                        TCMDTO00045 data = this.GetData(loanNo,accountNo,formName, month1, sourceBr);
                        dto.LoansNo = data.LoansNo;
                        //dto.AccountNo = data.AccountNo;
                        dto.LastCalculateDate = data.LastCalculateDate;
                        dto.InterestOfLastDate = data.InterestOfLastDate;
                        dto.InterestMonth1 = data.InterestMonth1;
                        dto.InterestMonth2 = data.InterestMonth2;
                        dto.InterestMonth3 = data.InterestMonth3;


                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90042";
            }
            return dto;
        }

        public TLMDTO00018 isValidLoanNo(string loanNo, string sourceBr,string formName)
        {
            TLMDTO00018 loanDTO = new TLMDTO00018();
            
            try
            {
               // bool isValidLno;
                if (formName == "OverdraftInterest")
                {
                     
                    // LOMDTO00021 LiDTO = LIDAO.GetLiInfo(loanNo, sourceBr).First();

                    MNMDTO00008 oIDTO = new MNMDTO00008();
                    IList<MNMDTO00008> oIList = this.OIDAO.SelectByLoanNo(loanNo, sourceBr);
                    if (oIList.Count > 0)
                    {
                        oIDTO = oIList.First();
                    }
                    else
                    {
                        oIDTO = null;
                    }
                      isValidLno = oIDTO != null ? true : false;
                   
                }
                else if (formName == "CommitmentFees")
                {
                    MNMDTO00011 commitmentFeeDTO = new MNMDTO00011();
                    IList<MNMDTO00011> comfeeList = this.CommitmentFeesDAO.SelectByLoansNo(loanNo, sourceBr);
                    if (comfeeList.Count > 0)
                    {

                        commitmentFeeDTO = comfeeList.First();

                    }
                    else 
                    {
                        commitmentFeeDTO = null;
                       
                    }

                    isValidLno = commitmentFeeDTO != null ? true : false;
                
                }
               
                if (isValidLno)
                {

                    loanDTO = LoansDAO.GetLoansAccountInformation(loanNo, sourceBr);

                    if (loanDTO != null)
                    {
                        if (loanDTO.AType != "OVERDRAFT")
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90085";//Loan Account Type Only.                          
                        }
                        else if (loanDTO.CloseDate != null)
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            ServiceResult.MessageCode = "MV90086";//Loan Account has been Closed. 
                        }
                        //else
                        //{
                        //    loanDTO.FirstSAmount = oIDTO.LastInt;
                        //}
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        ServiceResult.MessageCode = "MV90055";//Loan No is Valid                     
                    }
                }


                else
                {
                    this.ServiceResult.ErrorOccurred = true;

                    ServiceResult.MessageCode = "MI90067";//Loans No. not found in Interest File.                   
                    // ServiceResult.MessageCode = "MV90100";  //Invalid Account No {0} for Branch {1}.                      
                }

            }


            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message);
            }
            return loanDTO;
        }

        public void Save(TCMDTO00045 dto, string formName)
        {
            try
            {
                if (formName == "OverdraftInterest")
                {
                    this.OIDAO.UpdateOIForInterestEdit(dto.LoansNo, dto.InterestOfLastDate, dto.Column_1, dto.Column_2, dto.Column_3, dto.InterestMonth1, dto.InterestMonth2, dto.InterestMonth3, dto.CreatedUserId);
                }
                else if (formName == "CommitmentFees")
                {
                    this.CommitmentFeesDAO.UpdateCommitmentFeesForInterestEdit(dto.LoansNo, dto.InterestOfLastDate, dto.Column_1, dto.Column_2, dto.Column_3, dto.InterestMonth1, dto.InterestMonth2, dto.InterestMonth3, dto.CreatedUserId);
                }
                else if (formName == "TODExtraCharges")
                {
                    this.TODSChargeDAO.UpdateTOD_SChargeForInterestEdit(dto.LoansNo, dto.InterestOfLastDate, dto.Column_1, dto.Column_2, dto.Column_3, dto.InterestMonth1, dto.InterestMonth2, dto.InterestMonth3, dto.CreatedUserId);
                }
                else if (formName == "TODServiceCharges")
                {
                    this.SChargeDAO.UpdateSChargeForInterestEdit(dto.LoansNo, dto.InterestOfLastDate, dto.Column_1, dto.Column_2, dto.Column_3, dto.InterestMonth1, dto.InterestMonth2, dto.InterestMonth3, dto.CreatedUserId);
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }

        }

        public string[] GetAType(string formName)
        {
            string[] type = { string.Empty, string.Empty };
            if (formName == "OverdraftInterest" || formName == "CommitmentFees")
            { 
                type[0] =  "Overdraft";
                type[1] = "Overdraft"; 
            }
            else if (formName == "TODExtraCharges" || formName == "TODServiceCharges")
            {
                type[0] = "TOD";
                type[1] = "TOD_Remit";
            }
            return type;
        }

        public TCMDTO00045 GetData(string loanNo,string accountNo, string formName, string month1, string sourceBr)
        {
            TCMDTO00045 dto = new TCMDTO00045();
            try
            {
              
                if (formName == "OverdraftInterest")
                {
                   // IList<MNMDTO00008> oIList = new List<MNMDTO00008>();
                    IList<MNMDTO00008> oIList = this.OIDAO.SelectByLoanNo(loanNo, sourceBr);
                  // IList< MNMDTO00008> oIList = this.OIDAO.SelectByAccountNo(accountNo, sourceBr);
                    MNMDTO00008 oiDTO = oIList.Count > 0 ? oIList.First() : null;  //OI Table
                    dto = this.GetMonthInterest(month1, oiDTO, null, null, null);
                   // dto = this.GetMonthInterest(month1, oIList, null, null, null);

                }
                else if (formName == "CommitmentFees")
                {
                    //IList<MNMDTO00011> commitmentFeesDTOList = this.CommitmentFeesDAO.SelectByAccountNo(accountNo); //COMMIT_FEES TaBle
                    IList<MNMDTO00011> commitmentFeesDTOList = this.CommitmentFeesDAO.SelectByLoansNo(loanNo, sourceBr);
                    if (commitmentFeesDTOList.Count > 0)
                    {
                        var query = from MNMDTO00011 commitmentFees in commitmentFeesDTOList
                                    orderby commitmentFees.CreatedDate descending
                                    select commitmentFees;
                        MNMDTO00011 commitmentFeesDTO = query.First();
                        dto = this.GetMonthInterest(month1, null, commitmentFeesDTO, null, null);
                    }
                }
                else if (formName == "TODExtraCharges")
                {
                   // IList<MNMDTO00005> todSChargeDTOList = this.TODSChargeDAO.SelectByAccountNo(accountNo);  //TOD_SCHARGE Table
                    IList<MNMDTO00005> todSChargeDTOList = this.TODSChargeDAO.SelectByLoanNo(loanNo, accountNo, sourceBr); 
                    if (todSChargeDTOList.Count > 0)
                    {
                        var query = from MNMDTO00005 todSCharge in todSChargeDTOList
                                    orderby todSCharge.CreatedDate descending
                                    select todSCharge;
                        MNMDTO00005 todSChargeDTO = query.First();
                        dto = this.GetMonthInterest(month1, null, null, todSChargeDTO, null);
                    }
                }
                else if (formName == "TODServiceCharges")
                {
                    IList<MNMDTO00027> sChargeList = this.SChargeDAO.SelectByLoansNo(loanNo, accountNo, sourceBr);  //Scharge Table
                    if (sChargeList.Count > 0)
                    {
                        var query = from MNMDTO00027 scharge in sChargeList
                                    orderby scharge.CreatedDate descending
                                    select scharge;
                        MNMDTO00027 sChargeDTO = query.First();
                        dto = this.GetMonthInterest(month1, null, null, null, sChargeDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90042";
                //throw new Exception(this.ServiceResult.MessageCode); 
            }

            return dto;
        }

        public TCMDTO00045 GetMonthInterest(string month1, MNMDTO00008 oiDTO, MNMDTO00011 commitmentFeesDTO,MNMDTO00005 todSChargeDTO,MNMDTO00027 sChargeDTO)
        {
            TCMDTO00045 record = new TCMDTO00045();
            record.LoansNo = (oiDTO != null) ? oiDTO.LNo : (commitmentFeesDTO != null) ? commitmentFeesDTO.LNo : (todSChargeDTO != null) ? todSChargeDTO.LNo : (sChargeDTO!=null)? sChargeDTO.LNo : string.Empty;
            //record.LastCalculateDate = (oiDTO != null) ? Convert.ToDateTime(oiDTO.LastDate) : (commitmentFeesDTO != null) ? Convert.ToDateTime(commitmentFeesDTO.LastDate) : (todSChargeDTO != null) ? Convert.ToDateTime(todSChargeDTO.LastDate): (sChargeDTO != null) ? Convert.ToDateTime(sChargeDTO.LastDate) : Convert.ToDateTime(null);
            record.LastCalculateDate = (oiDTO != null) ? oiDTO.LastDate.ToString() : (commitmentFeesDTO != null) ? commitmentFeesDTO.LastDate.ToString() : (todSChargeDTO != null) ? todSChargeDTO.LastDate.ToString() : (sChargeDTO != null) ? sChargeDTO.LastDate.ToString() : string.Empty;
            record.InterestOfLastDate = (oiDTO != null) ? Convert.ToDecimal(oiDTO.LastInt) : (commitmentFeesDTO != null) ? Convert.ToDecimal(commitmentFeesDTO.LastInt) : (todSChargeDTO != null) ? Convert.ToDecimal(todSChargeDTO.LastInt) : (sChargeDTO != null) ? Convert.ToDecimal(sChargeDTO.LastInt) : 0;
            
            
            if (month1 == "M1" || month1 == "S1")
            {
                record.InterestMonth1 = (oiDTO != null) ? oiDTO.M1 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M1 : (todSChargeDTO!=null) ? Convert.ToInt32(todSChargeDTO.S1) : (sChargeDTO!=null)? sChargeDTO.M1 :0;
                record.InterestMonth2 = (oiDTO != null) ? oiDTO.M2 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M2 : (todSChargeDTO!=null) ? Convert.ToInt32(todSChargeDTO.S2) : (sChargeDTO!=null)? sChargeDTO.M2 :0;
                record.InterestMonth3 = (oiDTO != null) ? oiDTO.M3 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M3 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S3) : (sChargeDTO != null) ? sChargeDTO.M3 : 0;
                //record.Column_1 = "M1";
                //record.Column_2 = "M2";
                //record.Column_3 = "M3";
               
            }
            else if (month1 == "M4" || month1 == "S4")
            {
                record.InterestMonth1 = (oiDTO != null) ? oiDTO.M4 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M4 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S4) : (sChargeDTO != null) ? sChargeDTO.M4 : 0;
                record.InterestMonth2 = (oiDTO != null) ? oiDTO.M5 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M5 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S5) : (sChargeDTO != null) ? sChargeDTO.M5 : 0;
                record.InterestMonth3 = (oiDTO != null) ? oiDTO.M6 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M6 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S6) : (sChargeDTO != null) ? sChargeDTO.M6 : 0;
                //record.Column_1 = "M4";
                //record.Column_2 = "M5";
                //record.Column_3 = "M6";
            }
            else if (month1 == "M7" || month1 == "S7")
            {
                record.InterestMonth1 = (oiDTO != null) ? oiDTO.M7 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M7 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S7) : (sChargeDTO != null) ? sChargeDTO.M7 : 0;
                record.InterestMonth2 = (oiDTO != null) ? oiDTO.M8 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M8 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S8) : (sChargeDTO != null) ? sChargeDTO.M8 : 0;
                record.InterestMonth3 = (oiDTO != null) ? oiDTO.M9 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M9 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S9) : (sChargeDTO != null) ? sChargeDTO.M9 : 0;
                //record.Column_1 = "M7";
                //record.Column_2 = "M8";
                //record.Column_3 = "M9";
            }
            else if (month1 == "M10" || month1 == "S10")
            {
                record.InterestMonth1 = (oiDTO != null) ? oiDTO.M10 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M10 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S10) : (sChargeDTO != null) ? sChargeDTO.M10 : 0;
                record.InterestMonth2 = (oiDTO != null) ? oiDTO.M11 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M11 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S11) : (sChargeDTO != null) ? sChargeDTO.M11 : 0;
                record.InterestMonth3 = (oiDTO != null) ? oiDTO.M12 : (commitmentFeesDTO != null) ? commitmentFeesDTO.M12 : (todSChargeDTO != null) ? Convert.ToInt32(todSChargeDTO.S12) : (sChargeDTO != null) ? sChargeDTO.M12 : 0;
                //record.Column_1 = "M10";
                //record.Column_2 = "M11";
                //record.Column_3 = "M12";
            }
            return record;
        }

      
    }
}
