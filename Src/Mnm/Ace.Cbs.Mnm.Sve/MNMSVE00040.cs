using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00040 : BaseService, IMNMSVE00040
    {
        public ICXSVE00010 DataGenerateService { get; set; }
        public ICXDAO00010 procedureDAO { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }
        PFMDTO00042 ReportTlfData { get; set; }
        public IPFMDAO00042 ReportTLFDAO { get; set; }
   
        


        public IList<PFMDTO00042> GetAutoLinkListingReport(PFMDTO00042 DataDTO, int workStationId, int createdUserId)
       
        {
           ReportTlfData = this.GetDataForReportTLF(DataDTO, workStationId, createdUserId);   //Insert into Report_Tlf
           if(ReportTlfData.Row_Count > 0)
            PrintDataList = ReportTLFDAO.SelectDebitListing(workStationId.ToString(), DataDTO.AccountSign, DataDTO.SourceBranch, DataDTO.TransactionCode, DataDTO.DATE_TIME.Value, DataDTO.SourceCur);  //Select from Report_Tlf
           return PrintDataList;           
        }

        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO, int workStationId, int createdUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();

            reportparameters.StartDate = Convert.ToDateTime(DataDTO.DATE_TIME);
            reportparameters.EndDate = Convert.ToDateTime(DataDTO.DATE_TIME);
            reportparameters.CurrencyCode = DataDTO.SourceCur;
            reportparameters.BDateType = "S";
            reportparameters.ACSign = DataDTO.AccountSign;
          
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;


            reportparameters.WorkStationId = workStationId;
            reportparameters.UserNo = workStationId.ToString();
            reportparameters.TransactionCode = DataDTO.TransactionCode;

            reportparameters.SpecialCondition = "SourceBr = " +  DataDTO.SourceBranch ;

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }      
    }
}
