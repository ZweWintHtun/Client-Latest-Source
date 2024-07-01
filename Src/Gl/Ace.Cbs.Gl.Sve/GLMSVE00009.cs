using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00009 : BaseService, IGLMSVE00009
    {
        public ICXDAO00009 CXDao { get; set; }
        public IPFMDAO00057 NewSetupDAO { get; set; }
        public IGLMDAO00009 GLMDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }  //ASDA

        public GLMSVE00009()
        {

        }

        public IList<ChargeOfAccountDTO> ChargeOfAccountSelectByPCEAccount(string sourceBr)
        {
            IList<ChargeOfAccountDTO> COADTOList = this.GLMDAO.ChargeOfAccountSelectByPCEAccount(sourceBr);
            return COADTOList;
        }

        #region OldCode
        //public MNMDTO00010 VW_CCOA_SumMonthByACode(string aCode, string currency, string budMonth)
        //{            
        //    MNMDTO00010 CCOADto = this.CXDao.VW_CCOA_SumMonthByACode(aCode, currency, budMonth);
        //    decimal openingBalance = CCOADto.AMOUNT;
        //    CCOADto.AMOUNT = openingBalance;

        //    return CCOADto;
        //}

        public MNMDTO00037 NewSetup_SelectSDateEDate(string year)
        {
            MNMDTO00037 DTO = new MNMDTO00037();

            string getStartDate = CXCOM00007.Instance.GetValueByVariable("BUDSDATE");
            string date = getStartDate.Substring(0, 2);
            string month = getStartDate.Substring(3, 2);
            getStartDate = month+ "/" + date + "/" + year;

            string getEndDate = CXCOM00007.Instance.GetValueByVariable("BUDEDATE");
            date = getEndDate.Substring(0, 2);
            month = getEndDate.Substring(3, 2);
            getEndDate = month + "/" + date + "/" + year;

            DTO.getStartDate = Convert.ToDateTime(getStartDate);
            DTO.getEndaDate = Convert.ToDateTime(getEndDate);

            return DTO;
        }

        //public IList<MNMDTO00054> VW_LedgerListingByHomeCurrencyWithTransactionDate(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation)
        //{
        //    IList<MNMDTO00054> LedgerListingDTOList = this.GLMDAO.VW_LedgerListingByHomeCurrency(aCode, startDate, endDate, sourcebr, workStation);

        //    return LedgerListingDTOList;
        //}

        //public IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate, string sourcebr, int workStation)
        //{
        //    IList<MNMDTO00054> LedgerListingDTOList = this.GLMDAO.VW_LedgerListingBySourceCurrency(aCode, startDate, endDate, sourcebr, workStation);

        //    return LedgerListingDTOList;
        //}
        #endregion

        //modify by ASDA
        public void GetReportData(string aCode, DateTime startDate, DateTime endDate,bool isTransactionDate, int workStationId, int currentUserID)
        {
            PFMDTO00042 ReportTlfData = this.GetDataForReportTLF(aCode,startDate,endDate,isTransactionDate, workStationId, currentUserID);
        }

        public PFMDTO00042 GetDataForReportTLF(string aCode, DateTime startDate, DateTime endDate, bool isTransactionDate, int workStationId, int currentUserID)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();            

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.ACode = aCode;
            reportparameters.StartDate = startDate;               
            reportparameters.EndDate = endDate; 
            if(isTransactionDate)
                reportparameters.BDateType = "T";
            else
                reportparameters.BDateType = "S";

            reportparameters.CreatedUserId = currentUserID;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.WorkStationId = workStationId;
            reportparameters.UserNo =Convert.ToString(CurrentUserEntity.WorkStationId); 

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public MNMDTO00010 VW_CCOA_SumMonthByACode(string strOpeningField, string aCode, string currency, string budYear)
        {
            MNMDTO00010 CCOADto = this.CXDao.VW_CCOA_SumMonthByACode(strOpeningField, aCode, currency, budYear);
            decimal openingBalance = CCOADto.AMOUNT;
            CCOADto.AMOUNT = openingBalance;

            return CCOADto;
        }

        public IList<MNMDTO00054> VW_LedgerListingByHomeCurrency(string aCode, DateTime startDate, DateTime endDate,bool isTransactionDate, string sourcebr, int workStation)
        {
            IList<MNMDTO00054> LedgerListingDTOList = this.GLMDAO.VW_LedgerListingByHomeCurrency(aCode, startDate, endDate,isTransactionDate, sourcebr, workStation);

            return LedgerListingDTOList;
        }       

        public IList<MNMDTO00054> VW_LedgerListingBySourceCurrency(string aCode, DateTime startDate, DateTime endDate,string currency, bool isTransactionDate, string sourcebr, int workStation)
        {
            IList<MNMDTO00054> LedgerListingDTOList = this.GLMDAO.VW_LedgerListingBySourceCurrency(aCode, startDate, endDate,currency,isTransactionDate, sourcebr, workStation);

            return LedgerListingDTOList;
        }    
    }
}
