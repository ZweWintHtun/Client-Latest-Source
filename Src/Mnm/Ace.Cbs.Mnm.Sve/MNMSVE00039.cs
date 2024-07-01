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

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00039 : BaseService, IMNMSVE00039
    {
        public ICXSVE00010 DataGenerateService { get; set; }
        public ICXDAO00010 procedureDAO { get; set; }
        IList<PFMDTO00029> PrintDataList { get; set; }
        PFMDTO00042 ReportTlfData { get; set; }

        public IList<PFMDTO00029> GetAutoLinkListing(PFMDTO00042 DataDTO,int workStationId,int createdUserId)
        {
            ReportTlfData = this.GetDataForReportTLF(DataDTO,workStationId,createdUserId);
            
            //PrintDataList = procedureDAO.SelectAutoLinkListing(CurrentUserEntity.WorkStationId, DataDTO.IsWithReversal ==true? 1 : 0 , DataDTO.CurrencyType, CurrentUserEntity.BranchCode);
            PrintDataList = procedureDAO.SelectAutoLinkListing(workStationId, DataDTO.IsWithReversal == true ? 1 : 0, DataDTO.CurrencyType, DataDTO.SourceBranch);

            return PrintDataList;
        }

        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO,int workStationId,int createdUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();            
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.StartDate;            
            reportparameters.CurrencyCode = DataDTO.CurrencyType;
            reportparameters.BDateType = DataDTO.TransactionStatus;            
            //reportparameters.CreatedUserId = CurrentUserEntity.CurrentUserID;
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            //reportparameters.WorkStationId = CurrentUserEntity.WorkStationId;
            //reportparameters.UserNo = CurrentUserEntity.WorkStationId.ToString();
            reportparameters.WorkStationId = workStationId;
            reportparameters.UserNo = workStationId.ToString();
            reportparameters.TransactionCode = "ATL%";
            reportparameters.SpecialCondition = "sourceBr = '" + DataDTO.SourceBranch + "'";      
            
            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }      
           
    }
}
