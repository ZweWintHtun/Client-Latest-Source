using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00066 : BaseService ,IMNMSVE00066
    {
        ICXSVE00010 DataGenerateService { get; set; }
        public ICXDAO00010 procedureDAO { get; set; }
        public IPFMDAO00032 FReceiptDAO { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }
        IList<PFMDTO00032> FReceiptList { get; set; }

        public IList<PFMDTO00042> GetReportData(PFMDTO00042 dataDTO, string sourceBr, int workstationId, int createdUserId)
        {
            PFMDTO00042 ReportData = GetDataForReportTLF(dataDTO, sourceBr, workstationId, createdUserId);
            return PrintDataList = procedureDAO.SelectRenewalVoucherListing(workstationId, dataDTO.StartDate, dataDTO.CurrencyType, sourceBr);            
        }

        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 dataDTO, string sourceBr, int workstationId, int createdUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.StartDate = dataDTO.StartDate;
            reportparameters.EndDate = dataDTO.StartDate;            
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.WorkStationId = workstationId;
            reportparameters.UserNo = workstationId.ToString();
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.BDateType = "T";
            reportparameters.SpecialCondition = "sourceBr = '" + sourceBr + "'";

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public IList<PFMDTO00032> GetCheckListForComingAccrue(string currency, string sourceBr)
        {
            return FReceiptList = FReceiptDAO.CheckForComingAccrue(currency, sourceBr);            
        }

        public IList<PFMDTO00032> GetCheckListForComingInterest(string currency, string sourceBr)
        {
            return FReceiptList = FReceiptDAO.CheckForComingInterest(currency, sourceBr);            
        }

        public PFMDTO00042 GetMatureDate(PFMDTO00032 CheckDTO, int createdUserId)
        {
            PFMDTO00042 MatureDate = DataGenerateService.GetMatureDate(Convert.ToDateTime(CheckDTO.LastInterestDate), CheckDTO.Duration, Convert.ToDateTime(CheckDTO.RDate), createdUserId);
            return MatureDate;
        }
    }
}
