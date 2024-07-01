//----------------------------------------------------------------------
// <copyright file="SAMSVE00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// Zone Service
    /// </summary>
    public class SAMSVE00017 : BaseService, ISAMSVE00017
    {
        #region Properties

        private ITLMDAO00031 zoneDAO;
        public ITLMDAO00031 ZoneDAO
        {
            get { return this.zoneDAO; }
            set { this.zoneDAO = value; }
        }

        private ISAMDAO00004 branchDAOForAll;
        public ISAMDAO00004 BranchDAOForAll
        {
            get { return this.branchDAOForAll; }
            set { this.branchDAOForAll = value; }
        }

        private TLMORM00031 ZoneInfo;

        #endregion

        #region Helper Method

        private TLMORM00031 GetZone(TLMDTO00031 zoneDTO, bool isDelete)
        {
            ZoneInfo = new TLMORM00031();

            ZoneInfo.Id = zoneDTO.Id;
            ZoneInfo.ZoneType = zoneDTO.ZoneType;
            ZoneInfo.ZoneDescription = zoneDTO.ZoneDescription;
            ZoneInfo.BranchCode = zoneDTO.BranchCode;
            ZoneInfo.AccountCode = zoneDTO.AccountCode;
            ZoneInfo.UniqueId = zoneDTO.UniqueId;
            ZoneInfo.SourceBranchCode = zoneDTO.SourceBranchCode;
            ZoneInfo.TS = zoneDTO.TS;
            ZoneInfo.CreatedUserId = zoneDTO.CreatedUserId;
            ZoneInfo.CreatedDate = DateTime.Now;
            ZoneInfo.UpdatedUserId = zoneDTO.UpdatedUserId;
            ZoneInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                ZoneInfo.Active = false;
            else
                ZoneInfo.Active = true;
            return ZoneInfo;
        }

        #endregion

        #region Logical Methods

        public virtual IList<TLMDTO00031> GetAll(string sourcebr)
        {
            return this.ZoneDAO.SelectAll(sourcebr);
        }

        public TLMDTO00031 SelectById(int id)
        {
            return this.ZoneDAO.SelectById(id);
        }

        public IList<TLMDTO00031> GetAllByDistinct()
        {
            return this.ZoneDAO.SelectAllByDistinct();
        }

        public IList<BranchDTO> GetAllBranchCode()
        {
            return this.branchDAOForAll.SelectAllBranch();
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00031 Save(TLMDTO00031 entity)
        {
            TLMORM00031 zone = null;
            if (this.ZoneDAO.CheckExist(0, entity.ZoneType, entity.BranchCode, entity.SourceBranchCode))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }
            else
            {
                zone = this.ZoneDAO.Save(this.GetZone(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), zone.CreatedUserId, zone.Id.ToString());
            }
            return zone;
        }

        public void SaveServerAndServerClient(TLMDTO00031 entity)
        {
            TLMORM00031 zone = null;       
            try
            {
                zone = this.Save(entity);
                if (zone != null)
                {                   
                    Dictionary<string, object> zoneKeyPair = new Dictionary<string, object> {
                    { "Id", zone.Id },
                    { "ZoneType", zone.ZoneType },
                    { "ZoneDesp", zone.ZoneDescription },
                    { "BrCode", zone.BranchCode }, 
                    { "ACode", zone.AccountCode },
                    { "UID", zone.UniqueId },
                    { "SourceBr", zone.SourceBranchCode } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Zone", zoneKeyPair, zone.TS, zone.CreatedUserId, zone.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                }
            }
            catch
            {              
                this.ServiceResult.ErrorOccurred = true;               
                this.ServiceResult.MessageCode = "ME90036";
            }

        }
       
        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00031 UpdateServer(TLMDTO00031 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00031 zone = null;
                if (this.zoneDAO.CheckExist(entity.Id, entity.ZoneType, entity.BranchCode, entity.SourceBranchCode))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {
                    if (this.zoneDAO.CheckAccountCode(entity.AccountCode))
                    {              
                       zone =  this.ZoneDAO.Update(GetZone(entity, false));
                       SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "MV20035";//AccountCode Not Found
                    }
                }
                return zone;   
           
        }

        public virtual void Update(TLMDTO00031 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                TLMORM00031 zone = this.UpdateServer(entity,dvcvList);
                if (zone != null)
                {
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "ZoneType", zone.ZoneType },
                    { "ZoneDesp", zone.ZoneDescription },
                    { "BrCode", zone.BranchCode },
                    { "ACode", zone.AccountCode }, 
                    { "UpdatedUserId", zone.UpdatedUserId },
                    { "UpdatedDate", DateTime.Now } ,
                    {"TS",zone.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", zone.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00031", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";//Update Success 
                }               
                
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00031 DeleteServer(TLMDTO00031 zoneDTO)
        {
            TLMORM00031 zone =   this.ZoneDAO.Delete(GetZone(zoneDTO,true),false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), zoneDTO.CreatedUserId, zoneDTO.Id.ToString());
            return zone;               
        }

        public virtual void Delete(IList<TLMDTO00031> itemList)
        {
            try
            {
                foreach (TLMDTO00031 item in itemList)
                {
                   TLMORM00031 zone = this.DeleteServer(item);
                    string id= zone.Id.ToString();
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00031", "Id", id,zone.CreatedUserId,zone.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00031 ZoneORM = new TLMORM00031();

            //Require Data
            clientDataVersionDTO.ORMObjectName = ZoneORM;
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
            CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }

        #endregion     

      
    }
}