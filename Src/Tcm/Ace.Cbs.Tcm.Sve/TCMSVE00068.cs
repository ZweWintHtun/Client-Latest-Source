//----------------------------------------------------------------------
// <copyright file="system cut off" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <CreatedDate>2014/07/24</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Admin.Contracts.Dao;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;


namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00068 : BaseService, ITCMSVE00068
    {

        public IPFMDAO00056 SysDAO { get; set; }
        public IFormatDefinitionDAO FormatDefintionDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public ISAMDAO00003 HolidayDAO { get; set; }

        public DateTime NextSettlementDate { get; set; }
        public DateTime CurrentSettlementDate { get; set; }
        public int UserId { get; set; }
        public string BranchCode { get; set; }


        public IList<SAMDTO00003> SelectAllByDate()
        {
            return HolidayDAO.SelectByDateAll();
        }


        [Transaction(TransactionPropagation.Required)]
        public void CutOff(string branchCode, DateTime NextSettlementDate, DateTime currentSettlementDate, int userId, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                this.BranchCode = branchCode;
                this.NextSettlementDate = NextSettlementDate;
                this.CurrentSettlementDate = currentSettlementDate;
                this.UserId = userId;

                this.CutOff_Process();


                // Server Client Data Save,Update and Delete********                
                PFMDTO00056 LastSettlementDateDTO = SysDAO.SelectSys001Info(BranchCode, "LAST_SETTLEMENT_DATE");
                PFMDTO00056 NextSettlementDTO = SysDAO.SelectSys001Info(BranchCode, "NEXT_SETTLEMENT_DATE");

                //For LastSettlementDate
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, userId, LastSettlementDateDTO.Id.ToString()); //Added by ASDA               
                Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "SysDate", currentSettlementDate } };
                Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "BranchCode", branchCode }, { "Name", "LAST_SETTLEMENT_DATE" }, { "Active", true } };
               // CXServiceWrapper.Instance.Invoke<IServerClientDataUpdateService, bool>(x => x.Update("PFMORM00056", updateColumnsandValues, whereColumnsandValues));
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValues, whereColumnsandValues));

                //For NextSettlementDate
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, userId, NextSettlementDTO.Id.ToString()); //Added by ASDA
                Dictionary<string, object> updateColumnsandValuesForNextSettlement = new Dictionary<string, object> { { "SysDate", NextSettlementDate } };
                Dictionary<string, object> whereColumnsandValuesForNextSettlement = new Dictionary<string, object> { { "BranchCode", branchCode }, { "Name", "NEXT_SETTLEMENT_DATE" }, { "Active", true } };
                //CXServiceWrapper.Instance.Invoke<IServerClientDataUpdateService, bool>(x => x.Update("PFMORM00056", whereColumnsandValuesForNextSettlement, whereColumnsandValuesForNextSettlement));
                CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("PFMORM00056", updateColumnsandValuesForNextSettlement, whereColumnsandValuesForNextSettlement));
                
                //end********

                this.ServiceResult.ErrorOccurred = false;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME90043;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }



        //[Transaction(TransactionPropagation.Required)]
        //public void CutOff(string branchCode, DateTime NextSettlementDate, DateTime currentSettlementDate, int userId)
        //{
        //    try
        //    {
        //        this.BranchCode = branchCode;
        //        this.NextSettlementDate = NextSettlementDate;
        //        this.CurrentSettlementDate = currentSettlementDate;
        //        this.UserId = userId;

        //        this.CutOff_Process();
                

        //        this.ServiceResult.ErrorOccurred = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = CXMessage.ME90043;
        //        throw new Exception(this.ServiceResult.MessageCode);
        //    }


        //}

        [Transaction()]
        private void CutOff_Process()
        {
            this.CledgerDAO.UpdateDOBal(this.BranchCode, DateTime.Now, this.UserId);
            this.SysDAO.UpdateSysDateForCutOff(this.BranchCode, this.NextSettlementDate, this.CurrentSettlementDate, this.UserId);
            //this.FormatDefintionDAO.FormatDefinitionMaxValueUpdatebyDay(this.BranchCode, this.UserId, DateTime.Now);
        }

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            PFMORM00056 Sys001ORM = new PFMORM00056();

            //Require Data
            clientDataVersionDTO.ORMObjectName = Sys001ORM;
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
            // CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }
        #endregion

  
    }
}
