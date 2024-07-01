using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00066 : BaseService, ITCMSVE00066
    {
        public ITCMDAO00013 VW_LedgerDAO { get; set; }
        public ICXDAO00009 CXDAO { get; set; }
        public ICXSVE00010 DataGenerateService { get; set; }
        public IList<PFMDTO00042> LedgerList { get; set; }
        public IList<TCMDTO00013> DataList { get; set; }

        #region insert ReportTlf

        private PFMDTO00042 GetLedgerBalanceByTransactionFromSQL(PFMDTO00042 rawData)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            CXDTO00006 reportparameters = new CXDTO00006();

            reportparameters.StartDate = rawData.StartDate;
            reportparameters.EndDate = rawData.EndDate;
            reportparameters.BDateType = "T";
            reportparameters.SpecialCondition = "sourceBr = '" + rawData.SourceBranch + "'";
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.UserNo = rawData.WorkStationId.ToString();
            reportparameters.CreatedUserId = rawData.CreatedUserId;

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            
            if (DataGenerateDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI00039"; //No Data For Report
            }

            return DataGenerateDTO;         
        }
        #endregion 

        public IList<TCMDTO00013> SelectLedgerBalanceByTransaction(PFMDTO00042 rawdata)
        {
            // firstly insert to report_tlf to select data for report
            this.GetLedgerBalanceByTransactionFromSQL(rawdata); 
            
            switch (rawdata.Description)
            {
                   
                case "All": 
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoAbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if(LedgerList.Count > 0 )
                         DataList = this.CXDAO.SelectAcctNoAbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "BL":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoBbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList = this.CXDAO.SelectAcctNoBbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "HP":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoHbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList = this.CXDAO.SelectAcctNoHbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "PL":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoPbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         //DataList = this.CXDAO.SelectAcctNoPbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                         DataList = this.CXDAO.GetAccountLedgerbyAcSignWorkstation("P", rawdata.WorkStationId.ToString(), rawdata.SourceCur);   
                     break;

                case "DL":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoDbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList = this.CXDAO.SelectAcctNoDbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "Current":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoCbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList = this.CXDAO.SelectAcctNoCbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "Saving":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoSbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList= this.CXDAO.SelectAcctNoSbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;

                case "Fix":
                     LedgerList = this.VW_LedgerDAO.SelectAcctNoFbyWorkstation(rawdata.WorkStationId, rawdata.SourceCur);
                     if (LedgerList.Count > 0)
                         DataList= this.CXDAO.SelectAcctNoFbyWorkstation(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);
                     break;
               
            }

            return DataList;

           
        }

        public IList<TCMDTO00013> SelectAcctNoByOverDrawn(PFMDTO00042 rawdata)
        {
            // firstly insert to report_tlf to select data for report
            this.GetLedgerBalanceByTransactionFromSQL(rawdata);

            IList<TCMDTO00013> TCMDTOList = this.CXDAO.SelectAcctNobyOVERDRAWN(rawdata.WorkStationId.ToString(), rawdata.SourceCur, rawdata.Status);

            return TCMDTOList;
        }

        #region oldCode 
        //public IList<PFMDTO00042> SelectAcctNoAbyWorkstation(int workstation, string currency)
        //{
        //    IList<PFMDTO00042> DTOList = this.VW_LedgerDAO.SelectAcctNoAbyWorkstation(workstation, currency);
        //    return DTOList;          
        //}

        //public IList<PFMDTO00042> SelectAcctNoCbyWorkstation(int workstation, string currency)
        //{
        //    IList<PFMDTO00042> DTOList = this.VW_LedgerDAO.SelectAcctNoCbyWorkstation(workstation, currency);
        //    return DTOList;
        //}

        //public IList<PFMDTO00042> SelectAcctNoSbyWorkstation(int workstation, string currency)
        //{
        //    IList<PFMDTO00042> DTOList = this.VW_LedgerDAO.SelectAcctNoSbyWorkstation(workstation, currency);
        //    return DTOList;
        //}

        //public IList<PFMDTO00042> SelectAcctNoFbyWorkstation(int workstation, string currency)
        //{
        //    IList<PFMDTO00042> DTOList = this.VW_LedgerDAO.SelectAcctNoFbyWorkstation(workstation, currency);
        //    return DTOList;
        //}
      

        //ICXDAO00009..............

        //#region " @ _ @ Select By vw_Ledger @ _ @ "

       

        //public IList<TCMDTO00013> SelectAcctNoByAll(int workstation, string currency, string sorting)
        //{
        //    IList<TCMDTO00013> TCMDTOList = this.CXDAO.SelectAcctNoAbyWorkstation(Convert.ToString(workstation), currency, sorting);

        //    return TCMDTOList;
        //}

        //public IList<TCMDTO00013> SelectAcctNoByCurrent(int workstation, string currency, string sorting)
        //{
        //    IList<TCMDTO00013> TCMDTOList = this.CXDAO.SelectAcctNoCbyWorkstation(Convert.ToString(workstation), currency, sorting);

        //    return TCMDTOList;
        //}

        //public IList<TCMDTO00013> SelectAcctNoBySaving(int workstation, string currency, string sorting)
        //{
        //    IList<TCMDTO00013> TCMDTOList = this.CXDAO.SelectAcctNoSbyWorkstation(Convert.ToString(workstation), currency, sorting);

        //    return TCMDTOList;
        //}

        //public IList<TCMDTO00013> SelectAcctNoByFixed(int workstation, string currency, string sorting)
        //{
        //    IList<TCMDTO00013> TCMDTOList = this.CXDAO.SelectAcctNoFbyWorkstation(Convert.ToString(workstation), currency, sorting);

        //    return TCMDTOList;
        //}
        //#endregion

        #endregion
    }
}
